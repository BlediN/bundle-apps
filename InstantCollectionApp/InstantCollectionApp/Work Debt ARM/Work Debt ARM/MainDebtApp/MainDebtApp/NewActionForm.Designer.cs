namespace MainDebtApp
{
    partial class NewActionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewActionForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxaction = new System.Windows.Forms.ComboBox();
            this.actionTypeBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.forAmazonDataSet = new MainDebtApp.ForAmazonDataSet();
            this.actionTypeBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.actionTypeBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.actionTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBoxcontacted = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.actionTypeTableAdapter = new MainDebtApp.ForAmazonDataSetTableAdapters.ActionTypeTableAdapter();
            this.comboBoxContactOpt = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxReaction = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxPTPamt = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxDbSerial = new System.Windows.Forms.TextBox();
            this.textBoxFname = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxComment = new System.Windows.Forms.TextBox();
            this.actionTypeBindingSource4 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.actionTypeBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.forAmazonDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.actionTypeBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.actionTypeBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.actionTypeBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.actionTypeBindingSource4)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(24, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Serial Number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(24, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Full Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label4.Location = new System.Drawing.Point(26, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Action Type:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label5.Location = new System.Drawing.Point(24, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Contacted Person:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label6.Location = new System.Drawing.Point(24, 292);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Next Date:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label7.Location = new System.Drawing.Point(24, 315);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Comments:";
            // 
            // comboBoxaction
            // 
            this.comboBoxaction.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.comboBoxaction.DataSource = this.actionTypeBindingSource4;
            this.comboBoxaction.DisplayMember = "Action_type";
            this.comboBoxaction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxaction.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxaction.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.comboBoxaction.FormattingEnabled = true;
            this.comboBoxaction.ImeMode = System.Windows.Forms.ImeMode.On;
            this.comboBoxaction.Location = new System.Drawing.Point(137, 169);
            this.comboBoxaction.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxaction.Name = "comboBoxaction";
            this.comboBoxaction.Size = new System.Drawing.Size(181, 23);
            this.comboBoxaction.TabIndex = 4;
            this.comboBoxaction.ValueMember = "Action_type";
            this.comboBoxaction.SelectedIndexChanged += new System.EventHandler(this.ComboBoxaction_SelectedIndexChanged);
            this.comboBoxaction.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.comboBoxDB_MouseWheel);
            // 
            // actionTypeBindingSource3
            // 
            this.actionTypeBindingSource3.DataMember = "ActionType";
            this.actionTypeBindingSource3.DataSource = this.forAmazonDataSet;
            // 
            // forAmazonDataSet
            // 
            this.forAmazonDataSet.DataSetName = "ForAmazonDataSet";
            this.forAmazonDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // actionTypeBindingSource2
            // 
            this.actionTypeBindingSource2.DataMember = "ActionType";
            // 
            // actionTypeBindingSource1
            // 
            this.actionTypeBindingSource1.DataMember = "ActionType";
            // 
            // comboBoxcontacted
            // 
            this.comboBoxcontacted.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.comboBoxcontacted.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxcontacted.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxcontacted.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxcontacted.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.comboBoxcontacted.FormattingEnabled = true;
            this.comboBoxcontacted.Items.AddRange(new object[] {
            "Debtor",
            "Creditor",
            "Guarantor",
            "No Contact",
            "Relative",
            "No Answer",
            "Other"});
            this.comboBoxcontacted.Location = new System.Drawing.Point(137, 139);
            this.comboBoxcontacted.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxcontacted.Name = "comboBoxcontacted";
            this.comboBoxcontacted.Size = new System.Drawing.Size(181, 23);
            this.comboBoxcontacted.TabIndex = 3;
            this.comboBoxcontacted.SelectedIndexChanged += new System.EventHandler(this.comboBoxcontacted_SelectedIndexChanged);
            this.comboBoxcontacted.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.comboBoxDB_MouseWheel);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(216, 285);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePicker1.MaxDate = new System.DateTime(2026, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(104, 22);
            this.dateTimePicker1.TabIndex = 22;
            this.dateTimePicker1.TabStop = false;
            this.dateTimePicker1.Value = new System.DateTime(2016, 12, 7, 0, 0, 0, 0);
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonSubmit.FlatAppearance.BorderSize = 0;
            this.buttonSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSubmit.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSubmit.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.buttonSubmit.Location = new System.Drawing.Point(229, 3);
            this.buttonSubmit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(86, 28);
            this.buttonSubmit.TabIndex = 25;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = false;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // actionTypeTableAdapter
            // 
            this.actionTypeTableAdapter.ClearBeforeFill = true;
            // 
            // comboBoxContactOpt
            // 
            this.comboBoxContactOpt.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.comboBoxContactOpt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxContactOpt.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxContactOpt.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.comboBoxContactOpt.FormattingEnabled = true;
            this.comboBoxContactOpt.Location = new System.Drawing.Point(137, 197);
            this.comboBoxContactOpt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxContactOpt.Name = "comboBoxContactOpt";
            this.comboBoxContactOpt.Size = new System.Drawing.Size(181, 23);
            this.comboBoxContactOpt.TabIndex = 5;
            this.comboBoxContactOpt.SelectedIndexChanged += new System.EventHandler(this.comboBoxContactOpt_SelectedIndexChanged);
            this.comboBoxContactOpt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboboxTextPress);
            this.comboBoxContactOpt.MouseHover += new System.EventHandler(this.TextBoxToolTip);
            this.comboBoxContactOpt.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.comboBoxDB_MouseWheel);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label10.Location = new System.Drawing.Point(24, 197);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 15);
            this.label10.TabIndex = 23;
            this.label10.Text = "Contacted via:";
            // 
            // comboBoxReaction
            // 
            this.comboBoxReaction.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.comboBoxReaction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxReaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxReaction.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxReaction.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.comboBoxReaction.FormattingEnabled = true;
            this.comboBoxReaction.Items.AddRange(new object[] {
            "Accepts Debt",
            "Promises to Pay",
            "Refuses Debt",
            "Refuses to Pay"});
            this.comboBoxReaction.Location = new System.Drawing.Point(137, 227);
            this.comboBoxReaction.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxReaction.Name = "comboBoxReaction";
            this.comboBoxReaction.Size = new System.Drawing.Size(181, 23);
            this.comboBoxReaction.TabIndex = 6;
            this.comboBoxReaction.TabStop = false;
            this.comboBoxReaction.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.comboBoxDB_MouseWheel);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label12.Location = new System.Drawing.Point(24, 230);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 15);
            this.label12.TabIndex = 29;
            this.label12.Text = "Reaction:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label14.Location = new System.Drawing.Point(24, 258);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(109, 15);
            this.label14.TabIndex = 33;
            this.label14.Text = "Promised amount:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button1.Location = new System.Drawing.Point(7, 3);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 28);
            this.button1.TabIndex = 36;
            this.button1.TabStop = false;
            this.button1.Text = "Send SMS";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button2.Location = new System.Drawing.Point(119, 3);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 28);
            this.button2.TabIndex = 37;
            this.button2.TabStop = false;
            this.button2.Text = "Send email";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // textBoxPTPamt
            // 
            this.textBoxPTPamt.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBoxPTPamt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPTPamt.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPTPamt.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.textBoxPTPamt.Location = new System.Drawing.Point(137, 258);
            this.textBoxPTPamt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxPTPamt.Multiline = true;
            this.textBoxPTPamt.Name = "textBoxPTPamt";
            this.textBoxPTPamt.Size = new System.Drawing.Size(181, 20);
            this.textBoxPTPamt.TabIndex = 7;
            this.textBoxPTPamt.TabStop = false;
            this.textBoxPTPamt.Text = "0";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.buttonSubmit);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 419);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(339, 35);
            this.panel1.TabIndex = 40;
            // 
            // textBoxDbSerial
            // 
            this.textBoxDbSerial.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBoxDbSerial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDbSerial.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDbSerial.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.textBoxDbSerial.Location = new System.Drawing.Point(137, 95);
            this.textBoxDbSerial.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxDbSerial.Name = "textBoxDbSerial";
            this.textBoxDbSerial.ReadOnly = true;
            this.textBoxDbSerial.Size = new System.Drawing.Size(181, 14);
            this.textBoxDbSerial.TabIndex = 1;
            this.textBoxDbSerial.TabStop = false;
            // 
            // textBoxFname
            // 
            this.textBoxFname.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBoxFname.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxFname.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFname.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.textBoxFname.Location = new System.Drawing.Point(137, 117);
            this.textBoxFname.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxFname.Name = "textBoxFname";
            this.textBoxFname.ReadOnly = true;
            this.textBoxFname.Size = new System.Drawing.Size(181, 14);
            this.textBoxFname.TabIndex = 2;
            this.textBoxFname.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(100, 12);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(133, 48);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 71;
            this.pictureBox4.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(115, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 23);
            this.label3.TabIndex = 72;
            this.label3.Text = "New Action";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBoxComment
            // 
            this.textBoxComment.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBoxComment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxComment.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxComment.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.textBoxComment.Location = new System.Drawing.Point(134, 315);
            this.textBoxComment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxComment.Multiline = true;
            this.textBoxComment.Name = "textBoxComment";
            this.textBoxComment.Size = new System.Drawing.Size(181, 83);
            this.textBoxComment.TabIndex = 23;
            this.textBoxComment.TextChanged += new System.EventHandler(this.textBoxComment_TextChanged);
            this.textBoxComment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textboxCommentKeyPress);
            // 
            // actionTypeBindingSource4
            // 
            this.actionTypeBindingSource4.DataMember = "ActionType";
            this.actionTypeBindingSource4.DataSource = this.forAmazonDataSet;
            // 
            // NewActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(339, 454);
            this.Controls.Add(this.textBoxComment);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.textBoxFname);
            this.Controls.Add(this.textBoxDbSerial);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBoxPTPamt);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.comboBoxReaction);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.comboBoxContactOpt);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.comboBoxcontacted);
            this.Controls.Add(this.comboBoxaction);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "NewActionForm";
            this.Text = "Register New Action";
            this.Load += new System.EventHandler(this.NewActionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.actionTypeBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.forAmazonDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.actionTypeBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.actionTypeBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.actionTypeBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.actionTypeBindingSource4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxaction;
        private System.Windows.Forms.ComboBox comboBoxcontacted;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button buttonSubmit;
     //   private SystemDefaultsDataSet systemDefaultsDataSet;
      //  private System.Windows.Forms.BindingSource systemDefaultsDataSetBindingSource;
        private System.Windows.Forms.BindingSource actionTypeBindingSource;
     //   private fromExcelDataSet fromExcelDataSet;
        private System.Windows.Forms.BindingSource actionTypeBindingSource1;
      //  private fromExcelDataSetTableAdapters.ActionTypeTableAdapter actionTypeTableAdapter;
     //   private SystemDebtorsDataSet systemDebtorsDataSet;
        private System.Windows.Forms.BindingSource actionTypeBindingSource2;
     //   private SystemDebtorsDataSetTableAdapters.ActionTypeTableAdapter actionTypeTableAdapter1;
        private ForAmazonDataSet forAmazonDataSet;
        private System.Windows.Forms.BindingSource actionTypeBindingSource3;
        private ForAmazonDataSetTableAdapters.ActionTypeTableAdapter actionTypeTableAdapter;
        private System.Windows.Forms.ComboBox comboBoxContactOpt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxReaction;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxPTPamt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxDbSerial;
        private System.Windows.Forms.TextBox textBoxFname;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxComment;
        private System.Windows.Forms.BindingSource actionTypeBindingSource4;
        //   private SystemDefaultsDataSetTableAdapters.ActionTypeTableAdapter actionTypeTableAdapter;

    }
}