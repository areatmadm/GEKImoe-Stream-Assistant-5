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
    public partial class getuse_GEKImoe_Stream_safe : Form
    {
        public getuse_GEKImoe_Stream_safe()
        {
            InitializeComponent();
        }

        private int OpenFolder()
        {
            try
            {
                System.Diagnostics.Process.Start(sdvxwin._obs.GetRecordingFolder());
                return 0;
            }
            catch
            {
                MessageBox.Show("Error");
                return -1;
            }
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            //게키모에 스트리밍 세이프 베타 실행
            this.Close();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_openitunes_Click(object sender, EventArgs e)
        {
            int p = OpenFolder();
            if (p != -1)
            {
                Form d = new howtomoveios();
                d.Show();
            }
            this.Close();
        }
    }
}
