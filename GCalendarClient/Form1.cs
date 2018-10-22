using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace GCalendarClient
{
    public partial class GCal_Main_Form : Form
    {
        
        static double dblGlobalZoomLevel = Properties.Settings.Default.DefaultZoom;

        //private System.Windows.Forms.Button clearButton;
        //private System.Drawing.Drawing2D.GraphicsPath mousePath;
        //private System.Windows.Forms.GroupBox groupBox1;

        //private int fontSize = 20;
        public GCal_Main_Form()
        {
            InitializeComponent();
            //menuStrip1.Dock = DockStyle.Top;
            InitializeChromium();
            toolStripContainer1.ContentPanel.Controls.Add(chromeBrowser);
            ToolStripLabel1.Text = String.Format("Zoom: {0}%", 100 + (dblGlobalZoomLevel * 10));
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings() { CachePath = "cache" };
            // set the Cache so that it remembers passwords and stuff
            settings.PersistSessionCookies = true;
            settings.PersistUserPreferences = true;
            settings.CefCommandLineArgs.Add("enable-media-stream", "1");
            // Initialize cef with the provided settings
            Cef.Initialize(settings);
            // Create a browser component
            chromeBrowser = new ChromiumWebBrowser(Properties.Settings.Default.DefaultURL);
            // Add it to the form and fill it to the form window.
            this.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;

            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }

        
       
       
        private void ToolStripZoomIn_Click(object sender, EventArgs e)
        {
            chromeBrowser.SetZoomLevel(++dblGlobalZoomLevel);
            ToolStripLabel1.Text = String.Format("Zoom: {0}%", 100 + (dblGlobalZoomLevel * 10));
        }

        private void ToolStripZoomOut_Click(object sender, EventArgs e)
        {
            chromeBrowser.SetZoomLevel(--dblGlobalZoomLevel);
            ToolStripLabel1.Text = String.Format("Zoom: {0}%", 100 + (dblGlobalZoomLevel * 10));
        }

        private void ToolStripZoomReset_Click(object sender, EventArgs e)
        {
            dblGlobalZoomLevel = Properties.Settings.Default.DefaultZoom;
            chromeBrowser.SetZoomLevel(dblGlobalZoomLevel);
            ToolStripLabel1.Text = String.Format("Zoom: {0}%", 100 + (dblGlobalZoomLevel * 10));
        }

        
    }
}
