using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Net;
using System.Deployment.Application;
using Xceed.Words.NET;
using System.Text.RegularExpressions;
using Microsoft.Office.Interop;



namespace MainDebtApp
{
    public partial class Form1 : Form
    {
        //Phone variables
        //  string call = "", screen = "", endCall = "";
        List<string> ContactNo = new List<string>();
        private readonly BackgroundWorker worker1, worker2, worker3;
        //variable declaration of Debts
        // string clientcheck = " like ",Branchidcheck=" like ", portocheck = " like ", pstatuscheck = " like ", collectorcheck = " like ", lastcpCheck = " like ", currencyCheck = " like ", reactionCheck = " like";
        // string clientvalue = "%", portovalue = "%", pstatusvalue = "active", classValue="%",BranchValue="%",collectorvalue = "%", lastcpvalue = "%", currencyvalue = "%", reactionvalue = "%",actTypeValue="%";
        // double sumMin = 0;//PtpSum=0;
        // string SumQyery = "", DateQuery = "", PTPQuery = "",classQuery="", ReactionQuery = "", LastCp = "", noActionsQ = "", noPaymentsQ = "",UpdatedQuery="",AsgQuery="",ReasgQuery="",SourceQuery="",ActionQuery="";
        // string DateFilter = "",UpdateFilter="",AsgDateFilter="",DebtDistrictQuery="",ReasgFilter="",BranchQuery="";
        DataTable dts;
        DataTable dtskip = new DataTable();
        DataTable dtSearch = new DataTable();

        //variable declaration of Payments
        string cliendQuery = "", paymentQuery = "", dateQuery = "", PaymentCurrQuery = "", PaymentPortfolio = "";
        string lastupdatedPQuery = "", CollectorPay = "%", PaymentsComment = "";

        // variable declaration of Collaterals
        string CollClientValue = "%", CollNameQuery = "", CollTypeQuery = "";
        string CollValuesQuery = "", lastupdCollQuery = "";

        //variable declaration of Actions
        string actionClQuery, dateActquery, atypeQuery, astuatusValue = "%", userActQuery, actUpdateQuery, commentQuery, dateAcfilter = "";


        //variable declaration of contacts
        //string CntClientQuery, districtvalue = "%", PersonStatusQuery, noCntQuery, emailQuery,CntCollectorQuery;

        //System Values
        string LogedCollector = null;
        string usernamevalue = null;
        string StatusCollector = null, provider = null, contactno = null, dueDay = null;
        int rowIndex = -2;
        string FAMID = null;
        string NID = null;

        string ConectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["InstantLogin"].ConnectionString;



        int pointer = 1;
        String Savehistory = "SaveSearchHistory.txt";
        List<string> History = new List<string>();
        public Form1()
        {

            InitializeComponent();
            string textboxvalue = null;
            worker1 = new BackgroundWorker();
            worker1.DoWork += SeekData;
            worker1.RunWorkerCompleted += work_complete;

            worker2 = new BackgroundWorker();
            worker2.DoWork += GetSearchData;
            worker2.RunWorkerCompleted += work_complete_Search;

            worker3 = new BackgroundWorker();
            worker3.DoWork += SeekDataSkip;
            worker3.RunWorkerCompleted += work_complete;
            // worker1.ProgressChanged += worker_ProgressChanged;

            if (Application.OpenForms["Users"] != null)
            {
                usernamevalue = (Application.OpenForms["Users"] as Users).userna;
                LogedCollector = (Application.OpenForms["Users"] as Users).collector;

            }
            labelOnlineUser.Text = usernamevalue;
            //struct getValues { }

            if (Application.OpenForms["NewActionForm"] != null)
            {
                //labeldbSerial.Text = (Application.OpenForms["Form1"] as Form1).textname;
                //linkLabelfname.Text = (Application.OpenForms["Form1"] as Form1).textname3;
                //labelclinstitution.Text = (Application.OpenForms["Form1"] as Form1).textname2;
                textboxvalue = (Application.OpenForms["NewActionForm"] as NewActionForm).fill.debtserialnr;

            }

            if (Application.OpenForms["Notifications"] != null)
            {
                dts = (Application.OpenForms["Notifications"] as Notifications).Dtb;
                dataGridViewDebtors.DataSource = dts;
            }

            if (Application.OpenForms["Letter"] != null)
            {
                provider = (Application.OpenForms["Letter"] as Letter).provider;
                dueDay = (Application.OpenForms["Letter"] as Letter).DueDay;
                contactno = (Application.OpenForms["Letter"] as Letter).ContactNo;

            }


            //textBox8.Text = textboxvalue; 
        }

        public String textname { get { return this.textBoxdebtserial.Text.ToString(); } }
        public String textname2 { get { return this.Clinstitution; } }
        public String textname3 { get { return this.textBoxdfname.Text.ToString(); } }
        public String textname4 { get { return this.textBoxCollector.Text.ToString(); } }
        public String LogColl { get { return this.LogedCollector; } }
        public String PortfolioName { get { return this.textBoxPort.Text; } }

        public String UserRights { get { return this.StatusCollector; } }
        public String DocID { get { return this.docID; } }
        public String PaymID { get { return this.paymentID; } }
        public String ActID { get { return this.actionID; } }
        public String Contactid { get { return this.contactID; } }
        public DataGridView DGV { get { return this.dataGridViewDebtors; } }
        public DataGridView DGVpayments { get { return this.paymentsJanDataGridView; } }
        public String LasctCP { get { return this.dataGridViewDebtors.Rows[dataGridViewDebtors.CurrentCellAddress.Y].Cells[latestPersonContactedDataGridViewTextBoxColumn.Index].Value.ToString(); } }
        public String DebtId { get { return this.dataGridViewDebtors.Rows[dataGridViewDebtors.CurrentCellAddress.Y].Cells[debtIdDataGridViewTextBoxColumn.Index].Value.ToString(); } }

        string Clinstitution = null;
        string paymentID = null;
        string actionID = null;
        string contactID = null, docID = null;

        double dial_rate = 0, payrate = 0;
        int days = 0, actnr = 0, SMS = 0, letter = 0, field = 0, skip = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'forAmazonDataSet.Reactions' table. You can move, or remove it, as needed.
            this.reactionsTableAdapter.Fill(this.forAmazonDataSet.Reactions);
            splitContainerDebtors.SplitterDistance = 50;
            splitContainerinsideD.SplitterDistance = groupBoxActDetail.Size.Height;// + (groupBoxActDetail.Location.X/2);
            this.usernamesTableAdapter.Fill(this.forAmazonDataSet.Usernames);

            labelLogedCollector.Text = LogedCollector;
            this.portofolioTableAdapter1.Fill(this.forAmazonDataSet.Portofolio);
            // this.debtorsActiveTableAdapter1.Fill(this.forAmazonDataSet.DebtorsActive,LogedCollector);
            //save data
            this.clientInstitutionTableAdapter1.Fill(this.forAmazonDataSet.ClientInstitution);
            this.actionTypeTableAdapter1.Fill(this.forAmazonDataSet.ActionType);
            this.currencyTableAdapter1.Fill(this.forAmazonDataSet.Currency);
            this.contactedPersonTableAdapter1.Fill(this.forAmazonDataSet.ContactedPerson);
            this.portofolioStatusTableAdapter1.Fill(this.forAmazonDataSet.PortofolioStatus);

            //     CalculateData();
            this.comboBoxClientDb.SelectedItem = null;
            this.comboBoxClinstAct.SelectedValue = "";
            comboBoxPersonCl.SelectedValue = "";
            comboBoxPorto.SelectedItem = null;
            //comboBox2.Text = "";
            this.comboBoxPStatus.Text = "Active";
            this.comboBoxCurrDb.SelectedItem = null;
            comboBoxCntPersAct.SelectedItem = null;
            comboBoxActTypeAct.SelectedItem = null;
            comboBoxActionType.SelectedItem = null;
            this.comboBoxPayCurr.SelectedItem = null;

            this.comboBoxLcp.SelectedItem = null;
            this.comboBox2.SelectedItem = null;
            this.comboBoxClinstPAy.SelectedValue = "";
            this.comboBoxPortf.SelectedItem = null;
            //  comboBoxPayCurr
            // this.comboBoxPorto.Text = "";
            this.comboBoxPeriod.SelectedIndex = 0;
            this.comboBoxLastupd.SelectedIndex = 0;
            this.comboBoxSelPeriod1.SelectedIndex = 0;
            //  this.reportViewer1.RefreshReport();
            this.comboBoxPayColl.SelectedValue = "";
            this.DailyActions(usernamevalue);
            this.comboBoxDbCollector.Text = LogedCollector;
            this.textBoxUserAct.Text = usernamevalue;
            this.textBoxPayColl.Text = LogedCollector;
            string statusCollectorString = "select status from usernames where username='" + usernamevalue + "'";
            SqlConnection conStatus = new SqlConnection(ConectionStr);
            SqlCommand cmdStatus = new SqlCommand(statusCollectorString, conStatus);
            conStatus.Open();
            SqlDataReader reader = cmdStatus.ExecuteReader();

            while (reader.Read())
            {
                StatusCollector = reader.GetString(0).ToString();
            }

            conStatus.Close();

            if (StatusCollector.ToLower() != "admin" && StatusCollector.ToLower() != "supervisor")
            {

                textBoxPayColl.ReadOnly = true;// vetem ad,sp
                textBoxUserAct.ReadOnly = true;//vetem ad,s[
                toolTipAddres.SetToolTip(this.listBoxDadr, "Test tooltip");
                textBoxOnlineUser.ReadOnly = true;
                comboBoxCollector.Enabled = false;
                comboBoxActionRep.Enabled = false;
                comboBoxPaymentsRep.Enabled = false;
                comboBoxDebts.Enabled = false;
            }
            if (StatusCollector.ToLower() != "admin" && StatusCollector.ToLower() != "supervisor" && StatusCollector.ToLower() != "agent")
            {
                comboBoxDbCollector.Enabled = false;
            }
            taskload();

        }
        private void taskload()
        {
            DataTable dt = new DataTable();
            SqlConnection con1 = new SqlConnection(ConectionStr);
            string Search1 = "SELECT * FROM DebtorsActive where debt_collector='" + LogedCollector + "' and debt_serial_number in ( select serialCode from tasks where taskno=2)  order by debtor_full_name asc";
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = new SqlCommand(Search1, con1);
            adapt.Fill(dt);
            dataGridViewDebtors.DataSource = dt;
           // dataGridViewDebtors.Columns["Category"].DataPropertyName = dt.Columns["Category"].ToString();
            SetClientLogo();
            labelRowCount.Text = "Results: " + dataGridViewDebtors.RowCount;
        }

