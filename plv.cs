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
//using nolja_rtmp;

namespace AreaTM_acbas
{
    public partial class plv : Form
    {
        int maxtime = 2400;
        int now = 0;
        int npow = 0;

        bool oldalphauser = true;

        public static bool toonation = false;
        string plivecode = "500";

        string rtmp_service;

        //plive 브라우저 로드 코드
        public static string browser_urlload = "";
        public static string browser_name = "";

        string thisisnull;

        Size original_size;

        PictureBox splashpic = new PictureBox();

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



        public plv()
        {
            InitializeComponent();
        }

        private void btn_alpah_code_send_Click(object sender, EventArgs e)
        {
            if (sdvxwin.streamstatus == false)
            {
                thisisnull = GetHtmlString("https://nolja.bizotoge.areatm.com/public/plive/user/usr_sync.php?game=" + sdvxwin.setgame + "&isclr=1");//db청소

                //브라우저 설정 후 입장
                browser_name = "PLIVE MultiStream 인증코드 입력";
                browser_urlload = "https://nolja.bizotoge.areatm.com/public/plive/user";
                Form auth_plive = new plv_settings_toonat_win();
                auth_plive.ShowDialog();

                //브라우저 정보 초기화
                browser_urlload = "";
                browser_name = "";

                string pd = GetHtmlString("https://nolja.bizotoge.areatm.com/public/plive/user/usr_sync.php?game=" + sdvxwin.setgame);
                if (pd == "OK")
                {
                    /*string pd_name = GetHtmlString("https://nolja.bizotoge.areatm.com/public/plive/user/" + sdvxwin.setgame + "/?pcode=" + plivecode + 
                        "&mode=1");
                    MessageBox.Show(pd_name + "님 환영합니다. 마지막 항목을 입력해주세요."); */
                    oldalphauser = true;
                    Alpha_Open();
                }
                else if (pd == "OK_TEST")
                {
                    int pd_timelimit = 3600;
                    //if (sdvxwin.setgame == "5_konami_sdvx") pd_timelimit = 1200;
                    maxtime = pd_timelimit;
                    MessageBox.Show("환영합니다!" + "\r\n" + "현재 관리자의 요청으로 MultiStream 세션 시간제한이 걸려 있습니다." + "\r\n" + 
                        "(" + (pd_timelimit/60) + "분 후 MultiStream 강제종료됨)");
                        
                    Alpha_Open();
                }
                else if (pd == "NO")
                {
                    plivecode = "";
                    /*MessageBox.Show("인증에 실패하였습니다." + "\r\n" + 
                        "PLIVE 서비스 회원이면 핀번호를 다시 입력해주세요. 지속적인 인증 실패 시 soruto@kakao.com으로 메일 발송 바랍니다.");*/
                }
                else if (pd == "NO_BAN")
                {
                    plivecode = "";
                    /*MessageBox.Show("인증에 실패하였습니다." + "\r\n" +
                        "해당 회원은 놀자 PLIVE 서비스 이용규정을 위반하여 계정 사용이 중지되었습니다.");*/
                }
                else if (pd == "____________ERROR_DBSERVER")
                {
                    plivecode = "";
                    MessageBox.Show("서버 접속에 실패하였습니다." + "\r\n" +
                        "DB 서버에 문제가 발생하였습니다. soruto@kakao.com으로 문의 바랍니다[아레아티엠 게키모에 PLIVE 운영팀]");
                }
                else
                {
                    plivecode = "";
                    MessageBox.Show("서버 문제로 인증에 실패하였습니다. 잠시 후 다시 입력해주세요.");
                }
            }

            else
            {
                exitstreaming();
                this.Close();
            }
        }

        private void Alpha_Open()
        {
            //btn_alpah_code_send.Enabled = false;
            btn_set_service.Enabled = true;

            //btn_getstreamkey.Enabled = true;
            //btn_setting.Enabled = true;
        }

