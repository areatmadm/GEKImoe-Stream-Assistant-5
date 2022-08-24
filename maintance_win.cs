using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AreaTM_acbas
{
    public partial class maintance_win : Form
    {
        public ChromiumWebBrowser browser;

        private string GetHtmlString(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
                string strHtml = reader.ReadToEnd();

                reader.Close();
                response.Close();

                return strHtml;
            }
            catch
            {
                return "Error";
            }
        }

        public void InitBrowser()
        {
            string url = GetHtmlString("https://nolja.bizotoge.areatm.com/public/maintance/?ngame=" + sdvxwin.setgame + "&build=" + sdvxwin.nolja_build);

            browser = new ChromiumWebBrowser(url);
            //browser = new ChromiumWebBrowser("chrome://version");
            this.Controls.Add(browser);
            LifespanHandler life = new LifespanHandler();
            browser.LifeSpanHandler = life;

            browser.MenuHandler = new CustomMenuHandler();
            browser.Dock = DockStyle.Fill;
        }

        public maintance_win()
        {
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
