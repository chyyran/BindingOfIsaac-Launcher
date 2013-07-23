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
        string vanillaPath;
        string wrathOfTheLambPath;

        public InstallerProcess(string isaacPath, string installerPath)
        {
            this.isaacPath = isaacPath;
            this.installerPath = installerPath;

            this.vanillaPath = Path.Combine(isaacPath, "vanilla");
            this.wrathOfTheLambPath = Path.Combine(isaacPath, "wotl");
        }

        public void CreateFolderStructure()
        {
            if(!Directory.Exists(wrathOfTheLambPath)){
                Directory.CreateDirectory(wrathOfTheLambPath);
            }

            if(!Directory.Exists(vanillaPath)){
                Directory.CreateDirectory(vanillaPath);
            }

        }

        public void PatchWrathOfTheLamb()
        {
            //For some odd reason, if we specify path to xdelta, the resulting app will have admin manifest, so we copy it to the application startup directory
            
            //Copy unpatched Isaac.exe to Wrath of The Lamb folder
            File.Copy(Path.Combine(isaacPath, "Isaac.exe"), Path.Combine(wrathOfTheLambPath,"Isaac_WotL.exe"), true);
           
            //Copy the Wrath of the Lamb EXE Application Startup
            File.Copy(Path.Combine(isaacPath, "Isaac.exe"), Path.Combine(installerPath, "Isaac.exe"), true);

   
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
                    File.Delete(Path.Combine(installerPath, "Isaac_Vanilla.exe"));
                }
                catch (FileNotFoundException)
                {
                    //If Isaac_Vanilla.exe wasn't created, just ignore it and continue
                }
                finally
                {
                    throw new IOException("Isaac.exe was not patched correctly");
                }
            }

            //Move newly patched vanilla to selected path
            MoveFileOverwrite(Path.Combine(installerPath, "Isaac_Vanilla.exe"), Path.Combine(vanillaPath, "Isaac_Vanilla.exe"));

            //Delete unpatched Isaac.exe
            File.Delete(Path.Combine(isaacPath, "Isaac.exe"));
        }

        public void InstallLauncher()
        {           
            File.Copy(Path.Combine(installerPath, "launcher.exe"), Path.Combine(isaacPath, "Isaac.exe"), true);
            File.Copy(Path.Combine(installerPath, "uninstaller.exe"), Path.Combine(isaacPath, "uninstall.exe"), true);
        }

        public void InstallAchievementFix()
        {
            //Copy the achievement fix and back up the old one
            if (!File.Exists(Path.Combine(isaacPath, "FlashAchievements.old")))
            {
                File.Move(Path.Combine(isaacPath, "FlashAchievements.exe"), Path.Combine(isaacPath, "FlashAchievements.old"));  
            }

            File.Copy(Path.Combine(installerPath, "FlashAchievements.exe"), Path.Combine(isaacPath, "FlashAchievements.exe"), true);
        }

        public void CopyFlashAchievements()
        {
            File.Copy(Path.Combine(isaacPath, "FlashAchievements.exe"), Path.Combine(wrathOfTheLambPath, "FlashAchievements.exe"), true);
            File.Copy(Path.Combine(isaacPath, "FlashAchievements.exe"), Path.Combine(vanillaPath, "FlashAchievements.exe"), true);

            File.Copy(Path.Combine(isaacPath, "steam_api.dll"), Path.Combine(wrathOfTheLambPath, "steam_api.dll"), true);
            File.Copy(Path.Combine(isaacPath, "steam_api.dll"), Path.Combine(vanillaPath, "steam_api.dll"), true);
        }

        public void InstallSavesFix()
        {

            //Move existing save file to Wrath Of The Lamb folder
            if (File.Exists(Path.Combine(isaacPath, "serial.txt")))
            {
                File.Copy(Path.Combine(isaacPath, "serial.txt"), Path.Combine(isaacPath, "serial.txt.bak"), true);
                MoveFileOverwrite(Path.Combine(isaacPath, "serial.txt"), Path.Combine(wrathOfTheLambPath, "serial.txt"));
            }


            //stub so.sol and so.sxx

            Path.Combine(GetSolPath(), "so.sol");

            if(File.Exists(Path.Combine(GetSolPath(), "so.sol"))){
                File.SetAttributes(Path.Combine(GetSolPath(), "so.sol"), FileAttributes.Normal);
                File.Delete(Path.Combine(GetSolPath(), "so.sol"));
            }


            if (File.Exists(Path.Combine(GetSolPath(), "so.sxx")))
            {
                File.SetAttributes(Path.Combine(GetSolPath(), "so.sxx"), FileAttributes.Normal);
                File.Delete(Path.Combine(GetSolPath(), "so.sxx"));
            }

            File.Create(Path.Combine(GetSolPath(), "so.sol")).Dispose();
            File.Create(Path.Combine(GetSolPath(), "so.sxx")).Dispose();

            File.SetAttributes(Path.Combine(GetSolPath(), "so.sxx"), FileAttributes.ReadOnly);
            File.SetAttributes(Path.Combine(GetSolPath(), "so.sol"), FileAttributes.ReadOnly);

        }

        #region misc

        private ProcessStartInfo GetXdelta(string args)
        {
            ProcessStartInfo xdelta = new ProcessStartInfo(Path.Combine(installerPath, "xdelta.exe"), args);
            xdelta.WorkingDirectory = installerPath;
            xdelta.WindowStyle = ProcessWindowStyle.Hidden;
            return xdelta;
        }

        private string GetSolPath()
        {
            string savePathContainer = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Macromedia", "Flash Player", "#SharedObjects");
            string savePath = Path.Combine(Directory.GetDirectories(savePathContainer).First(), "localhost");
            return savePath;
        }

        private static void MoveFileOverwrite(string oldPath, string newPath)
        {
            File.Copy(oldPath, newPath, true);
            File.Delete(oldPath);
        }
        #endregion

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

        public static void ExceptionCleanup(string isaacPath)
        {
            if (Directory.Exists(Path.Combine(isaacPath, "wotl"))){
                Directory.Delete(Path.Combine(isaacPath, "wotl"), true);
            }

            if (Directory.Exists(Path.Combine(isaacPath, "vanilla"))){
                Directory.Delete(Path.Combine(isaacPath, "vanilla"), true);
            }

            if (File.Exists(Path.Combine(isaacPath, "serial.txt.bak")))
            {
                MoveFileOverwrite(Path.Combine(isaacPath, "serial.txt.bak"), Path.Combine(isaacPath, "serial.txt"));
            }
            

            //Validate files with Steam
            Process.Start("steam://validate/113200");
        }
    }
}
