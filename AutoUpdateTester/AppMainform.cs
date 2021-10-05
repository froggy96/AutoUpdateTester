using AutoUpdaterDotNET;
using System;
using System.Windows.Forms;

namespace AutoUpdateTester
{
    public partial class AppMainform : Form
    {
        public AppMainform()
        {
            InitializeComponent();

            // initiate AutoUpdater
            AutoUpdater.Start("http://localhost/fms/application/csupdate/autoupdate.xml");
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // get current version
            string version = System.Windows.Forms.Application.ProductVersion;

            //
            this.Text += $"    Ver: {version}, Started At: {DateTime.Now:yyyy-MM-dd HH:mm:ss}, Build Time: {GetMyEXEFileCreationTime}";
            
            //
            tbCurrentAppVersion.Text = version;
        }

        private string GetMyEXEFileCreationTime
        {
            get
            {
                string exe_path = System.Reflection.Assembly.GetEntryAssembly().Location;
                return System.IO.File.GetLastWriteTime(exe_path).ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

    }
}
