using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using System;
//using System.Windows.Forms;
using OBSWebsocketDotNet;
using OBSWebsocketDotNet.Types;
using System.Diagnostics;

//using nolja_game_set;

using System.IO;
using CefSharp;
using CefSharp.WinForms;
using CefSharp.SchemeHandler;

using Gecko;
using Gecko.DOM;
using System.Net;

namespace AreaTM_acbas
{
    public partial class sdvxwin : Form
    {
        public static int nowStreamTime = 0;
        public static bool FirstRun_RestreamOnly = true;

        public static bool isMuteWindow_opened = false;
        public static string pastScene;
        public static bool AreaTM_IoT = false;

        Form PLIVEForm = new plv();
        public static bool PLIVEForm_closed = true;

        Form PlusSettingForm = new plus_settings();
        public static bool PlusSettingForm_closed = true;
        public static bool PS_cam_reset = true; // 기타 캠 모드

        public static double plive_version; //PLIVE Service Version
        public static string nolja_ver;
        public static long nolja_build;
        public static string nolja_partnum; //Update 티어 설정

        //NOLJA Broadcast Ver.3.0 Alpha_Test
        //public static bool testver_3 = false;
        public static ChromiumWebBrowser ytvideo = new ChromiumWebBrowser();

        public static GeckoWebBrowser ytvideo_2 = new GeckoWebBrowser();

        public static string ytvd_pt = System.IO.Path.GetFullPath("promotionvideo");

        //NOLJA what season back color or fore color?
        //NOLJA maimaiDX Splash color(2020.9.17 After patched ~ 2020.9.24 Before patched
        public static Color nowseason_b_color;
        public static Color nowseason_f_color;
        public static bool nowseason = false;

        //NOLJA chinatsu_color
        public static Color chinatsu_white = Color.FromArgb(250, 250, 250);
        public static Color chinatsu_black = Color.FromArgb(32, 32, 32);
        public static Color chinatsu_black_nor = Color.FromArgb(60, 60, 60);
        public static Color chinatsu_disabled = Color.FromArgb(200, 200, 200);

        //NOLJA New Fonts
        public static PrivateFontCollection font_5_0_r = new PrivateFontCollection();
        public static PrivateFontCollection font_5_0_b = new PrivateFontCollection();

        //NOLJA Update Chk
        public static bool ischeckedupd = false;

        public static bool isCheckedGenuine = false;

        //ReStreamingStatus
        public static bool isRestreaming_onlyCheckStatus = false;

        //isFinishedTime
        public static bool isFinishedTime = false;

        //Check correctly status
        public static bool isCorrectlyStatus = false;
        public static bool nowRebooting = false;

        //CamOFF status for sdvx
        public static int sdvx_camoffstatus = 0;
        //0: INFORM & RE-Set, 1: NO-Inform & RE-Set, 2: INFORM & 12Min Set

        //NOLJA maimaiDX Cam Initialized status
        public static bool CamInitialized = false;

        int opd = 0;

        //int chk_highlight_beta = 0;

        public static string setgame;

        float obsvol = 0f;
        int chkbeta_mute; //음소거 대상 확인
        public static bool isrecordmod = false;
        public static bool streamstatus = false;

        public static bool banneduser = false;

        //ffmpeg 가동 Process
        public static Process startFFmpeg = new Process();


