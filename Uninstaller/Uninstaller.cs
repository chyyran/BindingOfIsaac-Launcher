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
            if(!File.Exists(Application.StartupPath+@"\FlashAchievements.old")){
                achievementFix.Enabled = false;
                achievementFix.Checked = false;
            }
            if(!File.Exists(Application.StartupPath+@"\Isaac.exe")){
               
                MessageBox.Show("The Binding of Isaac Launcher: Revamped was not found." + Environment.NewLine + "Make sure you started the uninstaller in your Binding of Isaac install directory");
                this.Close();
            }

            if (!File.Exists(Application.StartupPath + @"\Isaac_WotL.exe"))
            {
                wotlButton.Enabled = false;
            }

            if (!File.Exists(Application.StartupPath + @"\Isaac_Vanilla.exe"))
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
            uninstall("Isaac_WotL.exe", "Isaac_Vanilla.exe", achievementFix.Checked);
            MessageBox.Show("The Binding of Isaac Launcher has been uninstalled. Wrath of the Lamb was kept");
            this.Close();
        }

        private void uninstall(string keep, string remove, bool keepAchievements)
        {
            wotlButton.Hide();
            vanillaButton.Hide();
            textBox1.Hide();
            exitButton.Hide();
            achievementFix.Hide();
            statusLabel.Text = "Uninstalling Binding of Isaac Launcher";
            File.Delete(Application.StartupPath + @"\Isaac.exe");
            File.Delete(Application.StartupPath + @"\" + remove);
            File.Copy(Application.StartupPath + @"\" + keep, Application.StartupPath + @"\Isaac.exe");
            File.Delete(Application.StartupPath + @"\" + keep);
            if (!keepAchievements)
            {
                statusLabel.Text = "Uninstalling Achievement Fix";
                File.Delete(Application.StartupPath + @"\FlashAchievements.exe");
                File.Copy(Application.StartupPath + @"\FlashAchievements.old",Application.StartupPath + @"\FlashAchievements.exe");
                File.Delete(Application.StartupPath + @"\FlashAchievements.old");
            }
        }

        private void vanillaButton_Click(object sender, EventArgs e)
        {
            uninstall("Isaac_Vanilla.exe", "Isaac_WotL.exe", achievementFix.Checked);
            MessageBox.Show("The Binding of Isaac Launcher has been uninstalled. Vanilla Binding of Isaac was kept");
            this.Close();
        }


        

    }
}