        private void Stream_Start()
        {
            string nginx_conf = "";
            string pda;
            /*string youtube_rtmp = "rtmp://a.rtmp.youtube.com/live2/";
            string twitch_rtmp = "rtmp://live-sel.twitch.tv/app/";
            string restream_seoul_rtmp = "rtmp://seoul.restream.io/live/";
            string restream_tokyo_rtmp = "rtmp://tokyo.restream.io/live/";*/

            string rtmp_default = "";

            //pda = File.ReadAllText("nginx_rtmp_header");
            pda = "ffmpeg -i rtmp://127.0.0.1:1935/live/live -c copy ";

            rtmp_default = GetHtmlString("https://nolja.bizotoge.areatm.com/public/plive/plive_rtmp.php?ngame=" + sdvxwin.setgame + 
                "&ver=" + sdvxwin.plive_version);
            

            if (rtmp_default == "")
            {
                MessageBox.Show("서버 문제가 발생하였습니다. 불편을 드려 죄송합니다.");
                this.Close();
            }
            else
            {
                //방송 시스템 가동 준비
                nginx_conf += pda;

                //오락실 공용 rtmp 삽입
                nginx_conf += "-f flv " + rtmp_default + " ";
                //nginx_conf += @"            push " + rtmp_default + ";" + "\r\n";

                //테스트 시에만 해당 코드 활성화 하세요
                //nginx_conf += @"            push " + "rtmp://a.rtmp.youtube.com/live2/dsfsf" + ";" + "\r\n";

                //nginx_conf += @"            push ";
                nginx_conf += "-f flv ";

                /*twitch, youtube, restreamio(Seoul/Tokyo) 구분하기 (~2020.10.15)
                if (rd_youtube.Checked) nginx_conf += youtube_rtmp;
                else if(rd_twitch.Checked) nginx_conf += twitch_rtmp;
                else if(rd_restreamio.Checked) nginx_conf += restream_seoul_rtmp;*/

                //2020.10.16부터 적용되는 새로운 방식
                nginx_conf += "rtmp://" + rtmp_service + "/";

                //nginx_conf += txt_stream.Text + ";" + "\r\n";
                nginx_conf += txt_stream.Text;

                //pda = File.ReadAllText("nginx_rtmp_footer");
                //nginx_conf += pda;

                txt_stream.Text = "";
                txt_stream.Enabled = false;
                btn_livestart.Text = "스트리밍 종료";
                btn_livestart.Enabled = false;
                //btn_setting.Enabled = false;
                btn_set_service.Enabled = false;
                url_inform.Enabled = false;

                btn_getstreamkey.Enabled = false;

                lbl_nowstatus.Text = "스트리밍 준비중";
                btn_close.Enabled = false;

                try { sdvxwin._obs.StopStreaming(); } catch { }
                sdvxwin.streamstatus = true;

                //Delay(3500);
                //lbl_nowstatus.Text = "PLIVE MultiStream 모듈 일시 중단...";
                //Process.Start(@"nginxstop.lnk");

                Delay(500);
                //File.WriteAllText(@"C:\nginx-rtmp-win32-dev\conf\nginx.conf", nginx_conf);
                File.WriteAllText(@"C:\MonaServer\ffmpeg_start.bat", nginx_conf);
                lbl_nowstatus.Text = "PLIVE MultiStream 모듈 설정값 적용 중...";

                Delay(1600);
                //Process.Start(@"nginx.lnk");
                //lbl_nowstatus.Text = "PLIVE MultiStream 모듈 재시작 중...";
                thisisnull = GetHtmlString("https://nolja.bizotoge.areatm.com/public/plive/user/" + sdvxwin.setgame + "/?pcode=" + plivecode + 
                            "&mode=2");

                //방송 시스템 시작(모든 과정이 정상일 경우)
                Delay(1400);
                sdvxwin._obs.StartStreaming();

                btn_livestart.Enabled = true;
                timer1.Enabled = true;
                //btn_setting.Enabled = true;
                if(oldalphauser) url_inform.Enabled = true;
            }
            
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show(now + "");
            string ifhour = "";
            if (npow >= 3600) ifhour = ((npow / 60) / 60) + "시간 " + ((npow / 60) % 60) + "분 ";
            else ifhour = (npow / 60) + "분 ";
            lbl_nowstatus.Text = ifhour + (npow % 60) + "초 동안 방송중";
            //lbl_nowstatus.Text = npow + "";


            
            if (oldalphauser == false && npow > maxtime)
            {
                timer1.Enabled = false;
                //this.Show();
                lbl_nowstatus.Text = "시간초과로 방송 종료중...";
                btn_livestart.Text = "방송 미러링 시작";
                exitstreaming();
                this.Close();
            }


            //now += 60;
            now++;
            npow = now / 2;
        }

        private void plv_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Enabled = false;

            vis_invis(false);

            //original_size = this.Size;
            original_size = new Size();
            original_size.Height = this.Size.Height;
            original_size.Width = this.Size.Width;

