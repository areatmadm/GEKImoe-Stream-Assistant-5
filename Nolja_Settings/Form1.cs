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
using OBSWebsocketDotNet;

namespace GEKImoeStreamAssistant5FixReboot
{
    public partial class Nolja_ErrorFix : Form
    {
        PrivateFontCollection font_3_0_s = new PrivateFontCollection();
        string fix_nfd;

        //보안 강화에 POST 전송으로 암호화 통신 적용
        string[] postStringKey = new string[10];
        string[] postStringValue = new string[10];

        //강제종료를 위한 Process 정보 사전 입력
        string[] exitProcesses = new string[10000];

        public static OBSWebsocket _obs;

        //Streaming status
        public static bool isNowStream = false;

        public static string setgame; //현재 게임 확인
        public static string vender; //업소 확인

        int quick = 60;
        int qtemp;

        int fixPhase = 0;
        //fixPhase 0 : camera fixing(change scene profile)
        //fixPhase 1 : restarting OBS with restart GEKImoe Stream Assistant 5 or GEKImoe Stream Assistant NT

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
                    if (postDataKey[i] == null) { break; }
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

            _obs = new OBSWebsocket();

            _obs.Connected += onConnect;
            _obs.Disconnected += onDisconnect;
        }

        private void onConnect(object sender, EventArgs e)
        {

        }

        private void onDisconnect(object sender, EventArgs e)
        {
            _obs.Disconnect();
        }

