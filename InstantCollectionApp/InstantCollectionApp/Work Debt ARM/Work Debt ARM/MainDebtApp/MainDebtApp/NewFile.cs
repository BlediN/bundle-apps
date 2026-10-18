using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace MainDebtApp
{
    public partial class NewFile : Form
    {
        public string filePath = null,serialNumber=null,username=null;
        public string filename = null,ext=null,contenttype=null;
        public NewFile()
        {
            InitializeComponent();
            if (Application.OpenForms["Form1"] != null)
            {
                serialNumber = (Application.OpenForms["Form1"] as Form1).textname;
                username = (Application.OpenForms["Users"] as Users).userna;
            }
            
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
           // openFileDialog1.Filter = "Pdf Files (*.pdf)|*.pdf";
            openFileDialog1.Multiselect = false;
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.RestoreDirectory = false;
            openFileDialog1.ShowDialog();
            filePath = openFileDialog1.FileName;
            filename = Path.GetFileName(filePath);
            long length = new System.IO.FileInfo(filePath).Length;
            if (length<= 6400000)
            {
                textBoxfPath.Text = filePath;
                ext = Path.GetExtension(filename);
                contenttype = String.Empty;
            }

            else
            {
                MessageBox.Show("File exceeding 6 MB", "File size error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void buttonUpload_Click(object sender, EventArgs e)
        {
            if (textBoxfPath.Text != null && textBoxfPath.Text != "")
            {
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
                    FileStream fs = new FileStream(filePath, FileMode.Open);
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    SqlConnection con = new SqlConnection("Data Source=debitor.c8kumftnoykl.eu-central-1.rds.amazonaws.com,1433;Initial Catalog=ForAmazon;User ID=debitordata;Password=Trsdmr92l161");
                    //insert the file into database
                    string strQuery = "insert into FileAttachments(SerialNo,Name, FileType, Files,userid)" +
                     " values (@serial,@Name, @ContentType, @Data,@users)";
                    SqlCommand cmd = new SqlCommand(strQuery, con);
                    cmd.Parameters.Add("@Serial", SqlDbType.VarChar).Value = serialNumber;
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = filename;
                    cmd.Parameters.Add("@ContentType", SqlDbType.VarChar).Value
                    = contenttype;
                    cmd.Parameters.Add("@Data", SqlDbType.Binary).Value = bytes;
                    cmd.Parameters.Add("users", SqlDbType.VarChar).Value = username;

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("succesfully uploaded", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBoxfPath.Text = null;
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
                    MessageBox.Show("Empty file");
                }
            }
            else
            {
                MessageBox.Show("Please select a file","Action required",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
    }
}
