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

using NAudio;
using NAudio.Wave;

namespace AreaTM_acbas
{
    public partial class maintaince_check : Form
    {
        public static bool isopen = false;
        public static bool isupd = false;
        public static bool isupd_rtmp = false;
        public static bool chinatsu_html_yt_enabled = false;

        public static int value_hour = 0;
        public static int value_min = 0;
        public static int value_sec = 0;

        int ppd_e = 0;

        bool isnownetconnected = true;
        bool isexploreropened = true;

        int rechecktime = 10000;

        float level;

        sdvxwin mainform;
        DrumChat chatform;
        VIDEO_on vdfrm;

        Process[] killProcess;

        public static string isupd_ver = "";

        public static bool ischeckone = false;

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

        private static string PostHtmlString2(string url, String[] postDataKey, String[] postDataValue) //POST 전송에 필요한 데이터 수집
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

        public maintaince_check()
        {
            InitializeComponent();
        }
        public maintaince_check(sdvxwin mainfrm)
        {
            InitializeComponent();
            mainform = mainfrm;
        }
        public maintaince_check(sdvxwin mainfrm, VIDEO_on vdon)
        {
            InitializeComponent();
            mainform = mainfrm;
            vdfrm = vdon;
        }
        /*public maintaince_check(sdvxwin mainfrm, VIDEO_on vdon, DrumChat chtfrm)
        {
            InitializeComponent();
            mainform = mainfrm;
            vdfrm = vdon;
            chatform = chtfrm;
        }*/

        private void maintaince_check_Load(object sender, EventArgs e)
        {

        }

        private void maintaince_check_Shown(object sender, EventArgs e)
        {
            this.Hide();
            Thread NetStatus = new Thread(ChkNetStatus);
            NetStatus.SetApartmentState(ApartmentState.STA);
            NetStatus.Start();

            //Thread BanStatus = new Thread(ChkIfBanned);
            //BanStatus.SetApartmentState(ApartmentState.STA);
            //Control.CheckForIllegalCrossThreadCalls = false;
            //BanStatus.Start();

            Thread OBSStatus1 = new Thread(ChkOBSisFine1);
            OBSStatus1.SetApartmentState(ApartmentState.STA);
            OBSStatus1.Start();

            Thread tChkTimeAndReboot = new Thread(ChkTimeAndReboot);
            tChkTimeAndReboot.SetApartmentState(ApartmentState.STA);
            tChkTimeAndReboot.Start();

            // FFmpeg 잘 실행중인지 체크하는 별도 스레드 생성
            /*Thread ffmpegStatus1 = new Thread(chkFFmpegisFine1);
            ffmpegStatus1.SetApartmentState(ApartmentState.STA);
            ffmpegStatus1.Start();*/

            /* var waveIn = new NAudio.Wave.WaveInEvent();
            waveIn.DeviceNumber = 0;
            waveIn.WaveFormat = new NAudio.Wave.WaveFormat(16000, 1);
            waveIn.DataAvailable += WaveIn_DataAvailable;
            waveIn.StartRecording();

            if (sdvxwin.setgame == "0_sega_maimaidx")
            {
                Thread StreamingTimeChk = new Thread(ChkStreamingTime);
                StreamingTimeChk.SetApartmentState(ApartmentState.STA);
                Control.CheckForIllegalCrossThreadCalls = false;
                StreamingTimeChk.Start();
            } */

            MTick();

            //Thread MTick_TR = new Thread(MTick_Thread);
            //MTick_TR.SetApartmentState(ApartmentState.STA);
            //Control.CheckForIllegalCrossThreadCalls = false;
            //MTick_TR.Start();

            timer1.Interval = 90000;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MTick();
        }

        private void MTick_Thread()
        {
            while (true)
            {
                if(ischeckone) Thread.Sleep(90000);
                MTick();
            }
        }

