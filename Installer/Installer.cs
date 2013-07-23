using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Diagnostics;


namespace Installer
{
    public partial class Installer : Form
    {
        FolderBrowserDialog dialog = new FolderBrowserDialog();

        public Installer()
        {
            InitializeComponent();

            //Initialize FolderBrowserDialog with default Steam path
            dialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\Steam\steamapps\common\the binding of isaac";
            dialog.Description = "Select where Binding of Isaac: Wrath of the Lamb has been installed";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Set Achievement Fix tooltip
            achievementFixToolTip.SetToolTip(achievementFixBox, "The Achievement Fix fixes certain achievements not unlocking in Steam.");
            //Check that all files are present before continuing
            if (!CheckFiles().Equals("good"))
            {
                MessageBox.Show(CheckFiles() + " is missing, installer can not continue");
                this.Close();
            }
            else
            {
                //Ask user if he/she wants to install
                DialogResult confirm = MessageBox.Show("Install The Binding of Isaac Launcher: Revamped?" + Environment.NewLine + "The Binding of Isaac Launcher: Revamped will not install if the Wrath of the Lamb DLC is not installed", "Install The Binding of Isaac Launcher?", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.No)
                {
                    this.Close();
                }

                StatusLabel.Text = "Binding of Isaac Launcher: Revamped will install to";
                filePath.Text = dialog.SelectedPath;

            }



        }

        private string CheckFiles()
        {
            //Check for xdelta patch util
            String StartPath = Application.StartupPath;
            if (!File.Exists(StartPath + @"\xdelta.exe"))
            {
                return "xdelta.exe";
            }
            //Check for patch file
            if (!File.Exists(StartPath + @"\patch.xdelta"))
            {
                return "patch.xdelta";
            }
            //Check for launcher file
            if (!File.Exists(StartPath + @"\launcher.exe"))
            {
                return "launcher.exe";
            }
            //Check for AchievementFix
            if (!File.Exists(StartPath + @"\FlashAchievements.exe"))
            {
                return "FlashAchievements.exe";
            }
            //Check for Uninstall file
            if (!File.Exists(StartPath + @"\uninstaller.exe"))
            {
                return "uninstaller.exe";
            }
            //Check for Wrath of the Lamb md5
            if (!File.Exists(StartPath + @"\WotL.md5"))
            {
                return "WotL.md5";
            }
            //check for Vanilla md5
            if (!File.Exists(StartPath+@"\Vanilla.md5")){
                return "Vanilla.md5";
            }
            //If everything is present, we return "good"
            return "good";
        }
        
        private void nextbutton_Click(object sender, EventArgs e)
        {

            //Confirm installation
            DialogResult confirm = MessageBox.Show("Are you sure you want to install The Binding of Isaac Launcher to" + Environment.NewLine + dialog.SelectedPath, "Install The Binding of Isaac Launcher?", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.No)
            {
                return;
            }
            else
            {
                //Hide unecessary controls
                installpathbutton.Hide();
                nextbutton.Hide();
                filePath.Hide();
                linkLabel1.Hide();
                achievementFixBox.Hide();
                //Check MD5 hash to confirm legit copy
                if (!CheckMD5Isaac(dialog.SelectedPath+@"\Isaac.exe","Checking existing Binding of Isaac installation",File.ReadAllText(Application.StartupPath+@"\WotL.md5")))
                {
                    MessageBox.Show("The Binding of Isaac was not found, or did not include a valid installation of The Wrath of the Lamb");
                    this.Close();
                }
                else
                {
                    //Patch Wrath of the Lamb
                    PatchWotL();
                    //Copy Launcher to directory
                    InstallLauncher();
                    //Install Save file fix
                    InstallSaveFile();
                    //If the achievement fix is checked, install achievement fix
                    if (achievementFixBox.Checked)
                    {
                        InstallAchievementFix();
                    }
                    MessageBox.Show("The Binding of Isaac Launcher: Revamped has been installed." + Environment.NewLine + "To uninstall, please run " + dialog.SelectedPath + @"\uninstall.exe");
                }


            }

        }

        private void installpathbutton_Click(object sender, EventArgs e)
        {
            //Open dialog 
            dialog.ShowDialog();
            filePath.Text = dialog.SelectedPath;
        }

        private void InstallLauncher()
        {
            //Just copy the launcher and uninstaller to selected path
            StatusLabel.Text = "Installing Launcher";
            File.Copy(Application.StartupPath + @"\launcher.exe", dialog.SelectedPath + @"\Isaac.exe");
            if(File.Exists(dialog.SelectedPath+@"\uninstall.exe")){
                File.Delete(dialog.SelectedPath+@"\uninstall.exe");
            }

            File.Copy(Application.StartupPath + @"\uninstaller.exe", dialog.SelectedPath + @"\uninstall.exe");
            MessageBox.Show("The Binding of Isaac Launcher has been installed");
            this.Close();
        }