            Size custom_size = new Size();
            custom_size.Height = 257;
            custom_size.Width = 600;

            this.Size = custom_size;
            this.FormBorderStyle = FormBorderStyle.None;

            splashpic.Size = custom_size;
            splashpic.Image = Properties.Resources.nolja_plive_window;
            this.Controls.Add(splashpic);
        }

        private void plv_Activate(object sender, EventArgs e)
        {
            Delay(1500);
            this.Hide();
            thisisnull = GetHtmlString("https://nolja.bizotoge.areatm.com/public/plive/channel_noti/chnoti_del.php?game=" + sdvxwin.setgame);

            vis_invis(true);
            this.Controls.Remove(splashpic);
                
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Size = original_size;

            NOLJA_BlackEdition_Set();
            NOLJA_Edition_statechange(null,null);

            Delay(300);
            this.Show();
            
            lbl_nowstatus.Text = "PLIVE MultiStream 서비스 이용 가능여부 확인 중...";
            
            //btn_alpah_code_send.Enabled = false;
            btn_set_service.Enabled = false;
            Delay(300);

            //if (File.Exists(@"C:\nginx-rtmp-win32-dev\nginx.exe"))
            if (File.Exists(@"C:\MonaServer\MonaServer.exe") && File.Exists(@"C:\MonaServer\ffmpeg.exe") && File.Exists(@"C:\MonaServer\ffprobe.exe")) //신 모듈
            {
                lbl_nowstatus.Text = "PLIVE MultiStream 모듈 발견. 다음 단계로 이동 중...";
                Delay(500);

                plv_NeXT();
            }
            else
            {
                lbl_nowstatus.Text = "PLIVE MultiStream 모듈이 없어 해당기능 사용 불가";
                MessageBox.Show("해당 게임의 스트리밍 PC에는 PLIVE MultiStream 모듈이 아직 설치되어 있지 않아 해당 서비스의 이용이 불가합니다. 설치를 원하시는 경우, 업주를 통해 아레아티엠 고객센터로 문의 바랍니다.(B2B전용 고객센터로 문의)");
                this.Close();
            }
            
        }
        
        private void vis_invis(bool viin)
        {
            if (!viin)
            {
                lbl_info_0.Visible = false;
                lbl_info_1.Visible = false;
                lbl_nowstatus.Visible = false;
                //lbl_put_alpahcode.Visible = false;
                lbl_streamkey.Visible = false;

                //btn_alpah_code_send.Visible = false;
                btn_set_service.Visible = false;
                btn_close.Visible = false;
                btn_getstreamkey.Visible = false;
                btn_livestart.Visible = false;
                //btn_setting.Visible = false;
                
                txt_stream.Visible = false;
            }

            if (viin)
            {
                lbl_info_0.Visible = true;
                lbl_info_1.Visible = true;
                lbl_nowstatus.Visible = true;
                //lbl_put_alpahcode.Visible = true;
                lbl_streamkey.Visible = true;

                //btn_alpah_code_send.Visible = true;
                btn_set_service.Visible = true;
                btn_close.Visible = true;
                btn_getstreamkey.Visible = true;
                btn_livestart.Visible = true;
                //btn_setting.Visible = true;
                
                txt_stream.Visible = true;
            }
        }

        private void plv_NeXT()
        {
            lbl_nowstatus.Text = "PLIVE MultiStream 이용 가능여부 서버에서 확인 중...";

            string statusp;
            statusp = GetHtmlString("https://nolja.bizotoge.areatm.com/public/plive/status/status_user_sync_.php?game=" + sdvxwin.setgame + 
                "&ver=" + sdvxwin.plive_version);
            if (statusp == "OK" || statusp == "OK_MSG")
            {
                Delay(500);
                lbl_nowstatus.Text = "준비";
                
                //btn_alpah_code_send.Enabled = true;

                if (statusp == "OK_MSG")
                {
                    //브라우저 설정 후 입장
                    browser_name = "PLIVE MultiStream 안내";
                    browser_urlload = "https://nolja.bizotoge.areatm.com/public/plive/status";
                    Form auth_plive = new plv_settings_toonat_win();
                    auth_plive.ShowDialog();

                    //브라우저 정보 초기화
                    browser_urlload = "";
                    browser_name = "";

                    this.Focus();
                }
                VIDEO_on.plive = true;
                btn_set_service.Enabled = true;
            }
            else
            {
                Delay(500);
                lbl_nowstatus.Text = "이용 불가";
                if (statusp == "NO_MSG")
                {
                    //브라우저 설정 후 입장
                    browser_name = "PLIVE MultiStream 안내";
                    browser_urlload = "https://nolja.bizotoge.areatm.com/public/plive/status";
                    Form auth_plive = new plv_settings_toonat_win();
                    auth_plive.ShowDialog();

                    //브라우저 정보 초기화
                    browser_urlload = "";
                    browser_name = "";
                }

                this.Focus();
                MessageBox.Show("현재 해당 게임은 PLIVE MultiStream 이용이 불가합니다.");
                this.Close();
            }
        }

