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
    public partial class ChangePass : Form
    {
        public ChangePass()
        {
            InitializeComponent();
            string usernamevalue = null;

            if (Application.OpenForms["Users"] != null)
            {             
                usernamevalue = (Application.OpenForms["Users"] as Users).userna;
            }
            label6.Text = usernamevalue;
        }

        private void buttonReg_Click(object sender, EventArgs e)
        {
            string Entry = null;
            string conStr = "Data Source=debitor.c8kumftnoykl.eu-central-1.rds.amazonaws.com,1433;Initial Catalog=ForAmazon;User ID=debitordata;Password=Trsdmr92l161";
            String Select = "select Password From Usernames where Username=@user";
            SqlConnection con1 = new SqlConnection(conStr);
            SqlCommand command1 = new SqlCommand(Select, con1);
            command1.Parameters.AddWithValue("@user", label6.Text);

            con1.Open();
            using (SqlDataReader reader = command1.ExecuteReader())
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Entry = reader.GetString(i);
                    }
                }
            }
            con1.Close();

            if (Entry == textBoxOldPass.Text)
            {
                labeloldp.ForeColor = System.Drawing.Color.Green;
                labeloldp.Text = "√";
                if (textBoxPassword.Text.Length >= 6 && textBoxPassword.Text.Length <= 20)
                {
                    label2.ForeColor = System.Drawing.Color.Green;
                    label2.Text = "√";
                    if (textBoxPassword.Text == textBoxConfirmP.Text)
                    {
                        label3.ForeColor = System.Drawing.Color.Green;
                        label3.Text = "√";

                        if (MessageBox.Show("Are you sure you want to Change it?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            String Query = " Update Usernames set Password=@password From Usernames Where Username=@username";
                            SqlConnection con = new SqlConnection(conStr);
                            SqlCommand command = new SqlCommand(Query, con);
                          //  command.Parameters.AddWithValue("@id", id);
                            command.Parameters.AddWithValue("@username", label6.Text);
                            command.Parameters.AddWithValue("@password", textBoxPassword.Text);

                            try
                            {
                                con.Open();
                                command.ExecuteNonQuery();
                                con.Close();
                                // this.Close();
                            }

                            catch (SqlException exception)
                            {
                                MessageBox.Show(exception.Message.ToString(), "Error Message");
                            }
                            this.Close();
                        }
                    }

                    else
                    {
                        label3.ForeColor = System.Drawing.Color.Red;
                        label3.Text = "Passwords do not match";
                        // MessageBox.Show("Passwords do not match");
                    }
                }

                else
                {
                    label2.ForeColor = System.Drawing.Color.Red;
                    label2.Text = "Password must be at least 6 characters\n long and a maximum of 20 characters.";
                    // MessageBox.Show("Password must be at least 6 characters long and a maximum of 20 characters.");
                }            
            }
            else
            {
                labeloldp.ForeColor = System.Drawing.Color.Red;
                labeloldp.Text = "Wrong password";
            }
        }
    }
}
