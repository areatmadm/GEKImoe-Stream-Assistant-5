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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AreaTM_acbas
{
    public partial class NOLJA_ReStream : Form
    {
        public static int now = 0;
        public static int npow = 0;
        int npow2 = 0;
        bool thisWindowShowed = false;

        int nHour = 7;
        int nMin = 30;

        // Test용
        //int nHour = 0;
        //int nMin = 1;

        public static bool isRestarting = false;
        public static bool isRestartProcessing = false;
        public static bool isRestartProcessingFinished = true;

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

        public NOLJA_ReStream()
        {
            InitializeComponent();
        }

        private void NOLJA_ReStream_Load(object sender, EventArgs e)
        {
            //Font Settings Start
            this.Font = new Font(sdvxwin.font_5_0_r.Families[0], 12f);
            lbl_information.Font = new Font(sdvxwin.font_5_0_b.Families[0], 30f);

            lbl_restartInfo.Font = new Font(sdvxwin.font_5_0_b.Families[0], 18f);

            btn_goReStream.Font = new Font(sdvxwin.font_5_0_b.Families[0], 18f);
            btn_seelate.Font = new Font(sdvxwin.font_5_0_b.Families[0], 18f);
            //Font Settings End

            /*string N_null;
            N_null = GetHtmlString("https://nolja.bizotoge.areatm.com/public/saveload_time.php?mode=1&game=" + sdvxwin.setgame);
            int p_sdvb = 0;

            for (int i = 0; i < N_null.Length; i++)
            {
                p_sdvb = p_sdvb * 10 + (N_null[i] - '0');
            }*/

            //MessageBox.Show(now + " | " + npow + " | " + npow2);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sdvxwin.isCorrectlyStatus = true;
            try
            {
                if (sdvxwin.isFinishedTime)
                {
                    timer1.Enabled = false;
                    timer1.Stop();
                }
                if (!sdvxwin.nowRebooting)
                {
                    if (sdvxwin._obs.GetStreamingStatus().IsStreaming && sdvxwin.FirstRun_RestreamOnly && now < 20)
                    {
                        if (sdvxwin.nowStreamTime >= 20)
                        {
                            now = sdvxwin.nowStreamTime;
                            npow = sdvxwin.nowStreamTime;

                            sdvxwin.FirstRun_RestreamOnly = false;
                        }
                    }
                    else if (now >= 20 || !sdvxwin._obs.GetStreamingStatus().IsStreaming) sdvxwin.FirstRun_RestreamOnly = false;
                }
            }
            catch
            {
                timer1.Enabled = false;
                try { sdvxwin._obs.Disconnect(); } catch { } //연결해제 확실히 확인하는 용도

                //OBS 강제 종료(프로세스 유지 여부 확인)
                Thread.Sleep(500); //정상 종료 했는데 강제종료 판단 방지를 위함.
                Process killtask1 = new Process();
                killtask1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden; //일단 창 생성 없이 구동
                killtask1.StartInfo.FileName = @"C:\Windows\system32\taskkill.exe";
                killtask1.StartInfo.Arguments = "/f /im obs64.exe";
                try { killtask1.Start(); } catch { }

                Thread.Sleep(1500);

                //안전모드 활성화 여부 확인 후 활성화 되어있다면 안전 모드 제외
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\obs-studio\safe_mode")) //Find safemode enable status
                {
                    try { File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\obs-studio\safe_mode"); } catch { }//do not run safe mode
                }

                //OBS 다시 시작
                Process findOBS = new Process();
                if (File.Exists(@"C:\Program Files\obs-studio\bin\64bit\obs64.exe"))
                {
                    findOBS.StartInfo.FileName = @"C:\Program Files\obs-studio\bin\64bit\obs64.exe";
                    findOBS.StartInfo.WorkingDirectory = @"C:\Program Files\obs-studio\bin\64bit\";
                    findOBS.Start();
                }
                else if (File.Exists(@"C:\Program Files\obs-studio\bin\32bit\obs32.exe"))
                {
                    findOBS.StartInfo.FileName = @"C:\Program Files\obs-studio\bin\32bit\obs32.exe";
                    findOBS.StartInfo.WorkingDirectory = @"C:\Program Files\obs-studio\bin\32bit\";
                    findOBS.Start();
                }
                else if (File.Exists(@"C:\Program Files (x86)\obs-studio\bin\64bit\obs64.exe"))
                {
                    findOBS.StartInfo.FileName = @"C:\Program Files (x86)\obs-studio\bin\64bit\obs64.exe";
                    findOBS.StartInfo.WorkingDirectory = @"C:\Program Files (x86)\obs-studio\bin\64bit\";
                    findOBS.Start();
                }
                else if (File.Exists(@"C:\Program Files (x86)\obs-studio\bin\32bit\obs32.exe"))
                {
                    findOBS.StartInfo.FileName = @"C:\Program Files (x86)\obs-studio\bin\32bit\obs32.exe";
                    findOBS.StartInfo.WorkingDirectory = @"C:\Program Files (x86)\obs-studio\bin\32bit\";
                    findOBS.Start();
                }
                else
                {
                    
                }

                //10초 대기 후 다시 접속
                Thread.Sleep(10000);
                if (File.Exists("test")) sdvxwin._obs.Connect("ws://127.0.0.1:7849", "noljabroadcastpc");
                else sdvxwin._obs.Connect("ws://127.0.0.1:4444", "noljabroadcastpc");

                timer1.Enabled = true;
            }


            string ifhour = "";
            if (npow >= 3600) ifhour = ((npow / 60) / 60) + "시간 " + ((npow / 60) % 60) + "분 ";
            else ifhour = (npow / 60) + "분 ";

            if (!isRestarting)
            {
                if ((((((npow / 60) / 60) >= nHour && ((npow / 60) % 60) >= nMin) || ((npow / 60) / 60) >= 10)))
                //7시간 30분, 8시간 30분, 9시간 30분, 10시간 30분에 알림
                //PLIVE Mirroring 폼 닫혀 있을때만 동작
                {
                    lbl_restartInfo.Text = (59 - ((npow / 60) % 60)) + "분 " + (59 - (npow % 60)) + "초 이후 자동으로 재시작 됩니다.";

                    if (thisWindowShowed == false && VIDEO_on.isupdate == false && sdvxwin.banneduser == false) //창이 안 열려 있을 때
                    {
                        thisWindowShowed = true;
                        btn_goReStream.Enabled = true;

                        if (((npow / 60) / 60) >= 10) btn_seelate.Enabled = false; //10시간 30분 이후부터 비활성화 불가
                        else btn_seelate.Enabled = true;

                        this.Show();
                        this.Focus();
                    }

                    else if(thisWindowShowed == true && (VIDEO_on.isupdate == true || sdvxwin.banneduser == true)) //창은 열려 있으나 업데이트가 떳을 경우
                    {
                        thisWindowShowed = false;
                        this.Hide();
                    }

                    else if (thisWindowShowed && (59 - ((npow / 60) % 60)) == 0 && (59 - (npow % 60)) == 0) //창이 열려 있으며, 카운트가 다 된 경우
                    {
                        isRestarting = true;
                    }
                }

                //Timer Tick 보정
                if (!isRestarting && sdvxwin._obs.GetStreamingStatus().IsStreaming)
                {
                    now++;
                    // now+=50; //테스트용
                    npow = now / 1;
                    npow2 = 0;
                }
                else if (!isRestarting && !sdvxwin._obs.GetStreamingStatus().IsStreaming) //스트리밍을 잠깐 껏는지 확인하는 용도
                {
                    if (npow2 == 0) npow2 = npow;
                    else if (npow2 == (npow - 120)) isRestarting = true;

                    now++;
                    npow = now / 1;
                }
            }
            else if (!isRestartProcessingFinished)
            {
                isRestarting = false;
                isRestartProcessing = false;
                isRestartProcessingFinished = true;
                //DrumChat.isRestarted = true;

                thisWindowShowed = false;
                this.Hide();
            }
            else //방송 리방 프로세스 가동
            {
                btn_goReStream.Enabled = false;
                btn_seelate.Enabled = false;

                if (!thisWindowShowed) //창 안보일 때
                {
                    this.Show();
                    thisWindowShowed = true;
                }

                lbl_restartInfo.Text = "리방 시작 중입니다...";
                now = 0;
                npow = 0;
                npow2 = 0;

                if (!isRestartProcessing)
                {
                    Thread StreamingTimeChk = new Thread(ReStreaming);
                    StreamingTimeChk.SetApartmentState(ApartmentState.STA);
                    Control.CheckForIllegalCrossThreadCalls = false;
                    StreamingTimeChk.Start();

                    isRestartProcessing = true;
                }
            }
        }

        private void btn_seelate_Click(object sender, EventArgs e)
        {
            thisWindowShowed = false;
            this.Hide();
            nHour++;
        }

        private void btn_goReStream_Click(object sender, EventArgs e)
        {
            btn_goReStream.Enabled = false;
            btn_seelate.Enabled = false;
            lbl_restartInfo.Text = "리방 시작 중입니다...";

            isRestarting = true;
        }

        void ReStreaming()
        {
            string getp;
            try
            {
                sdvxwin._obs.StopStreaming();
                sdvxwin.isRestreaming_onlyCheckStatus = true;
                Thread.Sleep(200);
            }
            catch { }
            this.TopMost = false; //일시적으로 맨 위로 해제
            while (true) //방송이 제대로 꺼졌는지 확인하는 스크립트
            {
                if (!sdvxwin.isNowStream) { break; }
                else { Thread.Sleep(100); }
            }
            lbl_restartInfo.Text = "리방 진행 중입니다...";
            if (!File.Exists("test"))
            {
                getp = GetHtmlString("https://service.stream-assistant-5.gekimoe.areatm.com/public/serverstatus?vender=" + sdvxwin.vender + "&game=" + sdvxwin.setgame +
                        "&mode=4&submode=4");
                //GSA 서버로 리방 사실을 전송
            }
            Thread.Sleep(50000); //50초 뒤 다시 방송 시작

            VIDEO_on.isWakeOn = true; // 리방 오류 방지 기능으로 작동

            try { sdvxwin._obs.StartStreaming(); } catch { } // 스트리밍 다시 시작

            Thread.Sleep(1100);

            if (!File.Exists("test")) getp = GetHtmlString("https://service.stream-assistant-5.gekimoe.areatm.com/public/serverstatus?vender=" + sdvxwin.vender + "&game=" + sdvxwin.setgame +
                        "&mode=0");
            VIDEO_on.isWakeOn = false;

            sdvxwin.isRestreaming_onlyCheckStatus = false;
            isRestartProcessingFinished = false;
            this.TopMost = true; //다시 맨 위로 적용
        }

        private void NOLJA_ReStream_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }

        public static void ChkIfStreamisNeedRestart()
        {
            if (((npow / 60) / 60) >= 11) isRestarting = true;
            else try { sdvxwin._obs.StartStreaming(); } catch { }
        }

        public static void ChkIfStreamisNeedRestart2()
        {
            if (((npow / 60) / 60) >= 8) isRestarting = true;
            else try { sdvxwin._obs.StartStreaming(); } catch { }
        }

        public static void NowRestart()
        {
            isRestarting = true;
        }
    }
}
