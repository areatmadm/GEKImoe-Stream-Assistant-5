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
    public partial class movefile_form : Form
    {
        Process chr = new Process();
        string pm = "";
        string sec = "--incognito ";

        private int OpenFolder()
        {
            try
            {
                Process.Start(sdvxwin._obs.GetRecordingFolder());
                return 0;
            }
            catch
            {
                MessageBox.Show("Error");
                return -1;
            }
        }

        private void SetChromeURL()
        {
            chr.StartInfo.Arguments = sec + pm;
        }

        public movefile_form()
        {
            InitializeComponent();
        }

        private void movefile_form_Load(object sender, EventArgs e)
        {
            if (File.Exists(@"C:\Program Files (x86)\Naver\Naver Whale\Application\whale.exe")) chr.StartInfo.FileName = @"C:\Program Files (x86)\Naver\Naver Whale\Application\whale.exe";
            else if (File.Exists(@"C:\Program Files\Naver\Naver Whale\Application\whale.exe")) chr.StartInfo.FileName = @"C:\Program Files\Naver\Naver Whale\Application\whale.exe";
            else if (File.Exists(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe")) chr.StartInfo.FileName = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
            else if (File.Exists(@"C:\Program Files\Google\Chrome\Application\chrome.exe")) chr.StartInfo.FileName = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            else { }

            this.Font = new Font(sdvxwin.font_5_0_r.Families[0], 14f);
            lbl_name.Font = new Font(sdvxwin.font_5_0_b.Families[0], 20f);
        }

        private void btn_usb_normal_Click(object sender, EventArgs e)
        {
            int p = OpenFolder();
            this.Close();
        }

        private void btn_ios_Click(object sender, EventArgs e)
        {
            Form d = new getuse_GEKImoe_Stream_safe();
            d.Show();
            this.Close();
        }

        private void btn_ftp_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"C:\Program Files\FileZilla FTP Client\filezilla.exe"))
            {
                Process ftpd = new Process();
                ftpd.StartInfo.FileName = @"C:\Program Files\FileZilla FTP Client\filezilla.exe";
                ftpd.Start();
                OpenFolder();
                this.Close();
            }
            else if (File.Exists(@"C:\Program Files (x86)\FileZilla FTP Client\filezilla.exe"))
            {
                Process ftpd = new Process();
                ftpd.StartInfo.FileName = @"C:\Program Files (x86)\FileZilla FTP Client\filezilla.exe";
                ftpd.Start();
                OpenFolder();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_kakaodrive_Click(object sender, EventArgs e)
        {
            pm = "https://drive.kakao.com";
            SetChromeURL();
            pm = "";
            chr.Start();
            OpenFolder();
            this.Close();
        }

        private void btn_icloud_Click(object sender, EventArgs e)
        {
            pm = "https://www.icloud.com";
            SetChromeURL();
            pm = "";
            chr.Start();
            OpenFolder();
            this.Close();
        }

        private void btn_onedrive_Click(object sender, EventArgs e)
        {
            pm = "https://onedrive.com";
            SetChromeURL();
            pm = "";
            chr.Start();
            OpenFolder();
            this.Close();
        }

        private void btn_ndrive_Click(object sender, EventArgs e)
        {
            pm = "https://cloud.naver.com";
            SetChromeURL();
            pm = "";
            chr.Start();
            OpenFolder();
            this.Close();
        }

        private void btn_sendanywhere_Click(object sender, EventArgs e)
        {
            pm = "https://send-anywhere.com/ko";
            SetChromeURL();
            pm = "";
            chr.Start();
            OpenFolder();
            this.Close();
        }

        private void btn_mega_Click(object sender, EventArgs e)
        {
            pm = "https://mega.nz";
            SetChromeURL();
            pm = "";
            chr.Start();
            OpenFolder();
            this.Close();
        }

        private void btn_youtube_Click(object sender, EventArgs e)
        {
            pm = "https://youtube.com/upload";
            SetChromeURL();
            pm = "";
            chr.Start();
            OpenFolder();
            this.Close();
        }

        private void openWhale_Click(object sender, EventArgs e)
        {
            pm = "";
            SetChromeURL();
            pm = "";
            chr.Start();
            OpenFolder();
            this.Close();
        }
    }
}
