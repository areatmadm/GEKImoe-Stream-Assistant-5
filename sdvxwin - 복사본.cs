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

namespace NoljaBroadcast
{
    public partial class sdvxwin_ : Form
    {
        Form PLIVEForm = new plv();
        public static bool PLIVEForm_closed = true;

        Form PlusSettingForm = new plus_settings();
        public static bool PlusSettingForm_closed = true;
        public static bool PS_cam_reset = true; // 기타 캠 모드

        public static double plive_version; //PLIVE Service Version
        public static string nolja_ver;
        public static long nolja_build;

        //NOLJA Broadcast Ver.3.0 Alpha_Test
        //public static bool testver_3 = false;
        public static ChromiumWebBrowser ytvideo = new ChromiumWebBrowser();
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
        public static PrivateFontCollection font_3_0_s = new PrivateFontCollection();

        string set_handfoot;
        int opd = 0;

        //int chk_highlight_beta = 0;

        public static string setgame;

        float obsvol = 0f;
        int chkbeta_mute; //음소거 대상 확인
        public static bool isrecordmod = false;
        public static bool streamstatus = false;

        public sdvxwin_()
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
            string state = "";
            switch (newSceneName)
            {
                case "camon":
                    state = "캠 끄기";
                    break;

                case "camoff":
                    state = "캠 켜기";
                    break;

                default:
                    state = "캠 복귀";
                    break;
            }

            BeginInvoke((MethodInvoker)delegate
            {
                if (newSceneName != "camoff_mute") FormsChange.Text = set_handfoot + state;
                if(state == "camon" || state == "camoff")
                {
                    if (!PlusSettingForm_closed) { plus_settings.rd_cam_mode_0_pub = false; }
                }
            });
        }

        private void onVChanged(object sender, EventArgs e)
        {

        }

