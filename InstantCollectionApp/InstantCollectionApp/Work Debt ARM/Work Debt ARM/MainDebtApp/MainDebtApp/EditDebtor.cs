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
    public partial class EditDebtor : Form
    {
        string ConectionStr = "Data Source=debitor.c8kumftnoykl.eu-central-1.rds.amazonaws.com,1433;Initial Catalog=ForAmazon;User ID=debitordata;Password=Trsdmr92l161";
     //   decimal sum = 0;
        string usernamevalue = null;
        string FirstCollector = null;
        int debt_ID = 0;
     //   string statusvalue = null;
        public EditDebtor()
        {
            InitializeComponent();
            if (Application.OpenForms["Form1"] != null)
            {
                debt_Serial_NumberLabel1.Text = (Application.OpenForms["Form1"] as Form1).textname;
                debtor_Full_NameTextBox.Text = (Application.OpenForms["Form1"] as Form1).textname3;
                comboBoxDCollector.Text = (Application.OpenForms["Form1"] as Form1).textname4;
                FirstCollector = (Application.OpenForms["Form1"] as Form1).textname4;
                debt_Id1TextBox.Text = (Application.OpenForms["Form1"] as Form1).DebtId;

            }
            if (Application.OpenForms["Users"] != null)
            {
                usernamevalue = (Application.OpenForms["Users"] as Users).userna;            
            }

            this.reactionsTableAdapter.Fill(this.forAmazonDataSet.Reactions);
            // TODO: This line of code loads data into the 'forAmazonDataSet.ClientInstitution' table. You can move, or remove it, as needed.
            this.clientInstitutionTableAdapter.Fill(this.forAmazonDataSet.ClientInstitution);
            // TODO: This line of code loads data into the 'forAmazonDataSet.ContactedPerson' table. You can move, or remove it, as needed.
            this.contactedPersonTableAdapter.Fill(this.forAmazonDataSet.ContactedPerson);
            // TODO: This line of code loads data into the 'forAmazonDataSet.Portofolio' table. You can move, or remove it, as needed.
            this.portofolioTableAdapter.Fill(this.forAmazonDataSet.Portofolio);
            // TODO: This line of code loads data into the 'forAmazonDataSet.Currency' table. You can move, or remove it, as needed.
            this.currencyTableAdapter.Fill(this.forAmazonDataSet.Currency);
            this.debtTypeTableAdapter.Fill(this.forAmazonDataSet.DebtType);
            this.usernamesTableAdapter.Fill(this.forAmazonDataSet.Usernames);
            //  this.debtorsActiveTableAdapter.FillBy(this.forAmazonDataSet.DebtorsActive, debt_ID);
            this.portofolioStatusTableAdapter.Fill(this.forAmazonDataSet.PortofolioStatus);


            int.TryParse(debt_Id1TextBox.Text, out debt_ID);
            string SelectData = "select debt_serial_number,debt_type,Debtor_full_name,portfolio_status,outstanding_principal,outstanding_interest,outstanding_penalty " +
                ",currency, portfolio,debt_collector,total_outstanding,assigment_date,client_branch,last_act_type,next_action_date,client,latest_comment,latest_person_contacted,reaction " +
                ",contactedVia, closeDate,disbursmentdate,finishedDate,mortgage,pledge,cashcolateral,contractStatusID,branchId,linkID,classification "+
                " ,PayAccNo, assignmentdebt, PTP_Amount,disbursmentAmount,InAll_Base,AmountInDelay,PrincipalDelay,InterestDelay,upcomingInterest,clientSegment,productID,DaysIndelay, "+
                "avgMoRepayment  from debtorsActive where debt_id=@db_id ";
           
            SqlConnection con = new SqlConnection(ConectionStr);
            SqlCommand cmd = new SqlCommand(SelectData, con);
            cmd.Parameters.AddWithValue("@db_id", debt_Id1TextBox.Text);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
               
                debt_Serial_NumberLabel1.Text = reader.GetString(0);
                debt_TypeComboBox.Text = reader.GetString(1);
                debtor_Full_NameTextBox.Text = reader.GetString(2);
                portfolio_StatusComboBox.SelectedValue = reader.GetString(3);
                outstanding_PrincipalTextBox.Text = reader.GetDouble(4).ToString();
                outstanding_InterestTextBox.Text = reader.GetDouble(5).ToString();
                outstanding_PenaltyTextBox.Text = reader.GetDouble(6).ToString();
                currencyComboBox.Text = reader.GetString(7);
                portfolioTextBox.Text = reader.GetString(8);
                comboBoxDCollector.Text = reader.GetString(9);
                total_Outstanding1TextBox.Text = reader.GetDecimal(10).ToString();
                assigment_DateDateTimePicker.Text = reader.GetDateTime(11).ToString();

                if (reader.IsDBNull(12)==false)
                {
                    client_BranchTextBox.Text= reader.GetString(12);
                } 
                
                last_Act_typeTextBox.Text = reader.IsDBNull(13) ? null : reader.GetString(13);
                next_Action_DateDateTimePicker.Text = reader.IsDBNull(14) ? null : reader.GetDateTime(14).ToString();
                clientComboBox.Text = reader.IsDBNull(15) ? null : reader.GetString(15);
                latest_CommentTextBox.Text = reader.IsDBNull(16) ? null : reader.GetString(16);

                latest_Person_ContactedComboBox.Text = reader.IsDBNull(17) ? null : reader.GetString(17);
                reactionComboBox.Text = reader.IsDBNull(18) ? null : reader.GetString(18);
                contactedViaTextBox.Text = reader.IsDBNull(19) ? null : reader.GetString(19);

                if (reader.IsDBNull(20)==false)
                {
                    closeDateDateTimePicker.Text = reader.GetDateTime(20).ToString();
                }

                if (reader.IsDBNull(21)==false)
                {
                    disbursmentDateDateTimePicker.Text = reader.GetDateTime(21).ToString();
                }

                if (reader.IsDBNull(22) == false)
                {
                    finishedDateDateTimePicker.Text = reader.GetDateTime(22).ToString();
                }

                if (reader.IsDBNull(23) == false)
                {
                    mortgageTextBox.Text = reader.GetString(23);
                }

                if (reader.IsDBNull(24) == false)
                {
                    pledgeTextBox.Text = reader.GetString(24);
                }

                if (reader.IsDBNull(25) == false)
                {
                    cashColateralTextBox.Text = reader.GetString(25);
                }
              
                if (reader.IsDBNull(26) == false)
                {
                    contractStatusIdTextBox.Text = reader.GetString(26);
                }

                if (reader.IsDBNull(27) == false)
                {
                    branchIdTextBox.Text = reader.GetString(27);
                }


                linkIDTextBox.Text = reader.IsDBNull(28) ? null : reader.GetString(28);
                classificationTextBox.Text = reader.IsDBNull(29) ? null : reader.GetString(29);
                payAccNoTextBox.Text = reader.IsDBNull(30) ? null : reader.GetString(30);

                assignmentDebtTextBox.Text = reader.IsDBNull(31) ? null : reader.GetDecimal(31).ToString();
                pTP_AmountTextBox.Text = reader.IsDBNull(32) ? null : reader.GetDouble(32).ToString();
                disbursmentAmountTextBox.Text = reader.IsDBNull(33) ? null : reader.GetDecimal(33).ToString();
                inALL_BaseTextBox.Text = reader.IsDBNull(34) ? null : reader.GetDecimal(34).ToString();
                amountInDelayTextBox.Text = reader.IsDBNull(35) ? null : reader.GetDecimal(35).ToString();

                principalDelayTextBox.Text = reader.IsDBNull(36) ? null : reader.GetDecimal(36).ToString();
                interestDelayTextBox.Text = reader.IsDBNull(37) ? null : reader.GetDecimal(37).ToString();
                upComingInterestTextBox.Text = reader.IsDBNull(38) ? null : reader.GetDecimal(38).ToString();
                clientSegmentTextBox.Text = reader.IsDBNull(39) ? null : reader.GetString(39);
                productIDTextBox.Text = reader.IsDBNull(40) ? null : reader.GetString(40);
                daysInDelayTextBox.Text = reader.IsDBNull(41) ? null : reader.GetInt16(41).ToString();
                avgMoRepaymentTextBox.Text = reader.IsDBNull(42) ? null : reader.GetDouble(42).ToString();


            }
            con.Close();

         //   comboBoxSituation.Text = statusvalue;
        }

        private void EditDebtor_Load(object sender, EventArgs e)
        {
           // int nrserial = 0;
          //  int.TryParse(debt_Id1TextBox.Text, out nrserial);
            // TODO: This line of code loads data into the 'forAmazonDataSet.Reactions' table. You can move, or remove it, as needed.
         
           
            //string Search = "select portfolio_status,total_outstanding,debt_type,currency,portfolio,debt_collector from debtorsActive where debt_serial_number=@dserial";
            //SqlConnection con = new SqlConnection(ConectionStr);
            //SqlCommand cmd = new SqlCommand(Search, con);
            //cmd.Parameters.AddWithValue("@dserial", debt_Serial_NumberLabel1.Text);
            //con.Open();
            //SqlDataReader reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //    statusvalue = reader.GetString(0);
            //    sum = reader.GetDecimal(1);
            //    comboBoxType.Text = reader.GetString(2);
            //    comboBoxCurr.Text = reader.GetString(3);
            //    comboBoxPorto.Text = reader.GetString(4);
            //    comboBoxCollector.Text= reader.GetString(5);
            //}
            //con.Close();
            //textBoxAmt.Text = sum.ToString();
            //comboBoxSituation.Text = statusvalue;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string password=null;

       //     decimal.TryParse(textBoxAmt.Text, out sum);
            SqlConnection con = new SqlConnection(ConectionStr);
            string InsertNotification = "insert into Notifications(serial, name, type, userid, collector, datetime)" +
              "values(@dserial,@name,'Largim debitori',@user,@collect,GetDate())";
            string InsertNotification2 = "insert into Notifications(serial, name, type, userid, collector, datetime)" +
             "values(@dserial,@name,'Marrje debitori ',@user,@coll,GetDate())";

            string update = "update debtorsactive set debt_collector=@coll,portfolio_status=@situation,total_outstanding=@amt,debt_type=@type,currency=@curr,portfolio=@port " +
                " , Debtor_Full_Name=@name, Outstanding_Principal=@opricipal, Outstanding_Interest=@ointerest, Outstanding_Penalty=@openalty, " +
                         "Assigment_Date=@asgdate, Client_Branch=@cbranch, Next_Action_Date=@nad, Last_Act_type=@lat, Client=@client, ContactedVia=@cvia, Latest_Comment=@comment, Latest_Person_Contacted=@lpc, PTP_Amount=@ptpamo, Reaction=@react, " +
                         " BranchId=@bid, CashColateral=@ccolateral, ClientSegment=@csegment, CloseDate=@cdate, ContractStatusId=@csid, DaysInDelay=@did, DisbursmentDate=@ddate, FinishedDate=@fdate,  IsRestructured=@isrestr, " +
                         " Mortgage=@mortg,  Pledge=@pledge, ProductID=@prid,reassigned=getdate(), RestructuredContract=@restcntr," +
                         " Classification=@class, LinkID=@linkid, PayAccNo=@payacco  where debt_serial_number=@dserial and debt_id='"+ debt_Id1TextBox.Text +"'";

            string pass = "select password from usernames where username='" + usernamevalue+"'";

            SqlCommand cmd = new SqlCommand(pass, con);          
            //con.Open();
            //SqlDataReader reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //    password = reader.GetString(0);
            //}
            //con.Close();
            //cmd.Dispose();
            //if (password== textBoxPass.Text)
            //{
                cmd = new SqlCommand(update, con);
                cmd.Parameters.AddWithValue("@dserial", debt_Serial_NumberLabel1.Text);
                cmd.Parameters.AddWithValue("@coll", comboBoxDCollector.Text);
                cmd.Parameters.AddWithValue("@situation", portfolio_StatusComboBox.Text);
                cmd.Parameters.AddWithValue("@amt", total_Outstanding1TextBox.Text);
                cmd.Parameters.AddWithValue("@type", debt_TypeComboBox.Text);
               // cmd.Parameters.AddWithValue("@upd", DateTime.Today);
              //  cmd.Parameters.AddWithValue("@user", usernamevalue);
                cmd.Parameters.AddWithValue("@curr", currencyComboBox.Text);
                cmd.Parameters.AddWithValue("@port", portfolioTextBox.Text);

                cmd.Parameters.AddWithValue("@name", debtor_Full_NameTextBox.Text);
                cmd.Parameters.AddWithValue("@opricipal", outstanding_PrincipalTextBox.Text);
                cmd.Parameters.AddWithValue("@openalty", outstanding_PenaltyTextBox.Text);
                cmd.Parameters.AddWithValue("@ointerest", outstanding_InterestTextBox.Text);
                cmd.Parameters.AddWithValue("@asgdate", assigment_DateDateTimePicker.Text);
                cmd.Parameters.AddWithValue("@cbranch", client_BranchTextBox.Text);
                cmd.Parameters.AddWithValue("@nad", next_Action_DateDateTimePicker.Text);
                cmd.Parameters.AddWithValue("@lat", last_Act_typeTextBox.Text);
                cmd.Parameters.AddWithValue("@client", clientComboBox.Text);
                cmd.Parameters.AddWithValue("@cvia", contactedViaTextBox.Text);
                cmd.Parameters.AddWithValue("@comment", latest_CommentTextBox.Text);
                cmd.Parameters.AddWithValue("@lpc", latest_Person_ContactedComboBox.Text);
                cmd.Parameters.AddWithValue("@ptpamo", pTP_AmountTextBox.Text);
                cmd.Parameters.AddWithValue("@react", reactionComboBox.Text);
              //  cmd.Parameters.AddWithValue("@aid", amountInDelayTextBox.Text);
                // cmd.Parameters.AddWithValue("@amr", comboBoxPorto.Text);
                cmd.Parameters.AddWithValue("@bid", branchIdTextBox.Text);
                cmd.Parameters.AddWithValue("@ccolateral", cashColateralTextBox.Text);
                cmd.Parameters.AddWithValue("@csegment", clientSegmentTextBox.Text);
                cmd.Parameters.AddWithValue("@cdate", closeDateDateTimePicker.Text);
                cmd.Parameters.AddWithValue("@csid", contractStatusIdTextBox.Text);
                cmd.Parameters.AddWithValue("@did", daysInDelayTextBox.Text);
            //    cmd.Parameters.AddWithValue("@damount", disbursmentAmountTextBox.Text);
                cmd.Parameters.AddWithValue("@ddate", disbursmentDateDateTimePicker.Text);
                cmd.Parameters.AddWithValue("@fdate", finishedDateDateTimePicker.Text);
              //  cmd.Parameters.AddWithValue("@iabase", inALL_BaseTextBox.Text);
              //  cmd.Parameters.AddWithValue("@idelay", interestDelayTextBox.Text);
                cmd.Parameters.AddWithValue("@isrestr", isRestructuredTextBox.Text);
                cmd.Parameters.AddWithValue("@mortg", mortgageTextBox.Text);
                cmd.Parameters.AddWithValue("@pledge", pledgeTextBox.Text);
            //    cmd.Parameters.AddWithValue("@ptprepay", .Text);
              //  cmd.Parameters.AddWithValue("@pindelay", principalDelayTextBox.Text);

                cmd.Parameters.AddWithValue("@prid", productIDTextBox.Text);
               // cmd.Parameters.AddWithValue("@reperiod", comboBoxPorto.Text);
                cmd.Parameters.AddWithValue("@restcntr", restructuredContractTextBox.Text);
               // cmd.Parameters.AddWithValue("@risk", comboBoxPorto.Text);
             //   cmd.Parameters.AddWithValue("@upcint", upComingInterestTextBox.Text);
             //   cmd.Parameters.AddWithValue("@asgDebt", assignmentDebtTextBox.Text);
                cmd.Parameters.AddWithValue("@class", classificationTextBox.Text);
                cmd.Parameters.AddWithValue("@linkid", linkIDTextBox.Text);
                cmd.Parameters.AddWithValue("@payacco", payAccNoTextBox.Text);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    if (FirstCollector.ToLower()!= comboBoxDCollector.Text.ToLower())
                    {
                        cmd = new SqlCommand(InsertNotification, con);
                        cmd.Parameters.AddWithValue("@collect", FirstCollector);
                        cmd.Parameters.AddWithValue("@dserial", debt_Serial_NumberLabel1.Text);
                        cmd.Parameters.AddWithValue("@name", debtor_Full_NameTextBox.Text);
                        cmd.Parameters.AddWithValue("@user", usernamevalue);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        cmd = new SqlCommand(InsertNotification2, con);
                        cmd.Parameters.AddWithValue("@coll", comboBoxDCollector.Text);
                        cmd.Parameters.AddWithValue("@dserial", debt_Serial_NumberLabel1.Text);
                        cmd.Parameters.AddWithValue("@name", debtor_Full_NameTextBox.Text);
                        cmd.Parameters.AddWithValue("@user", usernamevalue);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                       // cmd.Parameters.AddWithValue("@collect2", FirstCollector);
                    }
                    this.Close();
                }
                catch (SqlException exception)
                {
                    MessageBox.Show(exception.Message.ToString(), "Error Message");
                    this.Close();
                }
            //}
            //else
            //{
            //    MessageBox.Show("Wrong password");
            //}
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void buttonDeleteD_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Debtor?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                string password = null;
                string pass = "select password from usernames where username='" + usernamevalue + "'";
                SqlConnection con = new SqlConnection(ConectionStr);
                string Delete = " delete from debtorsActive where debt_serial_number='" + debt_Serial_NumberLabel1.Text + "' and debt_id='"+ debt_Id1TextBox.Text +"'";
                SqlCommand cmd = new SqlCommand(pass, con);
                con.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    password = read.GetString(0);
                }
                con.Close();
                if (password == textBoxPass.Text)
                {
                    cmd = new SqlCommand(Delete, con);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message,"Error Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Wrong password","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

                }
            }
        }

        private void closeDateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            textBoxClDate.Text = closeDateDateTimePicker.Value.ToString();
        }

        private void disbursmentDateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            textBoxDbDate.Text = disbursmentDateDateTimePicker.Value.ToString();
        }

        private void finishedDateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {           
            textBoxFinDate.Text = finishedDateDateTimePicker.Value.ToString();
        }
    }
}
