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
    public partial class Notifications : Form
    {
        string LogColl = null;
        DataTable ds = new DataTable();
        string AmznString = "Data Source=debitor.c8kumftnoykl.eu-central-1.rds.amazonaws.com,1433;Initial Catalog=ForAmazon;User ID=debitordata;Password=Trsdmr92l161";
        public Notifications()
        {
            InitializeComponent();
            if (Application.OpenForms["Form1"] != null)
            {
                LogColl = (Application.OpenForms["Form1"] as Form1).LogColl;
            }
        }
        public DataTable  Dtb { get { return this.ds; } }


        private void Notifications_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string selectall = "select id, serial,name,type,userid,datetime from notifications where collector like '"+LogColl+"%' order by datetime desc";
            SqlConnection con = new SqlConnection(AmznString);
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = new SqlCommand(selectall, con);
            adapt.Fill(dt);
            dataGridViewNotif.DataSource = dt;
        }

        private void buttonFill_Click(object sender, EventArgs e)
        {
            ds.Clear();
           //DataTable dt = new DataTable();
            // List<string> RowsReturnet = new List<string>();
            SqlConnection con1 = new SqlConnection(AmznString);

                string Search1 = "SELECT DebtorsActive.* from(Notifications INNER JOIN DebtorsActive ON notifications.serial = DebtorsActive.Debt_Serial_Number) Where collector like '"+LogColl
        +"%'"+ " GROUP BY DebtorsActive.Debt_Serial_Number, debt_id,client,Debt_Type,Debtor_Full_Name,Portfolio_Status ,Latest_Comment,Outstanding_Principal,Outstanding_Interest,Outstanding_Penalty,Currency,Portfolio,Debt_Collector,Total_Outstanding,Latest_Person_Contacted,Assigment_Date,Client_Branch,Next_Action_Date,DebtorsActive.Reaction,DebtorsActive.Last_Updated,DebtorsActive.User_Id,Last_Act_type,ContactedVia,PTP_Amount,[CloseDate] ,[BranchId]  ,[DisbursmentDate]  ,[FinishedDate],[LoanTenure] ,[PmtRepayment],[AvgMoRepayment]  ,[PMTpercentage]  ,[RestructuredContract],[IsRestructured],[MonthsFromDisbursment],[MonthRecoveryRate],[RecoveryPeriod],[FPD],[DisbursmentAmount],[InALL_Base],[AmountInDelay],[PrincipalDelay],[InterestDelay],[Penalty],[UpComingInterest],[ClientSegment],[ProductID],[DaysInDelay],[Mortgage],[Pledge],[CashColateral],classification,linkID,PayAccNo,AssignmentDebt";
                SqlDataAdapter adapt = new SqlDataAdapter();
                adapt.SelectCommand = new SqlCommand(Search1, con1);
                adapt.Fill(ds);            
        }

        private void dataGridViewNotif_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonDelAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete all notifications?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                string deleteAll = "delete from notifications where collector like '" + LogColl + "%'";
                SqlConnection con = new SqlConnection(AmznString);
                SqlCommand cmd = new SqlCommand(deleteAll, con);
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
                string selectAll = "select id, serial,name,type,userid,datetime  from notifications where collector like '" + LogColl + "%'";
                SqlDataAdapter adapt = new SqlDataAdapter();
                adapt.SelectCommand = new SqlCommand(selectAll, con);
                adapt.Fill(ds);
                dataGridViewNotif.DataSource = ds;
            }
        }

        private void buttonDelSel_Click(object sender, EventArgs e)
        {
            List<string> rowsChecked = new List<string>();
            foreach (DataGridViewRow row in dataGridViewNotif.Rows)
            {
                if (Convert.ToBoolean(row.Cells[CheckSel.Name].Value) == true)
                {
                    rowsChecked.Add(row.Cells[1].Value.ToString());
                }
            }

            int CheckedRows = rowsChecked.Count;

            //  string conStr1 = "Data Source=debitor.c8kumftnoykl.eu-central-1.rds.amazonaws.com,1433;Initial Catalog=ForAmazon;User ID=debitordata;Password=Trsdmr92l161";
            if (CheckedRows != 0)
            {
                if (MessageBox.Show("Are you sure you want to delete " + CheckedRows.ToString() + " notifications?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection(AmznString);
                    for (int i = 0; i < CheckedRows; i++)
                    {
                        String Query = " Delete From Notifications  where ID=@id";
                       
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
                    string selectAll = "select id, serial,name,type,userid,datetime  from notifications where collector like '" + LogColl + "%'";
                    SqlDataAdapter adapt = new SqlDataAdapter();
                    adapt.SelectCommand = new SqlCommand(selectAll, con);
                    adapt.Fill(ds);
                    dataGridViewNotif.DataSource = ds;
                }
            }
            else
            {
                MessageBox.Show("At least one row must be selected", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBoxSerialNr_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
