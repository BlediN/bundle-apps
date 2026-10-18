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
using System.Diagnostics;
using System.Net;
using System.Deployment.Application;



namespace MainDebtApp
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }
        public String userna { get { return this.comboBox1.Text.ToString(); } }
        public String collector { get { return collector1; } }
        string collector1 = null;
               
        private void Users_Load(object sender, EventArgs e)
        {
          //  usernamesTableAdapter.Fill(this.forAmazonDataSet.Usernames);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string direktoria = AppDomain.CurrentDomain.BaseDirectory;
            string entering = null;
            Cursor.Current = Cursors.WaitCursor;
            string combo = comboBox1.Text;
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["InstantLogin"].ConnectionString;
            SqlConnection connection = new SqlConnection(conString);
            string Query = "SELECT Password,Collector FROM Usernames where Username =@username";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@username", combo);


            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {

                    entering = reader.GetString(0);
                    collector1 = reader.GetString(1);
                    // entering = textBoxTest.Text;
                }
            }
            connection.Close();
            if (entering == textBoxPassword.Text)
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
                string versioni = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
                string insertAppVerion = "insert into appversion (username,ip,timedate,version,pcname,logtype) values (@users,@ip,@timedat,@version,@cpname,'Log In')";
                command = new SqlCommand(insertAppVerion,connection);
                command.Parameters.AddWithValue("@users", combo);
                command.Parameters.AddWithValue("@ip", PICPS);
                command.Parameters.AddWithValue("@timedat", DateTime.Now);
                command.Parameters.AddWithValue("@version", versioni);
                command.Parameters.AddWithValue("@cpname", System.Environment.MachineName);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                pictureBoxLoading.Visible = true;
                comboBox1.SelectedItem = collector;
                Form1 formopen = new Form1();
            //    Users usr = new Users();
                formopen.Show();
                this.Hide();
            }
            else
            {
                label2.Visible = true;
                // MessageBox.Show("Try again");
            }
        }

        private void TextBoxPass(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                buttonLogin_Click(sender, e);
            }
        }

        private void DeveloperToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  string chr = "chrome.exe";
            string lnk = "https://al.linkedin.com/in/admir-tërshalla-a734b638";
            //ProcessStartInfo psi = new ProcessStartInfo(chr,lnk);
            Process.Start(lnk);
         //   processDev.Start(psi);
           
        }

        private void newVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewUpdates whats = new NewUpdates();
            whats.ShowDialog();
        }

        private void softwareUpdateToolStripMenuItem_Click(object sender, EventArgs e)
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




        //private void buttonDraw_Click(object sender, EventArgs e)
        //{
        //    Graphics g = Graphics.FromHwnd(this.Handle);
        //    for (int count = 0; count < imageListSlides.Images.Count; count++)
        //    {
        //        imageListSlides.Draw(g, new Point(264, 40), count);
        //        // Paint the form and wait to load the image
        //        Application.DoEvents();
        //        System.Threading.Thread.Sleep(1000);

        //    }

        //}
    }
 }