        private void InstallAchievementFix()
        {
            //Copy the achievement fix and back up the old one
            StatusLabel.Text = "Installing Achievement Fix";
            if(!File.Exists(Path.Combine(dialog.SelectedPath,"FlashAchievements.old"))){
                File.Copy(Path.Combine(dialog.SelectedPath , "FlashAchievements.exe"), Path.Combine(dialog.SelectedPath , "FlashAchievements.old"));
            }
            File.Delete(Path.Combine(dialog.SelectedPath, "FlashAchievements.exe"));
            File.Copy(Path.Combine(Application.StartupPath, "FlashAchievements.exe"), Path.Combine(dialog.SelectedPath,"FlashAchievements.exe"));
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://forums.steampowered.com/forums/showthread.php?t=2216833");
        }

        private string GetSolPath()
        {
            string savePathContainer = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Macromedia", "Flash Player", "#SharedObjects");
            string savePath = Path.Combine(Directory.GetDirectories(savePathContainer).First(), "localhost");
            return savePath;
        }

        private void InstallSaveFile()
        {
            string WotlSolSaveFile = Path.Combine(GetSolPath(), "so.sol");
            File.Move(WotlSolSaveFile,Path.Combine(dialog.SelectedPath,"so.sol.wotl"));
            File.Create(Path.Combine(dialog.SelectedPath, "so.sol.boi")).Dispose();
            File.Delete(Path.Combine(dialog.SelectedPath, "serial.txt"));
            File.Create(Path.Combine(dialog.SelectedPath, "serial.txt")).Dispose();
            File.SetAttributes(Path.Combine(dialog.SelectedPath,"serial.txt"), FileAttributes.ReadOnly);

        }

        #region ported
        private void PatchWotL()
        {

            StatusLabel.Text = "Patching Wrath of The Lamb to Vanilla";
            //For some odd reason, if we specify path to xdelta, the resulting app will have admin manifest, so we copy it to the application startup directory
            File.Copy(dialog.SelectedPath + @"\Isaac.exe", dialog.SelectedPath + @"\Isaac_WotL.exe");
            //Copy the Wrath of the Lamb EXE Application Startup
            File.Copy(dialog.SelectedPath + @"\Isaac.exe", Application.StartupPath + @"\Isaac.exe");
            ProcessStartInfo xdelta = new ProcessStartInfo(Application.StartupPath + @"\xdelta.exe", "patch patch.xdelta Isaac.exe");
            xdelta.WorkingDirectory = Application.StartupPath;
            xdelta.WindowStyle = ProcessWindowStyle.Hidden;
            //Here we do the actual patching
            Process.Start(xdelta).WaitForExit();
            //Clean up
            File.Delete(Application.StartupPath + @"\Isaac.exe");
            //Make sure patch completed successfully
            if (!CheckMD5Isaac(Application.StartupPath + @"\Isaac_Vanilla.exe", "Confirming integrity of installation", File.ReadAllText(Application.StartupPath + @"\Vanilla.md5")))
            {
                MessageBox.Show("An Error Occured, patch did not complete successfully. Please attempt to reinstall");
                StatusLabel.Text = "Cleaning Files, please do not close the installer";
                File.Delete(dialog.SelectedPath + @"\Isaac_WotL.exe");
                try
                {
                    File.Delete(Application.StartupPath + @"\Isaac_Vanilla.exe");
                }
                catch (System.IO.FileNotFoundException)
                {
                    this.Close();
                }
                this.Close();
            }
            //Copy newly patched vanilla to selected path
            File.Copy(Application.StartupPath + @"\Isaac_Vanilla.exe", dialog.SelectedPath + @"\Isaac_Vanilla.exe");
            //Clean up
            File.Delete(Application.StartupPath + @"\Isaac_Vanilla.exe");
            //Clean up 
            File.Delete(dialog.SelectedPath + @"\Isaac.exe");

        }

        private bool CheckMD5Isaac(string filename, string statuslabel, string md5)
        {
            StatusLabel.Text = statuslabel;
            if (!File.Exists(filename))
            {
                return false;
            }


            if (!GetFilesMD5Hash(filename).Equals(md5, StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }
            else
            {

                return true;

            }
        }

        public string GetFilesMD5Hash(string file)
        {
            //MD5 hash provider for computing the hash of the file
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            //open the file
            FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read, 8192);

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


        #endregion
    }

}
