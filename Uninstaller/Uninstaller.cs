using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace Uninstaller
{
    public partial class Uninstaller : Form
    {
        public Uninstaller()
        {
            InitializeComponent();
        }

        private void Uninstaller_Load(object sender, EventArgs e)
        {
            CheckFiles();
            DialogResult result = MessageBox.Show("Are you sure you want to uninstall The Binding of Isaac Launcher: Revamped", "Uninstall The Binding of Isaac Launcher: Revamped?", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                this.Close();
            }
            statusLabel.Text = "The Binding of Isaac Launcher: Revamped will uninstall from";
            textBox1.Text = Application.StartupPath;


        }

        private void CheckFiles()
        {
            if(!File.Exists(Path.Combine(Application.StartupPath,"FlashAchievements.old"))){
                achievementFix.Hide();
                achievementFix.Checked = true;
            }
            if(!File.Exists(Path.Combine(Application.StartupPath,"Isaac.exe"))){
               
                MessageBox.Show("The Binding of Isaac Launcher: Revamped was not found." + Environment.NewLine + "Make sure you started the uninstaller in your Binding of Isaac install directory");
                this.Close();
            }

            if (!Directory.Exists(Path.Combine(Application.StartupPath, "wotl")))
            {
                wotlButton.Enabled = false;
            }

            if (!Directory.Exists(Path.Combine(Application.StartupPath, "vanilla")))
            {
                vanillaButton.Enabled = false;
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void wotlButton_Click(object sender, EventArgs e)
        {
            uninstall(GameTypes.BOI_WOTL);
            MessageBox.Show("The Binding of Isaac Launcher has been uninstalled. Wrath of the Lamb was kept");
            this.Close();
        }

        private void vanillaButton_Click(object sender, EventArgs e)
        {
            uninstall(GameTypes.BOI_VANILLA);
            MessageBox.Show("The Binding of Isaac Launcher has been uninstalled. Vanilla Binding of Isaac was kept");
            this.Close();
        }


        private void uninstall(GameTypes keep)
        {
            wotlButton.Hide();
            vanillaButton.Hide();
            textBox1.Hide();
            exitButton.Hide();
            achievementFix.Hide();
            
            statusLabel.Text = "Uninstalling Binding of Isaac Launcher";
 
            if (keep == GameTypes.BOI_VANILLA)
            {
                File.Copy(Path.Combine(Application.StartupPath, "vanilla","Isaac_Vanilla.exe"), Path.Combine(Application.StartupPath,"Isaac.exe"), true);
                File.Copy(Path.Combine(Application.StartupPath, "vanilla", "serial.txt"), Path.Combine(Application.StartupPath, "serial.txt"), true);

            }

            if (keep == GameTypes.BOI_WOTL)
            {
                File.Copy(Path.Combine(Application.StartupPath, "wotl", "Isaac_WotL.exe"), Path.Combine(Application.StartupPath, "Isaac.exe"), true);
                File.Copy(Path.Combine(Application.StartupPath, "wotl", "serial.txt"), Path.Combine(Application.StartupPath, "serial.txt"), true);

            }

            if (!achievementFix.Checked)
            {
                statusLabel.Text = "Uninstalling Achievement Fix";
                File.Delete(Path.Combine(Application.StartupPath,"FlashAchievements.exe"));
                File.Move(Path.Combine(Application.StartupPath,"FlashAchievements.old"),Path.Combine(Application.StartupPath, "FlashAchievements.exe"));
            }

            if (File.Exists(Path.Combine(GetSolPath(), "so.sol")))
            {
                File.SetAttributes(Path.Combine(GetSolPath(), "so.sol"), FileAttributes.Normal);
                File.Delete(Path.Combine(GetSolPath(), "so.sol"));
            }


            if (File.Exists(Path.Combine(GetSolPath(), "so.sxx")))
            {
                File.SetAttributes(Path.Combine(GetSolPath(), "so.sxx"), FileAttributes.Normal);
                File.Delete(Path.Combine(GetSolPath(), "so.sxx"));
            }
            
            Directory.Delete(Path.Combine(Application.StartupPath, "vanilla"),true);
            Directory.Delete(Path.Combine(Application.StartupPath, "wotl"), true);
            File.Delete(Path.Combine(Application.StartupPath, "serial.txt.bak"));
        }

        private string GetSolPath()
        {
            string savePathContainer = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Macromedia", "Flash Player", "#SharedObjects");
            string savePath = Path.Combine(Directory.GetDirectories(savePathContainer).First(), "localhost");
            return savePath;
        }

    }

    public enum GameTypes
    {
        BOI_WOTL,
        BOI_VANILLA
    }
}
