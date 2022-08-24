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
    public partial class plv_settings_toonat_win : Form
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
            string url = plv.browser_urlload + "?game=" + sdvxwin.setgame;
            browser = new ChromiumWebBrowser(url);
            //browser = new ChromiumWebBrowser("chrome://version");
            this.Controls.Add(browser);
            LifespanHandler life = new LifespanHandler();
            browser.LifeSpanHandler = life;

            browser.MenuHandler = new CustomMenuHandler();
            browser.Dock = DockStyle.Fill;

            browser.AddressChanged += BrowserAddressChanged;
        }

        void BrowserAddressChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(browser.Address);
            if(browser.Address == "https://nolja.bizotoge.areatm.com/public/plive/rtmpset/?game=" + sdvxwin.setgame + "&success=1"
                || browser.Address == "https://nolja.bizotoge.areatm.com/public/plive/channel_noti/?game=" + sdvxwin.setgame + "&success=1")
            {
                this.Close();
            }
        }

        public plv_settings_toonat_win()
        {
            InitializeComponent();
            InitBrowser();
        }



        private void plv_settings_toonat_win_Load(object sender, EventArgs e)
        {
            this.Text = plv.browser_name;
            this.Font = new Font(sdvxwin.font_5_0_r.Families[0], 12f);
        }

        private void plv_settings_toonat_win_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
