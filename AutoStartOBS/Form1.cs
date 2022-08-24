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

using OBSWebsocketDotNet;
using OBSWebsocketDotNet.Types;

namespace AutoStartOBS
{
    public partial class AutoStart_Nolja : Form
    {
        int opd = 0;
        public AutoStart_Nolja()
        {
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

        private void Nolja_AutoStart_Load(object sender, EventArgs e)
        {
            //this.Activated += AfterLoading;

            //Process.Start(@"autoobs.ink");
        }

        private void Nolja_AutoStart_Activate(object sender, EventArgs e)
        {
            if (opd == 0)
            {
                //this.Activated -= AfterLoading;
                //Write your code here.
                
                Nolja_AutoStart_Shown();
                opd++;
            }
        }

        protected OBSWebsocket _obs;

        private void Nolja_AutoStart_Shown()
        {
            pb.Maximum = 10;
            pb.Value = 0;

            pg.Text = "Initializing...";
            //Process.Start(@"iiui.lnk");
            //Taiko Only
            Delay(10000);
            //MessageBox.Show("dfdf");
            pg.Text = "Start OBS Studio (amd64)";
            pb.Value++; // 1/10

            Process.Start(@"autoobs.lnk");
            Delay(10000);

            //Popn only start
            pg.Text = "Initializing Pop'n Music Screen...";
            Process.Start(@"iiui.lnk");
            Delay(10000);

            pg.Text = "kill...";
            Process.Start(@"exitprocess.bat");

            Delay(10000);
            //popn only end

            Process[] processList = Process.GetProcessesByName("obs64");
            pg.Text = "Finding Process...";
            pb.Value++; // 2/10
            while (processList.Length < 1)
            {
                Delay(2500);
            }
            pg.Text = "Find OBS";
            pb.Value++; // 3/10
            Delay(2000);

            _obs = new OBSWebsocket();

            pg.Text = "Socket Test";
            pb.Value++; // 4/10

            Delay(1890);
            try
            {
                _obs.Connect("ws://127.0.0.1:4444", "noljabroadcastpc");
                //_obs.Connect("ws://127.0.0.1:4444", "geosungbroadcastpc");

                pg.Text = "Find Socket";
                Delay(2000);

                pg.Text = "Cam Initializing...";

                string nowscene;
                nowscene = _obs.GetCurrentScene().Name;
                if (nowscene != "camoff")
                {
                    _obs.SetCurrentScene("camoff");
                    Delay(1000);
                    _obs.SetCurrentScene(nowscene);
                    Delay(1000);
                }

                else Delay(2000);

                pg.Text = "Start Streaming...";
                Delay(2890);
                
                _obs.StartStreaming();

            }
            catch(Exception e)
            {
                MessageBox.Show("에러가 발생하였습니다.\r\n관리자 호출 또는 050-6522-9446으로 문자 부탁드립니다.");
            }

            pg.Text = "Socket Test Complete";
            pb.Value++; // 5/10

            Delay(1300);
            _obs.Disconnect();
            pg.Text = "Socket Close...";
            pb.Value++; // 6/10

            Delay(4000);
            //Process.Start(@"noljaservice.exe");
            Process.Start(@"NoljaBroadcast.exe");

            pg.Text = "Start System...";
            pb.Value++; // 7/10

            pb.Value = 10;
            Delay(2000);
            this.Close();
        }
    }
}
