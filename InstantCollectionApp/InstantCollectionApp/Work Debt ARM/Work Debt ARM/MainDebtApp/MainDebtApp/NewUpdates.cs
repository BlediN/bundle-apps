using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
namespace MainDebtApp
{
    public partial class NewUpdates : Form
    {
        public NewUpdates()
        {
            InitializeComponent();
            string version= System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            //  Text = Text + " " + version.Major + "." + version.Minor + " (build " + version.Build + ")"; //change form title
            // var version1 = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            labelVersion.Text = "What's new in version " + version;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
