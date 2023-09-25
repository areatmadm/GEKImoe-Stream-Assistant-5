using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AreaTM_acbas
{
    public partial class plus_settings : Form
    {
        bool load_comp = false;

        public plus_settings()
        {
            InitializeComponent();
        }

        private void plus_settings_Shown(object sender, EventArgs e)
        {
            load_comp = true;
        }

        private void plus_settings_Load(object sender, EventArgs e)
        {
            lbl_d_n_m.Font = new Font(sdvxwin.font_5_0_b.Families[0], 22f);
            btn_rebang_real.Font = new Font(sdvxwin.font_5_0_r.Families[0], 11f);

            lbl_gb_other.Font = new Font(sdvxwin.font_5_0_r.Families[0], 11f);

            btn_rebang.Font = new Font(sdvxwin.font_5_0_r.Families[0], 11f);

            btn_UpdateLog.Font = new Font(sdvxwin.font_5_0_r.Families[0], 11f);

            if (!sdvxwin.PLIVEForm_closed) btn_rebang.Enabled = false;
        }

        private void plus_settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            sdvxwin.PlusSettingForm_closed = true;
        }

        private void btn_rebang_Click(object sender, EventArgs e)
        {
            MessageBox.Show("재부팅을 원할 시 '에러 픽스'를 선택해 주세요. 잘못 눌렀을 시 '방송화면으로 복귀'를 선택해 주세요.");
            ProcessStartInfo rebang = new ProcessStartInfo();

            rebang.FileName = "NoljaBugfix.exe";
            rebang.WorkingDirectory = "Bugfix";

            Process.Start(rebang);
        }

        private void btn_rebang_real_Click(object sender, EventArgs e)
        {
            NOLJA_ReStream.NowRestart();
            this.Close();
        }

        private void btn_UpdateLog_Click(object sender, EventArgs e)
        {
            Form d = new drumwin();
            d.Show();
            this.Close();
        }
    }
}