        private void DailyActions(string userO)
        {
            string querycount = " select count(id) from Actionsjan where user_id=@user and last_updated=@date";
            SqlConnection con = new SqlConnection(ConectionStr);
            SqlCommand cmd = new SqlCommand(querycount, con);
            cmd.Parameters.AddWithValue("@user", userO);
            cmd.Parameters.AddWithValue("@date", DateTime.Today.ToString("M/d/yyyy"));
            con.Open();
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                if (read.IsDBNull(0) == false)
                {
                    labelDailyAct.Text = "Actions: " + read.GetInt32(0).ToString();
                }
                else
                {
                    labelDailyAct.Text = "Actions: " + "0";
                }
            }
            con.Close();
        }
        private void collectActions()
        {
            //dataGridViewselectedactions.Columns.Clear();
            //dataGridViewselectedactions.Rows.Clear();
            //foreach (DataGridViewColumn dgvCol in dataGridViewAct.Columns)
            //{
            //    dataGridViewselectedactions.Columns.Add(dgvCol.Clone() as DataGridViewColumn);
            //}

            //DataGridViewRow row = new DataGridViewRow();
            //for (int i = 0; i < dataGridViewAct.Rows.Count - 1; i++)
            //{
            //    //  int vonesa = 0;
            //    string debtserialcode = textBoxdebtserial.Text;
            //    string actdebtserial = dataGridViewAct.Rows[i].Cells[debtSerialNumberDataGridViewTextBoxColumn1.Index].Value.ToString();
            //    // int.TryParse(vonesaStr, out vonesa);
            //    if (debtserialcode == actdebtserial)
            //    {

            //        row = (DataGridViewRow)dataGridViewAct.Rows[i].Clone();
            //        int intColIndex = 0;
            //        foreach (DataGridViewCell cell in dataGridViewAct.Rows[i].Cells)
            //        {
            //            row.Cells[intColIndex].Value = cell.Value;
            //            intColIndex++;
            //        }
            //        dataGridViewselectedactions.Rows.Add(row);
            //    }
            //}
            //dataGridViewselectedactions.AllowUserToAddRows = false;
            //dataGridViewselectedactions.Refresh();

            //try
            //{
            //    this.actionsJanTableAdapter1.ActionsCollect(this.forAmazonDataSet.ActionsJan, textBoxdebtserial.Text);
            //}
            //catch (System.Exception ex)
            //{
            //    System.Windows.Forms.MessageBox.Show(ex.Message);
            //}
            SqlConnection con = new SqlConnection(ConectionStr);
            DataTable dt = new DataTable();
            string collectAct = "select * from actionsjan where debt_serial_number='" + textBoxdebtserial.Text + "' order by last_updated desc,id desc";
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = new SqlCommand(collectAct, con);
            adapt.Fill(dt);
            dataGridViewselectedactions.DataSource = dt;

        }

        private void collectPayments()
        {
            //dataGridViewselectedPay.Columns.Clear();
            //dataGridViewselectedPay.Rows.Clear();
            //foreach (DataGridViewColumn dgvCol in paymentsJanDataGridView.Columns)
            //{
            //    dataGridViewselectedPay.Columns.Add(dgvCol.Clone() as DataGridViewColumn);
            //}

            //DataGridViewRow row = new DataGridViewRow();
            //for (int i = 0; i < paymentsJanDataGridView.Rows.Count - 1; i++)
            //{
            //    //  int vonesa = 0;
            //    string debtserialcode = textBoxdebtserial.Text;
            //    string Paydebtserial = paymentsJanDataGridView.Rows[i].Cells[dataGridViewTextBoxColumn2.Index].Value.ToString();
            //    // int.TryParse(vonesaStr, out vonesa);
            //    if (debtserialcode == Paydebtserial)
            //    {
            //        row = (DataGridViewRow)paymentsJanDataGridView.Rows[i].Clone();
            //        int intColIndex = 0;
            //        foreach (DataGridViewCell cell in paymentsJanDataGridView.Rows[i].Cells)
            //        {
            //            row.Cells[intColIndex].Value = cell.Value;
            //            intColIndex++;
            //        }
            //        dataGridViewselectedPay.Rows.Add(row);
            //    }
            //}
            //dataGridViewselectedPay.AllowUserToAddRows = false;
            //dataGridViewselectedPay.Refresh();

            //string conStr = "Data Source=debitor.c8kumftnoykl.eu-central-1.rds.amazonaws.com,1433;Initial Catalog=ForAmazon;User ID=debitordata;Password=Trsdmr92l161";
            //SqlConnection con = new SqlConnection(conStr);
            //String Query = "select * from PaymentsJan Where Debt_Serial_Number=@serial";
            //SqlCommand command = new SqlCommand(Query, con);
            //command.Parameters.AddWithValue("@serial", textBoxdebtserial.Text);
            //DataSet ds = new DataSet();
            //SqlDataAdapter adapt = new SqlDataAdapter();
            //adapt.SelectCommand = command;
            //adapt.Fill(ds);
            //dataGridViewselectedPay.DataSource = ds;

            //try
            //{
            //    this.paymentsJanTableAdapter1.Collected(this.forAmazonDataSet.PaymentsJan, textBoxdebtserial.Text);
            //}
            //catch (System.Exception ex)
            //{
            //    System.Windows.Forms.MessageBox.Show(ex.Message);
            //}

            SqlConnection con = new SqlConnection(ConectionStr);
            DataTable dt = new DataTable();
            string collectAct = "select * from paymentsjan where debt_serial_number='" + textBoxdebtserial.Text + "' order by last_updated desc";
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = new SqlCommand(collectAct, con);
            adapt.Fill(dt);
            dataGridViewselectedPay.DataSource = dt;
        }

        private void comboBoxDB_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void comboBoxDBCollector_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void comboBoxReasg_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void comboBoxClSeg_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
      
        private void comboBoxClassification_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void ToolTips(object sender, EventArgs e)
        {
            toolTipAddres.SetToolTip(listBoxDadr, listBoxDadr.Text);
        }

        //private void TextBoxToolTip(object sender, EventArgs e)
        //{
        //    ToolTip texttool = new ToolTip();
        //    texttool.SetToolTip(listBoxRelAdr, listBoxRelAdr.Text);
        //}

        private void GuarantorToolTip(object sender, EventArgs e)
        {
            ToolTip texttool = new ToolTip();
            texttool.SetToolTip(listBoxGuarant, listBoxGuarant.Text);
        }

        //private void Tabselect(object sender, EventArgs e)
        //{

        //}

        private void dataGridViewNAmes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //dataGridViewDebtors.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Brown;
            //  int rowindex = e.RowIndex;// get row index of the clicked cell 

            if (e.RowIndex >= 0)
            {
                FAMID = dataGridViewNames.Rows[e.RowIndex].Cells[6].Value.ToString();
                NID = dataGridViewNames.Rows[e.RowIndex].Cells[7].Value.ToString();
            }


        }

        // Double CLICK event to find family
        private void dataGridViewNAmes_CellContentDOUBLEClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (e.ColumnIndex == 6)
                {
                    FAMID = dataGridViewNames.Rows[e.RowIndex].Cells[6].Value.ToString();
                    if (FAMID != "" && FAMID != null && FAMID != "-")
                    {
                        string ConnectionSkip = "Data Source=skipdbs.database.windows.net;Initial Catalog=SkipDtb;User ID=TotalDtb;Password=Trsdmr92l161";

                        DataTable dt = new DataTable();
                        SqlConnection con1 = new SqlConnection(ConnectionSkip);
                        SqlDataAdapter adapt = new SqlDataAdapter();

                        adapt.SelectCommand = new SqlCommand("FindFamily", con1);
                        adapt.SelectCommand.CommandType = CommandType.StoredProcedure;
                        adapt.SelectCommand.Parameters.AddWithValue("@famID", FAMID);
                        adapt.Fill(dt);

                        dataGridViewNames.DataSource = dt;
                        dataGridViewNames.Columns[6].DefaultCellStyle.ForeColor = Color.Red;
                        dataGridViewNames.Columns[10].Width = 200;
                        dataGridViewNames.Columns[9].Width = 40;
                        dataGridViewNames.Columns[0].Width = 60;
                        labelSkipRows.Text = "Rows: " + dataGridViewNames.RowCount;
                    }
                    else
                    {
                        MessageBox.Show("Përbërja familjare nuk mund të gjendet për\nshkak se mungon ID e familjes.", "Njoftim", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void CalculateData()
        {
            int RrjeshtatDebtor = dataGridViewDebtors.RowCount;//numri i rrjeshtave to tabeles debitore
            int RrjeshtatActions = dataGridViewAct.RowCount;//numri i rrjeshtave to tabeles actions

            for (int i = 0; i < RrjeshtatDebtor - 1; i++)
            {
                //string debtIdDebtor = null;
                string debtIdDebtor = dataGridViewDebtors.Rows[i].Cells[debtSerialNumberDataGridViewTextBoxColumn.Index].Value.ToString();//gjetja e debt id
                int NoAns = 0, Debtor = 0, other = 0, family = 0, nocontact = 0;// vlerat fillestare

                for (int j = 0; j < RrjeshtatActions - 1; j++)
                {
                    string debtIdActions = null;
                    debtIdActions = dataGridViewAct.Rows[j].Cells[debtSerialNumberDataGridViewTextBoxColumn1.Index].Value.ToString();//gjetja e debt id
                    string ActionStatus = dataGridViewAct.Rows[j].Cells[actionStatusDataGridViewTextBoxColumn.Index].Value.ToString();//gjetja e action status
                    if (debtIdDebtor == debtIdActions)
                    {
                        switch (ActionStatus)
                        {
                            case "No Answer":
                                NoAns++;
                                break;
                            case "Other":
                                other++;
                                break;
                            case "Debtor":
                                Debtor++;
                                break;
                            case "Family Member":
                                family++;
                                break;
                            default:
                                nocontact++;
                                break;
                        }// end switch
                    }// end if

                }//end for j
                //    string noAnswer = NoAns.ToString();
                //dataGridViewDebtors.Rows[i].Cells[noAnswerNrDataGridViewTextBoxColumn.Index].Value = NoAns;
                //dataGridViewDebtors.Rows[i].Cells[debtorNrDataGridViewTextBoxColumn.Index].Value = Debtor;
                //dataGridViewDebtors.Rows[i].Cells[otherNrDataGridViewTextBoxColumn.Index].Value = other;
                //dataGridViewDebtors.Rows[i].Cells[familyNrDataGridViewTextBoxColumn.Index].Value = family;
                //dataGridViewDebtors.Rows[i].Cells[noContactNrDataGridViewTextBoxColumn.Index].Value = nocontact;

                dataGridViewDebtors.Rows[i].Cells[27].Value = NoAns;
                dataGridViewDebtors.Rows[i].Cells[28].Value = Debtor;
                dataGridViewDebtors.Rows[i].Cells[29].Value = other;
                dataGridViewDebtors.Rows[i].Cells[30].Value = family;
                dataGridViewDebtors.Rows[i].Cells[31].Value = nocontact;

                //if (i==1000)
                //{
                ////    int x = 1;
                //}
            }//end for i
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //dataGridViewDebtors.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Brown;
            int rowindex = e.RowIndex;// get row index of the clicked cell 
            if (rowindex != rowIndex)
            {
                if (rowindex >= 0)
                {
                    NewMethod(rowindex);
                    // SystemSuggestion(rowindex);             
                    calcPayRate(rowindex);
                    calcPaymentDays();
                    CalcDialRate();
                    GetRelatedPers();
                    PersonDetails();
                }
            }
            rowIndex = rowindex;

        }

        private void dataGridViewKeyevent(object sender, KeyEventArgs args)
        {
            int rowindex = dataGridViewDebtors.CurrentCellAddress.Y;
            if (rowindex >= 0)
            {
                if (args.KeyCode == Keys.Down || args.KeyCode == Keys.Up)
                {
                    NewMethod(rowindex);
                    SystemSuggestion(rowindex);
                    calcPayRate(rowindex);
                    calcPaymentDays();
                    CalcDialRate();
                    GetRelatedPers();
                    PersonDetails();
                }
            }
        }
        private void NewMethod(int rowindex)
        {// fill the textBox DebtSerial with the value of  debtSerialNumberDataGridViewTextBoxColumn based on the the clicked cell row index.
            if (rowindex >= 0)
            {
                Clinstitution = dataGridViewDebtors.Rows[rowindex].Cells[clientDataGridViewTextBoxColumn.Index].Value.ToString();
                textBoxdfname.Text = dataGridViewDebtors.Rows[rowindex].Cells[debtorFullNameDataGridViewTextBoxColumn.Index].Value.ToString();
                textBoxStatus.Text = dataGridViewDebtors.Rows[rowindex].Cells[portfolioStatusDataGridViewTextBoxColumn.Index].Value.ToString();
                textBoxPort.Text = dataGridViewDebtors.Rows[rowindex].Cells[portfolioDataGridViewTextBoxColumn.Index].Value.ToString();
                textBoxint.Text = dataGridViewDebtors.Rows[rowindex].Cells[outstandingInterestDataGridViewTextBoxColumn.Index].Value.ToString();
                textBoxUser.Text = dataGridViewDebtors.Rows[rowindex].Cells[userIdDataGridViewTextBoxColumn.Index].Value.ToString();
                textBoxPrc.Text = dataGridViewDebtors.Rows[rowindex].Cells[outstandingPrincipalDataGridViewTextBoxColumn.Index].Value.ToString();
                textBoxUpd.Text = dataGridViewDebtors.Rows[rowindex].Cells[lastUpdatedDataGridViewTextBoxColumn.Index].Value.ToString();
                textBoxPTP.Text = dataGridViewDebtors.Rows[rowindex].Cells[pTPAmountDataGridViewTextBoxColumn.Index].Value.ToString();
                //pictureBoxClient.Image = dataGridViewDebtors.Rows[rowindex].Cells[ClientImage.Index].;
                textBoxAssigDAte.Text = dataGridViewDebtors.Rows[rowindex].Cells[assigmentDateDataGridViewTextBoxColumn.Index].Value.ToString();
                textBoxDayArray.Text = dataGridViewDebtors.Rows[rowindex].Cells[outstandingPenaltyDataGridViewTextBoxColumn.Index].Value.ToString();
                textBoxTotalAct.Text = dataGridViewDebtors.Rows[rowindex].Cells[contactedViaDataGridViewTextBoxColumn.Index].Value.ToString();
                textBoxDisbDate.Text = dataGridViewDebtors.Rows[rowindex].Cells[disbursmentDateDataGridViewTextBoxColumn.Index].Value.ToString();
                TextBoxDebtCurrency.Text = dataGridViewDebtors.Rows[rowindex].Cells[currencyDataGridViewTextBoxColumn.Index].Value.ToString();
                textBoxDayDelay.Text = dataGridViewDebtors.Rows[rowindex].Cells[daysInDelayDataGridViewTextBoxColumn.Index].Value.ToString();
                textBoxReaction.Text = dataGridViewDebtors.Rows[rowindex].Cells[reactionDataGridViewTextBoxColumn.Index].Value.ToString();
                Clinstitution = Clinstitution.ToLower();
                textBoxDebtType.Text = dataGridViewDebtors.Rows[rowindex].Cells[debtTypeDataGridViewTextBoxColumn.Index].Value.ToString();
                switch (Clinstitution.ToLower())
                {
                    case "telekom":
                        pictureBoxClient.Image = imageListClients.Images[7];
                        break;

                    case "teb":
                        pictureBoxClient.Image = imageListClients.Images[4];
                        break;

                    case "pro credit":
                        pictureBoxClient.Image = imageListClients.Images[5];
                        break;

                    case "pro credit kosova":
                        pictureBoxClient.Image = imageListClients.Images[5];
                        break;

                    case "albtelecom":
                        pictureBoxClient.Image = imageListClients.Images[0];
                        break;

                    case "iutecredit":
                        pictureBoxClient.Image = imageListClients.Images[3];
                        break;

                    case "besa":
                        pictureBoxClient.Image = imageListClients.Images[2];
                        break;

                    case "transatlantic petroleum":
                        pictureBoxClient.Image = imageListClients.Images[8];
                        break;

                    case "tecnoxgroup":
                        pictureBoxClient.Image = imageListClients.Images[8];
                        break;

                    case "societe general albania":
                        pictureBoxClient.Image = imageListClients.Images[6];
                        break;

                    case "raiffeisen bank kosovo":
                        pictureBoxClient.Image = imageListClients.Images[9];
                        break;

                    case "plus":
                        pictureBoxClient.Image = imageListClients.Images[10];
                        break;
                    case "union bank":
                        pictureBoxClient.Image = imageListClients.Images[11];
                        break;

                    case "ipko":
                        pictureBoxClient.Image = imageListClients.Images[12];
                        break;

                    case "iute credit":
                        pictureBoxClient.Image = imageListClients.Images[13];
                        break;

                    default:
                        pictureBoxClient.Image = imageListClients.Images[1];
                        break;
                }
                textBoxLastComment.Text = dataGridViewDebtors.Rows[rowindex].Cells[latestCommentDataGridViewTextBoxColumn.Index].Value.ToString();
                textBoxCollector.Text = dataGridViewDebtors.Rows[rowindex].Cells[debtCollectorDataGridViewTextBoxColumn.Index].Value.ToString();
                textBoxdebtserial.Text = dataGridViewDebtors.Rows[rowindex].Cells[debtSerialNumberDataGridViewTextBoxColumn.Index].Value.ToString();
                textBoxClients.Text = dataGridViewDebtors.Rows[rowindex].Cells[clientDataGridViewTextBoxColumn.Index].Value.ToString();
                textBoxClassification.Text = dataGridViewDebtors.Rows[rowindex].Cells[Classification.Index].Value.ToString();
                textBoxAmoInDelay.Text = dataGridViewDebtors.Rows[rowindex].Cells[amountInDelayDataGridViewTextBoxColumn.Index].Value.ToString();


                SqlConnection con = new SqlConnection(ConectionStr);
                string selectCollateral = "select top(1) serialNumber from collaterals where serialNumber='" + textBoxdebtserial.Text + "'";
                SqlCommand cmd = new SqlCommand(selectCollateral, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    textBoxHasCollateral.Text = "YES";
                }
                else
                {
                    textBoxHasCollateral.Text = "NO";
                }
                con.Close();


            }
        }

        private void calcPayRate(int rowindex)
        {
            double totalpaid = 0;
            //  double totalsum = 0;            
            //  double remainingAmt = 0;
            ///   string totalsums = dataGridViewDebtors.Rows[rowindex].Cells[totalOutstandingDataGridViewTextBoxColumn.Index].Value.ToString();
            //      totalsum = Convert.ToDouble(totalsums);
            // String query = "Select sum(Paid_Amount)from PaymentsJan where Debt_Serial_Number=@dserial";
            SqlConnection con = new SqlConnection(ConectionStr);

            SqlCommand cmd = new SqlCommand("PaidAmtProc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@dserial", textBoxdebtserial.Text);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (reader.IsDBNull(0) == false)
                {
                    totalpaid = reader.GetDouble(0);
                }

                else
                {
                    totalpaid = 0;
                    //   remainingAmt = totalsum;
                }
            }
            con.Close();

            //if (totalpaid>0)
            //{
            //    payrate = (totalpaid / totalsum)*100;
            //  //  remainingAmt = totalsum - totalpaid;
            //    if (payrate>=50)
            //    {
            //        textBoxPayRate.BackColor = Color.GreenYellow;
            //    } 
            //    else
            //    {
            //        textBoxPayRate.BackColor = Color.White;
            //    }
            //}
            //else
            //{
            //    payrate = 0;
            //    textBoxPayRate.BackColor = Color.White;
            //}        
            // textBoxPayRate.Text = payrate.ToString();
            textBoxRemainig.Text = dataGridViewDebtors.Rows[rowindex].Cells[totalOutstandingDataGridViewTextBoxColumn.Index].Value.ToString();
            textBoxTotalPaid.Text = totalpaid.ToString();

            //chartAMount.Series[0].Points.Clear();

            //chartAMount.Series[0].Points.Add(totalpaid).Label="Paid";
            //chartAMount.Series[0].Points.Add(remainingAmt).Label="Remaining";
        }
        private void CalcDialRate()
        {
            //int dial1=0;

            SqlConnection con = new SqlConnection(ConectionStr);
            //do not delete comments, they present stored procedures
            // String query = "select count(*) from ActionsJan where Debt_Serial_Number=@dserial";
            // String query1= "select count(*) from ActionsJan where Debt_Serial_Number=@dserial and Action_Status<>@actstat1 and Action_Status<>@actstat2";
            // string query2 = "Select count(*) from ActionsJAn where Debt_Serial_Number=@dserial and action_type like '%'+@atype+'%'";

            //    SqlCommand cmd = new SqlCommand("CountActionsProc", con);
            //   cmd.CommandType = CommandType.StoredProcedure;
            //  cmd.Parameters.AddWithValue("@dserial", textBoxdebtserial.Text);
            //     SqlCommand cmd1 = new SqlCommand("CountAnswersProc", con);
            //   cmd1.CommandType = CommandType.StoredProcedure;

            //  cmd1.Parameters.AddWithValue("@dserial", textBoxdebtserial.Text);
            //   cmd1.Parameters.AddWithValue("@actstat1", "No Contact");
            //  cmd1.Parameters.AddWithValue("@actstat2", "No Answer");
            SqlCommand cmd2 = new SqlCommand("ActionTypeProc", con);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@dserial", textBoxdebtserial.Text);
            cmd2.Parameters.AddWithValue("@atype", "SMS");
            //con.Open();
            //SqlDataReader reader = cmd.ExecuteReader();

            //    while (reader.Read())//count total actions
            //    {
            //         actnr = reader.GetInt32(0);                  
            //    }
            //con.Close();

            //con.Open();
            //reader = cmd1.ExecuteReader();
            //while (reader.Read())//count actions with contact
            //{
            //     dial1 = reader.GetInt32(0);
            //}
            //con.Close();
            //if (actnr>0)
            //{
            //    double outDial = Convert.ToDouble(dial1);
            //    double outAct = Convert.ToDouble(actnr);
            //    dial_rate = (outDial/outAct)*100;
            //}
            //else
            //{
            //    dial_rate = 0;
            //}

            con.Open();
            SqlDataReader reader = cmd2.ExecuteReader();
            while (reader.Read())//count total SMS
            {
                if (reader.IsDBNull(0) == false)
                {
                    SMS = reader.GetInt32(0);
                }
                else
                {
                    SMS = 0;
                }
            }
            con.Close();

            cmd2.Parameters.Clear();

            cmd2.Parameters.AddWithValue("@dserial", textBoxdebtserial.Text);
            cmd2.Parameters.AddWithValue("@atype", "letter sent");
            con.Open();
            reader = cmd2.ExecuteReader();
            while (reader.Read())//count total SMS
            {
                if (reader.IsDBNull(0) == false)
                {
                    letter = reader.GetInt32(0);
                }
                else
                {
                    letter = 0;
                }
            }
            con.Close();

            cmd2.Parameters.Clear();

            cmd2.Parameters.AddWithValue("@dserial", textBoxdebtserial.Text);
            cmd2.Parameters.AddWithValue("@atype", "field");
            con.Open();
            reader = cmd2.ExecuteReader();
            while (reader.Read())//count total SMS
            {
                if (reader.IsDBNull(0) == false)
                {
                    field = reader.GetInt32(0);
                }
                else
                {
                    field = 0;
                }
            }
            con.Close();
            cmd2.Parameters.Clear();

            cmd2.Parameters.AddWithValue("@dserial", textBoxdebtserial.Text);
            cmd2.Parameters.AddWithValue("@atype", "skip");
            con.Open();
            reader = cmd2.ExecuteReader();
            while (reader.Read())//count total SMS
            {
                if (reader.IsDBNull(0) == false)
                {
                    skip = reader.GetInt32(0);
                }
                else
                {
                    skip = 0;
                }
            }
            con.Close();


            // textBoxDialRate.Text = dial_rate.ToString();
            // textBoxTotalAct.Text = actnr.ToString();
            textBoxSMS.Text = SMS.ToString();
            textBoxLetters.Text = letter.ToString();
            textBoxField.Text = field.ToString();
            textBoxSkip.Text = skip.ToString();

            //chartActions.Series[0].Points.Clear();            
            //chartActions.Series[0].Points.Add(actnr).Label="Achived";
            //chartActions.Series[0].Points.Add(7).Label="objective";
            //
        }

        private void calcPaymentDays()
        {
            DateTime dt = DateTime.Today;
            DateTime dt2 = DateTime.Today;
            //String query = "Select Top(1) Last_Updated from PaymentsJan where Debt_Serial_Number=@dserial";
            SqlConnection con = new SqlConnection(ConectionStr);
            SqlCommand cmd = new SqlCommand("CountDaysProc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@dserial", textBoxdebtserial.Text);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (reader.IsDBNull(0) == false)
                {
                    dt2 = reader.GetDateTime(0);
                }

                else
                {
                    days = 1000;
                }
            }
            con.Close();
            int months = 0;
            if (dt2 != DateTime.Today)
            {
                days = (dt.Date - dt2.Date).Days;
                months = days / 30;
                textBoxDaysUntil.Text = months.ToString();
            }
            else
            {
                textBoxDaysUntil.Text = "No payments";
            }

        }

        private void GetRelatedPers()
        {
            // string RelAddress = "";
            listBoxGuarant.Items.Clear();
            listViewRelPhone.Items.Clear();
            //   listBoxRelAdr.Items.Clear();
            //String query = "Select Top(1) First_Name,District,Address,Phone_1,Phone_2 from Persons where Person_Number=@dserial and First_Name<>''";
            SqlConnection con = new SqlConnection(ConectionStr);
            SqlCommand cmd = new SqlCommand("RelatedContactProc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@dserial", textBoxdebtserial.Text);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (reader.IsDBNull(0) == false)
                {
                    listBoxGuarant.Items.Add(reader.GetString(0));
                }
                for (int i = 1; i < 5; i++)
                {
                    if (reader.IsDBNull(i) == false)
                    {
                        if (reader.GetString(i) != null && reader.GetString(i) != "")
                        {
                            listViewRelPhone.Items.Add(reader.GetString(i));
                        }
                    }
                }

            }
            con.Close();

            for (int i = 0; i < listViewRelPhone.Items.Count; i++)
            {
                string VerifyNumber = "select action_status from (select ROW_NUMBER() OVER (ORDER BY id desc) as ROWNO,action_status from ActionsJan where othercontact='" + listViewRelPhone.Items[i].Text + "' and action_type='phone call' and debt_serial_number='" + textBoxdebtserial.Text + "') ActionsJan where ROWNO= 1";
                cmd = new SqlCommand(VerifyNumber, con);
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.IsDBNull(0) == false)
                    {
                        if (reader.GetString(0).ToLower() == "no answer")
                        {
                            listViewRelPhone.Items[i].ForeColor = Color.Orange;
                        }

                        else if (reader.GetString(0).ToLower() == "no contact")
                        {
                            listViewRelPhone.Items[i].ForeColor = Color.Red;
                        }
                        else
                        {
                            listViewRelPhone.Items[i].ForeColor = Color.Green;
                        }
                    }

                    else
                    {
                        listViewRelPhone.Items[i].ForeColor = Color.Black;
                    }


                }
                con.Close();

            }
        }

        private void PersonDetails()
        {
            listViewPhone.Items.Clear();
            listBoxDadr.Items.Clear();
            string address = "";
            string fillListbox = "select Phone_1,Phone_2,Phone_3, Phone_4 from persons where Person_Number=@dserial and relation='debtor'";
            string fillAdress = "select District, Address from persons where Person_Number=@dserial and relation='debtor'";

            //String query = "Select Top(1) District,Address,Phone_1,Phone_2,Phone_3 from Persons where Person_Number=@dserial and First_Name=''";
            SqlConnection con = new SqlConnection(ConectionStr);
            //   SqlCommand cmd = new SqlCommand("PersonDetailsProc", con);
            SqlCommand com = new SqlCommand(fillListbox, con);

            com.Parameters.AddWithValue("@dserial", textBoxdebtserial.Text);

            //    cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < 4; i++)
                {
                    if (reader.IsDBNull(i) == false)
                    {
                        if (reader.GetString(i) != "")
                        {
                            listViewPhone.Items.Add(reader.GetString(i));
                        }
                    }
                }
            }
            con.Close();
            com.Parameters.Clear();
            com = new SqlCommand(fillAdress, con);
            com.Parameters.AddWithValue("@dserial", textBoxdebtserial.Text);
            con.Open();
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                address = "";

                if (reader.IsDBNull(0) == false)
                {
                    address = reader.GetString(0);
                }

                if (reader.IsDBNull(1) == false)
                {
                    address += ", " + reader.GetString(1);
                }

                listBoxDadr.Items.Add(address);
            }
            con.Close();

            //listViewPhone.Items[0].ForeColor = Color.Green;
            for (int i = 0; i < listViewPhone.Items.Count; i++)
            {
                string VerifyNumber = "select action_status from (select ROW_NUMBER() OVER (ORDER BY id desc) as ROWNO,action_status from ActionsJan where othercontact='" + listViewPhone.Items[i].Text + "' and action_type='phone call' and debt_serial_number='" + textBoxdebtserial.Text + "') ActionsJan where ROWNO= 1";
                com = new SqlCommand(VerifyNumber, con);
                con.Open();
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.IsDBNull(0) == false)
                    {
                        if (reader.GetString(0).ToLower() == "no answer")
                        {
                            listViewPhone.Items[i].ForeColor = Color.Orange;
                        }

                        else if (reader.GetString(0).ToLower() == "no contact")
                        {
                            listViewPhone.Items[i].ForeColor = Color.Red;
                        }
                        else
                        {
                            listViewPhone.Items[i].ForeColor = Color.Green;
                        }

                    }


                    else
                    {
                        listViewPhone.Items[i].ForeColor = Color.Black;
                    }


                }
                con.Close();

            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //textBox8.Text = dataGridViewAct.RowCount.ToString();
            // CalculateData();
        }

        private void tabPageAct_Click(object sender, EventArgs e)
        {
            ////        //  this.dataGridViewselectedactions.Rows.Clear();
            ////        if (textBoxdebtserial.Text=="1")
            ////        { 
            ////        string conectionstr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\SystemDebtors.mdf;Integrated Security=True;Connect Timeout=60";
            //////  string amznString= "Data Source=debitor.c8kumftnoykl.eu-central-1.rds.amazonaws.com,1433;Initial Catalog=ForAmazon;User ID=debitordata;Password=Trsdmr92l161";
            ////            DataTable table = new DataTable();

            ////            using (SqlConnection connection = new SqlConnection(conectionstr))
            ////            {
            ////                DataTableMapping mapping = new DataTableMapping("ActionsJan", "Table");
            ////                SqlDataAdapter adapter = new SqlDataAdapter(
            ////                  "SELECT * From  ActionsJan Where Debt_Serial_Number=" + this.textBoxdebtserial.Text +"", connection);

            ////                adapter.TableMappings.Add(mapping);
            ////                mapping.ColumnMappings.Add("ID", "ID");
            ////                mapping.ColumnMappings.Add("Debt_Serial_Number", "Debt_Serial_Number");
            ////                mapping.ColumnMappings.Add("Person_Full_Name", "Person_Full_Name");
            ////                mapping.ColumnMappings.Add("Client_Institution", "Client_Institution");
            ////                mapping.ColumnMappings.Add("Action_Type", "Action_Type");
            ////                mapping.ColumnMappings.Add("Action_Status", "Action_Status");
            ////                mapping.ColumnMappings.Add("Action_Date", "Action_Date");
            ////                mapping.ColumnMappings.Add("Comments", "Comments");
            ////                mapping.ColumnMappings.Add("User_Id", "User_Id");
            ////                mapping.ColumnMappings.Add("Last_Updated", "Last_Updated");
            ////                SqlCommand cmd = new SqlCommand();

            ////                connection.Open();
            ////                DataSet ds = new DataSet();
            ////            //    adapter.FillSchema(table, SchemaType.Mapped);
            ////                adapter.Fill(ds,"Table");
            ////                dataGridViewselectedactions.DataSource = ds.DefaultViewManager;
            ////                connection.Close();
            ////             //   return table;
            ////            }
            ////        }
            ////        else
            ////        {
            ////            MessageBox.Show("Please select a debtor", "Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
            ////        }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (textBoxdebtserial.Text != "")
            {
                Form user_rpt = Application.OpenForms["NewActionForm"];
                if (user_rpt == null)
                {
                    NewActionForm nacf = new NewActionForm();

                    nacf.Show();
                    DailyActions(usernamevalue);
                }
                else
                {
                    MessageBox.Show("Action window is already open", "Window", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                Message();
            }
        }


        private void buttonNewPayment_Click(object sender, EventArgs e)
        {

            if (textBoxdebtserial.Text != "")
            {
                NewPayment newPay = new NewPayment();
                newPay.ShowDialog();
            }
            else
            {
                Message();
            }
        }

        private void ToCsV(DataGridView dGV, string filename)
        {
            int x = 0;
            switch (tabControl1.SelectedIndex)
            {
                case 0: x = dataGridViewDebtors.Rows.Count;
                    break;
                case 1:
                    x = dataGridViewAct.Rows.Count;
                    break;
                case 2:
                    x = paymentsJanDataGridView.Rows.Count;
                    break;
                case 3:
                    x = dataGridViewPersons.Rows.Count;
                    break;
                case 4:
                    x = dataGridViewStaticCollectors.Rows.Count;
                    break;
            }
            string stOutput = "";
            // Export titles:
            string sHeaders = "";

            for (int j = 0; j < dGV.Columns.Count; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].DataPropertyName) + "\t";
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

        private void ExportToExcel(DataGridView dgv)
        {
            // Creating a Excel object. 
            //Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            //Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            //Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            //try
            //{

            //    worksheet = workbook.ActiveSheet;

            //    worksheet.Name = "ExportedFromDatGrid";

            //    int cellRowIndex = 1;
            //    int cellColumnIndex = 1;

            //    //Loop through each row and read value from each column. 
            //    for (int i = 0; i < dgv.Rows.Count; i++)
            //    {
            //        for (int j = 0; j < dgv.Columns.Count; j++)
            //        {
            //            // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
            //            if (cellRowIndex == 1)
            //            {
            //                worksheet.Cells[cellRowIndex, cellColumnIndex] = dgv.Columns[j].HeaderText;
            //            }
            //            else
            //            {
            //                worksheet.Cells[cellRowIndex, cellColumnIndex] = dgv.Rows[i].Cells[j].Value.ToString();
            //            }
            //            cellColumnIndex++;
            //        }
            //        cellColumnIndex = 1;
            //        cellRowIndex++;
            //    }

            //Getting the location and file name of the excel to save from user. 
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Excel files (*.xls)|*.xls";
            saveDialog.FilterIndex = 2;
            saveDialog.FileName = "Exported Report " + DateTime.Today.ToString("dd-MMM-yy") + ".xls";

            if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int x = dataGridViewStaticCollectors.Rows.Count;
                string stOutput = "";
                // Export titles:
                string sHeaders = "";

                for (int j = 0; j < dgv.Columns.Count; j++)
                    sHeaders = sHeaders.ToString() + Convert.ToString(dgv.Columns[j].DataPropertyName) + "\t";
                stOutput += sHeaders + "\r\n";
                // Export data.

                for (int i = 0; i < x; i++)
                {
                    string stLine = "";
                    for (int j = 0; j < dgv.Rows[i].Cells.Count; j++)
                        stLine = stLine.ToString() + Convert.ToString(dgv.Rows[i].Cells[j].Value) + "\t";
                    stOutput += stLine + "\r\n";
                }

                Encoding utf16 = Encoding.GetEncoding(1254);
                byte[] output = utf16.GetBytes(stOutput);
                FileStream fs = new FileStream(saveDialog.FileName, FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(output, 0, output.Length); //write the encoded file
                bw.Flush();
                bw.Close();
                fs.Close();

            }
            //}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    excel.Quit();
            //    workbook = null;
            //    excel = null;
            //}

        }



        private void ToExcelCsV(string filename)
        {
            // int x = 0;
            //if (checkBoxNoact.Checked == true)//check for debts that do not have actions
            //{
            //    noActionsQ = "and Debt_Serial_Number not in (select Debt_Serial_Number from actionsjan)";
            //}
            //else
            //{
            //    noActionsQ = "";
            //}
            ////check for debts that do not have Payments
            //if (checkBoxNoPay.Checked == true)
            //{
            //    noPaymentsQ = "and Debt_Serial_Number not in (select Debt_Serial_Number from paymentsJan)";
            //}
            //else
            //{
            //    noPaymentsQ = "";
            //}

            //if (textBoxTotOut.Text == "" || textBoxTotOut.Text == null)
            //{
            //    SumQyery = "";
            //}

            //if (textBoxPrTP.Text == "" || textBoxPrTP.Text == null)
            //{
            //    PTPQuery = "";
            //}
            //if (comboBoxClientDb.Text == "" || comboBoxClientDb.Text == null)
            //{
            //    clientvalue = "%";
            //}
            ////if (comboBoxPorto.Text == "" || comboBoxClientDb.Text == null)
            ////{
            ////    portovalue = "%";
            ////}
            //if (comboBoxPeriod.Text == "" || comboBoxPeriod.Text == null)
            //{
            //    DateQuery = "";
            //}

            //if (comboBoxUpdated.Text == "" || comboBoxUpdated.Text == null)
            //{
            //    UpdatedQuery = "";
            //}

            //if (comboBoxAsgDate.Text == "" || comboBoxAsgDate.Text == null)
            //{
            //    AsgQuery = "";
            //}

            //if (comboBoxCurrDb.Text == "")
            //{
            //    currencyvalue = "%";
            //}
            //if (comboBoxLcp.Text == "")
            //{
            //    LastCp = "";
            //}
            //if (comboBox2.Text == "")
            //{
            //    ReactionQuery = "";
            //}

            //if (comboBoxActionType.Text == "")
            //{
            //    ActionQuery = "";
            //}

            //if (textBoxClassif.Text == "" || textBoxClassif.Text == null)
            //{
            //    classQuery = "";
            //}

            //if (textBoxBranchId.Text == "" || textBoxBranchId.Text == null)
            //{
            //    BranchQuery = "";
            //}
            //if (comboBoxPStatus.Text == "" || comboBoxPStatus.Text == null)
            //{
            //    pstatusvalue = "%";
            //}

            //if (textBoxDebtorDistrict.Text == "" || textBoxDebtorDistrict.Text == null)
            //{
            //    DebtDistrictQuery = "";
            //}

            //if (textBoxInfoSource.Text == "" || textBoxInfoSource == null)
            //{
            //    SourceQuery = "";
            //}

            //if (comboBoxReasg.Text == "" || comboBoxReasg.Text == null)
            //{
            //    ReasgQuery = "";
            //}

            //if (comboBoxDbCollector.Text == "" || comboBoxDbCollector.Text == null)
            //{
            //    collectorvalue = "%";
            //}
            //else
            //{
            //    collectorvalue = comboBoxDbCollector.Text + "%";
            //}

            //string Search = "select top(5000) * from debtorsactive,persons where ";
            //Search += " client " + clientcheck + "'" + clientvalue + "'" + " and portfolio " + portocheck + "'" + portovalue + "'" +
            //    " and portfolio_status " + pstatuscheck + "'" + pstatusvalue + "'" + " and debt_collector " + collectorcheck +
            //   "'" + collectorvalue + "'" + " and currency " + currencyCheck + "'" + currencyvalue + "'" +
            //   SumQyery + DateQuery+ReasgQuery+SourceQuery + PTPQuery + LastCp + classQuery +BranchQuery+DebtDistrictQuery+ ReactionQuery +ActionQuery+ UpdatedQuery + AsgQuery + noPaymentsQ + noActionsQ + " and debtorsactive.debt_serial_number=persons.person_number order by debtor_full_name asc";

            GetExportDebts();
            //  SqlConnection con = new SqlConnection(ConectionStr);
            //  SqlDataAdapter adapt = new SqlDataAdapter();
            //  adapt.SelectCommand = new SqlCommand(Search, con);

            //  DataTable dt = new DataTable();

            //  adapt.Fill(dt);

            //  dataGridViewBill.DataSource = dt;
            ////  SetClientLogo();
            //  labelRowCount.Text = "Results: " + dataGridViewDebtors.RowCount;

            // tabControl.SelectedTab = tabPageDebts;
            // textBoxdebtserial.Text = "";
            // rowIndex = -2;


            string stOutput = "";
            // Export titles:
            string sHeaders = "";

            for (int j = 0; j < dataGridViewBill.Columns.Count; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dataGridViewBill.Columns[j].HeaderText) + "\t";
            stOutput += sHeaders + "\r\n";
            // Export data.
            // x = dGV.Columns.Count;
            for (int i = 0; i < dataGridViewBill.Rows.Count; i++)
            {
                string stLine = "";
                for (int z = 0; z < dataGridViewBill.Rows[i].Cells.Count; z++)
                    stLine = stLine.ToString() + Convert.ToString(dataGridViewBill.Rows[i].Cells[z].Value) + "\t";
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

        private void GetExportDebts()
        {

            SqlConnection con = new SqlConnection(ConectionStr);
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = new SqlCommand("FilterExportDebts", con);
            adapt.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapt.SelectCommand.Parameters.AddWithValue("@yesno", checkBoxClient.Checked == false ? "0" : "1");
            adapt.SelectCommand.Parameters.AddWithValue("@Client", comboBoxClientDb.SelectedItem == null ? null : comboBoxClientDb.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@bitportfolio", checkBoxPorto.Checked == false ? "0" : "1");
            adapt.SelectCommand.Parameters.AddWithValue("@portfolio", comboBoxPorto.SelectedItem == null ? null : comboBoxPorto.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@bitpStatus", checkBoxPstatus.Checked == false ? "0" : "1");
            adapt.SelectCommand.Parameters.AddWithValue("@portfolio_status", comboBoxPStatus.SelectedItem == null ? null : comboBoxPStatus.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@bitCollector", checkBoxColl.Checked == false ? "0" : "1");
            adapt.SelectCommand.Parameters.AddWithValue("@Collector", comboBoxDbCollector.SelectedItem == null ? null : comboBoxDbCollector.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@EqLessMo", comboBoxMore.SelectedItem == null ? null : comboBoxMore.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@total", textBoxTotOut.Text == null ? "0" : textBoxTotOut.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@currency", comboBoxCurrDb.SelectedItem == null ? null : comboBoxCurrDb.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@EqDate", comboBoxPeriod.SelectedItem == null ? null : comboBoxPeriod.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@nexdate", dateTimePickerDb.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@eqPtp", comboBoxPromise.SelectedItem == null ? null : comboBoxPromise.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@ptp", textBoxPrTP.Text == "" ? null : textBoxPrTP.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@bitcontacted", checkBoxLCP.Checked == false ? "0" : "1");
            adapt.SelectCommand.Parameters.AddWithValue("@contacted", comboBoxLcp.SelectedItem == null ? null : comboBoxLcp.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@classif", textBoxClassif.Text == "" ? null : textBoxClassif.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@bitCheck", checkBoxCheck.Checked == false ? "0" : "1");
            adapt.SelectCommand.Parameters.AddWithValue("@checkinfo", textBoxBranchId.Text == "" ? null : textBoxBranchId.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@reaction", comboBox2.SelectedItem == null ? null : comboBox2.Text);//KUJDES
            adapt.SelectCommand.Parameters.AddWithValue("@actType", comboBoxActionType.SelectedItem == null ? null : comboBoxActionType.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@eqLdate", comboBoxUpdated.SelectedItem == null ? null : comboBoxUpdated.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@lastDate", dateTimePickerUpdated.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@eqAsdate", comboBoxAsgDate.SelectedItem == null ? null : comboBoxAsgDate.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@AsDate", dateTimePickerAsgDate.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@eqRedate", comboBoxReasg.SelectedItem == null ? null : comboBoxReasg.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@ReDate", dateTimePickerReasg.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@source", textBoxInfoSource.Text == "" ? null : textBoxInfoSource.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@addresses", textBoxDebtorDistrict.Text == "" ? null : textBoxDebtorDistrict.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@bitAction", checkBoxNoact.Checked == false ? null : "1");
            adapt.SelectCommand.Parameters.AddWithValue("@bitPayment", checkBoxNoPay.Checked == false ? null : "1");
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridViewBill.DataSource = dt;
            labelRowCount.Text = "Results: " + dataGridViewDebtors.RowCount;

        }

        private void ExportDebts(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Exported_Debts_" + DateTime.Today.ToString("dd-MMM-yy") + ".xls";
            if (MessageBox.Show("Do you want to export even related contact?",
                               "Double export",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ToExcelCsV(sfd.FileName);
                    // Here dataGridview1 is your grid view name
                }
            }
            else
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ToCsV(dataGridViewDebtors, sfd.FileName);
                    // Here dataGridview1 is your grid view name
                }
            }

        }

        private void groupBoxFilterdb_Enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonAdvancedF_Click(sender, e);
            }
        }

        private void ButtonAdvancedFilter_Enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonAdvancedF_Click(sender, e);
            }
        }
        private void GetSearchData(object sender, DoWorkEventArgs e)
        {
            int indeks = 0;
            string searched = textBoxSearch.Text;
            BackgroundWorker bgWorker1 = (BackgroundWorker)sender;
            if (searched != "" && searched != null && searched != " " && searched != "%")
            {
                if (comboBoxSearch.InvokeRequired)
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        indeks = comboBoxSearch.SelectedIndex;
                    });
                    if (indeks == 2)
                    {
                        try
                        {
                            string selectSerial = "select * from debtorsactive where debt_serial_number='" + searched + "'";
                            SqlConnection con = new SqlConnection(ConectionStr);
                            SqlDataAdapter adapt = new SqlDataAdapter();
                            adapt.SelectCommand = new SqlCommand(selectSerial, con);

                            DataTable dt = new DataTable();
                            adapt.Fill(dt);
                            dtSearch = dt;
                            //dataGridViewDebtors.DataSource = dt;
                            //SetClientLogo();
                            //labelRowCount.Text = "Results: " + dataGridViewDebtors.RowCount;

                        }
                        catch (System.Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show(ex.Message);
                        }
                    }

                    else if (indeks == 1)
                    {

                        try
                        {
                            string selectByNr = "SELECT DebtorsActive.* FROM (Persons INNER JOIN DebtorsActive " +
                               "ON Persons.Person_Number = DebtorsActive.Debt_Serial_Number )" +
                                 " GROUP BY DebtorsActive.Debt_Serial_Number, debt_id,client,Debt_Type,Debtor_Full_Name,Portfolio_Status ,Latest_Comment,Outstanding_Principal," +
                                 " Outstanding_Interest,Outstanding_Penalty,Currency,Portfolio,Debt_Collector,Total_Outstanding,Latest_Person_Contacted,Assigment_Date,Client_Branch,Next_Action_Date," +
                                 " DebtorsActive.Reaction,DebtorsActive.Last_Updated,DebtorsActive.User_Id,Last_Act_type,ContactedVia,PTP_Amount ,[CloseDate] ,[BranchId]  ,[DisbursmentDate]  ,[FinishedDate],[LoanTenure] ,[PmtRepayment],[AvgMoRepayment]  ,[PMTpercentage]  ," +
                                 " [RestructuredContract],[IsRestructured],[MonthsFromDisbursment],[MonthRecoveryRate],[RecoveryPeriod],[FPD],[DisbursmentAmount],reassigned,[InALL_Base],[AmountInDelay],[PrincipalDelay],[InterestDelay],[UpComingInterest],[ClientSegment],[ProductID],[DaysInDelay],[Mortgage],[Pledge],[CashColateral],Risk,classification,linkID,PayAccNo,AssignmentDebt,contractStatusId,Phone_1,Phone_2,Phone_3,phone_4 " +
                                  " HAVING Persons.Phone_1 like '" + searched + "'  or Persons.Phone_2 like '" + searched + "' or Persons.Phone_3 like '" + searched + "' or Persons.Phone_4 like '" + searched + "' ";
                            SqlConnection con = new SqlConnection(ConectionStr);
                            SqlDataAdapter adapt = new SqlDataAdapter();
                            adapt.SelectCommand = new SqlCommand(selectByNr, con);

                            DataTable dt = new DataTable();
                            adapt.Fill(dt);
                            dtSearch = dt;
                            //dataGridViewDebtors.DataSource = dt;
                            //SetClientLogo();
                            //labelRowCount.Text = "Results: " + dataGridViewDebtors.RowCount;
                        }

                        catch (System.Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show(ex.Message);
                        }

                    }

                    else if (indeks == 0)
                    {
                        try
                        {
                            // this.debtorsActiveTableAdapter1.KerkoDebitor(this.forAmazonDataSet.DebtorsActive, "%", "%" + textBoxSearch.Text + "%");
                            //SetClientLogo();
                            // labelRowCount.Text = "Results: " + dataGridViewDebtors.RowCount.ToString();
                            string selectSerial = "select * from debtorsactive where debtor_full_name like '" + searched + "%' order by debtor_full_name asc";
                            SqlConnection con = new SqlConnection(ConectionStr);
                            SqlDataAdapter adapt = new SqlDataAdapter();
                            adapt.SelectCommand = new SqlCommand(selectSerial, con);

                            DataTable dt = new DataTable();
                            adapt.Fill(dt);
                            dtSearch = dt;
                            //dataGridViewDebtors.DataSource = dt;
                            //SetClientLogo();
                            //labelRowCount.Text = "Results: " + dataGridViewDebtors.RowCount;

                        }
                        catch (System.Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show(ex.Message);
                        }
                    }

                    else
                    {
                        try
                        {
                            // this.debtorsActiveTableAdapter1.KerkoDebitor(this.forAmazonDataSet.DebtorsActive, "%", "%" + textBoxSearch.Text + "%");
                            //SetClientLogo();
                            // labelRowCount.Text = "Results: " + dataGridViewDebtors.RowCount.ToString();
                            //string selectSerial = "select * from debtorsactive where debtor_full_name like '%' +@searched + '%' or debt_serial_number=@searched  " +
                            //    " or latest_comment like '%'+@searched+'%' or contactedvia like  @searched + '%' or debt_serial_number in ( select person_number from persons " +
                            //    " where phone_1 like @searched + '%' or phone_2 like @searched + '%' or phone_3 like @searched + '%' or phone_4 like  searched + '%' or first_name like @searched + '%') order by debtor_full_name asc ";
                            SqlConnection con = new SqlConnection(ConectionStr);
                            SqlDataAdapter adapt = new SqlDataAdapter();
                            adapt.SelectCommand = new SqlCommand("FastSearch", con);
                            adapt.SelectCommand.CommandType = CommandType.StoredProcedure;
                            adapt.SelectCommand.Parameters.AddWithValue("@searched", searched);

                            DataTable dt = new DataTable();
                            adapt.Fill(dt);
                            dtSearch = dt;
                            //dataGridViewDebtors.DataSource = dt;
                            //SetClientLogo();
                            //labelRowCount.Text = "Results: " + dataGridViewDebtors.RowCount;

                        }
                        catch (System.Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show(ex.Message);
                        }
                    }
                }


            }

        }

        void work_complete_Search(object sender, RunWorkerCompletedEventArgs e)
        {
            string searched = textBoxSearch.Text;
            textBoxSearch.Enabled = true;
            buttonAdvancedF.Enabled = true;
            dataGridViewDebtors.DataSource = dtSearch;
            SetClientLogo();
            labelRowCount.Text = "Results: " + dataGridViewDebtors.RowCount;

            History.Add(searched);
            pointer = History.Count - 1;
            string timeFormat = "dd MMM yyyy HH:mm";
            string Timestamp = DateTime.Now.ToString(timeFormat);
            StreamWriter Save = new StreamWriter(Savehistory, true);

            Save.WriteLine(Timestamp + " " + searched);
            Save.Close();
            searched = null;
            tabControl.SelectedTab = tabPageDebts;
            tabControl1.SelectedTab = tabPageDebtors;
            textBoxdebtserial.Text = "";

            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in groupBox7.Controls)
                    if (control is TextBox)
                        (control as TextBox).Text = "";
                foreach (Control control in groupBox4.Controls)
                    if (control is ListBox)
                        (control as ListBox).Items.Clear();
                foreach (Control control in groupBoxActDetail.Controls)
                    if (control is TextBox)
                        (control as TextBox).Text = "";

            };

            func(Controls);
            rowIndex = -2;
        }

        private void textboxSearch(object sender, KeyEventArgs e)
        {

            string searched = textBoxSearch.Text;
            if (e.KeyCode == Keys.Enter)
            {
                worker2.RunWorkerAsync();
                textBoxSearch.Enabled = false;
                buttonAdvancedF.Enabled = false;
                //if (searched != "" && searched != null && searched != " " && searched != "%")
                //{
                //    if (comboBoxSearch.SelectedIndex == 2)
                //    {
                //        try
                //        {
                //            //debtorsActiveTableAdapter1.KerkoDebitor(this.forAmazonDataSet.DebtorsActive, textBoxSearch.Text, "%");
                //            //SetClientLogo();
                //            //labelRowCount.Text= "Results: " + dataGridViewDebtors.RowCount.ToString();

                //            //string selectSerial = "select * from debtorsactive where debt_serial_number='" + searched + "'";
                //            //SqlConnection con = new SqlConnection(ConectionStr);
                //            //SqlDataAdapter adapt = new SqlDataAdapter();
                //            //adapt.SelectCommand = new SqlCommand(selectSerial, con);

                //            //DataTable dt = new DataTable();
                //            //adapt.Fill(dt);
                //            dataGridViewDebtors.DataSource = dt;
                //            SetClientLogo();
                //            labelRowCount.Text = "Results: " + dataGridViewDebtors.RowCount;

                //        }
                //        catch (System.Exception ex)
                //        {
                //            System.Windows.Forms.MessageBox.Show(ex.Message);
                //        }
                //    }

                //    else if (comboBoxSearch.SelectedIndex == 1)
                //    {

                //        try
                //        {
                //            //string selectByNr = "SELECT DebtorsActive.* FROM (Persons INNER JOIN DebtorsActive " +
                //            //   "ON Persons.Person_Number = DebtorsActive.Debt_Serial_Number )" +
                //            //     " GROUP BY DebtorsActive.Debt_Serial_Number, debt_id,client,Debt_Type,Debtor_Full_Name,Portfolio_Status ,Latest_Comment,Outstanding_Principal," +
                //            //     " Outstanding_Interest,Outstanding_Penalty,Currency,Portfolio,Debt_Collector,Total_Outstanding,Latest_Person_Contacted,Assigment_Date,Client_Branch,Next_Action_Date," +
                //            //     " DebtorsActive.Reaction,DebtorsActive.Last_Updated,DebtorsActive.User_Id,Last_Act_type,ContactedVia,PTP_Amount ,[CloseDate] ,[BranchId]  ,[DisbursmentDate]  ,[FinishedDate],[LoanTenure] ,[PmtRepayment],[AvgMoRepayment]  ,[PMTpercentage]  ," +
                //            //     " [RestructuredContract],[IsRestructured],[MonthsFromDisbursment],[MonthRecoveryRate],[RecoveryPeriod],[FPD],[DisbursmentAmount],reassigned,[InALL_Base],[AmountInDelay],[PrincipalDelay],[InterestDelay],[UpComingInterest],[ClientSegment],[ProductID],[DaysInDelay],[Mortgage],[Pledge],[CashColateral],Risk,classification,linkID,PayAccNo,AssignmentDebt,contractStatusId,Phone_1,Phone_2,Phone_3,phone_4 " +
                //            //      " HAVING Persons.Phone_1 like '" + searched + "'  or Persons.Phone_2 like '" + searched + "' or Persons.Phone_3 like '" + searched + "' or Persons.Phone_4 like '" + searched + "' ";
                //            //SqlConnection con = new SqlConnection(ConectionStr);
                //            //SqlDataAdapter adapt = new SqlDataAdapter();
                //            //adapt.SelectCommand = new SqlCommand(selectByNr, con);

                //            //DataTable dt = new DataTable();
                //            //adapt.Fill(dt);
                //            dataGridViewDebtors.DataSource = dt;
                //            SetClientLogo();
                //            labelRowCount.Text = "Results: " + dataGridViewDebtors.RowCount;
                //        }

                //        catch (System.Exception ex)
                //        {
                //            System.Windows.Forms.MessageBox.Show(ex.Message);
                //        }

                //    }

                //    else if (comboBoxSearch.SelectedIndex == 0)
                //    {
                //        try
                //        {

                //            //string selectSerial = "select * from debtorsactive where debtor_full_name like '" + searched + "%' order by debtor_full_name asc";
                //            //SqlConnection con = new SqlConnection(ConectionStr);
                //            //SqlDataAdapter adapt = new SqlDataAdapter();
                //            //adapt.SelectCommand = new SqlCommand(selectSerial, con);

                //            //DataTable dt = new DataTable();
                //            //adapt.Fill(dt);
                //            dataGridViewDebtors.DataSource = dt;
                //            SetClientLogo();
                //            labelRowCount.Text = "Results: " + dataGridViewDebtors.RowCount;

                //        }
                //        catch (System.Exception ex)
                //        {
                //            System.Windows.Forms.MessageBox.Show(ex.Message);
                //        }
                //    }

                //    else
                //    {
                //        try
                //        {

                //            //SqlConnection con = new SqlConnection(ConectionStr);
                //            //SqlDataAdapter adapt = new SqlDataAdapter();
                //            //adapt.SelectCommand = new SqlCommand("FastSearch", con);
                //            //adapt.SelectCommand.CommandType = CommandType.StoredProcedure;
                //            //adapt.SelectCommand.Parameters.AddWithValue("@searched", searched);

                //            //DataTable dt = new DataTable();
                //            //adapt.Fill(dt);
                //            dataGridViewDebtors.DataSource = dt;
                //            SetClientLogo();
                //            labelRowCount.Text = "Results: " + dataGridViewDebtors.RowCount;

                //        }
                //        catch (System.Exception ex)
                //        {
                //            System.Windows.Forms.MessageBox.Show(ex.Message);
                //        }
                //    }
                //    History.Add(searched);
                //    pointer = History.Count - 1;
                //    string timeFormat = "dd MMM yyyy HH:mm";
                //    string Timestamp = DateTime.Now.ToString(timeFormat);
                //    StreamWriter Save = new StreamWriter(Savehistory, true);

                //    Save.WriteLine(Timestamp + " " + searched);
                //    Save.Close();
                //    searched = null;
                //    tabControl.SelectedTab = tabPageDebts;
                //    tabControl1.SelectedTab = tabPageDebtors;
                //    textBoxdebtserial.Text = "";

                //    Action<Control.ControlCollection> func = null;

                //    func = (controls) =>
                //    {
                //        foreach (Control control in groupBox7.Controls)
                //            if (control is TextBox)
                //                (control as TextBox).Text = "";
                //        foreach (Control control in groupBox4.Controls)
                //            if (control is ListBox)
                //                (control as ListBox).Items.Clear();
                //        foreach (Control control in groupBoxActDetail.Controls)
                //            if (control is TextBox)
                //                (control as TextBox).Text = "";

                //    };

                //    func(Controls);
                //    rowIndex = -2;
                //}

            }
        }

        private void buttonFilterDb_Click(object sender, EventArgs e)
        {
            string clInstit = this.comboBoxClientDb.Text.ToString();
            string currency = this.comboBoxCurrDb.Text.ToString();
            //string portofolio = this.comboBoxPorto.Text.ToString();
            string portoStatus = this.comboBoxPStatus.Text.ToString();
            string dCollector = comboBoxDbCollector.Text.ToString();
            string TotalOuts = textBoxTotOut.Text.ToString();
            string datetime = dateTimePickerDb.Text;
            string datetime2 = dateTimePickerDb.Text;
            this.comboBoxPeriod.SelectedIndex = 1;
            DateTime dt = new DateTime();
            DateTime.TryParse(datetime, out dt);

            double TotalO = 0.0;
            double TotalO2 = 0.0;

            if (clInstit == "Please Select")
            {
                clInstit = "%";
            }
            if (currency == "Please Select" || currency == "")
            {
                currency = "%";
            }
            //if (portofolio == "please select")
            //{
            //    portofolio = "%";
            //}
            if (portoStatus == "Please Select")
            {
                portoStatus = "%";
            }

            if (TotalOuts != "")
            {
                if (comboBoxMore.SelectedIndex == 0)
                {
                    Double.TryParse(TotalOuts, out TotalO2);
                    TotalO = 880000;
                }
                else
                {
                    Double.TryParse(TotalOuts, out TotalO);
                }
            }
            else
            {

                TotalO = 900000000.0;
                TotalO2 = 0.0;
            }

            if (datetime == null)
            {
                datetime = "2000-01-31";
                datetime2 = "2026-12-31";
            }

            else
            {
                if (comboBoxPeriod.SelectedIndex == 0)
                {
                    //  datetime = DateTime.Today.ToString();
                    datetime2 = datetime;
                }
                else if (comboBoxPeriod.SelectedIndex == 1)
                {
                    datetime = "2000-01-31";
                }
                else
                {
                    datetime2 = "2026-12-31";
                }
            }
            try
            {
                //    this.debtorsActiveTableAdapter1.DebtorFilter(this.forAmazonDataSet.DebtorsActive, portofolio + "%", TotalO, TotalO2, portoStatus, currency, "%" + dCollector + "%", datetime, datetime2, clInstit);
                //    SetClientLogo();
                //    labelRowCount.Text = "Results: " + dataGridViewDebtors.RowCount;
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void DGVcellcopy(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {

                Clipboard.SetData(System.Windows.Forms.DataFormats.Text, dataGridViewDebtors.Rows[dataGridViewDebtors.CurrentCellAddress.Y].Cells[dataGridViewDebtors.CurrentCellAddress.X].Value);
            }
        }


        private void listBoxPhoneCopy(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                if (listViewPhone.SelectedItems[0] != null && listViewPhone.SelectedItems[0].ToString() != "")
                {
                    Clipboard.SetData(System.Windows.Forms.DataFormats.Text, listViewPhone.SelectedItems[0].Text);
                }
            }
        }

        private void listViewPhoneCopy(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                if (listViewPhone.SelectedItems[0] != null && listViewPhone.SelectedItems[0].ToString() != "")
                {
                    Clipboard.SetData(System.Windows.Forms.DataFormats.Text, listViewPhone.SelectedItems[0].Text);
                }
            }
        }


        private void listViewRelPhoneCopy(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                if (listViewRelPhone.SelectedItems[0] != null && listViewRelPhone.SelectedItems[0].ToString() != "")
                {
                    Clipboard.SetData(System.Windows.Forms.DataFormats.Text, listViewRelPhone.SelectedItems[0].Text);
                }
            }
        }

        private void textboxSearchAct(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (comboBoxSrcAct.SelectedIndex == 0)
                {

                    string selectSerial = "select * from actionsjan where debt_serial_number='" + textBoxSrcAct.Text + "' order by last_updated desc, person_full_name desc ";
                    SqlConnection con = new SqlConnection(ConectionStr);
                    SqlDataAdapter adapt = new SqlDataAdapter();
                    adapt.SelectCommand = new SqlCommand(selectSerial, con);

                    DataTable dt = new DataTable();
                    adapt.Fill(dt);
                    dataGridViewAct.DataSource = dt;
                }

                else if (comboBoxSrcAct.SelectedIndex == 2)
                {
                    string selectSerial = "select * from actionsjan where comments like '%" + textBoxSrcAct.Text + "%'  order by last_updated desc, person_full_name desc ";
                    SqlConnection con = new SqlConnection(ConectionStr);
                    SqlDataAdapter adapt = new SqlDataAdapter();
                    adapt.SelectCommand = new SqlCommand(selectSerial, con);

                    DataTable dt = new DataTable();
                    adapt.Fill(dt);
                    dataGridViewAct.DataSource = dt;
                }

                else
                {

                    string selectSerial = "select * from actionsjan where person_full_name like '" + textBoxSrcAct.Text + "%'  order by last_updated desc, person_full_name desc ";
                    SqlConnection con = new SqlConnection(ConectionStr);
                    SqlDataAdapter adapt = new SqlDataAdapter();
                    adapt.SelectCommand = new SqlCommand(selectSerial, con);

                    DataTable dt = new DataTable();
                    adapt.Fill(dt);
                    dataGridViewAct.DataSource = dt;
                }
                labelActionRow.Text = "Action rows: " + dataGridViewAct.RowCount;
            }
        }

        private void textBoxSrcPaySearch(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (comboBoxPaidS.SelectedIndex == 0)
                {
                    try
                    {
                        this.paymentsJanTableAdapter1.SearchPayments(this.forAmazonDataSet.PaymentsJan, textBoxSrcPay.Text, "%");
                    }
                    catch (System.Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message);
                    }
                }

                else if (comboBoxPaidS.SelectedIndex == 1)
                {

                    try
                    {
                        this.paymentsJanTableAdapter1.SearchPayments(this.forAmazonDataSet.PaymentsJan, "%", textBoxSrcPay.Text + "%");
                    }
                    catch (System.Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message);
                    }
                }

                else
                {

                    string selectPayments = " select * from paymentsjan where debt_serial_number='" + textBoxSrcPay.Text + "' or person_full_name like '" + textBoxSrcPay.Text + "%' order by person_full_name asc,paymentDate desc";
                    SqlConnection con = new SqlConnection(ConectionStr);
                    SqlDataAdapter adapt = new SqlDataAdapter();
                    adapt.SelectCommand = new SqlCommand(selectPayments, con);

                    DataTable dt = new DataTable();
                    adapt.Fill(dt);
                    paymentsJanDataGridView.DataSource = dt;
                }
                labelPayCount.Text = "Contacts: " + paymentsJanDataGridView.RowCount;
            }
        }

        private void textBoxSrcPersSearch(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (comboBoxSrcPers.SelectedIndex == 0)
                {
                    //try
                    //{
                    //    this.personsTableAdapter.PersonSearch(this.forAmazonDataSet.Persons, textBoxScrPers.Text, "%","%");
                    //}
                    //catch (System.Exception ex)
                    //{
                    //    System.Windows.Forms.MessageBox.Show(ex.Message);
                    //}

                    string selectSerial = "select * from persons where person_number ='" + textBoxScrPers.Text + "' order by person_full_name asc";
                    SqlConnection con = new SqlConnection(ConectionStr);
                    SqlDataAdapter adapt = new SqlDataAdapter();
                    adapt.SelectCommand = new SqlCommand(selectSerial, con);

                    DataTable dt = new DataTable();
                    adapt.Fill(dt);
                    dataGridViewPersons.DataSource = dt;
                }

                else if (comboBoxSrcPers.SelectedIndex == 1)
                {
                    string selectSerial = " select * from persons where person_full_name ='" + textBoxScrPers.Text + "' order by person_full_name desc";
                    SqlConnection con = new SqlConnection(ConectionStr);
                    SqlDataAdapter adapt = new SqlDataAdapter();
                    adapt.SelectCommand = new SqlCommand(selectSerial, con);

                    DataTable dt = new DataTable();
                    adapt.Fill(dt);
                    dataGridViewPersons.DataSource = dt;
                    //try
                    //{
                    //    this.personsTableAdapter.PersonSearch(this.forAmazonDataSet.Persons, "%", textBoxScrPers.Text+"%", "%");
                    //}
                    //catch (System.Exception ex)
                    //{
                    //    System.Windows.Forms.MessageBox.Show(ex.Message);
                    //}
                }

                else if (comboBoxSrcPers.SelectedIndex == 2)
                {
                    string selectSerial = " select * from persons where first_name like '" + textBoxScrPers.Text + "%' order by first_name desc";
                    SqlConnection con = new SqlConnection(ConectionStr);
                    SqlDataAdapter adapt = new SqlDataAdapter();
                    adapt.SelectCommand = new SqlCommand(selectSerial, con);

                    DataTable dt = new DataTable();
                    adapt.Fill(dt);
                    dataGridViewPersons.DataSource = dt;
                }

                else
                {
                    string selectSerial = " select * from persons where person_number ='" + textBoxScrPers.Text + "' " +
                        " OR person_full_name like '" + textBoxScrPers.Text + "%' OR  first_name like '" + textBoxScrPers.Text + "%' " +
                        "OR last_name like '" + textBoxScrPers.Text + "%' OR fathers_name like '" + textBoxScrPers.Text + "%' " +
                        "OR address like '" + textBoxScrPers.Text + "%' OR phone_1 like '" + textBoxScrPers.Text + "%' OR phone_2 like '" +
                        textBoxScrPers.Text + "%' OR phone_3 like '" + textBoxScrPers.Text + "%' OR phone_4 like '" + textBoxScrPers.Text +
                        "%' OR personal_number like '" + textBoxScrPers.Text + "%' order by person_full_name asc";
                    SqlConnection con = new SqlConnection(ConectionStr);
                    SqlDataAdapter adapt = new SqlDataAdapter();
                    adapt.SelectCommand = new SqlCommand(selectSerial, con);

                    DataTable dt = new DataTable();
                    adapt.Fill(dt);
                    dataGridViewPersons.DataSource = dt;
                    //try
                    //{
                    //   this.personsTableAdapter.PersonSearch(this.forAmazonDataSet.Persons,"%", "%", textBoxScrPers.Text + "%");
                    //}
                    //catch (System.Exception ex)
                    //{
                    //    System.Windows.Forms.MessageBox.Show(ex.Message);
                    //}
                }
                labelContacts.Text = "Contacts: " + dataGridViewPersons.RowCount;
            }
        }

        private void buttonFilterActions_Click(object sender, EventArgs e)
        {
            //if (comboBoxClinstAct.Text == null || comboBoxClinstAct.Text == "")
            //{
            //    actionClQuery = "";
            //}

            //if (comboBoxActDate.Text == null || comboBoxActDate.Text == "")
            //{
            //    dateActquery = "";
            //}

            //if (comboBoxCntPersAct.Text == null || comboBoxCntPersAct.Text == "")
            //{
            //    astuatusValue = "%";
            //}

            //if (comboBoxActTypeAct.Text == null || comboBoxActTypeAct.Text == "")
            //{
            //    atypeQuery = "";
            //}

            //if (textBoxUserAct.Text == null || textBoxUserAct.Text == "")
            //{
            //    userActQuery = "";
            //}

            //if (comboBoxLastupd.Text == null || comboBoxLastupd.Text == "")
            //{
            //    actUpdateQuery = "";
            //}

            //if (textBoxCommentsAct.Text == null || textBoxCommentsAct.Text == "")
            //{
            //    commentQuery = "";
            //}
            //if (comboBoxActReact.Text == null || comboBoxActReact.Text == "")
            //{
            //    reactionAQuery = "";
            //}

            //string FilterActions = "select * from actionsjan where action_status like '" + astuatusValue + "' " +
            //    actionClQuery + dateActquery + commentQuery + atypeQuery + userActQuery + actUpdateQuery + reactionAQuery + " order by last_updated desc,id desc ";
            //SqlConnection con = new SqlConnection(ConectionStr);
            //SqlDataAdapter adapt = new SqlDataAdapter();
            //adapt.SelectCommand = new SqlCommand(FilterActions, con);

            //DataTable dt = new DataTable();
            //adapt.Fill(dt);
            //dataGridViewAct.DataSource = dt;
            //labelActionRow.Text = "Action rows: " + dataGridViewAct.RowCount;

            GetFilterActions();
        }

        private void GetFilterActions()
        {
            SqlConnection con = new SqlConnection(ConectionStr);
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = new SqlCommand("filterActions", con);
            adapt.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapt.SelectCommand.Parameters.AddWithValue("@client_institution", comboBoxClinstAct.SelectedItem == null ? null : comboBoxClinstAct.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@eqadate", comboBoxActDate.SelectedItem == null ? null : comboBoxActDate.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@acdate", dateTimePickerActDtAct.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@eqldate", comboBoxLastupd.SelectedItem == null ? null : comboBoxLastupd.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@date", dateTimePickerLastActU.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@person_contacted", comboBoxCntPersAct.SelectedItem == null ? null : comboBoxCntPersAct.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@actype", comboBoxActTypeAct.SelectedItem == null ? null : comboBoxActTypeAct.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@reaction", comboBoxActReact.SelectedItem == null ? null : comboBoxActReact.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@user", textBoxUserAct.Text == "" ? null : textBoxUserAct.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@comment", textBoxCommentsAct.Text == "" ? null : textBoxCommentsAct.Text);

            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridViewAct.DataSource = dt;
            labelActionRow.Text = "Action rows: " + dataGridViewAct.RowCount;
        }

        private void tabPageActionsClick(object serder, EventArgs e)
        {

        }

        private void TabLegalClick(object sender, EventArgs e)
        {
            if (tabControllegal.SelectedTab == tabPageMatters)
            {
                CollectTotalMatters();
            }

        }


        private void TabClick(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPageActions)
            {
                labelSuccesfulDelete.Text = null;
                // comboBoxClinstAct.Text = "";
                comboBoxActTypeAct.Text = "";
                comboBoxCntPersAct.Text = "";
                if (dataGridViewAct.RowCount == 1)
                {
                    this.actionsJanTableAdapter1.Fill(this.forAmazonDataSet.ActionsJan);
                }
            }
            else if (tabControl1.SelectedTab == tabPagePayments)
            {
                //  this.comboBoxClinstPAy.Text = "please select";

                // this.comboBoxPayCurr.Text = "please select";
                //.Text = "please select";
                labelSuccessPaydel.Text = null;
                int rowC = paymentsJanDataGridView.RowCount;
                if (rowC == 1)
                {
                    this.paymentsJanTableAdapter1.Fill(this.forAmazonDataSet.PaymentsJan);
                }

            }
            else if (tabControl1.SelectedTab == tabPagePersons)
            {
                //  this.comboBoxPersonCl.Text = "please select";
                if (dataGridViewPersons.RowCount == 1)
                {
                    this.personsTableAdapter.Fill(this.forAmazonDataSet.Persons);
                }
            }

            else if (tabControl1.SelectedTab == tabPageReports)
            {
                this.comboBoxCollector.Text = labelLogedCollector.Text;
                this.textBoxOnlineUser.Text = labelOnlineUser.Text;
            }

            else if (tabControl1.SelectedTab == tabPageColl)
            {
                CollectTotalCollaterals();
            }

            else if (tabControl1.SelectedTab == tabPageBill)
            {
                CollectTotalBills();
            }

            //Legal Process
            if (tabControllegal.SelectedTab==tabPageMatters)
            {
                CollectTotalMatters();
            }
            else if (tabControllegal.SelectedTab == tabPageDashboard)
            {
                CollectDashboardEvents();
                CollectDailyTasks();

            }
        }



        private void CollectTotalMatters()
        {
            SqlConnection con = new SqlConnection(ConectionStr);
            string SearchMatters = "select top(50) * from legalmatters ";
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = new SqlCommand(SearchMatters, con);
            adapt.Fill(dt);
            dataGridViewMatters.DataSource = dt;
        }

        private void CollectDashboardEvents()
        {
            SqlConnection con = new SqlConnection(ConectionStr);
            string SearchEvents = "select top(50) * from legalevents ";
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = new SqlCommand(SearchEvents, con);
            adapt.Fill(dt);
            dataGridViewEvents.DataSource = dt;
        }

        private void CollectDailyTasks()
        {
            SqlConnection con = new SqlConnection(ConectionStr);
            string SearchEvents = "select top(50) * from legaltasks ";
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = new SqlCommand(SearchEvents, con);
            adapt.Fill(dt);
            dataGridViewDailyTasks.DataSource = dt;
        }

        private void buttonchngPass_Click(object sender, EventArgs e)
        {
            ChangePass Pass = new ChangePass();
            Pass.ShowDialog();
        }

        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            if (labelOnlineUser.Text == "admin")
            {
                Register Regs = new Register();
                Regs.ShowDialog();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?",
                               "Exiting InstantCollect",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Information) == DialogResult.Yes)
            {
                e.Cancel = false;
                LogOut();
                Environment.Exit(1);

            }
            else
            {
                e.Cancel = true;
            }
        }

        private void LogOut()
        {
            string versioni = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string insertLogOut = "insert into Appversion (username,ip,timedate,version,pcname,logtype)" +
                   " values(@user,@ip,@dataora,@version,@pname,'Log Out')";
            SqlConnection con = new SqlConnection(ConectionStr);
            SqlCommand cmd = new SqlCommand(insertLogOut, con);
            cmd.Parameters.AddWithValue("@user", usernamevalue);
            cmd.Parameters.AddWithValue("@ip", GetIP());
            cmd.Parameters.AddWithValue("@dataora", DateTime.Now);
            cmd.Parameters.AddWithValue("@version", versioni);
            cmd.Parameters.AddWithValue("@pname", System.Environment.MachineName);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error Message");
            }

        }

        private string GetIP()// Gjen IP e rrjetit
        {
            string PICPS = null;
            try
            {
                PICPS = new WebClient().DownloadString("http://icanhazip.com");
            }
            catch (Exception)
            {

                MessageBox.Show("Error in first connection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (PICPS == null || PICPS == "")
            {
                try
                {
                    PICPS = new WebClient().DownloadString("http://api.ipify.org");
                }
                catch (Exception)
                {

                    MessageBox.Show("Error in second connection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            return PICPS;
        }
        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want exit?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                // this.Dispose();
                //   this.Close();
                //// Application.Exit();       
                //Users usr = new Users();
                //usr.Show();
                //this.Dispose();
                //this.Close();// test
                LogOut();
                Environment.Exit(1);
            }
        }


        private void dataGridViewselectedPay_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cellclick1 = (sender as DataGridView).Rows[e.RowIndex].Cells[e.ColumnIndex];
                int rowindex = cellclick1.RowIndex;
                int colindx = cellclick1.ColumnIndex;
                int colindex = ColumnSelectCheck.Index;
                if (colindex == colindx)
                {
                    paymentID = dataGridViewselectedPay.Rows[rowindex].Cells[iDDataGridViewTextBoxColumn1.Index].Value.ToString();
                    //   String PayMonth = dataGridViewselectedPay.Rows[rowindex].Cells[paymentMonthDataGridViewTextBoxColumn.Index].Value.ToString();
                    // ColumnSelectCheck.Selected = true;
                    EditPayment edpay = new EditPayment();
                    edpay.ShowDialog();
                }
            }

        }


        private void dataGridViewselectedactions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cellclick1 = (sender as DataGridView).Rows[e.RowIndex].Cells[e.ColumnIndex];
                int rowindex = cellclick1.RowIndex;
                int colindx = cellclick1.ColumnIndex;
                int colindex = ButtonGridAct.Index;
                if (colindex == colindx)
                {
                    actionID = dataGridViewselectedactions.Rows[rowindex].Cells[iDDataGridViewTextBoxColumn2.Index].Value.ToString();
                    EditAct edAct = new EditAct();
                    edAct.ShowDialog();
                }
            }

        }

        public string fname = null, lname = null;
        private void ClickContactsEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (StatusCollector.ToLower() == "admin" || StatusCollector.ToLower() == "supervisor" || StatusCollector.ToLower() == "agent")
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    DataGridViewCell cellclick1 = (sender as DataGridView).Rows[e.RowIndex].Cells[e.ColumnIndex];
                    int rowindex = cellclick1.RowIndex;
                    int colindx = cellclick1.ColumnIndex;
                    int colindex = ButtonEditCnt.Index;
                    if (colindex == colindx)
                    {
                        contactID = personsDataGridView.Rows[rowindex].Cells[personIdDataGridViewTextBoxColumn1.Index].Value.ToString();
                        EditContact editCnt = new EditContact();
                        editCnt.ShowDialog();
                    }
                }

            }

            if (e.ColumnIndex == SkipColumn.Index)
            {
                fname = personsDataGridView.Rows[e.RowIndex].Cells[firstNameDataGridViewTextBoxColumn1.Index].Value.ToString().Trim();
                lname = personsDataGridView.Rows[e.RowIndex].Cells[lastNameDataGridViewTextBoxColumn1.Index].Value.ToString().Trim();

                if (fname != "" && fname != null && lname != "" && lname != null)
                {
                    worker3.RunWorkerAsync();
                    buttonSkipDataSearch.Enabled = false;
                    SkipColumn.ReadOnly = true;
                    textBoxFnameSkip.Enabled = false;
                    textBoxLnameSkip.Enabled = false;
                    textBoxAtesiSkip.Enabled = false;
                    textBoxBdateSkip.Enabled = false;
                    textBoxAmesiSkip.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Empty name/last name", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void buttonAcount_Click(object sender, EventArgs e)
        {
            //usernamevalue = usernamevalue.ToLower();
            if (StatusCollector.ToLower() == "admin" || StatusCollector.ToLower() == "supervisor" || StatusCollector.ToLower() == "agent")
            {
                List<string> rowsChecked = new List<string>();
                foreach (DataGridViewRow row in dataGridViewAct.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[ColumnCheck.Name].Value) == true)
                    {
                        rowsChecked.Add(row.Cells[iDDataGridViewTextBoxColumn.Name].Value.ToString());
                    }
                }

                int CheckedRows = rowsChecked.Count;

                //  string conStr1 = "Data Source=debitor.c8kumftnoykl.eu-central-1.rds.amazonaws.com,1433;Initial Catalog=ForAmazon;User ID=debitordata;Password=Trsdmr92l161";
                if (CheckedRows != 0)
                {
                    if (MessageBox.Show("Are you sure you want to delete " + CheckedRows.ToString() + " actions?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        for (int i = 0; i < CheckedRows; i++)
                        {
                            String Query = " Delete From ActionsJan  where ID=@id";
                            SqlConnection con = new SqlConnection(ConectionStr);
                            SqlCommand command = new SqlCommand(Query, con);
                            int ID;
                            int.TryParse(rowsChecked[i], out ID);
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

                        }
                        labelSuccesfulDelete.Text = CheckedRows.ToString() + " actions deleted successfuly.";
                    }
                }
                else
                {
                    MessageBox.Show("At least one row must be selected", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("To delete multiple actions you must be logged as Administrator.", "Permission denied", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            // this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //usernamevalue = usernamevalue.ToLower();
            if (StatusCollector.ToLower() == "admin" || StatusCollector.ToLower() == "supervisor" || StatusCollector.ToLower() == "agent")
            {
                List<string> rowsChecked = new List<string>();
                foreach (DataGridViewRow row in paymentsJanDataGridView.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[CheckboxPayments.Name].Value) == true)
                    {
                        rowsChecked.Add(row.Cells[iDDataGridViewTextBoxColumn3.Name].Value.ToString());
                    }
                }
                int CheckedRows = rowsChecked.Count;
                if (CheckedRows != 0)
                {
                    if (MessageBox.Show("Are you sure you want to delete " + CheckedRows.ToString() + " payments?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        for (int i = 0; i < CheckedRows; i++)
                        {
                            String Query = " Delete From PaymentsJan  where ID=@id";
                            SqlConnection con = new SqlConnection(ConectionStr);
                            SqlCommand command = new SqlCommand(Query, con);
                            int ID;
                            int.TryParse(rowsChecked[i], out ID);
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

                        }
                        labelSuccessPaydel.Text = CheckedRows.ToString() + " payments deleted successfuly.";
                    }
                }
                else
                {
                    MessageBox.Show("At least one row must be selected", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("In order to delete payments you must be logged in as Administrator.", "No premission", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void dateTimePickerActDtAct_ValueChanged(object sender, EventArgs e)
        {
            comboBoxActDate_SelectedIndexChanged(sender, e);
        }

        private void dateTimePickerLastActU_ValueChanged(object sender, EventArgs e)
        {
            comboBoxLastupd_SelectedIndexChanged(sender, e);
        }

        private void buttonFilterPayment_Click(object sender, EventArgs e)
        {
            //     string clientinst = this.comboBoxClinstPAy.Text;
            //     string TotalOuts = textBoxPaidAmt.Text;
            //   //  string payYear = maskedTextBoxYear.Text;
            //   //  string payMonth = maskedTextBoxMonth.Text;
            // //    string datetime = textBoxPAyUpd.Text;
            ////     string datetime2 = datetime;
            //     string currency = this.comboBoxPayCurr.Text;
            //     string userid = textBoxPayColl.Text;
            //     string comments = textBoxPayComent.Text;
            //    short  month1 = 1;
            //     short month2 = 12;
            //     double TotalO2 = 0.0;
            //     double TotalO = 0.0;
            //     short year1 = 2000;
            //     short year2 = 2029;

            //     if (clientinst == "Please Select")// selecting slient institution
            //     {
            //         clientinst = "%";
            //     }

            //     if (userid=="")
            //     {
            //         userid = "%";
            //     }
            //     if (comments=="")
            //     {
            //         comments = "%";
            //     }
            //     if (TotalOuts != "")// setting paid amount
            //     {
            //         if (comboBoxMore2.SelectedIndex == 0)
            //         {
            //             Double.TryParse(TotalOuts, out TotalO);
            //             TotalO2 = 90000000;
            //         }
            //         else
            //         {
            //             Double.TryParse(TotalOuts, out TotalO2);
            //         }
            //     }        
            //    else
            //     {
            //         TotalO2 = 900000000.0;
            //         TotalO = 0.0;
            //     }                       
            //    if (comboBoxSelPeriod1.SelectedIndex == 0)//if selected period is just one moth
            //    {
            //        short.TryParse(payMonth, out month1);
            //        month2 = month1;                 
            //    }
            //    else if(comboBoxSelPeriod1.SelectedIndex == 1)//if selected period is before than given month
            //    {
            //        short.TryParse(payMonth, out month2);
            //        month1 = 1;
            //    }
            //    else if(comboBoxSelPeriod1.SelectedIndex == 2)//if selected period is after than given month
            //    {
            //        short.TryParse(payMonth, out month1);
            //        month2 = 12;
            //    }
            //    else// in other cases
            //    {
            //        short.TryParse(payMonth, out month1);
            //        month2 = month1;
            //    }           
            ////if (payYear != "")// setting pay month period
            ////{
            //    if (comboBoxSelPeriod2.SelectedIndex == 0)//if selected period is just one moth
            //    {
            //        short.TryParse(payYear, out year1);
            //        year2 = year1;

            //    }
            //    else if (comboBoxSelPeriod2.SelectedIndex == 1)//if selected period is before than given month
            //    {
            //        short.TryParse(payYear, out year2);
            //        year1 = 2000;
            //    }
            //    else if (comboBoxSelPeriod2.SelectedIndex == 2)//if selected period is after than given month
            //    {
            //        short.TryParse(payYear, out year1);
            //        year2 = 2029;
            //    }
            //    else// in other cases
            //    {
            //        short.TryParse(payYear, out year1);
            //        year2 = year1;
            //    }
            //}

            //else
            //{
            //    year1 = 2000;
            //    year2 = 2029;
            //}

            //if (currency=="Please Select")
            //{
            //    currency = "%";
            //}

            //if (datetime =="")
            //{
            //    datetime = "2000-01-31";
            //    datetime2 = "2026-12-31";
            //}

            //else
            //{
            //    if (comboBoxPeriod1.SelectedIndex == 0)
            //    {
            //        //  datetime = DateTime.Today.ToString();
            //        datetime2 = datetime;
            //    }
            //    else if (comboBoxPeriod1.SelectedIndex == 1)
            //    {
            //        datetime = "2000-01-31";
            //    }
            //    else
            //    {
            //        datetime2 = "2026-12-31";
            //    }
            //}
            //if (textBoxPayColl.Text == "" || textBoxPayColl.Text == null)
            //{
            //    CollectorPay = "%";
            //}

            //if (comboBoxClinstPAy.Text == "")
            //{
            //    cliendQuery = "";
            //}
            //if (textBoxPaidAmt.Text == "")
            //{
            //    paymentQuery = "";
            //}
            //if (comboBoxSelPeriod1.Text == "" || comboBoxSelPeriod1.Text == null)
            //{
            //    dateQuery = "";
            //}
            //if (comboBoxPayCurr.Text == "" || comboBoxPayCurr.Text == null || comboBoxPayCurr.Text.ToLower() == "please select")
            //{
            //    PaymentCurrQuery = "";
            //}
            //if (comboBoxPeriod1.Text == "" || comboBoxPeriod1.Text == null)
            //{
            //    lastupdatedPQuery = "";
            //}

            //if (comboBoxPortf.Text==""  || comboBoxPortf.Text==null)
            //{
            //    PaymentPortfolio = null;
            //}
            //string FilterPaymentsQuery = "select * from paymentsjan where collector like '" + CollectorPay + "%' " + cliendQuery +
            //    paymentQuery + PaymentCurrQuery + dateQuery+PaymentPortfolio+PaymentsComment + lastupdatedPQuery + "  order by paymentDate desc, id desc";
            //SqlConnection con = new SqlConnection(ConectionStr);
            //SqlDataAdapter adapt = new SqlDataAdapter();
            //adapt.SelectCommand = new SqlCommand(FilterPaymentsQuery, con);
            //DataTable dt = new DataTable();
            //adapt.Fill(dt);
            //paymentsJanDataGridView.DataSource = dt;


            GetFilterPayments();
        }

        private void GetFilterPayments()
        {
            SqlConnection con = new SqlConnection(ConectionStr);
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = new SqlCommand("filterPayments", con);
            adapt.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapt.SelectCommand.Parameters.AddWithValue("@client_institution", comboBoxClinstPAy.SelectedItem == null ? null : comboBoxClinstPAy.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@eqldate", comboBoxPeriod1.SelectedItem == null ? null : comboBoxPeriod1.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@date", dateTimePickerLastP.Value.ToString("dd-MMM-yyyy"));
            adapt.SelectCommand.Parameters.AddWithValue("@eqpdate", comboBoxSelPeriod1.SelectedItem == null ? null : comboBoxSelPeriod1.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@pdate", dateTimePickerPer.Value.ToString("dd-MMM-yyyy"));
            adapt.SelectCommand.Parameters.AddWithValue("@portfolio", comboBoxPortf.SelectedItem == null ? null : comboBoxPortf.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@collector", textBoxPayColl.Text == "" ? null : textBoxPayColl.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@comment", textBoxComment.Text == "" ? null : textBoxComment.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@EqLessMo", comboBoxMore2.SelectedItem == null ? null : comboBoxMore2.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@pamount", textBoxPaidAmt.Text == null ? "0" : textBoxPaidAmt.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@currency", comboBoxPayCurr.SelectedItem == null ? null : comboBoxPayCurr.Text);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            paymentsJanDataGridView.DataSource = dt;

            double shuma = 0, shumaEur = 0;

            SqlCommand cmd = new SqlCommand("filterpaymentssum", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@client_institution", comboBoxClinstPAy.SelectedItem == null ? null : comboBoxClinstPAy.Text);
            cmd.Parameters.AddWithValue("@eqldate", comboBoxPeriod1.SelectedItem == null ? null : comboBoxPeriod1.Text);
            cmd.Parameters.AddWithValue("@date", dateTimePickerLastP.Value.ToString("dd-MMM-yyyy"));
            cmd.Parameters.AddWithValue("@eqpdate", comboBoxSelPeriod1.SelectedItem == null ? null : comboBoxSelPeriod1.Text);
            cmd.Parameters.AddWithValue("@pdate", dateTimePickerPer.Value.ToString("dd-MMM-yyyy"));
            cmd.Parameters.AddWithValue("@portfolio", comboBoxPortf.SelectedItem == null ? null : comboBoxPortf.Text);
            cmd.Parameters.AddWithValue("@collector", textBoxPayColl.Text == "" ? null : textBoxPayColl.Text);
            cmd.Parameters.AddWithValue("@comment", textBoxComment.Text == "" ? null : textBoxComment.Text);
            cmd.Parameters.AddWithValue("@EqLessMo", comboBoxMore2.SelectedItem == null ? null : comboBoxMore2.Text);
            cmd.Parameters.AddWithValue("@pamount", textBoxPaidAmt.Text == null ? "0" : textBoxPaidAmt.Text);
            cmd.Parameters.AddWithValue("@currency", comboBoxPayCurr.SelectedItem == null ? null : comboBoxPayCurr.Text);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.IsDBNull(0) == false)
                {
                    shuma = reader.GetDouble(0);
                }

                if (reader.IsDBNull(1) == false)
                {
                    shumaEur = reader.GetDouble(1);
                }
            }
            con.Close();

            labelPayCount.Text = "Payments: " + paymentsJanDataGridView.RowCount + "  Shuma Lek: " + shuma.ToString() + ", Eur: " + shumaEur.ToString();

        }

        private void dateTimePickerLastP_ValueChanged(object sender, EventArgs e)
        {
            //textBoxPAyUpd.Text = dateTimePickerLastP.Text;
            comboBoxPeriod1_SelectedIndexChanged(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            GetContacts();
            //if (comboBoxPersonCl.Text == null || comboBoxPersonCl.Text == "")
            //{
            //    CntClientQuery = "";
            //}

            //if (comboBoxPerStatus.Text == null || comboBoxPerStatus.Text == "")
            //{
            //    PersonStatusQuery = "";
            //}

            //string filterContacts = "select * from persons where district like '" + districtvalue + "' " +
            //   CntClientQuery + PersonStatusQuery + noCntQuery + CntCollectorQuery + emailQuery + " order by person_full_name asc";
            //SqlConnection con = new SqlConnection(ConectionStr);
            //SqlDataAdapter adapt = new SqlDataAdapter();
            //adapt.SelectCommand = new SqlCommand(filterContacts, con);

            //DataTable dt = new DataTable();
            //adapt.Fill(dt);
            //dataGridViewPersons.DataSource = dt;
            //labelContacts.Text = "Contacts: " + dataGridViewPersons.RowCount;
        }
        private void GetContacts()
        {
            SqlConnection con = new SqlConnection(ConectionStr);
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = new SqlCommand("filterContacts", con);
            adapt.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapt.SelectCommand.Parameters.AddWithValue("@district", textBoxPersDistr.Text == "" ? null : textBoxPersDistr.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@debt_collector", textBoxCntCollector.Text == "" ? null : textBoxCntCollector.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@client_institution", comboBoxPersonCl.SelectedItem == null ? null : comboBoxPersonCl.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@latest_person_contacted", checkBoxNoCnt.Checked == true ? "no contact" : null);
            adapt.SelectCommand.Parameters.AddWithValue("@Relation", comboBoxPerStatus.SelectedItem == null ? null : comboBoxPerStatus.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@email", checkBoxEmail.Checked == true ? "emails" : null);
            adapt.SelectCommand.Parameters.AddWithValue("@date", dateTimePickercnt.Checked == false ? null : dateTimePickercnt.Text);



            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridViewPersons.DataSource = dt;
            labelContacts.Text = "Contacts: " + dataGridViewPersons.RowCount;
        }

        private void personSearchToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void buttonImport_Click(object sender, EventArgs e)
        {

            //  string OnlineUser = usernamevalue;
            // OnlineUser = OnlineUser.ToLower();
            if (StatusCollector.ToLower() == "admin" || StatusCollector.ToLower() == "supervisor" || StatusCollector.ToLower() == "agent")
            {
                Import newImport = new Import();
                newImport.ShowDialog();
            }
            else
            {
                MessageBox.Show("To import data you must be logged as administrator", "Premission denied", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void tabControllegal_DrawItem(object sender, DrawItemEventArgs e)
        {
            string tabName = tabControllegal.TabPages[e.Index].Text;
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            //Find if it is selected, this one will be hightlighted...
            if (e.Index == tabControllegal.SelectedIndex)
                e.Graphics.FillRectangle(Brushes.LightBlue, e.Bounds);
            e.Graphics.DrawString(tabName, this.Font, Brushes.Black, tabControllegal.GetTabRect(e.Index), stringFormat);
        }

        private void PaymentExport(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Exported_Payments_" + DateTime.Today.ToString("dd-MMM-yy") + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCsV(paymentsJanDataGridView, sfd.FileName);
                // Here dataGridview1 is your grid view name
            }
        }

        private void ExportContacts(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Exported_Contacts_" + DateTime.Today.ToString("dd-MMM-yy") + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCsV(dataGridViewPersons, sfd.FileName);
                // Here dataGridview1 is your grid view name
            }
        }

        //private void buttonDetails_Click(object sender, EventArgs e)
        //{
        //    calcPaymentDays();
        //    PersonDetails();
        //}
        private void dataGridViewDoc_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cellclick1 = (sender as DataGridView).Rows[e.RowIndex].Cells[e.ColumnIndex];
                int rowindex = cellclick1.RowIndex;
                int ClickedIndex = cellclick1.ColumnIndex;
                int colindex = Preview.Index;
                int col2index = Download.Index;
                int col3Index = DeleteFile.Index;
                if (colindex == ClickedIndex)
                {
                    if (dataGridViewDoc.Rows[rowindex].Cells[6].Value.ToString() == "image/jpg" || dataGridViewDoc.Rows[rowindex].Cells[6].Value.ToString() == "image/jpeg" || dataGridViewDoc.Rows[rowindex].Cells[6].Value.ToString() == "image/png")
                    {
                        docID = dataGridViewDoc.Rows[rowindex].Cells[3].Value.ToString();
                        //   String PayMonth = dataGridViewselectedPay.Rows[rowindex].Cells[paymentMonthDataGridViewTextBoxColumn.Index].Value.ToString();
                        // ColumnSelectCheck.Selected = true;
                        Preview prev = new Preview();
                        prev.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Unsupported format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }

                }

                else if (col2index == ClickedIndex)
                {
                    docID = dataGridViewDoc.Rows[rowindex].Cells[3].Value.ToString();
                    SqlConnection con = new SqlConnection(ConectionStr);
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand("SELECT files FROM fileattachments WHERE id ='" + docID + "'", con));
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);

                    if (dataSet.Tables[0].Rows.Count == 1)
                    {
                        Byte[] data = new Byte[0];
                        data = (Byte[])(dataSet.Tables[0].Rows[0]["files"]);
                        MemoryStream mem = new MemoryStream(data);
                        SaveFileDialog sfdDoc = new SaveFileDialog();

                        switch (dataGridViewDoc.Rows[rowindex].Cells[6].Value.ToString())
                        {
                            case "application/word":
                                // contenttype = "application/vnd.ms-word";
                                sfdDoc.Filter = "Word Documents (*.docx)|*.docx |Word Documents (*.doc)|*.doc";
                                break;

                            case "application/excel":
                                // contenttype = "application/vnd.ms-word";
                                sfdDoc.Filter = "Excel Documents (*.xlsx)|*.xlsx |Word Documents (*.xls)|*.xls";
                                break;

                            case "image/jpg":
                                //contenttype = "image/jpg";
                                sfdDoc.Filter = "JPG Images (*.jpg)|*.jpg";
                                break;
                            case "image/jpeg":
                                //  contenttype = "image/jpeg";
                                sfdDoc.Filter = "JPEG Images (*.jpeg)|*.jpeg";
                                break;
                            case "image/png":
                                //contenttype = "image/png";
                                sfdDoc.Filter = "PNG Images (*.png)|*.png";
                                break;

                            case "application/pdf":
                                //contenttype = "application/pdf";
                                sfdDoc.Filter = "PDF Documents (*.pdf)|*.pdf";
                                break;
                        }

                        sfdDoc.FileName = dataGridViewDoc.Rows[rowindex].Cells[5].Value.ToString();
                        if (sfdDoc.ShowDialog() == DialogResult.OK)
                        {
                            FileStream file = new FileStream(sfdDoc.FileName, FileMode.Create, FileAccess.Write);
                            mem.WriteTo(file);
                            file.Close();
                            mem.Close();
                        }
                    }
                }

                else if (col3Index == ClickedIndex && StatusCollector!="guest" && StatusCollector != "operator")
                {
                    
                    if (MessageBox.Show("Are you sure you want to delete this file ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        docID = dataGridViewDoc.Rows[rowindex].Cells[3].Value.ToString();
                        SqlConnection con = new SqlConnection(ConectionStr);
                        string query = "delete  FROM fileattachments WHERE id ='" + docID + "'";
                        SqlCommand cmd = new SqlCommand(query, con);
                        try
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            this.dataGridViewDoc.Rows.RemoveAt(rowindex);
                            //FileList = null;
                        }
                        catch (SqlException exception)
                        {
                            MessageBox.Show(exception.Message.ToString(), "Error Message");
                        }
                    }                  
                }
            }
        }


        private void CollectPerson(TextBox tbox)
        {

            SqlConnection con = new SqlConnection(ConectionStr);
            DataTable dt = new DataTable();
            string collectAct = "select * from persons where person_number='" + textBoxdebtserial.Text + "' order by relation desc";
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = new SqlCommand(collectAct, con);
            adapt.Fill(dt);
            personsDataGridView.DataSource = dt;

        }
        private void CollectCollaterals(TextBox txt)
        {
            SqlConnection con = new SqlConnection(ConectionStr);
            string SearchColl = "select * from Collaterals where serialnumber='" + txt.Text + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = new SqlCommand(SearchColl, con);
            adapt.Fill(dt);
            dataGridViewColateral.DataSource = dt;
        }

        private void CollectBills(TextBox txt)
        {
            SqlConnection con = new SqlConnection(ConectionStr);
            string SearchBill = "select * from Bills where kodi='" + txt.Text + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = new SqlCommand(SearchBill, con);
            adapt.Fill(dt);
            dataGridViewBills.DataSource = dt;
        }

        private void CollectMSDN(TextBox txt)
        {
            SqlConnection con = new SqlConnection(ConectionStr);
            string SearchBill = "select * from MSDN where SerialNumber='" + txt.Text + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = new SqlCommand(SearchBill, con);
            adapt.Fill(dt);
            dataGridViewMSDN.DataSource = dt;
        }

        private void CollectDoc(TextBox txt)
        {
            SqlConnection con = new SqlConnection(ConectionStr);
           // string SearchBill = "select id,serialno as [Serial nr],Name,filetype as [File type],Date,Userid from fileattachments where SerialNo='" + textBoxdebtserial.Text + "' order by date desc";
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = new SqlCommand("AttachmentsSelect", con);
            adapt.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapt.SelectCommand.Parameters.AddWithValue("@dserial", textBoxdebtserial.Text);
            adapt.Fill(dt);
            dataGridViewDoc.DataSource = dt;
            dataGridViewDoc.Columns[0].Width = 75;
            dataGridViewDoc.Columns[1].Width = 80;
            dataGridViewDoc.Columns[2].Width = 50;
            dataGridViewDoc.Columns[3].Width = 50;
            dataGridViewDoc.Columns[4].Width = 150;
            dataGridViewDoc.Columns[5].Width = 300;
            dataGridViewDoc.Columns[6].Width = 90;
            dataGridViewDoc.Columns[7].Width = 75;
            dataGridViewDoc.Columns[8].Width = 70;
            dataGridViewDoc.Columns[9].Width = 70;

        }

        private void CollectTotalBills()
        {
            SqlConnection con = new SqlConnection(ConectionStr);
            string SearchBill = "select top(50) * from Bills ";
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = new SqlCommand(SearchBill, con);
            adapt.Fill(dt);
            dataGridViewBill.DataSource = dt;
        }

        private void CollectTotalCollaterals()
        {
            SqlConnection con = new SqlConnection(ConectionStr);
            string SearchColl = "select top(50) * from Collaterals order by fullname desc";
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = new SqlCommand(SearchColl, con);
            adapt.Fill(dt);
            dataGridViewColls.DataSource = dt;
        }

        private void DailyStat()
        {
            int result = 0;
            decimal sum = 0;
            SqlConnection con = new SqlConnection(ConectionStr);
            // String Query = "Select count(Debt_Serial_Number) from ActionsJan where User_Id=@userid and Last_Updated=@Datetime";
            // String Query2 = "Select sum(Paid_Amount) from PAymentsJan where Last_Updated=@Datetime and Payment_Currency=@curr and Collector=@coll";
            SqlCommand cmd = new SqlCommand("DailyActionsProc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", textBoxOnlineUser.Text);
            cmd.Parameters.AddWithValue("@Datetime", DateTime.Today);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (reader.IsDBNull(0) == false)
                {
                    result = reader.GetInt32(0);
                    textBoxTodayAct.Text = result.ToString();//reader.GetString(0);
                }
                else
                {
                    textBoxTodayAct.Text = result.ToString();
                }

            }
            con.Close();
            cmd.Dispose();

            cmd = new SqlCommand("DailyCollectionsProc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Datetime", DateTime.Today);
            // cmd.Parameters.AddWithValue("@curr", "EUR");
            cmd.Parameters.AddWithValue("@coll", this.comboBoxCollector.SelectedValue);
            cmd.Parameters.AddWithValue("@ecRate", textBoxExcRate.Text);
            con.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.IsDBNull(0) == false)
                {
                    sum = reader.GetDecimal(0);
                    textBoxEur.Text = sum.ToString();//reader.GetString(0);
                }
                else
                {
                    textBoxEur.Text = sum.ToString();
                }
            }
            con.Close();
            //cmd.Dispose();

            //cmd = new SqlCommand("DailyCollectionsProc", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Datetime", DateTime.Today);
            //cmd.Parameters.AddWithValue("@curr", "ALL");
            //cmd.Parameters.AddWithValue("@coll", this.comboBoxCollector.SelectedValue);
            //con.Open();
            //reader = cmd.ExecuteReader();
            //sum = 0;
            //while (reader.Read())
            //{
            //    if (reader.IsDBNull(0) == false)
            //    {
            //        sum = reader.GetDouble(0);
            //        textBoxLek.Text = sum.ToString();//reader.GetString(0);
            //    }
            //    else
            //    {
            //        textBoxLek.Text = sum.ToString();
            //    }
            //}
            //con.Close();


        }

        private void monthlyStats()
        {
            int monthlyActions = 0;
            decimal monthlySum = 0;
            SqlConnection con = new SqlConnection(ConectionStr);
            //   String Query = "Select count(Debt_Serial_Number) from ActionsJan where User_Id like @userid+'%' and DATEPART(MM, Last_Updated)=@month and DATEPART(YYYY, Last_Updated)=@year";
            //  String Query2 = "Select sum(Paid_Amount) from PAymentsJan where Payment_month=@month and  Payment_Year=@year and  Payment_Currency=@curr and Collector=@coll";
            SqlCommand cmd = new SqlCommand("MonthlyActionsProc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", textBoxOnlineUser.Text);
            // cmd.Parameters.AddWithValue("@month", DateTime.Today.Month);
            // cmd.Parameters.AddWithValue("@year", DateTime.Today.Year);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.IsDBNull(0) == false)
                {
                    monthlyActions = reader.GetInt32(0);
                    textBoxMonthAct.Text = monthlyActions.ToString();//reader.GetString(0);
                }
                else
                {
                    textBoxMonthAct.Text = monthlyActions.ToString();
                }

            }
            con.Close();
            cmd.Dispose();

            cmd = new SqlCommand("MonthlyCollectionsProc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@month", DateTime.Today.Month);
            //cmd.Parameters.AddWithValue("@year", DateTime.Today.Year);
            cmd.Parameters.AddWithValue("@ecRate", textBoxExcRate.Text);
            cmd.Parameters.AddWithValue("@coll", this.comboBoxCollector.SelectedValue);
            con.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.IsDBNull(0) == false)
                {
                    monthlySum = reader.GetDecimal(0);
                    textBoxMonthEur.Text = monthlySum.ToString();//reader.GetString(0);
                }
                else
                {
                    textBoxMonthEur.Text = monthlySum.ToString();
                }
            }
            con.Close();
            //cmd.Dispose();

            //cmd = new SqlCommand("MonthlyCollectionsProc", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            ////cmd.Parameters.AddWithValue("@month", DateTime.Today.Month);
            ////cmd.Parameters.AddWithValue("@year", DateTime.Today.Year);
            //cmd.Parameters.AddWithValue("@curr", "ALL");
            //cmd.Parameters.AddWithValue("@coll", this.comboBoxCollector.SelectedValue);
            //con.Open();
            //reader = cmd.ExecuteReader();
            //monthlySum = 0;
            //while (reader.Read())
            //{
            //    if (reader.IsDBNull(0) == false)
            //    {
            //        monthlySum = reader.GetDouble(0);
            //        textBoxMonthLEk.Text = monthlySum.ToString();//reader.GetString(0);
            //    }
            //    else
            //    {
            //        textBoxMonthLEk.Text = monthlySum.ToString();
            //    }
            //}
            //con.Close();

        }

        private void PortofolioStat()
        {
            int result = 0;
            int result1 = 0;
            decimal sum = 0m, sum1 = 0m;
            int withpayment = 0;
            SqlConnection con = new SqlConnection(ConectionStr);
            //string Query = "Select count(Debt_Serial_Number) from DebtorsActive where Debt_Collector=@Coll and Portfolio_Status=@status";
            //string Query2 = "Select sum(Total_Outstanding) from DebtorsActive where Debt_Collector=@Coll and Currency=@curr and Portfolio_Status=@status";
            //string Query3 = "Select count(Debt_Serial_Number) from DebtorsActive where Debt_Collector=@Coll  and Portfolio_Status=@status and Latest_Person_Contacted<>@lpcont";
            //string Query4 = "Select sum(Total_Outstanding) from DebtorsActive where Debt_Collector=@Coll and Currency=@curr and Portfolio_Status=@status and Latest_Person_Contacted<>@lpcont";
            //string Query5 = "Select Debt_Serial_Number from DebtorsActive where Debt_Collector=@Coll and Portfolio_Status=@status";
            //string Query6 = "Select Debt_Serial_Number from PaymentsJan where Debt_Serial_Number=@dserial";

            SqlCommand cmd = new SqlCommand("CountTotalCasesProc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Coll", comboBoxCollector.SelectedValue);
            // cmd.Parameters.AddWithValue("@status", "Active");
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (reader.IsDBNull(0) == false)
                {
                    result = reader.GetInt32(0);
                    textBoxActive.Text = result.ToString();//reader.GetString(0);
                }
                else
                {
                    textBoxActive.Text = result.ToString();
                }
            }
            con.Close();
            cmd.Dispose();

            cmd = new SqlCommand("CountTotalSumProc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Coll", comboBoxCollector.SelectedValue);
            // cmd.Parameters.AddWithValue("@curr", "EUR");
            //cmd.Parameters.AddWithValue("@status", "Active");
            cmd.Parameters.AddWithValue("@ecRate", textBoxExcRate.Text);
            con.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.IsDBNull(0) == false)
                {
                    sum = reader.GetDecimal(0);
                    textBoxActiveEu.Text = sum.ToString();//reader.GetString(0);
                }
                else
                {
                    textBoxActiveEu.Text = sum.ToString();
                }
            }
            con.Close();
            cmd.Dispose();

            //cmd = new SqlCommand("CountTotalSumProc", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Coll", comboBoxCollector.SelectedValue);
            //cmd.Parameters.AddWithValue("@curr", "ALL");
            //cmd.Parameters.AddWithValue("@status", "Active");                     
            //con.Open();
            //reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //    if (reader.IsDBNull(0) == false)
            //    {
            //        sum = reader.GetDecimal(0);
            //        textBoxActiveLek.Text = sum.ToString();//reader.GetString(0);
            //    }
            //    else
            //    {
            //        sum = 0;
            //        textBoxActiveLek.Text = sum.ToString();
            //    }
            //}
            //con.Close();
            //cmd.Dispose();

            cmd = new SqlCommand("CountTotalWithCntProc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Coll", comboBoxCollector.SelectedValue);
            //  cmd.Parameters.AddWithValue("@lpcont", "No contact");
            //    cmd.Parameters.AddWithValue("@status", "Active");
            con.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.IsDBNull(0) == false)
                {
                    result1 = reader.GetInt32(0);
                    textBoxWithCnt.Text = result1.ToString();//reader.GetString(0);
                }
                else
                {
                    result1 = 0;
                    textBoxWithCnt.Text = result1.ToString();
                }
            }
            con.Close();
            cmd.Dispose();

            textBoxWithoutCnt.Text = (result - result1).ToString();
            //cmd = new SqlCommand("CountTotalSumWithCntProc", con);//debt sum of active debtors with contact, euro currency
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Coll", comboBoxCollector.SelectedValue);
            //cmd.Parameters.AddWithValue("@lpcont", "No contact");
            //cmd.Parameters.AddWithValue("@status", "Active");
            //cmd.Parameters.AddWithValue("@curr", "EUR");
            //con.Open();
            //reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //    if (reader.IsDBNull(0) == false)
            //    {
            //        sum = reader.GetDecimal(0);
            //        textBoxWithCntE.Text = sum.ToString();//reader.GetString(0);
            //    }
            //    else
            //    {
            //        sum = 0;
            //        textBoxWithCntE.Text = sum.ToString();
            //    }
            //}
            //con.Close();
            //cmd.Dispose();

            cmd = new SqlCommand("CountTotalSumWithCntProc", con);//debt sum of active debtors with contact, Lek currency
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Coll", comboBoxCollector.SelectedValue);
            //   cmd.Parameters.AddWithValue("@lpcont", "No contact");
            //  cmd.Parameters.AddWithValue("@status", "Active");
            cmd.Parameters.AddWithValue("@ecRate", textBoxExcRate.Text);
            con.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.IsDBNull(0) == false)
                {
                    sum1 = reader.GetDecimal(0);
                    textBoxWithCntAll.Text = sum1.ToString();//reader.GetString(0);
                }
                else
                {
                    sum1 = 0;
                    textBoxWithCntAll.Text = sum1.ToString();
                }
            }
            con.Close();
            cmd.Dispose();
            textBoxTotalWithoutCnt.Text = (sum - sum1).ToString();
            // List<string> RowsAffected = new List<string>();
            //cmd = new SqlCommand("CollectActiveCasesProc",con);
            // cmd.CommandType = CommandType.StoredProcedure;
            // cmd.Parameters.AddWithValue("@Coll", comboBoxCollector.SelectedValue);
            // cmd.Parameters.AddWithValue("@status", "Active");
            // con.Open();
            // reader = cmd.ExecuteReader();


            // while (reader.Read())//reads all affected rows
            // {
            //     RowsAffected.Add(reader.GetString(0));                     
            // }
            // con.Close();
            // cmd.Dispose();

            //string CountCases = "SELECT count(DebtorsActive.Debt_Serial_Number) from (PaymentsJan INNER JOIN DebtorsActive ON paymentsjan.Debt_Serial_Number = DebtorsActive.Debt_Serial_Number ) where DebtorsActive.Debt_Collector like '"+ comboBoxCollector.SelectedValue+"' GROUP BY DebtorsActive.Debt_Serial_Number ";
            string CountCases = "SELECT count(DebtorsActive.Debt_Serial_Number) from DebtorsActive where portfolio_status='active' and Debt_Serial_Number in( select Debt_Serial_Number from PaymentsJan where Debt_Collector='" + comboBoxCollector.SelectedValue + "')";
            cmd = new SqlCommand(CountCases, con);
            con.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                withpayment = reader.GetInt32(0);
            }
            con.Close();
            //int i=adapt.
            // adapt.Fill(dt);
            //for (int i = 0; i < RowsAffected.Count; i++)
            //{
            //    cmd = new SqlCommand("countCasesWithPayProc", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@dserial", RowsAffected[i]);
            //    con.Open();
            //    reader = cmd.ExecuteReader();
            //    if (reader.HasRows)
            //    {
            //        withpayment = withpayment + 1;
            //    }
            //    cmd.Parameters.Clear();
            //    con.Close();               
            //}
            textBox16.Text = withpayment.ToString();
        }

        private void buttonTemporary_Click(object sender, EventArgs e)
        {
            DailyStat();
            PortofolioStat();
            monthlyStats();
            objektivat(dateTimePickerPayRep);
        }

        private void objektivat(DateTimePicker dt)
        {
            //string SelectObjetctives = null;
            //if (StatusCollector.ToLower()=="admin" || StatusCollector.ToLower()=="supervisor")
            //{
            //     SelectObjetctives = "select * from objektivat where month(data)=@mon and year(data)=@yr";

            //}
            //else
            //{
            //    SelectObjetctives = "select * from objektivat where month(data)=@mon and year(data)=@yr and collector='"+ comboBoxCollector.Text+"'";
            //}
            //SqlConnection con = new SqlConnection(ConectionStr);
            //DataTable dtb = new DataTable();

            //SqlDataAdapter dtObjective = new SqlDataAdapter();
            //dtObjective.SelectCommand = new SqlCommand(SelectObjetctives, con);
            //dtObjective.SelectCommand.Parameters.AddWithValue("@mon", dt.Value.Month);
            //dtObjective.SelectCommand.Parameters.AddWithValue("@yr", dt.Value.Year);
            //dtObjective.Fill(dtb);
            // dataGridViewObjectives.DataSource = dtb;
        }
        private void buttonNewAgr_Click(object sender, EventArgs e)
        {
            //if (StatusCollector.ToLower() == "admin" || StatusCollector.ToLower() == "supervisor")
            //{ 
            if (textBoxdebtserial.Text != "")
            {
                NewContact newc = new NewContact();
                newc.ShowDialog();
            }
            else
            {
                Message();
            }
            //}
            //else
            //{
            //    MessageBox.Show("To add new clients you must be logged as administrator", "Premission denied", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //}         
        }

        //private void comboBoxClientDb_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (comboBoxClientDb.SelectedValue != null)
        //    {
        //        clientvalue = comboBoxClientDb.SelectedValue.ToString();// edited
        //    }

        //}

        //private void comboBoxPorto_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (this.comboBoxPorto.SelectedValue != null)
        //    {
        //        portovalue = this.comboBoxPorto.SelectedValue.ToString();
        //    }
        //}

        //private void comboBoxPStatus_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (this.comboBoxPStatus.SelectedValue != null)
        //    {
        //        pstatusvalue = this.comboBoxPStatus.SelectedValue.ToString();
        //    }

        //}

        //private void textBoxDbCollector_TextChanged(object sender, EventArgs e)
        //{
        //    collectorvalue = comboBoxDbCollector.Text + "%";
        //}

        //private void comboBoxLcp_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (this.comboBoxLcp.SelectedValue != null)
        //    {
        //        lastcpvalue = this.comboBoxLcp.SelectedValue.ToString();
        //        LastCp = " and latest_person_contacted " + lastcpCheck + "'" + lastcpvalue + "'";
        //    }

        //}

        //private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)//
        //{
        //    //if (comboBox2.SelectedItem.ToString() != null)
        //    //{
        //    //    reactionvalue = this.comboBox2.SelectedItem.ToString();
        //    //    ReactionQuery = " and reaction " + reactionCheck + " '" + reactionvalue + "'";
        //    //}
        //    //else
        //    //{
        //    //    ReactionQuery = "";
        //    //}
        //}


        //private void comboBoxMore_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    double.TryParse(textBoxTotOut.Text, out sumMin);
        //    if (comboBoxMore.SelectedIndex == 0)
        //    {
        //        SumQyery = " and total_outstanding>= " + sumMin;
        //    }
        //    else
        //    {
        //        SumQyery = " and total_outstanding<= " + sumMin;
        //    }

        //}

        //private void comboBoxPeriod_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (comboBoxPeriod.SelectedIndex == 0)
        //    {
        //        DateFilter = dateTimePickerDb.Text;
        //        DateQuery = " and next_action_date='" + DateFilter + "'";
        //    }
        //    else if (comboBoxPeriod.SelectedIndex == 1)
        //    {
        //        DateFilter = dateTimePickerDb.Text;
        //        DateQuery = " and next_action_date<'" + DateFilter + "'"; ;
        //    }
        //    else if (comboBoxPeriod.SelectedIndex == 2)
        //    {
        //        DateFilter = dateTimePickerDb.Text;
        //        DateQuery = " and next_action_date>'" + DateFilter + "'"; ;
        //    }
        //}

        //private void comboBoxCurrDb_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (this.comboBoxCurrDb.SelectedValue != null)
        //    {
        //        currencyvalue = this.comboBoxCurrDb.SelectedValue.ToString();
        //    }

        //}

        private void buttonfilterAdvance_Click(object sender, EventArgs e)
        {
            //string CombinedQ = "";
            //if (comboBoxClientDb.Text == "" || comboBoxClientDb.Text == null)
            //{
            //    clientvalue = "%";
            //}
            //if (checkBoxCombined.Checked == true)
            //{
            //    CombinedQ = " and debt_collector like '" + comboBoxDbCollector.Text + "%" + "'" +
            //        " and portfolio_status='active' and client like '" + clientvalue + "'" + noActionsQ + noPaymentsQ;
            //}

            //DataTable dt = new DataTable();
            //// List<string> RowsReturnet = new List<string>();
            //SqlConnection con1 = new SqlConnection(ConectionStr);
            //if (radioButtonPayDate.Checked == true)
            //{
            //    string notIn = " in ";
            //    string Period = " <= ";
            //    if (checkBoxNoPayment.Checked == true)
            //    {
            //        notIn = " not in ";
            //    }

            //    if (comboBoxBeAfter.SelectedIndex == 1)
            //    {
            //        Period = " >= ";
            //    }
            //    string Search1 = "select * from DebtorsActive where  portfolio_status='active' and Debt_Serial_Number " + notIn + " (select Debt_Serial_Number from PaymentsJan"
            //       + " where PaymentDate " + Period + "'" + dateTimePickerPay.Value + "')";
            //    SqlDataAdapter adapt = new SqlDataAdapter();
            //    adapt.SelectCommand = new SqlCommand(Search1, con1);
            //    adapt.Fill(dt);
            //}

            //else if (radioButtonPercentage.Checked == true)
            //{
            //    string valuation = "<";
            //    if (comboBoxPAyRate.SelectedIndex == 0)
            //    {
            //        valuation = ">";
            //    }
            //    else if (comboBoxPAyRate.SelectedIndex == 2)
            //    {
            //        valuation = "=";
            //    }
            //    else
            //    {
            //        valuation = "<";
            //    }
            //    string Search1 = "SELECT DebtorsActive.* from (PaymentsJan INNER JOIN DebtorsActive ON paymentsjan.Debt_Serial_Number = DebtorsActive.Debt_Serial_Number ) where DebtorsActive.Total_Outstanding>0"
            //         + "GROUP BY DebtorsActive.Debt_Serial_Number,debt_id,client,Debt_Type,Debtor_Full_Name,Portfolio_Status ,Latest_Comment,Outstanding_Principal,reassigned,Outstanding_Interest,Outstanding_Penalty,Risk,Currency,Portfolio,Debt_Collector,Total_Outstanding,Latest_Person_Contacted,Assigment_Date,Client_Branch,Next_Action_Date,DebtorsActive.Reaction,DebtorsActive.Last_Updated,DebtorsActive.User_Id,Last_Act_type,ContactedVia,PTP_Amount ,[CloseDate] ,[BranchId]  ,[DisbursmentDate]  ,[FinishedDate],[LoanTenure] ,[PmtRepayment],[AvgMoRepayment]  ,[PMTpercentage]  ,[RestructuredContract],[IsRestructured],[MonthsFromDisbursment],[MonthRecoveryRate],[RecoveryPeriod],[FPD],[DisbursmentAmount],[InALL_Base],[AmountInDelay],[PrincipalDelay],[InterestDelay],[UpComingInterest],[ClientSegment],[ProductID],[DaysInDelay],[Mortgage],[Pledge],CashColateral,classification,linkID,PayAccNo,AssignmentDebt,contractstatusid HAVING sum(Paid_Amount) * 100 / Total_Outstanding" +
            //        valuation + trackBar1.Value.ToString() + CombinedQ + " order by debtor_full_name desc";

            //    // string Search2 = "SELECT * from DebtorsActive where Debt_Serial_Number in (select Debt_Serial_Number from paymentsjan) where  sum(Paid_Amount) * 100 / Total_Outstanding ";
            //    SqlDataAdapter adapt = new SqlDataAdapter();
            //    adapt.SelectCommand = new SqlCommand(Search1, con1);
            //    adapt.Fill(dt);
            //}
            //else if (radioButtonAct.Checked == true)
            //{
            //    string valuation = "<";
            //    if (comboBoxActNr.SelectedIndex == 0)
            //    {
            //        valuation = ">";
            //    }
            //    else
            //    {
            //        valuation = "<";
            //    }

            //    string Search1 = "SELECT DebtorsActive.* FROM (ActionsJan inner JOIN DebtorsActive ON ActionsJan.Debt_Serial_Number = DebtorsActive.Debt_Serial_Number ) GROUP BY DebtorsActive.Debt_Serial_Number ,debt_id,client,Debt_Type,risk,Debtor_Full_Name,Portfolio_Status ,Latest_Comment,Outstanding_Principal,Outstanding_Interest,Outstanding_Penalty,Currency,Portfolio,Debt_Collector,Total_Outstanding,Latest_Person_Contacted,Assigment_Date,Client_Branch,Next_Action_Date,DebtorsActive.Reaction,DebtorsActive.Last_Updated,DebtorsActive.User_Id,Last_Act_type,ContactedVia,PTP_Amount   ,[CloseDate] ,[BranchId]  ,[DisbursmentDate]  ,[FinishedDate],[LoanTenure] ,[PmtRepayment],[AvgMoRepayment]  ,[PMTpercentage]  ,[RestructuredContract],[IsRestructured],[MonthsFromDisbursment],[MonthRecoveryRate],[RecoveryPeriod],[FPD],[DisbursmentAmount],[InALL_Base],[AmountInDelay],[PrincipalDelay],[InterestDelay],[UpComingInterest],[ClientSegment],[ProductID],[DaysInDelay],[Mortgage],[Pledge],[CashColateral],classification,linkID,PayAccNo,reassigned,AssignmentDebt,contractstatusid HAVING COUNT (ActionsJan.ID)" + valuation + textBoxActionNr.Text + CombinedQ + ";";
            //    SqlDataAdapter adapt = new SqlDataAdapter();
            //    adapt.SelectCommand = new SqlCommand(Search1, con1);
            //    adapt.Fill(dt);
            //    textBoxdebtserial.Text = "";
            //    rowIndex = -2;
            //}

            ////for (int i = 0; i < RowsReturnet.Count; i++)
            ////{
            ////    string fillGrid = "select * from debtorsactive where debt_serial_number='" + RowsReturnet[i].ToString() + "'" + " and portfolio_status='active'" + CombinedQ;
            ////    SqlDataAdapter adapt = new SqlDataAdapter();
            ////    adapt.SelectCommand = new SqlCommand(fillGrid, con1);
            ////    adapt.Fill(dt);
            ////}
            //dataGridViewDebtors.DataSource = dt;
            //labelRowCount.Text = "Results: " + dataGridViewDebtors.RowCount;
            //tabControl.SelectedTab = tabPageDebts;
        }

        //private void checkBox1_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBox1.Checked == true)
        //    {
        //        reactionCheck = " not like ";
        //    }
        //    else
        //    {
        //        reactionCheck = " like ";
        //    }
        //    comboBox2_SelectedIndexChanged(sender, e);
        //}


        //private void checkBoxCurr_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBoxCurr.Checked == true)
        //    {
        //        currencyCheck = " not like ";
        //    }
        //    else
        //    {
        //        currencyCheck = " like ";
        //    }
        //}

        //private void checkBoxCombined_CheckedChanged(object sender, EventArgs e)
        //{
        //}

        //private void checkBoxNoact_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBoxNoact.Checked == true)//check for debts that do not have actions
        //    {
        //        noActionsQ = " and Debt_Serial_Number not in (select Debt_Serial_Number from actionsjan) ";
        //    }
        //    else
        //    {
        //        noActionsQ = "";
        //    }
        //}

        //private void checkBoxNoPay_CheckedChanged(object sender, EventArgs e)
        //{
        //    //check for debts that do not have Payments
        //    if (checkBoxNoPay.Checked == true)
        //    {
        //        noPaymentsQ = " and Debt_Serial_Number not in (select Debt_Serial_Number from paymentsJan) ";
        //    }
        //    else
        //    {
        //        noPaymentsQ = "";
        //    }
        //}

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBoxPErcent.Text = trackBar1.Value.ToString();
        }

        private void ActionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button4_Click(sender, e);
        }

        private void comboBoxClinstPAy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxClinstPAy.SelectedValue != null)
            {
                cliendQuery = " and client_institution like '" + comboBoxClinstPAy.SelectedValue.ToString() + "' ";
            }
        }

        private void comboBoxMore2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMore2.SelectedIndex == 0)
            {
                paymentQuery = " and paid_amount>=" + textBoxPaidAmt.Text;
            }
            else
            {
                paymentQuery = " and paid_amount<" + textBoxPaidAmt.Text;
            }
        }

        private void comboBoxSelPeriod1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateTimePickerPer.CustomFormat = "dd/MM/yyyy";
            if (comboBoxSelPeriod1.SelectedIndex == 0)
            {
                dateQuery = " and  Month( paymentDate)=" + dateTimePickerPer.Value.Month + " and Year(paymentDate)=" + dateTimePickerPer.Value.Year;
            }
            else if (comboBoxSelPeriod1.SelectedIndex == 1)
            {
                dateQuery = " and paymentDAte<='" + dateTimePickerPer.Value + "' ";
            }
            else if (comboBoxSelPeriod1.SelectedIndex == 2)
            {
                dateQuery = " and paymentDAte>'" + dateTimePickerPer.Value + "' ";
            }
        }

        private void comboBoxPayCurr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxPayCurr.SelectedValue != null || this.comboBoxPayCurr.SelectedText.ToLower() != "please select")
            {
                PaymentCurrQuery = " and payment_currency='" + comboBoxPayCurr.SelectedValue + "' ";
            }
        }

        private void comboBoxPeriod1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateTimePickerLastP.CustomFormat = "dd/MM/yyyy";
            if (comboBoxPeriod1.SelectedIndex == 0)
            {
                lastupdatedPQuery = " and  Month( last_updated)=" + dateTimePickerLastP.Value.Month + " and Year(last_updated)=" + dateTimePickerLastP.Value.Year + " and day(last_updated)=" + dateTimePickerLastP.Value.Day;
            }
            else if (comboBoxPeriod1.SelectedIndex == 1)
            {
                lastupdatedPQuery = " and last_updated<='" + dateTimePickerLastP.Value + "' ";
            }
            else if (comboBoxPeriod1.SelectedIndex == 2)
            {
                lastupdatedPQuery = " and last_updated>'" + dateTimePickerLastP.Value + "' ";
            }
        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonNewPayment_Click(sender, e);
        }

        private void textBoxPayColl_TextChanged(object sender, EventArgs e)
        {
            CollectorPay = textBoxPayColl.Text;
        }

        private void textBoxPaidAmt_TextChanged(object sender, EventArgs e)
        {
            comboBoxMore2_SelectedIndexChanged(sender, e);
        }

        private void comboBoxPayColl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void contactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonNewAgr_Click(sender, e);
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonLogOut_Click(sender, e);
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            Notifications not = new Notifications();
            not.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int Tempindex = pointer + 1;
            //pointer += 1;
            int MAXindes = History.Count - 1;
            if (Tempindex <= MAXindes)
            {
                pointer += 1;
                textBoxSearch.Text = History[Tempindex];
            }
        }



        //private void maskedTextBoxPTP_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        //{
        //    comboBoxPromise_SelectedIndexChanged(sender, e);

        //}


        private void comboBoxCollClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCollClient.SelectedValue != null)
            {
                CollClientValue = comboBoxCollClient.SelectedValue.ToString();
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.SelectedItem != null)
            {
                CollNameQuery = " and collateralname like '" + comboBox5.SelectedItem.ToString() + "' ";
            }
        }

        private void comboBoxValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxValue.SelectedIndex == 0)
            {
                CollValuesQuery = " and  collateralvalue>=" + textBoxValue.Text;
            }
            else
            {
                CollValuesQuery = " and  collateralvalue<" + textBoxValue.Text;
            }
        }

        private void comboBoxCollType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCollType.SelectedItem != null)
            {
                CollTypeQuery = " and collateraltype like '" + comboBoxCollType.SelectedItem.ToString() + "' ";
            }
        }

        private void textBoxValue_TextChanged(object sender, EventArgs e)
        {
            comboBoxValue_SelectedIndexChanged(sender, e);
        }

        private void dateTimePickerColl_ValueChanged(object sender, EventArgs e)
        {
            comboBox3_SelectedIndexChanged(sender, e);
        }

        private void comboBoxActTypeAct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxActTypeAct.SelectedValue != null)
            {
                atypeQuery = " and action_type like '" + comboBoxActTypeAct.SelectedValue.ToString() + "' ";
            }
        }

        private void comboBoxPersonCl_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBoxPersonCl.SelectedValue != null)
            //{
            //    CntClientQuery = " and client_institution like '" + comboBoxPersonCl.SelectedValue.ToString() + "' ";
            //}
        }

        private void textBoxPersDistr_TextChanged(object sender, EventArgs e)
        {
            //if (textBoxPersDistr.Text != null || textBoxPersDistr.Text != "")
            //{
            //    districtvalue = textBoxPersDistr.Text + "%";
            //}
            //else
            //{
            //    districtvalue = "%";
            //}

        }

        private void comboBoxPerStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBoxPerStatus.Text != null)
            //{
            //    PersonStatusQuery = " and relation like '" + comboBoxPerStatus.Text + "' ";
            //}
        }

        private void checkBoxNoCnt_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBoxNoCnt.Checked == true)
            //{
            //    noCntQuery = " and person_number in (select debt_serial_number from debtorsactive where latest_person_contacted='no contact') ";
            //}
            //else
            //{
            //    noCntQuery = "";
            //}
        }

        private void checkBoxEmail_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBoxEmail.Checked == true)
            //{
            //    emailQuery = " and (email is not null AND email<>'') ";
            //}
            //else
            //{
            //    emailQuery = "";
            //}
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void buttonSplitDebts_Click(object sender, EventArgs e)
        {
            if (splitContainerDebtors.Panel1.Width > 50)
            {
                splitContainerDebtors.SplitterDistance = 50;
            }
            else
            {
                splitContainerDebtors.SplitterDistance = 419;
            }
        }


        private void textBoxCommentsAct_TextChanged(object sender, EventArgs e)
        {
            commentQuery = " and comments like '%" + textBoxCommentsAct.Text + "%'";
        }

        private void chartAMount_Click(object sender, EventArgs e)
        {

        }

        private void chartActions_Click(object sender, EventArgs e)
        {

        }

        private void buttonc1_Click(object sender, EventArgs e)
        {
            //screen += "1";
            ContactNo.Add("1");

            //richTextBoxPhone.Text = screen;
            //richTextBoxPhone.Text=ContactNo[1];
        }

        private void buttonc2_Click(object sender, EventArgs e)
        {
            //  screen += "2";
            ContactNo.Add("2");
            //  richTextBoxPhone.Text = screen;
        }

        private void buttonc0_Click(object sender, EventArgs e)
        {
            //  screen += "0";
            ContactNo.Add("0");
            // richTextBoxPhone.Text = screen;
        }

        private void buttonc4_Click(object sender, EventArgs e)
        {
            // screen += "4";
            ContactNo.Add("4");
            //  richTextBoxPhone.Text = screen;
        }

        private void buttonc5_Click(object sender, EventArgs e)
        {
            // screen += "5";
            ContactNo.Add("5");
            //richTextBoxPhone.Text = screen;
        }

        private void buttonc3_Click(object sender, EventArgs e)
        {
            // screen += "3";
            ContactNo.Add("3");
            //  richTextBoxPhone.Text = screen;
        }

        private void buttonc6_Click(object sender, EventArgs e)
        {
            // screen += "6";
            ContactNo.Add("6");
            //  richTextBoxPhone.Text = screen;
        }

        private void buttonc7_Click(object sender, EventArgs e)
        {
            // screen += "7";
            ContactNo.Add("7");
            // richTextBoxPhone.Text = screen;
        }

        private void buttonc8_Click(object sender, EventArgs e)
        {
            //  screen += "8";
            ContactNo.Add("8");
            // richTextBoxPhone.Text = screen;
        }

        private void buttonCallEnd_Click(object sender, EventArgs e)
        {
            // endCall = "Call ended";
            // richTextBoxPhone.Text = screen + "\n" + endCall;
            // richTextBoxPhone.ForeColor = Color.Red;
            // Thread.Sleep(500);
            //richTextBoxPhone.ForeColor = Color.Blue;

        }

        private void Button24_Click(object sender, EventArgs e)
        {
            if (ContactNo.Count > 0)
            {
                //  screen = "";
                ContactNo.RemoveAt(ContactNo.Count - 1);
                for (int i = 0; i < ContactNo.Count; i++)
                {
                    //       screen += ContactNo[i];
                }
                //   richTextBoxPhone.Text = screen;
                //  richTextBoxPhone.ForeColor = Color.Blue;
            }
        }

        private void developerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string lnk = "https://al.linkedin.com/in/admir-tërshalla-a734b638";
            Process.Start(lnk);
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            if (StatusCollector.ToLower() == "admin" || StatusCollector.ToLower() == "supervisor" || StatusCollector.ToLower() == "agent")
            {
                List<string> rowsChecked = new List<string>();
                foreach (DataGridViewRow row in dataGridViewPersons.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[iDButtonCloumn.Name].Value) == true)
                    {
                        rowsChecked.Add(row.Cells[personIdDataGridViewTextBoxColumn.Name].Value.ToString());
                    }
                }
                int CheckedRows = rowsChecked.Count;
                if (CheckedRows != 0)
                {
                    if (MessageBox.Show("Are you sure you want to delete " + CheckedRows.ToString() + " contacts?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        for (int i = 0; i < CheckedRows; i++)
                        {
                            String Query = " Delete From Persons  where Person_id=@id";
                            SqlConnection con = new SqlConnection(ConectionStr);
                            SqlCommand command = new SqlCommand(Query, con);
                            int ID;
                            int.TryParse(rowsChecked[i], out ID);
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
                        }

                        labelDeletedCnt.Text = CheckedRows.ToString() + " contacts deleted successfuly.";
                    }
                }
                else
                {
                    MessageBox.Show("At least one row must be selected", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("In order to delete contacts you must be logged in as Administrator.", "No premission", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void comboBoxDebts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string select = null;
            SqlConnection con = new SqlConnection(ConectionStr);
            if (comboBoxDebts.SelectedIndex == 0)
            {
                select = "clientstat";
            }

            else if (comboBoxDebts.SelectedIndex == 1)
            {
                select = "portfoliostat";
            }

            else if (comboBoxDebts.SelectedIndex == 3)
            {
                select = "RaiffeisenReport";
            }

            else if (comboBoxDebts.SelectedIndex == 4)
            {
                select = "AlphaBank";
            }

            else if (comboBoxDebts.SelectedIndex == 5)
            {
                select = "TebReport";
            }

            else if (comboBoxDebts.SelectedIndex == 6)
            {
                select = "GeneralReport";
            }
            else if (comboBoxDebts.SelectedIndex == 7)
            {
                select = "spinrate";
            }
            //else if (comboBoxDebts.SelectedIndex == 8)
            //{
            //    select = "report4";
            //}
            else
            {
                select = "portfolioCollectorClient";
                //  select = "select debt_collector as [Collector] ,count(total_outstanding) as [Cases],sum(total_outstanding) " +
                //" as [Total amount],count( case  when Latest_Person_Contacted<>'no contact' then 1 end) as [With Contact] " +
                //",sum( case  when Latest_Person_Contacted<>'no contact' then total_outstanding end) as [Amount With Cnt] from " +
                //"DebtorsActive where portfolio_status='active' group by debt_collector order by debt_collector asc ";
            }

            if (select != "AlphaBank" && select != "RaiffeisenReport" && select != "TebReport" && select != "GeneralReport")
            {
                DataTable dt = new DataTable();
                SqlDataAdapter adapt = new SqlDataAdapter();
                adapt.SelectCommand = new SqlCommand(select, con);
                adapt.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapt.Fill(dt);
                dataGridViewStaticCollectors.DataSource = dt;
                dataGridViewStaticCollectors.Columns[0].Width = 200;
                for (int i = 2; i < dataGridViewStaticCollectors.Columns.Count; i++)
                {
                    dataGridViewStaticCollectors.Columns[i].Width = 90;
                }
                dataGridViewStaticCollectors.Columns[0].Frozen = true;
            }



        }

        private void comboBoxActionRep_SelectedIndexChanged(object sender, EventArgs e)
        {
            string select = null;
            SqlConnection con = new SqlConnection(ConectionStr);
            if (comboBoxActionRep.SelectedIndex == 0)
            {
                select = "select client_institution as Client, count(case when month(last_updated)=month(GetDate()) and YEAR(last_updated)=year(getdate()) then 1 end ) as Monthly " +
                ", count(case when month(last_updated) = month(GetDate()) and YEAR(last_updated) = year(getdate()) and Action_Type = 'phone call' then 1 end) as Calls " +
                ",count(case when month(last_updated) = month(GetDate()) and YEAR(last_updated) = year(getdate()) and Action_Type like '%sms%' then 1 end) as SMS " +
                ",count(case when month(last_updated) = month(GetDate()) and YEAR(last_updated) = year(getdate()) and Action_Type like '%letter%' then 1 end) as Letters " +
                ",count(case when month(last_updated) = month(GetDate()) and YEAR(last_updated) = year(getdate()) and Action_Type like '%field%' then 1 end) as Field " +
                 ",count(case when month(last_updated) = month(GetDate()) and YEAR(last_updated) = year(getdate()) and Reaction = 'promises to pay' then 1 end) as Promises " +
                ",count(case when day(last_updated) = day(getdate()) and YEAR(last_updated) = year(getdate()) and month(last_updated) = month(GetDate()) then 1 end) as Today " +
                "from ActionsJan group by client_institution " +
                "order by Monthly desc, Today desc";
            }

            else
            {
                select = "select user_id as [User], count(case when month(last_updated)=month(GetDate()) and YEAR(last_updated)=year(getdate()) then 1 end ) as Monthly " +
                ", count(case when month(last_updated) = month(GetDate()) and YEAR(last_updated) = year(getdate()) and Action_Type = 'phone call' then 1 end) as Calls " +
                ",count(case when month(last_updated) = month(GetDate()) and YEAR(last_updated) = year(getdate()) and Action_Type like '%sms%' then 1 end) as SMS " +
                ",count(case when month(last_updated) = month(GetDate()) and YEAR(last_updated) = year(getdate()) and Action_Type like '%letter%' then 1 end) as Letters " +
                ",count(case when month(last_updated) = month(GetDate()) and YEAR(last_updated) = year(getdate()) and Action_Type like '%field%' then 1 end) as Field " +
                ",count(case when month(last_updated) = month(GetDate()) and YEAR(last_updated) = year(getdate()) and Reaction = 'promises to pay' then 1 end) as Promises, " +
                "count(case when month(last_updated) = month(GetDate()) and YEAR(last_updated) = year(getdate()) and Day(last_updated) = Day(getdate()) then 1 end) as Daily " +
                " from ActionsJan group by user_id " +
                "order by Monthly desc";
            }


            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = new SqlCommand(select, con);
            adapt.Fill(dt);
            dataGridViewActionRep.DataSource = dt;
            dataGridViewActionRep.Columns[0].Width = 200;
            for (int i = 1; i < dataGridViewActionRep.Columns.Count; i++)
            {
                dataGridViewActionRep.Columns[i].Width = 65;
            }
            dataGridViewActionRep.Columns[0].Frozen = true;
        }

        private void comboBoxPaymentsRep_SelectedIndexChanged(object sender, EventArgs e)
        {
            string select = null;
            SqlConnection con = new SqlConnection(ConectionStr);
            if (comboBoxPaymentsRep.SelectedIndex == 0)
            {
                select = "select client_institution,sum(case when Payment_Currency='all' and MONTH(paymentDate)=month(@date) and YEAR(paymentDate)=year(@date) then Paid_Amount  when payment_currency='usd' " +
                 "and MONTH(paymentDate) = month(@date) and YEAR(paymentDate) = year(@date) then Paid_Amount * 128 when Payment_Currency = 'eur' and   MONTH(paymentDate) = month(@date) and " +
                "YEAR(paymentDate) = year(@date) then Paid_Amount * 138  end ) as [Sum(ALL)],sum( case when PaymentDate = @date and Payment_Currency='all' then Paid_Amount when PaymentDate = @date and Payment_Currency='eur' then Paid_Amount*138 when PaymentDate = @date and Payment_Currency='usd' then Paid_Amount*128  end) as [Payments Today], " +
                "count( case when MONTH(paymentDate)=month(@date) and YEAR(paymentDate)=year(@date) then 1 end) as Payments " +
                "from PaymentsJan group by client_institution order by[Sum(ALL)] desc";
            }

            else
            {
                select = "select collector,sum(case when Payment_Currency='all' and MONTH(paymentDate)=month(@date) and YEAR(paymentDate)=year(@date) then Paid_Amount  when payment_currency='usd' " +
                "and MONTH(paymentDate) = month(@date) and YEAR(paymentDate) = year(@date) then Paid_Amount * 128 when Payment_Currency = 'eur' and   MONTH(paymentDate) = month(@date) and " +
               "YEAR(paymentDate) = year(@date) then Paid_Amount * 138  end ) as [Sum(ALL)],sum( case when PaymentDate = @date and Payment_Currency='all' then Paid_Amount when PaymentDate = @date and Payment_Currency='eur' then Paid_Amount*138 when PaymentDate = @date and Payment_Currency='usd' then Paid_Amount*128  end) as [Payments Today], " +
               "count(case when MONTH(paymentDate)=month(@date) and YEAR(paymentDate)=year(@date) then 1 end) as Payments " +
               "from PaymentsJan group by collector order by[Sum(ALL)] desc";
            }


            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = new SqlCommand(select, con);
            DateTime dtime = dateTimePickerPayRep.Value;
            adapt.SelectCommand.Parameters.AddWithValue("@date", dtime);
            adapt.Fill(dt);
            dataGridViewPaymentsRep.DataSource = dt;
            dataGridViewPaymentsRep.Columns[0].Width = 200;
            for (int i = 1; i < dataGridViewPaymentsRep.Columns.Count; i++)
            {
                dataGridViewPaymentsRep.Columns[i].Width = 100;
            }
        }

        private void groupBoxFilterdb_Enter(object sender, EventArgs e)
        {

        }

        private void buttonc9_Click(object sender, EventArgs e)
        {
            //screen += "9";
            ContactNo.Add("9");
            //richTextBoxPhone.Text = screen;
        }

        private void ButtonRefreshActions_Click(object sender, EventArgs e)
        {
            Action<Control.ControlCollection> func = null;
            func = (controls) =>
            {
                foreach (Control control in groupBox1.Controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else if (control is ComboBox)
                        (control as ComboBox).SelectedItem = null;
            };

            func(Controls);
            textBoxUserAct.Text = usernamevalue;
        }

        private void TabFoundNAmesSelect(object sender, TabControlEventArgs e)
        {
            if (FAMID != "" && FAMID != null && FAMID != "-")
            {
                if (tabControlFoundNames.SelectedTab == tabPageFoundNumbers)
                {
                    collectNumbers();
                }
                else if (tabControlFoundNames.SelectedTab == tabPageFoundWork)
                {
                    collectWork();
                }

            }
            else if (FAMID == "-" || FAMID == null || FAMID == "")
            {
                if (tabControlFoundNames.SelectedTab == tabPageFoundNumbers)
                {
                    collectNIDnumbers();
                }
                else if (tabControlFoundNames.SelectedTab == tabPageFoundWork)
                {
                    collectNIDwork();
                }
            }

            else if (tabControlFoundNames.SelectedTab != tabPageFoundNames)
            {
                MessageBox.Show(" Please select a row", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabControlFoundNames.SelectedIndex = 0;
            }
        }

        private void collectNIDnumbers()
        {
            if (NID != null && NID != "")
            {
                string ConnectionSkip = "Data Source=skipdbs.database.windows.net;Initial Catalog=SkipDtb;User ID=TotalDtb;Password=Trsdmr92l161";

                DataTable dt = new DataTable();
                SqlConnection con1 = new SqlConnection(ConnectionSkip);
                SqlDataAdapter adapt = new SqlDataAdapter();

                adapt.SelectCommand = new SqlCommand("FindPersonalNumbers", con1);
                adapt.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapt.SelectCommand.Parameters.AddWithValue("@nid", NID);
                adapt.Fill(dt);

                dataGridViewFoundNumbers.DataSource = dt;
                dataGridViewFoundNumbers.Columns[0].Frozen = true;
                dataGridViewFoundNumbers.Columns[1].Frozen = true;
                dataGridViewFoundNumbers.Columns[2].Frozen = true;
                dataGridViewFoundNumbers.Columns[3].Frozen = true;
            }
            else
            {

                while (dataGridViewFoundNumbers.Rows.Count > 0)
                {
                    dataGridViewFoundNumbers.Rows.RemoveAt(0);
                }
            }


        }

        private void collectNIDwork()
        {
            if (NID != null && NID != "")
            {
                string ConnectionSkip = "Data Source=skipdbs.database.windows.net;Initial Catalog=SkipDtb;User ID=TotalDtb;Password=Trsdmr92l161";

                DataTable dt = new DataTable();
                SqlConnection con1 = new SqlConnection(ConnectionSkip);
                SqlDataAdapter adapt = new SqlDataAdapter();

                adapt.SelectCommand = new SqlCommand("FindPersonalWork", con1);
                adapt.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapt.SelectCommand.Parameters.AddWithValue("@nid", NID);
                adapt.Fill(dt);

                dataGridViewFoundWork.DataSource = dt;
                dataGridViewFoundWork.Columns[0].Frozen = true;
                dataGridViewFoundWork.Columns[1].Frozen = true;
                dataGridViewFoundWork.Columns[2].Frozen = true;

            }
            else
            {

                while (dataGridViewFoundWork.Rows.Count > 0)
                {
                    dataGridViewFoundWork.Rows.RemoveAt(0);
                }
            }
        }
        private void collectNumbers()
        {
            string ConnectionSkip = "Data Source=skipdbs.database.windows.net;Initial Catalog=SkipDtb;User ID=TotalDtb;Password=Trsdmr92l161";

            DataTable dt = new DataTable();
            SqlConnection con1 = new SqlConnection(ConnectionSkip);
            SqlDataAdapter adapt = new SqlDataAdapter();

            adapt.SelectCommand = new SqlCommand("FindFamNumbers", con1);
            adapt.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapt.SelectCommand.Parameters.AddWithValue("@famID", FAMID);
            adapt.Fill(dt);

            dataGridViewFoundNumbers.DataSource = dt;
        }

        private void collectWork()
        {
            string ConnectionSkip = "Data Source=skipdbs.database.windows.net;Initial Catalog=SkipDtb;User ID=TotalDtb;Password=Trsdmr92l161";

            DataTable dt = new DataTable();
            SqlConnection con1 = new SqlConnection(ConnectionSkip);
            SqlDataAdapter adapt = new SqlDataAdapter();

            adapt.SelectCommand = new SqlCommand("FindFamWork", con1);
            adapt.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapt.SelectCommand.Parameters.AddWithValue("@famID", FAMID);
            adapt.Fill(dt);

            dataGridViewFoundWork.DataSource = dt;
        }

        private void ButtonRefreshPayments_Click(object sender, EventArgs e)
        {
            Action<Control.ControlCollection> func = null;
            func = (controls) =>
            {
                foreach (Control control in groupBoxFilterPay.Controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else if (control is ComboBox)
                        (control as ComboBox).SelectedItem = null;
            };

            func(Controls);
            textBoxPayColl.Text = LogedCollector;
        }

        private void Tabselect(object sender, TabControlEventArgs e)
        {
            if (textBoxdebtserial.Text != "")
            {
                if (tabControl.SelectedTab == tabPagePay)
                {
                    collectPayments();
                }
                else if (tabControl.SelectedTab == tabPageAct)
                {
                    collectActions();
                }
                else if (tabControl.SelectedTab == tabPage1Persons)
                {
                    CollectPerson(textBoxdebtserial);
                }
                else if (tabControl.SelectedTab == tabPageColateral)
                {
                    CollectCollaterals(textBoxdebtserial);
                }

                else if (tabControl.SelectedTab == tabPageBills)
                {
                    CollectBills(textBoxdebtserial);
                }

                else if (tabControl.SelectedTab == tabPageMSDN)
                {
                    CollectMSDN(textBoxdebtserial);
                }

                else if (tabControl.SelectedTab == tabPageDokumentet)
                {
                    CollectDoc(textBoxdebtserial);
                }
            }

            else if (tabControl.SelectedTab != tabPageDebts)
            {
                Message();
                tabControl.SelectedIndex = 0;
            }
        }



        private void buttonSkipDataSearch_Click(object sender, EventArgs e)
        {
            if (StatusCollector.ToLower() != "guest")
            {
                worker1.RunWorkerAsync();
                buttonSkipDataSearch.Enabled = false;
                SkipColumn.ReadOnly = true;
                textBoxFnameSkip.Enabled = false;
                textBoxLnameSkip.Enabled = false;
                textBoxAtesiSkip.Enabled = false;
                textBoxBdateSkip.Enabled = false;
                textBoxAmesiSkip.Enabled = false;
            }

        }

        private void SeekData(object sender, DoWorkEventArgs e)
        {       
            string subject = "";

            if (usernamevalue == "emuca" || textBoxLnameSkip.Text.ToLower() == "tershalla")
            {
                subject = textBoxFnameSkip.Text + " | " + textBoxLnameSkip.Text + " | " + textBoxAtesiSkip.Text + " | " + textBoxAmesiSkip.Text + " | " + textBoxBdateSkip.Text;
            }
            else
            {
                subject = "";
            }

            BackgroundWorker bgWorker1 = (BackgroundWorker)sender;

            string insertU = "insert into usage(username,timestamp,pcip,Subject,pcname) values (@username,@time,@ip,@subject,@pname)";
            FAMID = "";
            NID = "";
            string ConnectionSkip = "Data Source=skipdbs.database.windows.net;Initial Catalog=SkipDtb;User ID=TotalDtb;Password=Trsdmr92l161";
            DataTable dt = new DataTable();
            SqlConnection con1 = new SqlConnection(ConnectionSkip);
            //string Search1 = "SELECT * FROM DebtorsActive where debt_collector='" + LogedCollector + "' and debt_serial_number in ( select serialCode from tasks where taskno=" + indeks + ")  order by risk desc";
            SqlCommand cmd = new SqlCommand(insertU, con1);
            cmd.Parameters.AddWithValue("@username", usernamevalue);
            cmd.Parameters.AddWithValue("@time", DateTime.Now.ToUniversalTime());
            cmd.Parameters.AddWithValue("@subject", subject);
            cmd.Parameters.AddWithValue("@pname", System.Environment.MachineName);
            //string hostName = Dns.GetHostName(); // Retrive the Name of HOST
            //                                     //  Console.WriteLine(hostName);
            //                                     // Get the IP
            //string myIP = Dns.GetHostEntry(hostName).AddressList[0].ToString();
            //string IPS = Dns.GetHostByName(hostName).AddressList[0].ToString();
            //// Console.WriteLine("My IP Address is :" + myIP);
            //// Console.ReadKey();
            string PICPS = null;
            try
            {
                PICPS = new WebClient().DownloadString("http://icanhazip.com");
            }
            catch (Exception)
            {

                MessageBox.Show("Error in first connection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (PICPS == null || PICPS == "")
            {
                try
                {
                    PICPS = new WebClient().DownloadString("http://api.ipify.org");
                }
                catch (Exception)
                {

                    MessageBox.Show("Error in second connection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

            cmd.Parameters.AddWithValue("@ip", PICPS);
            con1.Open();
            cmd.ExecuteNonQuery();
            con1.Close();
            cmd.Dispose();

            string nullVAlue = null;
            if (textBoxBdateSkip.Text == null || textBoxBdateSkip.Text == "" || textBoxBdateSkip.Text == " ")
            {
                nullVAlue = "";
            }
            else
            {
                nullVAlue = textBoxBdateSkip.Text;
            }
            //  dtskip.Dispose();
            DataTable dtSkip2 = new DataTable();

            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = new SqlCommand("SkipSearch", con1);
            adapt.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapt.SelectCommand.CommandTimeout = 90;
            adapt.SelectCommand.Parameters.AddWithValue("@name", textBoxFnameSkip.Text.Trim());
            adapt.SelectCommand.Parameters.AddWithValue("@lname", textBoxLnameSkip.Text.Trim());
            adapt.SelectCommand.Parameters.AddWithValue("@father", textBoxAtesiSkip.Text.Trim());
            adapt.SelectCommand.Parameters.AddWithValue("@bdate", nullVAlue);
            adapt.SelectCommand.Parameters.AddWithValue("@mother", textBoxAmesiSkip.Text.Trim());
            adapt.Fill(dtSkip2);
            dtskip = dtSkip2;
            // dataGridViewNames.DataSource = dtskip;
        }

        private void SeekDataSkip(object sender, DoWorkEventArgs e)
        {

            string subject = "";

            if (usernamevalue == "emuca" || textBoxLnameSkip.Text.ToLower() == "tershalla")
            {
                subject = textBoxFnameSkip.Text + " | " + textBoxLnameSkip.Text + " | " + textBoxAtesiSkip.Text + " | " + textBoxAmesiSkip.Text + " | " + textBoxBdateSkip.Text;
            }
            else
            {
                subject = "";
            }

            BackgroundWorker bgWorker1 = (BackgroundWorker)sender;

            string insertU = "insert into usage(username,timestamp,pcip,Subject,pcname) values (@username,@time,@ip,@subject,@pname)";
            FAMID = "";
            NID = "";
            string ConnectionSkip = "Data Source=skipdbs.database.windows.net;Initial Catalog=SkipDtb;User ID=TotalDtb;Password=Trsdmr92l161";
            DataTable dt = new DataTable();
            SqlConnection con1 = new SqlConnection(ConnectionSkip);
            //string Search1 = "SELECT * FROM DebtorsActive where debt_collector='" + LogedCollector + "' and debt_serial_number in ( select serialCode from tasks where taskno=" + indeks + ")  order by risk desc";
            SqlCommand cmd = new SqlCommand(insertU, con1);
            cmd.Parameters.AddWithValue("@username", usernamevalue);
            cmd.Parameters.AddWithValue("@time", DateTime.Now.ToUniversalTime());
            cmd.Parameters.AddWithValue("@subject", subject);
            cmd.Parameters.AddWithValue("@pname", System.Environment.MachineName);
            //string hostName = Dns.GetHostName(); // Retrive the Name of HOST
            //                                     //  Console.WriteLine(hostName);
            //                                     // Get the IP
            //string myIP = Dns.GetHostEntry(hostName).AddressList[0].ToString();
            //string IPS = Dns.GetHostByName(hostName).AddressList[0].ToString();
            //// Console.WriteLine("My IP Address is :" + myIP);
            //// Console.ReadKey();
            string PICPS = null;
            try
            {
                PICPS = new WebClient().DownloadString("http://icanhazip.com");
            }
            catch (Exception)
            {

                MessageBox.Show("Error in first connection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (PICPS == null || PICPS == "")
            {
                try
                {
                    PICPS = new WebClient().DownloadString("http://api.ipify.org");
                }
                catch (Exception)
                {

                    MessageBox.Show("Error in second connection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

            cmd.Parameters.AddWithValue("@ip", PICPS);
            con1.Open();
            cmd.ExecuteNonQuery();
            con1.Close();
            cmd.Dispose();


            DataTable dtSkip2 = new DataTable();

            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = new SqlCommand("UserSkipSearch", con1);
            adapt.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapt.SelectCommand.CommandTimeout = 90;
            adapt.SelectCommand.Parameters.AddWithValue("@name", fname);
            adapt.SelectCommand.Parameters.AddWithValue("@lname", lname);

            adapt.Fill(dtSkip2);
            dtskip = dtSkip2;

        }


        void work_complete(object sender, RunWorkerCompletedEventArgs e)
        {

            //  dataGridViewNames.DataSource = null;
            dataGridViewNames.DataSource = dtskip;
            // dtskip.Dispose();
            // dtskip.Rows.Clear();

            dataGridViewNames.Columns[0].Frozen = true;
            dataGridViewNames.Columns[1].Frozen = true;
            dataGridViewNames.Columns[2].Frozen = true;
            dataGridViewNames.Columns[6].DefaultCellStyle.ForeColor = Color.Red;
            dataGridViewNames.Columns[10].Width = 200;
            dataGridViewNames.Columns[9].Width = 40;
            dataGridViewNames.Columns[0].Width = 60;
            tabControlFoundNames.SelectedIndex = 0;
            labelSkipRows.Text = "Rows: " + dataGridViewNames.RowCount;
            buttonSkipDataSearch.Enabled = true;
            textBoxFnameSkip.Enabled = true;
            textBoxLnameSkip.Enabled = true;
            textBoxAtesiSkip.Enabled = true;
            textBoxBdateSkip.Enabled = true;
            textBoxAmesiSkip.Enabled = true;
            SkipColumn.ReadOnly = false;
            tabControl1.SelectedTab = tabPageSkip;
            System.Media.SystemSounds.Beep.Play();
            //  dtskip.Rows.Clear();
        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void textBoxComment_TextChanged(object sender, EventArgs e)
        {
            if (textBoxComment.Text != "" && textBoxComment.Text != null)
            {
                PaymentsComment = " and comments like '%" + textBoxComment.Text + "%' ";
            }
            else
            {
                PaymentsComment = "";
            }
        }

        private void textBoxSrcPay_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSelectAll.Checked == true)
            {
                foreach (DataGridViewRow row in dataGridViewAct.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    chk.Value = !(chk.Value == null ? false : (bool)chk.Value); //because chk.Value is initialy null
                }


            }
            else if (checkBoxSelectAll.Checked == false)
            {
                foreach (DataGridViewRow row in dataGridViewAct.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    chk.Value = !(chk.Value == null ? true : (bool)chk.Value); //because chk.Value is initialy null
                }
            }
        }

        private void checkBoxSelectAllP_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSelectAllP.Checked == true)
            {
                foreach (DataGridViewRow row in paymentsJanDataGridView.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    chk.Value = !(chk.Value == null ? false : (bool)chk.Value); //because chk.Value is initialy null
                }


            }
            else if (checkBoxSelectAllP.Checked == false)
            {
                foreach (DataGridViewRow row in paymentsJanDataGridView.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    chk.Value = !(chk.Value == null ? true : (bool)chk.Value); //because chk.Value is initialy null
                }
            }
        }

        //private void textBoxInfoSource_TextChanged(object sender, EventArgs e)
        //{
        //    SourceQuery = " and debt_serial_number in (select person_number from persons where source like '%" + textBoxInfoSource.Text + "%') ";
        //}

        //private void dateTimePickerReasg_ValueChanged(object sender, EventArgs e)
        //{
        //    comboBoxReasg_SelectedIndexChanged(sender, e);
        //}

        private void buttonExportRep_Click(object sender, EventArgs e)
        {
            //SaveFileDialog sfd = new SaveFileDialog();
            //sfd.Filter = "Excel Documents (*.xlsx)|*.xlsx";
            //sfd.FileName = "Exported_Report_" + DateTime.Today.ToString("dd-MMM-yy") + ".xlsx";
            //if (sfd.ShowDialog() == DialogResult.OK)
            //{
            //    ToCsV(dataGridViewStaticCollectors, sfd.FileName);
            //    // Here dataGridview1 is your grid view name
            //}
            ExportToExcel(dataGridViewStaticCollectors);
        }

        private void comboBoxPortf_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPortf.SelectedValue != null)
            {
                PaymentPortfolio = " and portfolios like '" + comboBoxPortf.SelectedValue.ToString() + "' ";
            }
        }

        //private void comboBoxActionType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (comboBoxActionType.SelectedValue != null)
        //    {
        //        actTypeValue = this.comboBoxActionType.SelectedValue.ToString();
        //        ActionQuery = " and last_act_type like '" + actTypeValue + "'";
        //    }
        //    else
        //    {
        //        ActionQuery = "";
        //    }
        //}

        private void listBoxPhone_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxClientReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            string select = null;
            SqlConnection con = new SqlConnection(ConectionStr);
            if (comboBoxDebts.Text == "Tipi Alpha" || comboBoxDebts.Text == "Tipi Raiffeisen" || comboBoxDebts.Text == "Tipi Teb" || comboBoxDebts.Text == "General")
            {
                if (comboBoxDebts.Text == "Tipi Alpha")
                {
                    select = "AlphaBank";
                }
                else if (comboBoxDebts.Text == "Tipi Raiffeisen")
                {
                    select = "RaiffeisenReport";
                }

                else if (comboBoxDebts.Text == "Tipi Teb")
                {
                    select = "TebReport";
                }

                else if (comboBoxDebts.Text == "General")
                {
                    select = "GeneralReport";

                }

                DataTable dt = new DataTable();
                SqlDataAdapter adapt = new SqlDataAdapter();
                adapt.SelectCommand = new SqlCommand(select, con);
                adapt.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapt.SelectCommand.Parameters.AddWithValue("@client", comboBoxClientReport.Text);
                adapt.Fill(dt);
                dataGridViewStaticCollectors.DataSource = dt;
                dataGridViewStaticCollectors.Columns[0].Width = 200;
                for (int i = 2; i < dataGridViewStaticCollectors.Columns.Count; i++)
                {
                    dataGridViewStaticCollectors.Columns[i].Width = 90;
                }
                dataGridViewStaticCollectors.Columns[0].Frozen = true;
            }
        }

        private void buttonUploadFile_Click(object sender, EventArgs e)
        {
            if (textBoxdebtserial.Text != "")
            {
                NewFile nf = new NewFile();
                nf.ShowDialog();
            }
            else
            {
                Message();
            }
        }

        private void Message() => MessageBox.Show("Please select a debtor", "Action required", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        //private void textBoxBranchId_TextChanged(object sender, EventArgs e)
        //{          
        //        BranchValue = textBoxBranchId.Text;
        //        BranchQuery = " and branchid "+Branchidcheck+" '%" + BranchValue + "%'";                     
        //}

        //private void checkBoxCheck_CheckedChanged(object sender, EventArgs e)
        //{

        //    if (checkBoxCheck.Checked == true)
        //    {
        //        Branchidcheck = " not like ";
        //    }
        //    else
        //    {
        //        Branchidcheck = " like ";
        //    }
        //    textBoxBranchId_TextChanged(sender, e);
        //}   
        private void buttonLetters_Click(object sender, EventArgs e)
        {
            if (textBoxdebtserial.Text != "")
            {
                if (textBoxClients.Text.ToLower() == "union bank")
                {
                    string fileName1 = @"leterunion.docx";
                    var doc = DocX.Load(fileName1);
                    doc.ReplaceText("protDate", DateTime.Today.ToString("yyyyMMdd"), false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("dates", textBoxAssigDAte.Text.Substring(0,10), false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("fnames", textBoxdfname.Text);
                    // doc.ReplaceText("clinst", textBoxClients.Text);
                    // doc.ReplaceText("principals", textBoxPrc.Text, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    // doc.ReplaceText("interests", textBoxint.Text, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    // doc.ReplaceText("penalties", textBoxDayArray.Text, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("totals", textBoxRemainig.Text, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("Currency", TextBoxDebtCurrency.Text, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.SaveAs("leterunion1.docx");
                    Letter let = new Letter();
                    let.ShowDialog();
                }
                else
                {
                    string fileName = @"LeterDaf.docx";
                    string fileName2 = @"LeterKdca.docx";

                    var doc = DocX.Load(fileName);

                    doc.ReplaceText("protDate", DateTime.Today.ToString("yyyyMMdd"), false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("dates", DateTime.Today.ToString("dd-MM-yy"), false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("fnames", textBoxdfname.Text);
                    doc.ReplaceText("clinst", textBoxClients.Text);
                    doc.ReplaceText("principals", textBoxPrc.Text, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("interests", textBoxint.Text, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("penalties", textBoxDayArray.Text, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("totals", textBoxRemainig.Text, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("Currency", TextBoxDebtCurrency.Text, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.SaveAs("LeterDaf1.docx");


                    var doc2 = DocX.Load(fileName2);

                    doc2.ReplaceText("protDate", DateTime.Today.ToString("yyyyMMdd"), false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc2.ReplaceText("dates", DateTime.Today.ToString("dd-MM-yy"), false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc2.ReplaceText("fnames", textBoxdfname.Text);
                    doc2.ReplaceText("clinst", textBoxClients.Text);
                    doc2.ReplaceText("principals", textBoxPrc.Text, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc2.ReplaceText("interests", textBoxint.Text, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc2.ReplaceText("penalties", textBoxDayArray.Text, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc2.ReplaceText("totals", textBoxRemainig.Text, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    // doc2.ReplaceText("Address", listBoxDadr.Items[0].ToString(), false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc2.ReplaceText("Currency", TextBoxDebtCurrency.Text, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc2.ReplaceText("SerialNo", textBoxdebtserial.Text, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc2.SaveAs("LeterKdca1.docx");

                    Letter let = new Letter();
                    let.ShowDialog();
                }
            }
            else
            {
                Message();
            }

        }

        //private void comboBoxDbCollector_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (comboBoxDbCollector.SelectedValue != null)
        //    {
        //        collectorvalue = comboBoxDbCollector.SelectedValue.ToString();// edited
        //    }
        //}

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateCheckInfo info = null;

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;

                try
                {
                    info = ad.CheckForDetailedUpdate();

                }
                catch (DeploymentDownloadException dde)
                {
                    MessageBox.Show("The new version of the application cannot be downloaded at this time. \n\nPlease check your network connection, or try again later. Error: " + dde.Message);
                    return;
                }
                catch (InvalidDeploymentException ide)
                {
                    MessageBox.Show("Cannot check for a new version of the application. The ClickOnce deployment is corrupt. Please redeploy the application and try again. Error: " + ide.Message);
                    return;
                }
                catch (InvalidOperationException ioe)
                {
                    MessageBox.Show("This application cannot be updated. It is likely not a ClickOnce application. Error: " + ioe.Message);
                    return;
                }

                if (info.UpdateAvailable)
                {
                    Boolean doUpdate = true;

                    if (!info.IsUpdateRequired)
                    {
                        DialogResult dr = MessageBox.Show("An update is available. Would you like to update the application now?", "Update Available", MessageBoxButtons.OKCancel);
                        if (!(DialogResult.OK == dr))
                        {
                            doUpdate = false;
                        }
                    }
                    else
                    {
                        // Display a message that the app MUST reboot. Display the minimum required version.
                        MessageBox.Show("This application has detected a mandatory update from your current " +
                            "version to version " + info.MinimumRequiredVersion.ToString() +
                            ". The application will now install the update and restart.",
                            "Update Available", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }

                    if (doUpdate)
                    {
                        try
                        {
                            ad.Update();
                            MessageBox.Show("The application has been upgraded, and will now restart.");
                            Application.Restart();
                        }
                        catch (DeploymentDownloadException dde)
                        {
                            MessageBox.Show("Cannot install the latest version of the application. \n\nPlease check your network connection, or try again later. Error: " + dde);
                            return;
                        }
                    }
                }
            }

        }

        //private void textBoxClassif_TextChanged(object sender, EventArgs e)
        //{
        //    classValue = textBoxClassif.Text;
        //    classQuery = " and classification like '%" + classValue + "%'";
        //}

        private void buttonclearSkip_Click(object sender, EventArgs e)
        {
            Action<Control.ControlCollection> func = null;
            func = (controls) =>
            {
                foreach (Control control in groupBox11.Controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else if (control is ComboBox)
                        (control as ComboBox).Text = "";
            };

            func(Controls);

        }

        private void comboBoxSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {

        }

        //private void comboBoxReasg_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (comboBoxReasg.SelectedIndex == 0)
        //    {
        //        ReasgFilter = dateTimePickerReasg.Text;
        //        ReasgQuery = " and reassigned='" + ReasgFilter + "'";
        //    }
        //    else if (comboBoxReasg.SelectedIndex == 1)
        //    {
        //        ReasgFilter = dateTimePickerReasg.Text;
        //        ReasgQuery = " and reassigned<'" + ReasgFilter + "'"; ;
        //    }
        //    else if (comboBoxReasg.SelectedIndex == 2)
        //    {
        //        ReasgFilter = dateTimePickerReasg.Text;
        //        ReasgQuery = " and reassigned>'" + ReasgFilter + "'"; ;
        //    }
        //}

        private void feedBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Feedback fdp = new Feedback();
            fdp.Show();
        }

        //private void textBoxDebtorDistrict_TextChanged(object sender, EventArgs e)
        //{
        //    DebtDistrictQuery = " and debt_serial_number in (select person_number from persons where district like '%"+textBoxDebtorDistrict.Text +"%' or address like '%"+ textBoxDebtorDistrict.Text + "%') ";
        //}


        private void button25_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxSelectAllC_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSelectAllC.Checked == true)
            {
                foreach (DataGridViewRow row in dataGridViewPersons.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    chk.Value = !(chk.Value == null ? false : (bool)chk.Value); //because chk.Value is initialy null
                }


            }
            else if (checkBoxSelectAllC.Checked == false)
            {
                foreach (DataGridViewRow row in dataGridViewPersons.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    chk.Value = !(chk.Value == null ? true : (bool)chk.Value); //because chk.Value is initialy null
                }
            }
        }

        //private void comboBoxUpdated_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (comboBoxUpdated.SelectedIndex == 0)
        //    {
        //        UpdateFilter = dateTimePickerUpdated.Text;
        //        UpdatedQuery = " and last_updated='" + UpdateFilter + "'";
        //    }
        //    else if (comboBoxUpdated.SelectedIndex == 1)
        //    {
        //        UpdateFilter = dateTimePickerUpdated.Text;
        //        UpdatedQuery = " and last_updated<'" + UpdateFilter + "'"; ;
        //    }
        //    else if (comboBoxUpdated.SelectedIndex == 2)
        //    {
        //        UpdateFilter = dateTimePickerUpdated.Text;
        //        UpdatedQuery = " and last_updated>'" + UpdateFilter + "'"; ;
        //    }
        //}

        //private void dateTimePickerUpdated_ValueChanged(object sender, EventArgs e)
        //{
        //    comboBoxUpdated_SelectedIndexChanged(sender, e);
        //}

        //private void dateTimePickerAsgDate_ValueChanged(object sender, EventArgs e)
        //{
        //    comboBoxAsgDate_SelectedIndexChanged(sender,e);
        //}

        //private void comboBoxAsgDate_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (comboBoxAsgDate.SelectedIndex == 0)
        //    {
        //        AsgDateFilter = dateTimePickerAsgDate.Text;
        //        AsgQuery = " and assigment_Date='" + AsgDateFilter + "'";
        //    }
        //    else if (comboBoxAsgDate.SelectedIndex == 1)
        //    {
        //        AsgDateFilter = dateTimePickerAsgDate.Text;
        //        AsgQuery = " and assigment_Date<'" + AsgDateFilter + "'"; ;
        //    }
        //    else if (comboBoxAsgDate.SelectedIndex == 2)
        //    {
        //        AsgDateFilter = dateTimePickerAsgDate.Text;
        //        AsgQuery = " and assigment_Date>'" + AsgDateFilter + "'"; ;
        //    }
        //}


        private void textBoxCntCollector_TextChanged(object sender, EventArgs e)
        {
            //if (textBoxCntCollector.Text != null || textBoxCntCollector.Text != "")
            //{
            //    CntCollectorQuery = " and person_number in (select debt_serial_number from debtorsactive where debt_collector='"+textBoxCntCollector.Text+"' and portfolio_status='active') ";
            //}
            //else
            //{
            //    CntCollectorQuery = "";
            //}
        }

        private void buttonCall_Click(object sender, EventArgs e)
        {
            //call = "...Calling";
            //richTextBoxPhone.Text += "\n" + call;
            //  richTextBoxPhone.ForeColor = Color.Green;
        }

        private void textBoxCollUserAct_TextChanged(object sender, EventArgs e)
        {
            userActQuery = " and user_id like '" + textBoxUserAct.Text + "%'";
        }

        private void comboBoxActDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxActDate.SelectedIndex == 0)
            {
                // dateActquery = " and action_date='" + dateTimePickerActDtAct.Text + "' ";
                //dateAcfilter = dateTimePickerActDtAct.Text;
                dateActquery = " and action_date='" + dateTimePickerActDtAct.Text + "' ";
            }
            else if (comboBoxActDate.SelectedIndex == 1)
            {
                // dateAcfilter = dateTimePickerActDtAct.Text;
                dateActquery = " and action_date<'" + dateTimePickerActDtAct.Text + "' "; ;
            }
            else if (comboBoxActDate.SelectedIndex == 2)
            {
                // dateAcfilter = dateTimePickerActDtAct.Text;
                dateActquery = " and action_date>'" + dateTimePickerActDtAct.Text + "' "; ;
            }
        }

        //private void comboBoxActReact_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (comboBoxActReact.SelectedItem.ToString() != null)
        //    {
        //        reactionAQuery =" and reaction like '"+comboBoxActReact.SelectedItem.ToString()+"' ";
        //    }
        //    else
        //    {
        //        reactionAQuery = "";
        //    }
        //}

        private void comboBoxLastupd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLastupd.SelectedIndex == 0)
            {
                dateAcfilter = dateTimePickerLastActU.Value.ToString();
                actUpdateQuery = " and last_updated='" + dateAcfilter + "' ";
            }
            else if (comboBoxLastupd.SelectedIndex == 1)
            {
                dateAcfilter = dateTimePickerLastActU.Text;
                actUpdateQuery = " and last_updated<'" + dateAcfilter + "' "; ;
            }
            else if (comboBoxLastupd.SelectedIndex == 2)
            {
                dateAcfilter = dateTimePickerLastActU.Text;
                actUpdateQuery = " and last_updated>'" + dateAcfilter + "' "; ;
            }
        }

        private void comboBoxCntPersAct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxCntPersAct.SelectedValue != null)
            {
                astuatusValue = comboBoxCntPersAct.SelectedValue.ToString();
            }
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void whatsNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewUpdates whats = new NewUpdates();
            whats.ShowDialog();

        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerPayDate_ValueChanged(object sender, EventArgs e)
        {
            textBoxPayDate.Text = dateTimePickerPayDate.Text;
        }

        private void checkBoxPayDate_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPayDate.Text = dateTimePickerPayDate.Text;
        }

        private void tabControl_Drag(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;

            }

            else
                e.Effect = DragDropEffects.None;
        }

        private void tabControl_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            string filename = null;// = Path.GetFileName(FileList[0]);
            long length = 9000000; //new System.IO.FileInfo(FileList[0]).Length;
            string ext = null, contenttype = null;
            if (textBoxdebtserial.Text!="" && textBoxdebtserial.Text !=null)
            {
                if (FileList.Length <= 10)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    int files = 0; 
                    foreach (string file in FileList)
                    {
                        filename = Path.GetFileName(file);
                        length = new System.IO.FileInfo(file).Length;
                        if (length <= 4300000)
                        {
                            // textBoxfPath.Text = filePath;
                            ext = Path.GetExtension(filename);
                            contenttype = String.Empty;
                            switch (ext.ToLower())
                            {
                                case ".doc":
                                    contenttype = "application/word";
                                    break;
                                case ".docx":
                                    contenttype = "application/word";
                                    break;
                                case ".jpg":
                                    contenttype = "image/jpg";
                                    break;
                                case ".jpeg":
                                    contenttype = "image/jpeg";
                                    break;
                                case ".png":
                                    contenttype = "image/png";
                                    break;
                                case ".xls":
                                    contenttype = "application/excel";
                                    break;
                                case ".xlsx":
                                    contenttype = "application/excel";
                                    break;
                                case ".pdf":
                                    contenttype = "application/pdf";
                                    break;
                            }

                            if (contenttype != String.Empty)
                            {
                                FileStream fs = new FileStream(file, FileMode.Open);
                                BinaryReader br = new BinaryReader(fs);
                                Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                                SqlConnection con = new SqlConnection("Data Source=debitor.c8kumftnoykl.eu-central-1.rds.amazonaws.com,1433;Initial Catalog=ForAmazon;User ID=debitordata;Password=Trsdmr92l161");
                                //insert the file into database
                                string strQuery = "insert into FileAttachments(SerialNo,Name, FileType, Files,userid)" +
                                 " values (@serial,@Name, @ContentType, @Data,@users)";
                                SqlCommand cmd = new SqlCommand(strQuery, con);
                                cmd.Parameters.Add("@Serial", SqlDbType.VarChar).Value = textBoxdebtserial.Text;
                                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = filename;
                                cmd.Parameters.Add("@ContentType", SqlDbType.VarChar).Value
                                = contenttype;
                                cmd.Parameters.Add("@Data", SqlDbType.Binary).Value = bytes;
                                cmd.Parameters.Add("users", SqlDbType.VarChar).Value = labelOnlineUser.Text;

                                try
                                {
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    files++;
                                    con.Close();
                                    //FileList = null;
                                }
                                catch (SqlException exception)
                                {
                                    MessageBox.Show(exception.Message.ToString(), "Error Message");
                                }
                                //  lblMessage.ForeColor = System.Drawing.Color.Green;
                                // lblMessage.Text = "File Uploaded Successfully";
                            }
                            else
                            {
                                MessageBox.Show("Unsupported file type");
                            }
                        }
                        else
                        {
                            MessageBox.Show("File exceeding 4 MB", "File size error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(files.ToString()+" file(s) were uploaded", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cannot upload more than 10 files at a time", "File error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                Message();
            }                             
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indeks = 0;
          

            if (comboBox9.SelectedIndex==0)
            {
                indeks = 1;
            }

           else if (comboBox9.SelectedIndex == 1)
            {
                indeks = 2;
            }

            else if (comboBox9.SelectedIndex == 2)
            {
                indeks = 3;
            }

            else if (comboBox9.SelectedIndex == 3)
            {
                indeks = 4;
            }

            else if (comboBox9.SelectedIndex == 4)
            {
                indeks = 5;
            }

            else if (comboBox9.SelectedIndex == 5)
            {
                indeks = 6;
            }

            else 
            {
                indeks = 1;
            }

            DataTable dt = new DataTable();
            SqlConnection con1 = new SqlConnection(ConectionStr);
            string Search1 = "SELECT * FROM DebtorsActive where debt_collector='" + LogedCollector + "' and debt_serial_number in ( select serialCode from tasks where taskno=" + indeks + ")  order by risk desc";

            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = new SqlCommand(Search1, con1);
            adapt.Fill(dt);
            dataGridViewDebtors.DataSource = dt;
            SetClientLogo();
            labelRowCount.Text = "Results: " + dataGridViewDebtors.RowCount;
            tabControl.SelectedTab = tabPageDebts;
            textBoxdebtserial.Text = "";

        }

        private void buttonClearF_Click(object sender, EventArgs e)
        {
            // groupBoxFilterdb.Controls.Clear();
            //foreach (Control c in groupBoxFilterdb.Controls) groupBoxFilterdb.Controls.Remove(c);
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in groupBoxFilterdb.Controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else if (control is ComboBox)
                        (control as ComboBox).SelectedItem = null;
                    else if (control is CheckBox)
                        (control as CheckBox).Checked = false;

                foreach (Control control in groupBox10.Controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else if (control is ComboBox)
                        (control as ComboBox).SelectedItem = null;
                    else if (control is CheckBox)
                        (control as CheckBox).Checked = false;
            };

            func(Controls);
            comboBoxDbCollector.Text = LogedCollector;
            textBoxDebtorDistrict.Text = "";
            comboBoxPStatus.Text = "Active";
            textBoxInfoSource.Text ="";
            comboBoxPeriod.Text = "Equal";
            taskload();

        }

        private void comboBoxClinstAct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxClinstAct.SelectedValue!=null)
            {
                actionClQuery = " and client_institution like '" + comboBoxClinstAct.SelectedValue + "' ";
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {    
           if (comboBox3.SelectedIndex == 0)
            {
                lastupdCollQuery = " and lastUpdated<='" + dateTimePickerColl.Value + "' ";
            }
            else
            {
                lastupdCollQuery = " and lastUpdated>'" + dateTimePickerColl.Value + "' ";
            }
        }

        private void tabPageColl_Click(object sender, EventArgs e)
        {

        }

        private void buttonFilterColl_Click(object sender, EventArgs e)
        {
            if (comboBoxCollClient.Text == "")
            {
                CollClientValue = "%";
            }

            if (comboBox5.Text == "")
            {
                CollNameQuery = "";
            }

            if (comboBoxCollType.Text == "")
            {
                CollTypeQuery = "";
            }

            if (textBoxValue.Text == "" || textBoxValue.Text==null)
            {
                CollValuesQuery = "";
            }

            if (comboBoxValue.Text == "" || comboBoxValue.Text == null)
            {
                CollValuesQuery = "";
            }


            if (comboBox3.Text == "" || comboBox3.Text == null)
            {
                lastupdCollQuery = "";
            }
            string FilterCollateralsQuery = "select * from collaterals where client like '" + CollClientValue+"%'"+CollNameQuery+CollTypeQuery+CollValuesQuery+ lastupdCollQuery;
            SqlConnection con = new SqlConnection(ConectionStr);
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = new SqlCommand(FilterCollateralsQuery, con);

            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridViewColls.DataSource = dt;
        }

        private void buttonBackward_Click(object sender, EventArgs e)
        {
            int tempindex = pointer - 1;
            //pointer -= 1;
            if (tempindex >= 0 && History.Count != 0)
            {
                pointer -= 1;
                textBoxSearch.Text = History[tempindex];          
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            //string rrjeshti;

            //StreamReader sReader = new StreamReader(Savehistory, true);
            //while (sReader.EndOfStream == false)
            //{
            //    rrjeshti = sReader.ReadLine();
            //   //  listBoxHistory.Items.Add(rrjeshti);
            //}
            //sReader.Close();
            MDIParent1 md1 = new MDIParent1();
            md1.Show();
        }

        private void clearHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sure you wand to clear search history?", "Clear History", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                File.WriteAllText(Savehistory, string.Empty);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            comboBoxSelPeriod1_SelectedIndexChanged(sender, e);
        }

        //private void dateTimePickerDb_ValueChanged(object sender, EventArgs e)
        //{
        //    // int month = dateTimePickerDb.Value.Month;
        //    comboBoxPeriod_SelectedIndexChanged(sender, e);
        //}

        private void comboBoxLastCP_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        //private void comboBoxPromise_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //  //  double.TryParse(textBoxPrTP.Text, out PtpSum);
        //    if (comboBoxPromise.SelectedIndex == 0)// more than
        //    {
        //        PTPQuery = " and ptp_amount>= " + textBoxPrTP.Text;
        //    }
        //    else if (comboBoxPromise.SelectedIndex == 1)//less than
        //    {
        //        PTPQuery = " and ptp_amount<= " + textBoxPrTP.Text;
        //    }
        //    else if(comboBoxPromise.SelectedIndex == 2)// no promise
        //    {
        //        PTPQuery = " and ptp_amount is null ";
        //    }
        //}

        //private void MaskedTextboxChange(object sender,EventArgs e)
        //{
        //   // double.TryParse(maskedTextBoxTotOut.Text, out sumMin);
        //    if (comboBoxMore.SelectedIndex == 0)
        //    {
        //        SumQyery = " and total_outstanding>= " + textBoxTotOut.Text;
        //    }
        //    else
        //    {
        //        SumQyery = " and total_outstanding<= " + textBoxTotOut.Text;
        //    }

        //}
        private void button9_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab==tabPageDebtors)
            {
                ExportDebts(sender, e);
            }
            else if (tabControl1.SelectedTab ==tabPageActions)
            {
                ActionExport(sender, e);
            }
            else if (tabControl1.SelectedTab ==tabPagePayments)
            {
                PaymentExport(sender, e);
            }
            else if (tabControl1.SelectedTab ==tabPagePersons)
            {
                ExportContacts(sender, e);
            }


        }

        private void ActionExport(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Exported_Actions_" + DateTime.Today.ToString("dd-MMM-yy") + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ToCsV(dataGridViewAct, sfd.FileName);
                // Here dataGridview1 is your grid view name
            }
        }
     //   dataGridViewPaymenstJan_CellContentDoubleClick

        private void dataGridViewPaymenstJan_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (StatusCollector.ToLower() == "admin" || StatusCollector.ToLower() == "supervisor" || StatusCollector.ToLower() == "agent")
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    DataGridViewCell cellclick1 = (sender as DataGridView).Rows[e.RowIndex].Cells[e.ColumnIndex];
                    int rowindex = cellclick1.RowIndex;
                    int colindx = cellclick1.ColumnIndex;
                    int colindex = CheckboxPayments.Index;
                    if (colindex == colindx)
                    {

                        paymentID = paymentsJanDataGridView.Rows[rowindex].Cells[iDDataGridViewTextBoxColumn3.Index].Value.ToString();
                        //   String PayMonth = dataGridViewselectedPay.Rows[rowindex].Cells[paymentMonthDataGridViewTextBoxColumn.Index].Value.ToString();
                        // ColumnSelectCheck.Selected = true;
                        EditPayment edPay = new EditPayment();
                        edPay.ShowDialog();
                    }
                }
            }
        }


        private void dataGridViewPersons_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (StatusCollector.ToLower() == "admin" || StatusCollector.ToLower() == "supervisor" || StatusCollector.ToLower() == "agent")
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    DataGridViewCell cellclick1 = (sender as DataGridView).Rows[e.RowIndex].Cells[e.ColumnIndex];
                    int rowindex = cellclick1.RowIndex;
                    int colindx = cellclick1.ColumnIndex;
                    int colindex = ColumnSelectCheck.Index;
                    if (colindex == colindx)
                    {
                        contactID = dataGridViewPersons.Rows[rowindex].Cells[personIdDataGridViewTextBoxColumn.Index].Value.ToString();
                        //   String PayMonth = dataGridViewselectedPay.Rows[rowindex].Cells[paymentMonthDataGridViewTextBoxColumn.Index].Value.ToString();
                        // ColumnSelectCheck.Selected = true;
                        EditContact edCnt = new EditContact();
                        edCnt.ShowDialog();
                    }
                }
            }
           
            
        }

        private void Button12_Click(object sender, EventArgs e)
        {
           // string OnlineUser = usernamevalue;
            //OnlineUser = OnlineUser.ToLower();
            if (StatusCollector.ToLower() == "admin" || StatusCollector.ToLower() == "supervisor" || StatusCollector.ToLower() == "agent")
            {
                if (textBoxdebtserial.Text != "")
                {
                    EditDebtor eDebt = new EditDebtor();
                    eDebt.ShowDialog();
                }
                else
                {
                    Message();
                }
            }
            else
            {
                MessageBox.Show("To edit a debtor you must be logged in as administrator", "Premission denied", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
              
        }

        //private void checkBoxPorto_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBoxPorto.Checked==true)
        //    {
        //        portocheck = " not like ";
        //    }
        //    else
        //    {
        //        portocheck = " like ";
        //    }
        //}

        //private void checkBoxPstatus_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBoxPstatus.Checked == true)
        //    {
        //        pstatuscheck = " not like ";
        //    }
        //    else
        //    {
        //        pstatuscheck = " like ";
        //    }
        //}

        //private void checkBoxColl_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBoxColl.Checked == true)
        //    {
        //        collectorcheck = " not like ";
        //    }
        //    else
        //    {
        //        collectorcheck = " like ";
        //    }
        //}

        //private void checkBoxLCP_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBoxLCP.Checked == true)
        //    {
        //        lastcpCheck = " not like ";
        //    }
        //    else
        //    {
        //        lastcpCheck = " like ";
        //    }
        //    comboBoxLcp_SelectedIndexChanged(sender, e);
        //}

        private void Button13_Click(object sender, EventArgs e)
        {
            CreateReports();         
        }
        private void  CreateReports()
        {
            double shuma = 0;
            string selected = "";
            chartPay.Series[0].Points.Clear();
            SqlConnection con = new SqlConnection(ConectionStr);
            if (comboBoxPayColl.Text == "")
            {
                selected = "";
            }
            else
            {
                selected = this.comboBoxPayColl.SelectedValue.ToString();
            }
            string Amount = "declare @lek float,@eur float set @lek=(select sum(paid_amount) from paymentsjan where month(paymentdate)=@pmonth and year(paymentdate)=2016 and payment_currency='all' and collector like '" + selected +"%') " +
                "set @eur=(select sum(paid_amount) from paymentsjan where month(paymentdate)=@pmonth and year(paymentdate)=2016 and payment_currency='eur' and collector like '" + selected +"%') "+
                "if (@lek IS NULL) begin set @lek=0 end   if (@eur IS NULL) begin set @eur=0 end " +
                "select sum(@lek + @eur*"+textBoxExRate.Text+")";
            SqlCommand cmd = new SqlCommand(Amount, con);
          
            for (int i = 1; i <= 12; i++)
            {
                con.Open();
                cmd.Parameters.AddWithValue("@pmonth", i);           
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.IsDBNull(0) == false)
                    {
                        shuma = reader.GetDouble(0);
                    }
                    else
                    {
                        shuma = 0;
                    }
                }
                chartPay.Series[0].Points.Add(shuma);
                cmd.Parameters.Clear();
                con.Close();
            }         
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            Settings setings = new Settings();
            setings.ShowDialog();
            //if (param1<100 || param2==150)
            //{
            //    // set an action
            //}
        }

        private void buttonClient_Click(object sender, EventArgs e)
        {
           // string OnlineUser = usernamevalue;
          //  OnlineUser = OnlineUser.ToLower();
            if (StatusCollector.ToLower() == "admin" || StatusCollector.ToLower() == "supervisor")
            {
                NewClientcs newCl = new NewClientcs();
                newCl.ShowDialog();
            }
            else
            {
                MessageBox.Show("To add new clients you must be logged as administrator", "Premission denied", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  string OnlineUser = usernamevalue;
            //OnlineUser = OnlineUser.ToLower();
            if (StatusCollector.ToLower() == "admin" || StatusCollector.ToLower()=="supervisor" || StatusCollector.ToLower() == "agent")
            {
                Admin adm = new Admin();
                adm.ShowDialog();
            }
            else
            {
                MessageBox.Show("You must be logged in as administrator to access this panel", "Premission denied", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void buttonAdvancedF_Click(object sender, EventArgs e)
        {                      
            //if (checkBoxNoact.Checked==true)//check for debts that do not have actions
            //{
            //    noActionsQ = "and Debt_Serial_Number not in (select Debt_Serial_Number from actionsjan)";
            //}
            //else
            //{
            //    noActionsQ = "";
            //}
            ////check for debts that do not have Payments
            //if (checkBoxNoPay.Checked == true)
            //{
            //    noPaymentsQ = "and Debt_Serial_Number not in (select Debt_Serial_Number from paymentsJan)";
            //}
            //else
            //{
            //    noPaymentsQ = "";
            //}

            //if (textBoxTotOut.Text=="" ||textBoxTotOut.Text==null)
            //{
            //    SumQyery = "";
            //}

            //if (textBoxPrTP.Text == "" || textBoxPrTP.Text == null)
            //{
            //    PTPQuery = "";
            //}

            //if (textBoxDebtorDistrict.Text=="" || textBoxDebtorDistrict.Text==null)
            //{
            //    DebtDistrictQuery = "";
            //}
            //if (comboBoxClientDb.Text=="" || comboBoxClientDb.Text ==null )
            //{
            //    clientvalue = "%";
            //}
            //if (comboBoxPorto.Text=="" || comboBoxClientDb.Text == null)
            //{
            //    portovalue = "%";
            //}
            //if (comboBoxPeriod.Text=="" || comboBoxPeriod.Text ==null)
            //{
            //    DateQuery = "";
            //}

            //if (comboBoxUpdated.Text == "" || comboBoxUpdated.Text == null)
            //{
            //    UpdatedQuery = "";
            //}

            //if (comboBoxAsgDate.Text == "" || comboBoxAsgDate.Text == null)
            //{
            //    AsgQuery = "";
            //}

            //if (textBoxInfoSource.Text=="" || textBoxInfoSource==null)
            //{
            //    SourceQuery = "";
            //}

            //if (comboBoxReasg.Text=="" || comboBoxReasg.Text==null)
            //{
            //    ReasgQuery = "";
            //}
            
            //if (comboBoxCurrDb.Text=="")
            //{
            //    currencyvalue = "%";
            //}
            //if (comboBoxLcp.Text=="")
            //{
            //    LastCp = "";
            //}
            //if (comboBox2.Text == "")
            //{
            //    ReactionQuery = "";
            //}

            //if (comboBoxActionType.Text == "")
            //{
            //    ActionQuery = "";
            //}
            //if (textBoxClassif.Text == "" || textBoxClassif.Text == null)
            //{
            //    classQuery = "";
            //}

            //if (textBoxBranchId.Text == "" || textBoxBranchId.Text == null)
            //{
            //    BranchQuery = "";
            //}
            //if (comboBoxPStatus.Text=="" || comboBoxPStatus.Text==null)
            //{
            //    pstatusvalue = "%";
            //}

            //if (comboBoxDbCollector.Text=="" || comboBoxDbCollector.Text==null)
            //{
            //    collectorvalue = "%";
            //}
            //else
            //{
            //    collectorvalue = comboBoxDbCollector.Text + "%";
            //}

            //string Search = "select * from debtorsactive where ";
            //Search += " client " + clientcheck + "'" + clientvalue + "'" + " and portfolio " + portocheck+"'"+ portovalue + "'"+
            //    " and portfolio_status " +pstatuscheck+ "'" + pstatusvalue + "'" + " and debt_collector " +collectorcheck +
            //   "'" + collectorvalue + "'" + " and currency " +currencyCheck+ "'" + currencyvalue+"'"+
            //   SumQyery+DateQuery+PTPQuery +SourceQuery+ReasgQuery+LastCp+classQuery+ BranchQuery + ReactionQuery+ActionQuery+UpdatedQuery+AsgQuery+DebtDistrictQuery+noPaymentsQ+noActionsQ+" order by debtor_full_name asc";

            //SqlConnection con = new SqlConnection(ConectionStr);           
            //SqlDataAdapter adapt = new SqlDataAdapter();
            //adapt.SelectCommand = new SqlCommand(Search, con);

            //DataTable dt = new DataTable();
            //adapt.Fill(dt);
            //dataGridViewDebtors.DataSource = dt;
            //SetClientLogo();
            //labelRowCount.Text = "Results: " + dataGridViewDebtors.RowCount;

            //tabControl.SelectedTab = tabPageDebts;
            //textBoxdebtserial.Text = "";
            //rowIndex = -2;
       
            GetFilterData();
        }

        private void GetFilterData()
        {
            SqlConnection con = new SqlConnection(ConectionStr);
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = new SqlCommand("FilterDebts", con);
            adapt.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapt.SelectCommand.Parameters.AddWithValue("@yesno", checkBoxClient.Checked ==false ? "0" : "1");
            adapt.SelectCommand.Parameters.AddWithValue("@Client", comboBoxClientDb.SelectedItem == null? null :comboBoxClientDb.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@bitportfolio", checkBoxPorto.Checked == false ? "0" : "1");

            adapt.SelectCommand.Parameters.AddWithValue("@portfolio", comboBoxPorto.SelectedItem == null ? null : comboBoxPorto.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@bitpStatus", checkBoxPstatus.Checked == false ? "0" : "1");
            adapt.SelectCommand.Parameters.AddWithValue("@portfolio_status", comboBoxPStatus.SelectedItem == null ? null : comboBoxPStatus.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@bitCollector", checkBoxColl.Checked == false ? "0" : "1");
            adapt.SelectCommand.Parameters.AddWithValue("@Collector", comboBoxDbCollector.SelectedItem == null ? null : comboBoxDbCollector.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@EqLessMo", comboBoxMore.SelectedItem == null ? null : comboBoxMore.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@total", textBoxTotOut.Text == "" ? "0": textBoxTotOut.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@currency", comboBoxCurrDb.SelectedItem == null ? null : comboBoxCurrDb.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@EqDate", comboBoxPeriod.SelectedItem == null ? null : comboBoxPeriod.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@nexdate", dateTimePickerDb.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@eqPtp", comboBoxPromise.SelectedItem == null ? null : comboBoxPromise.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@ptp", textBoxPrTP.Text == "" ? null : textBoxPrTP.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@bitcontacted", checkBoxLCP.Checked == false ? "0": "1");
            adapt.SelectCommand.Parameters.AddWithValue("@contacted", comboBoxLcp.SelectedItem == null ? null : comboBoxLcp.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@classif", textBoxClassif.Text == "" ? null : textBoxClassif.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@bitCheck", checkBoxCheck.Checked == false ? "0" : "1");
            adapt.SelectCommand.Parameters.AddWithValue("@checkinfo", textBoxBranchId.Text == "" ? null : textBoxBranchId.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@reaction", comboBox2.SelectedItem == null ? null : comboBox2.Text);//KUJDES

            adapt.SelectCommand.Parameters.AddWithValue("@bitAtype", checkBoxAct.Checked == false ? "0" : "1");
            adapt.SelectCommand.Parameters.AddWithValue("@actType", comboBoxActionType.SelectedItem == null ? null : comboBoxActionType.Text);

            adapt.SelectCommand.Parameters.AddWithValue("@eqLdate", comboBoxUpdated.SelectedItem == null ? null : comboBoxUpdated.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@lastDate", dateTimePickerUpdated.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@eqAsdate", comboBoxAsgDate.SelectedItem == null ? null : comboBoxAsgDate.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@AsDate", dateTimePickerAsgDate.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@eqRedate", comboBoxReasg.SelectedItem == null ? null : comboBoxReasg.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@ReDate", dateTimePickerReasg.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@source", textBoxInfoSource.Text == "" ? null : textBoxInfoSource.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@addresses", textBoxDebtorDistrict.Text == "" ? null : textBoxDebtorDistrict.Text);
            adapt.SelectCommand.Parameters.AddWithValue("@bitAction", checkBoxNoact.Checked == false ? null : "1");
            adapt.SelectCommand.Parameters.AddWithValue("@bitContract", checkBoxContract.Checked == false ? null : "1");
            adapt.SelectCommand.Parameters.AddWithValue("@bitPayment", checkBoxNoPay.Checked == false ? null : "1");
            adapt.SelectCommand.Parameters.AddWithValue("@ClSegment", comboBoxClSeg.SelectedItem == null ? null : comboBoxClSeg.Text);//KUJDES
            adapt.SelectCommand.Parameters.AddWithValue("@BitPayDate", checkBoxPayDate.Checked == false ? "0" : "1");//filter payments X months
            adapt.SelectCommand.Parameters.AddWithValue("@PayDate", textBoxPayDate.Text == "" ? null : textBoxPayDate.Text);

            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridViewDebtors.DataSource = dt;
        //    dataGridViewDebtors.Columns["Category"].DataPropertyName = dt.Columns["Category"].ToString();
            //SetClientLogo();
            labelRowCount.Text = "Results: " + dataGridViewDebtors.RowCount;

            tabControl.SelectedTab = tabPageDebts;
            textBoxdebtserial.Text = "";
            rowIndex = -2;
        }

        //private void checkBoxClient_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBoxClient.Checked==true)
        //    {
        //        clientcheck = " not like ";
        //    }
        //    else
        //    {
        //        clientcheck = " like ";
        //    }
        //}

        private void SetClientLogo()
        {
            //string Client;
            //for (int i = 0; i < dataGridViewDebtors.RowCount; i++)
            //{
            //    Client = dataGridViewDebtors.Rows[i].Cells[clientDataGridViewTextBoxColumn.Index].Value.ToString().ToLower();
            //    switch (Client)
            //    {
            //        case "telekom":
            //            dataGridViewDebtors.Rows[i].Cells[ClientImage.Index].Value = imageListClients.Images[7];
            //            break;

            //        case "teb":
            //            dataGridViewDebtors.Rows[i].Cells[ClientImage.Index].Value = imageListClients.Images[4];
            //            break;

            //        case "pro credit":
            //            dataGridViewDebtors.Rows[i].Cells[ClientImage.Index].Value = imageListClients.Images[5];
            //            break;

            //        case "pro credit kosova":
            //            dataGridViewDebtors.Rows[i].Cells[ClientImage.Index].Value = imageListClients.Images[5];
            //            break;

            //        case "albtelecom":
            //            dataGridViewDebtors.Rows[i].Cells[ClientImage.Index].Value = imageListClients.Images[0];
            //            break;

            //        case "iutecredit":
            //            dataGridViewDebtors.Rows[i].Cells[ClientImage.Index].Value = imageListClients.Images[3];
            //            break;

            //        case "besa":
            //            dataGridViewDebtors.Rows[i].Cells[ClientImage.Index].Value = imageListClients.Images[2];
            //            break;

            //        case "transatlantic petroleum":
            //            dataGridViewDebtors.Rows[i].Cells[ClientImage.Index].Value = imageListClients.Images[8];
            //            break;

            //        case "tecnoxgroup":
            //            dataGridViewDebtors.Rows[i].Cells[ClientImage.Index].Value = imageListClients.Images[8];
            //            break;

            //        case "societe general albania":
            //            dataGridViewDebtors.Rows[i].Cells[ClientImage.Index].Value = imageListClients.Images[6];
            //            break;

            //        default:
            //            dataGridViewDebtors.Rows[i].Cells[ClientImage.Index].Value = imageListClients.Images[1];
            //            break;
            //    }               
            //}
        }

        private void SystemSuggestion(int rowindex)
        {
            if (rowindex>0)
            {
                //textBoxSuggestion.Clear();
                DateTime today = DateTime.Today;
                DateTime past;
                DateTime.TryParse(dataGridViewDebtors.Rows[rowindex].Cells[lastUpdatedDataGridViewTextBoxColumn.Index].Value.ToString(), out past);
                int ditet = (today.Date - past.Date).Days;
                string cntPerson = dataGridViewDebtors.Rows[rowindex].Cells[latestPersonContactedDataGridViewTextBoxColumn.Index].Value.ToString();
                string actType= dataGridViewDebtors.Rows[rowindex].Cells[lastActtypeDataGridViewTextBoxColumn.Index].Value.ToString();
                int total = 0;
                int.TryParse(dataGridViewDebtors.Rows[rowindex].Cells[totalOutstandingDataGridViewTextBoxColumn.Index].Value.ToString(), out total);
                cntPerson = cntPerson.ToLower();
                actType = actType.ToLower();
                
                if (cntPerson == "no contact" && ditet > 15 && actType=="skip trace" && total>5000 )
                {
                  //  textBoxSuggestion.Text = "Sent a letter";
                }

                else if (cntPerson == "no contact" && ditet > 30 && actType == "suggest letter" && total > 50000)
                {
                   // textBoxSuggestion.Text = "Field search";
                }
                else if (cntPerson == "no contact" && ditet > 15)
                {
                   //     textBoxSuggestion.Text = "Skip trace";                  
                }
                //kur eshte me kontakt
                if (cntPerson != "no contact")
                {
                     if ((dial_rate < 20 && payrate < 3) || (dial_rate < 50 && ditet > 99 && payrate < 2) || (payrate == 0 && actnr >= 10 && days > 100))
                    {
                    //    textBoxSuggestion.Text = "Send a warning letter";
                    }
                    else if (payrate<3 && days>=200 && ditet>100 )
                    {
                      //  textBoxSuggestion.Text = "A meeting should be scheduled";
                    }
                }
          }                                
        }

        private void comboBoxCollector_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConectionStr);
            string query = " select Username from Usernames where Collector=@coll";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@coll", this.comboBoxCollector.Text);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                textBoxOnlineUser.Text = reader.GetString(0);
            }
            con.Close();
        } 
        private void ComboboxgetCollecor(object sender,KeyEventArgs args)
        {
           if( args.KeyCode == Keys.Down || args.KeyCode == Keys.Up)
            {
                CreateReports();
            }
            Thread.Sleep(250);
        }
        private void Strategies()
        {
           // bool trueif = true;
          //  string str = "&&";
        }  
        
        private void DataGridViewContacts_Cellclick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewPersons.CurrentCell.ColumnIndex== firstNameDataGridViewTextBoxColumn.Index || dataGridViewPersons.CurrentCell.ColumnIndex == personFullNameDataGridViewTextBoxColumn1.Index)
            {
                textBoxSkipName.Text = dataGridViewPersons.CurrentCell.Value.ToString();
            }
            else if (dataGridViewPersons.CurrentCell.ColumnIndex == lastNameDataGridViewTextBoxColumn.Index)
            {
                textBoxSkipLanem.Text= dataGridViewPersons.CurrentCell.Value.ToString();
            }
            else if (dataGridViewPersons.CurrentCell.ColumnIndex == fathersNameDataGridViewTextBoxColumn.Index)
            {
                textBoxSkipFather.Text = dataGridViewPersons.CurrentCell.Value.ToString();
            }
            else if (dataGridViewPersons.CurrentCell.ColumnIndex == phone1DataGridViewTextBoxColumn.Index)
            {
                textBoxSkipPh1.Text = dataGridViewPersons.CurrentCell.Value.ToString();
            }
            else if (dataGridViewPersons.CurrentCell.ColumnIndex == phone2DataGridViewTextBoxColumn.Index)
            {
                textBoxSkipPh2.Text = dataGridViewPersons.CurrentCell.Value.ToString();
            }
            else if (dataGridViewPersons.CurrentCell.ColumnIndex == employerNameDataGridViewTextBoxColumn.Index)
            {
                textBoxSkipNipt.Text = dataGridViewPersons.CurrentCell.Value.ToString();
            }
            else if (dataGridViewPersons.CurrentCell.ColumnIndex == personalnumberDataGridViewTextBoxColumn1.Index)
            {
                textBoxSkipPersonal.Text = dataGridViewPersons.CurrentCell.Value.ToString();
            }
        }     
    }
}
