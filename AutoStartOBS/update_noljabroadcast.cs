using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SevenZip;

namespace NoljaUpdater
{
    public partial class update_noljabroadcast : Form
    {
        public static PrivateFontCollection font_3_0_s = new PrivateFontCollection();

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

        public update_noljabroadcast()
        {
            InitializeComponent();
        }

        private void update_noljabroadcast_Load(object sender, EventArgs e)
        {
            font_3_0_s.AddFontFile(@"font_3.0\nanum-barun-gothic\NanumBarunGothicBold.otf");
            font_3_0_s.AddFontFile(@"font_3.0\nanum-barun-gothic\NanumBarunGothic.otf");

            lbl_name.Font = new Font(font_3_0_s.Families[0], 25f, FontStyle.Bold);
            lbl_status.Font = new Font(font_3_0_s.Families[0], 14f);

            lbl_status.Text = "압축 해제 준비 중...";
        }

        private void update_noljabroadcast_Shown(object sender, EventArgs e)
        {
            Delay(5000);

            try
            {
                lbl_status.Text = "압축 해제 중...";
                Delay(1000);
                SevenZipExtractor.SetLibraryPath(System.IO.Path.GetFullPath("7z.dll"));
                SevenZipExtractor se = new SevenZipExtractor(System.IO.Path.GetFullPath("gekimoe_acbas_update.7z"));
                //MessageBox.Show(System.IO.Directory.GetCurrentDirectory());
                se.BeginExtractArchive(System.IO.Directory.GetCurrentDirectory());
                
                se.ExtractionFinished += new EventHandler<EventArgs>(se_ExtFinished);
            }
            catch
            {
                lbl_status.Text = "압축 해제 중 오류 발생!";
                File.WriteAllText("error_update", "");
                try
                {
                    File.Delete("gekimoe_acbas_update.7z");
                }
                catch { }
                Delay(2000);

                if (File.Exists("AutoStartV3.exe"))
                {
                    Process.Start("AutoStartV3.exe");
                }
                else Process.Start("AutoStartV2.exe");
                Application.Exit();
            }
        }

        //신버전 코드
        private void se_ExtFinished(object sender, EventArgs e)
        {
            Delay(200);
            try
            {
                File.Delete("gekimoe_acbas_update.7z");
            }
            catch { }
            File.WriteAllText("update_success", "");
            lbl_status.Text = "압축 해제 완료! 재부팅 중...";
            Delay(6000);

            Process reboot_now_process = new Process();
            reboot_now_process.StartInfo.FileName = @"C:\Windows\SysWOW64\shutdown.exe";
            reboot_now_process.StartInfo.Arguments = "-r -t 0";
            try { reboot_now_process.Start(); } catch { }
            Application.ExitThread();
        }

        //구버전 코드 - 참고용으로만 사용하세요!
        /*private void se_ExtFinished(object sender, EventArgs e)
        {
            Delay(200);
            try
            {
                File.Delete("noljaupdate.7z");
            }
            catch { }
            File.WriteAllText("update_success", "");
            lbl_status.Text = "압축 해제 완료... 재실행 중...";
            Delay(2000);
            if (File.Exists("AutoStartV3.exe"))
            {
                Process.Start("AutoStartV3.exe");
            }
            else Process.Start("AutoStartV2.exe");
            Application.Exit();
        }*/
    }
}
