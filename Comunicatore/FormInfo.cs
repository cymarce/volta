using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comunicatore
{
    public partial class FormInfo : Form
    {
        public FormInfo()
        {
            InitializeComponent();
        }


        private void FormInfo_Load(object sender, EventArgs e)
        {
            lblversione.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            lbldata.Text = RetriveLinkerTimestamp(System.Reflection.Assembly.GetEntryAssembly().Location).ToString();
            lnklblAppConfigFile.Text = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None).FilePath;
            lnklblUserConfigFile.Text = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath;
        }

        private void lnklblUserConfigFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", '"' + System.IO.Path.GetDirectoryName(lnklblUserConfigFile.Text) + '"');
        }

        private void lnklblAppConfigFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", '"' + System.IO.Path.GetDirectoryName(lnklblAppConfigFile.Text) + '"');
        }


        DateTime RetriveLinkerTimestamp(string  filepath)
        {
            const int PeHeaderOffset = 60;
            const int LinkerTimerstampOffset = 8;
            byte[] b = new byte[2048];

            System.IO.Stream s = new System.IO.FileStream(filepath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            s.Read(b, 0, 2048);

            int i = BitConverter.ToInt32(b, PeHeaderOffset);
            int secondSince1970 = BitConverter.ToInt32(b, i + LinkerTimerstampOffset);
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0);
            dt = dt.AddSeconds(secondSince1970);
            dt = dt.AddHours(TimeZone.CurrentTimeZone.GetUtcOffset(dt).Hours);
            return dt;
}
    }
}
