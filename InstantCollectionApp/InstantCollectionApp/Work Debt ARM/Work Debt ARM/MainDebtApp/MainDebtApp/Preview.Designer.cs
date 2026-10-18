namespace MainDebtApp
{
    partial class Preview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Preview));
            this.PictureBoxBill = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxBill)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBoxBill
            // 
            this.PictureBoxBill.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PictureBoxBill.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.PictureBoxBill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBoxBill.Location = new System.Drawing.Point(0, 0);
            this.PictureBoxBill.Name = "PictureBoxBill";
            this.PictureBoxBill.Size = new System.Drawing.Size(428, 528);
            this.PictureBoxBill.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBoxBill.TabIndex = 2;
            this.PictureBoxBill.TabStop = false;
            this.PictureBoxBill.WaitOnLoad = true;
            // 
            // Preview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(428, 528);
            this.Controls.Add(this.PictureBoxBill);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(900, 1000);
            this.Name = "Preview";
            this.Text = "Preview";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxBill)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox PictureBoxBill;
    }
}