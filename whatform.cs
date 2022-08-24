using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AreaTM_acbas
{
    public partial class whatform : Form
    {
        string NowMode;

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

        public whatform()
        {
            InitializeComponent();
        }

        private void whatform_Load(object sender, EventArgs e)
        {
            this.Font = new Font(sdvxwin.font_5_0_r.Families[0], 11f);

            if (sdvxwin.setgame != "0_sega_maimaidx" && sdvxwin.setgame != "3_squarepixels_ez2ac") this.Close();

            if (sdvxwin.setgame == "0_sega_maimaidx")
            {
                cb_selectScene.Items.Add("1P 모드");
                cb_selectScene.Items.Add("2P 모드");
                cb_selectScene.Items.Add("1P 2P DualView");
            }
            else if (sdvxwin.setgame == "3_squarepixels_ez2ac")
            {
                cb_selectScene.Items.Add("1P 캠");
                cb_selectScene.Items.Add("2P 캠");
                cb_selectScene.Items.Add("캠 모두 보기");

                rd_onlyScreen.Enabled = false;
            }

            NowMode = sdvxwin._obs.GetCurrentSceneCollection();

            if (NowMode == "maimaiDX_1P2P" || NowMode == "EZ2AC_1P2P") //DualView에서의 캠 끄기 옵션은 아직 구현되지 않음
            {
                cb_selectScene.SelectedIndex = 2;

                rd_camon.Checked = true;
                rd_camoff.Enabled = false;
                rd_onlyScreen.Enabled = false;
            }
            else //나머지는 캠 끄기 옵션이 구현되어 있음
            {
                if (NowMode == "maimaiDX_1P_Normal" || NowMode == "EZ2AC_1P_Normal") cb_selectScene.SelectedIndex = 0;
                else if (NowMode == "maimaiDX_2P_Normal" || NowMode == "EZ2AC_2P_Normal") cb_selectScene.SelectedIndex = 1;
                else this.Close();

                string NowScene = sdvxwin._obs.GetCurrentScene().Name;
                if (NowScene == "camon") rd_camon.Checked = true;
                else if (NowScene == "camoff") rd_camoff.Checked = true;
                else if (NowScene == "mod_0") rd_onlyScreen.Checked = true;
            }
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
            if(!rd_camoff.Checked && !rd_camon.Checked && !rd_onlyScreen.Checked)
            {
                MessageBox.Show("캠 설정이 되어 있지 않습니다.");
                return;
            }

            if (cb_selectScene.SelectedIndex != 0 && cb_selectScene.SelectedIndex != 1 && cb_selectScene.SelectedIndex != 2)
            {
                MessageBox.Show("장면 설정이 되어 있지 않습니다.");
                return;
            }

            if(cb_selectScene.SelectedIndex == 0)
            {
                if (sdvxwin.setgame=="0_sega_maimaidx" && NowMode != "maimaiDX_1P_Normal") sdvxwin._obs.SetCurrentSceneCollection("maimaiDX_1P_Normal");
                else if (sdvxwin.setgame == "3_squarepixels_ez2ac" && NowMode != "EZ2AC_1P_Normal") sdvxwin._obs.SetCurrentSceneCollection("EZ2AC_1P_Normal");
            }
            else if(cb_selectScene.SelectedIndex == 1)
            {
                if (sdvxwin.setgame=="0_sega_maimaidx" && NowMode != "maimaiDX_2P_Normal") sdvxwin._obs.SetCurrentSceneCollection("maimaiDX_2P_Normal");
                else if (sdvxwin.setgame == "3_squarepixels_ez2ac" && NowMode != "EZ2AC_2P_Normal") sdvxwin._obs.SetCurrentSceneCollection("EZ2AC_2P_Normal");
            }
            else if (cb_selectScene.SelectedIndex == 2)
            {
                if (sdvxwin.setgame=="0_sega_maimaidx" && NowMode != "maimaiDX_1P2P") sdvxwin._obs.SetCurrentSceneCollection("maimaiDX_1P2P");
                else if (sdvxwin.setgame == "3_squarepixels_ez2ac" && NowMode != "EZ2AC_1P2P") sdvxwin._obs.SetCurrentSceneCollection("EZ2AC_1P2P");
                Delay(800);
                sdvxwin._obs.SetCurrentScene("camon");
                this.Close();
                return;
            }

            Delay(800);

            if (rd_camon.Checked) sdvxwin._obs.SetCurrentScene("camon");
            else if (rd_camoff.Checked) sdvxwin._obs.SetCurrentScene("camoff");
            else if (rd_onlyScreen.Checked) sdvxwin._obs.SetCurrentScene("mod_0");

            this.Close();
        }

        private void cb_selectScene_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cb_selectScene.SelectedIndex == 2)
            {
                rd_camoff.Enabled = false;
                rd_onlyScreen.Enabled = false;

                rd_camoff.Checked = false;
                rd_onlyScreen.Checked = false;
                rd_camon.Checked = true;
            }
            else
            {
                rd_camoff.Enabled = true;
                if (sdvxwin.setgame == "0_sega_maimaidx") rd_onlyScreen.Enabled = true;
            }
        }
    }
}