        private bool ConnectToServer()
        {
            if (!_obs.IsConnected)
            {
                try
                {
                    //Test Build ONLY
                    if (File.Exists("test")) _obs.Connect("ws://127.0.0.1:7849", "noljabroadcastpc");

                    //Main Build ONLY
                    else _obs.Connect("ws://127.0.0.1:4444", "noljabroadcastpc");

                    //streaming check
                    if (_obs.GetStreamingStatus().IsStreaming) { isNowStream = true; }
                }
                catch (AuthFailureException)
                {
                    MessageBox.Show("Authentication failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                catch (ErrorResponseException ex)
                {
                    MessageBox.Show("Connect failed : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                return true;
            }
            else
            {
                return false;
                //_obs.Disconnect();
            }
        }

        private void NoljaStreamingSelect_Load(object sender, EventArgs e)
        {


            fix_nfd = System.IO.Path.GetFullPath("font_3.0").Replace(@"Bugfix\", "");
            //fix_nfd = System.IO.Path.GetFullPath("font_3.0").Replace(@"Debug\", "");
            //MessageBox.Show(fix_nfd);
            font_3_0_s.AddFontFile(fix_nfd + @"\nanum-barun-gothic\NanumBarunGothicBold.otf");
            font_3_0_s.AddFontFile(fix_nfd + @"\nanum-barun-gothic\NanumBarunGothic.otf");

            this.Font = new Font(font_3_0_s.Families[0], 18f, FontStyle.Bold);
            btn_exit.Font = new Font(font_3_0_s.Families[0], 18f, FontStyle.Bold);
            btn_fix.Font = new Font(font_3_0_s.Families[0], 18f, FontStyle.Bold);
            label1.Font = new Font(font_3_0_s.Families[0], 14f);
            lbl_name.Font = new Font(font_3_0_s.Families[0], 22f, FontStyle.Bold);
            button1.Font = new Font(font_3_0_s.Families[0], 18f, FontStyle.Bold);

            //timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Enabled = false;
        }

        private void btn_fix_Click(object sender, EventArgs e)
        {
            btn_fix.Enabled = false;
            btn_exit.Enabled = false;
            button1.Enabled = false;

            //Process.Start("nolja_fix_pp.vbs"); //(구)SW 강종 코드

            //신 SW 강종 코드 start
            exitProcesses[0] = "explorer"; //Windows 탐색기
            exitProcesses[1] = "obs64"; //OBS

            //GEKImoe Stream Assistant 5 찾기 시작
            exitProcesses[2] = "AreaTM_acbas"; //Full버전일 경우
            exitProcesses[3] = "GEKImoeStreamAssistant5Lite"; //Lite버전일 경우
            exitProcesses[4] = "SangguGSA5"; //구. 로얄게임장 전용
            exitProcesses[5] = "GAMED_BCAS"; //(주)대왕산업 계열 고객사 전용
                                             //GEKImoe Stream Assistant 5 찾기 끝

            //Internet Browser 시작
            exitProcesses[6] = "chrome"; //Google Chrome
            exitProcesses[7] = "msedge"; //Microsoft Edge
            exitProcesses[8] = "firefox"; //Mozilla Firefox
            exitProcesses[9] = "whale"; //Naver Whale
                                        //Internet Browser 끝

            //Apple 시작
            exitProcesses[10] = "iTunes"; //iTunes
            exitProcesses[11] = "AppleDevices"; //Apple 기기
                                                //Apple 끝

            //GEKImoe Stream AI 시작
            exitProcesses[12] = "GEKImoeStreamAI";
            //GEKImoe Stream AI 끝

            //아레아티엠 오락실 방송 어시스턴트(v4) IoT 시작
            exitProcesses[13] = @"AreaTM_IoT";
            //아레아티엠 오락실 방송 어시스턴트(v4) IoT 끝


            Process killProcess = new Process(); //taskkill.exe 구동을 위한 Process 함수 생성
            killProcess.StartInfo.FileName = @"C:\Windows\System32\taskkill.exe"; //taskkill 경로 작성
            killProcess.StartInfo.Arguments = @"/f";
            killProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden; //cmd창 숨겨보기
            for (int i = 0; i < exitProcesses.Length; i++) //여러 프로그램들을 동시에 강종하기 위한 Process 수집
            {
                if (exitProcesses[i] == null) { /*MessageBox.Show(i + "");*/ break; } //null값 추출
                Process[] ifUsingProcess = Process.GetProcessesByName(exitProcesses[i]); //프로세스가 실행 중인지 찾기
                if (ifUsingProcess.Length >= 1) { killProcess.StartInfo.Arguments += @" /im " + exitProcesses[i] + ".exe"; } //미리 입력된 Process 입력
            }
            killProcess.Start(); //KILL

            //신 SW 강종 코드 end
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

            //구형 GET방식 데이터 전송 시작
            /*if (File.Exists(Path.GetFullPath("nolja_game_set.txt").Replace(@"Bugfix\", ""))) //놀자는 독자적인 도메인 이용
            {
                noll = GetHtmlString("https://nolja.bizotoge.areatm.com/public/serverstatus?mode=4&submode=5&game=" + setgame);
            }
            else // 그 외에는 표준규격 사용
            {
                noll = GetHtmlString("https://service.stream-assistant-5.gekimoe.areatm.com/public/serverstatus?vender=" + vender + "mode=4&submode=5&game=" + setgame);
            }*/
            //구형 GET방식 데이터 전송 끝
            //신형 POST방식 데이터 전송 시작
            postStringKey[0] = "vender"; postStringValue[0] = vender; //game
            postStringKey[1] = "mode"; postStringValue[1] = "4"; //game
            postStringKey[2] = "submode"; postStringValue[2] = "5"; //postkey_vender
            postStringKey[3] = "game"; postStringValue[3] = setgame; //game

            noll = PostHtmlString("https://service.stream-assistant-5.gekimoe.areatm.com/v2/serverstatus/v1/", postStringKey, postStringValue);
            //신형 POST방식 데이터 전송 끝

            Delay(1000);

            lbl_name.Text = "GEKImoe Stream Assistant 재시작 요청됨";
            timer1.Enabled = true;
            label1.Text = "30초 후 GEKImoe Stream Assistant를 재시작합니다.";
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            quick--;
            qtemp = quick / 2;
            label1.Font = new Font(font_3_0_s.Families[0], 14f);

            /*if (qtemp >= 60)
            {
                label1.Text = (qtemp / 60) + "분 " + (qtemp % 60) + "초 후 GEKImoe Stream Assistant를 재시작합니다.";
            }
            else */
            label1.Text = qtemp + "초 후 GEKImoe Stream Assistant를 재시작합니다.";
            //label1.Font = new Font(font_3_0_s.Families[0], 14f);

            if (qtemp < 0)
            {
                label1.Text = "재시작을 진행합니다...";
                timer1.Enabled = false;
                Delay(2000);
                if(File.Exists(Path.GetFullPath("AutoStartV3.exe").Replace(@"Bugfix\", ""))){ //AutoStartV3 재실행
                    Process startV3 = new Process();
                    startV3.StartInfo.FileName = Path.GetFullPath("AutoStartV3.exe").Replace(@"Bugfix\", ""); //경로를 찾아 AutoStartV3.exe를 시작 파일로 설정
                    startV3.StartInfo.WorkingDirectory = Path.GetFullPath("AutoStartV3.exe").Replace(@"Bugfix\AutoStartV3.exe", ""); //AutoStartV3가 있는 폴더를 시작 경로로 설정
                    startV3.Start(); //재시작
                    Application.ExitThread();//Bugfix 종료
                }
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

        private void button1_Click(object sender, EventArgs e)
        {
            btn_fix.Enabled = false;
            btn_exit.Enabled = false;
            button1.Enabled = false;

            //campatch
            try
            {
                ConnectToServer();

                String nowSceneName = _obs.GetCurrentSceneCollection(); //현재 장면 모음 이름 가져오기
                _obs.SetCurrentSceneCollection("patchcam"); //patchcam 전환

                Delay(7000);
                _obs.SetCurrentSceneCollection(nowSceneName); // 원복

                
                if (File.Exists(@"WebCameraConfig\cam_sett.cfg"))
                {
                    Delay(5000);

                    Process runCamSett = new Process(); //새로운 Process 생성
                    runCamSett.StartInfo.WindowStyle = ProcessWindowStyle.Hidden; //일단 창 생성 없이 구동
                    runCamSett.StartInfo.FileName = "restore.bat"; //WebCameraConfig\restore.bat
                    runCamSett.StartInfo.WorkingDirectory = "WebCameraConfig"; //실행 자체가 그 폴더에 있는 cam_sett.cfg 파일을 필요로 함
                    runCamSett.Start(); //PROFIT!!
                    Delay(2000);
                    runCamSett.Start(); //Profit!!(2회 적용시켜 적용이 안되는 현상이 일어나지 않도록 함.)
                }
            }
            catch { }


            Delay(2000);
            btn_fix.Enabled = true;
            btn_exit.Enabled = true;
            button1.Enabled = true;
        }
    }
}
