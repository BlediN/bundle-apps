using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xceed.Words.NET;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Data.SqlClient;
using Spire.Doc;
//using Spire.Doc.Documents;
//using GemBox.Document;

namespace MainDebtApp
{
    public partial class Letter : Form
    {
        string dSerial = null;
        string Status = null;
        string AmznString = "Data Source=debitor.c8kumftnoykl.eu-central-1.rds.amazonaws.com,1433;Initial Catalog=ForAmazon;User ID=debitordata;Password=Trsdmr92l161";

        public Letter()
        {
            InitializeComponent();
            if (Application.OpenForms["Form1"] != null)
            {
                dSerial = (Application.OpenForms["Form1"] as Form1).textname;
                Status= (Application.OpenForms["Form1"] as Form1).UserRights;
            }
            DataTable dt = new DataTable();
            SqlConnection con1 = new SqlConnection(AmznString);
            string searchRec = "select First_name from persons where person_number='" + dSerial + "' order by relation asc";
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = new SqlCommand(searchRec, con1);
            adapt.Fill(dt);
            comboBoxReceiver.ValueMember = "First_name";
            comboBoxReceiver.DisplayMember = "First_name";
            comboBoxReceiver.DataSource = dt;
        }
        public String  provider { get { return this.comboBoxProvider.Text.ToString(); } }
        public String DueDay { get { return this.textBoxDays.Text.ToString(); } }
        public String ContactNo { get { return this.textBoxno.Text.ToString(); } }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (comboBoxProvider.SelectedIndex<=2)
            {
                if (textBoxno.Text.Length >= 5)
                {
                    string adresa = "", distrikt = "";
                    string searchAdr = "select  top(1) address,district from persons where first_name='" + comboBoxReceiver.Text + "' and person_number='" + dSerial + "'";
                    SqlConnection cons = new SqlConnection(AmznString);
                    SqlCommand cmd = new SqlCommand(searchAdr, cons);

                    cons.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.IsDBNull(0) == false)
                        {
                            adresa = reader.GetString(0);
                        }
                        if (reader.IsDBNull(1) == false)
                        {
                            distrikt = reader.GetString(1);
                        }
                    }
                    cons.Close();
                    if (comboBoxProvider.SelectedIndex == 0)
                    {
                        string filename = @"LeterDaf1.docx";
                        var doc = DocX.Load(filename);
                        doc.ReplaceText("phone_no", textBoxno.Text, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                        doc.ReplaceText("dateAdd", DateTime.Today.AddDays(Convert.ToDouble(textBoxDays.Text)).ToString("dd-MM-yy"), false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                        doc.ReplaceText("receivers", comboBoxReceiver.Text, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                        doc.ReplaceText("Address", adresa + ", " + distrikt, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                        // doc.

                        doc.Save();
                        this.Close();
                        Process.Start("WINWORD.EXE", filename);
                    }

                    else if (comboBoxProvider.SelectedIndex == 1)
                    {
                        string filename = @"LeterKdca1.docx";
                        var doc = DocX.Load(filename);
                        doc.ReplaceText("phone_no", textBoxno.Text, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                        doc.ReplaceText("dateAdd", DateTime.Today.AddDays(Convert.ToDouble(textBoxDays.Text)).ToString("dd-MM-yy"), false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                        doc.ReplaceText("receivers", comboBoxReceiver.Text, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                        doc.ReplaceText("Address", adresa + ", " + distrikt, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                        doc.Save();
                        this.Close();
                        Process.Start("WINWORD.EXE", filename);
                    }

                    else if (comboBoxProvider.SelectedIndex == 2)
                    {
                        string filename = @"leterunion1.docx";

                        var doc = DocX.Load(filename);
                        doc.ReplaceText("phone_no", textBoxno.Text, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                        doc.ReplaceText("dateAdd", DateTime.Today.AddDays(Convert.ToDouble(textBoxDays.Text)).ToString("dd-MM-yy"), false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                        doc.ReplaceText("dateto", DateTime.Today.ToString("dd-MM-yyyy"), false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                        doc.ReplaceText("receivers", comboBoxReceiver.Text, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                        doc.ReplaceText("Address", adresa + ", " + distrikt, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                        doc.Save();
                        this.Close();
                        Process.Start("WINWORD.EXE", filename);
                    }




                }
                else
                {
                    MessageBox.Show("Please provide e valid phone number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else if (comboBoxProvider.SelectedIndex>2)
            {

                SqlConnection cons = new SqlConnection(AmznString);
                SqlCommand cmd = new SqlCommand("dawdwad", cons);
                
                
                  if (comboBoxProvider.SelectedIndex == 3)
                  {
                    string filename = @"infoDaf.docx";
                    string fname = "", curr = "", client = "";
                    DateTime dt = new DateTime();
                    decimal total = 0;
                    double principal = 0, interest = 0, penalty = 0, paid = 0;
                    string selectInfo = "select debtor_full_name,assigment_date,total_outstanding,outstanding_principal,outstanding_interest,outstanding_penalty,currency,sum(paid_amount) as [paid amount] ,client from (debtorsactive left join paymentsjan " +
                    "on paymentsjan.debt_serial_number = debtorsactive.debt_serial_number) " +
                    "where debtorsactive.debt_serial_number = '" + dSerial + "' " +
                    "group by DebtorsActive.Debtor_Full_Name,assigment_date,total_outstanding,outstanding_principal,outstanding_interest,outstanding_penalty,DebtorsActive.currency,client ";
                    cons = new SqlConnection(AmznString);
                    cmd = new SqlCommand(selectInfo, cons);
                   
                    cons.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        fname = reader.GetString(0);
                        dt = reader.GetDateTime(1);
                        total = reader.GetDecimal(2);
                        interest = reader.GetDouble(4);
                        principal = reader.GetDouble(3);
                        penalty = reader.GetDouble(5);
                        curr = reader.GetString(6);
                        if (reader.IsDBNull(7) == false)
                        {
                            paid = reader.GetDouble(7);
                        }
                        client = reader.GetString(8);
                    }
                    cons.Close();
                    var doc = DocX.Load(filename);
                    doc.ReplaceText("fnames", fname, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("dates", DateTime.Today.ToString("dd-MM-yy"), false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("asdate", dt.ToString("dd-MM-yyyy"), false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("totals", total.ToString(), false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("principals", principal.ToString(), false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("interests", interest.ToString(), false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("penalties", penalty.ToString(), false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("Currency", curr, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("paidAmt", paid.ToString(), false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("clients", client, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.SaveAs("infoDaf1.docx");
                    this.Close();
                    Process.Start("WINWORD.EXE", "infoDaf1.docx");
                }

                else if (comboBoxProvider.SelectedIndex == 4)
                {
                    string filename = @"infoKdca.docx";
                    string fname = "", curr = "", client = "";
                    DateTime dt = new DateTime();
                    decimal total = 0;
                    double principal = 0, interest = 0, penalty = 0, paid = 0;
                    string selectInfo = "select debtor_full_name,assigment_date,total_outstanding,outstanding_principal,outstanding_interest,outstanding_penalty,currency,sum(paid_amount) as [paid amount],client from (debtorsactive left join paymentsjan " +
                    "on paymentsjan.debt_serial_number = debtorsactive.debt_serial_number) " +
                    "where debtorsactive.debt_serial_number = '" + dSerial + "' " +
                    "group by DebtorsActive.Debtor_Full_Name,assigment_date,total_outstanding,outstanding_principal,outstanding_interest,outstanding_penalty,DebtorsActive.currency,client  ";
                    cons = new SqlConnection(AmznString);
                    cmd = new SqlCommand(selectInfo, cons);
                    cons.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        fname = reader.GetString(0);
                        dt = reader.GetDateTime(1);
                        total = reader.GetDecimal(2);
                        interest = reader.GetDouble(4);
                        principal = reader.GetDouble(3);
                        penalty = reader.GetDouble(5);
                        curr = reader.GetString(6);
                        if (reader.IsDBNull(7) == false)
                        {
                            paid = reader.GetDouble(7);
                        }
                        client = reader.GetString(8);
                    }
                    cons.Close();
                    var doc = DocX.Load(filename);
                    doc.ReplaceText("fnames", fname, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("dates", DateTime.Today.ToString("dd-MM-yy"), false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("asdate", dt.ToString("dd-MM-yyyy"), false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("totals", total.ToString(), false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("principals", principal.ToString(), false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("interests", interest.ToString(), false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("penalties", penalty.ToString(), false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("Currency", curr, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("paidAmt", paid.ToString(), false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("clients", client, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.SaveAs("infoKdca1.docx");
                    this.Close();
                    Process.Start("WINWORD.EXE", "infoKdca1.docx");
                }

                else if (comboBoxProvider.SelectedIndex == 5)
                {
                    string filename = @"vertetim.docx";
                    string fname = "";
                    double total = 0;

                    string selectInfo = "select debtorsactive.debtor_full_name,sum(paid_amount) from  " +
                        " (debtorsactive left join paymentsjan on paymentsjan.debt_serial_number = debtorsactive.debt_serial_number) where debtorsactive.debt_serial_number='" + dSerial + "' group by debtorsactive.debtor_full_name ";

                    cons = new SqlConnection(AmznString);
                    cmd = new SqlCommand(selectInfo, cons);
                    cons.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        fname = reader.GetString(0);

                        total = (reader.IsDBNull(1) == false) ? reader.GetDouble(1) : 0;
                    }
                    cons.Close();
                    dSerial = dSerial.Substring(7, dSerial.Length - 7);
                    string nrProt = dSerial.Insert(6, "/");
                    var doc = DocX.Load(filename);
                    doc.ReplaceText("names", fname, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("dates", DateTime.Today.ToString("dd-MM-yyyy"), false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("amount", total.ToString(), false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("cntr", dSerial, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("nrprot", nrProt, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.SaveAs("vertetim1.docx");
                    this.Close();
                    Process.Start("WINWORD.EXE", "vertetim1.docx");
                }

                else if (comboBoxProvider.SelectedIndex == 6 && (Status=="supervisor" || Status=="admin" || Status == "agent"))
                {
                    string filename = @"vertetimPdf.docx";
                    string fname = "";
                    string total = "";

                    string selectInfo = "select debtorsactive.debtor_full_name,format(sum(paid_amount),'###,###,###') from  " +
                        " (debtorsactive left join paymentsjan on paymentsjan.debt_serial_number = debtorsactive.debt_serial_number) where debtorsactive.debt_serial_number='" + dSerial + "' group by debtorsactive.debtor_full_name ";

                    cons = new SqlConnection(AmznString);
                    cmd = new SqlCommand(selectInfo, cons);
                    cons.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        fname = reader.GetString(0);

                        total = (reader.IsDBNull(1) == false) ? reader.GetString(1) : "0";
                    }
                    cons.Close();
                    dSerial = dSerial.Substring(7, dSerial.Length - 7);
                    string nrProt = dSerial.Insert(6, "/");
                    var doc = DocX.Load(filename);
                    doc.ReplaceText("names", fname, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("dates", DateTime.Today.ToString("dd-MM-yyyy"), false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("amount", total.ToString(), false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("cntr", dSerial, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("nrprot", nrProt, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.SaveAs("vertetim2.docx");
                    Document document = new Document();
                    document.LoadFromFile("vertetim2.docx");
                    document.SaveToFile("vertetimPDF.PDF", FileFormat.PDF);
                    this.Close();
                    System.Diagnostics.Process.Start("vertetimPDF.PDF");
                }

                if (comboBoxProvider.SelectedIndex == 7)
                {
                    string filename = @"albinfo.docx";
                    string fname = "", adres = "", client = "",district="",phone="";
                    string serial = dSerial.Substring(7, dSerial.Length - 7);
                    string nrProt = serial.Insert(6, "/");
                    string total = "";
                    
                    string selectInfo = "select top(1) debtor_full_name,format(total_outstanding ,'###,###,###') as total_outstanding,debtorsactive.portfolio,address,district,phone from (debtorsactive inner join Persons on Persons.person_number = debtorsactive.debt_serial_number inner join usernames on collector=debtorsactive.debt_collector)" +
                     " where debtorsactive.debt_serial_number ='"+dSerial+"' "+
                    " and District<>'' and District is not null " +
                    " and Portfolio_Status = 'active' group by" +
                    " DebtorsActive.Debtor_Full_Name,total_outstanding," +
                    " debtorsactive.portfolio,address,district,phone";
                    cons = new SqlConnection(AmznString);
                    cmd = new SqlCommand(selectInfo, cons);

                    cons.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        fname = reader.GetString(0);                     
                        total = reader.GetString(1);                                                          
                        client = reader.GetString(2);
                        adres = reader.GetString(3);
                        district = reader.GetString(4);
                        phone = reader.GetString(5);
                    }

                    if (client.ToLower()=="daf-em")
                    {
                        client = "Eagle Mobile";
                    }

                    else
                    {
                        client = "Albtelecom";
                    }
                    cons.Close();
                    var doc = DocX.Load(filename);
                    doc.ReplaceText("fnames", fname, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("protDate", nrProt, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("contr", serial, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("receivers", fname, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("dates", DateTime.Today.ToString("dd-MM-yyyy"), false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("Address", adres+", "+district, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("totals", total.ToString(), false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);                                  
                    doc.ReplaceText("clients", client, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("usercnt", phone, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.SaveAs("albinfo1.docx");
                    this.Close();
                    Process.Start("WINWORD.EXE", "albinfo1.docx");
                }

                if (comboBoxProvider.SelectedIndex == 8)
                {
                    string filename = @"albfinal.docx";
                    string fname = "", adres = "", client = "", district = "", phone = "";
                    string serial = dSerial.Substring(7, dSerial.Length - 7);
                    string nrProt = serial.Insert(6, "/");
                    string total = "";

                    string selectInfo = "select top(1) debtor_full_name,format(total_outstanding ,'###,###,###') as total_outstanding,debtorsactive.portfolio,address,district,phone from (debtorsactive inner join Persons on Persons.person_number = debtorsactive.debt_serial_number inner join usernames on collector=debtorsactive.debt_collector)" +
                     " where debtorsactive.debt_serial_number ='" + dSerial + "' " +
                    " and District<>'' and District is not null " +
                    " and Portfolio_Status = 'active' group by" +
                    " DebtorsActive.Debtor_Full_Name,total_outstanding," +
                    " debtorsactive.portfolio,address,district,phone";
                    cons = new SqlConnection(AmznString);
                    cmd = new SqlCommand(selectInfo, cons);

                    cons.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        fname = reader.GetString(0);
                        total = reader.GetString(1);
                        client = reader.GetString(2);
                        adres = reader.GetString(3);
                        district = reader.GetString(4);
                        phone = reader.GetString(5);
                    }

                    if (client.ToLower() == "daf-em")
                    {
                        client = "Eagle Mobile";
                    }

                    else
                    {
                        client = "Albtelecom";
                    }
                    cons.Close();
                    var doc = DocX.Load(filename);
                    doc.ReplaceText("fnames", fname, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("protDate", nrProt, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("contr", serial, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("receivers", fname, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("dates", DateTime.Today.ToString("dd-MM-yyyy"), false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("Address", adres + ", " + district, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("totals", total.ToString(), false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("client", client, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("usercnt", phone, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.SaveAs("albfinal1.docx");
                    this.Close();
                    Process.Start("WINWORD.EXE", "albfinal1.docx");
                }

                if (comboBoxProvider.SelectedIndex == 9)
                {
                    string filename = @"albzyra.docx";
                    string fname = "", client = "";
                    string serial = dSerial.Substring(7, dSerial.Length - 7);
                    string nrProt = serial.Insert(6, "/");
                    string total = "";

                    string selectInfo = "select top(1) debtor_full_name,format(total_outstanding ,'###,###,###') as total_outstanding,debtorsactive.portfolio from debtorsactive " +
                     " where debtorsactive.debt_serial_number ='" + dSerial + "' " +                   
                    " and Portfolio_Status = 'active'";
                    cons = new SqlConnection(AmznString);
                    cmd = new SqlCommand(selectInfo, cons);

                    cons.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        fname = reader.GetString(0);
                        total = reader.GetString(1);
                        client = reader.GetString(2);                                            
                    }

                    if (client.ToLower() == "daf-em")
                    {
                        client = "Eagle Mobile";
                    }

                    else
                    {
                        client = "Albtelecom";
                    }
                    cons.Close();
                    var doc = DocX.Load(filename);
                    doc.ReplaceText("fnames", fname, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("protDate", nrProt, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("contr", serial, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("receivers", fname, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("dates", DateTime.Now.ToString("dd-MM-yyyy hh:mm"), false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);                  
                    doc.ReplaceText("totals", total.ToString(), false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.ReplaceText("clients", client, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                    doc.SaveAs("albzyra1.docx");
                    this.Close();
                    Process.Start("WINWORD.EXE", "albzyra1.docx");
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (comboBoxProvider.SelectedIndex == 0)
            {
                string filename = @"LeterDaf.docx";
                var doc = DocX.Load(filename);
                doc.ReplaceText("phone_no", textBoxno.Text, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                doc.ReplaceText("dateAdd", DateTime.Today.AddDays(Convert.ToDouble(textBoxDays.Text)).ToString("dd-MM-yy"), false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                doc.ReplaceText("receivers", "", false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                doc.ReplaceText("Address", "", false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                doc.ReplaceText("fnames", "");
                doc.ReplaceText("clinst", "");
                doc.ReplaceText("principals", "", false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                doc.ReplaceText("interests","", false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                doc.ReplaceText("penalties","", false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                doc.ReplaceText("totals", "", false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                // doc.ReplaceText("Address", listBoxDadr.Items[0].ToString(), false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                doc.ReplaceText("Currency","", false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                // doc.

                doc.SaveAs("LeterDaf2.docx");
                this.Close();
                Process.Start("WINWORD.EXE", @"LeterDaf2.docx");
            }

            else if (comboBoxProvider.SelectedIndex == 1)
            {
                string filename = @"LeterKdca.docx";
                var doc = DocX.Load(filename);
                doc.ReplaceText("phone_no", textBoxno.Text, false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                doc.ReplaceText("dateAdd", DateTime.Today.AddDays(Convert.ToDouble(textBoxDays.Text)).ToString("dd-MM-yy"), false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                doc.ReplaceText("receivers","", false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                doc.ReplaceText("Address", "", false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                doc.ReplaceText("fnames", "");
                doc.ReplaceText("clinst", "");
                doc.ReplaceText("principals", "", false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                doc.ReplaceText("interests", "", false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                doc.ReplaceText("penalties", "", false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                doc.ReplaceText("totals", "", false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                // doc.ReplaceText("Address", listBoxDadr.Items[0].ToString(), false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                doc.ReplaceText("Currency", "", false, RegexOptions.None, null, null, MatchFormattingOptions.SubsetMatch, true, false);
                // doc.
                doc.SaveAs("LeterKdca2.docx");
                this.Close();
                Process.Start("WINWORD.EXE", @"LeterKdca2.docx");
            }
        }
    }
}
