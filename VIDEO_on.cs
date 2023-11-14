using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using NAudio;
using NAudio.Wave;
using System.Threading;
using System.Net;
using System.IO;

namespace AreaTM_acbas
{
    public partial class VIDEO_on : Form
    {
        sdvxwin mainfrm0;

        //public static GeckoWebBrowser ytvideo_2;
        int mynumber = 0;
        int maxnumber = 2800;
        //int maxnumber = 10;

        int mynumber2 = 0;
        int maxnumber2 = 1200;

        bool FirstRun = true;
        bool FirstRun2 = true;

        public static bool ismute = false;
        public static bool isupdate = false;
        public static bool isgo = false;
        public static bool isclicked = false;
        public static bool rec = false;
        public static bool plive = false;
        public static bool isUsing = false;

        public static bool isWakeOn = false;

        public static bool isNowRestart = false;
        public static bool isMouseMoved = false;

        public static bool isBanModeDisalbed = false;

        public static bool ispushedkeyboard = false;

        public static bool tmp_d_md0 = false;
        public static bool tmp_d_md1 = false;

        string X_Cursor;
        string Y_Cursor;

        float level;

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

        public VIDEO_on()
        {
            InitializeComponent();
        }

        public VIDEO_on(sdvxwin mainfrm)
        {
            InitializeComponent();
            mainfrm0 = mainfrm;
        }

        private void VIDEO_on_Load(object sender, EventArgs e)
        {
            //ytvideo_2 = DeepCopy();
        }

        private void VIDEO_on_Shown(object sender, EventArgs e)
        {
            this.Hide();
            //MessageBox.Show(sdvxwin._obs.GetVolume("마이크", true).Volume + "");

            var waveIn = new NAudio.Wave.WaveInEvent();
            waveIn.DeviceNumber = 0;
            waveIn.WaveFormat = new NAudio.Wave.WaveFormat(16000, 1);
            waveIn.DataAvailable += WaveIn_DataAvailable;
            waveIn.StartRecording();

            Thread OnThread = new Thread(OnWakeSystem);
            OnThread.SetApartmentState(ApartmentState.STA);
            Control.CheckForIllegalCrossThreadCalls = false;
            OnThread.Start();

            Thread OnMouseMoved = new Thread(MouseMoveCheck);
            OnMouseMoved.SetApartmentState(ApartmentState.STA);
            OnMouseMoved.Start();

            Thread OnKeyboardPressed = new Thread(Keyboardd);
            OnKeyboardPressed.SetApartmentState(ApartmentState.STA);
            OnKeyboardPressed.Start();

            //timer1.Tick += timer1_Tick;
            //timer1.Interval = 100;
            timer1.Enabled = false;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            //float dbget = sdvxwin._obs.GetVolume("마이크", true).Volume;
            /*string tmp_x = X_Cursor;
            string tmp_y = Y_Cursor;

            X_Cursor = Cursor.Position.X.ToString();
            Y_Cursor = Cursor.Position.Y.ToString();*/

            if ((!ispushedkeyboard && !isMouseMoved && !isclicked && !isupdate && !ismute && !rec && !plive && !isUsing && !isgo) || (!isupdate && sdvxwin.banneduser))
            {
                //if (mynumber2 != 0) mynumber2 = 0;
                if (FirstRun2 || sdvxwin.banneduser || mynumber >= maxnumber)
                {
                    MyON();
                    //this.Size = new Size(1920, 1080);
                    //this.Show();
                    //if(!sdvxwin.banneduser) ChangeVol(1);
                    //System.Windows.Forms.Cursor.Hide();
                    isgo = true;
                }
                else mynumber++;
            }
            else if (!sdvxwin.banneduser && (isMouseMoved || isupdate || ismute || isUsing || ispushedkeyboard || isWakeOn))
            {
                if (mynumber != 0) mynumber = 0;
                /*if (dbget >= 10)
                {
                    if (mynumber2 != 0) mynumber2 = 0;
                }*/
                if (!isgo || isBanModeDisalbed)
                {
                    System.Windows.Forms.Cursor.Show();
                    MyOFF();
                    this.Hide();

                    isBanModeDisalbed = false;
                    isgo = false;
                }
                if (Win32.GetSoundVolume() > 0) Win32.SetSoundVolume(0);

                if (ispushedkeyboard) ispushedkeyboard = false;

                isWakeOn = false;
            }

            FirstRun2 = false;
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
        }

