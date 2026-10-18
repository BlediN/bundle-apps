using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;

namespace MainDebtApp
{
    public partial class Settings : Form

    {
        string AmznString = "Data Source=debitor.c8kumftnoykl.eu-central-1.rds.amazonaws.com,1433;Initial Catalog=ForAmazon;User ID=debitordata;Password=Trsdmr92l161";
        private readonly BackgroundWorker worker1;
        DataTable ds = new DataTable();
        public Settings()
        {
            InitializeComponent();         
            worker1 = new BackgroundWorker();
            worker1.DoWork += GetDataFrom;
            worker1.RunWorkerCompleted += work_complete;
            worker1.ProgressChanged += worker_ProgressChanged;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //worker.RunWorkerAsync();

            
            //button5.Enabled = false;
        }

        private void StartCounting(object sender, DoWorkEventArgs e)
        {
            //BackgroundWorker bgWorker = (BackgroundWorker)sender;
            //for (var i = 0; i < 10; i++)
            //{
            //    bgWorker.ReportProgress(i);
            //    Thread.Sleep(1000);
            //}
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            textBox2.Text = e.ProgressPercentage.ToString();
        }

        //        void worker_RunWorkerCompleted(object sender,
        //RunWorkerCompletedEventArgs e)
        //        {
        //            button5.Enabled = true;
        //        }

        private void button6_Click(object sender, EventArgs e)
        {
            worker1.RunWorkerAsync();


            button6.Enabled = false;
        }
        private void GetDataFrom(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bgWorker1 = (BackgroundWorker)sender;
            
            SqlConnection con = new SqlConnection(AmznString);
            string fillgrid = "select * from debtorsactive where client like '%credit%'";
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = new SqlCommand(fillgrid, con);
            adapt.Fill(ds);
          //  bgWorker1.ReportProgress(ds.Rows.Count);
            //dataGridViewTest.DataSource = ds;
            
        }
        void work_complete(object sender,RunWorkerCompletedEventArgs e)
        {
            button6.Enabled = true;
            dataGridViewTest.DataSource = ds;
        }
    }
}
