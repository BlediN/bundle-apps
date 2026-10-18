namespace MainDebtApp
{
    partial class Notifications
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
            this.textBoxSerialNr = new System.Windows.Forms.TextBox();
            this.buttonFill = new System.Windows.Forms.Button();
            this.buttonDelAll = new System.Windows.Forms.Button();
            this.dataGridViewNotif = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonDelSel = new System.Windows.Forms.Button();
            this.CheckSel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNotif)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxSerialNr
            // 
            this.textBoxSerialNr.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBoxSerialNr.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSerialNr.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBoxSerialNr.Location = new System.Drawing.Point(3, 9);
            this.textBoxSerialNr.Multiline = true;
            this.textBoxSerialNr.Name = "textBoxSerialNr";
            this.textBoxSerialNr.ReadOnly = true;
            this.textBoxSerialNr.Size = new System.Drawing.Size(116, 24);
            this.textBoxSerialNr.TabIndex = 54;
            this.textBoxSerialNr.TextChanged += new System.EventHandler(this.textBoxSerialNr_TextChanged);
            // 
            // buttonFill
            // 
            this.buttonFill.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonFill.FlatAppearance.BorderSize = 0;
            this.buttonFill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFill.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFill.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.buttonFill.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonFill.Location = new System.Drawing.Point(134, 9);
            this.buttonFill.Name = "buttonFill";
            this.buttonFill.Size = new System.Drawing.Size(96, 24);
            this.buttonFill.TabIndex = 55;
            this.buttonFill.Text = "Fill";
            this.buttonFill.UseVisualStyleBackColor = false;
            this.buttonFill.Click += new System.EventHandler(this.buttonFill_Click);
            // 
            // buttonDelAll
            // 
            this.buttonDelAll.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonDelAll.FlatAppearance.BorderSize = 0;
            this.buttonDelAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelAll.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelAll.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.buttonDelAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDelAll.Location = new System.Drawing.Point(356, 9);
            this.buttonDelAll.Name = "buttonDelAll";
            this.buttonDelAll.Size = new System.Drawing.Size(96, 24);
            this.buttonDelAll.TabIndex = 56;
            this.buttonDelAll.Text = "Delete All";
            this.buttonDelAll.UseVisualStyleBackColor = false;
            this.buttonDelAll.Click += new System.EventHandler(this.buttonDelAll_Click);
            // 
            // dataGridViewNotif
            // 
            this.dataGridViewNotif.AllowUserToAddRows = false;
            this.dataGridViewNotif.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewNotif.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewNotif.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewNotif.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNotif.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckSel});
            this.dataGridViewNotif.Location = new System.Drawing.Point(0, 47);
            this.dataGridViewNotif.Name = "dataGridViewNotif";
            this.dataGridViewNotif.RowHeadersVisible = false;
            this.dataGridViewNotif.Size = new System.Drawing.Size(724, 405);
            this.dataGridViewNotif.TabIndex = 57;
            this.dataGridViewNotif.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewNotif_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonDelSel);
            this.panel1.Controls.Add(this.buttonDelAll);
            this.panel1.Controls.Add(this.buttonFill);
            this.panel1.Controls.Add(this.textBoxSerialNr);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(724, 41);
            this.panel1.TabIndex = 58;
            // 
            // buttonDelSel
            // 
            this.buttonDelSel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonDelSel.FlatAppearance.BorderSize = 0;
            this.buttonDelSel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelSel.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelSel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.buttonDelSel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDelSel.Location = new System.Drawing.Point(245, 9);
            this.buttonDelSel.Name = "buttonDelSel";
            this.buttonDelSel.Size = new System.Drawing.Size(96, 24);
            this.buttonDelSel.TabIndex = 57;
            this.buttonDelSel.Text = "Delete Selected";
            this.buttonDelSel.UseVisualStyleBackColor = false;
            this.buttonDelSel.Click += new System.EventHandler(this.buttonDelSel_Click);
            // 
            // CheckSel
            // 
            this.CheckSel.Frozen = true;
            this.CheckSel.HeaderText = "Select";
            this.CheckSel.Name = "CheckSel";
            // 
            // Notifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(724, 452);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridViewNotif);
            this.MaximumSize = new System.Drawing.Size(900, 800);
            this.MinimumSize = new System.Drawing.Size(200, 300);
            this.Name = "Notifications";
            this.Text = "Notifications";
            this.Load += new System.EventHandler(this.Notifications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNotif)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSerialNr;
        private System.Windows.Forms.Button buttonFill;
        private System.Windows.Forms.Button buttonDelAll;
        private System.Windows.Forms.DataGridView dataGridViewNotif;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonDelSel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckSel;
    }
}