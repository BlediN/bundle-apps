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
    public partial class EditContact : Form
    {
        string conStr = "Data Source=debitor.c8kumftnoykl.eu-central-1.rds.amazonaws.com,1433;Initial Catalog=ForAmazon;User ID=debitordata;Password=Trsdmr92l161";
        
        string CntID = null;
        string user = null;
        int ContactID = 0;
        public EditContact()
        {
            InitializeComponent();
            if (Application.OpenForms["Users"] != null)
            {
                user = (Application.OpenForms["Users"] as Users).userna;
                CntID = (Application.OpenForms["Form1"] as Form1).Contactid;
            }

            int.TryParse(CntID, out ContactID);
            string SearchQuery = "select  First_name, Last_name,Fathers_name,district,address,phone_1,phone_2,phone_3,employer_name,job_position,email,personal_number,relation,source, Person_number,Person_full_name,phone_4 from Persons where Person_id=@id";
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand(SearchQuery, con);
            cmd.Parameters.AddWithValue("@id", ContactID);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read() )
            {            
                    if (reader.IsDBNull(0)==false)
                    {
                        textBoxFname.Text = reader.GetString(0);
                    }
                    else
                    {
                        textBoxFname.Text = null;
                    }

                if (reader.IsDBNull(1) == false)
                {
                    textBoxLname.Text = reader.GetString(1);
                }
                else
                {
                    textBoxLname.Text = null;
                }

                if (reader.IsDBNull(2) == false)
                {
                    textBoxFather.Text = reader.GetString(2);
                }
                else
                {
                    textBoxFather.Text = null;
                }

                if (reader.IsDBNull(3) == false)
                {
                    textBoxDistrict.Text = reader.GetString(3);
                }
                else
                {
                    textBoxDistrict.Text = null;
                }

                if (reader.IsDBNull(4) == false)
                {
                    textBoxAddress.Text = reader.GetString(4);
                }
                else
                {
                    textBoxAddress.Text = null;
                }

                if (reader.IsDBNull(5) == false)
                {
                    textBoxphone1.Text = reader.GetString(5);
                }
                else
                {
                    textBoxphone1.Text = null;
                }

                if (reader.IsDBNull(6) == false)
                {
                    textBoxphone2.Text = reader.GetString(6);
                }
                else
                {
                    textBoxphone2.Text = null;
                }

                if (reader.IsDBNull(7) == false)
                {
                    textBoxphone3.Text = reader.GetString(7);
                }
                else
                {
                    textBoxphone3.Text = null;
                }

                if (reader.IsDBNull(8) == false)
                {
                    textBoxEmp.Text = reader.GetString(8);
                }
                else
                {
                    textBoxEmp.Text = null;
                }

                if (reader.IsDBNull(9) == false)
                {
                    textBoxJob.Text = reader.GetString(9);
                }
                else
                {
                    textBoxJob.Text = null;
                }

                if (reader.IsDBNull(10) == false)
                {
                    textBoxemail.Text = reader.GetString(10);
                }
                else
                {
                    textBoxemail.Text = null;
                }

                if (reader.IsDBNull(11) == false)
                {
                    textBoxPersonal.Text = reader.GetString(11);
                }
                else
                {
                    textBoxPersonal.Text = null;
                }

                if (reader.IsDBNull(12) == false)
                {
                    comboBoxRel.Text = reader.GetString(12);
                }
                else
                {
                    comboBoxRel.Text = null;
                }

                if (reader.IsDBNull(13) == false)
                {
                    comboBoxSrc.Text = reader.GetString(13);
                }
                else
                {
                    comboBoxSrc.Text = null;
                }

                if (reader.IsDBNull(14) == false)
                {
                    labelIdSerial.Text = reader.GetString(14);
                }
                else
                {
                    labelIdSerial.Text = null;
                }

                if (reader.IsDBNull(15) == false)
                {
                    linkLabelfname.Text = reader.GetString(15);
                }
                else
                {
                    linkLabelfname.Text = null;
                }

                if (reader.IsDBNull(16) == false)
                {
                    textBoxPhone4.Text = reader.GetString(16);
                }
                else
                {
                    textBoxPhone4.Text = null;
                }
            }
            con.Close();
        }
        
        private void buttonSave_Click(object sender, EventArgs e)
        {//updating the selected contact
            SqlConnection con = new SqlConnection(conStr);
            string updateQuery = "update persons set first_name=@fn,last_name=@ln,fathers_name=@Father,district=@dist, address=@adr,phone_1=@ph1,phone_2=@ph2,phone_3=@ph3,phone_4=@ph4,employer_name=@emp,job_position=@job,email=@email,personal_number=@pno,relation=@rel,source=@src, last_updated=@upd,user_id=@user where Person_id=@id ";

            SqlCommand cmd = new SqlCommand(updateQuery, con);
            cmd.Parameters.AddWithValue("@fn", textBoxFname.Text);
            cmd.Parameters.AddWithValue("@ln", textBoxLname.Text);
            cmd.Parameters.AddWithValue("@Father", textBoxFather.Text);
            cmd.Parameters.AddWithValue("@dist", textBoxDistrict.Text);
            cmd.Parameters.AddWithValue("@adr", textBoxAddress.Text);
            cmd.Parameters.AddWithValue("@ph1", textBoxphone1.Text);
            cmd.Parameters.AddWithValue("@ph2", textBoxphone2.Text);
            cmd.Parameters.AddWithValue("@ph3", textBoxphone3.Text);
            cmd.Parameters.AddWithValue("@ph4", textBoxPhone4.Text);
            cmd.Parameters.AddWithValue("@emp", textBoxEmp.Text);
            cmd.Parameters.AddWithValue("@job", textBoxJob.Text);
            cmd.Parameters.AddWithValue("@email", textBoxemail.Text);
            cmd.Parameters.AddWithValue("@pno", textBoxPersonal.Text);
            cmd.Parameters.AddWithValue("@rel", comboBoxRel.Text);
            cmd.Parameters.AddWithValue("@src", comboBoxSrc.Text);
            cmd.Parameters.AddWithValue("@upd", DateTime.Today);
            cmd.Parameters.AddWithValue("@user",user);
            cmd.Parameters.AddWithValue("@id", CntID);


            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                this.Close();
            }
            catch (SqlException exception)
            {

                MessageBox.Show(exception.Message.ToString(), "Error Message");
            }
        }

        private void defaultLabels1_Load(object sender, EventArgs e)
        { 
        }
    }
}
