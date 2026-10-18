using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
//using PdfiumViewer;
namespace MainDebtApp
{
    public partial class Preview : Form
    {
        public string DocumentId = null;
        public Preview()
        {
            InitializeComponent();
            if (Application.OpenForms["Form1"] != null)
            {
                DocumentId = (Application.OpenForms["Form1"] as Form1).DocID;

            }
            buttonPreview_Click();
        }
        private void buttonPreview_Click()
        {
            string conectionStr = "Data Source=debitor.c8kumftnoykl.eu-central-1.rds.amazonaws.com,1433;Initial Catalog=ForAmazon;User ID=debitordata;Password=Trsdmr92l161";
            SqlConnection con = new SqlConnection(conectionStr);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand("SELECT files FROM fileattachments WHERE id ='"+DocumentId+"'", con));
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            if (dataSet.Tables[0].Rows.Count == 1)
            {
                Byte[] data = new Byte[0];
                data = (Byte[])(dataSet.Tables[0].Rows[0]["files"]);
                MemoryStream mem = new MemoryStream(data);
                PictureBoxBill.Image = Image.FromStream(mem);
               // richTextBoxPDF.Text = mem.
                // webBrowserPreview.Navigate(mem.ToString());
                // this.webBrowserPreview.NavigateToStream(mem);
                //  var stream = mem;
                //  axFoxitCtl1.OpenFile(stream);
                //  PdfRenderer pdfRenderer = new PdfRenderer();
                //PdfDocument pdfDocument = PdfDocument.Load(mem);
               // axRDPViewer1.Show();
                

            }
        }
    }
}
