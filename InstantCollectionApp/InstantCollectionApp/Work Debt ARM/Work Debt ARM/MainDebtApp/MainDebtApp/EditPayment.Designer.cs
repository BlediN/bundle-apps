namespace MainDebtApp
{
    partial class EditPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditPayment));
            this.comboBoxCurrency = new System.Windows.Forms.ComboBox();
            this.labelCurrency = new System.Windows.Forms.Label();
            this.labelPayDate = new System.Windows.Forms.Label();
            this.textBoxpaidAmt = new System.Windows.Forms.TextBox();
            this.labelPaidAmt = new System.Windows.Forms.Label();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.richTextBoxcoment = new System.Windows.Forms.RichTextBox();
            this.labelComments = new System.Windows.Forms.Label();
            this.labelPayID = new System.Windows.Forms.Label();
            this.labelPayIDNr = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelPname = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerPayDate = new System.Windows.Forms.DateTimePicker();
            this.comboBoxCollectors = new System.Windows.Forms.ComboBox();
            this.usernamesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.forAmazonDataSet = new MainDebtApp.ForAmazonDataSet();
            this.usernamesTableAdapter = new MainDebtApp.ForAmazonDataSetTableAdapters.UsernamesTableAdapter();
            this.textBoxCollector = new System.Windows.Forms.TextBox();
            this.comboBoxPaymentStatus = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDiff = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.currencyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.currencyTableAdapter = new MainDebtApp.ForAmazonDataSetTableAdapters.CurrencyTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usernamesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.forAmazonDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currencyBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxCurrency
            // 
            this.comboBoxCurrency.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.comboBoxCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCurrency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxCurrency.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.comboBoxCurrency.FormattingEnabled = true;
            this.comboBoxCurrency.Items.AddRange(new object[] {
            "ALL",
            "EUR",
            "USD",
            "GBP",
            "CHF"});
            this.comboBoxCurrency.Location = new System.Drawing.Point(124, 175);
            this.comboBoxCurrency.Name = "comboBoxCurrency";
            this.comboBoxCurrency.Size = new System.Drawing.Size(171, 21);
            this.comboBoxCurrency.TabIndex = 56;
            // 
            // labelCurrency
            // 
            this.labelCurrency.AutoSize = true;
            this.labelCurrency.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrency.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelCurrency.Location = new System.Drawing.Point(23, 179);
            this.labelCurrency.Name = "labelCurrency";
            this.labelCurrency.Size = new System.Drawing.Size(58, 15);
            this.labelCurrency.TabIndex = 55;
            this.labelCurrency.Text = "Currency:";
            // 
            // labelPayDate
            // 
            this.labelPayDate.AutoSize = true;
            this.labelPayDate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPayDate.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelPayDate.Location = new System.Drawing.Point(23, 204);
            this.labelPayDate.Name = "labelPayDate";
            this.labelPayDate.Size = new System.Drawing.Size(85, 15);
            this.labelPayDate.TabIndex = 54;
            this.labelPayDate.Text = "Payment date:";
            // 
            // textBoxpaidAmt
            // 
            this.textBoxpaidAmt.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBoxpaidAmt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxpaidAmt.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.textBoxpaidAmt.Location = new System.Drawing.Point(125, 153);
            this.textBoxpaidAmt.Name = "textBoxpaidAmt";
            this.textBoxpaidAmt.Size = new System.Drawing.Size(170, 13);
            this.textBoxpaidAmt.TabIndex = 53;
            // 
            // labelPaidAmt
            // 
            this.labelPaidAmt.AutoSize = true;
            this.labelPaidAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPaidAmt.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelPaidAmt.Location = new System.Drawing.Point(23, 149);
            this.labelPaidAmt.Name = "labelPaidAmt";
            this.labelPaidAmt.Size = new System.Drawing.Size(80, 15);
            this.labelPaidAmt.TabIndex = 52;
            this.labelPaidAmt.Text = "Paid Amount:";
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonSubmit.FlatAppearance.BorderSize = 0;
            this.buttonSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSubmit.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSubmit.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.buttonSubmit.Location = new System.Drawing.Point(167, 421);
            this.buttonSubmit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(128, 26);
            this.buttonSubmit.TabIndex = 51;
            this.buttonSubmit.Text = "Save changes";
            this.buttonSubmit.UseVisualStyleBackColor = false;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // richTextBoxcoment
            // 
            this.richTextBoxcoment.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.richTextBoxcoment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxcoment.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxcoment.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.richTextBoxcoment.Location = new System.Drawing.Point(126, 236);
            this.richTextBoxcoment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.richTextBoxcoment.Name = "richTextBoxcoment";
            this.richTextBoxcoment.Size = new System.Drawing.Size(169, 88);
            this.richTextBoxcoment.TabIndex = 48;
            this.richTextBoxcoment.Text = "";
            // 
            // labelComments
            // 
            this.labelComments.AutoSize = true;
            this.labelComments.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelComments.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelComments.Location = new System.Drawing.Point(23, 236);
            this.labelComments.Name = "labelComments";
            this.labelComments.Size = new System.Drawing.Size(72, 15);
            this.labelComments.TabIndex = 45;
            this.labelComments.Text = "Comments:";
            // 
            // labelPayID
            // 
            this.labelPayID.AutoSize = true;
            this.labelPayID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPayID.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelPayID.Location = new System.Drawing.Point(23, 105);
            this.labelPayID.Name = "labelPayID";
            this.labelPayID.Size = new System.Drawing.Size(70, 15);
            this.labelPayID.TabIndex = 61;
            this.labelPayID.Text = "Payment ID";
            // 
            // labelPayIDNr
            // 
            this.labelPayIDNr.AutoSize = true;
            this.labelPayIDNr.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.labelPayIDNr.Location = new System.Drawing.Point(122, 109);
            this.labelPayIDNr.Name = "labelPayIDNr";
            this.labelPayIDNr.Size = new System.Drawing.Size(18, 13);
            this.labelPayIDNr.TabIndex = 62;
            this.labelPayIDNr.Text = "ID";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelName.Location = new System.Drawing.Point(23, 128);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(41, 15);
            this.labelName.TabIndex = 63;
            this.labelName.Text = "Name";
            // 
            // labelPname
            // 
            this.labelPname.AutoSize = true;
            this.labelPname.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.labelPname.Location = new System.Drawing.Point(122, 131);
            this.labelPname.Name = "labelPname";
            this.labelPname.Size = new System.Drawing.Size(35, 13);
            this.labelPname.TabIndex = 64;
            this.labelPname.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(23, 330);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 65;
            this.label1.Text = "Collector:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(29, 421);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 26);
            this.button1.TabIndex = 67;
            this.button1.Text = "Delete ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(90, 12);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(133, 62);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 69;
            this.pictureBox4.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(69, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 26);
            this.label4.TabIndex = 68;
            this.label4.Text = "Edit/Delete Payment";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dateTimePickerPayDate
            // 
            this.dateTimePickerPayDate.CalendarForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dateTimePickerPayDate.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerPayDate.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerPayDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerPayDate.Location = new System.Drawing.Point(126, 205);
            this.dateTimePickerPayDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePickerPayDate.MaxDate = new System.DateTime(2026, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerPayDate.MinDate = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerPayDate.Name = "dateTimePickerPayDate";
            this.dateTimePickerPayDate.Size = new System.Drawing.Size(171, 22);
            this.dateTimePickerPayDate.TabIndex = 70;
            this.dateTimePickerPayDate.Value = new System.DateTime(2016, 11, 10, 0, 0, 0, 0);
            // 
            // comboBoxCollectors
            // 
            this.comboBoxCollectors.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.comboBoxCollectors.DataSource = this.usernamesBindingSource;
            this.comboBoxCollectors.DisplayMember = "Collector";
            this.comboBoxCollectors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCollectors.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxCollectors.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCollectors.FormattingEnabled = true;
            this.comboBoxCollectors.Location = new System.Drawing.Point(227, 330);
            this.comboBoxCollectors.Name = "comboBoxCollectors";
            this.comboBoxCollectors.Size = new System.Drawing.Size(68, 23);
            this.comboBoxCollectors.TabIndex = 71;
            this.comboBoxCollectors.ValueMember = "Collector";
            this.comboBoxCollectors.SelectedIndexChanged += new System.EventHandler(this.comboBoxCollectors_SelectedIndexChanged);
            // 
            // usernamesBindingSource
            // 
            this.usernamesBindingSource.DataMember = "Usernames";
            this.usernamesBindingSource.DataSource = this.forAmazonDataSet;
            // 
            // forAmazonDataSet
            // 
            this.forAmazonDataSet.DataSetName = "ForAmazonDataSet";
            this.forAmazonDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // usernamesTableAdapter
            // 
            this.usernamesTableAdapter.ClearBeforeFill = true;
            // 
            // textBoxCollector
            // 
            this.textBoxCollector.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBoxCollector.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCollector.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.textBoxCollector.Location = new System.Drawing.Point(128, 333);
            this.textBoxCollector.Name = "textBoxCollector";
            this.textBoxCollector.ReadOnly = true;
            this.textBoxCollector.Size = new System.Drawing.Size(95, 13);
            this.textBoxCollector.TabIndex = 72;
            // 
            // comboBoxPaymentStatus
            // 
            this.comboBoxPaymentStatus.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.comboBoxPaymentStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPaymentStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxPaymentStatus.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.comboBoxPaymentStatus.FormattingEnabled = true;
            this.comboBoxPaymentStatus.Items.AddRange(new object[] {
            "",
            "Verified"});
            this.comboBoxPaymentStatus.Location = new System.Drawing.Point(127, 365);
            this.comboBoxPaymentStatus.Name = "comboBoxPaymentStatus";
            this.comboBoxPaymentStatus.Size = new System.Drawing.Size(171, 21);
            this.comboBoxPaymentStatus.TabIndex = 74;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(26, 369);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 15);
            this.label2.TabIndex = 73;
            this.label2.Text = "Status:";
            // 
            // textBoxDiff
            // 
            this.textBoxDiff.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBoxDiff.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDiff.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.textBoxDiff.Location = new System.Drawing.Point(128, 395);
            this.textBoxDiff.Name = "textBoxDiff";
            this.textBoxDiff.Size = new System.Drawing.Size(170, 13);
            this.textBoxDiff.TabIndex = 76;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label3.Location = new System.Drawing.Point(26, 392);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 15);
            this.label3.TabIndex = 75;
            this.label3.Text = "Difference:";
            // 
            // currencyBindingSource
            // 
            this.currencyBindingSource.DataMember = "Currency";
            this.currencyBindingSource.DataSource = this.forAmazonDataSet;
            // 
            // currencyTableAdapter
            // 
            this.currencyTableAdapter.ClearBeforeFill = true;
            // 
            // EditPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(323, 460);
            this.Controls.Add(this.textBoxDiff);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxPaymentStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxCollector);
            this.Controls.Add(this.comboBoxCollectors);
            this.Controls.Add(this.dateTimePickerPayDate);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelPname);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelPayIDNr);
            this.Controls.Add(this.labelPayID);
            this.Controls.Add(this.comboBoxCurrency);
            this.Controls.Add(this.labelCurrency);
            this.Controls.Add(this.labelPayDate);
            this.Controls.Add(this.textBoxpaidAmt);
            this.Controls.Add(this.labelPaidAmt);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.richTextBoxcoment);
            this.Controls.Add(this.labelComments);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(380, 520);
            this.MinimumSize = new System.Drawing.Size(300, 400);
            this.Name = "EditPayment";
            this.Text = "Edit a Payment";
            this.Load += new System.EventHandler(this.EditPayment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usernamesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.forAmazonDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currencyBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxCurrency;
        private System.Windows.Forms.Label labelCurrency;
        private System.Windows.Forms.Label labelPayDate;
        private System.Windows.Forms.TextBox textBoxpaidAmt;
        private System.Windows.Forms.Label labelPaidAmt;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.RichTextBox richTextBoxcoment;
        private System.Windows.Forms.Label labelComments;
        private System.Windows.Forms.Label labelPayID;
        private System.Windows.Forms.Label labelPayIDNr;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelPname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerPayDate;
        private System.Windows.Forms.ComboBox comboBoxCollectors;
        private ForAmazonDataSet forAmazonDataSet;
        private System.Windows.Forms.BindingSource usernamesBindingSource;
        private ForAmazonDataSetTableAdapters.UsernamesTableAdapter usernamesTableAdapter;
        private System.Windows.Forms.TextBox textBoxCollector;
        private System.Windows.Forms.ComboBox comboBoxPaymentStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDiff;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource currencyBindingSource;
        private ForAmazonDataSetTableAdapters.CurrencyTableAdapter currencyTableAdapter;
    }
}