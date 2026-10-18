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
    public partial class NewContact : Form
    {
        string ClientInstitution = null;
        string usernamevalue = null;
        string collector = null;
        string StatusCollector = null;
        string LogColl = null;
        string AmznString = "Data Source=debitor.c8kumftnoykl.eu-central-1.rds.amazonaws.com,1433;Initial Catalog=ForAmazon;User ID=debitordata;Password=Trsdmr92l161";
        public NewContact()
        {
            InitializeComponent();
            if (Application.OpenForms["Form1"] != null)
            {
                labelIdSerial.Text = (Application.OpenForms["Form1"] as Form1).textname;
                linkLabelfname.Text = (Application.OpenForms["Form1"] as Form1).textname3;
                ClientInstitution = (Application.OpenForms["Form1"] as Form1).textname2;
                StatusCollector = (Application.OpenForms["Form1"] as Form1).UserRights;
                LogColl = (Application.OpenForms["Form1"] as Form1).LogColl;
                collector = (Application.OpenForms["Form1"] as Form1).textname4;
            }

            if (Application.OpenForms["Users"] != null)
            {
                usernamevalue = (Application.OpenForms["Users"] as Users).userna;
            } 
            
            if(StatusCollector.ToLower()!="admin" && StatusCollector.ToLower() != "supervisor")
            {
                textBoxFather.Enabled = false;
                textBoxDistrict.Enabled = false;
                textBoxAddress.Enabled = false;
                textBoxphone2.Enabled = false;
                textBoxphone3.Enabled = false;
                textBoxPh4.Enabled = false;
                textBoxPersonal.Enabled = false;
                textBoxEmp.Enabled = false;
                textBoxJob.Enabled = false;
                textBoxDate.Enabled = false;
            }
        }
        private void comboBoxDB_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxRel.Text!="" && comboBoxSrc.Text!="")
            {
             //   int id = 0;
                SqlConnection conx = new SqlConnection(AmznString);
                //string Querys = "Select PersonsNumber from  NumerRows";//kaped numri sekuencial i kontakteve
                //string QueryUpdate = " update  NumerRows set PersonsNumber=@nr;";// perditesohet numri sekuencial i kontakteve                                                                          
                //SqlCommand commandx = new SqlCommand(Querys, conx);

                //conx.Open();
                //SqlDataReader reader = commandx.ExecuteReader();
                
                //    while (reader.Read())
                //{
                //    id = id + 1;
                //    id = reader.GetInt32(0);
                //}
                             
                //conx.Close();
               //inserting a new contact
                //commandx.Dispose();
                string insertQuery = "insert into Persons (Client_institution,Person_number,Person_full_name,First_name,Last_name,Fathers_name,District,Address,Phone_1,phone_2,phone_3,phone_4,Employer_name,Job_position,Last_updated,User_id,email,personal_number,relation,source,birthdate) values (@client,@pnumber,@fullname,@fname,@lname,@fathern,@district,@adr,@no1,@no2,@no3,@no4,@empname,@jpos,@updated,@user,@email,@persno,@relation,@source,@birthdate)";
                SqlCommand commandx = new SqlCommand(insertQuery,conx);
               // commandx.Parameters.AddWithValue("@person", id);
                commandx.Parameters.AddWithValue("@client",ClientInstitution.ToUpper());
                commandx.Parameters.AddWithValue("@pnumber",labelIdSerial.Text);
                commandx.Parameters.AddWithValue("@fullname",linkLabelfname.Text);
                commandx.Parameters.AddWithValue("@fname",textBoxFname.Text.ToUpper());
                commandx.Parameters.AddWithValue("@lname",textBoxLname.Text.ToUpper());
                commandx.Parameters.AddWithValue("@fathern",textBoxFather.Text.ToUpper());
                commandx.Parameters.AddWithValue("@district",textBoxDistrict.Text);
                commandx.Parameters.AddWithValue("@adr",textBoxAddress.Text);
                commandx.Parameters.AddWithValue("@no1",textBoxphone1.Text);
                commandx.Parameters.AddWithValue("@no2",textBoxphone2.Text);
                commandx.Parameters.AddWithValue("@no3", textBoxphone3.Text);
                commandx.Parameters.AddWithValue("@no4", textBoxPh4.Text);
                commandx.Parameters.AddWithValue("@empname", textBoxEmp.Text);
                commandx.Parameters.AddWithValue("@jpos", textBoxJob.Text);
                commandx.Parameters.AddWithValue("@updated",DateTime.Today);
                commandx.Parameters.AddWithValue("@user", usernamevalue);
                commandx.Parameters.AddWithValue("@email", textBoxemail.Text);
                commandx.Parameters.AddWithValue("@persno", textBoxPersonal.Text.ToUpper());
                commandx.Parameters.AddWithValue("@relation", comboBoxRel.Text);
                commandx.Parameters.AddWithValue("@source", comboBoxSrc.Text);
                commandx.Parameters.AddWithValue("@birthdate", textBoxDate.Text);

                try
                {
                    conx.Open();
                    commandx.ExecuteNonQuery();
                    conx.Close();
                }
                catch (SqlException exception)
                {
                    MessageBox.Show(exception.Message.ToString(), "Error Message");
                }
                //preparing to update row numbers of the Persons table
                //commandx.Parameters.Clear();
                //commandx.Dispose();
                //commandx = new SqlCommand(QueryUpdate, conx);
                //commandx.Parameters.AddWithValue("@nr", id + 1);//increasing index number
                //try
                //{
                //    conx.Open();
                //    commandx.ExecuteNonQuery();
                //    conx.Close();
                //}
                //catch (SqlException exception)
                //{
                //    MessageBox.Show(exception.Message.ToString(), "Error Message");
                //}

                if (collector.ToLower() != LogColl.ToLower())
                {
                    commandx.Parameters.Clear();
                    string insertSMS = "insert into Notifications(serial,name,type,userid,collector,datetime)" +
                        "values(@dserial,@name,'Contact',@user,@coll,GetDate())";
                    commandx = new SqlCommand(insertSMS, conx);
                   // commandx.Parameters.AddWithValue("@id", id);
                    commandx.Parameters.AddWithValue("@dserial", labelIdSerial.Text);
                    commandx.Parameters.AddWithValue("@name", linkLabelfname.Text);
                    commandx.Parameters.AddWithValue("@user", usernamevalue);
                    commandx.Parameters.AddWithValue("@coll", collector);
                    try
                    {
                        conx.Open();
                        commandx.ExecuteNonQuery();
                        conx.Close();
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
                MessageBox.Show("Relation or data source information is missing", "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dateTimePickerbDate_ValueChanged(object sender, EventArgs e)
        {
            textBoxDate.Text = dateTimePickerbDate.Text;
        }
    }
}
