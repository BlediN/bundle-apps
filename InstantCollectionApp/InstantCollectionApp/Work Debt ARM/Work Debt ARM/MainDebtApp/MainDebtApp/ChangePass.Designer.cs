namespace MainDebtApp
{
    partial class ChangePass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePass));
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonChange = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxConfirmP = new System.Windows.Forms.TextBox();
            this.labelConfirmPass = new System.Windows.Forms.Label();
            this.labelPassNew = new System.Windows.Forms.Label();
            this.labelOldPass = new System.Windows.Forms.Label();
            this.textBoxOldPass = new System.Windows.Forms.TextBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labeloldp = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label3.Location = new System.Drawing.Point(250, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Avoid using spaces";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(250, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Min 6 characters, max 20 characters";
            // 
            // buttonChange
            // 
            this.buttonChange.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonChange.FlatAppearance.BorderSize = 0;
            this.buttonChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChange.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChange.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.buttonChange.Location = new System.Drawing.Point(130, 253);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(133, 23);
            this.buttonChange.TabIndex = 21;
            this.buttonChange.Text = "Change Password";
            this.buttonChange.UseVisualStyleBackColor = false;
            this.buttonChange.Click += new System.EventHandler(this.buttonReg_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPassword.Location = new System.Drawing.Point(130, 168);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(123, 13);
            this.textBoxPassword.TabIndex = 20;
            // 
            // textBoxConfirmP
            // 
            this.textBoxConfirmP.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBoxConfirmP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxConfirmP.Location = new System.Drawing.Point(130, 208);
            this.textBoxConfirmP.Name = "textBoxConfirmP";
            this.textBoxConfirmP.PasswordChar = '*';
            this.textBoxConfirmP.Size = new System.Drawing.Size(123, 13);
            this.textBoxConfirmP.TabIndex = 19;
            // 
            // labelConfirmPass
            // 
            this.labelConfirmPass.AutoSize = true;
            this.labelConfirmPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelConfirmPass.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConfirmPass.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelConfirmPass.Location = new System.Drawing.Point(15, 207);
            this.labelConfirmPass.Name = "labelConfirmPass";
            this.labelConfirmPass.Size = new System.Drawing.Size(110, 15);
            this.labelConfirmPass.TabIndex = 16;
            this.labelConfirmPass.Text = "Confirm Password";
            // 
            // labelPassNew
            // 
            this.labelPassNew.AutoSize = true;
            this.labelPassNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelPassNew.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPassNew.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelPassNew.Location = new System.Drawing.Point(15, 167);
            this.labelPassNew.Name = "labelPassNew";
            this.labelPassNew.Size = new System.Drawing.Size(91, 15);
            this.labelPassNew.TabIndex = 15;
            this.labelPassNew.Text = "New Password";
            // 
            // labelOldPass
            // 
            this.labelOldPass.AutoSize = true;
            this.labelOldPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelOldPass.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOldPass.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelOldPass.Location = new System.Drawing.Point(15, 124);
            this.labelOldPass.Name = "labelOldPass";
            this.labelOldPass.Size = new System.Drawing.Size(85, 15);
            this.labelOldPass.TabIndex = 14;
            this.labelOldPass.Text = "Old Password";
            // 
            // textBoxOldPass
            // 
            this.textBoxOldPass.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBoxOldPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxOldPass.Location = new System.Drawing.Point(130, 127);
            this.textBoxOldPass.Name = "textBoxOldPass";
            this.textBoxOldPass.PasswordChar = '*';
            this.textBoxOldPass.Size = new System.Drawing.Size(123, 13);
            this.textBoxOldPass.TabIndex = 18;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelUsername.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsername.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelUsername.Location = new System.Drawing.Point(15, 89);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(66, 15);
            this.labelUsername.TabIndex = 26;
            this.labelUsername.Text = "Username";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label6.Location = new System.Drawing.Point(127, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 15);
            this.label6.TabIndex = 27;
            this.label6.Text = "label6";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(116, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 18);
            this.label1.TabIndex = 28;
            this.label1.Text = "Change Password";
            // 
            // labeloldp
            // 
            this.labeloldp.AutoSize = true;
            this.labeloldp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labeloldp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeloldp.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labeloldp.Location = new System.Drawing.Point(250, 129);
            this.labeloldp.Name = "labeloldp";
            this.labeloldp.Size = new System.Drawing.Size(96, 13);
            this.labeloldp.TabIndex = 29;
            this.labeloldp.Text = "Type old password";
            // 
            // ChangePass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(429, 321);
            this.Controls.Add(this.labeloldp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonChange);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxConfirmP);
            this.Controls.Add(this.textBoxOldPass);
            this.Controls.Add(this.labelConfirmPass);
            this.Controls.Add(this.labelPassNew);
            this.Controls.Add(this.labelOldPass);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChangePass";
            this.Text = "Change Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxConfirmP;
        private System.Windows.Forms.Label labelConfirmPass;
        private System.Windows.Forms.Label labelPassNew;
        private System.Windows.Forms.Label labelOldPass;
        private System.Windows.Forms.TextBox textBoxOldPass;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labeloldp;
    }
}