using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AreaTM_acbas
{
    public partial class camchange_maimai2p : Form
    {
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
        public camchange_maimai2p()
        {
            InitializeComponent();
        }

        private void camchange_maimai2p_Load(object sender, EventArgs e)
        {
            this.Font = new Font(sdvxwin.font_5_0_r.Families[0], 12f);
        }

        private void camchange_maimai2p_Shown(object sender, EventArgs e)
        {
            if (File.Exists(@"WebCameraConfig\restore.bat"))
            {
                //MessageBox.Show("OK");
                Delay(3000);

                //\WebCameraConfig\restore.bat
                //Process.Start(@"WebCameraConfig\restore.bat");
                try
                {
                    ProcessStartInfo camfix = new ProcessStartInfo();

                    camfix.FileName = "restore.bat";
                    camfix.WorkingDirectory = "WebCameraConfig";

                    Process.Start(camfix);
                }
                catch { }
            }
            //else MessageBox.Show("NO");
            this.Close();
        }
    }
}
