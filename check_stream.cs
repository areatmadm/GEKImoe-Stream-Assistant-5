using Newtonsoft.Json.Linq;
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
    public partial class check_stream : Form
    {
        DrumChat chatwin;

        public check_stream()
        {
            InitializeComponent();
        }

        public check_stream(DrumChat drchat)
        {
            chatwin = drchat;
            InitializeComponent();
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

        private void check_stream_Load(object sender, EventArgs e)
        {
            

        }

        private void check_stream_Shown(object sender, EventArgs e)
        {
            this.Hide();

            chatwin.ReloadStatus(false);

            timer1.Interval = 300000;
            //timer1.Interval = 30000; //테스트용
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Enabled = true;

            Delay(5000);
            if (File.Exists("already_stream"))
            {
                File.Delete("already_stream");
                chatwin.ReloadStatus(true);
                timer1.Enabled = false;
                this.Close();
            }
            else
            {
                chatwin.gono();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            /*string chk = GetHtmlString("https://nolja.bizotoge.areatm.com/public/newchat/" + sdvxwin.setgame + "/checklive.php");
            if (chk == "error")
            {
                //MessageBox.Show("Err");
                try { sdvxwin._obs.StopStreaming(); } catch { }
                Delay(10000);
                try { sdvxwin._obs.StartStreaming(); } catch { }
                if (timer1.Interval <= 30000) timer1.Interval = 210000;
                else timer1.Interval -= 15000;

                timer1.Enabled = true;
            }
            else
            {*/
            chatwin.godo();
            chatwin.ReloadStatus(true);

            //채팅창이 obs화면에 포함된 게임만 해당 start
            //채팅창이 obs화면에 포함된 게임에서 채팅창 리로드
            if ((sdvxwin.setgame == "5_konami_sdvx" || sdvxwin.setgame == "6_andamiro_pumpitup") && sdvxwin._obs.GetCurrentScene().Name == "camon")
            {
                try
                {
                    sdvxwin._obs.SetCurrentScene("camon_nochat"); //camon 상에서의 채팅창 none 표시
                    Delay(1000);
                    sdvxwin._obs.SetCurrentScene("camon");
                }
                catch { }
            }
            else if (sdvxwin.setgame == "6_andamiro_pumpitup" && sdvxwin._obs.GetCurrentScene().Name == "mod_0")
            {
                try
                {
                    sdvxwin._obs.SetCurrentScene("mod_0_nochat"); //펌프 캠OFF 채팅ON 상에서의 채팅창 none 표시
                    Delay(1000);
                    sdvxwin._obs.SetCurrentScene("mod_0");
                }
                catch { }
            }
            //채팅창이 포함된 게임만 해당 end

            Delay(200);
            this.Close();
            //}
        }

        private void WaitChat()
        {

        }
    }
}
