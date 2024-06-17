//using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AreaTM_acbas
{
    public partial class maintance_win : Form
    {
        string url;
        //public ChromiumWebBrowser browser;

        public async void InitBrowser()
        {
            //string url = GetHtmlString("https://service.stream-assistant-5.gekimoe.areatm.com/public/maintance?ngame=" + sdvxwin.setgame + "&build=" + sdvxwin.nolja_build);

            /*browser = new ChromiumWebBrowser(url);
            //browser = new ChromiumWebBrowser("chrome://version");
            this.Controls.Add(browser);
            LifespanHandler life = new LifespanHandler();
            browser.LifeSpanHandler = life;

            browser.MenuHandler = new CustomMenuHandler();
            browser.Dock = DockStyle.Fill;*/

            await browser.EnsureCoreWebView2Async();

            if (url == null) //일반적인 전체공지라면
            {
                browser.CoreWebView2.Navigate("https://service.stream-assistant-5.gekimoe.areatm.com/public/maintance?ngame=" + sdvxwin.setgame + "&build=" + sdvxwin.nolja_build);
            }
            else //그게 아니면
            {
                browser.CoreWebView2.Navigate(url);
            }

            browser.CoreWebView2.Settings.AreDevToolsEnabled = false;
            browser.CoreWebView2.Settings.AreBrowserAcceleratorKeysEnabled = false;
            browser.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
        }
        
        public maintance_win(string url_g)
        {
            url = url_g;
            InitializeComponent();
            InitBrowser();
        }



        private void maintance_win_Load(object sender, EventArgs e)
        {
            
        }

        private void maintance_win_FormClosing(object sender, FormClosingEventArgs e)
        {
            maintaince_check.isopen = false;
        }
    }
}
