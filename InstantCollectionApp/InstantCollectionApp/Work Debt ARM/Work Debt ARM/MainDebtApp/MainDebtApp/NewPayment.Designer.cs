namespace MainDebtApp
{
    partial class NewPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewPayment));
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.richTextBoxcoment = new System.Windows.Forms.RichTextBox();
            this.labelComments = new System.Windows.Forms.Label();
            this.labelPaidAmt = new System.Windows.Forms.Label();
            this.textBoxpaidAmt = new System.Windows.Forms.TextBox();
            this.labelPayDate = new System.Windows.Forms.Label();
            this.labelCurrency = new System.Windows.Forms.Label();
            this.comboBoxCurrency = new System.Windows.Forms.ComboBox();
            this.currencyBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.forAmazonDataSet = new MainDebtApp.ForAmazonDataSet();
            this.currencyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.debtTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.currencyTableAdapter1 = new MainDebtApp.ForAmazonDataSetTableAdapters.CurrencyTableAdapter();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxClient = new System.Windows.Forms.TextBox();
            this.textBoxSerialNr = new System.Windows.Forms.TextBox();
            this.textBoxfname = new System.Windows.Forms.TextBox();
            this.dateTimePickerPayDate = new System.Windows.Forms.DateTimePicker();
            this.comboBoxPayment = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.currencyBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.forAmazonDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currencyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.debtTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label3.Location = new System.Drawing.Point(23, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 22;
            this.label3.Text = "Client:\t";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(23, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 21;
            this.label2.Text = "Full Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(23, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "Serial Number:";
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonSubmit.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.buttonSubmit.FlatAppearance.BorderSize = 0;
            this.buttonSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSubmit.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.buttonSubmit.Location = new System.Drawing.Point(169, 461);
            this.buttonSubmit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(142, 23);
            this.buttonSubmit.TabIndex = 3;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = false;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // richTextBoxcoment
            // 
            this.richTextBoxcoment.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.richTextBoxcoment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxcoment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxcoment.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.richTextBoxcoment.Location = new System.Drawing.Point(26, 358);
            this.richTextBoxcoment.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.richTextBoxcoment.Name = "richTextBoxcoment";
            this.richTextBoxcoment.Size = new System.Drawing.Size(285, 93);
            this.richTextBoxcoment.TabIndex = 2;
            this.richTextBoxcoment.Text = "";
            this.richTextBoxcoment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textboxCommentKeyPress);
            // 
            // labelComments
            // 
            this.labelComments.AutoSize = true;
            this.labelComments.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelComments.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelComments.Location = new System.Drawing.Point(23, 336);
            this.labelComments.Name = "labelComments";
            this.labelComments.Size = new System.Drawing.Size(72, 15);
            this.labelComments.TabIndex = 26;
            this.labelComments.Text = "Comments:";
            // 
            // labelPaidAmt
            // 
            this.labelPaidAmt.AutoSize = true;
            this.labelPaidAmt.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPaidAmt.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelPaidAmt.Location = new System.Drawing.Point(23, 206);
            this.labelPaidAmt.Name = "labelPaidAmt";
            this.labelPaidAmt.Size = new System.Drawing.Size(79, 15);
            this.labelPaidAmt.TabIndex = 33;
            this.labelPaidAmt.Text = "Paid Amount:";
            // 
            // textBoxpaidAmt
            // 
            this.textBoxpaidAmt.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBoxpaidAmt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxpaidAmt.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBoxpaidAmt.Location = new System.Drawing.Point(137, 206);
            this.textBoxpaidAmt.Name = "textBoxpaidAmt";
            this.textBoxpaidAmt.Size = new System.Drawing.Size(174, 14);
            this.textBoxpaidAmt.TabIndex = 1;
            // 
            // labelPayDate
            // 
            this.labelPayDate.AutoSize = true;
            this.labelPayDate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPayDate.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelPayDate.Location = new System.Drawing.Point(23, 305);
            this.labelPayDate.Name = "labelPayDate";
            this.labelPayDate.Size = new System.Drawing.Size(85, 15);
            this.labelPayDate.TabIndex = 35;
            this.labelPayDate.Text = "Payment date:";
            // 
            // labelCurrency
            // 
            this.labelCurrency.AutoSize = true;
            this.labelCurrency.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrency.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelCurrency.Location = new System.Drawing.Point(23, 238);
            this.labelCurrency.Name = "labelCurrency";
            this.labelCurrency.Size = new System.Drawing.Size(59, 15);
            this.labelCurrency.TabIndex = 38;
            this.labelCurrency.Text = "Currency:";
            // 
            // comboBoxCurrency
            // 
            this.comboBoxCurrency.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.comboBoxCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCurrency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxCurrency.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.comboBoxCurrency.FormattingEnabled = true;
            this.comboBoxCurrency.Items.AddRange(new object[] {
            "ALL",
            "EUR",
            "USD"});
            this.comboBoxCurrency.Location = new System.Drawing.Point(137, 235);
            this.comboBoxCurrency.Name = "comboBoxCurrency";
            this.comboBoxCurrency.Size = new System.Drawing.Size(176, 23);
            this.comboBoxCurrency.TabIndex = 39;
            this.comboBoxCurrency.TabStop = false;
            this.comboBoxCurrency.SelectedIndexChanged += new System.EventHandler(this.comboBoxCurrency_SelectedIndexChanged);
            this.comboBoxCurrency.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.comboBoxDB_MouseWheel);
            // 
            // currencyBindingSource1
            // 
            this.currencyBindingSource1.DataMember = "Currency";
            this.currencyBindingSource1.DataSource = this.forAmazonDataSet;
            // 
            // forAmazonDataSet
            // 
            this.forAmazonDataSet.DataSetName = "ForAmazonDataSet";
            this.forAmazonDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // currencyBindingSource
            // 
            this.currencyBindingSource.DataMember = "Currency";
            // 
            // currencyTableAdapter1
            // 
            this.currencyTableAdapter1.ClearBeforeFill = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(77, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 28);
            this.label4.TabIndex = 49;
            this.label4.Text = "Add new payment";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(95, 12);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(149, 70);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 50;
            this.pictureBox4.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.OrangeRed;
            this.button1.Location = new System.Drawing.Point(26, 461);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 23);
            this.button1.TabIndex = 51;
            this.button1.TabStop = false;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxClient
            // 
            this.textBoxClient.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBoxClient.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxClient.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBoxClient.Location = new System.Drawing.Point(137, 180);
            this.textBoxClient.Name = "textBoxClient";
            this.textBoxClient.ReadOnly = true;
            this.textBoxClient.Size = new System.Drawing.Size(174, 14);
            this.textBoxClient.TabIndex = 52;
            this.textBoxClient.TabStop = false;
            // 
            // textBoxSerialNr
            // 
            this.textBoxSerialNr.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBoxSerialNr.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSerialNr.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBoxSerialNr.Location = new System.Drawing.Point(137, 128);
            this.textBoxSerialNr.Name = "textBoxSerialNr";
            this.textBoxSerialNr.ReadOnly = true;
            this.textBoxSerialNr.Size = new System.Drawing.Size(174, 14);
            this.textBoxSerialNr.TabIndex = 53;
            this.textBoxSerialNr.TabStop = false;
            // 
            // textBoxfname
            // 
            this.textBoxfname.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBoxfname.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxfname.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBoxfname.Location = new System.Drawing.Point(137, 154);
            this.textBoxfname.Name = "textBoxfname";
            this.textBoxfname.ReadOnly = true;
            this.textBoxfname.Size = new System.Drawing.Size(174, 14);
            this.textBoxfname.TabIndex = 54;
            this.textBoxfname.TabStop = false;
            // 
            // dateTimePickerPayDate
            // 
            this.dateTimePickerPayDate.CalendarForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dateTimePickerPayDate.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerPayDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerPayDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerPayDate.Location = new System.Drawing.Point(140, 298);
            this.dateTimePickerPayDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePickerPayDate.MaxDate = new System.DateTime(2026, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerPayDate.MinDate = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerPayDate.Name = "dateTimePickerPayDate";
            this.dateTimePickerPayDate.Size = new System.Drawing.Size(171, 22);
            this.dateTimePickerPayDate.TabIndex = 55;
            this.dateTimePickerPayDate.TabStop = false;
            this.dateTimePickerPayDate.Value = new System.DateTime(2016, 11, 30, 0, 0, 0, 0);
            // 
            // comboBoxPayment
            // 
            this.comboBoxPayment.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.comboBoxPayment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxPayment.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.comboBoxPayment.FormattingEnabled = true;
            this.comboBoxPayment.Items.AddRange(new object[] {
            "Full Payment",
            "Installment",
            "Closure by agreement",
            "Debt cancellation",
            "Paid in ALBTELECOM account"});
            this.comboBoxPayment.Location = new System.Drawing.Point(137, 266);
            this.comboBoxPayment.Name = "comboBoxPayment";
            this.comboBoxPayment.Size = new System.Drawing.Size(176, 23);
            this.comboBoxPayment.TabIndex = 57;
            this.comboBoxPayment.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label5.Location = new System.Drawing.Point(23, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 15);
            this.label5.TabIndex = 56;
            this.label5.Text = "Payment Type:";
            // 
            // NewPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(343, 491);
            this.Controls.Add(this.comboBoxPayment);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePickerPayDate);
            this.Controls.Add(this.textBoxfname);
            this.Controls.Add(this.textBoxSerialNr);
            this.Controls.Add(this.textBoxClient);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxCurrency);
            this.Controls.Add(this.labelCurrency);
            this.Controls.Add(this.labelPayDate);
            this.Controls.Add(this.textBoxpaidAmt);
            this.Controls.Add(this.labelPaidAmt);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.richTextBoxcoment);
            this.Controls.Add(this.labelComments);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(450, 530);
            this.MinimumSize = new System.Drawing.Size(350, 450);
            this.Name = "NewPayment";
            this.Text = "Add Payment";
            this.Load += new System.EventHandler(this.NewPayment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.currencyBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.forAmazonDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currencyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.debtTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.RichTextBox richTextBoxcoment;
        private System.Windows.Forms.Label labelComments;
        private System.Windows.Forms.Label labelPaidAmt;
        private System.Windows.Forms.TextBox textBoxpaidAmt;
        private System.Windows.Forms.Label labelPayDate;
        private System.Windows.Forms.Label labelCurrency;
        private System.Windows.Forms.ComboBox comboBoxCurrency;
        private System.Windows.Forms.BindingSource currencyBindingSource;
        private System.Windows.Forms.BindingSource debtTypeBindingSource;
    //    private SystemDebtorsDataSetTableAdapters.DebtTypeTableAdapter debtTypeTableAdapter;
        private ForAmazonDataSet forAmazonDataSet;
        private System.Windows.Forms.BindingSource currencyBindingSource1;
        private ForAmazonDataSetTableAdapters.CurrencyTableAdapter currencyTableAdapter1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxClient;
        private System.Windows.Forms.TextBox textBoxSerialNr;
        private System.Windows.Forms.TextBox textBoxfname;
        private System.Windows.Forms.DateTimePicker dateTimePickerPayDate;
        private System.Windows.Forms.ComboBox comboBoxPayment;
        private System.Windows.Forms.Label label5;
    }
}