        private void OnWakeSystem()
        {
            int tmp_d = 0;

            while (!isNowRestart)
            {
                Thread.Sleep(100);
                int dbget = Convert.ToInt32(level);
                if (dbget > 10)
                {
                    isUsing = true;

                    if (FirstRun || !tmp_d_md0)
                    {
                        tmp_d = 0;

                        tmp_d_md0 = true;
                        tmp_d_md1 = false;

                        if (!File.Exists("test"))
                        {
                            string getp_d = "";
                            while (getp_d != "Success")
                            {
                                getp_d = GetHtmlString("https://service.stream-assistant-5.gekimoe.areatm.com/public/serverstatus?vender=" + sdvxwin.vender + "&game=" + sdvxwin.setgame +
                                            "&mode=3&submode=1");
                                Thread.Sleep(10);
                            }
                        }

                        //MessageBox.Show("Test_isPlaying");
                    }
                }
                else
                {
                    isUsing = false;

                    if (FirstRun || (tmp_d >= 1000 && !tmp_d_md1))
                    {
                        tmp_d_md0 = false;
                        tmp_d_md1 = true;

                        if (!File.Exists("test"))
                        {
                            string getp_d = "";
                            while (getp_d != "Success")
                            {
                                getp_d = GetHtmlString("https://service.stream-assistant-5.gekimoe.areatm.com/public/serverstatus?vender=" + sdvxwin.vender + "&game=" + sdvxwin.setgame +
                                        "&mode=3&submode=0");
                                Thread.Sleep(10);
                            }
                        }

                        //MessageBox.Show("Test_isNotPlaying");
                    }
                    else tmp_d++;
                }

                if (FirstRun) FirstRun = false;
            }
        }

        private void MouseMoveCheck()
        {
            while (true)
            {
                string tmp_x = X_Cursor;
                string tmp_y = Y_Cursor;

                X_Cursor = System.Windows.Forms.Cursor.Position.X.ToString();
                Y_Cursor = System.Windows.Forms.Cursor.Position.Y.ToString();

                if (X_Cursor == tmp_x && Y_Cursor == tmp_y) isMouseMoved = false;
                else { isMouseMoved = true; }

                    Thread.Sleep(100);
            }
        }

        void MyON()
        {
            /*oldcode_video_full_on*/
        }

        void MyOFF()
        {
            /*oldcode_video_full_off*/
        }

        void Keyboardd()
        {
            while (true)
            {

                Thread.Sleep(40); //minimum CPU usage

                if (IsAnyKeyDown())
                {
                    ispushedkeyboard = true;
                }
                /*if (Keyboard.IsKeyDown(key))
                {
                    //MessageBox.Show("ㅇㅇ");
                    //label1.Text = "Pressed";
                    ispushedkeyboard = true;
                }
                else
                {
                    ispushedkeyboard = false;
                }*/
            }
        }

        public static void ChangeVol(int vol)
        {
            /*if(vol == 0)
            {
                isWakeOn = true;
            }

            else if(vol == 1)
            {
                if (sdvxwin.setgame == "0_sega_maimaidx") //BIT-B2275IPS
                    Win32.SetSoundVolume(1);

                else Win32.SetSoundVolume(0);
            }

            else if(vol == 2)
            {
                isBanModeDisalbed = true;
                Win32.SetSoundVolume(10);
            }*/
        }

        public static bool IsAnyKeyDown()
        {
            var values = Enum.GetValues(typeof(Key));

            foreach (var v in values)
                if ((((Key)v) != Key.None && Keyboard.IsKeyDown((Key)v)) &&
                    (
                    (((Key)v) == Key.A && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.B && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.C && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.D && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.E && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.F && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.G && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.H && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.I && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.J && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.K && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.L && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.M && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.N && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.O && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.P && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.Q && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.R && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.S && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.T && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.U && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.V && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.W && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.X && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.Y && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.Z && Keyboard.IsKeyDown((Key)v)) ||

                    (((Key)v) == Key.D0 && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.D1 && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.D2 && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.D3 && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.D4 && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.D5 && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.D6 && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.D7 && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.D8 && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.D9 && Keyboard.IsKeyDown((Key)v)) ||

                    (((Key)v) == Key.F1 && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.F2 && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.F3 && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.F4 && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.F5 && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.F6 && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.F7 && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.F8 && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.F9 && Keyboard.IsKeyDown((Key)v)) ||

                    (((Key)v) == Key.LeftCtrl && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.RightCtrl && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.LeftShift && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.RightShift && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.Escape && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.CapsLock && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.LWin && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.Space && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.RWin && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.Tab && Keyboard.IsKeyDown((Key)v)) ||
                    (((Key)v) == Key.Enter && Keyboard.IsKeyDown((Key)v))
                    ))
                    return true;

            return false;
        }
    }
}
