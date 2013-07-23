namespace Installer
{
    partial class Installer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Installer));
            this.statusLabel = new System.Windows.Forms.Label();
            this.installpathbutton = new System.Windows.Forms.Button();
            this.nextbutton = new System.Windows.Forms.Button();
            this.filePath = new System.Windows.Forms.TextBox();
            this.achievementFixBox = new System.Windows.Forms.CheckBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.achievementFixToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // StatusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(11, 21);
            this.statusLabel.Name = "StatusLabel";
            this.statusLabel.Size = new System.Drawing.Size(225, 13);
            this.statusLabel.TabIndex = 0;
            this.statusLabel.Text = "Binding of Isaac Launcher Revamped Installer";
            // 
            // installpathbutton
            // 
            this.installpathbutton.Location = new System.Drawing.Point(35, 138);
            this.installpathbutton.Name = "installpathbutton";
            this.installpathbutton.Size = new System.Drawing.Size(152, 35);
            this.installpathbutton.TabIndex = 1;
            this.installpathbutton.Text = "Choose Install Path";
            this.installpathbutton.UseVisualStyleBackColor = true;
            this.installpathbutton.Click += new System.EventHandler(this.installpathbutton_Click);
            // 
            // nextbutton
            // 
            this.nextbutton.Location = new System.Drawing.Point(200, 138);
            this.nextbutton.Name = "nextbutton";
            this.nextbutton.Size = new System.Drawing.Size(152, 35);
            this.nextbutton.TabIndex = 2;
            this.nextbutton.Text = "Next";
            this.nextbutton.UseVisualStyleBackColor = true;
            this.nextbutton.Click += new System.EventHandler(this.nextbutton_Click);
            // 
            // filePath
            // 
            this.filePath.Location = new System.Drawing.Point(11, 49);
            this.filePath.Name = "filePath";
            this.filePath.ReadOnly = true;
            this.filePath.Size = new System.Drawing.Size(363, 20);
            this.filePath.TabIndex = 3;
            // 
            // achievementFixBox
            // 
            this.achievementFixBox.AutoSize = true;
            this.achievementFixBox.Location = new System.Drawing.Point(11, 75);
            this.achievementFixBox.Name = "achievementFixBox";
            this.achievementFixBox.Size = new System.Drawing.Size(199, 17);
            this.achievementFixBox.TabIndex = 4;
            this.achievementFixBox.Text = "Install Achievement Fix by 1nvisible~";
            this.achievementFixToolTip.SetToolTip(this.achievementFixBox, "The achievement fix resolves achievements earned ingame, but not unlocked on Stea" +
                    "m");
            this.achievementFixBox.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(216, 77);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(134, 13);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Achivement Fix Information";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(35, 109);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(317, 23);
            this.progressBar1.TabIndex = 6;
            // 
            // Installer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 183);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.achievementFixBox);
            this.Controls.Add(this.filePath);
            this.Controls.Add(this.nextbutton);
            this.Controls.Add(this.installpathbutton);
            this.Controls.Add(this.statusLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Installer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Binding Of Isaac Launcher: Revamped Installation";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button installpathbutton;
        private System.Windows.Forms.Button nextbutton;
        private System.Windows.Forms.TextBox filePath;
        private System.Windows.Forms.CheckBox achievementFixBox;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ToolTip achievementFixToolTip;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

