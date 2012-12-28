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
            this.StatusLabel = new System.Windows.Forms.Label();
            this.installpathbutton = new System.Windows.Forms.Button();
            this.nextbutton = new System.Windows.Forms.Button();
            this.filePath = new System.Windows.Forms.TextBox();
            this.achievementFixBox = new System.Windows.Forms.CheckBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.achievementFixToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(11, 21);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(225, 13);
            this.StatusLabel.TabIndex = 0;
            this.StatusLabel.Text = "Binding of Isaac Launcher Revamped Installer";
            // 
            // installpathbutton
            // 
            this.installpathbutton.Location = new System.Drawing.Point(35, 216);
            this.installpathbutton.Name = "installpathbutton";
            this.installpathbutton.Size = new System.Drawing.Size(152, 35);
            this.installpathbutton.TabIndex = 1;
            this.installpathbutton.Text = "Choose Install Path";
            this.installpathbutton.UseVisualStyleBackColor = true;
            this.installpathbutton.Click += new System.EventHandler(this.nextbutton_Click);
            // 
            // nextbutton
            // 
            this.nextbutton.Location = new System.Drawing.Point(200, 216);
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
            this.achievementFixBox.Location = new System.Drawing.Point(11, 76);
            this.achievementFixBox.Name = "achievementFixBox";
            this.achievementFixBox.Size = new System.Drawing.Size(214, 17);
            this.achievementFixBox.TabIndex = 4;
            this.achievementFixBox.Text = "Install Achievement Fix (by 1nvisible~) ?";
            this.achievementFixBox.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(8, 96);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(171, 13);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "More info on Achievement Fix here";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Installer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 262);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.achievementFixBox);
            this.Controls.Add(this.filePath);
            this.Controls.Add(this.nextbutton);
            this.Controls.Add(this.installpathbutton);
            this.Controls.Add(this.StatusLabel);
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

        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Button installpathbutton;
        private System.Windows.Forms.Button nextbutton;
        private System.Windows.Forms.TextBox filePath;
        private System.Windows.Forms.CheckBox achievementFixBox;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ToolTip achievementFixToolTip;
    }
}