        private void ChkNetStatus()
        {
            string[] postStringKey;
            string[] postStringValue;

            if (File.Exists("test")) { }
            else
            {
                while (true)
                {
                    Thread.Sleep(rechecktime);
                    string getp = "";
                    if (!sdvxwin.isRestreaming_onlyCheckStatus)
                    {
                        postStringKey = new string[3]; postStringValue = new string[3]; //보낼 키값 초기화
                        postStringKey[0] = "mode"; postStringValue[0] = "0"; //mode
                        postStringKey[1] = "vender"; postStringValue[1] = sdvxwin.vender; // key_vender
                        postStringKey[2] = "game"; postStringValue[2] = sdvxwin.setgame; //game
                        getp = PostHtmlString2("https://service.stream-assistant-5.gekimoe.areatm.com/v2/serverstatus/v1/", postStringKey, postStringValue);
                        //getp = GetHtmlString("https://service.stream-assistant-5.gekimoe.areatm.com/public/serverstatus?vender=" + sdvxwin.vender + "&game=" + sdvxwin.setgame + "&mode=0");
                    }

                    if (getp == "Success")
                    {
                        rechecktime = 90000;
                        isnownetconnected = true;

                        /*if (sdvxwin.isFinishedTime)
                        {
                            string getmpp = GetHtmlString("https://service.stream-assistant-5.gekimoe.areatm.com/public/serverstatus?vender=" + sdvxwin.vender + "&mode=3&submode=2&game=" + sdvxwin.setgame);
                            if (getmpp == "TodayGameEnded")
                            {
                                try { sdvxwin._obs.StopStreaming(); } catch { }
                                sdvxwin.isFinishedTime = true;

                                
                            }
                        }*/
                    }

                    else
                    {
                        rechecktime = 10000;
                        isnownetconnected = false;
                    }
                }
            }
        }

        //OBS 정상작동 상태 확인

        private void ChkOBSisFine1()
        {
            string[] postStringKey;
            string[] postStringValue;

            while (true)
            {
                if (ppd_e == 3)
                {
                    sdvxwin.nowRebooting = true;

                    string pvd;
                    pvd = "taskkill /f /im obs64.exe" + "\r\n";
                    pvd += "taskkill /f /im AreaTM_acbas.exe" + "\r\n";
                    pvd += "taskkill /f /im AreaTM_IoT.exe" + "\r\n";
                    pvd += "taskkill /f /im chrome.exe" + "\r\n";
                    pvd += "taskkill /f /im whale.exe" + "\r\n";
                    pvd += "taskkill /f /im itunes.exe" + "\r\n";
                    pvd += "shutdown -r -t 0" + "\r\n";

                    string pve = "";
                    pve += "Set WshShell = CreateObject (\"WScript.shell\")" + "\r\n";
                    pve += "Dim strArgs" + "\r\n";
                    pve += "strArgs = \"restart_pc.bat\"" + "\r\n";
                    pve += "WshShell.Run strArgs, 0, false";

                    string noll;
                    //noll = GetHtmlString("https://service.stream-assistant-5.gekimoe.areatm.com/public/serverstatus?vender=" + sdvxwin.vender + "&mode=4&submode=5&game=" + sdvxwin.setgame);
                    postStringKey = new string[4]; postStringValue = new string[4]; //보낼 키값 초기화
                    postStringKey[0] = "mode"; postStringValue[0] = "4"; //mode
                    postStringKey[1] = "submode"; postStringValue[1] = "5"; //mode
                    postStringKey[2] = "vender"; postStringValue[2] = sdvxwin.vender; // key_vender
                    postStringKey[3] = "game"; postStringValue[3] = sdvxwin.setgame; //game
                    noll = PostHtmlString2("https://service.stream-assistant-5.gekimoe.areatm.com/v2/serverstatus/v1/", postStringKey, postStringValue);

                    File.WriteAllText("restart_pc.bat", pvd);
                    File.WriteAllText("restart_pc.vbs", pve);
                    Thread.Sleep(500);
                    Process.Start("restart_pc.vbs");

                    //Process rebooting = new Process();
                    //rebooting.StartInfo.FileName = @"C:\Windows\SysWOW64\shutdown.exe";
                    //rebooting.StartInfo.Arguments = "-r -t 0";
                    //try { rebooting.Start(); } catch { }
                    ppd_e = 0;
                }

                if (sdvxwin.isCorrectlyStatus)
                {
                    ppd_e = 0;
                    sdvxwin.isCorrectlyStatus = false;
                }

                else { ppd_e++; }
                Thread.Sleep(22000);
            }
        }

        /*private void chkFFmpegisFine1() //스트리밍 중 FFmpeg가 잘 살아있는지 체크
        {
            while (true)
            {
                OBSWebsocketDotNet.OutputStatus getStreamStatus = sdvxwin._obs.GetStreamingStatus();
                if (getStreamStatus.IsStreaming)
                {
                    Process[] checkFFmpeg = Process.GetProcessesByName("ffmpeg");
                    if (checkFFmpeg.Length < 1) //안살아있다면
                    {
                        for(int i=0; i<11; i++) //10초간 체크
                        {
                            Thread.Sleep(1000);
                            if (checkFFmpeg.Length >= 1) break; //살아있으면 패스
                            else if (i == 10) { sdvxwin.startFFmpeg.Start(); break; } //죽어있으면 강제 재실행
                        }
                    }
                    Thread.Sleep(10000); //10초마다 한번씩 실행
                }
            }
        }*/

