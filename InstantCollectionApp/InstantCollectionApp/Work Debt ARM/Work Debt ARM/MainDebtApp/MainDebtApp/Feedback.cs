using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MainDebtApp
{
    public partial class Feedback : Form
    {
        string ConectionStr = "Data Source=debitor.c8kumftnoykl.eu-central-1.rds.amazonaws.com,1433;Initial Catalog=ForAmazon;User ID=debitordata;Password=Trsdmr92l161";
        string usernamevalue = null;
        public Feedback()
        {
            InitializeComponent();
            if (Application.OpenForms["Users"] != null)
            {
                usernamevalue = (Application.OpenForms["Users"] as Users).userna;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection(ConectionStr);
            string InsertData = "insert into FeedbackTab (fedtype,comment,data,user_ids) values (@fed,@comments,@data,@user)";
            SqlCommand cmd = new SqlCommand(InsertData, con1);
            cmd.Parameters.AddWithValue("@fed", comboBoxFedT.Text);
            cmd.Parameters.AddWithValue("@comments", textBoxComment.Text);
            cmd.Parameters.AddWithValue("@data", DateTime.Now);
            cmd.Parameters.AddWithValue("@user", usernamevalue);

            try
            {
                con1.Open();
                cmd.ExecuteNonQuery();
                con1.Close();
                MessageBox.Show("Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message.ToString(), "Error Message");
            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();        }
    }
}
