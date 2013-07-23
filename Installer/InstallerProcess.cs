// -----------------------------------------------------------------------
// <copyright file="InstallerMethods.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Installer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    using System.IO;
    using System.Security.Cryptography;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class InstallerProcess 
    {
        string isaacPath;
        string installerPath;
        bool installAchievements;

        string vanillaPath;
        string wrathOfTheLambPath;

        public InstallerProcess(string isaacPath, string installerPath,  bool installAchievements)
        {
            this.isaacPath = isaacPath;
            this.installAchievements = installAchievements;
            this.installerPath = installerPath;

            this.vanillaPath = Path.Combine(isaacPath, "vanilla");
            this.wrathOfTheLambPath = Path.Combine(isaacPath, "wotl");
        }

        public bool PatchWrathOfTheLamb()
        {
            //For some odd reason, if we specify path to xdelta, the resulting app will have admin manifest, so we copy it to the application startup directory
            
            //Copy unpatched Isaac.exe to Wrath of The Lamb folder
            File.Copy(Path.Combine(isaacPath, "Isaac.exe"), Path.Combine(wrathOfTheLambPath,"Isaac_WotL.exe"));
           
            //Copy the Wrath of the Lamb EXE Application Startup
            File.Copy(Path.Combine(isaacPath, "Isaac.exe"), Path.Combine(installerPath, "Isaac.exe"));

   
            //Patch Wrath of The Lamb to Isaac_Vanilla.exe
            Process.Start(GetXdelta("patch patch.xdelta Isaac.exe")).WaitForExit();
            //patch.xdelta patches to Isaac_Vanilla.exe

            //Clean up temp Wrath of The Lamb executable
            File.Delete(Path.Combine(installerPath, "Isaac.exe"));

            //Check patched file integrity
            if (!CheckMD5(Path.Combine(installerPath, "Isaac_Vanilla.exe"), File.ReadAllText(Path.Combine(installerPath, "Vanilla.md5"))))
            {
                //Cleanup files, since patch failed
                File.Delete(Path.Combine(isaacPath, "Isaac_WotL.exe"));
                try
                {
                    File.Delete(Path.Combine(installerPath,"Isaac_Vanilla.exe"));
                }
                catch (FileNotFoundException)
                {
                   //If Isaac_Vanilla.exe wasn't created, just ignore it and continue
                }
                return false;
            }

            //Move newly patched vanilla to selected path
            File.Move(Path.Combine(installerPath, "Isaac_Vanilla.exe"), Path.Combine(vanillaPath, "Isaac_Vanilla.exe"));

            //Delete unpatched Isaac.exe
            File.Delete(Path.Combine(isaacPath, "Isaac.exe"));
            return true;
        }


        private ProcessStartInfo GetXdelta(string args)
        {
            ProcessStartInfo xdelta = new ProcessStartInfo(Path.Combine(installerPath, "xdelta.exe"), args);
            xdelta.WorkingDirectory = installerPath;
            xdelta.WindowStyle = ProcessWindowStyle.Hidden;
            return xdelta;
        }


        private void InstallLauncher()
        {
            //Check if file exists, then move the launcher and uninstaller to selected path
            
            if(File.Exists(Path.Combine(isaacPath, "Isaac.exe"))){
                File.Delete(Path.Combine(isaacPath, "Isaac.exe"));
            }

            if (File.Exists(Path.Combine(isaacPath, "uninstall.exe")))
            {
                File.Delete(Path.Combine(isaacPath, "uninstall.exe"));
            }

            File.Move(Path.Combine(installerPath, "launcher.exe"), Path.Combine(isaacPath, "Isaac.exe"));
            File.Move(Path.Combine(installerPath, "uninstaller.exe"), Path.Combine(isaacPath, "uninstall.exe"));
        }

        #region MD5
        /// <summary>
        /// Gets MD5 hash of a file
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <returns>MD5 hash of file</returns>
        private string GetMD5(string path)
        {
            //MD5 hash provider for computing the hash of the file
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            //open the file
            FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, 8192);

            //calculate the files hash
            md5.ComputeHash(stream);

            //close our stream
            stream.Close();

            //byte array of files hash
            byte[] hash = md5.Hash;

            //string builder to hold the results
            StringBuilder sb = new StringBuilder();

            //loop through each byte in the byte array
            foreach (byte b in hash)
            {
                //format each byte into the proper value and append
                //current value to return value
                sb.Append(string.Format("{0:X2}", b));
            }

            //return the MD5 hash of the file
            return sb.ToString();
        }

        /// <summary>
        /// Checks MD5 of a file path
        /// </summary>
        /// <param name="path"></param>
        /// <param name="md5check"></param>
        /// <returns>Whether MD5 matches or not</returns>
        private bool CheckMD5(string path, string md5)
        {
            if(GetMD5(path).Equals(md5, StringComparison.InvariantCultureIgnoreCase)) {
                return true;
            }else{
                return false;
            }
        }
        #endregion
    }
}
