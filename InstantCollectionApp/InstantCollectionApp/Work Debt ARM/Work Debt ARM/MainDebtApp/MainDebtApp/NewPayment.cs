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
    public partial class NewPayment : Form
    {
        string collector = null;
      string   LogColl=null;
        string Portfolio = null;
        string usernamevalue = null;
        string AmznString = System.Configuration.ConfigurationManager.ConnectionStrings["InstantLogin"].ConnectionString;

        public NewPayment()
        {
            InitializeComponent();
                      
            if (Application.OpenForms["Form1"] != null)
            {
                textBoxSerialNr.Text = (Application.OpenForms["Form1"] as Form1).textname;
                textBoxfname.Text = (Application.OpenForms["Form1"] as Form1).textname3;
                textBoxClient.Text = (Application.OpenForms["Form1"] as Form1).textname2;
                collector= (Application.OpenForms["Form1"] as Form1).textname4;
                LogColl = (Application.OpenForms["Form1"] as Form1).LogColl;
                Portfolio= (Application.OpenForms["Form1"] as Form1).PortfolioName;
            }

            if (Application.OpenForms["Users"] != null)
            {     
                usernamevalue = (Application.OpenForms["Users"] as Users).userna;
            }          
        }

        private void NewPayment_Load(object sender, EventArgs e)
        {
            this.currencyTableAdapter1.Fill(this.forAmazonDataSet.Currency);
            DateTime dt = DateTime.Today;
         //   comboBoxMonth.Text = dt.Month.ToString();
           // comboBoxYear.Text = dt.Year.ToString();
            string selectCurrency = "select currency from debtorsActive where Debt_serial_number=@dserial";
            SqlConnection con = new SqlConnection(AmznString);
            SqlCommand cmd = new SqlCommand(selectCurrency, con);
            cmd.Parameters.AddWithValue("@dserial", textBoxSerialNr.Text);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBoxCurrency.Text = reader.GetString(0);
            }
            con.Close();
            dateTimePickerPayDate.Value = DateTime.Today;

            string selectPaymentType = " select types from paymentTypes";
             con = new SqlConnection(AmznString);
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = new SqlCommand(selectPaymentType, con);

            DataTable dtb = new DataTable();
            adapt.Fill(dtb);
            comboBoxPayment.DataSource = dtb;
            comboBoxPayment.DisplayMember = "types";
            comboBoxPayment.SelectedItem = null;
          
        }
        private void comboBoxDB_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        private void textboxCommentKeyPress (object ob, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }
        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            // the code block below was commented out because the ID is st automatically by the database
            //int id = 1;
            //string constring3 = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\SystemDebtors.mdf;Integrated Security=True;Connect Timeout=60";
            //SqlConnection conx = new SqlConnection(AmznString);
            //String Querys = "Select PaymentsNumber from  NumerRows";
            //String Query1 = " update  NumerRows set PaymentsNumber=@nr;";
            //SqlCommand commandx = new SqlCommand(Querys, conx);
            //SqlCommand commandy = new SqlCommand(Query1, conx);

            //conx.Open();
            //using (SqlDataReader reader = commandx.ExecuteReader())
            //{
            //    while (reader.Read())
            //    {
            //        id = id + 1;
            //        id = reader.GetInt32(0);
            //    }
            //}
            //commandy.Parameters.AddWithValue("@nr", id + 1);
            //commandy.ExecuteNonQuery();
            //conx.Close();

            richTextBoxcoment.Text = richTextBoxcoment.Text.Replace(System.Environment.NewLine, " ");
            SqlConnection con = new SqlConnection(AmznString);

            String query = "INSERT INTO PaymentsJan(Debt_Serial_Number,Person_Full_Name,Client_Institution,Paid_Amount,PaymentDate,Payment_Currency,Comments,Last_Updated,User_Id,Collector,Portfolios,paymentType) VALUES(@serialnr, @linklb, @clinstit, @paidamt,@pDate,@pcurrency,@comment,@lastupd,@userid,@coll,@port,@ptype)";
            SqlCommand command = new SqlCommand(query, con);
            
            //command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@serialnr", textBoxSerialNr.Text);
            command.Parameters.AddWithValue("@linklb", textBoxfname.Text);
            command.Parameters.AddWithValue("@clinstit", textBoxClient.Text);
            command.Parameters.AddWithValue("@paidamt", textBoxpaidAmt.Text);
            command.Parameters.AddWithValue("@pDate", dateTimePickerPayDate.Value);
           // command.Parameters.AddWithValue("@pyear", comboBoxYear.Text.ToString());
            command.Parameters.AddWithValue("@pcurrency",comboBoxCurrency.Text.ToString());
            command.Parameters.AddWithValue("@comment", richTextBoxcoment.Text);
            command.Parameters.AddWithValue("@lastupd", DateTime.Today);
            command.Parameters.AddWithValue("@userid",usernamevalue );
            command.Parameters.AddWithValue("@coll", collector);
            command.Parameters.AddWithValue("@port", Portfolio);
            command.Parameters.AddWithValue("@ptype", comboBoxPayment.Text);

            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
                if (collector.ToLower() != LogColl.ToLower())//nitify collector if payment is added by another user.
                {
                    command.Parameters.Clear();
                    string insertSMS = "insert into Notifications(serial,name,type,userid,collector,datetime)" +
                        "values(@dserial,@name,'Payment',@user,@coll,GetDate())";
                    command = new SqlCommand(insertSMS, con);
                    //command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@dserial", textBoxSerialNr.Text);
                    command.Parameters.AddWithValue("@name", textBoxfname.Text);
                    command.Parameters.AddWithValue("@user", usernamevalue);
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

           
           // this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
