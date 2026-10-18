using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Data.SqlClient;
using System.Threading;


namespace MainDebtApp

{
    public partial class Import : Form
    {
        private string OnlineUser=null;
        string Clients = null;
        private string Excel03ConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        private string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        string AmznString = System.Configuration.ConfigurationManager.ConnectionStrings["InstantLogin"].ConnectionString;
        // string client = null;
        string PortfolioName = null;
        public Import()
        {
            InitializeComponent();
            if (Application.OpenForms["Users"] != null)
            {
                OnlineUser = (Application.OpenForms["Users"] as Users).userna;
            }
        }

        private void buttonUpload_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount>=1)
            {
               
                    for (int k = 0; k < dataGridView1.Rows.Count; k++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            if (dataGridView1.Rows[k].Cells[j].Value == null || dataGridView1.Rows[k].Cells[j].Value.ToString()=="")
                            {
                                dataGridView1.Rows[k].Cells[j].Value = DBNull.Value;
                            }
                        }
                    }
                    //  progressBarUpload.
                    // string AmznString = "Data Source=debitor.c8kumftnoykl.eu-central-1.rds.amazonaws.com,1433;Initial Catalog=ForAmazon;User ID=debitordata;Password=Trsdmr92l161";
                    SqlConnection conx = new SqlConnection(AmznString);
                    String Query = "insert into DebtorsActive (  Debt_Serial_Number , Debtor_Full_Name ,client,portfolio,debt_type,currency, Outstanding_Principal, Outstanding_Interest, Outstanding_Penalty," +
                        "  Debt_Collector , Total_Outstanding , Client_Branch,CloseDate, BranchId, DisbursmentDate, FinishedDate, RestructuredContract, IsRestructured, DisbursmentAmount,"+
                        "InALL_Base,AmountInDelay ,PrincipalDelay ,InterestDelay  ,ClientSegment,ProductID ,DaysInDelay ,Mortgage,Pledge ,CashColateral ,ContractStatusId,"+
                        "last_updated,User_id,portfolio_status,assigment_date,LinkId,assignmentDebt,last_act_type,next_action_date,latest_comment,latest_person_contacted,reaction,contactedVia,payaccno,classification,UpComingInterest)" +
                        "values (@dser,@dname,@client,@port,@dtype,@curr,@oprinc,@oi,@ope,@dcol,@tot,@clb,isnull(@CloseDate,''), @BranchId, isnull(@DisbursmentDate,'01-01-00'), isnull(@FinishedDate,'01-jan-00'), @RestructuredContract, @IsRestructured,"+
                        "@disbursmentAmount,@allBase,@AmountInDelay ,@PrincipalDelay ,@InterestDelay   ,@ClientSegment,@ProductID ,@DaysInDelay ,@Mortgage ,@Pledge ,@CashColateral,"+
                       "@CntrId, @ldate,@user,@pstatus,@adate,@lid,isnull(@adebt,@tot),@last_act_type,isnull(@next_act_date,'01-jan-00'),@latest_comment,@latest_person_contacted,@reaction,@contactedVia,@payaccno,@classification,isnull(@UpComingInterest,0))";
                    SqlCommand command = new SqlCommand(Query, conx);
                    conx.Open();

