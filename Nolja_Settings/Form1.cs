using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Drawing.Text;
using System.Net;

namespace GEKImoeStreamAssistant5FixReboot
{
    public partial class Nolja_ErrorFix : Form
    {
        int quick = 30;
        int qtemp;

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

        public static string PostHtmlString(string url, String[] postDataKey, String[] postDataValue) //POST 전송에 필요한 데이터 수집
        {
            try
            {

                String callUrl = url;
                //String[] data = new String[1];

                String postDataToSend = null;
                for (int i = 0; i < postDataKey.Length; i++) //값 전달할 key 전달
                {
                    if (i > 0) postDataToSend += "&";
                    postDataToSend += postDataKey[i];
                    postDataToSend += "=";
                    postDataToSend += postDataValue[i];
                }

                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(callUrl);

                //인코딩 UTF-8
                byte[] sendData = UTF8Encoding.UTF8.GetBytes(postDataToSend);
                httpWebRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                httpWebRequest.Method = "POST";
                httpWebRequest.ContentLength = sendData.Length;

                Stream requestStream = httpWebRequest.GetRequestStream();
                requestStream.Write(sendData, 0, sendData.Length);
                requestStream.Close();

                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
                String response = streamReader.ReadToEnd();

                streamReader.Close();
                httpWebResponse.Close();

                return response;
            }
            catch
            {
                return "__Error__";
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

        public Nolja_ErrorFix()
        {
            InitializeComponent();
        }

        private void NoljaStreamingSelect_Load(object sender, EventArgs e)
        {
            PrivateFontCollection font_3_0_s = new PrivateFontCollection();
            string fix_nfd;
            //fix_nfd = System.IO.Path.GetFullPath("font_3.0").Replace(@"Bugfix\", "");
            fix_nfd = System.IO.Path.GetFullPath("font_3.0").Replace(@"Debug\", "");
            //MessageBox.Show(fix_nfd);
            font_3_0_s.AddFontFile(fix_nfd + @"\nanum-barun-gothic\NanumBarunGothicBold.otf");
            font_3_0_s.AddFontFile(fix_nfd + @"\nanum-barun-gothic\NanumBarunGothic.otf");

            this.Font = new Font(font_3_0_s.Families[0], 18f, FontStyle.Bold);
            label1.Font = new Font(font_3_0_s.Families[0], 14f);
            lbl_name.Font = new Font(font_3_0_s.Families[0], 22f, FontStyle.Bold);

            //timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Enabled = false;
        }

        private void btn_fix_Click(object sender, EventArgs e)
        {
            btn_fix.Enabled = false;
            btn_exit.Enabled = false;

            //Process.Start("nolja_fix_pp.vbs"); //SW 강종 코드
            Delay(6000);

            string noll;
            string setgame = "";
            string vender = "";
            /*if (File.Exists(Path.GetFullPath("nolja_game_set.txt").Replace(@"Bugfix\", ""))) //놀자 독자규격 사용 시
            {
                setgame = File.ReadAllText(Path.GetFullPath("nolja_game_set.txt").Replace(@"Bugfix\", ""));
            }
            else //표준규격 사용 업장
            {
                setgame = File.ReadAllText(Path.GetFullPath("game_set.txt").Replace(@"Bugfix\", ""));
            }*/
            //표준규격 단일화로 인한 코드 제거 진행 중(Ver.5.17부터 적용)

            setgame = File.ReadAllText(Path.GetFullPath("game_set.txt").Replace(@"Bugfix\", ""));

            if (File.Exists(Path.GetFullPath("vender.txt").Replace(@"Bugfix\", ""))) vender = File.ReadAllText(Path.GetFullPath("vender.txt").Replace(@"Bugfix\", ""));
            else vender = "NOLJA";

            if (File.Exists(Path.GetFullPath("nolja_game_set.txt").Replace(@"Bugfix\", ""))) //놀자는 독자적인 도메인 이용
            {
                noll = GetHtmlString("https://nolja.bizotoge.areatm.com/public/serverstatus?mode=4&submode=5&game=" + setgame);
            }
            else // 그 외에는 표준규격 사용
            {
                noll = GetHtmlString("https://service.stream-assistant-5.gekimoe.areatm.com/public/serverstatus?vender=" + vender + "mode=4&submode=5&game=" + setgame);
            }
            
            Delay(1000);

            lbl_name.Text = "GEKImoe Stream Assistant 재시작 요청됨";
            timer1.Enabled = true;
            label1.Text = "30초 후 스트리밍을 재시작합니다.";
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            quick--;
            qtemp = quick / 2;

            if (qtemp >= 60)
            {
                label1.Text = (qtemp / 60) + "분 " + (qtemp % 60) + "초 후 재시작합니다.";
            }
            else label1.Text = qtemp + "초 후 재시작합니다.";

            if (qtemp < 0)
            {
                label1.Text = "재시작을 진행합니다...";
                timer1.Enabled = false;
                Delay(2000);
                //if(File.Exists(Path.GetFullPath))
                //Process.Start(@"nolja_reboot.vbs");
            }

            //label1.Text = "3분 30초 후 재부팅을 시작합니다.";
        }

        private void btn_fix_EnabledChanged(object sender, EventArgs e)
        {
            if (btn_fix.Enabled) btn_fix.BackColor = Color.FromArgb(32, 32, 32);
            else btn_fix.BackColor = Color.FromArgb(200, 200, 200);
        }

        private void btn_exit_EnabledChanged(object sender, EventArgs e)
        {
            if (btn_exit.Enabled) btn_exit.BackColor = Color.FromArgb(32, 32, 32);
            else btn_exit.BackColor = Color.FromArgb(200, 200, 200);
        }
    }
}
