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

namespace NoljaBroadcast
{
    public partial class sdvxchat : Form
    {
        public ChromiumWebBrowser browser;
        public void InitBrowser()
        {
            var settings = new CefSettings();
            settings.CachePath = "cache_drumchat";

            if (CefSharp.Cef.IsInitialized == false)
                CefSharp.Cef.Initialize(settings);

            browser = new ChromiumWebBrowser("https://youtu.be/F-i6hv0tSms");
            this.Controls.Add(browser);
            //browser.Dock = DockStyle.Fill;
            browser.Size= new System.Drawing.Size(376, 155);
            
        }

        public sdvxchat()
        {
            InitializeComponent();
            InitBrowser();
            
        }

        public static string GameName;

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void SpecialNotice_Load(object sender, EventArgs e)
        {
            //webBrowser1.Navigate("https://www.youtube.com/live_chat?v=A_e6xELqjCM&is_popout=1");
            //webBrowser1.Visible = true;
        }
    }
}
