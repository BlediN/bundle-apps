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
using System.Configuration;
using System.Text.RegularExpressions;
using System.Web;

namespace MainDebtApp
{
    public partial class TestForm : Form
    {
        DataTable dTable=new DataTable();
        //HttpRequest Request=new HttpRequest("","","");
        //public OpenFileDialog ofp = new OpenFileDialog();
        public TestForm()
        {
            
            InitializeComponent();
        }

        private void buttonTest1_Click(object sender, EventArgs e)
        {
            //  MessageBox.Show("hello world","hello",MessageBoxButtons.OK,MessageBoxIcon.Information);
           // string str = "addadwdaw";
         
            openFileDialog1.ShowDialog();
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            //openFileDialog1.ShowDialog();

            //  OpenFileDialog openFileDialog1 = new OpenFileDialog();
            ////  openFileDialog1.Filter = "Pdf Files (*.pdf)|*.pdf";
            //  openFileDialog1.Multiselect = false;
            //  openFileDialog1.CheckFileExists = true;
            //  openFileDialog1.RestoreDirectory = false;

            //  //string initDir = "C:/Logs";

            //  //openFileDialog1.InitialDirectory = !Directory.Exists(initDir) ? Path.GetPathRoot(Environment.SystemDirectory) : initDir;

            //  if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            //  {

            //foreach (string upload in Request.Files)
            //{
            //  //  if (!Request.Files[upload].HasFile1()) continue;

            //    string mimeType = Request.Files[upload].ContentType;
            //    Stream fileStream = Request.Files[upload].InputStream;
            //    string fileName = Path.GetFileName(Request.Files[upload].FileName);
            //    int fileLength = Request.Files[upload].ContentLength;
            //    byte[] fileData = new byte[fileLength];
            //    fileStream.Read(fileData, 0, fileLength);

            //   // const string connect = @"Server=localhost;Database=Images;user id=taraw; password=****;";
            //    SqlConnection conn = new SqlConnection("Data Source=skipdbs.database.windows.net;Initial Catalog=SkipDtb;User ID=TotalDtb;Password=Trsdmr92l161");


            //    var qry = "insert into dokumentet(Name, ContentType, Files) values (@Name, @ContentType, @Data)";
            //        var cmd = new SqlCommand(qry, conn);
            //        cmd.Parameters.AddWithValue("@Data", fileData);
            //        cmd.Parameters.AddWithValue("@ContentType", mimeType);
            //        cmd.Parameters.AddWithValue("@Name", fileName);
            //        conn.Open();
            //        cmd.ExecuteNonQuery();

            //}



            //foreach (String file in openFileDialog1.FileNames)
            //{
            //    try
            //    {
            //        dataGridView1.DataSource = LoadTable(file);

            //        SqlConnection conn = new SqlConnection("Data Source=skipdbs.database.windows.net;Initial Catalog=SkipDtb;User ID=TotalDtb;Password=Trsdmr92l161");
            //        SqlCommand command = new SqlCommand();
            //                conn.Open();

            //                command.Connection = conn;
            //        command.CommandText = "insert into dokumentet(Name, ContentType, Files) values (@Name, @ContentType, @Data)";


            //                command.Parameters.AddWithValue("@Name", DbType.String);
            //                command.Parameters.AddWithValue("@ContentType", DbType.String);
            //                command.Parameters.AddWithValue("@Data", DbType.String);


            //                foreach (DataGridViewRow row in dataGridView1.Rows)
            //                {
            //                    if (!row.IsNewRow)
            //                    {

            //                        command.Parameters["@Name"].Value = row.Cells[0].Value;
            //                        command.Parameters["@ContentType"].Value = row.Cells[1].Value;
            //                        command.Parameters["@Data"].Value = row.Cells[2].Value;

            //                        command.ExecuteNonQuery();
            //                    }
            //                    command.CommandType = CommandType.Text;
            //                }

            //    }
            //    catch (Exception err)
            //    {
            //        MessageBox.Show("Error:  " + err.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            // }
        }