        private void NOLJA_BlackEdition_Set()
        {
            //this.Font = new Font(sdvxwin.font_3_0_s.Families[1], 10f);

            lbl_info_0.Font = new Font(sdvxwin.font_5_0_r.Families[0], 10f);
            lbl_info_1.Font = new Font(sdvxwin.font_5_0_r.Families[0], 10f);
            lbl_nowstatus.Font = new Font(sdvxwin.font_5_0_r.Families[0], 10f);
            //lbl_put_alpahcode.Font = new Font(sdvxwin.font_3_0_s.Families[1], 10f);
            lbl_streamkey.Font = new Font(sdvxwin.font_5_0_r.Families[0], 10f);
            
            txt_stream.Font = new Font(sdvxwin.font_5_0_r.Families[0], 10f);

            //btn_alpah_code_send.Font = new Font(sdvxwin.font_3_0_s.Families[1], 10f);
            btn_set_service.Font = new Font(sdvxwin.font_5_0_r.Families[0], 10f);
            btn_close.Font = new Font(sdvxwin.font_5_0_r.Families[0], 10f);
            btn_getstreamkey.Font = new Font(sdvxwin.font_5_0_r.Families[0], 10f);
            btn_livestart.Font = new Font(sdvxwin.font_5_0_r.Families[0], 10f);
            //btn_setting.Font = new Font(sdvxwin.font_3_0_s.Families[1], 10f);

            url_inform.Font = new Font(sdvxwin.font_5_0_r.Families[0], 10f);
        }

        private void NOLJA_Edition_statechange(object sender, EventArgs e)
        {
            if (txt_stream.Enabled)
            {
                txt_stream.ForeColor = sdvxwin.chinatsu_white;
                txt_stream.BackColor = sdvxwin.chinatsu_black;
            }
            else
            {
                txt_stream.ForeColor = sdvxwin.chinatsu_black;
                txt_stream.BackColor = sdvxwin.chinatsu_disabled;
            }
        }

        private void plv_Closing(object sender, FormClosingEventArgs e)
        {
            if(sdvxwin.streamstatus == true)
            {
                exitstreaming();
            }

            thisisnull = GetHtmlString("https://nolja.bizotoge.areatm.com/public/plive/user/usr_sync.php?game=" + sdvxwin.setgame + "&isclr=1");//db청소
            thisisnull = GetHtmlString("https://nolja.bizotoge.areatm.com/public/plive/channel_noti/chnoti_del.php?game=" + sdvxwin.setgame); //안내청소

            VIDEO_on.plive = false;
            sdvxwin.PLIVEForm_closed = true;
            //timer1.Enabled = false;
        }

        private void exitstreaming()
        {
            thisisnull = GetHtmlString("https://nolja.bizotoge.areatm.com/public/plive/channel_noti/chnoti_del.php?game=" + sdvxwin.setgame);

            //방송 종료 프로세스
            timer1.Enabled = false;
            btn_livestart.Enabled = false;
            btn_close.Enabled = false;
            //btn_setting.Enabled = false;
            url_inform.Enabled = false;

            try
            {
                sdvxwin._obs.StopStreaming();
            }
            catch { }
            Delay(3500);
            Process.Start(@"nginxstop.lnk");
            thisisnull = GetHtmlString("https://nolja.bizotoge.areatm.com/public/plive/user/" + sdvxwin.setgame + "?pcode=" + plivecode +
                            "&mode=3");
            if (toonation)
            {
                string scenename = sdvxwin._obs.GetCurrentScene().Name; //직전 장면 이름 구하기

                //toonation off scene 설정 코드 시작
                sdvxwin._obs.SetCurrentScene("toon_off");
                //toonation off scene 설정 코드 종료

                Delay(1240);
                sdvxwin._obs.SetCurrentScene(scenename);
                toonation = false;
                //Delay(1240);
            }
            Delay(1700);
            //Process.Start(@"nginxrollback.bat");
            File.Copy(@"C:\MonaServer\ffmpeg_start.bat.bak", @"C:\MonaServer\ffmpeg_start.bat", true);
            Delay(2000);
            //Process.Start(@"nginx.lnk");
            
            Delay(1500);

            sdvxwin.streamstatus = false;
            NOLJA_ReStream.ChkIfStreamisNeedRestart();
            /*
            lbl_nowstatus.Text = "대기";
            btn_alpah_code_send.Enabled = true;
            now = 0;
            npow = 0;

            btn_close.Enabled = true;
            */
        }