        /*private void ChkIfBanned()
        {
            while (true)
            {
                if (isnownetconnected)
                {
                    string getp = "";
                    getp = GetHtmlString("https://nolja.bizotoge.areatm.com/public/serverstatus?game=" + sdvxwin.setgame +
                        "&mode=4&submode=3");
                    if (getp == "NowBanned")
                    {
                        sdvxwin.banneduser = true;
                        VIDEO_on.ChangeVol(2);

                        if (isexploreropened)
                        {
                            isexploreropened = false;
                            Process killtask = new Process();
                            killtask.StartInfo.FileName = @"C:\Windows\SysWOW64\taskkill.exe";
                            killtask.StartInfo.Arguments = "/f /im explorer.exe";
                            try { killtask.Start(); } catch { }
                        }
                        //rechecktime = 15000;
                    }
                    else
                    {
                        if(sdvxwin.banneduser) VIDEO_on.isWakeOn = true;

                        sdvxwin.banneduser = false;
                        if (!isexploreropened)
                        {
                            isexploreropened = true;
                            Process killtask = new Process();
                            killtask.StartInfo.FileName = @"C:\Windows\explorer.exe";
                            try { killtask.Start(); } catch { }
                        }
                    }
                }
                Thread.Sleep(20000);
            }
        }*/

        /* private void ChkStreamingTime()
        {
            //chk streaming time

            while (true)
            {
                try
                {
                    if (sdvxwin._obs.GetStreamingStatus().IsStreaming)
                    {
                        value_sec += 1;

                        if (value_sec == 60)
                        {
                            value_min += 1;
                            value_sec = 0;

                            if (value_min == 60)
                            {
                                value_hour += 1;
                                value_min = 0;
                            }
                        }

                        if (value_hour > 7)
                        //if (value_min > 1)
                        {
                            bool isrestart = false;
                            int value_chksec = 0;

                            while (true)
                            {
                                int dbget = Convert.ToInt32(level);
                                if ((dbget > 10 || sdvxwin.streamstatus) && value_hour < 10) value_chksec = 0;
                                else
                                {
                                    value_chksec += 1;
                                    if (value_chksec > 40 || value_hour >= 10)
                                    {
                                        try { sdvxwin._obs.StopStreaming(); } catch { }
                                        Thread.Sleep(120000);

                                        if (File.Exists(@"chromium\chromium.exe"))
                                        {
                                            Process chr = new Process();
                                            string pm = "https://studio.youtube.com/channel/UC/livestreaming";

                                            chr.StartInfo.FileName = System.IO.Path.GetFullPath("chromium") + @"\chromium.exe";
                                            chr.StartInfo.Arguments = pm;
                                            chr.Start();

                                            Thread.Sleep(29000);
                                            string pvd = "taskkill /f /im chromium.exe";
                                            File.WriteAllText("chromium_taskkill.bat", pvd);
                                            Thread.Sleep(500);
                                            Process.Start("chromium_taskkill.bat");
                                            Thread.Sleep(1500);
                                            File.Delete("chromium_taskkill.bat");

                                            try { sdvxwin._obs.StartStreaming(); } catch { }

                                            isrestart = true;

                                            DrumChat.isRestarted = true;
                                            break;
                                        }
                                    }
                                }

                                value_sec += 1;

                                if (value_sec == 60)
                                {
                                    value_min += 1;
                                    value_sec = 0;

                                    if (value_min == 60)
                                    {
                                        value_hour += 1;
                                        value_min = 0;
                                    }
                                }

                                Thread.Sleep(1000);
                            }

                            if (isrestart) break;
                        }
                    }

                    else break;
                }
                catch
                {
                    break;
                }

                Thread.Sleep(1000);
            }
        }

        private void WaveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            //if (isRecording)
            //{
            //    writer.Write(args.Buffer, 0, args.BytesRecorded);
            //}

            float max = 0;
            // interpret as 16 bit audio
            for (int index = 0; index < e.BytesRecorded; index += 2)
            {
                short sample = (short)((e.Buffer[index + 1] << 8) |
                                        e.Buffer[index + 0]);
                // to floating point
                var sample32 = sample / 32768f;
                // absolute value 
                if (sample32 < 0) sample32 = -sample32;
                // is this the max value?
                if (sample32 > max) max = sample32;
            }
            level = 100 * max;
            this.Invoke(new Action(
                 delegate ()
                 {
                     //MessageBox.Show(Convert.ToInt32(level) + "");
                 }));
        } */

