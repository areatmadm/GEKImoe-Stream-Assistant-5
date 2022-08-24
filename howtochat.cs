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

using System.IO;

namespace AreaTM_acbas
{
    public partial class howtochat : Form
    {
        int quick = 200;
        int qtemp;

        string sdname;
        string dd;

        public howtochat()
        {
            InitializeComponent();
        }

        private void howtochat_Load(object sender, EventArgs e)
        {
            sdname = File.ReadAllText(@"ResourceFiles\" + sdvxwin.setgame + @"\sound_name.txt");
            NOLJA_BlackEdition();
        }

        private void howtochat_activate(object sender, EventArgs e)
        {
            try
            {
                VIDEO_on.ismute = true;

                sdvxwin._obs.SetMute(sdname, true);
                if (sdvxwin.setgame == "0_sega_maimaidx")
                {
                    if (sdvxwin._obs.GetCurrentSceneCollection() == "maimaiDX_1P2P") sdvxwin._obs.SetMute("마이크/보조 2", true);
                    
                    quick = 240;
                    OBSScene dp = sdvxwin._obs.GetCurrentScene();
                    dd = sdvxwin._obs.GetCurrentScene().Name;

                    if(sdvxwin._obs.GetCurrentScene().Name == "camoff_mute" || sdvxwin._obs.GetCurrentScene().Name == "camon_mute")
                    {
                        if (sdvxwin.pastScene == null) dd = "camon";
                        else dd = sdvxwin.pastScene;
                    }
                    else if (sdvxwin._obs.GetCurrentScene().Name == "camoff") sdvxwin._obs.SetCurrentScene("camoff_mute");
                    else sdvxwin._obs.SetCurrentScene("camon_mute");
                }
                lbl_whenstop.Text = (quick / 60) + "분 " + (quick % 60) + "초 후 중단됩니다.";
                mutetimer = new System.Windows.Forms.Timer();
                mutetimer.Interval = 1000;
                mutetimer.Tick += new EventHandler(mutetimer_Tick);
                mutetimer.Enabled = true;
            }
            catch
            {
                //MessageBox.Show("에러 발생으로 음소거 기능 이용불가. 자세한 사항은 관리자에게 문의 바랍니다.");
                End_mute();
            }
        }

        private void mutetimer_Tick(object sender, EventArgs e)
        {
            if (sdvxwin.setgame == "0_sega_maimaidx" && sdvxwin._obs.GetCurrentScene().Name != "camon_mute" && sdvxwin._obs.GetCurrentScene().Name != "camoff_mute")
            {
                End_mute();
            }

            quick--;
            qtemp = quick / 1;
            if (qtemp >= 60)
            {
                if ((qtemp % 60) != 0) lbl_whenstop.Text = (qtemp / 60) + "분 " + (qtemp % 60) + "초 후 중단됩니다.";
                else lbl_whenstop.Text = (qtemp / 60) + "분 후 중단됩니다.";
            }
            else lbl_whenstop.Text = qtemp + "초후 음소거가 중단됩니다.";

            if (qtemp==0)
            {
                End_mute();
            }
        }

        private void End_mute()
        {
            VIDEO_on.ismute = false;

            try
            {
                sdvxwin._obs.SetMute(sdname, false);
            }
            catch { }
            if (sdvxwin.setgame == "0_sega_maimaidx")
            {
                if (sdvxwin._obs.GetCurrentSceneCollection() == "maimaiDX_1P2P") { try { sdvxwin._obs.SetMute("마이크/보조 2", false); } catch { } }

                if(sdvxwin._obs.GetCurrentScene().Name == "camon_mute" || sdvxwin._obs.GetCurrentScene().Name == "camoff_mute")
                    sdvxwin._obs.SetCurrentScene(dd);
            }
            quick = 200;
            mutetimer.Enabled = false;

            sdvxwin.isMuteWindow_opened = false;
            this.Close();
        }

        private void NOLJA_BlackEdition()
        {
            lbl_whenstop.Font = new Font(sdvxwin.font_5_0_r.Families[0], 12f);

            btn_finishmute.Font= new Font(sdvxwin.font_5_0_b.Families[0], 14.25f);
        }

        private void btn_finishmute_Click(object sender, EventArgs e)
        {
            End_mute();
        }
    }
}