        private void btn_livestart_Click(object sender, EventArgs e)
        {
            if (sdvxwin.streamstatus == false && txt_stream.Text == "") MessageBox.Show("스트림 키를 입력해주세요!");
            else if (sdvxwin.streamstatus == false) Stream_Start();
            else if (sdvxwin.streamstatus == true)
            {
                lbl_nowstatus.Text = "스트리밍 종료 중...";
                exitstreaming();
                this.Close();
            }
        }

        private void btn_getstreamkey_Click(object sender, EventArgs e)
        {
            Process chr = new Process();
            /*string pm = "https://areatm.com/";

            if (rd_youtube.Checked) pm += "1690";
            else if (rd_twitch.Checked) pm += "1838";
            else if (rd_restreamio.Checked) pm += "1864";
            ~ 2020.10.16
            */

            string pm = "https://geki.moe/nolja_plive/howtoset_rtmp?serv=" + rtmp_service;
            //서비스별 사용법이 다르므로 서비스에 맞는 사용법 알려주기

            if (File.Exists(@"C:\Program Files (x86)\Naver\Naver Whale\Application\whale.exe")) chr.StartInfo.FileName = @"C:\Program Files (x86)\Naver\Naver Whale\Application\whale.exe";
            else if (File.Exists(@"C:\Program Files\Naver\Naver Whale\Application\whale.exe")) chr.StartInfo.FileName = @"C:\Program Files\Naver\Naver Whale\Application\whale.exe";
            else if (File.Exists(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe")) chr.StartInfo.FileName = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
            else if (File.Exists(@"C:\Program Files\Google\Chrome\Application\chrome.exe")) chr.StartInfo.FileName = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            else { }
            chr.StartInfo.Arguments = "--incognito " + pm;
            try { chr.Start(); } catch { };
        }

        private void btn_set_service_Click(object sender, EventArgs e)
        {
            //2020년 10월 16일부터 새롭게 적용된 스트림 서비스 선택기 작동

            //브라우저 설정 후 입장
            browser_name = "PLIVE MultiStream 스트림 서비스 선택";
            browser_urlload = "https://nolja.bizotoge.areatm.com/public/plive/rtmpset";
            Form auth_plive = new plv_settings_toonat_win();
            auth_plive.ShowDialog();

            //브라우저 정보 초기화
            browser_urlload = "";
            browser_name = "";

            string getp = GetHtmlString("https://nolja.bizotoge.areatm.com/public/plive/rtmpset/rtmpset_sync_.php?game=" + sdvxwin.setgame);
            bool result_p = false;
            if (getp == "OK") result_p = true;

            if (result_p) //성공일 때
            {
                btn_set_service.Text = "플랫폼 다시 선택하기";
                rtmp_service = GetHtmlString("https://nolja.bizotoge.areatm.com/public/plive/rtmpset/rtmpset_sync.php?game=" + sdvxwin.setgame);

                txt_stream.Enabled = true;
                btn_getstreamkey.Enabled = true;
                btn_livestart.Enabled = true;
                if (oldalphauser) url_inform.Enabled = true;
            }
        }

        private void url_inform_Click(object sender, EventArgs e)
        {
            //2020년 10월 16일부터 새롭게 적용된 스트림 서비스 선택기 작동

            //브라우저 설정 후 입장
            browser_name = "PLIVE MultiStream 알리미 서비스";
            browser_urlload = "https://nolja.bizotoge.areatm.com/public/plive/channel_noti";
            Form auth_plive = new plv_settings_toonat_win();
            auth_plive.ShowDialog();

            //브라우저 정보 초기화
            browser_urlload = "";
            browser_name = "";
        }
    }
}
