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
    public partial class NewClientcs : Form
    {
        string conStr1 = "Data Source=debitor.c8kumftnoykl.eu-central-1.rds.amazonaws.com,1433;Initial Catalog=ForAmazon;User ID=debitordata;Password=Trsdmr92l161";

        public NewClientcs()
        {
            InitializeComponent();
        }
        private void comboBoxDB_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (richTextBoxClient.Text != null && richTextBoxClient.Text !="" && comboBoxCountry.Text != null && comboBoxCountry.Text !="" && comboBoxType.Text != null && comboBoxType.Text !="")
            {
                int id = 1;
                string countClients = "Select count(id) from clientinstitution";
                SqlConnection con = new SqlConnection(conStr1);
                SqlCommand cmd = new SqlCommand(countClients, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                }
                con.Close();
                cmd.Dispose();

                string insertQuery = "insert into clientinstitution(id,Client_Institution,NIPT,Type,Country,District,Address,email,phone1,phone2,phone3,representative,Date,Users)";
                insertQuery = insertQuery + " values (@id,@client,@nipt,@type,@country,@district,@address,@email,@phone1,@phone2,@phone3,@representative,@date,@users)";
                cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.AddWithValue("id", id+1);
                cmd.Parameters.AddWithValue("client", richTextBoxClient.Text);
                cmd.Parameters.AddWithValue("nipt", richTextBoxnipt.Text);
                cmd.Parameters.AddWithValue("type", comboBoxType.Text);
                cmd.Parameters.AddWithValue("country", comboBoxCountry.Text);
                cmd.Parameters.AddWithValue("district", textBoxDistrict.Text);
                cmd.Parameters.AddWithValue("address", textBoxAdr.Text);
                cmd.Parameters.AddWithValue("email", maskedTextBoxemail.Text);
                cmd.Parameters.AddWithValue("phone1", richTextBoxPh1.Text);
                cmd.Parameters.AddWithValue("phone2", richTextBoxPh2.Text);
                cmd.Parameters.AddWithValue("phone3", richTextBoxPh3.Text);
                cmd.Parameters.AddWithValue("representative", richTextBoxRep.Text);
                cmd.Parameters.AddWithValue("date", DateTime.Today);
                cmd.Parameters.AddWithValue("users", "admin");
                if (MessageBox.Show("Are you sure you want to add this client?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Client added succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (SqlException exception)
                    {
                        MessageBox.Show(exception.Message.ToString(), "Error Message");
                    }
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Mandatory (*) fields cannot be left blank", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
