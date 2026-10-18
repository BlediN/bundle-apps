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
    public partial class EditPayment : Form
    {
        string PayID = null;
        int ID = 0;
        string LogedCollector = null;
        string logetUser = null;
        string collector = null;
        string shuma = null;
        string StatusColl = null;
        string Dserial = null;//, currency = null;
        string conStr = "Data Source=debitor.c8kumftnoykl.eu-central-1.rds.amazonaws.com,1433;Initial Catalog=ForAmazon;User ID=debitordata;Password=Trsdmr92l161";
        public EditPayment()
        {     // last edited 11.41 30.05.2016
            InitializeComponent();
            //string usernamevalue = null;

            //if (Application.OpenForms["Form1"] != null)
            //{
            //    PayID = (Application.OpenForms["Form1"] as Form1).PaymID;
            //    usernamevalue = (Application.OpenForms["Form1"] as Form1).textname1;
            //}

            if (Application.OpenForms["Users"] != null)
            {
                logetUser = (Application.OpenForms["Users"] as Users).userna;
                PayID = (Application.OpenForms["Form1"] as Form1).PaymID;
                LogedCollector = (Application.OpenForms["Users"] as Users).collector;
                StatusColl= (Application.OpenForms["Form1"] as Form1).UserRights;
            }

        //    string formati = "dd/MM/yyyy";
           // labeldata.Text = DateTime.Today.ToString(formati);
            int.TryParse(PayID, out ID);
            double paidAmt = 0.0;
            //int month = 0;
            //int year = 0;
            string personN = null;
            
          //  DateTime dt = new DateTime();
            
            String Select = "select Person_Full_Name, Paid_Amount,PaymentDate,Payment_Currency,Collector,Comments,payment_status,Debt_serial_number,paymentdiff From PaymentsJan where ID=@id";
            SqlConnection con1 = new SqlConnection(conStr);
            SqlCommand command1 = new SqlCommand(Select, con1);
            command1.Parameters.AddWithValue("@id", ID);

            con1.Open();
            SqlDataReader reader = command1.ExecuteReader();           
                while (reader.Read())
                {
                    personN = reader.GetString(0);
                    paidAmt = reader.GetDouble(1);
                Dserial = reader.GetString(7);
                    //month = reader.GetInt16(2);
                    //year = reader.GetInt16(3);
                dateTimePickerPayDate.Value = reader.GetDateTime(2);

                if (reader.IsDBNull(4)==false)
                    {
                        collector = reader.GetString(4);
                    }

                else
                    {
                        collector = null;
                    }

                //currency = reader.GetString(3);
                //comboBoxCurrency.Text = currency;
                if (reader.IsDBNull(3) == false)
                {
                     comboBoxCurrency.Text = reader.GetString(3).Trim();
                }
                else
                {
                    comboBoxCurrency.Text = null;
                }

                if (reader.IsDBNull(5) == false)
                {
                    richTextBoxcoment.Text = reader.GetString(5);
                }
                else
                {
                    richTextBoxcoment.Text = null;
                }
                if (reader.IsDBNull(6)==false)
                {
                    comboBoxPaymentStatus.Text = reader.GetString(6);
                }
                else
                {
                    comboBoxPaymentStatus.Text = null;
                }

                if (reader.IsDBNull(8)==false)
                {
                    textBoxDiff.Text = reader.GetDouble(8).ToString();
                }
                else
                {
                    textBoxDiff.Text = null;
                }


            }  
                         
            con1.Close();

            labelPayIDNr.Text = PayID;
            textBoxpaidAmt.Text = paidAmt.ToString();
          //  comboBoxMonth.Text = month.ToString();
            labelPname.Text = personN;
          //  comboBoxYear.Text = year.ToString();
            textBoxCollector.Text = collector;
            shuma = textBoxpaidAmt.Text;
          //  comboBoxCurrency.Text = currency;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            richTextBoxcoment.Text = richTextBoxcoment.Text.Replace(System.Environment.NewLine, " ");
            collector = collector.ToLower();         
            //double.TryParse(textBoxpaidAmt.Text,out shuma);
            LogedCollector = LogedCollector.ToLower();
            if (StatusColl.ToLower() == "admin" || StatusColl.ToLower() == "supervisor" || StatusColl.ToLower() == "agent")
            {
                if (MessageBox.Show("Are you sure you want to edit this payment?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    // string conStr1 = "Data Source=debitor.c8kumftnoykl.eu-central-1.rds.amazonaws.com,1433;Initial Catalog=ForAmazon;User ID=debitordata;Password=Trsdmr92l161";
                    String Query = " update PaymentsJan set Paid_Amount=@paidamt, PaymentDAte=@pDate,Payment_Currency=@pcurrency,Comments=@comment,User_Id=@userid, Collector=@coll,paymentDiff=@pdiff,payment_status=nullif(@paymentStatus,'') where ID=@id";
                    SqlConnection con = new SqlConnection(conStr);
                    SqlCommand command = new SqlCommand(Query, con);

                    command.Parameters.AddWithValue("@paidamt", textBoxpaidAmt.Text);
                    command.Parameters.AddWithValue("@pDate", dateTimePickerPayDate.Value);
                   // command.Parameters.AddWithValue("@pyear", comboBoxYear.Text.ToString());
                    command.Parameters.AddWithValue("@pcurrency", comboBoxCurrency.Text.ToString());
                    command.Parameters.AddWithValue("@comment", richTextBoxcoment.Text);
                   // command.Parameters.AddWithValue("@lastupd", DateTime.Today);
                    command.Parameters.AddWithValue("@userid", logetUser);
                    command.Parameters.AddWithValue("@id", ID);
                    command.Parameters.AddWithValue("@coll", textBoxCollector.Text);
                    command.Parameters.AddWithValue("@paymentStatus", comboBoxPaymentStatus.Text);
                    command.Parameters.AddWithValue("@pdiff", textBoxDiff.Text);


                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();
                        con.Close();
                        // this.Close();
                        if(collector.ToLower()!=textBoxCollector.Text.ToLower())
                        {
                            command.Parameters.Clear();
                            string insertSMS = "insert into Notifications(serial,name,type,userid,collector,datetime)" +
                                "values(@dserial,@name,@type,@user,@coll,GetDate())";
                            command = new SqlCommand(insertSMS, con);
                        //    command.Parameters.AddWithValue("@id", ID);
                            command.Parameters.AddWithValue("@dserial", Dserial);
                            command.Parameters.AddWithValue("@name", labelPname.Text);
                            command.Parameters.AddWithValue("@type", "Payment transfered");
                            command.Parameters.AddWithValue("@user", logetUser);
                            command.Parameters.AddWithValue("@coll", collector);

                            SqlCommand cmd = new SqlCommand(insertSMS, con);
                            cmd = new SqlCommand(insertSMS, con);
                        //    cmd.Parameters.AddWithValue("@id", ID);
                            cmd.Parameters.AddWithValue("@dserial", Dserial);
                            cmd.Parameters.AddWithValue("@name", labelPname.Text);
                            cmd.Parameters.AddWithValue("@type", "Payment income");
                            cmd.Parameters.AddWithValue("@user", logetUser);
                            cmd.Parameters.AddWithValue("@coll", textBoxCollector.Text);

                            try
                            {
                                con.Open();
                                command.ExecuteNonQuery();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                            catch (SqlException exception)
                            {
                                MessageBox.Show(exception.Message.ToString(), "Error Message");
                            }
                        }

                        if (shuma != textBoxpaidAmt.Text.ToLower())
                        {
                            command.Parameters.Clear();
                            string insertSMS = "insert into Notifications(serial,name,type,userid,collector,datetime)" +
                                "values(@dserial,@name,@type,@user,@coll,GetDate())";
                            command = new SqlCommand(insertSMS, con);
                            //    command.Parameters.AddWithValue("@id", ID);
                            command.Parameters.AddWithValue("@dserial", Dserial);
                            command.Parameters.AddWithValue("@name", labelPname.Text);
                            command.Parameters.AddWithValue("@type", "Ndryshim pagese");
                            command.Parameters.AddWithValue("@user", logetUser);
                            command.Parameters.AddWithValue("@coll", collector);
                          
                            try
                            {
                                con.Open();
                                command.ExecuteNonQuery();              
                                con.Close();
                            }
                            catch (SqlException exception)
                            {
                                MessageBox.Show(exception.Message.ToString(), "Error Message");
                            }
                        }



                        this.Close();
                    }

                    catch (SqlException exception)
                    {
                        MessageBox.Show(exception.Message.ToString(), "Error Message");                   
                    }
                    

                }
            }
            else
            {
                MessageBox.Show("You cannot edit a payment.\nPlease contact system administrator.", "Presmission denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            collector = collector.ToLower();
            LogedCollector = LogedCollector.ToLower();
            if (StatusColl.ToLower() == "admin" || StatusColl.ToLower() == "supervisor" || StatusColl.ToLower() == "agent")
            {
                if (MessageBox.Show("Are you sure you want to delete this payment?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection(conStr);
                    string queryDelete = "delete from PaymentsJan where ID=@id";
                    SqlCommand command = new SqlCommand(queryDelete, con);
                    command.Parameters.AddWithValue("@id", ID);
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
                MessageBox.Show("You cannot delete a payment.\nPlease contact system administrator.", "Presmission denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void EditPayment_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'forAmazonDataSet.Currency' table. You can move, or remove it, as needed.
            this.currencyTableAdapter.Fill(this.forAmazonDataSet.Currency);
            // TODO: This line of code loads data into the 'forAmazonDataSet.Usernames' table. You can move, or remove it, as needed.
            this.usernamesTableAdapter.Fill(this.forAmazonDataSet.Usernames);
           // comboBoxCurrency.Text = currency;
           

        }

        private void comboBoxCollectors_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxCollector.Text = comboBoxCollectors.SelectedValue.ToString();
        }
    }
}
