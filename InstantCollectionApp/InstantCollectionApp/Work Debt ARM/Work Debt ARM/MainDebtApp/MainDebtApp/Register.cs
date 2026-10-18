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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        string conStr = System.Configuration.ConfigurationManager.ConnectionStrings["InstantLogin"].ConnectionString;

        private void buttonReg_Click(object sender, EventArgs e)
        {

     
           

            if (textBoxUsername.Text.Length >= 4 && textBoxUsername.Text.Length<26)
            {
                label1.ForeColor = System.Drawing.Color.Green;
                label1.Text = "√";
                string Entry = null;
                String Select = "select Username From Usernames where Username=@user";
                SqlConnection con1 = new SqlConnection(conStr);
                SqlCommand command1 = new SqlCommand(Select, con1);
                command1.Parameters.AddWithValue("@user", textBoxUsername.Text);

                con1.Open();
                SqlDataReader reader = command1.ExecuteReader();
                
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Entry = reader.GetString(i);
                        }

                    }
                
                con1.Close();
                command1.Parameters.Clear();
                if (Entry == null)
                {
                    string collector = null;

                    Select = "select Collector From Usernames where Collector=@coll";
                    con1 = new SqlConnection(conStr);
                    command1 = new SqlCommand(Select, con1);
                    command1.Parameters.AddWithValue("@coll", textBoxCollector.Text);

                    con1.Open();
                     reader = command1.ExecuteReader();
                    
                        while (reader.Read())
                        {
                        collector = reader.GetString(0);                   
                        }                    
                     con1.Close();

                    if (collector ==null)
                    {
                        label6.ForeColor = System.Drawing.Color.Green;
                        label6.Text = "√";
                        if (textBoxCollector.Text.Length >= 6 && textBoxCollector.Text.Length <= 35)
                        {
                            label6.ForeColor = System.Drawing.Color.Green;
                            label6.Text = "√";
                            if (textBoxPassword.Text.Length >= 6 && textBoxPassword.Text.Length <= 20)
                            {
                                label2.ForeColor = System.Drawing.Color.Green;
                                label2.Text = "√";
                                if (textBoxPassword.Text == textBoxConfirmP.Text)
                                {
                                    label3.ForeColor = System.Drawing.Color.Green;
                                    label3.Text = "√";

                                    if (MessageBox.Show("Are you sure you want to register it?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                    {
                                       // string formati = "dMmm";
                                        //string ids = DateTime.Now.ToString(formati);
                                        //int id = 0;
                                        //int.TryParse(ids, out id);
                                        //id += 1;
                                        String Query = " insert into Usernames (Username,Password,Collector,Country,Status,StartedWork,BirthDate,Phone,checkin,activity) values (@username,@password,@coll,@country,@status,@startedw,@birthdate,@phone,@check,'Active')";
                                        SqlConnection con = new SqlConnection(conStr);
                                        SqlCommand command = new SqlCommand(Query, con);
                                 
                                        command.Parameters.AddWithValue("@username", textBoxUsername.Text);
                                        command.Parameters.AddWithValue("@password", textBoxPassword.Text);
                                        command.Parameters.AddWithValue("@coll", textBoxCollector.Text);
                                        command.Parameters.AddWithValue("@Country", comboBoxCountry.Text);
                                        command.Parameters.AddWithValue("@Status", comboBoxStatus.Text);
                                        command.Parameters.AddWithValue("@startedw", dateTimePickerStarted.Value);
                                        command.Parameters.AddWithValue("@birthdate", dateTimePickerBirth.Value);
                                        command.Parameters.AddWithValue("@phone", textBoxPhone.Text);
                                        command.Parameters.AddWithValue("@check", textBoxPin.Text);

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
                            label6.ForeColor = System.Drawing.Color.Red;
                            label6.Text = "Collector name must 6-35 characters long.";
                        }
                    }
                    else
                    {
                        label6.ForeColor = System.Drawing.Color.Red;
                        label6.Text = "Collector already exists";
                    }
                }

                else
                {
                    label1.ForeColor = System.Drawing.Color.Red;
                    label1.Text = "User already exists";
                    //MessageBox.Show("User already exists");
                }
            }

            else
            {
                label1.ForeColor = System.Drawing.Color.Red;
                label1.Text = "Username must be at least 4 characters\n long and a maximum of 26 characters.";
             //   MessageBox.Show("Username must be at least 4 characters long and a maximum of 26 characters.");
            }     
        }

       
        private void Register_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'forAmazonDataSet.Usernames1' table. You can move, or remove it, as needed.
           // this.usernames1TableAdapter.Fill(this.forAmazonDataSet.Usernames1);
            // TODO: This line of code loads data into the 'forAmazonDataSet.Usernames' table. You can move, or remove it, as needed.
            this.usernamesTableAdapter.Fill(this.forAmazonDataSet.Usernames);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (comboBoxUsers.Text!="admin")
            {
                labelCombo.ForeColor = System.Drawing.Color.Green;
                labelCombo.Text = "√";
                if (comboBoxUsers.Text==textBoxConfirmuser.Text)
                {
                    labelConfUser.ForeColor = System.Drawing.Color.Green;
                    labelConfUser.Text = "√";

                    string Entry = null;
                    String Select = "select Password From Usernames where Username=@user";
                    SqlConnection con1 = new SqlConnection(conStr);
                    SqlCommand command1 = new SqlCommand(Select, con1);
                    command1.Parameters.AddWithValue("@user", "admin");

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

                    if (Entry == textBoxAdminPass.Text)
                    {                      
                                labelAdminPass.ForeColor = System.Drawing.Color.Green;
                                labelAdminPass.Text = "√";

                                if (MessageBox.Show("Are you sure you want to delete it?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                {
                                    String Query = " Delete From Usernames Where Username=@user ";
                                    SqlConnection con = new SqlConnection(conStr);
                                    SqlCommand command = new SqlCommand(Query, con);
                                  //  command.Parameters.AddWithValue("@id", id);
                                    command.Parameters.AddWithValue("@user", comboBoxUsers.Text);
                                    //command.Parameters.AddWithValue("@password", textBoxPassword.Text);
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
                        labelAdminPass.ForeColor = System.Drawing.Color.Red;
                        labelAdminPass.Text = "Wrong password";
                    }               
                 }
                else
                {
                    labelConfUser.ForeColor = System.Drawing.Color.Red;
                    labelConfUser.Text = "Usernames do not match";
                }
            }
            else
            {
                labelCombo.ForeColor = System.Drawing.Color.Red;
                labelCombo.Text = "Administrator account cannot be deleted.";
            }
        }
    }
}