        private DataTable LoadTable(string filename)
        {

            if (dTable.Columns.Count!=3)
            {
                dTable.Columns.Add(new DataColumn("LogName", typeof(string)));
                dTable.Columns.Add(new DataColumn("Channel", typeof(string)));
                dTable.Columns.Add(new DataColumn("DateRecord", typeof(string)));
            }
         
           

            DataRow dr;

            String sLine = new StreamReader(filename).ReadToEnd();

            if (sLine != null)
            {
                foreach (string regel in Regex.Split(sLine, "\r\n"))
                {
                    if (!string.IsNullOrEmpty(regel))
                    {
                        dr = dTable.NewRow();

                        string[] splitregel = Regex.Split(regel.Replace("|", ";"), ";");

                        dr[0] = splitregel[0];
                        //dr[1] = splitregel[1];
                        //dr[2] = splitregel[2];
                       // dr[3] = splitregel[3];
                      

                        dTable.Rows.Add(dr);
                    }
                }
            }
            return dTable;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string filePath = openFileDialog1.FileName;
            string filename = Path.GetFileName(filePath);
            textBoxfPath.Text = filePath;
            string ext = Path.GetExtension(filename);
            string contenttype = String.Empty;

            //Set the contenttype based on File Extension
            switch (ext)
            {
                case ".doc":
                    contenttype = "application/vnd.ms-word";
                    break;
                case ".docx":
                    contenttype = "application/vnd.ms-word";
                    break;
                case ".xls":
                    contenttype = "application/vnd.ms-excel";
                    break;
                case ".xlsx":
                    contenttype = "application/vnd.ms-excel";
                    break;
                case ".jpg":
                    contenttype = "image/jpg";
                    break;
                case ".PNG":
                    contenttype = "image/png";
                    break;
                case ".gif":
                    contenttype = "image/gif";
                    break;
                case ".pdf":
                    contenttype = "application/pdf";
                    break;
            }

            if (contenttype != String.Empty)
            {
                //Encoding utf16 = Encoding.GetEncoding(1254);
                //byte[] output = utf16.GetBytes(stOutput);
                //FileStream fs = new FileStream(filename, FileMode.Create);
                //BinaryWriter bw = new BinaryWriter(fs);
                //bw.Write(output, 0, output.Length); //write the encoded file
                //bw.Flush();
                //bw.Close();
                //fs.Close();

                FileStream fs = new FileStream(filePath, FileMode.Open);
                BinaryReader br = new BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);
               SqlConnection con = new SqlConnection("Data Source=skipdbs.database.windows.net;Initial Catalog=SkipDtb; User ID=TotalDtb;Password=Trsdmr92l161");
                //insert the file into database
                string strQuery = "insert into [dokumentet] (Name, ContentType, Files)" +
                 " values (@Name, @ContentType, @Data)";
                SqlCommand cmd = new SqlCommand(strQuery,con);
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = filename;
                cmd.Parameters.Add("@ContentType", SqlDbType.VarChar).Value
                = contenttype;
                cmd.Parameters.Add("@Data", SqlDbType.Binary).Value = bytes;

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
                //  lblMessage.ForeColor = System.Drawing.Color.Green;
                // lblMessage.Text = "File Uploaded Successfully";
            }
            else
            {
                MessageBox.Show("Empty file");
            }
        }

        private void buttonPreview_Click(object sender, EventArgs e)
        {
            string conectionStr = "Data Source=skipdbs.database.windows.net;Initial Catalog=SkipDtb;User ID=TotalDtb;Password=Trsdmr92l161";
            SqlConnection con = new SqlConnection(conectionStr);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand("SELECT files FROM dokumentet WHERE id = 1715", con));
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            if (dataSet.Tables[0].Rows.Count == 1)
            {
                Byte[] data = new Byte[0];
                data = (Byte[])(dataSet.Tables[0].Rows[0]["files"]);
                MemoryStream mem = new MemoryStream(data);
                PictureBoxBill.Image = Image.FromStream(mem);
            }
        }

        private void buttonMultiple_Click(object sender, EventArgs e)
        {
            //foreach (HttpPostedFile postedFile in FileUpload1.PostedFiles)
            //{
            //    string filename = Path.GetFileName(postedFile.FileName);
            //    string contentType = postedFile.ContentType;
            //    using (Stream fs = postedFile.InputStream)
            //    {
            //        using (BinaryReader br = new BinaryReader(fs))
            //        {
            //            byte[] bytes = br.ReadBytes((Int32)fs.Length);
            //            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            //            using (SqlConnection con = new SqlConnection(constr))
            //            {
            //                string query = "insert into tblFiles values (@Name, @ContentType, @Data)";
            //                using (SqlCommand cmd = new SqlCommand(query))
            //                {
            //                    cmd.Connection = con;
            //                    cmd.Parameters.AddWithValue("@Name", filename);
            //                    cmd.Parameters.AddWithValue("@ContentType", contentType);
            //                    cmd.Parameters.AddWithValue("@Data", bytes);
            //                    con.Open();
            //                    cmd.ExecuteNonQuery();
            //                    con.Close();
            //                }
            //            }
            //        }
            //    }
            //}
            //Response.Redirect(Request.Url.AbsoluteUri);
        }
    }
}
