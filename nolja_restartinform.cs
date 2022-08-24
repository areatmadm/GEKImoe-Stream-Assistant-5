using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AreaTM_acbas
{
    public partial class nolja_restartinform : Form
    {
        public static int quick = 600;
        int qtemp;

        public ChromiumWebBrowser updinform = new ChromiumWebBrowser();

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

        public nolja_restartinform()
        {
            InitializeComponent();
        }

        private void nolja_restartinform_Load(object sender, EventArgs e)
        {
            this.Font = new Font(sdvxwin.font_5_0_r.Families[0], 15f);
            lbl_name.Font = new Font(sdvxwin.font_5_0_b.Families[0], 25f);
            btn_update.Font = new Font(sdvxwin.font_5_0_b.Families[0], 18f);
            btn_resettime.Font = new Font(sdvxwin.font_5_0_b.Families[0], 18f);

            updinform.Load("https://nolja.bizotoge.areatm.com/public/updatecheck/info");
            updinform.Dock = DockStyle.None;
            updinform.Size = browserarea.Size;
            updinform.Location = browserarea.Location;

            LifespanHandler life = new LifespanHandler();
            updinform.LifeSpanHandler = life;

            updinform.MenuHandler = new CustomMenuHandler();

            this.Controls.Remove(browserarea);
            this.Controls.Add(updinform);
            
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Enabled = false;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            goUpdate();
        }

        private void nolja_restartinform_Shown(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void nolja_restartinform_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            quick--;

            if (sdvxwin.isrecordmod) quick = 600;
            qtemp = quick / 2;

            if (qtemp >= 60)
            {
                lbl_timer.Text = (qtemp / 60) + "분 " + (qtemp % 60) + "초 이후 어시스턴트 업데이트를 진행합니다." + "\r\n" +
                                    "업데이트 중에는 어시스턴트 사용이 불가합니다.";
            }
            else lbl_timer.Text = qtemp + "초 이후 어시스턴트 업데이트를 진행합니다." + "\r\n" +
                                    "업데이트 중에는 어시스턴트 사용이 불가합니다.";

            if (qtemp < 0)
            {
                goUpdate();
            }
        }

        private void btn_resettime_Click(object sender, EventArgs e)
        {
            quick = 600;
            timer1.Enabled = false;

            lbl_timer.Text = (quick / 120) + "분 " + (quick % 120) + "초 이후 어시스턴트 업데이트를 진행합니다." + "\r\n" +
                                    "업데이트 중에는 어시스턴트 사용이 불가합니다.";
            timer1.Enabled = true;
        }

        private void goUpdate()
        {
            lbl_timer.Text = "어시스턴트 업데이트 진행...";
            timer1.Enabled = false;
            btn_resettime.Enabled = false;
            btn_resettime.BackColor = sdvxwin.chinatsu_disabled;
            btn_update.Enabled = false;
            btn_update.BackColor = sdvxwin.chinatsu_disabled;

            Delay(2000);

            Process[] processifusenjbtmpcht = Process.GetProcessesByName("Nolja_OpenUp");
            if (processifusenjbtmpcht.Length >= 1)
            {
                for (int i = 0; i < processifusenjbtmpcht.Length; i++)
                {
                    processifusenjbtmpcht[i].Kill();
                }
                /*
                string pvd = "taskkill /f /im Nolja_OpenUp.exe" + "\r\n";
                pvd += "taskkill /f /im AreaTM_IoT.exe";
                string pve = "";
                pve += "Set WshShell = CreateObject (\"WScript.shell\")" + "\r\n";
                pve += "Dim strArgs" + "\r\n";
                pve += "strArgs = \"NOLJA_TaskKill.bat\"" + "\r\n";
                pve += "WshShell.Run strArgs, 0, false";

                File.WriteAllText("NOLJA_TaskKill.bat", pvd);
                File.WriteAllText("start.vbs", pve);

                Delay(500);
                Process.Start("start.vbs");
                Delay(1500);

                File.Delete("chromium_taskkill.bat");
                File.Delete("start.vbs");*/
                Delay(200);
            }

            if (!File.Exists("test"))
            {
                String N_null;
                N_null = GetHtmlString("https://nolja.bizotoge.areatm.com/public/serverstatus?mode=4&submode=0&game=" + sdvxwin.setgame);
            }

            Process[] processifusenjbtmpcht2 = Process.GetProcessesByName("AreaTM_IoT");
            if (processifusenjbtmpcht2.Length >= 1)
            {
                for(int i=0; i<processifusenjbtmpcht2.Length; i++)
                {
                    processifusenjbtmpcht2[i].Kill();
                }
                Delay(200);
            }

            Process.Start("NoljaUpdater.exe");
            //Application.ExitThread();

            Process killtask2 = new Process();
            killtask2.StartInfo.FileName = @"C:\Windows\SysWOW64\taskkill.exe";
            killtask2.StartInfo.Arguments = "/f /im AreaTM_acbas.exe";
            try { killtask2.Start(); } catch { }
        }
    }
}
