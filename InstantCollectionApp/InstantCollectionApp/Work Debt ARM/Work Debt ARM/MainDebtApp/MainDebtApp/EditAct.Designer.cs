namespace MainDebtApp
{
    partial class EditAct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditAct));
            this.actionTypeTableAdapter = new MainDebtApp.ForAmazonDataSetTableAdapters.ActionTypeTableAdapter();
            this.forAmazonDataSet = new MainDebtApp.ForAmazonDataSet();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.linkLabelfname = new System.Windows.Forms.LinkLabel();
            this.richTextBoxcoment = new System.Windows.Forms.RichTextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboBoxcontacted = new System.Windows.Forms.ComboBox();
            this.contactedPersonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.actionTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.actionTypeBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.actionTypeBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.comboBoxaction = new System.Windows.Forms.ComboBox();
            this.actionTypeBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.labelActID = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPTPamt = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBoxReaction = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBoxContactOpt = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.contactedPersonTableAdapter = new MainDebtApp.ForAmazonDataSetTableAdapters.ContactedPersonTableAdapter();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.forAmazonDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactedPersonBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.actionTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.actionTypeBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.actionTypeBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.actionTypeBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // actionTypeTableAdapter
            // 
            this.actionTypeTableAdapter.ClearBeforeFill = true;
            // 
            // forAmazonDataSet
            // 
            this.forAmazonDataSet.DataSetName = "ForAmazonDataSet";
            this.forAmazonDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonSubmit.FlatAppearance.BorderSize = 0;
            this.buttonSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSubmit.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSubmit.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.buttonSubmit.Location = new System.Drawing.Point(175, 435);
            this.buttonSubmit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(164, 26);
            this.buttonSubmit.TabIndex = 42;
            this.buttonSubmit.Text = "Save changes";
            this.buttonSubmit.UseVisualStyleBackColor = false;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // linkLabelfname
            // 
            this.linkLabelfname.AutoSize = true;
            this.linkLabelfname.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelfname.LinkColor = System.Drawing.Color.RoyalBlue;
            this.linkLabelfname.Location = new System.Drawing.Point(123, 84);
            this.linkLabelfname.Name = "linkLabelfname";
            this.linkLabelfname.Size = new System.Drawing.Size(54, 20);
            this.linkLabelfname.TabIndex = 39;
            this.linkLabelfname.TabStop = true;
            this.linkLabelfname.Text = "linkLabel1";
            this.linkLabelfname.UseCompatibleTextRendering = true;
            // 
            // richTextBoxcoment
            // 
            this.richTextBoxcoment.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.richTextBoxcoment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxcoment.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxcoment.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.richTextBoxcoment.Location = new System.Drawing.Point(118, 326);
            this.richTextBoxcoment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.richTextBoxcoment.Name = "richTextBoxcoment";
            this.richTextBoxcoment.Size = new System.Drawing.Size(221, 101);
            this.richTextBoxcoment.TabIndex = 36;
            this.richTextBoxcoment.Text = "";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dateTimePicker1.CalendarMonthBackground = System.Drawing.SystemColors.ButtonFace;
            this.dateTimePicker1.CalendarTitleForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(231, 301);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePicker1.MaxDate = new System.DateTime(2026, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(108, 22);
            this.dateTimePicker1.TabIndex = 35;
            this.dateTimePicker1.Value = new System.DateTime(2017, 2, 1, 0, 0, 0, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // comboBoxcontacted
            // 
            this.comboBoxcontacted.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.comboBoxcontacted.DataSource = this.contactedPersonBindingSource;
            this.comboBoxcontacted.DisplayMember = "Contacted_person";
            this.comboBoxcontacted.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxcontacted.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxcontacted.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxcontacted.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.comboBoxcontacted.FormattingEnabled = true;
            this.comboBoxcontacted.Location = new System.Drawing.Point(119, 140);
            this.comboBoxcontacted.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxcontacted.Name = "comboBoxcontacted";
            this.comboBoxcontacted.Size = new System.Drawing.Size(220, 24);
            this.comboBoxcontacted.TabIndex = 33;
            this.comboBoxcontacted.ValueMember = "Contacted_person";
            this.comboBoxcontacted.SelectedIndexChanged += new System.EventHandler(this.comboBoxcontacted_SelectedIndexChanged);
            // 
            // contactedPersonBindingSource
            // 
            this.contactedPersonBindingSource.DataMember = "ContactedPerson";
            this.contactedPersonBindingSource.DataSource = this.forAmazonDataSet;
            // 
            // actionTypeBindingSource1
            // 
            this.actionTypeBindingSource1.DataMember = "ActionType";
            // 
            // actionTypeBindingSource2
            // 
            this.actionTypeBindingSource2.DataMember = "ActionType";
            // 
            // comboBoxaction
            // 
            this.comboBoxaction.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.comboBoxaction.DataSource = this.actionTypeBindingSource3;
            this.comboBoxaction.DisplayMember = "Action_type";
            this.comboBoxaction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxaction.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxaction.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.comboBoxaction.FormattingEnabled = true;
            this.comboBoxaction.Location = new System.Drawing.Point(119, 174);
            this.comboBoxaction.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxaction.Name = "comboBoxaction";
            this.comboBoxaction.Size = new System.Drawing.Size(220, 24);
            this.comboBoxaction.TabIndex = 32;
            this.comboBoxaction.ValueMember = "Action_type";
            this.comboBoxaction.SelectedIndexChanged += new System.EventHandler(this.comboBoxaction_SelectedIndexChanged);
            // 
            // actionTypeBindingSource3
            // 
            this.actionTypeBindingSource3.DataMember = "ActionType";
            this.actionTypeBindingSource3.DataSource = this.forAmazonDataSet;
            // 
            // labelActID
            // 
            this.labelActID.AutoSize = true;
            this.labelActID.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelActID.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelActID.Location = new System.Drawing.Point(126, 114);
            this.labelActID.Name = "labelActID";
            this.labelActID.Size = new System.Drawing.Size(19, 16);
            this.labelActID.TabIndex = 31;
            this.labelActID.Text = "ID";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label7.Location = new System.Drawing.Point(12, 328);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 16);
            this.label7.TabIndex = 28;
            this.label7.Text = "Comments:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label6.Location = new System.Drawing.Point(12, 298);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 16);
            this.label6.TabIndex = 27;
            this.label6.Text = "Next Date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label5.Location = new System.Drawing.Point(12, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 16);
            this.label5.TabIndex = 26;
            this.label5.Text = "Contacted Person:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label4.Location = new System.Drawing.Point(12, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 25;
            this.label4.Text = "Action Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label3.Location = new System.Drawing.Point(15, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 24;
            this.label3.Text = "Action ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(13, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "Full Name:";
            // 
            // textBoxPTPamt
            // 
            this.textBoxPTPamt.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBoxPTPamt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPTPamt.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPTPamt.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.textBoxPTPamt.Location = new System.Drawing.Point(119, 276);
            this.textBoxPTPamt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxPTPamt.Name = "textBoxPTPamt";
            this.textBoxPTPamt.Size = new System.Drawing.Size(220, 15);
            this.textBoxPTPamt.TabIndex = 51;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label14.Location = new System.Drawing.Point(12, 271);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 16);
            this.label14.TabIndex = 49;
            this.label14.Text = "Promised amount:";
            // 
            // comboBoxReaction
            // 
            this.comboBoxReaction.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.comboBoxReaction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxReaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxReaction.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxReaction.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.comboBoxReaction.FormattingEnabled = true;
            this.comboBoxReaction.Items.AddRange(new object[] {
            "NA",
            "Accepts Debt",
            "Promises to Pay",
            "Refuses Debt",
            "Refuses to Pay"});
            this.comboBoxReaction.Location = new System.Drawing.Point(119, 242);
            this.comboBoxReaction.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxReaction.Name = "comboBoxReaction";
            this.comboBoxReaction.Size = new System.Drawing.Size(220, 24);
            this.comboBoxReaction.TabIndex = 46;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label12.Location = new System.Drawing.Point(12, 238);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 16);
            this.label12.TabIndex = 45;
            this.label12.Text = "Reaction:";
            // 
            // comboBoxContactOpt
            // 
            this.comboBoxContactOpt.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.comboBoxContactOpt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxContactOpt.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxContactOpt.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.comboBoxContactOpt.FormattingEnabled = true;
            this.comboBoxContactOpt.Location = new System.Drawing.Point(119, 208);
            this.comboBoxContactOpt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxContactOpt.Name = "comboBoxContactOpt";
            this.comboBoxContactOpt.Size = new System.Drawing.Size(220, 24);
            this.comboBoxContactOpt.TabIndex = 44;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label10.Location = new System.Drawing.Point(12, 208);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 16);
            this.label10.TabIndex = 43;
            this.label10.Text = "Contacted via:";
            // 
            // contactedPersonTableAdapter
            // 
            this.contactedPersonTableAdapter.ClearBeforeFill = true;
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonDelete.FlatAppearance.BorderSize = 0;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.ForeColor = System.Drawing.Color.Red;
            this.buttonDelete.Location = new System.Drawing.Point(18, 435);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(151, 26);
            this.buttonDelete.TabIndex = 68;
            this.buttonDelete.Text = "Delete ";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(114, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 23);
            this.label1.TabIndex = 69;
            this.label1.Text = "Edit/Delete Action";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(118, 5);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(133, 48);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 70;
            this.pictureBox4.TabStop = false;
            // 
            // EditAct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(362, 471);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.textBoxPTPamt);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.comboBoxReaction);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.comboBoxContactOpt);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.linkLabelfname);
            this.Controls.Add(this.richTextBoxcoment);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.comboBoxcontacted);
            this.Controls.Add(this.comboBoxaction);
            this.Controls.Add(this.labelActID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(478, 700);
            this.MinimumSize = new System.Drawing.Size(280, 450);
            this.Name = "EditAct";
            this.Text = "Edit Action";
            this.Load += new System.EventHandler(this.EditAct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.forAmazonDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactedPersonBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.actionTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.actionTypeBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.actionTypeBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.actionTypeBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ForAmazonDataSetTableAdapters.ActionTypeTableAdapter actionTypeTableAdapter;
        private ForAmazonDataSet forAmazonDataSet;
      //  private SystemDebtorsDataSetTableAdapters.ActionTypeTableAdapter actionTypeTableAdapter1;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.LinkLabel linkLabelfname;
        private System.Windows.Forms.RichTextBox richTextBoxcoment;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboBoxcontacted;
        private System.Windows.Forms.BindingSource actionTypeBindingSource;
        private System.Windows.Forms.BindingSource actionTypeBindingSource1;
    //    private SystemDebtorsDataSet systemDebtorsDataSet;
        private System.Windows.Forms.BindingSource actionTypeBindingSource2;
        private System.Windows.Forms.ComboBox comboBoxaction;
        private System.Windows.Forms.BindingSource actionTypeBindingSource3;
        private System.Windows.Forms.Label labelActID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPTPamt;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboBoxReaction;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBoxContactOpt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.BindingSource contactedPersonBindingSource;
        private ForAmazonDataSetTableAdapters.ContactedPersonTableAdapter contactedPersonTableAdapter;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}