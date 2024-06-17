using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using CefSharp;
//using CefSharp.WinForms;

using System.IO;

namespace AreaTM_acbas
{
    public partial class DrumChat : Form
    {
        //string setgame;
        //string livechat;
        //public static ChromiumWebBrowser browser;
        public static bool isRestarted = false;

        int pTime = 300;

        /*public void InitBrowser()
        {
            //이미 크로미움은 메인 폼에서 오픈했으므로 추가로 호출하지 않는다.

            //Cef.Initialize();
            browser = new ChromiumWebBrowser("https://nolja.bizotoge.areatm.com/public/newchat/" + sdvxwin.setgame);
            browser.AddressChanged += hakobe_naru;
            
            //browser = new ChromiumWebBrowser("chrome://version");
            this.Controls.Add(browser);

            LifespanHandler life = new LifespanHandler();
            browser.LifeSpanHandler = life;

            browser.MenuHandler = new CustomMenuHandler();
            browser.Dock = DockStyle.Fill;

            if(!File.Exists("_OnelineTXT_"))
            {
                lbl_LINECUSTIOM.Visible = false;
                txt_onelinetext.Visible = false;
                btn_ok.Visible = false;
            }
        }*/

        public void ReloadStatus(bool okayd)
        {
            if (okayd) chatreload.Enabled = true;
            else chatreload.Enabled = false;
        }

        private static DateTime Delay(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }

            return DateTime.Now;
        }

        private void hakobe_naru(object sender, EventArgs e)
        {
            
        }

        public DrumChat()
        {
            //setgame = File.ReadAllText(@"nolja_game_set.txt");
            //livechat = File.ReadAllText(@"ResourceFiles\" + setgame + @"\url.otogeonpf");

            InitializeComponent();
            /*InitBrowser();*/
            
        }

        public static string GameName;

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //MessageBox.Show("");
        }

        private void SpecialNotice_Load(object sender, EventArgs e)
        {
            //webBrowser1.Navigate("https://www.youtube.com/live_chat?v=A_e6xELqjCM&is_popout=1");
            //webBrowser1.Visible = true;
            NOLJA_BlackEdition();
        }

        private void chatreload_Click(object sender, EventArgs e)
        {
            /*browser.Load("https://nolja.bizotoge.areatm.com/public/newchat/" + sdvxwin.setgame);*/
        }

        private void NOLJA_BlackEdition()
        {
            chatreload.ForeColor = sdvxwin.chinatsu_white;
            chatreload.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 255, 224, 192);

            chatreload.Font = new Font(sdvxwin.font_5_0_b.Families[0], 12f);

            //한줄문구 Font Setting
            lbl_LINECUSTIOM.Font = new Font(sdvxwin.font_5_0_b.Families[0], 10f);
            txt_onelinetext.Font = new Font(sdvxwin.font_5_0_r.Families[0], 12f);
            btn_ok.Font = new Font(sdvxwin.font_5_0_b.Families[0], 10f);
        }

        private void DrumChat_Shown(object sender, EventArgs e)
        {
            if (File.Exists("laterseechat"))
            {
                File.Delete("laterseechat");
                //chatreload.Enabled = false;
                //browser.Load("https://nolja.bizotoge.areatm.com/public/newchat/noti.php");
                //Delay(40000);
                //chatreload.Enabled = true;
                //browser.Load("https://nolja.bizotoge.areatm.com/public/newchat/" + sdvxwin.setgame);
            }
        }

        public void gono()
        {
            //browser.Load("https://nolja.bizotoge.areatm.com/public/newchat/" + sdvxwin.setgame);
            /*browser.Load("https://geki.moe/nolja/chatnotice/");*/
        }

        public void godo()
        {
            /*browser.Load("https://nolja.bizotoge.areatm.com/public/newchat/" + sdvxwin.setgame);*/

        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if(txt_onelinetext.Text == null)
            {
                if (File.Exists("_OnelineTXT_"))
                {
                    File.Delete("_OnelineTXT_");
                }
            }
            else
            {
                if (File.Exists("_OnelineTXT_"))
                {
                    File.Delete("_OnelineTXT_");
                }
                File.WriteAllText("_OnelineTXT_", (txt_onelinetext.Text));
                txt_onelinetext.Text = null;
            }
        }

        private void RestartedTimer_Tick(object sender, EventArgs e)
        {
            if (isRestarted)
            {
                if (pTime == 300)
                {
                    gono();
                    chatreload.Enabled = false;
                }

                else if (pTime <= 0)
                {
                    godo();

                    isRestarted = false;
                    chatreload.Enabled = true;

                    if((sdvxwin.setgame == "6_andamiro_pumpitup" || sdvxwin.setgame == "5_konami_sdvx") && sdvxwin._obs.GetCurrentScene().Name == "camon")
                    {
                        sdvxwin._obs.SetCurrentScene("camon_nochat");
                        Delay(600);
                        sdvxwin._obs.SetCurrentScene("camon");
                    }
                }

                pTime--;
            }
        }
    }
}
