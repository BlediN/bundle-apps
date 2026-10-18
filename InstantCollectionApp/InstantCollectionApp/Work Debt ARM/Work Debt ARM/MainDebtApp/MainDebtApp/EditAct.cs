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
    public partial class EditAct : Form
    {
        string personN = null;
        string actionType = null;
        string cntPerson = null;
        DateTime actDate = new DateTime();
        string comments = null;
        string reaction = null, otherdata = null;
        string ActID = null;
        int ID = 0;
        string user = null;
        string serial = null;
        string saveduser = null;
        double PTPamt = 0;
        string StatusColl = null;
        string conStr1 = "Data Source=debitor.c8kumftnoykl.eu-central-1.rds.amazonaws.com,1433;Initial Catalog=ForAmazon;User ID=debitordata;Password=Trsdmr92l161";
        public EditAct()
        {
            InitializeComponent();

            if (Application.OpenForms["Users"] != null)
            {
                user = (Application.OpenForms["Users"] as Users).userna;
                ActID = (Application.OpenForms["Form1"] as Form1).ActID;
                StatusColl = (Application.OpenForms["Form1"] as Form1).UserRights;
            }

            int.TryParse(ActID, out ID);
         
           
           // string conStr = "Data Source=debitor.c8kumftnoykl.eu-central-1.rds.amazonaws.com,1433;Initial Catalog=ForAmazon;User ID=debitordata;Password=Trsdmr92l161";
            String Select = "select Person_Full_Name, Action_Type,Action_Status,Action_Date,Comments,Reaction,OtherContact, debt_serial_number,user_id,promisedAmount From ActionsJan where ID=@id";
            SqlConnection con1 = new SqlConnection(conStr1);
            SqlCommand command1 = new SqlCommand(Select, con1);
            command1.Parameters.AddWithValue("@id", ID);

            con1.Open();
            using (SqlDataReader reader = command1.ExecuteReader())
            {
                while (reader.Read())
                {
                    personN = reader.GetString(0);
                    actionType = reader.GetString(1);
                    cntPerson = reader.GetString(2);
                    actDate = reader.GetDateTime(3);
                                     
                    if (reader.IsDBNull(4) == false)
                    {
                        comments = reader.GetString(4);
                    }

                    if (reader.IsDBNull(5) == false)
                    {
                        reaction = reader.GetString(5);
                    }
                    if (reader.IsDBNull(6) == false)
                    {
                        otherdata = reader.GetString(6);
                    }
                    serial = reader.GetString(7);
                    saveduser = reader.GetString(8);

                    if (reader.IsDBNull(9) == false)
                    {
                        PTPamt = reader.GetDouble(9);
                    }
                }
            }
            con1.Close();

            //linkLabelfname.Text = personN;
            //labelActID.Text = ActID;
            //comboBoxaction.Text = actionType;
            //comboBoxcontacted.Text = cntPerson;
            //comboBoxReaction.Text = reaction;
            //comboBoxContactOpt.Text = otherdata;
            //dateTimePicker1.Value = actDate.Date;
            //richTextBoxcoment.Text = comments;
            //textBoxPTPamt.Text = PTPamt.ToString();
            if (StatusColl!="admin" && StatusColl!="supervisor")
            {
                comboBoxcontacted.Enabled = false;
                comboBoxaction.Enabled = false;
                dateTimePicker1.Enabled = false;
                comboBoxContactOpt.Enabled = false;
                comboBoxReaction.Enabled = false;
                textBoxPTPamt.Enabled = false;
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            richTextBoxcoment.Text = richTextBoxcoment.Text.Replace(System.Environment.NewLine, " ");
            user = user.ToLower();
            saveduser = saveduser.ToLower();
            double.TryParse(textBoxPTPamt.Text, out PTPamt);
            if (comboBoxcontacted.Text != null && comboBoxcontacted.Text != "" && comboBoxContactOpt.Text != null && comboBoxContactOpt.Text != "")
            {
                if (user == saveduser || StatusColl.ToLower()=="admin" || StatusColl.ToLower() == "supervisor" || StatusColl.ToLower() == "agent")
                {
                    if (MessageBox.Show("Are you sure you want to edit this action?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                     //   DateTime dtpicker = new DateTime();
                      //  DateTime.TryParse(textBoxdatepicker.Text, out dtpicker);

                        String Query = " update ActionsJan set Action_Type=@actype, Action_Status=@acstatus,Action_Date=@acdate,Comments=@comment,User_Id=@userid,Last_Updated=@lastupd,OtherContact=@otherc,PromisedAmount=@PTPamt,Reaction=@reaction where ID=@id";
                     //   String query2 = "UPDATE dbo.DebtorsActive SET Latest_Person_Contacted=@contacted,Last_Act_type=@actiont, next_Action_Date=@datepicker,Last_Updated=@labaldata,User_Id=@masked,Latest_comment=@comment, reaction=@reaction,contactedvia=@contact, PTP_Amount=@PTP FROM DebtorsActive WHERE Debt_Serial_Number=@serialnr";
                        SqlConnection con = new SqlConnection(conStr1);
                        SqlCommand command = new SqlCommand(Query, con);
                    //    SqlCommand command2 = new SqlCommand(query2, con);
                        command.Parameters.AddWithValue("@actype", comboBoxaction.Text);
                        command.Parameters.AddWithValue("@acstatus", comboBoxcontacted.Text.ToString());
                        // command.Parameters.AddWithValue("@pyear", comboBoxYear.Text.ToString());
                        command.Parameters.AddWithValue("@acdate", dateTimePicker1.Value);
                        command.Parameters.AddWithValue("@comment", richTextBoxcoment.Text);
                        command.Parameters.AddWithValue("@lastupd", DateTime.Today);
                        command.Parameters.AddWithValue("@userid", user);
                        command.Parameters.AddWithValue("@id", ID);
                        command.Parameters.AddWithValue("@otherc", comboBoxContactOpt.Text);
                        command.Parameters.AddWithValue("@PTPamt", PTPamt);
                        command.Parameters.AddWithValue("@reaction", comboBoxReaction.Text);

                        //update Debtor
                        //command2.Parameters.AddWithValue("@serialnr", serial);
                        //command2.Parameters.AddWithValue("@contacted", comboBoxcontacted.Text.ToString());
                        //command2.Parameters.AddWithValue("@actiont", comboBoxaction.Text.ToString());
                        //command2.Parameters.AddWithValue("@datepicker", dateTimePicker1.Value);
                        //command2.Parameters.AddWithValue("@comment", richTextBoxcoment.Text);
                        //command2.Parameters.AddWithValue("@masked", user);
                        //command2.Parameters.AddWithValue("@labaldata", DateTime.Today.ToString("dd-MMM-yyyy"));
                        //command2.Parameters.AddWithValue("@reaction", comboBoxReaction.Text);
                        //command2.Parameters.AddWithValue("@contact", comboBoxContactOpt.Text);
                        //command2.Parameters.AddWithValue("@PTP", PTPamt);

                        try
                        {
                            con.Open();
                            command.ExecuteNonQuery();
                       //     command2.ExecuteNonQuery();
                            con.Close();
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
                    MessageBox.Show("You cannot edit an action that belongs to another user.\nPlease contact system administrator.", "Presmission denied", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                MessageBox.Show("Please select contacted person and the contact option.", "Fields left blank", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //textBoxdatepicker.Text = dateTimePicker1.Text;
        }

        private void EditAct_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'forAmazonDataSet.ContactedPerson' table. You can move, or remove it, as needed.
            this.contactedPersonTableAdapter.Fill(this.forAmazonDataSet.ContactedPerson);
            this.actionTypeTableAdapter.Fill(this.forAmazonDataSet.ActionType);
            
         //   this.reaction.Fill(this.forAmazonDataSet.ActionType);
            linkLabelfname.Text = personN;
            labelActID.Text = ActID;
            comboBoxaction.Text = actionType;
            comboBoxcontacted.Text = cntPerson;
            comboBoxReaction.Text = reaction;
            comboBoxContactOpt.Text = otherdata;
            dateTimePicker1.Value = actDate.Date;
            richTextBoxcoment.Text = comments;
            textBoxPTPamt.Text = PTPamt.ToString();

        }

        private void comboBoxaction_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            user = user.ToLower();
            saveduser = saveduser.ToLower();
            if (user == saveduser || StatusColl.ToLower() == "admin" || StatusColl.ToLower()=="supervisor" || StatusColl.ToLower() == "agent")
            {
                if (MessageBox.Show("Are you sure you want to delete this action?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection(conStr1);
                    string queryDelete = "delete from ActionsJan where ID=@id";
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
                MessageBox.Show("You cannot delete an action that belongs to another user.\nPlease contact system administrator.", "Presmission denied", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void comboBoxcontacted_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
