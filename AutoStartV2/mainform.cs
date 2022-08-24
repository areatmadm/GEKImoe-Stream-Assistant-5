using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

using OBSWebsocketDotNet;
using OBSWebsocketDotNet.Types;

namespace AutoStartV2
{
    public partial class AutoStartV2Main : Form
    {
        public string p;
        public string gc_name;
        public string game_name;

        bool plive_available = false;

        protected OBSWebsocket _obs;

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

        public AutoStartV2Main()
        {
            InitializeComponent();
        }

        void isPliveAvailable_Alpha()
        {
            if (File.Exists(@"C:\nginx-rtmp-win32-dev\nginx.exe"))
            {
                plive_available = true;
            }
            else plive_available = false;
        }

        private void AutoStartV2Main_Load(object sender, EventArgs e)
        {
            lbl_nowver.Text = "2.4_B_20200830";

            lbl_information.Text = "이 창이 닫히기 전까지 절대로 PC를 조작하지 마시오." + "\r\n"
                + "Do NOT distrub this computer before this window is closing.";

            try
            {
                gc_name = "놀자";

                p = File.ReadAllText(@"nolja_game_set.txt");
                game_name = File.ReadAllText(@"ResourceFiles\" + p + @"\gamename.otogeonpf");
            }
            catch
            {
                MessageBox.Show("에러가 발생하여 방송기기 부팅이 불가합니다. 카운터로 문의 바랍니다.");
                this.Close();
            }

            lbl_name.Text = gc_name + " " + game_name + " 방송기기 준비중";
        }

        private void AutoStartV2Main_Activate(object sender, EventArgs e)
        {
            pg.Text = "잠시만 기다려주세요...";
            Delay(5000);

            if(p== "1_namco_taiko")
            {
                pg.Text = "태고 방송 필수 프로그램 실행 중...";
                Process.Start(@"iiui.lnk");
                Delay(7000);
            }
            
            pg.Text = "OBS Studio (amd64)를 시작하는 중...";
            Process.Start(Path.GetFullPath(@"autoobs.lnk"));
            Delay(8000);

            //NOLJA Popn only start
            if (p == "5_konami_popn")
            {
                pg.Text = "팝픈뮤직 화면 조정 중...";
                Process.Start(Path.GetFullPath(@"iiui.lnk"));
                Delay(6000);

                pg.Text = "화면조정 프로세스 종료 중...";
                Process.Start(Path.GetFullPath(@"exitprocess.bat"));

                Delay(6000);
            }
            //NOLJA Popn only end

            int pa = 0;
            while(pa == 0)
            {
                pg.Text = "프로세스 찾는 중...";
                Process[] processList = Process.GetProcessesByName("obs64");
                if (processList.Length >= 1) pa = 1;
                Delay(1500);
            }

            pg.Text = "OBS Studio를 찾았습니다!";
            Delay(1500);

            pg.Text = "놀자 PLIVE(알파테스트) 서비스 가능 여부 확인 중...";
            isPliveAvailable_Alpha();
            Delay(1000);

            if (plive_available)
            {
                pg.Text = "놀자 PLIVE 설정값 초기화 중...";
                Process.Start(@"nginxrollback.bat");
                Delay(3000);

                pg.Text = "놀자 PLIVE 시스템 시작 중...";
                Process.Start(@"nginx.lnk");
                Delay(2000);
            }
            else
            {
                pg.Text = "놀자 PLIVE 모듈이 없습니다. 계속 진행합니다.";
                Delay(2000);
            }

            pg.Text = "소켓 테스트 진행";

            _obs = new OBSWebsocket();
            Delay(1890);

            try
            {
                _obs.Connect("ws://127.0.0.1:4444", "noljabroadcastpc");
                //_obs.Connect("ws://127.0.0.1:4444", "geosungbroadcastpc");

                pg.Text = "소켓을 찾았습니다";
                Delay(1720);

                pg.Text = "웹캠 초기화 중... 깜빡 거릴 수 있습니다";

                string nowscene;
                nowscene = _obs.GetCurrentScene().Name;
                if (nowscene != "camoff")
                {
                    _obs.SetCurrentScene("camoff");
                    Delay(1000);
                    _obs.SetCurrentScene(nowscene);
                    Delay(1000);
                }

                else
                {
                    if (p == "6_andamiro_pumpitup") _obs.SetCurrentScene("camoff");
                    //20200825부터 일시적으로 Pump It Up의 캠 사용을 제한함

                    else _obs.SetCurrentScene("camon");
                    Delay(1000);
                }

                pg.Text = "스트리밍을 시작합니다";
                _obs.StartStreaming();
                Delay(2890);


            }
            catch
            {
                MessageBox.Show("에러가 발생하였습니다.\r\n관리자 호출 또는 soruto@kakao.com으로 메일 부탁드립니다.");
            }

            pg.Text = "작업 완료! 잠시만 기다려 주세요...";
            Delay(4000);

            Process.Start(Path.GetFullPath(@"NoljaBroadcast.exe"));

            pg.Text = "아케이드 스트리밍 시스템 시작";
            Delay(2000);

            //pg.Text = "놀자 코로나19 알리미 프로그램 실행";
            //Process.Start(@"Nolja_covid19.exe");
            //Delay(2000);

            this.Close();
        }
    }
}
