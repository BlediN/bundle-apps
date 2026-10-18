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
using System.IO;
using System.Data.OleDb;


namespace MainDebtApp
{
    public partial class Admin : Form
    {
        //string LogedCollector = "";
        string portovalue = "";
        int verification = 0;
        string usernamevalue = null;
        DataGridView dv = new DataGridView();
        DataGridView dvpayments = new DataGridView();
        string ConectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["InstantLogin"].ConnectionString;
        private string Excel03ConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        private string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        
        public Admin()
        {
            InitializeComponent();
            dateTimePickerOrari.Value = DateTime.Today;
            if (Application.OpenForms["Form1"] != null)
            {
                //    textBoxDbSerial.Text = (Application.OpenForms["Form1"] as Form1).textname;
                dv.DataSource = (Application.OpenForms["Form1"] as Form1).DGV.DataSource;
                dvpayments.DataSource = (Application.OpenForms["Form1"] as Form1).DGVpayments.DataSource;

            }
            dataGridViewCases.DataSource = dv.DataSource;
            dataGridViewPaymentUpdate.DataSource = dvpayments.DataSource;
            if (Application.OpenForms["Users"] != null)
            {
                usernamevalue = (Application.OpenForms["Users"] as Users).userna;
            }
        }

        private void Admin_Load(object sender, EventArgs e)
        {
         
            this.debtTypeTableAdapter.Fill(this.forAmazonDataSet.DebtType);
            // TODO: This line of code loads data into the 'forAmazonDataSet.Currency' table. You can move, or remove it, as needed.
            this.currencyTableAdapter.Fill(this.forAmazonDataSet.Currency);
            // TODO: This line of code loads data into the 'forAmazonDataSet.ClientInstitution' table. You can move, or remove it, as needed.
            this.clientInstitutionTableAdapter.Fill(this.forAmazonDataSet.ClientInstitution);
            // TODO: This line of code loads data into the 'forAmazonDataSet.PortofolioStatus' table. You can move, or remove it, as needed.
            this.portofolioStatusTableAdapter.Fill(this.forAmazonDataSet.PortofolioStatus);
            // TODO: This line of code loads data into the 'forAmazonDataSet.Portofolio' table. You can move, or remove it, as needed.
            this.portofolioTableAdapter.Fill(this.forAmazonDataSet.Portofolio);
            // TODO: This line of code loads data into the 'forAmazonDataSet.Usernames' table. You can move, or remove it, as needed.
            this.usernamesTableAdapter.Fill(this.forAmazonDataSet.Usernames);
            comboBoxStatusUpd.Text = null;

        }

        private void listBox1_SelectedDoubleClick(object sender, EventArgs e)
        {
            listBox2.Items.Add(listBox1.SelectedValue.ToString());
        }

        private void ToCsV(DataGridView dGV, string filename)
        {
            int x = dataGridViewCases.RowCount;
            switch (tabControl1.SelectedIndex)
            {
                case 3:
                    x = dataGridViewCases.Rows.Count;
                    break;
            //    case 1:
            //        x = dataGridViewAct.Rows.Count;
            //        break;
            //    case 2:
            //        x = paymentsJanDataGridView.Rows.Count;
            //        break;
                case 0:
                    x = dataGridViewProcess.Rows.Count;
                    break;
            }
            string stOutput = "";
            // Export titles:
            string sHeaders = "";

            for (int j = 0; j < dGV.Columns.Count - 1; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
            stOutput += sHeaders + "\r\n";
            // Export data.

            for (int i = 0; i < x; i++)
            {
                string stLine = "";
                for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
                stOutput += stLine + "\r\n";
            }
            Encoding utf16 = Encoding.GetEncoding(1254);
            byte[] output = utf16.GetBytes(stOutput);
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length); //write the encoded file
            bw.Flush();
            bw.Close();
            fs.Close();
        }


