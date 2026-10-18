namespace MainDebtApp
{
    partial class Letter
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
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxProvider = new System.Windows.Forms.ComboBox();
            this.textBoxDays = new System.Windows.Forms.TextBox();
            this.labelPaidAmt = new System.Windows.Forms.Label();
            this.textBoxno = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxReceiver = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.buttonSave.Location = new System.Drawing.Point(91, 257);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(94, 27);
            this.buttonSave.TabIndex = 11;
            this.buttonSave.Text = "Single letter";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.ForeColor = System.Drawing.Color.Red;
            this.buttonCancel.Location = new System.Drawing.Point(2, 257);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(73, 27);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(25, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Type";
            // 
            // comboBoxProvider
            // 
            this.comboBoxProvider.BackColor = System.Drawing.SystemColors.ControlLight;
            this.comboBoxProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProvider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxProvider.FormattingEnabled = true;
            this.comboBoxProvider.Items.AddRange(new object[] {
            "DAF 1",
            "KDCA 1",
            "Union Bank",
            "DAF 2",
            "KDCA 2",
            "Vertetim",
            "Vertetim elektronik",
            "Albtel Letra1",
            "Albtel Letra2",
            "Albtel Zyra"});
            this.comboBoxProvider.Location = new System.Drawing.Point(29, 52);
            this.comboBoxProvider.Name = "comboBoxProvider";
            this.comboBoxProvider.Size = new System.Drawing.Size(198, 21);
            this.comboBoxProvider.TabIndex = 6;
            // 
            // textBoxDays
            // 
            this.textBoxDays.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBoxDays.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDays.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBoxDays.Location = new System.Drawing.Point(28, 162);
            this.textBoxDays.Name = "textBoxDays";
            this.textBoxDays.Size = new System.Drawing.Size(199, 13);
            this.textBoxDays.TabIndex = 34;
            this.textBoxDays.Text = "10";
            // 
            // labelPaidAmt
            // 
            this.labelPaidAmt.AutoSize = true;
            this.labelPaidAmt.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPaidAmt.ForeColor = System.Drawing.SystemColors.Desktop;
            this.labelPaidAmt.Location = new System.Drawing.Point(25, 144);
            this.labelPaidAmt.Name = "labelPaidAmt";
            this.labelPaidAmt.Size = new System.Drawing.Size(62, 15);
            this.labelPaidAmt.TabIndex = 35;
            this.labelPaidAmt.Text = "Due days:";
            // 
            // textBoxno
            // 
            this.textBoxno.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBoxno.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxno.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBoxno.Location = new System.Drawing.Point(28, 223);
            this.textBoxno.Name = "textBoxno";
            this.textBoxno.Size = new System.Drawing.Size(199, 13);
            this.textBoxno.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(25, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 37;
            this.label2.Text = "Contact No:";
            // 
            // comboBoxReceiver
            // 
            this.comboBoxReceiver.BackColor = System.Drawing.SystemColors.ControlLight;
            this.comboBoxReceiver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxReceiver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxReceiver.FormattingEnabled = true;
            this.comboBoxReceiver.Items.AddRange(new object[] {
            "D&A Fin Partner",
            "KDCA"});
            this.comboBoxReceiver.Location = new System.Drawing.Point(26, 108);
            this.comboBoxReceiver.Name = "comboBoxReceiver";
            this.comboBoxReceiver.Size = new System.Drawing.Size(201, 21);
            this.comboBoxReceiver.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(26, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "Receiver";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button1.Location = new System.Drawing.Point(200, 257);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 27);
            this.button1.TabIndex = 40;
            this.button1.Text = "Multiple";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Letter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(320, 305);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxReceiver);
            this.Controls.Add(this.textBoxno);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxDays);
            this.Controls.Add(this.labelPaidAmt);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxProvider);
            this.Name = "Letter";
            this.Text = "Letter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxProvider;
        private System.Windows.Forms.TextBox textBoxDays;
        private System.Windows.Forms.Label labelPaidAmt;
        private System.Windows.Forms.TextBox textBoxno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxReceiver;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}