        private void onSceneColChange(object sender, EventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                //tbSceneCol.Text = _obs.GetCurrentSceneCollection();
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

        /* private void onStreamingStateChange(OBSWebsocket sender, OutputState newState)
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
            });
        } */

        private void onRecordingStateChange(OBSWebsocket sender, OutputState newState)
        {
            string state = "";
            switch (newState)
            {
                case OutputState.Starting:
                    state = "녹화 시작";
                    break;

                case OutputState.Started:
                    state = "녹화 중지";
                    break;

                case OutputState.Stopping:
                    state = "녹화 중지";
                    break;

                case OutputState.Stopped:
                    state = "녹화 시작";
                    break;

                default:
                    state = "확인 불가";
                    break;
            }

            BeginInvoke((MethodInvoker)delegate
            {
                rec_start.Text = state;

                if(newState == OutputState.Started)
                {
                    if (quick >= 60)
                    {
                        if ((quick % 60) != 0) lbl_rectimer.Text = (quick / 60) + "분 " + (quick % 60) + "초 후 중단됩니다.";
                        else lbl_rectimer.Text = (quick / 60) + "분 후 중단됩니다.";
                    }
                    else lbl_rectimer.Text = quick + "초 후 중단됩니다.";

                    rec_start.Enabled = true;

                    if (!timer_rec.Enabled)
                        timer_rec.Enabled = true;
                }

                else if (newState == OutputState.Stopped)
                {
                    lbl_rectimer.Text = "녹화 가능";

                    rec_start.Enabled = true;

                    rec_start.Enabled = true;
                    if (chkbeta_mute == 1) btn_mute.Enabled = true;
                    rec_3mh.Enabled = true;
                    if (!streamstatus) btn_personal.Enabled = true;
                }

                else if (newState == OutputState.Starting)
                {
                    isrecordmod = true; //녹화 중에는 일부 기능 제한

                    lbl_rectimer.Text = "녹화 준비중...";
                    rec_start.Enabled = false;
                    if (chkbeta_mute == 1) btn_mute.Enabled = false;
                    rec_3mh.Enabled = false;
                    if(!streamstatus) btn_personal.Enabled = false;
                }

                else if (newState == OutputState.Stopping)
                {
                    isrecordmod = false;

                    if (timer_rec.Enabled)
                        timer_rec.Enabled = false;

                    lbl_rectimer.Text = "녹화 저장 중...";
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
            //updatelog_Click(0, e);

            Form d = new DrumChat();
            d.Show();

            Form maintance = new maintaince_check();
            maintance.Show();
        }

        private void sdvxwin_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            this.Text = "놀자 방송 소프트웨어";

            setgame = File.ReadAllText(@"nolja_game_set.txt");

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
           

            set_handfoot = File.ReadAllText(@"ResourceFiles\" + setgame + @"\handfootinfo.otogeonpf");
            //손캠인지 발캠인지 북캠인지 구분해 주는 기능


            if (!ConnectToServer())
            {
                //Application.Restart();
            }

            if (setgame == "6_andamiro_pumpitup")
            {
                try
                {
                    _obs.SetCurrentScene("camoff");
                }
                catch { }
                //FormsChange.Text = set_handfoot + "캠 켜기";
                FormsChange.Enabled = false;
            }

            string nowscene;
            nowscene = _obs.GetCurrentScene().Name;
            if(nowscene == "camon") { FormsChange.Text = set_handfoot + "캠 끄기"; }
            else if (nowscene=="camoff") { FormsChange.Text = set_handfoot + "캠 켜기"; }
            else if (nowscene == "camoff_mute") { FormsChange.Text = set_handfoot + "캠 켜기"; }
            else FormsChange.Text = set_handfoot + "캠 복귀";

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
            
            nolja_ver = "3.0-Beta_6_A";
            nolja_build = 202009140812;
            
            lbl_version.Text = "Ver." + nolja_ver + " | " + nolja_build;
            plive_version = 0.12; //PLIVE 모듈 버전

            //NOLJA New Fonts_Kakao NOLNABroadcast 3.0
            font_3_0_s.AddFontFile(@"font_3.0\kakao\KakaoBold.ttf");
            font_3_0_s.AddFontFile(@"font_3.0\kakao\KakaoRegular.ttf");

            nowseason = true;

            //NOLJA BlackEdition NoljaBroadcast 3.0
            NOLJA_Black_Edition();


            timer_viewer.Enabled = false;
        }


        private void FormsChange_Click(object sender, EventArgs e)
        {
            //if (!PS_cam_reset) { _obs.SceneChanged -= onSceneChange; _obs.SceneChanged += onSceneChange; PS_cam_reset = true; }

            //scenechanged로 이동
            string nowscene;
            nowscene = _obs.GetCurrentScene().Name;

            if (nowscene == "camon")
            {
                _obs.SetCurrentScene("camoff");
                //FormsChange.Text = set_handfoot + "캠 켜기";
            }
            else
            {
                _obs.SetCurrentScene("camon");
                //FormsChange.Text = set_handfoot + "캠 끄기";
            }
        }

        int quick = 750;
        int qtemp;

        private void rec_start_Click(object sender, EventArgs e)
        {
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
                quick = 750;
            }
        }

        private void openexplorer_rec_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(_obs.GetRecordingFolder());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }

        private void btn_itunes_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(_obs.GetRecordingFolder());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
            Form d = new howtomoveios();
            d.ShowDialog();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.webBrowser1.Document.Window.ScrollTo(255, 390);
        }

        private void NOLJA_Black_Edition()
        {
            nowseason_check();

            Font kakao_r_16 = new Font(font_3_0_s.Families[0], 15f);
            Font kakao_r_12 = new Font(font_3_0_s.Families[0], 12f);

            FormsChange.Font = kakao_r_16;
            rec_start.Font = kakao_r_16;


            openexplorer_rec.Font = kakao_r_16;
            btn_mute.Font = kakao_r_16;
            btn_itunes.Font = kakao_r_16;

            rec_3mh.Font = kakao_r_12;
            updatelog.Font = kakao_r_12;
            btn_personal.Font = kakao_r_12;
            btn_more.Font = kakao_r_12;

            lbl_linkinfo.Font = new Font(font_3_0_s.Families[0], 18f);

            lbl_rectimer.Font = new Font(font_3_0_s.Families[1], 12f);
            lbl_version.Font = new Font(font_3_0_s.Families[1], 11.25f);

            var settings = new CefSettings();
            settings.BrowserSubprocessPath = System.IO.Path.GetFullPath("CefSharp.BrowserSubprocess.exe");
            //settings.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:68.0) Gecko/20100101 Firefox/68.0";
            settings.CefCommandLineArgs["autoplay-policy"] = "no-user-gesture-required";
            settings.Locale = "KO_KR";
            settings.CachePath = System.IO.Path.GetFullPath("cache_drumchat");

            if (CefSharp.Cef.IsInitialized == false)
                CefSharp.Cef.Initialize(settings);

            
            ytvideo.Load("file:///" + ytvd_pt.Replace(@"\", "/") + "/index.html");

            ytvideo.Dock = DockStyle.None;
            ytvideo.Size = new Size(368, 207);
            ytvideo.Location = new Point(16, 337);
            ytvideo.BackColor = chinatsu_black;
            this.Controls.Add(ytvideo);
            ytvideo.Enabled = false;
            //lbl_info.Visible = false;

            NOLJA_Edition_Statechange();
        }

        private void NOLJA_Edition_Statechange()
        {
            if (rec_start.Enabled) rec_start.BackColor = nowseason_b_color; else rec_start.BackColor = chinatsu_disabled;
            if (FormsChange.Enabled) FormsChange.BackColor = nowseason_b_color; else FormsChange.BackColor = chinatsu_disabled;
            if (openexplorer_rec.Enabled) openexplorer_rec.BackColor = nowseason_b_color; else openexplorer_rec.BackColor = chinatsu_disabled;
            if (btn_mute.Enabled) btn_mute.BackColor = nowseason_b_color; else btn_mute.BackColor = chinatsu_disabled;
            if (btn_itunes.Enabled) btn_itunes.BackColor = nowseason_b_color; else btn_itunes.BackColor = chinatsu_disabled;
            if (updatelog.Enabled) updatelog.BackColor = nowseason_b_color; else updatelog.BackColor = chinatsu_disabled;
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
        private void btn_itunes_EnabledChanged(object sender, EventArgs e) //애플기기로 옮기기 버튼 상태 변경 시 작동되는 코드
        {
            if (btn_itunes.Enabled) btn_itunes.BackColor = nowseason_b_color;
            else btn_itunes.BackColor = chinatsu_disabled;
        }
        private void updatelog_EnabledChanged(object sender, EventArgs e) //업데이트 로그 버튼 상태 변경 시 작동되는 코드
        {
            if (updatelog.Enabled) updatelog.BackColor = nowseason_b_color;
            else updatelog.BackColor = chinatsu_disabled;
        }
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
                if ((qtemp % 60) != 0) lbl_rectimer.Text = (qtemp / 60) + "분 " + (qtemp % 60) + "초 후 중단됩니다.";
                else lbl_rectimer.Text = (qtemp / 60) + "분 후 중단됩니다.";
            }
            else lbl_rectimer.Text = qtemp + "초 후 중단됩니다.";


            if (qtemp == 0)
            {
                lbl_rectimer.Text = "";
                if (isrecordmod)
                {
                    quick = 750;
                    _obs.StopRecording();
                }
                else
                {
                    
                }
            }
        }

        int viewertimer = 4;
        int vitemp;
        private void timer_viewer_Tick(object sender, EventArgs e)
        {
            viewertimer--;
            vitemp = viewertimer / 1;
            if (vitemp == 0)
            {
                webBrowser1.Refresh();
                viewertimer = 4;
            }
        }

        private void btn_openchat_Click(object sender, EventArgs e)
        {
            //if (!PS_cam_reset) { _obs.SceneChanged -= onSceneChange; _obs.SceneChanged += onSceneChange; PS_cam_reset = true; }
            //_obs.Disconnect();
            Form p = new howtochat();
            p.ShowDialog();
        }

        private void updatelog_Click(object sender, EventArgs e)
        {
            Form d = new drumwin();
            d.ShowDialog();
        }

        private void setpersonalbroadcast_Click(object sender, EventArgs e)
        {
            //개인방송 설정이 아닌 하이라이트 설정입니다.
            if(setgame != "6_andamiro_pumpitup") FormsChange.Enabled = false;
            if (chkbeta_mute == 1) btn_mute.Enabled = false;
            rec_start.Enabled = false; openexplorer_rec.Enabled = false; btn_itunes.Enabled = false;
            updatelog.Enabled = false; rec_3mh.Enabled = false; btn_personal.Enabled = false; btn_more.Enabled = false;
            lbl_rectimer.Text = "하이라이트 저장 중...";

            try
            {
                _obs.SaveReplayBuffer();
            }
            catch
            {
                lbl_rectimer.Text = "하이라이트 저장 중 오류 발생! 관리자에게 문의 요망";
            }
            Delay(2500);

            if (setgame != "6_andamiro_pumpitup") FormsChange.Enabled = true;
            if (chkbeta_mute == 1) btn_mute.Enabled = true;
            rec_start.Enabled = true; openexplorer_rec.Enabled = true; btn_itunes.Enabled = true;
            updatelog.Enabled = true; rec_3mh.Enabled = true; btn_personal.Enabled = true; btn_more.Enabled = true;
            lbl_rectimer.Text = "녹화 가능";
        }

        public static void openupdate_promotionvideo()
        {
            Form obd = new update_noljaprom();
            obd.ShowDialog();
        }
        
        public static void openupdate_njb()
        {
            Form obd = new update_noljabroadcast();
            obd.ShowDialog();
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
            if (nowseason) { nowseason_b_color = Color.FromArgb(204, 255, 204); nowseason_f_color = Color.FromArgb(0, 0, 0);
                this.BackColor = nowseason_b_color; this.ForeColor = nowseason_f_color;
            }
            //2020.9.17 ~ 2020.9.24 기간 한정 컬러셋 적용
            else { nowseason_b_color = chinatsu_black; nowseason_f_color = chinatsu_white; }
        }
    }
}