        private void ChkTimeAndReboot()//리부팅 시간 되었을 때 강제 리부팅 조치하도록 함
        {
            if((System.DateTime.Now.Hour == 5 && System.DateTime.Now.Minute >= 20) || (System.DateTime.Now.Hour == 6 && System.DateTime.Now.Minute <= 58)) 
            { //매일 05:20 ~ 06:58 리부팅 강제 시간
                Process rebootAutoTime = new Process();//05:20 자동 재부팅
                rebootAutoTime.StartInfo.FileName = @"C:\Windows\system32\shutdown.exe";
                rebootAutoTime.StartInfo.Arguments = "-r -t 10";
                rebootAutoTime.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                rebootAutoTime.Start();

                Delay(100);
                Process killOBS = new Process();//GEKImoe Stream Assistant 강제 종료
                killOBS.StartInfo.FileName = @"C:\Windows\system32\taskkill.exe";
                killOBS.StartInfo.Arguments = "/f /im AreaTM_acbas.exe";
                killOBS.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                killOBS.Start();

                //OBS 강제 종료
                killOBS.StartInfo.Arguments = "/f /im obs64.exe";
                killOBS.Start();
            }
            Delay(1000);
        }

        private void MTick()
        {
            string getp = "";
            if (!isopen)
            {
                getp = GetHtmlString("https://service.stream-assistant-5.gekimoe.areatm.com/public/maintance_old.php?ngame=" + sdvxwin.setgame +
                    "&build=" + sdvxwin.nolja_build);
            }
            //https://nolja.bizotoge.areatm.com/public/maintance_old.php?ngame=0_sega_maimaidx
            if (getp == "1")
            {
                isopen = true;
                string url_g = GetHtmlString("https://service.stream-assistant-5.gekimoe.areatm.com/public/maintance?ngame=" + sdvxwin.setgame + "&build=" + sdvxwin.nolja_build);
                Form openform = new maintance_win(url_g);
                openform.Show();

                //this.Close();
            }

            getp = "";
            if (!isupd && !sdvxwin.isrecordmod && !sdvxwin.streamstatus && !ischeckone)
            {
                if (!File.Exists("error_update"))
                {
                    getp = GetHtmlString("https://streamassistant.sv.gekimoe.areatm.com/updatecheck/" + sdvxwin.nolja_partnum + "?mod=1&ver=" + sdvxwin.nolja_build);
                    if (getp == "1")
                    {
                        VIDEO_on.isupdate = true;
                        isupd = true;
                        if (!ischeckone)
                        {
                            mainform.Hide();

                            if (chatform != null) chatform.Hide();
                            else
                            {
                                Process[] processifusenjbtmpcht = Process.GetProcessesByName("Nolja_OpenUp");
                                if (processifusenjbtmpcht.Length >= 1)
                                {
                                    Process killtask = new Process();
                                    killtask.StartInfo.FileName = @"C:\Windows\SysWOW64\taskkill.exe";
                                    killtask.StartInfo.Arguments = "/f /im Nolja_OpenUp.exe";
                                    try { killtask.Start(); } catch { }
                                    //C:\Windows\SysWOW64\taskkill.exe /f /im Nolja_OpenUp.exe
                                    Delay(200);
                                }
                            }
                        }
                        mainform.openupdate_njb();
                    }
                    else ischeckone = true;
                }
            }
            getp = "";

            if (!isupd) //AreaTM IoT
            {
                getp = GetHtmlString("https://service.stream-assistant-5.gekimoe.areatm.com/public/areatm_iot?game=" + sdvxwin.setgame +
                    "&mode=1");

                if (getp == "1" && !sdvxwin.AreaTM_IoT)
                {
                    sdvxwin.AreaTM_IoT = true;

                    killProcess = Process.GetProcessesByName("AreaTM_IoT");
                    if (killProcess.Length >= 1)
                    {
                        for (int i = 0; i < killProcess.Length; i++)
                        {
                            killProcess[i].Kill();
                        }
                        Delay(100);
                    }

                    Process.Start("AreaTM_IoT.exe");

                    //this.Close();
                }
                else if (getp == "0" && sdvxwin.AreaTM_IoT)
                {
                    sdvxwin.AreaTM_IoT = false;

                    killProcess = Process.GetProcessesByName("AreaTM_IoT");
                    if (killProcess.Length >= 1)
                    {
                        for (int i = 0; i < killProcess.Length; i++)
                        {
                            killProcess[i].Kill();
                        }
                        Delay(100);
                    }

                    killProcess = null;
                }
            }
            getp = "";

            /*oldcode_video_download*/
        }
    }
}
