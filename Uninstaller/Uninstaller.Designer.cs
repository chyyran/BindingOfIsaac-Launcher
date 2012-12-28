namespace Uninstaller
{
    partial class Uninstaller
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Uninstaller));
            this.statusLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.achievementFix = new System.Windows.Forms.CheckBox();
            this.wotlButton = new System.Windows.Forms.Button();
            this.vanillaButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(15, 13);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(193, 13);
            this.statusLabel.TabIndex = 0;
            this.statusLabel.Text = "Binding of Isaac: Revamped Uninstaller";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(18, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(317, 20);
            this.textBox1.TabIndex = 1;
            // 
            // achievementFix
            // 
            this.achievementFix.AutoSize = true;
            this.achievementFix.Checked = true;
            this.achievementFix.CheckState = System.Windows.Forms.CheckState.Checked;
            this.achievementFix.Location = new System.Drawing.Point(18, 55);
            this.achievementFix.Name = "achievementFix";
            this.achievementFix.Size = new System.Drawing.Size(138, 17);
            this.achievementFix.TabIndex = 2;
            this.achievementFix.Text = "Keep Achievement Fix?";
            this.achievementFix.UseVisualStyleBackColor = true;
            // 
            // wotlButton
            // 
            this.wotlButton.Location = new System.Drawing.Point(18, 88);
            this.wotlButton.Name = "wotlButton";
            this.wotlButton.Size = new System.Drawing.Size(147, 40);
            this.wotlButton.TabIndex = 3;
            this.wotlButton.Text = "Uninstall and keep Wrath of the Lamb DLC";
            this.wotlButton.UseVisualStyleBackColor = true;
            this.wotlButton.Click += new System.EventHandler(this.wotlButton_Click);
            // 
            // vanillaButton
            // 
            this.vanillaButton.Location = new System.Drawing.Point(188, 88);
            this.vanillaButton.Name = "vanillaButton";
            this.vanillaButton.Size = new System.Drawing.Size(147, 40);
            this.vanillaButton.TabIndex = 4;
            this.vanillaButton.Text = "Uninstall and keep Vanilla Binding of Isaac";
            this.vanillaButton.UseVisualStyleBackColor = true;
            this.vanillaButton.Click += new System.EventHandler(this.vanillaButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(18, 135);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(317, 34);
            this.exitButton.TabIndex = 5;
            this.exitButton.Text = "Exit Uninstaller";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // Uninstaller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 182);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.vanillaButton);
            this.Controls.Add(this.wotlButton);
            this.Controls.Add(this.achievementFix);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.statusLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Uninstaller";
            this.Text = "Binding of Isaac: Revamped Uninstallation";
            this.Load += new System.EventHandler(this.Uninstaller_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox achievementFix;
        private System.Windows.Forms.Button wotlButton;
        private System.Windows.Forms.Button vanillaButton;
        private System.Windows.Forms.Button exitButton;
    }
}