        private void listBox2_SelectedDoubleClick(object sender, EventArgs e)
        {
            if (listBox2.Items.Count > 0)
            {
                int index = listBox2.SelectedIndex;
                listBox2.Items.RemoveAt(index);
            }
            else
            {
                MessageBox.Show("No more items to delete", "Empty List", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Export(object sender,EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Exported_Change_"+DateTime.Today.ToString("dd.MM.yyyy")+".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ToCsV(dataGridViewCases, sfd.FileName);
                // Here dataGridview1 is your grid view name
            }
        }
        private void buttonShuffle_Click(object sender, EventArgs e)
        {
            Export(sender, e);

            ListBox.ObjectCollection list = listBox2.Items;
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                string value = (string)list[k];
                list[k] = list[n];
                list[n] = value;
            }
            if (listBox2.Items.Count > 0)
            {
                ReorderGrid();
                int listindex = 0;
                int listitems = listBox2.Items.Count;
                for (int i = 0; i <= dataGridViewCases.RowCount - 1; i++)
                {
                    if (listindex < listitems)
                    {
                        dataGridViewCases.Rows[i].Cells[debtCollectorDataGridViewTextBoxColumn.Index].Value = listBox2.Items[listindex].ToString();
                    }
                    else
                    {
                        listindex = 0;
                        dataGridViewCases.Rows[i].Cells[debtCollectorDataGridViewTextBoxColumn.Index].Value = listBox2.Items[listindex].ToString();
                    }
                    listindex++;
                    verification = i;
                }
            }
            else
            {
                MessageBox.Show("Please select at least one collector to continue", "Empty List", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ReorderGrid()
        {
            dataGridViewCases.Sort(totalOutstandingDataGridViewTextBoxColumn, ListSortDirection.Descending);
        }

        private void buttonCollectors_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Count > 0)
            {
                if (verification == dataGridViewCases.RowCount - 1)
                {
                    ReorderGrid();
                    SqlConnection conx = new SqlConnection(ConectionStr);
                    String UpdateQuery = "update DebtorsActive set debt_collector=@coll,reassigned=getdate() where debt_serial_number=@dserial ";
                    SqlCommand command = new SqlCommand(UpdateQuery, conx);

                    if (MessageBox.Show("Are you sure you want to edit Debt Collector list?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        conx.Open();
                        for (int j = 0; j < dataGridViewCases.Rows.Count; j++)
                        {
                            command.Parameters.AddWithValue("@coll", dataGridViewCases.Rows[j].Cells[debtCollectorDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@date", DateTime.Today);
                         //   command.Parameters.AddWithValue("@user", usernamevalue);
                            command.Parameters.AddWithValue("@dserial", dataGridViewCases.Rows[j].Cells[debtSerialNumberDataGridViewTextBoxColumn.Index].Value);
                            try
                            {
                                command.ExecuteNonQuery();
                            }
                            catch (SqlException exception)
                            {
                                MessageBox.Show(exception.Message.ToString(), "Error Message");
                            }
                            command.Parameters.Clear();
                        }
                        conx.Close();
                        MessageBox.Show("Succesfully updated " + dataGridViewCases.Rows.Count + " debtors", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Error on the debts table. One of the Debt_Collector cells is not set.\nPlease check and try again", "List Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select at least one collector to continue", "Empty List", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBoxPortofolio_SelectedDoubleClick(object sender, EventArgs e)
        {
            textBoxPname.Text = listBoxPortofolio.SelectedValue.ToString();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            string Entry = null;
            String Select = "select Password From Usernames where Username=@user";
            SqlConnection con1 = new SqlConnection(ConectionStr);
            SqlCommand command1 = new SqlCommand(Select, con1);
            command1.Parameters.AddWithValue("@user", "admin");

            con1.Open();
            SqlDataReader reader = command1.ExecuteReader();
            while (reader.Read())
            {
                Entry = reader.GetString(0);
            }
            con1.Close();

            if (Entry == textBoxPass.Text)
            {
                labelAdminPass.ForeColor = System.Drawing.Color.Green;
                labelAdminPass.Text = "√";

                string updatePortofolio = "update portofolio set portofolio=@port,client=@cl, last_updated=@date,status=@status,user_id=@users where portofolio=@portfolio";
                SqlConnection con = new SqlConnection(ConectionStr);
                SqlCommand cmd = new SqlCommand(updatePortofolio, con);
                cmd.Parameters.AddWithValue("port", textBoxPname.Text);
                cmd.Parameters.AddWithValue("cl", comboBox1.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@date", DateTime.Today);
                cmd.Parameters.AddWithValue("@status", comboBoxPStatus.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@users", usernamevalue);
                cmd.Parameters.AddWithValue("@portfolio", listBoxPortofolio.SelectedValue.ToString());
                con.Open();
                if (MessageBox.Show("Are you sure you want to edit Portofolio data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                        // this.Close();
                    }
                    catch (SqlException exception)
                    {
                        MessageBox.Show(exception.Message.ToString(), "Error Message");
                    }
                }
                con.Close();
            }
            else
            {
                labelAdminPass.ForeColor = System.Drawing.Color.Red;
                labelAdminPass.Text = "Wrong password";
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            string Entry = null;
            String Select = "select Password From Usernames where Username=@user";
            SqlConnection con1 = new SqlConnection(ConectionStr);
            SqlCommand command1 = new SqlCommand(Select, con1);
            command1.Parameters.AddWithValue("@user", "admin");

            con1.Open();
            SqlDataReader reader = command1.ExecuteReader();
                while (reader.Read())
                {    
                        Entry = reader.GetString(0);
                }
            con1.Close();

            if (Entry == textBoxPass.Text)
            {
                labelAdminPass.ForeColor = System.Drawing.Color.Green;
                labelAdminPass.Text = "√";
                string updateDebts = "update debtorsActive set portfolio=@port,client=@cl, last_updated=@date,portfolio_status=@status,user_id=@users where portfolio=@portfolio";
                SqlConnection con = new SqlConnection(ConectionStr);
                SqlCommand cmd = new SqlCommand(updateDebts, con);
                cmd.Parameters.AddWithValue("port", textBoxPname.Text);
                cmd.Parameters.AddWithValue("cl", comboBox1.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@date", DateTime.Today);
                cmd.Parameters.AddWithValue("@status", comboBoxPStatus.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@users", usernamevalue);
                cmd.Parameters.AddWithValue("@portfolio", listBoxPortofolio.SelectedValue.ToString());
                con.Open();
                if (MessageBox.Show("Are you sure you want to edit Debts data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                        // this.Close();
                    }
                    catch (SqlException exception)
                    {
                        MessageBox.Show(exception.Message.ToString(), "Error Message");
                    }
                }
                con.Close();
            }
            else
            {
                labelAdminPass.ForeColor = System.Drawing.Color.Red;
                labelAdminPass.Text = "Wrong password";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int caseNr = 0;
            int.TryParse(textBoxCaseNr.Text, out caseNr);
            int ID = 0;
            string countPoirtflio = "select count(id) from Portofolio";
            SqlConnection con1 = new SqlConnection(ConectionStr);
            SqlCommand command1 = new SqlCommand(countPoirtflio, con1);

            con1.Open();
            SqlDataReader reader = command1.ExecuteReader();
            while (reader.Read())
            {
                ID = reader.GetInt32(0);
            }
            con1.Close();

            string insertPortfolio = "insert into portofolio(id, portofolio,client,status,dateCreated,user_id,last_updated,cases) values (@id,@porto,@cl,@status,@date,@user,@lastdate,@case)";
            command1 = new SqlCommand(insertPortfolio, con1);
            command1.Parameters.AddWithValue("porto", textBoxPorto.Text);
            command1.Parameters.AddWithValue("id", ID);
            command1.Parameters.AddWithValue("cl", comboBoxNewCl.SelectedValue.ToString());
            command1.Parameters.AddWithValue("status", "active");
            command1.Parameters.AddWithValue("date", DateTime.Today);
            command1.Parameters.AddWithValue("lastdate", DateTime.Today);
            command1.Parameters.AddWithValue("user", usernamevalue);
            command1.Parameters.AddWithValue("case", caseNr);
            con1.Open();

            if (MessageBox.Show("Are you sure you want to save this portolio?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                try
                {
                    command1.ExecuteNonQuery();
                    // this.Close();
                }
                catch (SqlException exception)
                {
                    MessageBox.Show(exception.Message.ToString(), "Error Message");
                }
                con1.Close();
            }        
        }

        private void comboBoxPorto_SelectedIndexChanged(object sender, EventArgs e)
        {
        
            if (this.comboBoxPorto.SelectedValue != null)
            {
                double BalDev = 0;
                decimal BalAvg = 0.0M;
                double AgeDev = 0;
                decimal AgeAvg = 0.0m;
                double RecDev = 0;
                decimal RecAvg = 0.0m;
                double FpdDev = 0;
                decimal FpdAvg = 0.0m;
                portovalue = this.comboBoxPorto.SelectedValue.ToString();
                SqlConnection con = new SqlConnection(ConectionStr);
                SqlCommand cmd = new SqlCommand("StatisticalProc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@portfolios", portovalue);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    if (reader.IsDBNull(0)==false)
                    {
                        BalDev = reader.GetDouble(0);
                    }
                    if (reader.IsDBNull(1) == false)
                    {
                        BalAvg = reader.GetDecimal(1);
                    }
                    if (reader.IsDBNull(2) == false)
                    {
                        AgeDev = reader.GetDouble(2);
                    }
                    if (reader.IsDBNull(3) == false)
                    {
                        //    AgeAvg= reader.GetDecimal(3);
                    }
                    if (reader.IsDBNull(4) == false)
                    {
                        RecDev = reader.GetDouble(4);
                    }
                    if (reader.IsDBNull(5) == false)
                    {
                        RecAvg = reader.GetDecimal(5);
                    }
                    if (reader.IsDBNull(6) == false)
                    {
                        FpdDev = reader.GetDouble(6);
                    }
                    if (reader.IsDBNull(7) == false)
                    {
                        FpdAvg = reader.GetDecimal(7);
                    }                                                                                                                                        
                }
                con.Close();
                textBoxStdBal.Text = BalDev.ToString();
                textBoxAvgBal.Text = BalAvg.ToString();
                textBoxStdAge.Text = AgeDev.ToString();
                textBoxAvgAge.Text = AgeAvg.ToString();
                textBoxStdRe.Text = RecDev.ToString();
                textBoxAvgRe.Text = RecAvg.ToString();
                textBoxStdFpd.Text = FpdDev.ToString();
                textBoxAvgFpd.Text = FpdAvg.ToString();

              
                //DataTable dt = new DataTable();
                // List<string> RowsReturnet = new List<string>();           
                string Search1 = "SELECT * from DebtorsActive where portfolio='"+portovalue+"'";
                SqlDataAdapter adapt = new SqlDataAdapter();
                adapt.SelectCommand = new SqlCommand(Search1, con);               
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                dataGridViewRisk.DataSource = dt;

            }
        }

        private void ButtonSetRisk_Click(object sender, EventArgs e)
        {
            if (portovalue != "" && portovalue != null)
            {
                float balW = 0;
                float recw = 0;
                float agew = 0;
                float RestrW = 0;
                float ColateralW = 0;
                float.TryParse(textBoxbW.Text, out balW);
                float.TryParse(textBoxRec.Text, out recw);
                float.TryParse(textBoxAge.Text, out agew);
                float.TryParse(textBoxRestruct.Text, out RestrW);
                float.TryParse(textBoxColateral.Text, out ColateralW);

                SqlConnection con = new SqlConnection(ConectionStr);
                SqlCommand cmd = new SqlCommand("SetRiskValue", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@balw", balW);
                cmd.Parameters.AddWithValue("@recw", recw);
                cmd.Parameters.AddWithValue("@agew", agew);            
                cmd.Parameters.AddWithValue("@porto", portovalue);
                cmd.Parameters.AddWithValue("@IsrestrucW", RestrW);
                cmd.Parameters.AddWithValue("@hasColW", ColateralW);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();                  
                    string Search1 = "SELECT * from DebtorsActive where portfolio='" + portovalue + "'";
                    SqlDataAdapter adapt = new SqlDataAdapter();
                    adapt.SelectCommand = new SqlCommand(Search1, con);
                    DataTable dt = new DataTable();
                    adapt.Fill(dt);
                    dataGridViewRisk.DataSource = dt;
                    MessageBox.Show("Risk was set successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException exp)
                {
                    MessageBox.Show(exp.Message.ToString(), "Error Message");
                }

            }
            else
            {
                MessageBox.Show("Portfolio is not set", "Portfolio", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CheckBoxClient_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxClient.Checked==false)
            {
                textBoxRec.Text = "0";
                textBoxRec.ReadOnly = true;
            }
            else
            {
                textBoxRec.ReadOnly = false;
            }
        }

        private void CheckBoxBal_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBal.Checked == false)
            {
                textBoxbW.Text = "0";
                textBoxbW.ReadOnly = true;
            }
            else
            {
                textBoxbW.ReadOnly = false;
            }
        }

        private void checkBoxAge_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAge.Checked == false)
            {
                textBoxAge.Text = "0";
                textBoxAge.ReadOnly = true;
            }
            else
            {
                textBoxAge.ReadOnly = false;
            }
        }

        private void checkBoxRestr_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRestr.Checked == false)
            {
                textBoxRestruct.Text = "0";
                textBoxRestruct.ReadOnly = true;
            }
            else
            {
                textBoxRestruct.ReadOnly = false;
            }
        }

        private void checkBoxCol_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCol.Checked == false)
            {
                textBoxColateral.Text = "0";
                textBoxColateral.ReadOnly = true;
            }
            else
            {
                textBoxColateral.ReadOnly = false;
            }
        }
        private void comboBoxDB_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

      
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string aType = "Suggest sms";
            string equal = "<>";

            if (comboBox2.SelectedIndex == 0)
            {
                aType = "Suggest sms";
            }

            else if (comboBox2.SelectedIndex == 1)
            {
                aType = "suggest letter";
            }

            else if (comboBox2.SelectedIndex == 2)
            {
                aType = "suggest field";
            }

            else if (comboBox2.SelectedIndex == 3)
            {
                aType = "skip trace";
                equal = "=";
            }

            else if (comboBox2.SelectedIndex == 4)
            {
                aType ="suggest letter";
                equal = "=";
            }

            else if (comboBox2.SelectedIndex == 4)
            {
                aType = "field search";
                equal = "=";
            }
        
            DataTable dt = new DataTable();
            SqlConnection con1 = new SqlConnection(ConectionStr);
            //string Search1 = "SELECT * FROM DebtorsActive where debt_serial_number in ( select debt_serial_number from actionsjan where action_type='" + aType + "' and "+
            // " user_id='automated system' and action_date='2016-11-26' ) and latest_person_contacted"+equal+"'no contact' order by risk desc";

            string SearchProcess = "select DebtorsActive.debt_serial_number,DebtorsActive.Client,DebtorsActive.Debtor_Full_Name,DebtorsActive.Total_outstanding,DebtorsActive.Currency,DebtorsActive.Debt_Collector,actionsjan.OtherContact as Destination from " +
"(ActionsJan inner join DebtorsActive on ActionsJan.Debt_Serial_Number = DebtorsActive.Debt_Serial_Number) "+
"group by DebtorsActive.Debt_Serial_Number,ActionsJan.User_Id,ActionsJan.Action_Type,actionsjan.OtherContact,DebtorsActive.Client,DebtorsActive.Latest_Person_Contacted,DebtorsActive.Debtor_Full_Name,DebtorsActive.Currency,DebtorsActive.Total_outstanding,DebtorsActive.Debt_Collector " +
"having ActionsJan.User_Id = 'automated system' and ActionsJan.Action_Type like '"+aType+ "' and DebtorsActive.Latest_Person_Contacted"+equal+"'no contact' ";


            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = new SqlCommand(SearchProcess, con1);
            adapt.Fill(dt);
            dataGridViewProcess.DataSource = dt;
            //SetClientLogo();
          //  labelRowCount.Text = "Results: " + dataGridViewProcess.RowCount.ToString();
        }

        private void dataGridViewProcess_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (dataGridViewProcess.RowCount > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Documents (*.xls)|*.xls";
                sfd.FileName = "Exported_Processes.xls";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ToCsV(dataGridViewProcess, sfd.FileName);
                    // Here dataGridview1 is your grid view name
                }
            }
            else
            {
                MessageBox.Show("No data to export","Error Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
    }

        private void button4_Click(object sender, EventArgs e)
        {
            string aType = "";
            string pcontacted = "<>'no contact'";
            if (comboBox2.SelectedIndex >= 3)
            {
                pcontacted ="='no contact'";
            }

            if (comboBox2.SelectedIndex == 0)
            {
                aType = "Suggest sms";
            }

            else if (comboBox2.SelectedIndex == 1)
            {
                aType = "suggest letter";
            }

            else if (comboBox2.SelectedIndex == 2)
            {
                aType = "suggest field";
            }

            else if (comboBox2.SelectedIndex == 3)
            {
                aType = "skip trace";
             //   equal = "=";
            }

            else if (comboBox2.SelectedIndex == 4)
            {
                aType = "suggest letter";
             //   equal = "=";
            }

            else if (comboBox2.SelectedIndex == 4)
            {
                aType = "field search";
             //   equal = "=";
            }

            string update = "update DebtorsActive set Last_Act_type = @actType, user_id = 'automatic process', Next_Action_Date = DATEADD(DAY, 10, GETDATE())" +
            " where latest_person_contacted"+pcontacted+" and  Debt_Serial_Number in (select Debt_Serial_Number from ActionsJan where" +
            " Action_Date = GETDATE() and User_Id = 'automated system' and Action_Type = @actType)";
           
            //   string update="update debtorsactive set "
            SqlConnection con = new SqlConnection(ConectionStr);
            SqlCommand cmd = new SqlCommand("MultipleAction", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@actType", aType);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridViewclients_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int rowindex = e.RowIndex;// get row index of the clicked cell                          
            if (rowindex >= 0)
            {
                NewMethod(rowindex);
  
            }
        }
        private void NewMethod(int rowindex)
        {
            if (rowindex >= 0)
            {
                textBoxClient.Text = dataGridViewclients.Rows[rowindex].Cells[clientInstitutionDataGridViewTextBoxColumn.Index].Value.ToString();
                textBoxNipt.Text = dataGridViewclients.Rows[rowindex].Cells[nIPTDataGridViewTextBoxColumn.Index].Value.ToString();
                textBoxCtg.Text = dataGridViewclients.Rows[rowindex].Cells[typeDataGridViewTextBoxColumn.Index].Value.ToString();
                textBoxDt.Text = dataGridViewclients.Rows[rowindex].Cells[dateDataGridViewTextBoxColumn.Index].Value.ToString();
                textBoxRep.Text = dataGridViewclients.Rows[rowindex].Cells[representativeDataGridViewTextBoxColumn.Index].Value.ToString();
                textBoxcnt.Text = dataGridViewclients.Rows[rowindex].Cells[countryDataGridViewTextBoxColumn.Index].Value.ToString();
                textBoxDist.Text = dataGridViewclients.Rows[rowindex].Cells[districtDataGridViewTextBoxColumn.Index].Value.ToString();
                textBoxAdr.Text = dataGridViewclients.Rows[rowindex].Cells[addressDataGridViewTextBoxColumn.Index].Value.ToString();
                //pictureBoxClient.Image = dataGridViewclients.Rows[rowindex].Cells[ClientImage.Index].;
                textBoxemail.Text = dataGridViewclients.Rows[rowindex].Cells[emailDataGridViewTextBoxColumn.Index].Value.ToString();
                textBoxPh1.Text = dataGridViewclients.Rows[rowindex].Cells[phone1DataGridViewTextBoxColumn.Index].Value.ToString();
                textBoxPh2.Text = dataGridViewclients.Rows[rowindex].Cells[phone2DataGridViewTextBoxColumn.Index].Value.ToString();
                textBoxPh3.Text = dataGridViewclients.Rows[rowindex].Cells[phone3DataGridViewTextBoxColumn.Index].Value.ToString();

            }
        }
        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void buttonAddDebt_Click(object sender, EventArgs e)
        {
            //  if (dataGridViewAddDb.RowCount > 1)
            //  {

            //for (int i = 0; i < dataGridViewAddDb.Rows.Count; i++)
            //{
            //    if (dataGridViewAddDb.Rows[i].Cells[debtSerialNumberDataGridViewTextBoxColumn1.Index].Value == null || dataGridViewAddDb.Rows[i].Cells[currencyDataGridViewTextBoxColumn1.Index].Value == null || dataGridViewAddDb.Rows[i].Cells[clientInstitutionDataGridViewTextBoxColumn.Index].Value == null)
            //    {
            //        // dataGridViewAddDb.Rows[i].Cells[j].Value = DBNull.Value;
            //    }
            //}
            //  progressBarUpload.
            // string AmznString = "Data Source=debitor.c8kumftnoykl.eu-central-1.rds.amazonaws.com,1433;Initial Catalog=ForAmazon;User ID=debitordata;Password=Trsdmr92l161";
            if (textBoxDSerial.Text != "" && textBoxDSerial != null)
            {


                SqlConnection conx = new SqlConnection(ConectionStr);
                String Query = "insert into DebtorsActive (  Debt_Serial_Number , Debtor_Full_Name , Outstanding_Principal, Outstanding_Interest, Outstanding_Penalty," +
                    "  Debt_Collector , Total_Outstanding , Client_Branch, BranchId, DisbursmentDate, FinishedDate, RestructuredContract, IsRestructured, DisbursmentAmount," +
                    "InALL_Base,AmountInDelay ,PrincipalDelay ,InterestDelay ,UpComingInterest ,ClientSegment,ProductID ,DaysInDelay ,Mortgage,Pledge ,CashColateral ,portfolio,ContractStatusId," +
                    "client,last_updated,User_id,currency,debt_type,portfolio_status,assigment_date,assignmentDebt)" +
                    "values (@dser,@dname,@opc,@oi,@ope,@dcol,@tot,@clb, @BranchId, @DisbursmentDate, @FinishedDate, @RestructuredContract, @IsRestructured," +
                    " isnull(@DisbursmentAmount,0),isnull(@allBase,0),isnull(@AmountInDelay,0) ,isnull(@PrincipalDelay,0) ,isnull(@InterestDelay,0)  ,isnull(@UpComingInterest,0) ,@ClientSegment,@ProductID ,isnull(@DaysInDelay,1) ,@Mortgage ,@Pledge ,@CashColateral," +
                   "@portfolio,@CntrId,@client, @ldate,@user,@curr,@dtype,@pstatus,@adate,isnull(@asgDebt,@tot))";
                SqlCommand command = new SqlCommand(Query, conx);
                
                if (MessageBox.Show("Are you sure you want to add those data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    //for (int i = 0; i < dataGridViewAddDb.Rows.Count - 1; i++)
                    //{
                    command.Parameters.AddWithValue("@dser", textBoxDSerial.Text);
                    //   command.Parameters.AddWithValue("@did", dataGridViewAddDb.Rows[i].Cells[debtIdDataGridViewTextBoxColumn.Index].Value);
                    command.Parameters.AddWithValue("@dname", debtor_Full_NameTextBox.Text);
                    command.Parameters.AddWithValue("@opc", outstanding_PrincipalTextBox.Text);
                    command.Parameters.AddWithValue("@oi", outstanding_InterestTextBox.Text);
                    command.Parameters.AddWithValue("@ope", outstanding_PenaltyTextBox.Text);
                    command.Parameters.AddWithValue("@PrincipalDelay", principalDelayTextBox.Text);
                    command.Parameters.AddWithValue("@InterestDelay", interestDelayTextBox.Text);
                    command.Parameters.AddWithValue("@dcol", comboBoxDColl.Text);
                    command.Parameters.AddWithValue("@tot", total_Outstanding1TextBox.Text);
                    command.Parameters.AddWithValue("@clb", client_BranchTextBox.Text);



                    // command.Parameters.AddWithValue("@CloseDate",closeda);
                    command.Parameters.AddWithValue("@BranchId", branchIdTextBox.Text);

                    command.Parameters.AddWithValue("@DisbursmentDate", disbursmentDateDateTimePicker.Value);
                    command.Parameters.AddWithValue("@FinishedDate", finishedDateDateTimePicker.Value);
                    command.Parameters.AddWithValue("@RestructuredContract", restructuredContractTextBox.Text);
                    command.Parameters.AddWithValue("@IsRestructured", isRestructuredTextBox.Text);
                    command.Parameters.AddWithValue("@DisbursmentAmount", disbursmentAmountTextBox.Text);
                    command.Parameters.AddWithValue("@allBase", inALL_BaseTextBox.Text);
                    command.Parameters.AddWithValue("@AmountInDelay", amountInDelayTextBox.Text);

                    // command.Parameters.AddWithValue("@Penalty", dataGridViewAddDb.Rows[i].Cells[19].Value);
                    command.Parameters.AddWithValue("@UpComingInterest", upComingInterestTextBox.Text);
                    command.Parameters.AddWithValue("@ClientSegment", clientSegmentTextBox.Text);
                    command.Parameters.AddWithValue("@ProductID", productIDTextBox.Text);
                    command.Parameters.AddWithValue("@DaysInDelay", daysInDelayTextBox.Text);
                    command.Parameters.AddWithValue("@Mortgage", mortgageTextBox.Text);
                    command.Parameters.AddWithValue("@Pledge", pledgeTextBox.Text);
                    command.Parameters.AddWithValue("@CashColateral", cashColateralTextBox.Text);
                    command.Parameters.AddWithValue("@CntrId", contractStatusIdTextBox.Text);
                    command.Parameters.AddWithValue("@portfolio", PortfolioTextBox.Text);

                    command.Parameters.AddWithValue("@client", clientComboBox.Text);
                    command.Parameters.AddWithValue("ldate", DateTime.Today.ToString());
                    //       command.Parameters.AddWithValue("user", OnlineUser);
                    command.Parameters.AddWithValue("curr", currencyComboBox.Text);
                    command.Parameters.AddWithValue("dtype", debt_TypeComboBox.Text);
                    command.Parameters.AddWithValue("adate", DateTime.Today.ToString());
                    command.Parameters.AddWithValue("@pstatus", "Active");
                    command.Parameters.AddWithValue("@user", usernamevalue);
                    command.Parameters.AddWithValue("asgDebt", total_Outstanding1TextBox.Text);

                    try
                    {
                        conx.Open();
                        command.ExecuteNonQuery();
                        conx.Close();
                        // this.Close();
                    }
                    catch (SqlException exception)
                    {
                        MessageBox.Show(exception.Message.ToString(), "Error Message");
                    }
                    command.Parameters.Clear();
                    string InsertNotification = "insert into Notifications(serial, name, type, userid, collector, datetime)" +
             "values(@dserial,@name,'New debtor',@user,@collect,GetDate())";
                    command = new SqlCommand(InsertNotification, conx);
                    command.Parameters.AddWithValue("@dserial",textBoxDSerial.Text);
                    command.Parameters.AddWithValue("@name", debtor_Full_NameTextBox.Text);
                    command.Parameters.AddWithValue("@collect", PortfolioTextBox.Text);
                    command.Parameters.AddWithValue("@user", usernamevalue);
                    conx.Open();
                    command.ExecuteNonQuery();
                    conx.Close();
                    // Contine editing here....


                    //  SqlConnection con = new SqlConnection(AmznString);
                    command = new SqlCommand("UpdateDebtColumnsProc", conx);//ERROR when converting float to numerit
                    command.CommandType = CommandType.StoredProcedure;
                    // cmd.Parameters.AddWithValue("@Client_Institution", comboBoxClient.Text);
                    //cmd.Parameters.AddWithValue("@Portfolio",comboBoxPorto.Text);
                    //cmd.Parameters.AddWithValue("@ActualDate", DateTime.Today);
                    for (int j = 0; j <= 1; j++)
                    {
                        try
                        {
                            conx.Open();
                            command.ExecuteNonQuery();
                            conx.Close();

                        }
                        catch (SqlException exception)
                        {
                            conx.Close();
                            MessageBox.Show(exception.Message.ToString(), "Error Message");
                        }

                    }
                    //MessageBox.Show("Succesfully uploaded " + dataGridView1.Rows.Count + " new debtors", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    buttonAddDebt.Enabled = false;//parandalon ringarkimin e rasteve
                    MessageBox.Show("Uploaded successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No data to upload", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

       

       
        private void buttonOpenFile_Click_1(object sender, EventArgs e)
        {
            openFileDialogDebt.ShowDialog();
        }

        private void openFileDialogDebt_FileOk(object sender, CancelEventArgs e)
        {
            string filePath = openFileDialogDebt.FileName;
            textBoxFilePath.Text = filePath;
            string extension = Path.GetExtension(filePath);
            //  string header = "YES";
            string conStr, sheetName;

            conStr = string.Empty;
            switch (extension)
            {
                case ".xls": //Excel 97-03
                    conStr = string.Format(Excel03ConString, filePath, "YES");
                    break;

                case ".xlsx": //Excel 07
                    conStr = string.Format(Excel07ConString, filePath, "YES");
                    break;
            }

            //Get the name of the First Sheet.
            OleDbConnection con1 = new OleDbConnection(conStr);

            con1.Open();
            DataTable dtExcelSchema = con1.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
            con1.Close();

            //Read Data from the First Sheet.
            OleDbConnection con = new OleDbConnection(conStr);
            OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * From [" + sheetName + "]", con);
            OleDbDataAdapter oda2 = new OleDbDataAdapter("Delete From [" + sheetName + "] Where ", con);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            con.Close();

            List<string> ColumnNames = new List<string>();
            List<string> ExcelNames = new List<string>();
            for (int i = 0; i < dataGridViewUpdateDebts.ColumnCount; i++)
            {
                ColumnNames.Add(dataGridViewUpdateDebts.Columns[i].HeaderText.ToLower());
            }
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ExcelNames.Add(dt.Columns[i].ColumnName.ToLower());
            }
            //if (ExcelNames.Contains("Debt_Serial_Number")==false)
            //{
                for (int x = 0; x < ExcelNames.Count; x++)
                {
                    if (ColumnNames.Contains(ExcelNames[x]) == false)
                    {
                        MessageBox.Show("Column names does not match in excel column index " + x, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    if (x == dt.Columns.Count - 1)
                    {
                        dataGridViewUpdateDebts.DataSource = dt;
                    }
                }
            //}
            //else
            //{
            //    MessageBox.Show("Required column 'Debt_Serial_Number' is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }

        private void buttonUpload_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewUpdateDebts.RowCount >= 1)
            {

                for (int k = 0; k < dataGridViewUpdateDebts.Rows.Count; k++)
                {
                    for (int j = 0; j < dataGridViewUpdateDebts.Columns.Count; j++)
                    {
                        if (dataGridViewUpdateDebts.Rows[k].Cells[j].Value == null || dataGridViewUpdateDebts.Rows[k].Cells[j].Value.ToString() == "" || dataGridViewUpdateDebts.Rows[k].Cells[j].Value.ToString() == " ")
                        {
                            dataGridViewUpdateDebts.Rows[k].Cells[j].Value = DBNull.Value;
                        }
                    }
                }
                //  progressBarUpload.
                // string AmznString = "Data Source=debitor.c8kumftnoykl.eu-central-1.rds.amazonaws.com,1433;Initial Catalog=ForAmazon;User ID=debitordata;Password=Trsdmr92l161";
                SqlConnection conx = new SqlConnection(ConectionStr);
                String Query = "update DebtorsActive set  Debtor_Full_Name=isnull(@dname,Debtor_Full_Name) ,client=isnull(@client,client) ,portfolio=isnull(@port,portfolio),debt_type=isnull(@dtype,debt_type),currency=isnull(@curr,currency), Outstanding_Principal=isnull(@oprinc,Outstanding_Principal), "+
                    "Outstanding_Interest=isnull(@oi,Outstanding_Interest), Outstanding_Penalty=isnull(@ope,Outstanding_Penalty), " +
                    "  Debt_Collector= isnull(@dcol,Debt_Collector), Total_Outstanding=isnull(@tot,Total_Outstanding) , Client_Branch=isnull(@clb,Client_Branch),CloseDate=isnull(@CloseDate,CloseDate), BranchId=isnull(@BranchId,BranchId), DisbursmentDate=isnull(@DisbursmentDate,DisbursmentDate), "+
                    "FinishedDate=isnull(@FinishedDate,FinishedDate), RestructuredContract=isnull(@RestructuredContract,RestructuredContract), "+
                    "IsRestructured=isnull(@IsRestructured,IsRestructured), DisbursmentAmount=isnull(DisbursmentAmount,DisbursmentAmount)," +
                    "InALL_Base=isnull(@allBase,InALL_Base),AmountInDelay =isnull(@AmountInDelay,AmountInDelay),PrincipalDelay=isnull(@PrincipalDelay,PrincipalDelay) ,InterestDelay =isnull(@InterestDelay,InterestDelay) ,ClientSegment=isnull(@ClientSegment,ClientSegment), "+
                    "ProductID=isnull(@ProductID,ProductID) ,reassigned=(case when @dcol is not null then  getdate() else reassigned end),DaysInDelay= isnull(@DaysInDelay,DaysInDelay),Mortgage=isnull(@Mortgage,Mortgage),Pledge=isnull(@Pledge,Pledge) ,CashColateral=isnull(@CashColateral,CashColateral) ,ContractStatusId=isnull(@CntrId,ContractStatusId)," +
                    "portfolio_status=isnull(@pstatus,portfolio_status),assigment_date=isnull(@adate,assigment_date),LinkId=isnull(@lid,LinkId),assignmentDebt=isnull(@adebt,assignmentDebt),payaccno=isnull(@payaccno,payaccno),classification=isnull(@classification,classification),UpComingInterest=isnull(@UpComingInterest,UpComingInterest) " +
                    " where debt_serial_number=@dserial ";
                 
                SqlCommand command = new SqlCommand(Query, conx);
                conx.Open();

                SqlTransaction trans = conx.BeginTransaction();
                command.Transaction = trans;
                int i = 0;
                try
                {
                    for (i = 0; i < dataGridViewUpdateDebts.Rows.Count; i++)
                    {

                        command.Parameters.AddWithValue("@dserial", dataGridViewUpdateDebts.Rows[i].Cells[debtSerialNumberDataGridViewTextBoxColumn2.Index].Value);
                        command.Parameters.AddWithValue("@client", dataGridViewUpdateDebts.Rows[i].Cells[clientDataGridViewTextBoxColumn2.Index].Value);
                        command.Parameters.AddWithValue("@port", dataGridViewUpdateDebts.Rows[i].Cells[portfolioDataGridViewTextBoxColumn2.Index].Value);
                        command.Parameters.AddWithValue("@dtype", dataGridViewUpdateDebts.Rows[i].Cells[debtTypeDataGridViewTextBoxColumn1.Index].Value);
                        command.Parameters.AddWithValue("@curr", dataGridViewUpdateDebts.Rows[i].Cells[currencyDataGridViewTextBoxColumn2.Index].Value);
                        //   command.Parameters.AddWithValue("@did", dataGridViewUpdateDebts.Rows[i].Cells[debtIdDataGridViewTextBoxColumn.Index].Value);
                        command.Parameters.AddWithValue("@dname", dataGridViewUpdateDebts.Rows[i].Cells[debtorFullNameDataGridViewTextBoxColumn2.Index].Value);
                        command.Parameters.AddWithValue("@oprinc", dataGridViewUpdateDebts.Rows[i].Cells[outstandingPrincipalDataGridViewTextBoxColumn2.Index].Value);
                        command.Parameters.AddWithValue("@oi", dataGridViewUpdateDebts.Rows[i].Cells[outstandingInterestDataGridViewTextBoxColumn2.Index].Value);
                        command.Parameters.AddWithValue("@ope", dataGridViewUpdateDebts.Rows[i].Cells[outstandingPenaltyDataGridViewTextBoxColumn2.Index].Value);
                        command.Parameters.AddWithValue("@PrincipalDelay", dataGridViewUpdateDebts.Rows[i].Cells[principalDelayDataGridViewTextBoxColumn1.Index].Value);
                        command.Parameters.AddWithValue("@InterestDelay", dataGridViewUpdateDebts.Rows[i].Cells[interestDelayDataGridViewTextBoxColumn1.Index].Value);
                        command.Parameters.AddWithValue("@dcol", dataGridViewUpdateDebts.Rows[i].Cells[debtCollectorDataGridViewTextBoxColumn2.Index].Value);
                        command.Parameters.AddWithValue("@tot", dataGridViewUpdateDebts.Rows[i].Cells[totalOutstandingDataGridViewTextBoxColumn2.Index].Value);
                        command.Parameters.AddWithValue("@clb", dataGridViewUpdateDebts.Rows[i].Cells[clientBranchDataGridViewTextBoxColumn1.Index].Value);
                        //DateTime tm = new DateTime();

                        //                 tm= dataGridViewUpdateDebts.Rows[i].Cells[closeDateDataGridViewTextBoxColumn.Index].Value;


                        command.Parameters.AddWithValue("@CloseDate", dataGridViewUpdateDebts.Rows[i].Cells[closeDateDataGridViewTextBoxColumn1.Index].Value);
                        command.Parameters.AddWithValue("@BranchId", dataGridViewUpdateDebts.Rows[i].Cells[branchIdDataGridViewTextBoxColumn1.Index].Value);

                        command.Parameters.AddWithValue("@DisbursmentDate", dataGridViewUpdateDebts.Rows[i].Cells[disbursmentDateDataGridViewTextBoxColumn1.Index].Value);
                        command.Parameters.AddWithValue("@FinishedDate", dataGridViewUpdateDebts.Rows[i].Cells[finishedDateDataGridViewTextBoxColumn1.Index].Value);
                        command.Parameters.AddWithValue("@RestructuredContract", dataGridViewUpdateDebts.Rows[i].Cells[restructuredContractDataGridViewTextBoxColumn1.Index].Value);
                        command.Parameters.AddWithValue("@IsRestructured", dataGridViewUpdateDebts.Rows[i].Cells[isRestructuredDataGridViewTextBoxColumn1.Index].Value);
                        command.Parameters.AddWithValue("@DisbursmentAmount", dataGridViewUpdateDebts.Rows[i].Cells[disbursmentAmountDataGridViewTextBoxColumn1.Index].Value);
                        command.Parameters.AddWithValue("@allBase", dataGridViewUpdateDebts.Rows[i].Cells[disbursmentAmountDataGridViewTextBoxColumn1.Index].Value);
                        command.Parameters.AddWithValue("@AmountInDelay", dataGridViewUpdateDebts.Rows[i].Cells[amountInDelayDataGridViewTextBoxColumn1.Index].Value);

                        // command.Parameters.AddWithValue("@Penalty", dataGridViewUpdateDebts.Rows[i].Cells[19].Value);
                        command.Parameters.AddWithValue("@UpComingInterest", dataGridViewUpdateDebts.Rows[i].Cells[upComingInterestDataGridViewTextBoxColumn1.Index].Value);
                        command.Parameters.AddWithValue("@ClientSegment", dataGridViewUpdateDebts.Rows[i].Cells[clientSegmentDataGridViewTextBoxColumn1.Index].Value);
                        command.Parameters.AddWithValue("@ProductID", dataGridViewUpdateDebts.Rows[i].Cells[productIDDataGridViewTextBoxColumn1.Index].Value);
                        command.Parameters.AddWithValue("@DaysInDelay", dataGridViewUpdateDebts.Rows[i].Cells[daysInDelayDataGridViewTextBoxColumn1.Index].Value);
                        command.Parameters.AddWithValue("@Mortgage", dataGridViewUpdateDebts.Rows[i].Cells[mortgageDataGridViewTextBoxColumn1.Index].Value);
                        command.Parameters.AddWithValue("@Pledge", dataGridViewUpdateDebts.Rows[i].Cells[pledgeDataGridViewTextBoxColumn1.Index].Value);
                        command.Parameters.AddWithValue("@CashColateral", dataGridViewUpdateDebts.Rows[i].Cells[cashColateralDataGridViewTextBoxColumn1.Index].Value);
                        command.Parameters.AddWithValue("@CntrId", dataGridViewUpdateDebts.Rows[i].Cells[contractStatusIdDataGridViewTextBoxColumn1.Index].Value);
                        command.Parameters.AddWithValue("@lid", dataGridViewUpdateDebts.Rows[i].Cells[linkIDDataGridViewTextBoxColumn1.Index].Value);
                        command.Parameters.AddWithValue("@adebt", dataGridViewUpdateDebts.Rows[i].Cells[assignmentDebtDataGridViewTextBoxColumn1.Index].Value);
                       // command.Parameters.AddWithValue("@last_act_type", dataGridViewUpdateDebts.Rows[i].Cells[Last_Act_type.Index].Value);
                       // command.Parameters.AddWithValue("@next_act_date", dataGridViewUpdateDebts.Rows[i].Cells[Next_Action_Date.Index].Value);
                       // //command.Parameters.AddWithValue("@latest_comment", dataGridViewUpdateDebts.Rows[i].Cells[Latest_Comment.Index].Value);
                       // command.Parameters.AddWithValue("@latest_person_contacted", dataGridViewUpdateDebts.Rows[i].Cells[Latest_Person_Contacted.Index].Value);
                       // command.Parameters.AddWithValue("@reaction", dataGridViewUpdateDebts.Rows[i].Cells[Reaction.Index].Value);
                       // command.Parameters.AddWithValue("@contactedVia", dataGridViewUpdateDebts.Rows[i].Cells[ContactedVia.Index].Value);
                        //command.Parameters.AddWithValue("@Ptp_amount", dataGridViewUpdateDebts.Rows[i].Cells[PTP_Amount.Index].Value);
                        command.Parameters.AddWithValue("@payaccno", dataGridViewUpdateDebts.Rows[i].Cells[payAccNoDataGridViewTextBoxColumn1.Index].Value);

                       // command.Parameters.AddWithValue("ldate", DateTime.Today.ToString());
                       // command.Parameters.AddWithValue("@user", dataGridViewUpdateDebts.Rows[i].Cells[User_Id.Index].Value);
                        command.Parameters.AddWithValue("@classification", dataGridViewUpdateDebts.Rows[i].Cells[classificationDataGridViewTextBoxColumn1.Index].Value);
                        //DateTime dt = new DateTime();
                        command.Parameters.AddWithValue("adate",dataGridViewUpdateDebts.Rows[i].Cells[assigmentDateDataGridViewTextBoxColumn2.Index].Value);
                        command.Parameters.AddWithValue("@pstatus", dataGridViewUpdateDebts.Rows[i].Cells[portfolioStatusDataGridViewTextBoxColumn2.Index].Value);

                        try
                        {
                            command.ExecuteNonQuery();
                            
                            // this.Close();
                        }
                        catch (SqlException exception)
                        {
                            MessageBox.Show(exception.Message.ToString(), "Error Message");
                            break;
                        }

                        command.Parameters.Clear();
                    }
                    trans.Commit();

                }

                catch (SqlException ex) // As you are doing the same thing on boths exceptions one handler is enought
                {
                    trans.Rollback();
                    MessageBox.Show(ex.Message.ToString() + "\nError line " + i + ".\nUpload failed.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }

                conx.Close();
                        
                MessageBox.Show("Succesfully updated " + dataGridViewUpdateDebts.Rows.Count + " new debtors", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttonUpload.Enabled = false;//parandalon ringarkimin e rasteve
                                             // this.Close();           
            }
            else
            {
                MessageBox.Show("Please select a file to continue", "No file choosen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUpdateStatus_Click(object sender, EventArgs e)
        {
            if (dataGridViewCases.Rows.Count >= 1)
            {
                if (comboBoxStatusUpd.Text != null && comboBoxStatusUpd.Text != "")
                {
                    SqlConnection conx = new SqlConnection(ConectionStr);
                    String UpdateQuery = "update DebtorsActive set portfolio_status='" + comboBoxStatusUpd.Text + "',reassigned=getdate() where debt_serial_number=@dserial ";
                    SqlCommand command = new SqlCommand(UpdateQuery, conx);

                    if (MessageBox.Show("Are you sure you want to edit Portfolio status ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        conx.Open();
                        for (int j = 0; j < dataGridViewCases.Rows.Count; j++)
                        {
                            // command.Parameters.AddWithValue("@coll", dataGridViewCases.Rows[j].Cells[debtCollectorDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@date", DateTime.Today);
                            //   command.Parameters.AddWithValue("@user", usernamevalue);
                            command.Parameters.AddWithValue("@dserial", dataGridViewCases.Rows[j].Cells[debtSerialNumberDataGridViewTextBoxColumn.Index].Value);
                            try
                            {
                                command.ExecuteNonQuery();
                            }
                            catch (SqlException exception)
                            {
                                MessageBox.Show(exception.Message.ToString(), "Error Message");
                            }
                            command.Parameters.Clear();
                        }
                        conx.Close();
                        MessageBox.Show("Succesfully updated " + dataGridViewCases.Rows.Count + " debtors", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a protfolio type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonUpdatePayment_Click(object sender, EventArgs e)
        {
            if (dataGridViewPaymentUpdate.Rows.Count >= 1)
            {
              
                    SqlConnection conx = new SqlConnection(ConectionStr);
                    String UpdateQuery = "update Paymentsjan set payment_status='" + comboBoxUpdatePayment.Text + "' where id=@id ";
                    SqlCommand command = new SqlCommand(UpdateQuery, conx);

                    if (MessageBox.Show("Are you sure you want to edit Payment status ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        conx.Open();
                        for (int j = 0; j < dataGridViewPaymentUpdate.Rows.Count; j++)
                        {
                            // command.Parameters.AddWithValue("@coll", dataGridViewCases.Rows[j].Cells[debtCollectorDataGridViewTextBoxColumn.Index].Value);
                          //  command.Parameters.AddWithValue("@date", DateTime.Today);
                            //   command.Parameters.AddWithValue("@user", usernamevalue);
                            command.Parameters.AddWithValue("@id", dataGridViewPaymentUpdate.Rows[j].Cells[iDDataGridViewTextBoxColumn1.Index].Value);
                            try
                            {
                                command.ExecuteNonQuery();
                            }
                            catch (SqlException exception)
                            {
                                MessageBox.Show(exception.Message.ToString(), "Error Message");
                            }
                            command.Parameters.Clear();
                        }
                        conx.Close();
                        MessageBox.Show("Succesfully updated " + dataGridViewPaymentUpdate.Rows.Count + " debtors", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
              
            }
        }

        private void ButtonOraret_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConectionStr);
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = new SqlCommand("orari", con);
            adapt.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapt.SelectCommand.Parameters.AddWithValue("@koha", dateTimePickerOrari.Text);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridViewOraret.DataSource = dt;
            dataGridViewOraret.Columns[0].Width = 120;
            dataGridViewOraret.Columns[1].Width = 200;
            dataGridViewOraret.Columns[2].Width = 200;



        }
    }
}