        public sdvxwin()
        {
            InitializeComponent();
            _obs = new OBSWebsocket();

            _obs.Connected += onConnect;
            _obs.Disconnected += onDisconnect;

            _obs.SceneChanged += onSceneChange;
            _obs.SceneCollectionChanged += onSceneColChange;
            _obs.ProfileChanged += onProfileChange;
            _obs.TransitionChanged += onTransitionChange;
            _obs.TransitionDurationChanged += onTransitionDurationChange;

            //_obs.StreamingStateChanged += onStreamingStateChange;
            _obs.RecordingStateChanged += onRecordingStateChange;

            _obs.StreamStatus += onStreamData;
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

        public static OBSWebsocket _obs;



        private void onConnect(object sender, EventArgs e)
        {

        }

        private void onDisconnect(object sender, EventArgs e)
        {
            _obs.Disconnect();
        }

        private void onSceneChange(OBSWebsocket sender, string newSceneName)
        {
            if (setgame != "0_sega_maimaidx" && setgame != "3_squarepixels_ez2ac")
            {
                string state = "";
                switch (newSceneName)
                {
                    case "camon":
                        state = language_.ko_kr_FormsChange_OFF;
                        break;

                    case "camoff":
                        state = language_.ko_kr_FormsChange_ON;
                        break;

                    default:
                        state = language_.ko_kr_FormsChange_ChangeDefault;
                        break;
                }

                BeginInvoke((MethodInvoker)delegate
                {
                //펌프 캠 운영 일시중단에 따른 강제 비활성화 코드
                /*if(setgame == "6_andamiro_pumpitup")
                {
                    if(newSceneName == "camon") { _obs.SetCurrentScene("camoff"); }
                    if (newSceneName == "camon" || newSceneName == "camoff") FormsChange.Enabled = false;
                    else FormsChange.Enabled = true;
                } 1단계 조치로 인한 캠 강제 OFF 비활성화*/
                    if (newSceneName != "camoff_mute") FormsChange.Text = state;

                /*
                if(newSceneName == "camon" || newSceneName == "camoff")
                {
                    if (!PlusSettingForm_closed) { plus_settings.rd_cam_mode_0_pub = false; }
                }
                */

                    /*if(setgame == "5_konami_sdvx")
                    {
                        if(sdvx_camoffstatus == 0 && newSceneName != "camon")
                        {
                            string nullSt;
                            nullSt = GetHtmlString("https://nolja.bizotoge.areatm.com/public/plive/forgotid/sdvx_camstat.php?mod=ban");//twelv

                            _obs.SetCurrentScene("camon");
                        }
                    }*/
                
                });
            }
            else
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    if (newSceneName == "camon_mute" && !isMuteWindow_opened)
                    {
                        Form MuteWindow = new howtochat();
                        isMuteWindow_opened = true;
                        pastScene = "camon";
                        MuteWindow.ShowDialog();
                    }
                    else if(newSceneName == "camoff_mute" && !isMuteWindow_opened)
                    {
                        Form MuteWindow = new howtochat();
                        isMuteWindow_opened = true;
                        pastScene = "camoff";
                        MuteWindow.ShowDialog();
                    }
                });
            }
        }

        private void onVChanged(object sender, EventArgs e)
        {

        }

        private void onSceneColChange(object sender, EventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                //tbSceneCol.Text = _obs.GetCurrentSceneCollection();
                if(!CamInitialized)
                {
                    Form camchange_maimai2p = new camchange_maimai2p();
                    try { camchange_maimai2p.Show(); } catch { }
                    try { camchange_maimai2p.Close(); } catch { }

                    //1P, 2P 모두 캠 초기화가 완료되었을때 더이상 해당 작업 수행 안함
                    //if (_obs.GetCurrentSceneCollection() == "maimaiDX_1P2P") CamInitialized = true;
                }
            });
        }

        private void onProfileChange(object sender, EventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                //tbProfile.Text = _obs.GetCurrentProfile();
            });
        }

        private void onTransitionChange(OBSWebsocket sender, string newTransitionName)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                //tbTransition.Text = newTransitionName;
            });
        }

        private void onTransitionDurationChange(OBSWebsocket sender, int newDuration)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                //tbTransitionDuration.Value = newDuration;
            });
        }

        private void onStreamData(OBSWebsocket sender, StreamStatus data)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                nowStreamTime = data.TotalStreamTime;
            });
        }

        private void onStreamingStateChange(OBSWebsocket sender, OutputState newState)
        {
            string state = "";
            switch (newState)
            {
                case OutputState.Starting:
                    state = "Stream starting...";
                    break;

                case OutputState.Started:
                    state = "Stop streaming";
                    BeginInvoke((MethodInvoker)delegate
                    {
                        //gbStatus.Enabled = true;
                    });
                    break;

                case OutputState.Stopping:
                    state = "Stream stopping...";
                    break;

                case OutputState.Stopped:
                    state = "Start streaming";
                    BeginInvoke((MethodInvoker)delegate
                    {
                        //gbStatus.Enabled = false;
                    });
                    break;

                default:
                    state = "State unknown";
                    break;
            }

            BeginInvoke((MethodInvoker)delegate
            {
                //btnToggleStreaming.Text = state;
                if(newState == OutputState.Started && File.Exists(@"C:\MonaServer\ffmpeg.exe")) //PLIVE MultiStream2 모듈 확인
                {
                    startFFmpeg.Start();
                }
            });
        }

        private void onRecordingStateChange(OBSWebsocket sender, OutputState newState)
        {
            string state = "";
            switch (newState)
            {
                case OutputState.Starting:
                    state = language_.ko_kr_recstart;
                    break;

                case OutputState.Started:
                    state = language_.ko_kr_recstart_stop;
                    break;

                case OutputState.Stopping:
                    state = language_.ko_kr_recstart_stop;
                    break;

                case OutputState.Stopped:
                    state = language_.ko_kr_recstart;
                    break;

                default:
                    state = language_.ko_kr_recstart_error;
                    break;
            }

            BeginInvoke((MethodInvoker)delegate
            {
                rec_start.Text = state;

                if(newState == OutputState.Started)
                {
                    VIDEO_on.rec = true;
                    if (quick >= 60)
                    {
                        if ((quick % 60) != 0) lbl_rectimer.Text = (quick / 60) + language_.ko_kr_lbl_rectimer_RECMOD_minuite + (quick % 60) + language_.ko_kr_lbl_rectimer_RECMOD_second + language_.ko_kr_lbl_rectimer_RECMOD_willstop;
                        else lbl_rectimer.Text = (quick / 60) + language_.ko_kr_lbl_rectimer_RECMOD_minuite + language_.ko_kr_lbl_rectimer_RECMOD_willstop;//영어는 서순이 달라 수정필수!
                    }
                    else lbl_rectimer.Text = quick + language_.ko_kr_lbl_rectimer_RECMOD_second + language_.ko_kr_lbl_rectimer_RECMOD_willstop;

                    rec_start.Enabled = true;

                    if (!timer_rec.Enabled)
                        timer_rec.Enabled = true;
                }

                else if (newState == OutputState.Stopped)
                {
                    lbl_rectimer.Text = language_.ko_kr_lbl_rectimer_IDLE;
                    VIDEO_on.rec = false;

                    rec_start.Enabled = true;

                    rec_start.Enabled = true;
                    if (chkbeta_mute == 1) btn_mute.Enabled = true;
                    //rec_3mh.Enabled = true;
                    if (!streamstatus) btn_personal.Enabled = true;
                }

                else if (newState == OutputState.Starting)
                {
                    isrecordmod = true; //녹화 중에는 일부 기능 제한
                    quick = 990;

                    lbl_rectimer.Text = language_.ko_kr_lbl_rectimer_STARTING;
                    rec_start.Enabled = false;
                    if (chkbeta_mute == 1) btn_mute.Enabled = false;
                    //rec_3mh.Enabled = false;
                    if(!streamstatus) btn_personal.Enabled = false;
                }

                else if (newState == OutputState.Stopping)
                {
                    isrecordmod = false;

                    if (timer_rec.Enabled)
                        timer_rec.Enabled = false;

                    lbl_rectimer.Text = language_.ko_kr_lbl_rectimer_RECMOD_saving;
                    
                    rec_start.Enabled = false;
                }

                else
                {
                    rec_start.Enabled = false;
                    lbl_rectimer.Text = "Error occured!";
                }
            });
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

        private void sdvxwin_Activate(object sender, EventArgs e)
        {
            if (opd == 0)
            {
                sdvxwin_Shown(e);
                opd++;
            }
            
        }

        private void sdvxwin_Shown(EventArgs e)
        {
            DrumChat de = new DrumChat();

            ytvideo_2.Navigate("file:///" + ytvd_pt.Replace(@"\", "/") + "/index.html");
            ytvideo_2.Dock = DockStyle.None;
            ytvideo_2.Size = new Size(380, 214);
            ytvideo_2.Location = new Point(10, 332);
            ytvideo_2.BackColor = chinatsu_black;
            this.Controls.Add(ytvideo_2);
            ytvideo_2.Enabled = false;

            VIDEO_on video_on = new VIDEO_on(this);
            video_on.Show();

            //updatelog_Click(0, e);
            if (File.Exists(@"nolja_maimaichat_termpfix\Nolja_OpenUp.exe"))
            {
                //놀자 마이마이채팅 오류 임시조치 패치
                ProcessStartInfo chatopen_temp = new ProcessStartInfo();
                chatopen_temp.FileName = "Nolja_OpenUp.exe";
                chatopen_temp.WorkingDirectory = "nolja_maimaichat_termpfix";

                Process.Start(chatopen_temp);
            }
            else
            {
                Form d = de;
                d.Show();

                //YouTube 정책 변경에 따른 변화된 스트리밍 방식 적용
                if (File.Exists(@"chromium\chromium.exe") && !File.Exists(@"nolja_maimaichat_termpfix\Nolja_OpenUp.exe"))
                {
                    Form checkstream = new check_stream(de);
                    checkstream.Show();
                }
            }

            this.Focus();
            
            if (setgame == "6_andamiro_pumpitup")
            {
                Delay(500);
                if (File.Exists("already_stream_piu")) File.Delete("already_stream_piu");
                else
                {
                    //Form piumute = new piu_micmute();
                    //piumute.Show();
                }
            }

            Form ReStreaming = new NOLJA_ReStream();
            ReStreaming.Show();

            Form maintance;
            if (File.Exists(@"nolja_maimaichat_termpfix\Nolja_OpenUp.exe"))
            {
                maintance = new maintaince_check(this, video_on);
            }
            else maintance = new maintaince_check(this, video_on, de);
            maintance.Show();
            Delay(300);
        }

        private void sdvxwin_Load(object sender, EventArgs e)
        {
            startFFmpeg.StartInfo.FileName = @"C:\MonaServer\ffmpeg_start.vbs";
            startFFmpeg.StartInfo.WorkingDirectory = @"C:\MonaServer";

            if (Program.ExitThread == true) Application.ExitThread();

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            //NOLJA New Fonts_Kakao NOLNABroadcast 3.0
            /*font_3_0_s.AddFontFile(@"font_3.0\kakao\KakaoBold.ttf");
            font_3_0_s.AddFontFile(@"font_3.0\kakao\KakaoRegular.ttf");*/

            //GEKImoe Stream New Fonts_NAVER NanumGothic for AreaTM_acbas 5.0
            //font_5_0_r.AddFontFile(@"font_3.0\nanum-gothic\NanumGothic.ttf");
            //font_5_0_b.AddFontFile(@"font_3.0\nanum-gothic\NanumGothicExtraBold.ttf");

            //GEKImoe Stream New Fonts_NAVER NanumBarunGothic for AreaTM_acbas 5.0
            font_5_0_r.AddFontFile(@"font_3.0\nanum-barun-gothic\NanumBarunGothic.otf"); //0 
            font_5_0_b.AddFontFile(@"font_3.0\nanum-barun-gothic\NanumBarunGothicBold.otf"); //1 → [0], style=bold


            this.Text = language_.ko_kr_sdvxwin_name;

            setgame = File.ReadAllText(@"nolja_game_set.txt");

            //Version 일람
            //Alpha_{N} : {N}번째 알파 버전, Beta_{N}: {N}번째 베타 버전, Pre_{N} or Pre: 정식출시 직전 마지막 버전
            //_SP_: Special Theme 적용 버전, _{Alphabet}: n번째 빌드, _NotRelease: 미리보기 화면용
            //예시: 3.0-Pre_0_SP_B : 3.0 버전 출시 직전 마지막 n번째 스페셜 테마 적용 중 2번째 빌드
            //예시: 3.0-Pre_0_SP_B_NotRelease : 3.0 버전 출시 직전 마지막 n번째 스페셜 테마 적용 중 2번째 빌드(미리보기용)
            //Program.cs에서 작업하세요!!
            nolja_ver = Program.acbas_ver; //nolja_ver = "5.0-Pre.2_A";
            nolja_build = Program.acbas_build; //nolja_build = 202111031618;
            nolja_partnum = Program.acbas_partnum; //업데이트 파트 설정
                                        //업데이트 확인 경로: ./public/updatecheck/{PARTNUM}
                                        //업데이트 경로: ./autoupdate/{PARTNUM}/{NEWBUILD}.7z

            lbl_version.Text = "Ver." + nolja_ver + " | " + nolja_build;
            plive_version = 2.0; //PLIVE 모듈 버전

            Form Genuine_Auth = new Authorize_acbas();
            Genuine_Auth.ShowDialog();

            if (!isCheckedGenuine)
            {
                MessageBox.Show("아레아티엠 게키모에 인증을 받지 않은 오락실입니다." + "\r\n" + "관리자에게 문의 바랍니다.", "아레아티엠 게키모에 스트리밍 어시스턴트 인증");
                Application.ExitThread();
            }

            //NOLJA_Game_Set setgame_newget = new NOLJA_Game_Set();
            //setgame = setgame_newget.setgame_dll();

            //if (setgame == "0_sega_maimaidx" || setgame == "6_andamiro_pumpitup") btn_personal.Enabled = true;
            //else btn_personal.Enabled = false;
            btn_personal.Enabled = true;

            sdvxpic.Load(@"ResourceFiles\" + setgame + @"\logo.png");
            pictureBox1.Load(@"ResourceFiles\" + setgame + @"\qrcode.png");

            string setqrinfo = File.ReadAllText(@"ResourceFiles\" + setgame + @"\qrinfo.otogeonpf");
            lbl_linkinfo.Text = setqrinfo;


            FileStream fs = new FileStream(@"ResourceFiles\" + setgame + @"\highlight_beta.otogeonpf", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            //chk_highlight_beta = int.Parse(sr.ReadLine());
            sr.Close();
            fs.Close();

            fs = new FileStream(@"ResourceFiles\" + setgame + @"\muteable.otogeonpf", FileMode.Open, FileAccess.Read);
            sr = new StreamReader(fs);
            chkbeta_mute = int.Parse(sr.ReadLine());
            sr.Close();
            fs.Close();

            //if (chk_highlight_beta == 1)
            rec_3mh.Enabled = true;
            if (chkbeta_mute == 1) btn_mute.Enabled = true;

            //set_handfoot = File.ReadAllText(@"ResourceFiles\" + setgame + @"\handfootinfo.otogeonpf");
            //손캠인지 발캠인지 북캠인지 구분해 주는 기능


            if (!ConnectToServer())
            {
                //Application.Restart();
            }

            /*
            마이마이 디럭스 기기관리 강화 조치로 인한 캠 비활성화 불가 조치*/
            if (setgame == "0_sega_maimaidx" || setgame == "3_squarepixels_ez2ac")
            {
                /*try
                {
                    _obs.SetCurrentScene("camon");
                }
                catch { }
                //FormsChange.Text = set_handfoot + language_.ko_kr_FormsChange_ON;
                FormsChange.Enabled = false;
                */

                FormsChange.Text = language_.ko_kr_FormsChange_DualView;

                //if (_obs.GetCurrentSceneCollection() == "maimaiDX_2P_Normal" || _obs.GetCurrentSceneCollection() == "maimaiDX_1P2P")
                //{
                //캠 초기화 진행
                Form camchange_maimai2p = new camchange_maimai2p();
                try { camchange_maimai2p.Show(); } catch { }
                try { camchange_maimai2p.Close(); } catch { }

                //1P, 2P 모두 캠 초기화가 완료되었을때 더이상 해당 작업 수행 안함
                //if (_obs.GetCurrentSceneCollection() == "maimaiDX_1P2P") CamInitialized = true;

                //}
            }

            if (setgame != "0_sega_maimaidx" && setgame != "3_squarepixels_ez2ac")
            {
                string nowscene;
                nowscene = _obs.GetCurrentScene().Name;
                if (nowscene == "camon") { FormsChange.Text = language_.ko_kr_FormsChange_OFF; }
                else if (nowscene == "camoff") { FormsChange.Text = language_.ko_kr_FormsChange_ON; }
                else if (nowscene == "camoff_mute") { FormsChange.Text = language_.ko_kr_FormsChange_ON; }
                else FormsChange.Text = language_.ko_kr_FormsChange_ChangeDefault;
            }

            //FormsChange.Text = "손캠 ON/OFF하기";

            bool dd;
            dd = _obs.GetStreamingStatus().IsRecording;
            if (!dd)
            {
                rec_start.Text = "녹화 시작";
                lbl_rectimer.Text = "녹화 가능";
            }
            else
            {
                rec_start.Text = "녹화 중지";
                timer_rec = new System.Windows.Forms.Timer();
                timer_rec.Interval = 1000;
                timer_rec.Tick += new EventHandler(timer_rec_Tick);
                timer_rec.Enabled = true;
            }

            nowseason = false; //nowseason_check()로 이동해서 상세하게 설정

            //NOLJA BlackEdition NoljaBroadcast 3.0
            NOLJA_Black_Edition();

            //놀자 마이마이 임시조치(모니터 수리후 코드 완전히 제거
            //if (File.Exists("Nolja_CheckScreenR.exe")) NOLJAMAIMAITEMP();


            timer_viewer.Enabled = true;
        }

        //놀자 마이마이 임시조치(모니터 수리후 코드 제거
        private void NOLJAMAIMAITEMP()
        {
            lbl_linkinfo.Font = new Font(font_5_0_b.Families[0], 15f, FontStyle.Bold);
            lbl_linkinfo.Text = "놀자 마이마이 트위치 생방송" + "\r\n" +
                                "https://twitch.tv/nolja_maimai" + "\r\n" +
                                "또는 트위치에서 nolja_maimai 검색";
            lbl_linkinfo.Size = new Size(400, 87);
            lbl_version.Location = new Point(12, 649);

            pictureBox1.Visible = false;

            this.Size = new Size(400, 674);
            this.Location = new Point(966, 50);
        }

        private void FormsChange_Click(object sender, EventArgs e)
        {
            //if (!PS_cam_reset) { _obs.SceneChanged -= onSceneChange; _obs.SceneChanged += onSceneChange; PS_cam_reset = true; }

            //scenechanged로 이동
            if (setgame == "0_sega_maimaidx" || setgame == "3_squarepixels_ez2ac")
            {
                Form d = new whatform();
                d.Show();
            }

            /*else if(setgame == "5_konami_sdvx" && _obs.GetCurrentScene().Name == "camon")
            {
                //한시적으로 캠 끄기 기능 감시
                Form d = new sdvx_camoff();
                d.Show();
            }*/

            else
            {
                string nowscene;
                nowscene = _obs.GetCurrentScene().Name;

                if (nowscene == "camon")
                {
                    _obs.SetCurrentScene("camoff");
                    //FormsChange.Text = language_.ko_kr_FormsChange_ON;
                }
                else
                {
                    /*if (setgame == "6_andamiro_pumpitup") { _obs.SetCurrentScene("camoff"); }
                    else */
                    _obs.SetCurrentScene("camon");
                    //FormsChange.Text = language_.ko_kr_FormsChange_OFF;
                }
            }
        }

        int quick = 990;
        int qtemp;

        private void rec_start_Click(object sender, EventArgs e)
        {
            //if (!VIDEO_on.isgo)
            /*if(!VIDEO_on.tmp_d_md0 && VIDEO_on.tmp_d_md1)
            {
                btn_mute.Enabled = false;
                rec_start.Enabled = false; openexplorer_rec.Enabled = false; //btn_itunes.Enabled = false;
                //updatelog.Enabled = false;
                rec_3mh.Enabled = false; btn_personal.Enabled = false; btn_more.Enabled = false;

                lbl_rectimer.Text = "게임기 작동 후 다시 시도해주세요";
                Delay(1000);

                btn_mute.Enabled = true;
                rec_start.Enabled = true; openexplorer_rec.Enabled = true; //btn_itunes.Enabled = true;
                //updatelog.Enabled = true;
                rec_3mh.Enabled = true; btn_personal.Enabled = true; btn_more.Enabled = true;
                lbl_rectimer.Text = language_.ko_kr_lbl_rectimer_IDLE;

                return;
            }*/

            isrecordmod = true;
            bool isrec;
            isrec = _obs.GetStreamingStatus().IsRecording;

            if (!isrec)
            {

                timer_rec = new System.Windows.Forms.Timer();
                timer_rec.Interval = 1000;
                timer_rec.Tick += new EventHandler(timer_rec_Tick);
                _obs.StartRecording();
            }
            else
            {
                _obs.StopRecording();
                quick = 990;
            }
        }

        private void openexplorer_rec_Click(object sender, EventArgs e)
        {
            /*try
            {
                Process.Start(_obs.GetRecordingFolder());
            }
            catch
            {
                MessageBox.Show("Error");
            }*/
            Form d = new movefile_form();
            d.Show();
        }

        /*private void btn_itunes_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(_obs.GetRecordingFolder());
            }
            catch
            {
                MessageBox.Show("Error");
            }
            Form d = new howtomoveios();
            d.ShowDialog();
        }*/

        private void NOLJA_Black_Edition()
        {
            nowseason_check();

            //nanumgothic
            //Font kakao_r_16 = new Font(font_5_0_b.Families[0], 14f);
            //Font kakao_r_12 = new Font(font_5_0_b.Families[0], 11f);

            //nanumbarungothic
            Font kakao_r_16 = new Font(font_5_0_b.Families[0], 15f, FontStyle.Bold);
            Font kakao_r_12 = new Font(font_5_0_b.Families[0], 12f, FontStyle.Bold);

            FormsChange.Font = kakao_r_16;
            rec_start.Font = kakao_r_16;


            openexplorer_rec.Font = kakao_r_16;
            btn_mute.Font = kakao_r_16;
            //btn_itunes.Font = kakao_r_16;

            rec_3mh.Font = kakao_r_16;
            //updatelog.Font = kakao_r_12;
            btn_personal.Font = kakao_r_12;
            btn_more.Font = kakao_r_12;

            lbl_linkinfo.Font = new Font(font_5_0_b.Families[0], 17f, FontStyle.Bold);

            lbl_rectimer.Font = new Font(font_5_0_r.Families[0], 12f);
            lbl_version.Font = new Font(font_5_0_r.Families[0], 11.25f);

            //ytvideo.Load("file:///" + ytvd_pt.Replace(@"\", "/") + "/index.html");

            /*ytvideo.Dock = DockStyle.None;
            ytvideo.Size = new Size(377, 212);
            ytvideo.Location = new Point(12, 331);
            ytvideo.BackColor = chinatsu_black;
            this.Controls.Add(ytvideo);
            ytvideo.Enabled = false;
            //lbl_info.Visible = false;*/

            NOLJA_Edition_Statechange();
        }

        private void NOLJA_Edition_Statechange()
        {
            if (rec_start.Enabled) rec_start.BackColor = nowseason_b_color; else rec_start.BackColor = chinatsu_disabled;
            if (FormsChange.Enabled) FormsChange.BackColor = nowseason_b_color; else FormsChange.BackColor = chinatsu_disabled;
            if (openexplorer_rec.Enabled) openexplorer_rec.BackColor = nowseason_b_color; else openexplorer_rec.BackColor = chinatsu_disabled;
            if (btn_mute.Enabled) btn_mute.BackColor = nowseason_b_color; else btn_mute.BackColor = chinatsu_disabled;
            //if (btn_itunes.Enabled) btn_itunes.BackColor = nowseason_b_color; else btn_itunes.BackColor = chinatsu_disabled;
            //if (updatelog.Enabled) updatelog.BackColor = nowseason_b_color; else updatelog.BackColor = chinatsu_disabled;
            if (rec_3mh.Enabled) rec_3mh.BackColor = nowseason_b_color; else rec_3mh.BackColor = chinatsu_disabled;
            if (btn_personal.Enabled) btn_personal.BackColor = nowseason_b_color; else btn_personal.BackColor = chinatsu_disabled;
            if (btn_more.Enabled) btn_more.BackColor = nowseason_b_color; else btn_more.BackColor = chinatsu_disabled;
        }
        private void rec_start_EnabledChanged(object sender, EventArgs e) //녹화 시작/중지 버튼 상태 변경 시 작동되는 코드
        {
            if (rec_start.Enabled) rec_start.BackColor = nowseason_b_color;
            else rec_start.BackColor = chinatsu_disabled;
        }
        private void FormsChange_EnabledChanged(object sender, EventArgs e) //캠 변경 버튼 상태 변경 시 작동되는 코드
        {
            if (FormsChange.Enabled) FormsChange.BackColor = nowseason_b_color;
            else FormsChange.BackColor = chinatsu_disabled;
        }
        private void openexplorer_rec_EnabledChanged(object sender, EventArgs e) //폴더열기 버튼 상태 변경 시 작동되는 코드
        {
            if (openexplorer_rec.Enabled) openexplorer_rec.BackColor = nowseason_b_color;
            else openexplorer_rec.BackColor = chinatsu_disabled;
        }
        private void btn_mute_EnabledChanged(object sender, EventArgs e) //음소거 버튼 상태 변경 시 작동되는 코드
        {
            if (btn_mute.Enabled) btn_mute.BackColor = nowseason_b_color;
            else btn_mute.BackColor = chinatsu_disabled;
        }
        /*private void btn_itunes_EnabledChanged(object sender, EventArgs e) //애플기기로 옮기기 버튼 상태 변경 시 작동되는 코드
        {
            if (btn_itunes.Enabled) btn_itunes.BackColor = nowseason_b_color;
            else btn_itunes.BackColor = chinatsu_disabled;
        }*/
        /*private void updatelog_EnabledChanged(object sender, EventArgs e) //업데이트 로그 버튼 상태 변경 시 작동되는 코드
        {
            if (updatelog.Enabled) updatelog.BackColor = nowseason_b_color;
            else updatelog.BackColor = chinatsu_disabled;
        }*/
        private void rec_3mh_EnabledChanged(object sender, EventArgs e) //하이라이트 저장 버튼 상태 변경 시 작동되는 코드
        {
            if (rec_3mh.Enabled) rec_3mh.BackColor = nowseason_b_color;
            else rec_3mh.BackColor = chinatsu_disabled;
        }
        private void btn_personal_EnabledChanged(object sender, EventArgs e) //PLIVE 버튼 상태 변경 시 작동되는 코드
        {
            if (btn_personal.Enabled) btn_personal.BackColor = nowseason_b_color;
            else btn_personal.BackColor = chinatsu_disabled;
        }
        private void btn_more_EnabledChanged(object sender, EventArgs e) //+설정 버튼 상태 변경 시 작동되는 코드
        {
            if (btn_more.Enabled) btn_more.BackColor = nowseason_b_color;
            else btn_more.BackColor = chinatsu_disabled;
        }

        private void timer_rec_Tick(object sender, EventArgs e)
        {
            quick--;
            qtemp = quick / 1;

            if (qtemp >= 60)
            {
                if ((qtemp % 60) != 0) lbl_rectimer.Text = (qtemp / 60) + language_.ko_kr_lbl_rectimer_RECMOD_minuite + (qtemp % 60) + language_.ko_kr_lbl_rectimer_RECMOD_second + language_.ko_kr_lbl_rectimer_RECMOD_willstop;
                else lbl_rectimer.Text = (qtemp / 60) + language_.ko_kr_lbl_rectimer_RECMOD_minuite + language_.ko_kr_lbl_rectimer_RECMOD_willstop;
            }
            else lbl_rectimer.Text = qtemp + language_.ko_kr_lbl_rectimer_RECMOD_second + language_.ko_kr_lbl_rectimer_RECMOD_willstop;


            if (qtemp <= 0)
            {
                lbl_rectimer.Text = "";
                if (isrecordmod)
                {
                    quick = 990;
                    _obs.StopRecording();
                }
                else
                {
                    
                }
            }
            /*else if (!VIDEO_on.tmp_d_md0 && VIDEO_on.tmp_d_md1) //기기를 계속 사용하지 않는 경우
            {
                _obs.StopRecording(); //OBS의 녹화 기능을 멈춤
            }*/
        }

        int viewertimer = 4;
        int vitemp;
        private void timer_viewer_Tick(object sender, EventArgs e)
        {
            viewertimer--;
            vitemp = viewertimer / 1;
            if (vitemp == 0)
            {
                viewertimer = 4;
            }
        }

        private void btn_openchat_Click(object sender, EventArgs e)
        {
            //if (!PS_cam_reset) { _obs.SceneChanged -= onSceneChange; _obs.SceneChanged += onSceneChange; PS_cam_reset = true; }
            //_obs.Disconnect();
            if(setgame == "0_sega_maimaidx" && !isMuteWindow_opened)
            {
                if (_obs.GetCurrentScene().Name == "camoff" || _obs.GetCurrentScene().Name == "mod_0")
                    _obs.SetCurrentScene("camoff_mute");
                else _obs.SetCurrentScene("camon_mute");
            }
            else if(setgame != "0_sega_maimaidx")
            {
                Form p = new howtochat();
                p.ShowDialog();
            }
        }

        private void setpersonalbroadcast_Click(object sender, EventArgs e)
        {
            //개인방송 설정이 아닌 하이라이트 설정입니다.
            if(setgame != "6_andamiro_pumpitup") FormsChange.Enabled = false;
            if (chkbeta_mute == 1) btn_mute.Enabled = false;
            rec_start.Enabled = false; openexplorer_rec.Enabled = false; /*btn_itunes.Enabled = false;*/
            /*updatelog.Enabled = false;*/ rec_3mh.Enabled = false; btn_personal.Enabled = false; btn_more.Enabled = false;
            lbl_rectimer.Text = language_.ko_kr_lbl_rectimer_HLSAVE;

            try
            {
                _obs.SaveReplayBuffer();
            }
            catch
            {
                lbl_rectimer.Text = language_.ko_kr_lbl_rectimer_HLSAVE_error;
                MessageBox.Show(language_.ko_kr_lbl_rectimer_HLSAVE_error_popup);
            }
            Delay(2500);

            if (setgame != "6_andamiro_pumpitup") FormsChange.Enabled = true;
            if (chkbeta_mute == 1) btn_mute.Enabled = true;
            rec_start.Enabled = true; openexplorer_rec.Enabled = true; /*btn_itunes.Enabled = true;*/
            /*updatelog.Enabled = true;*/ rec_3mh.Enabled = true; btn_personal.Enabled = true; btn_more.Enabled = true;
            lbl_rectimer.Text = language_.ko_kr_lbl_rectimer_IDLE;
        }

        /*public static void openupdate_promotionvideo()
        {
            Form obd = new update_noljaprom();
            obd.ShowDialog();
        }*/
        
        public void openupdate_njb()
        {
            Form obd = new update_noljabroadcast();
            if (maintaince_check.ischeckone)
            {
                obd.Show();
                //ischeckedupd = true;
            }
            else
            {
                obd.ShowDialog();
                //this.Hide();
            }
        }
        
        private void btn_personal_Click(object sender, EventArgs e)
        {
            if (PLIVEForm_closed)
            {
                PLIVEForm = new plv();
                PLIVEForm_closed = false;

                PLIVEForm.Show();
            }
            else
            {
                PLIVEForm.Show();
                PLIVEForm.Focus();
            }
        }

        private void btn_more_Click(object sender, EventArgs e)
        {
            //놀자 PLIVE 상태 변경
            if (PlusSettingForm_closed)
            {
                PlusSettingForm = new plus_settings();
                PlusSettingForm_closed = false;

                PlusSettingForm.Show();
            }
            else { PlusSettingForm.Show(); PlusSettingForm.Focus(); }
        }

        //Special Edition Colorset
        private void nowseason_check()
        {
            if (nowseason)
            {
                //season 확인법: /public_html/otoge_patch/_common/_specialthemecode

                //2020.10.1 ~ 10.6 프로젝트 세카이 컬러풀 스테이지 가동 기념
                nowseason_b_color = Color.FromArgb(210, 255, 255); nowseason_f_color = Color.FromArgb(0, 0, 0);
                Color[] season_btn_0 = new Color[3]; Color[] season_btn_1 = new Color[3]; Color[] season_btn_2 = new Color[3];
                season_btn_0[0] = Color.FromArgb(120, 255, 255); season_btn_0[1] = Color.FromArgb(0, 192, 192); season_btn_0[2] = Color.FromArgb(100, 120, 255, 255);
                season_btn_1[0] = Color.FromArgb(155, 255, 30); season_btn_1[1] = Color.FromArgb(94, 192, 30); season_btn_1[2] = Color.FromArgb(100, 155, 255, 30);
                season_btn_2[0] = Color.FromArgb(0, 255, 128); season_btn_2[1] = Color.FromArgb(0, 155, 28); season_btn_2[2] = Color.FromArgb(100, 0, 255, 128);

                this.BackColor = nowseason_b_color; this.ForeColor = nowseason_f_color;

                FormsChange.FlatAppearance.BorderColor = season_btn_0[0];
                FormsChange.FlatAppearance.MouseDownBackColor = season_btn_0[1];
                FormsChange.FlatAppearance.MouseOverBackColor = season_btn_0[2];
                rec_start.FlatAppearance.BorderColor = season_btn_0[0];
                rec_start.FlatAppearance.MouseDownBackColor = season_btn_0[1];
                rec_start.FlatAppearance.MouseOverBackColor = season_btn_0[2];

                openexplorer_rec.FlatAppearance.BorderColor = season_btn_1[0];
                openexplorer_rec.FlatAppearance.MouseDownBackColor = season_btn_1[1];
                openexplorer_rec.FlatAppearance.MouseOverBackColor = season_btn_1[2];
                btn_mute.FlatAppearance.BorderColor = season_btn_1[0];
                btn_mute.FlatAppearance.MouseDownBackColor = season_btn_1[1];
                btn_mute.FlatAppearance.MouseOverBackColor = season_btn_1[2];
                rec_3mh.FlatAppearance.BorderColor = season_btn_1[0];
                rec_3mh.FlatAppearance.MouseDownBackColor = season_btn_1[1];
                rec_3mh.FlatAppearance.MouseOverBackColor = season_btn_1[2];
                /*btn_itunes.FlatAppearance.BorderColor = season_btn_1[0];
                btn_itunes.FlatAppearance.MouseDownBackColor = season_btn_1[1];
                btn_itunes.FlatAppearance.MouseOverBackColor = season_btn_1[2];*/

                //updatelog.FlatAppearance.BorderColor = season_btn_2[0];
                //updatelog.FlatAppearance.MouseDownBackColor = season_btn_2[1];
                //updatelog.FlatAppearance.MouseOverBackColor = season_btn_2[2];
                btn_personal.FlatAppearance.BorderColor = season_btn_2[0];
                btn_personal.FlatAppearance.MouseDownBackColor = season_btn_2[1];
                btn_personal.FlatAppearance.MouseOverBackColor = season_btn_2[2];
                btn_more.FlatAppearance.BorderColor = season_btn_2[0];
                btn_more.FlatAppearance.MouseDownBackColor = season_btn_2[1];
                btn_more.FlatAppearance.MouseOverBackColor = season_btn_2[2];
            }
            

            else { nowseason_b_color = chinatsu_black; nowseason_f_color = chinatsu_white; }
        }

        private void sdvxwin_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*Process[] processifusenjbtmpcht = Process.GetProcessesByName("Nolja_OpenUp");
            if (processifusenjbtmpcht.Length >= 1)
            {
                Process killtask = new Process();
                killtask.StartInfo.FileName = @"C:\Windows\SysWOW64\taskkill.exe";
                killtask.StartInfo.Arguments = "/f /im Nolja_OpenUp.exe";
                try { killtask.Start(); } catch { }
                //C:\Windows\SysWOW64\taskkill.exe /f /im Nolja_OpenUp.exe
                Delay(200);
            }*/
            e.Cancel = true;
        }

        public void GameEndedTimeSet()
        {
            rec_start.Enabled = false;
            FormsChange.Enabled = false;
            btn_mute.Enabled = false;
            rec_3mh.Enabled = false;
        }
    }
}
