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
using System.Text.RegularExpressions;

namespace MainDebtApp
{
    public partial class NewActionForm : Form
    {
        public struct filledData
        {
            public string debtserialnr;
            public string debtorfullname;
            public string clientinstitution;
            public string actiontype;
            public string contactedperson;
            public string actiondate;
            public string infonr;
            public string comment;
            public string users;
            public string lastupdated;

        }
        filledData flld = new filledData();
        string AmznString = System.Configuration.ConfigurationManager.ConnectionStrings["InstantLogin"].ConnectionString;

        string ClientInstitution = null;
        string usernamevalue = null;
        string Dcollector = null;
        string LogColl = null, dCollector = null, currency = null;
        string lastpersonCnt = null;
        string ComboboxValue = null;
        string serialValue = null;      
        public NewActionForm()
        {        
            InitializeComponent();
           
            if (Application.OpenForms["Form1"] != null)
            {
                textBoxDbSerial.Text = (Application.OpenForms["Form1"] as Form1).textname;
                textBoxFname.Text = (Application.OpenForms["Form1"] as Form1).textname3;
                ClientInstitution = (Application.OpenForms["Form1"] as Form1).textname2;
                Dcollector = (Application.OpenForms["Form1"] as Form1).textname4;
                LogColl= (Application.OpenForms["Form1"] as Form1).LogColl;
                lastpersonCnt= (Application.OpenForms["Form1"] as Form1).LasctCP;
               // LogColl = (Application.OpenForms["Form1"] as Form1).LogColl;

            }
            if (Application.OpenForms["Users"] != null)
            {
                usernamevalue = (Application.OpenForms["Users"] as Users).userna;
            }
            //    public String userna { get { return this.comboBox1.Text.ToString(); } }
         //   string res1 = null, res2 = null, res3 = null;
            //  public List structures { get {return this.filledData; } }
            SqlConnection con = new SqlConnection(AmznString);
            string Query = "select Phone_1,Phone_2,Phone_3,phone_4 from Persons where Person_number=@dserial";
            string QueryColl = "select top(1) debt_collector,currency from debtorsactive where debt_serial_number='"+textBoxDbSerial.Text+"'";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("dserial", textBoxDbSerial.Text);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                for (int i = 0; i < 4; i++)
                {
                    if (reader.IsDBNull(i)==false)
                    {
                        if (reader.GetString(i)!="")
                        {
                            comboBoxContactOpt.Items.Add(reader.GetString(i));
                        }
                    }
                }
            }
            con.Close();
            cmd = new SqlCommand(QueryColl, con);
            con.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.IsDBNull(0)==false)
                {
                    dCollector = reader.GetString(0);
                    currency = reader.GetString(1);
                }
            }
            con.Close();   

            dateTimePicker1.Value = DateTime.Today;
           // labeluser.Text = usernamevalue;
        }
        public filledData fill { get { return this.flld; } }

       // public Label LbAction { get { return this.labeldbSerial; } }


        private void linkLabelfname_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void NewActionForm_Load(object sender, EventArgs e)
        {
            this.actionTypeTableAdapter.Fill(this.forAmazonDataSet.ActionType);
            string selectReaction = " select reaction_type from reactions";
            SqlConnection con = new SqlConnection(AmznString);
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = new SqlCommand(selectReaction, con);

            DataTable dt = new DataTable();
            adapt.Fill(dt);
            comboBoxReaction.DataSource = dt;
            comboBoxReaction.DisplayMember = "reaction_type";
            comboBoxReaction.SelectedItem = null;
        }

        private void comboBoxDB_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            textBoxComment.Text = textBoxComment.Text.Replace(System.Environment.NewLine, " ");
            if (comboBoxcontacted.Text != null && comboBoxcontacted.Text != "" && comboBoxContactOpt.Text != null && comboBoxContactOpt.Text != "")
            {
                ComboboxValue = comboBoxaction.Text;
                serialValue = textBoxDbSerial.Text;
                if (comboBoxReaction.Enabled == false || (comboBoxReaction.Enabled == true && comboBoxReaction.Text !=null && comboBoxReaction.Text!=""))
                {
                    
                        string numriRi = comboBoxContactOpt.Text;
                    numriRi = numriRi.TrimStart(new Char[] { '0' });
                    double PTPamt = 0;
                    double.TryParse(textBoxPTPamt.Text, out PTPamt);
                    DateTime dt = DateTime.Today;
                    DateTime td = dateTimePicker1.Value;
                    //  DateTime.TryParse(dateTimePicker1.Text, out td);
                    if (td >= dt)
                    {
                        DateTime dtpicker = dateTimePicker1.Value;

                        SqlConnection con = new SqlConnection(AmznString);

                        string query = "INSERT INTO ActionsJan(Debt_Serial_Number,Person_Full_Name,Client_Institution,Action_Type,Action_Status,Action_Date,OtherContact,Reaction,Comments,User_Id,Last_Updated,PromisedAmount) VALUES(@serialnr, @linklb, @clinstit, @actiont,@contacted,@datepicker0,@OtherContact,@reaction,@comment,@masked,@labaldata,@ptpamt)";
                        //ketu eshte errori i mos rreshistrimit te numrit te ri.
                        string countNo = "select count(person_number) from persons where (phone_1=@nr or phone_2=@nr or phone_3=@nr or phone_4=@nr) and person_number=@dserial";


                        //inserting new numbers in existing rows
                        string insertContact = "insert into persons (Client_institution,person_number,Person_full_name,First_name,Last_name,Relation,Source,Phone_1) select Client_institution  " +
                            ",person_number,Person_full_name,First_name,Last_name,@rel,'new action',@phone1 from Persons where person_number=@serial and Relation='" + comboBoxcontacted.Text + "'";
                        //string updateContacts4 = "update persons set phone_4=@selphone where debt_serial_number=@serial and phone_4='' or phone_4 is null and relation=@rel";
                        //string updateContacts3 = "update persons set phone_3=@selphone where debt_serial_number=@serial and phone_3='' or phone_3 is null and relation=@rel";
                        //string updateContacts2 = "update persons set phone_2=@selphone where debt_serial_number=@serial and phone_2='' or phone_2 is null and relation=@rel";
                        //string updateContacts1 = "update persons set phone_1=@selphone where debt_serial_number=@serial and phone_1='' or phone_1 is null and relation=@rel";

                        //SqlCommand PersonCMD = new SqlCommand(updateContacts4, con);
                        //con.Open();
                        //PersonCMD.ExecuteNonQuery();
                        //int numb = PersonCMD.ExecuteNonQuery();
                        //con.Close();
                        string toBeUpdated = "";
                        string readPersons = " select phone_1,Phone_2,phone_3,phone_4 from persons where person_number=@serial and relation=@rel";
                        SqlCommand CmdNO = new SqlCommand(readPersons, con);
                        CmdNO.Parameters.AddWithValue("@serial", textBoxDbSerial.Text);
                        string updatePersonContaced = "";
                        if (comboBoxcontacted.Text.ToLower() == "guarantor")
                        {
                            CmdNO.Parameters.AddWithValue("@rel", comboBoxcontacted.Text);
                            updatePersonContaced = "guarantor";
                        }

                        //else if (comboBoxcontacted.Text.ToLower() == "other")
                        //{
                        //    CmdNO.Parameters.AddWithValue("@rel", comboBoxcontacted.Text);
                        //    updatePersonContaced = "other";
                        //}

                        else
                        {
                            CmdNO.Parameters.AddWithValue("@rel", "debtor");
                            updatePersonContaced = "debtor";
                        }
                        // CmdNO.Parameters.AddWithValue("@rel")
                        con.Open();
                        SqlDataReader readNo = CmdNO.ExecuteReader();
                        bool Founded = false;
                        while (readNo.Read())
                        {
                            if (Founded == false)
                            {
                                if (readNo.IsDBNull(0) == true || readNo.GetString(0) == "")
                                {
                                    toBeUpdated = " update top(1) persons set phone_1='" + numriRi + "' where (phone_1 is null or phone_1='') and person_number=@serial  and relation='" + updatePersonContaced + "' ";
                                    Founded = true;
                                }
                                else if (readNo.IsDBNull(1) == true || readNo.GetString(1) == "")
                                {
                                    toBeUpdated = " update top(1) persons set phone_2='" + numriRi + "' where (phone_2 is null or phone_2='') and person_number=@serial and  relation='" + updatePersonContaced + "' ";
                                    Founded = true;
                                }
                                else if (readNo.IsDBNull(2) == true || readNo.GetString(2) == "")
                                {
                                    toBeUpdated = " update top(1) persons set phone_3='" + numriRi + "' where (phone_3 is null or phone_3='') and person_number=@serial and  relation='" + updatePersonContaced + "' ";
                                    Founded = true;
                                }
                                else if (readNo.IsDBNull(3) == true || readNo.GetString(3) == "")
                                {
                                    toBeUpdated = " update top(1) persons set phone_4='" + numriRi + "' where (phone_4 is null or phone_4='') and person_number=@serial and  relation='" + updatePersonContaced + "' ";
                                    Founded = true;
                                }

                                else
                                {
                                    toBeUpdated = "insert top(1) into persons (Client_institution,person_number,Person_full_name,First_name,Last_name,Relation,Source,Phone_1) select Client_institution  " +
                                ",person_number,Person_full_name,First_name,Last_name,'" + updatePersonContaced + "','new action','" + numriRi + "' from Persons where person_number=@serial and Relation='" + updatePersonContaced + "'";
                                }
                            }
                        }
                        con.Close();

                        if (comboBoxaction.Text.ToLower() == "phone call" || comboBoxaction.Text.ToLower() == "suggest sms" || comboBoxaction.Text.ToLower() == "notification sms")
                        {
                           
                            int Nr = 0;
                            SqlCommand cmdInser = new SqlCommand(countNo, con);
                            cmdInser.Parameters.AddWithValue("@nr", numriRi);
                            cmdInser.Parameters.AddWithValue("@dserial", textBoxDbSerial.Text);
                            con.Open();
                            SqlDataReader read = cmdInser.ExecuteReader();

                            while (read.Read())
                            {
                                Nr = read.GetInt32(0);
                            }
                            con.Close();

                            if (Nr <= 0)
                            {

                                SqlCommand updates = new SqlCommand(toBeUpdated, con);
                                updates.Parameters.AddWithValue("@serial", textBoxDbSerial.Text);
                                try
                                {
                                    con.Open();
                                    updates.ExecuteNonQuery();
                                    con.Close();
                                }
                                catch (SqlException ex)
                                {
                                    MessageBox.Show(ex.Message.ToString());

                                }


                            }
                        }

                        //end of number add


                        SqlCommand command = new SqlCommand(query, con);

                        string dateformat2 = "yyyy-MM-dd";
                        dateTimePicker1.CustomFormat = dateformat2;
                        // command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@serialnr", textBoxDbSerial.Text);
                        command.Parameters.AddWithValue("@linklb", textBoxFname.Text);
                        command.Parameters.AddWithValue("@clinstit", ClientInstitution);
                        command.Parameters.AddWithValue("@actiont", comboBoxaction.Text.ToString());
                        command.Parameters.AddWithValue("@contacted", comboBoxcontacted.Text.ToString());
                        command.Parameters.AddWithValue("@datepicker0", dateTimePicker1.Value);
                        command.Parameters.AddWithValue("@OtherContact", numriRi);
                        command.Parameters.AddWithValue("@reaction", comboBoxReaction.Text);
                        command.Parameters.AddWithValue("@comment", textBoxComment.Text);
                        command.Parameters.AddWithValue("@masked", usernamevalue);
                        command.Parameters.AddWithValue("@labaldata", DateTime.Today.ToString(dateformat2));
                        command.Parameters.AddWithValue("@ptpamt", PTPamt);

                        try
                        {
                            con.Open();
                            command.ExecuteNonQuery();
                            con.Close();

                            //update DebtorsActive
                            if (lastpersonCnt.ToLower() == "")
                            {
                                string query2 = "UPDATE dbo.DebtorsActive SET Latest_Person_Contacted=@contacted,Last_Act_type=@actiont, next_Action_Date=@datepicker,Last_Updated=@labaldata,User_Id=@masked,Latest_comment=@comment, reaction=@reaction,contactedvia=@contact,PTP_Amount=@PTP FROM DebtorsActive WHERE Debt_Serial_Number=@serialnr";
                                //   command2.Parameters.AddWithValue("@id", id);
                                SqlCommand command2 = new SqlCommand(query2, con);
                                command2.Parameters.AddWithValue("@serialnr", textBoxDbSerial.Text);
                                command2.Parameters.AddWithValue("@contacted", comboBoxcontacted.Text.ToString());
                                command2.Parameters.AddWithValue("@actiont", comboBoxaction.Text.ToString());
                                command2.Parameters.AddWithValue("@datepicker", dateTimePicker1.Value);
                                command2.Parameters.AddWithValue("@comment", textBoxComment.Text);
                                command2.Parameters.AddWithValue("@masked", usernamevalue);
                                command2.Parameters.AddWithValue("@labaldata", DateTime.Today.ToString("dd-MMM-yyyy"));
                                command2.Parameters.AddWithValue("@reaction", comboBoxReaction.Text);
                                command2.Parameters.AddWithValue("@contact", numriRi);
                                command2.Parameters.AddWithValue("@PTP", PTPamt);

                                con.Open();
                                command2.ExecuteNonQuery();
                                con.Close();
                            }

                            else if (lastpersonCnt.ToLower() != "" && lastpersonCnt.ToLower() != "no contact")
                            {
                                if (comboBoxcontacted.Text.ToLower() != "no contact")
                                {
                                    if (comboBoxaction.Text.ToLower() == "phone call" || comboBoxaction.Text.ToLower() == "notification sms" || comboBoxaction.Text.ToLower() == "field search" || comboBoxaction.Text.ToLower() == "letter delivered" || comboBoxaction.Text.ToLower() == "office meeting" || comboBoxaction.Text.ToLower() == "skip trace" || comboBoxaction.Text.ToLower() == "suggest sms")
                                    {

                                        string query2 = "UPDATE dbo.DebtorsActive SET Latest_Person_Contacted=@contacted,Last_Act_type=@actiont, next_Action_Date=@datepicker,Last_Updated=@labaldata,User_Id=@masked,Latest_comment=@comment, reaction=@reaction,contactedvia=@contact,PTP_Amount=@PTP FROM DebtorsActive WHERE Debt_Serial_Number=@serialnr";
                                        //   command2.Parameters.AddWithValue("@id", id);
                                        SqlCommand command2 = new SqlCommand(query2, con);
                                        command2.Parameters.AddWithValue("@serialnr", textBoxDbSerial.Text);
                                        command2.Parameters.AddWithValue("@contacted", comboBoxcontacted.Text.ToString());
                                        command2.Parameters.AddWithValue("@actiont", comboBoxaction.Text.ToString());
                                        command2.Parameters.AddWithValue("@datepicker", dateTimePicker1.Value);
                                        command2.Parameters.AddWithValue("@comment", textBoxComment.Text);
                                        command2.Parameters.AddWithValue("@masked", usernamevalue);
                                        command2.Parameters.AddWithValue("@labaldata", DateTime.Today.ToString("dd-MMM-yyyy"));
                                        command2.Parameters.AddWithValue("@reaction", comboBoxReaction.Text);
                                        command2.Parameters.AddWithValue("@contact", numriRi);
                                        command2.Parameters.AddWithValue("@PTP", PTPamt);

                                        con.Open();
                                        command2.ExecuteNonQuery();
                                        con.Close();
                                    }
                                }
                                else if (comboBoxcontacted.Text.ToLower() == "no contact")
                                {
                                    string verify = "select dbo.FindContactStatus('" + textBoxDbSerial.Text + "')";
                                    SqlCommand command1 = new SqlCommand(verify, con);
                                    con.Open();
                                    SqlDataReader reader = command1.ExecuteReader();
                                    string value = "";
                                    while (reader.Read())
                                    {
                                        value = reader.GetString(0);
                                    }
                                    con.Close();

                                    if (value.ToLower() == "no")
                                    {

                                        string query2 = "UPDATE dbo.DebtorsActive SET Latest_Person_Contacted=@contacted,Last_Act_type=@actiont, next_Action_Date=@datepicker,Last_Updated=@labaldata,User_Id=@masked,Latest_comment=@comment, contactedvia=@contact FROM DebtorsActive WHERE Debt_Serial_Number=@serialnr";
                                        //   command2.Parameters.AddWithValue("@id", id);
                                        SqlCommand command2 = new SqlCommand(query2, con);
                                        command2.Parameters.AddWithValue("@serialnr", textBoxDbSerial.Text);
                                        command2.Parameters.AddWithValue("@contacted", comboBoxcontacted.Text.ToString());
                                        command2.Parameters.AddWithValue("@actiont", comboBoxaction.Text.ToString());
                                        command2.Parameters.AddWithValue("@datepicker", dateTimePicker1.Value);
                                        command2.Parameters.AddWithValue("@comment", textBoxComment.Text);
                                        command2.Parameters.AddWithValue("@masked", usernamevalue);
                                        command2.Parameters.AddWithValue("@labaldata", DateTime.Today.ToString("dd-MMM-yyyy"));
                                        //command2.Parameters.AddWithValue("@reaction", comboBoxReaction.Text);
                                        command2.Parameters.AddWithValue("@contact", numriRi);
                                        // command2.Parameters.AddWithValue("@PTP", PTPamt);
                                        con.Open();
                                        command2.ExecuteNonQuery();
                                        con.Close();
                                    }

                                }


                            }

                            else if (lastpersonCnt.ToLower() == "no contact")
                            {
                                if (comboBoxaction.Text.ToLower() == "suggest letter" || comboBoxaction.Text.ToLower() == "suggest field" || comboBoxaction.Text.ToLower() == "letter returned" || comboBoxaction.Text.ToLower() == "notification email")
                                {
                                }

                                else
                                {
                                    string query2 = "UPDATE dbo.DebtorsActive SET Latest_Person_Contacted=@contacted,Last_Act_type=@actiont, next_Action_Date=@datepicker,Last_Updated=@labaldata,User_Id=@masked,Latest_comment=@comment, reaction=@reaction,contactedvia=@contact,PTP_Amount=@PTP FROM DebtorsActive WHERE Debt_Serial_Number=@serialnr";
                                    //   command2.Parameters.AddWithValue("@id", id);
                                    SqlCommand command2 = new SqlCommand(query2, con);
                                    command2.Parameters.AddWithValue("@serialnr", textBoxDbSerial.Text);
                                    command2.Parameters.AddWithValue("@contacted", comboBoxcontacted.Text.ToString());
                                    command2.Parameters.AddWithValue("@actiont", comboBoxaction.Text.ToString());
                                    command2.Parameters.AddWithValue("@datepicker", dateTimePicker1.Value);
                                    command2.Parameters.AddWithValue("@comment", textBoxComment.Text);
                                    command2.Parameters.AddWithValue("@masked", usernamevalue);
                                    command2.Parameters.AddWithValue("@labaldata", DateTime.Today.ToString("dd-MMM-yyyy"));
                                    command2.Parameters.AddWithValue("@reaction", comboBoxReaction.Text);
                                    command2.Parameters.AddWithValue("@contact", numriRi);
                                    command2.Parameters.AddWithValue("@PTP", PTPamt);

                                    con.Open();
                                    command2.ExecuteNonQuery();
                                    con.Close();
                                }

                            }
                            // End of update

                            if (Dcollector.ToLower() != LogColl.ToLower())
                            {
                                command.Parameters.Clear();

                                string insertSMS = "insert into Notifications(serial,name,type,userid,collector,datetime)" +
                                    "values(@dserial,@name,'Action',@user,@coll,GetDate())";

                                command = new SqlCommand(insertSMS, con);
                                command.Parameters.AddWithValue("@dserial", textBoxDbSerial.Text);
                                command.Parameters.AddWithValue("@name", textBoxFname.Text);
                                command.Parameters.AddWithValue("@user", usernamevalue);
                                command.Parameters.AddWithValue("@coll", Dcollector);

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


                        }
                        catch (SqlException exception)
                        {
                            MessageBox.Show(exception.Message.ToString(), "Error Message");
                            // this.Close();
                        }


                        this.Close();
                    }
                    else
                    {                                     
                        MessageBox.Show("Next action date cannot be in the past time", "Date problem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                }
                else
                {
                    MessageBox.Show("Please select a reaction option", "Reaction left blank", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                ComboboxValue = ComboboxValue.ToLower();
                LogColl = LogColl.ToLower();
                if (ComboboxValue.ToLower() == "suggest field" && LogColl.ToLower()==dCollector.ToLower() && currency.ToLower()!="eur")
                {
                    string updateCollector = "update debtorsactive set debt_collector='mariglen cengu' where debt_serial_number='"+serialValue+"'";
                    string insertNofication = "insert into Notifications (serial,name,type,userid,collector,datetime) values (@serial,@name,@type,@userid,@collector,getdate()) "+
                        " insert into Notifications (serial,name,type,userid,collector,datetime) values (@serial,@name,'marrje rasti',@userid,'Mariglen Cengu',getdate())";

                    SqlConnection con = new SqlConnection(AmznString);
                    SqlCommand cmd = new SqlCommand(updateCollector, con);
                    

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    cmd = new SqlCommand(insertNofication, con);
                    cmd.Parameters.AddWithValue("@serial", serialValue);
                    cmd.Parameters.AddWithValue("@type", "kalim rasti");
                    cmd.Parameters.AddWithValue("@collector", LogColl);
                    cmd.Parameters.AddWithValue("@userid", usernamevalue);
                    cmd.Parameters.AddWithValue("@name", serialValue);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }

                else  if (ComboboxValue.ToLower() == "suggest field" && LogColl.ToLower() == dCollector.ToLower() && currency.ToLower() == "eur")
                {
                    string updateCollector = "update debtorsactive set debt_collector='Urim Hyseni' where debt_serial_number='" + serialValue + "'";
                    string insertNofication = "insert into Notifications (serial,name,type,userid,collector,datetime) values (@serial,@name,@type,@userid,@collector,getdate()) " +
                        " insert into Notifications (serial,name,type,userid,collector,datetime) values (@serial,@name,'marrje rasti',@userid,'Mariglen Cengu',getdate())";

                    SqlConnection con = new SqlConnection(AmznString);
                    SqlCommand cmd = new SqlCommand(updateCollector, con);


                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    cmd = new SqlCommand(insertNofication, con);
                    cmd.Parameters.AddWithValue("@serial", serialValue);
                    cmd.Parameters.AddWithValue("@type", "kalim rasti");
                    cmd.Parameters.AddWithValue("@collector", LogColl);
                    cmd.Parameters.AddWithValue("@userid", usernamevalue);
                    cmd.Parameters.AddWithValue("@name", serialValue);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }


            }
            else
            {
                MessageBox.Show("Please select contacted person and the contact option.", "Fields left blank", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void ComboBoxaction_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxReaction.Enabled = true;
            textBoxPTPamt.ReadOnly = false;
            comboBoxContactOpt.Text = null;
            
            if (comboBoxaction.Text.ToLower() == "letter sent" || comboBoxaction.Text.ToLower() == "letter returned" || comboBoxaction.Text.ToLower() == "suggest letter" || comboBoxaction.Text.ToLower() == "suggest sms" || comboBoxaction.Text.ToLower() == "suggest field" || comboBoxcontacted.Text.ToLower() == "no contact" || comboBoxcontacted.Text.ToLower() == "no answer")
            {
                comboBoxReaction.Text =null;
                textBoxPTPamt.Text = null;
                comboBoxReaction.Enabled = false;
                textBoxPTPamt.ReadOnly = true;
            }

            if (comboBoxaction.Text.ToLower()=="letter sent")
            {

            }
            comboBoxContactOpt.Items.Clear();
       

          //  string result1 = null, result2 = null, result3 = null ;
            Regex reg = new Regex("letter");
            Regex reg2 = new Regex("field");
            Match m = reg.Match(comboBoxaction.Text.ToLower());
            Match m2 = reg2.Match(comboBoxaction.Text.ToString().ToLower());

            if (m.Success || m2.Success)
            {         
                SqlConnection con = new SqlConnection(AmznString);
                string Query = "select District,Address from Persons where Person_number=@dserial";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("dserial", textBoxDbSerial.Text);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //result1 = reader.GetString(0);
                    //result2 = reader.GetString(1);
                    //result1 = result1 + ", " + result2;
                    //if ((result1 != "" && result1 != null))
                    //{
                    //    comboBoxContactOpt.Items.Add(result1);
                    //}


                    if (reader.IsDBNull(0) == false && reader.IsDBNull(1)==false)
                    {
                        if (reader.GetString(1) != "")
                        {
                            comboBoxContactOpt.Items.Add(reader.GetString(0)+", "+reader.GetString(1));
                        }
                    }                   
                }
                con.Close();
            }
            else if (comboBoxaction.Text.ToLower()=="notification email")
            {
                SqlConnection con = new SqlConnection(AmznString);
                string Query = "select email from Persons where Person_number=@dserial";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("dserial", textBoxDbSerial.Text);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {                
                        if (reader.IsDBNull(0) == false)
                        {
                            if (reader.GetString(0) != "")
                            {
                                comboBoxContactOpt.Items.Add(reader.GetString(0));
                            }
                        }                 
                }
                con.Close();
            }

            else
            {
                SqlConnection con = new SqlConnection(AmznString);
                string Query = "select Phone_1,Phone_2,Phone_3,Phone_4 from Persons where Person_number=@dserial";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("dserial", textBoxDbSerial.Text);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
              
                    for (int i = 0; i <= 3; i++)
                    {
                        if (reader.IsDBNull(i) == false)
                        {
                            if (reader.GetString(i) != "")
                            {
                                comboBoxContactOpt.Items.Add(reader.GetString(i));
                            }
                        }
                    }
                }
                con.Close();
            }
        }

        private void TextBoxToolTip(object sender, EventArgs e)
        {
            ToolTip texttool = new ToolTip();
            texttool.SetToolTip(comboBoxContactOpt, comboBoxContactOpt.Text);
        }
        private void ComboBoxSelection()
        {
            if (comboBoxcontacted.SelectedItem.ToString()=="No Contact")
            {
                comboBoxContactOpt.Text = "NA";
                comboBoxReaction.Text = "NA";
                textBoxComment.Text = "Nuk mund te kontaktohet";
            }
            else if (comboBoxcontacted.SelectedItem.ToString() =="No Answer")
            {
                comboBoxaction.Text = "Phone Call";
                comboBoxReaction.Text = "NA";
                textBoxComment.Text = "Nuk pergjigjet";
            }
        }

        private void comboBoxcontacted_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxReaction.Enabled = true;
            textBoxPTPamt.ReadOnly = false;
            if (comboBoxcontacted.Text.ToLower() == "no contact")
            {
               
                if (MessageBox.Show("Are you sure you want to save it as NO CONTACT?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    comboBoxcontacted.Text = null;
                }
            }

            if (comboBoxcontacted.Text.ToLower() == "no contact" || comboBoxcontacted.Text.ToLower() == "no answer")
            {
                comboBoxReaction.Text = null;
                textBoxPTPamt.Text = null;
                comboBoxReaction.Enabled = false;
                textBoxPTPamt.ReadOnly = true;               
            }
        }

        private void comboBoxContactOpt_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void comboboxTextPress(object sender, KeyPressEventArgs e)
        {
            if (comboBoxaction.Text.ToLower() == "phone call" || comboBoxaction.Text.ToLower() == "notification sms" || comboBoxaction.Text.ToLower() == "office meeting" || comboBoxaction.Text.ToLower() == "suggest sms")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }


        }

        private void textboxCommentKeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void textBoxComment_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