                    SqlTransaction trans = conx.BeginTransaction();
                    command.Transaction = trans;
                    int i = 0;
                    try
                    {
                        for (i = 0; i < dataGridView1.Rows.Count; i++)
                        {

                            command.Parameters.AddWithValue("@dser", dataGridView1.Rows[i].Cells[debtSerialNumberDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@client", dataGridView1.Rows[i].Cells[Client.Index].Value);
                            command.Parameters.AddWithValue("@port", dataGridView1.Rows[i].Cells[Portfolio.Index].Value);
                            command.Parameters.AddWithValue("@dtype", dataGridView1.Rows[i].Cells[Debt_Type.Index].Value);
                            command.Parameters.AddWithValue("@curr", dataGridView1.Rows[i].Cells[Currency.Index].Value);
                            //   command.Parameters.AddWithValue("@did", dataGridView1.Rows[i].Cells[debtIdDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@dname", dataGridView1.Rows[i].Cells[debtorFullNameDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@oprinc", dataGridView1.Rows[i].Cells[outstandingPrincipalDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@oi", dataGridView1.Rows[i].Cells[outstandingInterestDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@ope", dataGridView1.Rows[i].Cells[outstandingPenaltyDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@PrincipalDelay", dataGridView1.Rows[i].Cells[principalDelayDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@InterestDelay", dataGridView1.Rows[i].Cells[interestDelayDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@dcol", dataGridView1.Rows[i].Cells[debtCollectorDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@tot", dataGridView1.Rows[i].Cells[totalOutstandingDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@clb", dataGridView1.Rows[i].Cells[clientBranchDataGridViewTextBoxColumn.Index].Value);
                        //DateTime tm = new DateTime();
                       
       //                 tm= dataGridView1.Rows[i].Cells[closeDateDataGridViewTextBoxColumn.Index].Value;


                            command.Parameters.AddWithValue("@CloseDate", dataGridView1.Rows[i].Cells[closeDateDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@BranchId", dataGridView1.Rows[i].Cells[branchIdDataGridViewTextBoxColumn.Index].Value);

                            command.Parameters.AddWithValue("@DisbursmentDate", dataGridView1.Rows[i].Cells[disbursmentDateDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@FinishedDate", dataGridView1.Rows[i].Cells[finishedDateDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@RestructuredContract", dataGridView1.Rows[i].Cells[restructuredContractDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@IsRestructured", dataGridView1.Rows[i].Cells[isRestructuredDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@DisbursmentAmount", dataGridView1.Rows[i].Cells[disbursmentAmountDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@allBase", dataGridView1.Rows[i].Cells[disbursmentAmountDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@AmountInDelay", dataGridView1.Rows[i].Cells[amountInDelayDataGridViewTextBoxColumn.Index].Value);

                            // command.Parameters.AddWithValue("@Penalty", dataGridView1.Rows[i].Cells[19].Value);
                            command.Parameters.AddWithValue("@UpComingInterest", dataGridView1.Rows[i].Cells[upComingInterestDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@ClientSegment", dataGridView1.Rows[i].Cells[clientSegmentDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@ProductID", dataGridView1.Rows[i].Cells[productIDDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@DaysInDelay", dataGridView1.Rows[i].Cells[daysInDelayDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@Mortgage", dataGridView1.Rows[i].Cells[mortgageDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@Pledge", dataGridView1.Rows[i].Cells[pledgeDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@CashColateral", dataGridView1.Rows[i].Cells[cashColateralDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@CntrId", dataGridView1.Rows[i].Cells[contractStatusIdDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@lid", dataGridView1.Rows[i].Cells[LinkID.Index].Value);
                            command.Parameters.AddWithValue("@adebt", dataGridView1.Rows[i].Cells[AssignmentDebt.Index].Value);
                            command.Parameters.AddWithValue("@last_act_type", dataGridView1.Rows[i].Cells[Last_Act_type.Index].Value);
                            command.Parameters.AddWithValue("@next_act_date", dataGridView1.Rows[i].Cells[Next_Action_Date.Index].Value);
                            command.Parameters.AddWithValue("@latest_comment", dataGridView1.Rows[i].Cells[Latest_Comment.Index].Value);
                            command.Parameters.AddWithValue("@latest_person_contacted", dataGridView1.Rows[i].Cells[Latest_Person_Contacted.Index].Value);
                            command.Parameters.AddWithValue("@reaction", dataGridView1.Rows[i].Cells[Reaction.Index].Value);
                            command.Parameters.AddWithValue("@contactedVia", dataGridView1.Rows[i].Cells[ContactedVia.Index].Value);
                            command.Parameters.AddWithValue("@Ptp_amount", dataGridView1.Rows[i].Cells[PTP_Amount.Index].Value);
                            command.Parameters.AddWithValue("@payaccno", dataGridView1.Rows[i].Cells[PayAccNo.Index].Value);

                            command.Parameters.AddWithValue("ldate", DateTime.Today.ToString());
                            command.Parameters.AddWithValue("@user", dataGridView1.Rows[i].Cells[User_Id.Index].Value);
                            command.Parameters.AddWithValue("@classification", dataGridView1.Rows[i].Cells[Classification.Index].Value);

                             command.Parameters.AddWithValue("adate", dataGridView1.Rows[i].Cells[Assigment_Date.Index].Value);
                            command.Parameters.AddWithValue("@pstatus", dataGridView1.Rows[i].Cells[Portfolio_Status.Index].Value);

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
                        string InsertNotification = "insert into notifications (serial,name,type,userid,collector,datetime) select distinct client,portfolio,'New Debtors',@userid,Debt_Collector,getdate() from DebtorsActive where portfolio='" + PortfolioName + "' and day(last_updated)=day(getdate())";

                    command = new SqlCommand(InsertNotification, conx);
                    command.Parameters.AddWithValue("@userid", OnlineUser);
                       // conx.Open();
                    command.ExecuteNonQuery();
                       // conx.Close();
                }

                    catch (SqlException ex) // As you are doing the same thing on boths exceptions one handler is enought
                    {
                        trans.Rollback();
                        MessageBox.Show(ex.Message.ToString() + "\nError line " + i + ".\nUpload failed.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }

                    conx.Close();
                    //string updateInserted = "update debtorsactive set client=@client, last_updated=@ldate,user_id=@user,currency=@curr,debt_type=@dtype,portfolio_status='active' ,assigment_date=@adate where portfolio=@port";
                    //command = new SqlCommand(updateInserted, conx);
                    //command.Parameters.AddWithValue("client", comboBoxClient.Text);
                    //command.Parameters.AddWithValue("ldate", DateTime.Today.ToString());
                    //command.Parameters.AddWithValue("user", OnlineUser);
                    //command.Parameters.AddWithValue("curr", comboBoxCurrency.Text);
                    //command.Parameters.AddWithValue("dtype", comboBoxDType.Text);
                    //command.Parameters.AddWithValue("adate", DateTime.Today.ToString());
                    //command.Parameters.AddWithValue("port", comboBoxPorto.Text);
                    
                    //try
                    //{
                    //    conx.Open();
                    //    command.ExecuteNonQuery();
                    //    conx.Close();
                    //    // this.Close();
                    //}
                    //catch (SqlException exception)
                    //{
                    //    MessageBox.Show(exception.Message.ToString(), "Error Message");
                    //}

                    SqlConnection con = new SqlConnection(AmznString);
                    SqlCommand cmd = new SqlCommand("UpdateDebtColumnsProc", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                   // cmd.Parameters.AddWithValue("@Client_Institution", comboBoxClient.Text);
                    //cmd.Parameters.AddWithValue("@Portfolio",comboBoxPorto.Text);
                    //cmd.Parameters.AddWithValue("@ActualDate", DateTime.Today);
                    for(int j=0;j<=1;j++)
                    {
                        try
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                       
                      }
                        catch (SqlException exception)
                        {
                            MessageBox.Show(exception.Message.ToString(), "Error Message");
                        }

                    }
                    MessageBox.Show("Succesfully uploaded " + dataGridView1.Rows.Count + " new debtors", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    buttonUpload.Enabled = false;//parandalon ringarkimin e rasteve
                                                 // this.Close();
               
                //else
                //{
                //    MessageBox.Show("Please set the porfolio properties", "Portfollio properties not set", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
            else
            {
                MessageBox.Show("Please select a file to continue", "No file choosen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string filePath = openFileDialog1.FileName;
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
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                ColumnNames.Add(dataGridView1.Columns[i].HeaderText.ToLower());
            }
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ExcelNames.Add(dt.Columns[i].ColumnName.ToLower());
            }
            
            
            if (dt.Columns.Count== dataGridView1.ColumnCount)
            {
              
                for (int x = 0; x < ExcelNames.Count; x++)
                {
                    if (ExcelNames.Contains(ColumnNames[x]) == false)
                    {
                        MessageBox.Show("Column names does not match in excel column index " + x, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    if (x == dt.Columns.Count - 1)
                    {
                        dataGridView1.DataSource = dt;
                        PortfolioName = dataGridView1.Rows[0].Cells[Portfolio.Index].Value.ToString();
                    }
                }
                 
             
            }
            else
            {
                MessageBox.Show("Column number does not match","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);// to be edited
            }

        }

        private void Import_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'forAmazonDataSet.ActionsJan' table. You can move, or remove it, as needed.
            //this.actionsJanTableAdapter.Fill(this.forAmazonDataSet.ActionsJan);

            this.debtTypeTableAdapter.Fill(this.forAmazonDataSet.DebtType);
          
            this.currencyTableAdapter.Fill(this.forAmazonDataSet.Currency);
            this.portofolioTableAdapter.Fill(this.forAmazonDataSet.Portofolio);
            this.clientInstitutionTableAdapter.Fill(this.forAmazonDataSet.ClientInstitution);

            comboBoxClient.Text = null;
            comboBoxCurrency.Text = null;
            comboBoxPorto.Text = null;
           // comboBox1.Text = null;
            //foreach (DataGridViewColumn dgvc in dataGridViewSavedP.Columns)
            //{
            //    dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
            //}
            foreach (DataGridViewColumn dgvc in dataGridViewPayments.Columns)
            {
                dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }


        //CONTACTS---CONTACTS---CONTACTS---CONTACTS---CONTACTS---CONTACTS---CONTACTS---CONTACTS---CONTACTS---CONTACTS
        private void buttonOpenpersonsDialog_Click(object sender, EventArgs e)
        {
            openFileDialogPersons.ShowDialog();
        }
        //CONTACTS
        private void openFileDialogPersons_FileOk(object sender, CancelEventArgs e)
        {
            string filePath = openFileDialogPersons.FileName;
            textBoxpathPErsons.Text = filePath;
            string extension = Path.GetExtension(filePath);
           // string header = "YES";
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
            for (int i = 0; i < dataGridViewPersons.ColumnCount; i++)
            {
                ColumnNames.Add(dataGridViewPersons.Columns[i].HeaderText.ToLower());
            }
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ExcelNames.Add(dt.Columns[i].ColumnName.ToLower());
            }


            if (dt.Columns.Count == dataGridViewPersons.ColumnCount)
            {

                for (int x = 0; x < ExcelNames.Count; x++)
                {
                    if (ExcelNames.Contains(ColumnNames[x]) == false)
                    {
                        MessageBox.Show("Column names does not match in excel column index " + x, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    if (x == dt.Columns.Count - 1)
                    {
                        dataGridViewPersons.DataSource = dt;
                    }
                }

                for (int k = 0; k < dataGridViewPersons.Rows.Count; k++)
                {
                    for (int j = 0; j < dataGridViewPersons.Columns.Count; j++)
                    {
                        if (dataGridViewPersons.Rows[k].Cells[j].Value == null)
                        {
                            dataGridViewPersons.Rows[k].Cells[j].Value = DBNull.Value;
                        }
                    }
                }


            }
            else
            {
                MessageBox.Show("Column number does not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);// to be edited
            }
        
        }
        //UPLOAD CONTACTS
        private void buttonUplpersons_Click(object sender, EventArgs e)
        {
           
                if (dataGridViewPersons.Rows.Count >= 1)
                {                  
                    //  progressBarUpload.
                    // string AmznString = "Data Source=debitor.c8kumftnoykl.eu-central-1.rds.amazonaws.com,1433;Initial Catalog=ForAmazon;User ID=debitordata;Password=Trsdmr92l161";
                    SqlConnection conx = new SqlConnection(AmznString);
                    String Query = "insert into Persons ( client_institution,person_number, person_Full_Name,first_name,fathers_name,last_name,district,address,phone_1,phone_2,phone_3,phone_4,employer_name,job_position,fraud," +
                        "last_updated,user_id,email,personal_number,relation,source,birthdate) values (@col2,@col3,@col4,@col5,@col6,@col7,isnull(@district,''),@col9,@col10,@col11,@col12,@phone4,@col13,@col14,@col15,isnull(@col16,Getdate()),isnull(@user,'admin'),@col18,@col19,@col20,@col21,@bdate)";
                    SqlCommand command = new SqlCommand(Query, conx);
                   
                    conx.Open();
                    SqlTransaction trans = conx.BeginTransaction();
                    command.Transaction = trans;
                    int i=0;
                    try
                    {
                        for (i = 0; i < dataGridViewPersons.RowCount; i++)
                        {
                            //  command.Parameters.AddWithValue("@col1", dataGridViewPersons.Rows[i].Cells[personIdDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@col2", dataGridViewPersons.Rows[i].Cells[Client_Institution.Index].Value);
                            command.Parameters.AddWithValue("@col3", dataGridViewPersons.Rows[i].Cells[personNumberDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@col4", dataGridViewPersons.Rows[i].Cells[personFullNameDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@col5", dataGridViewPersons.Rows[i].Cells[firstNameDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@col6", dataGridViewPersons.Rows[i].Cells[fathersNameDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@col7", dataGridViewPersons.Rows[i].Cells[lastNameDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@district", dataGridViewPersons.Rows[i].Cells[districtDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@phone4", dataGridViewPersons.Rows[i].Cells[phone_4.Index].Value);

                            command.Parameters.AddWithValue("@col9", dataGridViewPersons.Rows[i].Cells[addressDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@col10", dataGridViewPersons.Rows[i].Cells[phone1DataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@col11", dataGridViewPersons.Rows[i].Cells[phone2DataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@col12", dataGridViewPersons.Rows[i].Cells[phone3DataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@col13", dataGridViewPersons.Rows[i].Cells[employerNameDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@col14", dataGridViewPersons.Rows[i].Cells[jobPositionDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@col15", dataGridViewPersons.Rows[i].Cells[fraudDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@col16", dataGridViewPersons.Rows[i].Cells[lastUpdatedDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@user", dataGridViewPersons.Rows[i].Cells[userIdDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@col18", dataGridViewPersons.Rows[i].Cells[emailDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@col19", dataGridViewPersons.Rows[i].Cells[personalnumberDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@col20", dataGridViewPersons.Rows[i].Cells[relationDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@col21", dataGridViewPersons.Rows[i].Cells[sourceDataGridViewTextBoxColumn.Index].Value);
                            command.Parameters.AddWithValue("@bdate", dataGridViewPersons.Rows[i].Cells[BirthDate.Index].Value);

                            try
                            {
                                command.ExecuteNonQuery();

                            }
                            catch (SqlException exception)
                            {
                                MessageBox.Show(exception.Message.ToString() + " Error on row " + i + ".\nUpload failed", "Error Message");
                                break;
                            }

                            command.Parameters.Clear();
                        }
                        trans.Commit();
                        MessageBox.Show(dataGridViewPersons.RowCount.ToString() + " contacts uploaded successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridViewPersons.Dispose();
                        dataGridViewPersons.Refresh();
                    }

                    catch (SqlException ex) // As you are doing the same thing on boths exceptions one handler is enought
                    {           
                        trans.Rollback();
                        MessageBox.Show(ex.Message.ToString() + "\nError line " + i + ".\nUpload failed.", "Error Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }

                    conx.Close();
                 
                }
                else
                {
                    MessageBox.Show("No data selected for upload", "No data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }          
        }

        //PAYMENTS---PAYMENTS---PAYMENTS---PAYMENTS---PAYMENTS---PAYMENTS---PAYMENTS---PAYMENTS---PAYMENTS---PAYMENTS---PAYMENTS---PAYMENTS
        //payments Section to choose excel file
        private void buttonChoosePay_Click(object sender, EventArgs e)
        {
            openFileDialogPayments.ShowDialog();
        }

        //payments section to check opened file
        private void openFileDialogPayments_FileOk(object sender, CancelEventArgs e)//check excel contents before filling the grid
        {
            string filePath = openFileDialogPayments.FileName;
            textBoxPaymentpath.Text = filePath;
            string extension = Path.GetExtension(filePath);
           // string header = "YES";
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
            //getting the client name and currenct
            List<string> ColumnNames = new List<string>();
            List<string> ExcelNames = new List<string>();
            for (int i = 0; i < dataGridViewPayments.ColumnCount; i++)
            {
                ColumnNames.Add(dataGridViewPayments.Columns[i].HeaderText.ToLower());
            }
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ExcelNames.Add(dt.Columns[i].ColumnName.ToLower());
            }


            if (dt.Columns.Count ==dataGridViewPayments.ColumnCount)
            {
                for (int i = 0; i < ExcelNames.Count; i++)
                {
                    if (ExcelNames.Contains(ColumnNames[i]) == false)
                    {
                        MessageBox.Show("Column names does not match in excel column index " + i, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    if (i == dt.Columns.Count - 1)
                    {
                        dataGridViewPayments.DataSource = dt;

                        int PaymentId = 1;

                        SqlConnection conx = new SqlConnection(AmznString);
                        //   String Querys = "Select PaymentsNumber from  NumerRows";
                        String Query1 = "select Debt_Collector,client,Debtor_full_name,Portfolio from DebtorsActive where Debt_serial_number=@dserial";
                        //  String Query1 = " update  NumerRows set DebtorsNumber=@nr;";
                        //   SqlCommand commandx = new SqlCommand(Querys, conx);
                        // SqlCommand commandy = new SqlCommand(Query1, conx);
                        SqlCommand cmd2 = new SqlCommand(Query1, conx);

                        //conx.Open();
                        //SqlDataReader reader = commandx.ExecuteReader();
                        //while (reader.Read())
                        //{
                        //    PaymentId = PaymentId + 1;
                        //    PaymentId = reader.GetInt32(0);
                        //}

                        //int gridRows = dataGridViewPayments.Rows.Count;
                        //conx.Close();               
                        int j = PaymentId;

                        //    string currency = null;
                        //    string queryClient = "select client from DebtorsActive where debt_serial_number=@serialn";
                        //      string queryFull = "select debtor_full_name from DebtorsActive where debt_serial_number=@serialn";
                        //SqlConnection conection = new SqlConnection(AmznString);
                        //   SqlCommand com = new SqlCommand(queryClient, conx);
                        //   string TestValue = dt.Rows[0].Cells[debtSerialNumberDataGridViewTextBoxColumn1.Index].Value.ToString();
                        //    com.Parameters.AddWithValue("@serialn", dataGridViewPayments.Rows[0].Cells[debtSerialNumberDataGridViewTextBoxColumn1.Index].Value.ToString());

                        //  conx.Open();
                        //   SqlDataReader readc = com.ExecuteReader();
                        //while (readc.Read())
                        //{
                        //    client = readc.GetString(0);
                        // //   currency = readc.GetString(1);
                        //}
                        //conx.Close();

                        for (int a = 0; a < dataGridViewPayments.RowCount; a++)
                        {//set currency,client and collector
                         //    dataGridViewPayments.Rows[a].Cells[clientInstitutionDataGridViewTextBoxColumn2.Index].Value = client;
                         // dataGridViewPayments.Rows[a].Cells[paymentCurrencyDataGridViewTextBoxColumn.Index].Value = currency;

                            conx.Open();
                            //  j = j + 1;
                            //   dataGridViewPayments.Rows[a].Cells[0].Value = j.ToString();
                            cmd2.Parameters.AddWithValue("@dserial", dataGridViewPayments.Rows[a].Cells[debtSerialNumberDataGridViewTextBoxColumn1.Index].Value.ToString());

                            SqlDataReader reader = cmd2.ExecuteReader();
                            string dCollector = null;
                            string Fullname = null;
                            string PortfolioName = null;
                            while (reader.Read())
                            {
                                dCollector = reader.GetString(0);
                                Clients = reader.GetString(1);
                                Fullname = reader.GetString(2);
                                PortfolioName= reader.GetString(3);
                            }
                            
                            cmd2.Parameters.Clear();
                            dataGridViewPayments.Rows[a].Cells[Collector.Index].Value = dCollector;
                            dataGridViewPayments.Rows[a].Cells[clientInstitutionDataGridViewTextBoxColumn2.Index].Value = Clients;
                            dataGridViewPayments.Rows[a].Cells[personFullNameDataGridViewTextBoxColumn1.Index].Value = Fullname;
                            dataGridViewPayments.Rows[a].Cells[Portfolios.Index].Value = PortfolioName;

                            conx.Close();
                        }//end of client and currency set

                        //for (int y = 0; y < gridRows ; y++)
                        //{

                        //}
                        for (int k = 0; k < dataGridViewPayments.Rows.Count; k++)
                        {
                            for (int w = 0; w < dataGridViewPayments.Columns.Count; w++)
                            {
                                if (dataGridViewPayments.Rows[k].Cells[w].Value == null)
                                {
                                    dataGridViewPayments.Rows[k].Cells[w].Value = DBNull.Value;
                                }
                            }
                        }
                        //  progressBarUpload.

                    }
                }
                ////for (int i = 0; i < dt.Columns.Count; i++)
                ////{
                ////    if (dt.Columns[i].ColumnName.ToLower() == dataGridViewPayments.Columns[i].HeaderText.ToLower())
                ////    {
                        
                ////    }
                ////    else
                ////    {
                ////        MessageBox.Show("Error in index " + i + ". Column names in the source table do not match column names in the destination Payment table");
                ////        i = dt.Columns.Count;
                ////    }
                ////}
            }
            else
            {
                MessageBox.Show("column number does not match");// to be edited
            }      
            
               
        }

        //event that occurs when upload button is clicked.
        private void ButtonUploatpay_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < dataGridViewPayments.Rows.Count; i++)
            //{
            //    for (int j = 0; j < dataGridViewPayments.Columns.Count; j++)
            //    {
            //        if (dataGridViewPayments.Rows[i].Cells[j].Value == null)
            //        {
            //            dataGridViewPayments.Rows[i].Cells[j].Value = DBNull.Value;
            //        }
            //    }
            //}
            ////  progressBarUpload.
            //SqlConnection conx = new SqlConnection(AmznString);
            //String Query = "insert into PaymentsJan ( ID, Debt_Serial_Number  , Person_Full_Name,Client_Institution,Paid_Amount ,Payment_Month,Payment_Year,Payment_Currency,Comments,  Last_Updated , User_Id,collector,payment_status) values (@col1,@col2,@col3,@col4,@col5,@col6,@col7,@col8,@col9,@col10,@col11,@col12,@col13)";
            //SqlCommand command = new SqlCommand(Query, conx);
            //conx.Open();
            //for (int i = 0; i < dataGridViewPayments.Rows.Count-1; i++)
            //{
            //    command.Parameters.AddWithValue("@col1", dataGridViewPayments.Rows[i].Cells[0].Value);
            //    command.Parameters.AddWithValue("@col2", dataGridViewPayments.Rows[i].Cells[1].Value);
            //    command.Parameters.AddWithValue("@col3", dataGridViewPayments.Rows[i].Cells[2].Value);
            //    command.Parameters.AddWithValue("@col4", dataGridViewPayments.Rows[i].Cells[3].Value);
            //    command.Parameters.AddWithValue("@col5", dataGridViewPayments.Rows[i].Cells[4].Value);
            //    command.Parameters.AddWithValue("@col6", dataGridViewPayments.Rows[i].Cells[5].Value);
            //    command.Parameters.AddWithValue("@col7", dataGridViewPayments.Rows[i].Cells[6].Value);
            //    command.Parameters.AddWithValue("@col8", dataGridViewPayments.Rows[i].Cells[7].Value);
            //    command.Parameters.AddWithValue("@col9", dataGridViewPayments.Rows[i].Cells[8].Value);
            //    command.Parameters.AddWithValue("@col10", DateTime.Today);
            //    command.Parameters.AddWithValue("@col11", dataGridViewPayments.Rows[i].Cells[10].Value);
            //    command.Parameters.AddWithValue("@col12", dataGridViewPayments.Rows[i].Cells[11].Value);
            //    command.Parameters.AddWithValue("@col13", dataGridViewPayments.Rows[i].Cells[12].Value);
            //    try
            //    {
            //        command.ExecuteNonQuery();
            //        // this.Close();
            //    }
            //    catch (SqlException exception)
            //    {
            //        MessageBox.Show(exception.Message.ToString(), "Error Message");
            //    }

            //    command.Parameters.Clear();
            //}
            //conx.Close();

            if (dataGridViewPayments.RowCount >= 1)
            {
                if (dataGridViewPayments.Rows[0].Cells[PaymentDate1.Index].Value.ToString() != "" && dataGridViewPayments.Rows[0].Cells[PaymentDate1.Index].Value.ToString() != null)
                {
                    string deleteQuery = "delete from temppayments";


                    //uploading payments to temporary 
                    SqlConnection conx = new SqlConnection(AmznString);
                    string Query = "insert into temppayments(DebtSerialt  , Namet,Client,Amount ,PayDate,curr,Comment, updatedon , UserIdt,collectort,statust,Portfol) values (@col2,@col3,@col4,@col5,@col6,@col7,@col8,@col10,@col11,@col12,@col13,@port)";
                    SqlCommand command = new SqlCommand(deleteQuery, conx);
                    conx.Open();
                    command.ExecuteNonQuery();
                    conx.Close();

                    command = new SqlCommand(Query, conx);
                    conx.Open();
                    SqlTransaction trans = conx.BeginTransaction();
                    command.Transaction = trans;
                    int x = 0;
                    try // hedhja e pagesave ne tabelen e perkohshme
                    {
                        for (x = 0; x < dataGridViewPayments.Rows.Count; x++)
                        {
                            // command.Parameters.AddWithValue("@col1", dataGridViewPayments.Rows[x].Cells[iDDataGridViewTextBoxColumn.Index].Value);//id
                            command.Parameters.AddWithValue("@col2", dataGridViewPayments.Rows[x].Cells[debtSerialNumberDataGridViewTextBoxColumn1.Index].Value);//serial
                            command.Parameters.AddWithValue("@col3", dataGridViewPayments.Rows[x].Cells[personFullNameDataGridViewTextBoxColumn1.Index].Value);//name
                            command.Parameters.AddWithValue("@col4", dataGridViewPayments.Rows[x].Cells[clientInstitutionDataGridViewTextBoxColumn2.Index].Value);//client
                            command.Parameters.AddWithValue("@col5", dataGridViewPayments.Rows[x].Cells[paidAmountDataGridViewTextBoxColumn.Index].Value);//amount
                            command.Parameters.AddWithValue("@col6", dataGridViewPayments.Rows[x].Cells[PaymentDate1.Index].Value);//date
                            command.Parameters.AddWithValue("@col7", dataGridViewPayments.Rows[x].Cells[paymentCurrencyDataGridViewTextBoxColumn.Index].Value);//curr
                            command.Parameters.AddWithValue("@col8", "New payment");//coment
                                                                                    //    command.Parameters.AddWithValue("@col9", dataGridViewPayments.Rows[x].Cells[8].Value);
                            command.Parameters.AddWithValue("@col10", DateTime.Today.Date);//last updated
                            command.Parameters.AddWithValue("@col11", "Admin");//user
                            command.Parameters.AddWithValue("@col12", dataGridViewPayments.Rows[x].Cells[Collector.Index].Value);//collector
                            command.Parameters.AddWithValue("@col13", "Verified");//payment status
                            command.Parameters.AddWithValue("@port", dataGridViewPayments.Rows[x].Cells[Portfolios.Index].Value);

                            // command.ExecuteNonQuery();
                            try
                            {
                                command.ExecuteNonQuery();
                            }
                            catch (SqlException ex)
                            {
                                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                break;
                            }   
                            command.Parameters.Clear();
                        }
                        trans.Commit();
                     //   MessageBox.Show(dataGridViewPayments.RowCount.ToString() + " payments uploaded successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);                       
                    }                                
                    catch (SqlException ex) // As you are doing the same thing on boths exceptions one handler is enought
                    {
                        trans.Rollback();
                        MessageBox.Show(ex.Message.ToString() + "\nError line " + x + ".\nUpload failed.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }

                    conx.Close();


                    //hedhja e pagesave te reja nga tabela e perkohshme ne ate te perhershme
                    // ne koment vendoset "new payment"
                string QueryIn = "insert into PaymentsJan (Debt_Serial_Number  , Person_Full_Name,Client_Institution,Paid_Amount ,Payment_Currency,Comments,  Last_Updated , User_Id,collector,payment_status,PaymentDate,Portfolios)" +
          " select debtserialt,namet,client,amount,curr,comment,updatedon,useridt,collectort,statust,paydate,Portfol from TempPayments where TempPayments.debtserialt not in(select Debt_Serial_Number from PaymentsJan where MONTH(PaymentDate) =@month and YEAR(PaymentDate) = @year) and client=@client";
                    SqlConnection con = new SqlConnection(AmznString);
                    SqlCommand cmd = new SqlCommand(QueryIn, con);
                    cmd.Parameters.AddWithValue("@month", dateTimePicker1.Value.Month);
                    cmd.Parameters.AddWithValue("@year", dateTimePicker1.Value.Year);
                    cmd.Parameters.AddWithValue("@client", Clients);
                    con.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                        // this.Close();
                    }
                    catch (SqlException exception)
                    {
                        MessageBox.Show(exception.Message.ToString(), "Error Message");
                    }
                    con.Close();
                    cmd.Dispose();


                    // ne tabelen e pagesave behet mbledhja e shumes se pagesave te nje muaji per nje debitor,
                    // vlera e kthyer caktohet si vlere e shumes dhe me pas fshijme
                    // te  gjitha rekordet duke lene vetem njerin qe tregon shumen e pagesave qe jane hedhur ne sistem
                    cmd = new SqlCommand("InsertPaymentsProc", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@month", dateTimePicker1.Value.Month);
                    cmd.Parameters.AddWithValue("@year", dateTimePicker1.Value.Year);
                    cmd.Parameters.AddWithValue("@client", Clients);
                    con.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                        // this.Close();
                    }
                    catch (SqlException exception)
                    {
                        MessageBox.Show(exception.Message.ToString(), "Error Message");
                    }
                    con.Close();
                    cmd.Dispose();

                    // perditesohet shume e pageses ne rastet kur ka diference negative, behet 
                    // krahasimi mes shumes se hedhur nga perdoruesi dhe shumes qe ndodhet tek tabela e perkohshme
                    //tek diferenca vendoset shuma qe mungon
                    string QueryLess = "update PaymentsJan set payment_status = 'Verified', Paid_Amount = TempPayments.amount ,PaymentDiff=amount-Paid_Amount " +
                    " from TempPayments where paymentsjan.debt_serial_number = TempPayments.debtserialt and month(paymentdate) =@month and year(paymentdate) = @year and Paid_Amount > amount" +
                    " and month(paydate)=@month and year(paydate)=@year and (payment_status<>'Verified' or payment_status is null)";
                    cmd = new SqlCommand(QueryLess, con);
                    cmd.Parameters.AddWithValue("@month", dateTimePicker1.Value.Month);
                    cmd.Parameters.AddWithValue("@year", dateTimePicker1.Value.Year);
                    // cmd.Parameters.AddWithValue("@client", client);
                    con.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                        // this.Close();
                    }
                    catch (SqlException exception)
                    {
                        MessageBox.Show(exception.Message.ToString(), "Error Message");
                    }
                    con.Close();
                    cmd.Dispose();


                    // perditesohet shume e pageses ne rastet kur ka diference pozitive ose eshte barazim, behet 
                    // krahasimi mes shumes se hedhur nga perdoruesi dhe shumes qe ndodhet tek tabela e perkohshme.
                    //tek diferenca vendoset shuma qe ka ardhur shtese
                    string QueryMore = "update PaymentsJan set payment_status = 'Verified',Paid_Amount = TempPayments.amount ,PaymentDiff=amount-Paid_Amount " +
                  " from TempPayments where paymentsjan.debt_serial_number = TempPayments.debtserialt and month(paymentdate) =@month and year(paymentdate) = @year and Paid_Amount <= amount" +
                  " and month(paydate)=@month and year(paydate)=@year and (payment_status<>'Verified' or payment_status is null) ";
                    cmd = new SqlCommand(QueryMore, con);
                    cmd.Parameters.AddWithValue("@month", dateTimePicker1.Value.Month);
                    cmd.Parameters.AddWithValue("@year", dateTimePicker1.Value.Year);
                    // cmd.Parameters.AddWithValue("@client", client);
                    con.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                        // this.Close();
                    }
                    catch (SqlException exception)
                    {
                        MessageBox.Show(exception.Message.ToString(), "Error Message");
                    }
                    con.Close();
                    cmd.Dispose();


                    //perditesohet pagesa, duke e bere ate zero ne rastet kur pagesa mungon, tek diferenca vendoset shuma qe mungon
                    string QueryMissing = "update PaymentsJan set payment_status = 'Verified',Comments=Comments+'/Missing',PaymentDiff=-Paid_Amount," +
                    " Paid_Amount = 0.0 where PaymentsJan.Debt_Serial_Number not in (select TempPayments.debtserialt from TempPayments where month(paydate)=@month and year(paydate)=@year ) " +
                    " and month(paymentdate) = @month and year(paymentdate) =@year and client_institution =@client and(payment_status <> 'Verified' or payment_status is null)";
                    cmd = new SqlCommand(QueryMissing, con);
                    cmd.Parameters.AddWithValue("@month", dateTimePicker1.Value.Month);
                    cmd.Parameters.AddWithValue("@year", dateTimePicker1.Value.Year);
                    cmd.Parameters.AddWithValue("@client", Clients);
                    con.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                        // this.Close();
                    }
                    catch (SqlException exception)
                    {
                        MessageBox.Show(exception.Message.ToString(), "Error Message");
                    }
                    con.Close();
                    cmd.Dispose();


                    conx.Close();
                    MessageBox.Show("successfully inserted " + dataGridViewPayments.Rows.Count + " rows", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   // button2.Enabled = false;
                    buttonUploatpay.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Please set payment date", "Missing info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select an excel file to continue", "No file chosen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }






          

        }


        private void ToCsV(DataGridView dGV, string filename)
        {
            int x = 0;// dataGridView1.Rows.Count;
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    x = dataGridView1.Rows.Count;
                    break;
                case 1:
                    x = dataGridViewPersons.Rows.Count;
                    break;
                case 2:
                    x = dataGridViewPayments.Rows.Count;
                    break;
                case 3:
                    x = dataGridViewAct.Rows.Count;
                    break;
                case 6:
                    x = dataGridViewNewPayments.Rows.Count;
                    break;


                    //case 3:
                    //      x =.Rows.Count;
                    //    break;
            }
            string stOutput = "";
            // Export titles:
            string sHeaders = "";

            for (int j = 0; j < dGV.ColumnCount; j++)
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

        private void buttonExcelSheet_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Import_Debts_Schema" + DateTime.Today.ToString("dd-MMM-yy") + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ToCsV(dataGridView1, sfd.FileName);
            }
        }

        private void comboBoxClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount-1; i++)
            {
             //   dataGridView1.Rows[i].Cells[clientDataGridViewTextBoxColumn.Index].Value = comboBoxClient.Text;
            }
        }

        private void comboBoxPorto_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
              //  dataGridView1.Rows[i].Cells[portfolioDataGridViewTextBoxColumn.Index].Value = comboBoxPorto.Text;
            }
        }

        private void comboBoxCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
             //   dataGridView1.Rows[i].Cells[currencyDataGridViewTextBoxColumn.Index].Value = comboBoxCurrency.Text;
            }
        }

        private void comboBoxDType_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
           //     dataGridView1.Rows[i].Cells[debtTypeDataGridViewTextBoxColumn.Index].Value = comboBoxDType.Text;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //for (int i = 0; i < dataGridViewPersons.RowCount; i++)
            //{
            //    dataGridViewPersons.Rows[i].Cells[Client_Institution.Index].Value = comboBox1.Text;
            //}
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;

            Thread.Sleep(500);
            pictureBox1.BorderStyle = BorderStyle.None;
            MessageBox.Show("The selected excel file should be of type '.xls'./n Must contain...", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void buttonAdvancedF_Click(object sender, EventArgs e)
        {
            //  int month = dateTimePickerPAyDate.Value.Month;
            //short shmonth = 0;
            //short.TryParse(month.ToString(),out shmonth);
            //short shyear = 0;
            //short.TryParse(dateTimePickerPAyDate.Value.Year.ToString(), out shyear);
            //try
            //{
            //    this.paymentsJanTableAdapter.FilterPayImport(this.forAmazonDataSet.PaymentsJan, comboBoxClientDb.Text, dateTimePickerPAyDate.Value.Month, dateTimePickerPAyDate.Value.Year);
            //}
            //catch (System.Exception ex)
            //{
            //    System.Windows.Forms.MessageBox.Show(ex.Message);
            //}
         //   DataTable dt = new DataTable();
         //   SqlConnection con = new SqlConnection(AmznString);
         ////   SqlCommand cmd = new SqlCommand("FilterImportPay", con);
         //   //cmd.CommandType = CommandType.StoredProcedure;
         //   SqlDataAdapter adapt = new SqlDataAdapter();
         //   adapt.SelectCommand = new SqlCommand("FilterImportPay", con);
         //   adapt.SelectCommand.CommandType = CommandType.StoredProcedure;
         //   adapt.SelectCommand.Parameters.AddWithValue("@month", dateTimePickerPAyDate.Value.Month);
         //   adapt.SelectCommand.Parameters.AddWithValue("@year", dateTimePickerPAyDate.Value.Year);
         //   adapt.SelectCommand.Parameters.AddWithValue("@client", comboBoxClientDb.SelectedValue.ToString());
         //   adapt.Fill(dt);
         //   dataGridViewSavedP.DataSource = dt;
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
          //  string querySelect = "select count (debt_serial_number), sum(paid_amount) from paymentsJAn where payment_month=@pmonth and payment_year=@pyear and debt_serial_number=@dserial and payment_status<>'confirmed'";
          ////  string querydelete = "delete from paymentsjan where payment_month=@pmonth and payment_year=@pyear and debt_serial_number=@dserial and payment_status<>'confirmed'";
          ////  string queryinsert = "insert into paymentsjan";
          //  SqlConnection con = new SqlConnection(AmznString);
          //  SqlCommand cmd = new SqlCommand(querySelect, con);
          //  SqlDataReader reader;
          //  for (int i = 0; i < dataGridViewPayments.RowCount; i++)
          //  {
          //      cmd.Parameters.AddWithValue("@pmonth", 9);
          //      cmd.Parameters.AddWithValue("@pyear", 2016);
          //      cmd.Parameters.AddWithValue("@dserial", dataGridViewPayments.Rows[i].Cells[debtSerialNumberDataGridViewTextBoxColumn1.Index].Value.ToString());
          //      con.Open();
          //      reader = cmd.ExecuteReader();
          //      int pagesat = 0;
          //      double shumat = 0;
          //      while (reader.Read())
          //      {
          //          if (reader.IsDBNull(0) == false)
          //          {
          //              pagesat = reader.GetInt32(0);
          //              shumat = reader.GetDouble(1);
          //          }
          //      }
          //      con.Close();
          //      cmd.Parameters.Clear();


          //  }

          //  double shuma = 0;
          //  double shumaTrue = 0;
          //  for (int i = 0; i < dataGridViewSavedP.RowCount; i++)
          //  {
          //      for (int j = 0; j < dataGridViewPayments.RowCount; j++)
          //      {

          //          if (dataGridViewSavedP.Rows[i].Cells[debtSerialNumberDataGridViewTextBoxColumn2.Index].Value.ToString() == dataGridViewPayments.Rows[j].Cells[debtSerialNumberDataGridViewTextBoxColumn1.Index].Value.ToString())
          //          {
          //              double.TryParse(dataGridViewSavedP.Rows[i].Cells[paidAmountDataGridViewTextBoxColumn1.Index].Value.ToString(), out shuma);
          //              double.TryParse(dataGridViewPayments.Rows[i].Cells[paidAmountDataGridViewTextBoxColumn.Index].Value.ToString(), out shumaTrue);

          //              if (shuma == shumaTrue)
          //              {
          //                  dataGridViewSavedP.Rows[i].DefaultCellStyle.BackColor = Color.Green;
          //                  dataGridViewPayments.Rows[j].DefaultCellStyle.BackColor = Color.Green;
          //              }
          //              else if (shuma > shumaTrue)
          //              {
          //                  dataGridViewSavedP.Rows[i].Cells[paidAmountDataGridViewTextBoxColumn1.Index].Value = shumaTrue.ToString();
          //                  dataGridViewSavedP.Rows[i].Cells[commentsDataGridViewTextBoxColumn1.Index].Value = "Mungese " + (shuma - shumaTrue).ToString();
          //                  dataGridViewSavedP.Rows[i].DefaultCellStyle.BackColor = Color.Green;
          //                  dataGridViewPayments.Rows[j].DefaultCellStyle.BackColor = Color.Green;
          //              }
          //              else if (shuma < shumaTrue)
          //              {
          //                  dataGridViewSavedP.Rows[i].Cells[paidAmountDataGridViewTextBoxColumn1.Index].Value = shumaTrue.ToString();
          //                  dataGridViewSavedP.Rows[i].Cells[commentsDataGridViewTextBoxColumn1.Index].Value = "Shtese " + (shumaTrue - shuma).ToString();
          //                  dataGridViewSavedP.Rows[i].DefaultCellStyle.BackColor = Color.Green;
          //                  dataGridViewPayments.Rows[j].DefaultCellStyle.BackColor = Color.Green;
          //              }
          //          }
          //      }
          //  }
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //   // string update;
        //    SqlConnection con = new SqlConnection(AmznString);
        //    SqlCommand cmd = new SqlCommand("UpdateDebtColumnsProc", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@Client_Institution","pro credit");
        //    cmd.Parameters.AddWithValue("@Portfolio","pcb2test");
        //    cmd.Parameters.AddWithValue("@ActualDate", "1-Aug-2016");

        //    try
        //    {
        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //        con.Close();

        //        // this.Close();
        //    }
        //    catch (SqlException exception)
        //    {
        //        MessageBox.Show(exception.Message.ToString(), "Error Message");
        //    }
        //}

        private void textBoxDbCollector_TextChanged(object sender, EventArgs e)
        {

        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dataGridViewPayments.RowCount>=1)
            {
                for (int i = 0; i < dataGridViewPayments.RowCount; i++)
                {
                    dataGridViewPayments.Rows[i].Cells[PaymentDate1.Index].Value = dateTimePicker1.Text;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridViewPayments.RowCount >= 1)
            {
                if (dataGridViewPayments.Rows[1].Cells[5].Value.ToString() != "" && dataGridViewPayments.Rows[1].Cells[5].Value.ToString() != null)
                {
                    //uploading payments to temporary 
                    SqlConnection conx = new SqlConnection(AmznString);
                    String Query = "insert into temppayments( IDt, DebtSerialt  , Namet,Client,Amount ,PayDate,curr,Comment, updatedon , UserIdt,collectort,statust) values (@col1,@col2,@col3,@col4,@col5,@col6,@col7,@col8,@col10,@col11,@col12,@col13)";
                    SqlCommand command = new SqlCommand(Query, conx);
                    conx.Open();
                    for (int x = 0; x < dataGridViewPayments.Rows.Count; x++)
                    {
                        command.Parameters.AddWithValue("@col1", dataGridViewPayments.Rows[x].Cells[0].Value);//id
                        command.Parameters.AddWithValue("@col2", dataGridViewPayments.Rows[x].Cells[1].Value);//serial
                        command.Parameters.AddWithValue("@col3", dataGridViewPayments.Rows[x].Cells[2].Value);//name
                        command.Parameters.AddWithValue("@col4", dataGridViewPayments.Rows[x].Cells[3].Value);//client
                        command.Parameters.AddWithValue("@col5", dataGridViewPayments.Rows[x].Cells[4].Value);//amount
                        command.Parameters.AddWithValue("@col6", dataGridViewPayments.Rows[x].Cells[5].Value);//date
                        command.Parameters.AddWithValue("@col7", dataGridViewPayments.Rows[x].Cells[6].Value);//curr
                        command.Parameters.AddWithValue("@col8", "New payment");//coment
                                                                                //    command.Parameters.AddWithValue("@col9", dataGridViewPayments.Rows[x].Cells[8].Value);
                        command.Parameters.AddWithValue("@col10", DateTime.Today.Date);//last updated
                        command.Parameters.AddWithValue("@col11", "Admin");//user
                        command.Parameters.AddWithValue("@col12", dataGridViewPayments.Rows[x].Cells[7].Value);//collector
                        command.Parameters.AddWithValue("@col13", "Verified");//payment status
                        try
                        {
                            command.ExecuteNonQuery();
                            // this.Close();
                        }
                        catch (SqlException exception)
                        {
                            MessageBox.Show(exception.Message.ToString(), "Error Message");
                        }

                        command.Parameters.Clear();
                    }
                    conx.Close();
                    MessageBox.Show("successfully inserted " + dataGridViewPayments.Rows.Count + " rows", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button2.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Please set payment date", "Missing info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select an excel file to continue","No file chosen",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void buttonWeights_Click(object sender, EventArgs e)
        {

        }

        private void buttonContactSchema_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Import_Contacts_Schema" + DateTime.Today.ToString("dd-MMM-yy") + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ToCsV(dataGridViewPersons, sfd.FileName);
            }
        }

        private void ButtonPAymentSchema_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Import_Payments_Schema" + DateTime.Today.ToString("dd-MMM-yy") + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ToCsV(dataGridViewPayments, sfd.FileName);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void Button10_Click(object sender, EventArgs e)
        {
            openFileDialogAcitons.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (dataGridViewAct.Rows.Count >= 1)
            {

                for (int k = 0; k < dataGridViewAct.Rows.Count; k++)
                {
                    for (int j = 0; j < dataGridViewAct.Columns.Count; j++)
                    {
                        if (dataGridViewAct.Rows[k].Cells[j].Value == null)
                        {
                            dataGridViewAct.Rows[k].Cells[j].Value = DBNull.Value;
                        }
                    }

                }
                SqlConnection conx = new SqlConnection(AmznString);
                String Query = "insert into ActionsJan (Debt_Serial_Number,Person_Full_Name,Client_Institution,Action_Type," +
                    "Action_Status,Action_Date,Comments,User_Id, Last_Updated,othercontact,promisedAmount,reaction) values (@dser,@pname,@client,@atype," +
                    "@astatus,@adate,@comment,@userId,isnull(@lupd,getdate()),@contacted,@ptpAmt,@react)";
                SqlCommand command = new SqlCommand(Query, conx);
                conx.Open();

                SqlTransaction trans = conx.BeginTransaction();
                command.Transaction = trans;
                int i = 0;
                try
                {
                    for (i = 0; i < dataGridViewAct.RowCount; i++)
                    {
                        //  command.Parameters.AddWithValue("@col1", dataGridViewPersons.Rows[i].Cells[personIdDataGridViewTextBoxColumn.Index].Value);
                        command.Parameters.AddWithValue("dser", dataGridViewAct.Rows[i].Cells[debtSerialNumberDataGridViewTextBoxColumn2.Index].Value);
                        command.Parameters.AddWithValue("@pname", dataGridViewAct.Rows[i].Cells[personFullNameDataGridViewTextBoxColumn2.Index].Value);
                        command.Parameters.AddWithValue("@client", dataGridViewAct.Rows[i].Cells[clientInstitutionDataGridViewTextBoxColumn.Index].Value);
                        command.Parameters.AddWithValue("@atype", dataGridViewAct.Rows[i].Cells[actionTypeDataGridViewTextBoxColumn.Index].Value);
                        command.Parameters.AddWithValue("@astatus", dataGridViewAct.Rows[i].Cells[actionStatusDataGridViewTextBoxColumn.Index].Value);
                        command.Parameters.AddWithValue("@adate", dataGridViewAct.Rows[i].Cells[actionDateDataGridViewTextBoxColumn.Index].Value);
                        command.Parameters.AddWithValue("@comment", dataGridViewAct.Rows[i].Cells[commentsDataGridViewTextBoxColumn.Index].Value);
                        command.Parameters.AddWithValue("@userId", dataGridViewAct.Rows[i].Cells[userIdDataGridViewTextBoxColumn1.Index].Value);
                        command.Parameters.AddWithValue("@contacted", dataGridViewAct.Rows[i].Cells[otherContactDataGridViewTextBoxColumn.Index].Value);
                        command.Parameters.AddWithValue("@ptpAmt", dataGridViewAct.Rows[i].Cells[promisedAmountDataGridViewTextBoxColumn.Index].Value);
                        command.Parameters.AddWithValue("@react", dataGridViewAct.Rows[i].Cells[reactionDataGridViewTextBoxColumn.Index].Value);
                        command.Parameters.AddWithValue("@lupd", dataGridViewAct.Rows[i].Cells[lastUpdatedDataGridViewTextBoxColumn1.Index].Value);

                        //try
                        //{
                        command.ExecuteNonQuery();
                        //    // this.Close();
                        //}
                        //catch (SqlException exception)
                        //{
                        //    MessageBox.Show(exception.Message.ToString(), "Error Message");
                        //}

                        command.Parameters.Clear();
                    }
                    trans.Commit();
                    MessageBox.Show(dataGridViewAct.RowCount.ToString() + " actions uploaded successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewAct.Dispose();
                    dataGridViewAct.Refresh();
                }
                catch (SqlException ex) // As you are doing the same thing on boths exceptions one handler is enought
                {
                    trans.Rollback();
                    MessageBox.Show(ex.Message.ToString() + "\nError line " + i + ".\nUpload failed.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  
                }

                conx.Close();
            
            }
            else
            {
                MessageBox.Show("No data selected for upload", "No data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void openFileDialogAcitons_FileOk(object sender, CancelEventArgs e)
        {
            string filePath = openFileDialogAcitons.FileName;
            textBoxAct.Text = filePath;
            string extension = Path.GetExtension(filePath);
            // string header = "YES";
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
            if (dt.Columns.Count == dataGridViewAct.ColumnCount)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (dt.Columns[i].ColumnName == dataGridViewAct.Columns[i].HeaderText)
                    {
                        if (i == dt.Columns.Count - 1)
                        {
                            dataGridViewAct.DataSource = dt;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error in index " + i + ". Column names in the source table do not match column names in the destination table");
                        i = dt.Columns.Count;
                    }
                }

            }
            else
            {
                MessageBox.Show("column number does not match");// to be edited
            }
        }

        private void buttonNewPayments_Click(object sender, EventArgs e)
        {
            openFileDialogNewPayments.ShowDialog();
        }

        private void openFileDialogNewPayments_FileOk(object sender, CancelEventArgs e)
        {
            string filePath = openFileDialogNewPayments.FileName;
            textBoxNewPayPath.Text = filePath;
            string extension = Path.GetExtension(filePath);
            // string header = "YES";
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
            //getting the client name and currenct
            List<string> ColumnNames = new List<string>();
            List<string> ExcelNames = new List<string>();
            for (int i = 0; i < dataGridViewNewPayments.ColumnCount; i++)
            {
                ColumnNames.Add(dataGridViewNewPayments.Columns[i].HeaderText.ToLower());
            }
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ExcelNames.Add(dt.Columns[i].ColumnName.ToLower());
            }

            
            if (dt.Columns.Count == dataGridViewNewPayments.ColumnCount)//checks cloumn numbers
            {              
                    for (int i = 0; i < ExcelNames.Count; i++)
                    {
                        if (ExcelNames.Contains(ColumnNames[i]) == false)
                        {
                            MessageBox.Show("Column names does not match in excel column index " + i, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        if (i == dt.Columns.Count - 1)
                        {
                            dataGridViewNewPayments.DataSource = dt;

                            int PaymentId = 1;

                            SqlConnection conx = new SqlConnection(AmznString);
                            String Query1 = "select Debt_Collector,client,Debtor_full_name, Portfolio from DebtorsActive where Debt_serial_number=@dserial";

                            SqlCommand cmd2 = new SqlCommand(Query1, conx);
                            int j = PaymentId;

                            for (int a = 0; a < dataGridViewNewPayments.RowCount; a++)
                            {
                                conx.Open();
                                //  j = j + 1;
                                //   dataGridViewNewPayments.Rows[a].Cells[0].Value = j.ToString();
                                cmd2.Parameters.AddWithValue("@dserial", dataGridViewNewPayments.Rows[a].Cells[debtSerialNumberDataGridViewTextBoxColumn1.Index].Value.ToString());

                                SqlDataReader reader = cmd2.ExecuteReader();
                                string dCollector = null;
                                string Fullname = null;
                                 string PortfolioNames = null;
                                while (reader.Read())
                                {
                                    dCollector = reader.GetString(0);
                                    Clients = reader.GetString(1);
                                    Fullname = reader.GetString(2);
                                PortfolioNames = reader.GetString(3);
                            }

                                cmd2.Parameters.Clear();
                                dataGridViewNewPayments.Rows[a].Cells[dataGridViewTextBoxColumncoll.Index].Value = dCollector;
                                dataGridViewNewPayments.Rows[a].Cells[Client_InstitutionNewPay.Index].Value = Clients;
                                dataGridViewNewPayments.Rows[a].Cells[dataGridViewTextBoxColumnfullname.Index].Value = Fullname;
                                dataGridViewNewPayments.Rows[a].Cells[portfol.Index].Value = PortfolioNames;

                            conx.Close();
                            }//end of client and currency set

                            //for (int y = 0; y < gridRows ; y++)
                            //{

                            //}
                            for (int k = 0; k < dataGridViewNewPayments.Rows.Count; k++)
                            {
                                for (int w = 0; w < dataGridViewNewPayments.Columns.Count; w++)
                                {
                                    if (dataGridViewNewPayments.Rows[k].Cells[w].Value == null)
                                    {
                                        dataGridViewNewPayments.Rows[k].Cells[w].Value = DBNull.Value;
                                    }
                                }
                            }
                            //  progressBarUpload.
                        }                                                             
                }
            }
            else
            {
                MessageBox.Show("column number does not match");// to be edited
            }       
    }

        private void buttonUploadNewPayments_Click(object sender, EventArgs e)
        {
            if (dataGridViewNewPayments.RowCount >= 1)
            {
                if (MessageBox.Show("You are about to add NEW PAYMENTS ONLY", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (dataGridViewNewPayments.Rows[0].Cells[dataGridViewTextBoxColumn1.Index].Value.ToString() != "" && dataGridViewNewPayments.Rows[0].Cells[dataGridViewTextBoxColumn1.Index].Value.ToString() != null)
                    {
                        string deleteQuery = "delete from temppayments";


                        //uploading payments to temporary 
                        SqlConnection conx = new SqlConnection(AmznString);
                        string Query = "insert into temppayments(DebtSerialt  , Namet,Client,Amount ,PayDate,curr,Comment, updatedon , UserIdt,collectort,statust,Portfol) values (@col2,@col3,@col4,@col5,@col6,@col7,@col8,@col10,@col11,@col12,@col13,@port)";
                        SqlCommand command = new SqlCommand(deleteQuery, conx);
                        try
                        {
                            conx.Open();
                            command.ExecuteNonQuery();
                            conx.Close();
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.Message, "Import Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }
                      

                        command = new SqlCommand(Query, conx);
                        conx.Open();
                        SqlTransaction trans = conx.BeginTransaction();
                        command.Transaction = trans;
                        int x = 0;
                        try // hedhja e pagesave ne tabelen e perkohshme
                        {
                            for (x = 0; x < dataGridViewNewPayments.Rows.Count; x++)
                            {
                                // command.Parameters.AddWithValue("@col1", dataGridViewNewPayments.Rows[x].Cells[iDDataGridViewTextBoxColumn.Index].Value);//id
                                command.Parameters.AddWithValue("@col2", dataGridViewNewPayments.Rows[x].Cells[dataGridViewTextBoxColumnSerial.Index].Value);//serial
                                command.Parameters.AddWithValue("@col3", dataGridViewNewPayments.Rows[x].Cells[dataGridViewTextBoxColumnfullname.Index].Value);//name
                                command.Parameters.AddWithValue("@col4", dataGridViewNewPayments.Rows[x].Cells[Client_InstitutionNewPay.Index].Value);//client
                                command.Parameters.AddWithValue("@col5", dataGridViewNewPayments.Rows[x].Cells[dataGridViewTextBoxColumnPaidAmt.Index].Value);//amount
                                command.Parameters.AddWithValue("@col6", dataGridViewNewPayments.Rows[x].Cells[dataGridViewTextBoxColumn1.Index].Value);//date
                                command.Parameters.AddWithValue("@col7", dataGridViewNewPayments.Rows[x].Cells[dataGridViewTextBoxColumnCurr.Index].Value);//curr
                                command.Parameters.AddWithValue("@col8", "New weekly payment ");//coment
                                                                                                //    command.Parameters.AddWithValue("@col9", dataGridViewNewPayments.Rows[x].Cells[8].Value);
                                command.Parameters.AddWithValue("@col10", DateTime.Today.Date);//last updated
                                command.Parameters.AddWithValue("@col11", OnlineUser);//user
                                command.Parameters.AddWithValue("@col12", dataGridViewNewPayments.Rows[x].Cells[dataGridViewTextBoxColumncoll.Index].Value);//collector
                                command.Parameters.AddWithValue("@col13", "");//payment status
                                command.Parameters.AddWithValue("@port", dataGridViewNewPayments.Rows[x].Cells[portfol.Index].Value);
                                command.ExecuteNonQuery();
                                command.Parameters.Clear();
                            }
                            trans.Commit();
                            //   MessageBox.Show(dataGridViewNewPayments.RowCount.ToString() + " payments uploaded successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);                       
                        }
                        catch (SqlException ex) // As you are doing the same thing on boths exceptions one handler is enought
                        {
                            trans.Rollback();
                            MessageBox.Show(ex.Message.ToString() + "\nError line " + x + ".\nUpload failed.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }

                        conx.Close();


                        //hedhja e pagesave te reja nga tabela e perkohshme ne ate te perhershme
                        // ne koment vendoset "new payment"
                        string QueryIn = "insert into PaymentsJan (Debt_Serial_Number  , Person_Full_Name,Client_Institution,Paid_Amount ,Payment_Currency,Comments,  Last_Updated , User_Id,collector,payment_status,PaymentDate,Portfolios)" +
                  " select debtserialt,namet,client,amount,curr,comment,updatedon,useridt,collectort,statust,paydate,portfol from TempPayments where TempPayments.debtserialt not in(select Debt_Serial_Number from PaymentsJan where MONTH(PaymentDate) =@month and YEAR(PaymentDate) = @year) and client=@client";
                        SqlConnection con = new SqlConnection(AmznString);
                        SqlCommand cmd = new SqlCommand(QueryIn, con);
                        cmd.Parameters.AddWithValue("@month", dateTimePickerNewPay.Value.Month);
                        cmd.Parameters.AddWithValue("@year", dateTimePickerNewPay.Value.Year);
                        cmd.Parameters.AddWithValue("@client", Clients);
                        con.Open();
                        int RowsReturned = 0;
                        try
                        {
                            RowsReturned=cmd.ExecuteNonQuery();
                            // this.Close();
                        }
                        catch (SqlException exception)
                        {
                            MessageBox.Show(exception.Message.ToString(), "Error Message");
                        }
                        con.Close();
                        cmd.Dispose();


                        MessageBox.Show("successfully inserted " + RowsReturned + " new payments", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // button2.Enabled = false;
                        buttonUploatpay.Enabled = false;

                        string InsertNotification = "insert into notifications (serial,name,type,userid,collector,datetime) select distinct client,client,'New Payments',useridt,collectort,getdate() from TempPayments";
                        cmd = new SqlCommand(InsertNotification, con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please set payment date", "Missing info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please select an excel file to continue", "No file chosen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dateTimePickerNewPay_ValueChanged(object sender, EventArgs e)
        {
            if (dataGridViewNewPayments.RowCount >= 1)
            {
                for (int i = 0; i < dataGridViewNewPayments.RowCount; i++)
                {
                    dataGridViewNewPayments.Rows[i].Cells[dataGridViewTextBoxColumn1.Index].Value = dateTimePickerNewPay.Text;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Import_Actions_Schema" + DateTime.Today.ToString("dd-MMM-yy") + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ToCsV(dataGridViewAct, sfd.FileName);
            }
        }

        private void buttonGetNewSchema_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Import_New_Payments_Schema_"+DateTime.Today.ToString("dd-MMM-yy") + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ToCsV(dataGridViewNewPayments, sfd.FileName);
            }
        }
    }
}
