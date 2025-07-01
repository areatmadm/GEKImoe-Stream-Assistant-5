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
    public partial class movefile_form_selectbrowser : Form
    {
        Process chr = new Process();
        string pm = "";
        string sec = "";
        //string AppleDeviceVersion_0 = "1.1030.22273.0";
        //string AppleDeviceVersion_1 = "1.1030.22273.0";
        //Apple 기기 버전별 경로가 달라 부득이하게 지정

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

        public movefile_form_selectbrowser()
        {
            InitializeComponent();
        }
        public movefile_form_selectbrowser(string pm_t)
        {
            pm = pm_t;
            InitializeComponent();
        }


        private void openWhale_Click(object sender, EventArgs e) //파이어폭스 버튼이에요!!
        {
            if(pm == null) //기본 브라우저 세팅용(아직 미구현)
            {
                this.Close();
                return;
            }


            if (File.Exists(@"C:\Program Files\Mozilla Firefox\firefox.exe"))
            {
                //openFirefox.Enabled = true;
                chr.StartInfo.FileName = @"C:\Program Files\Mozilla Firefox\firefox.exe";
                sec = "-private-window ";
            }
            else if (File.Exists(@"C:\Program Files (x86)\Mozilla Firefox\firefox.exe"))
            {
                //openFirefox.Enabled = true;
                chr.StartInfo.FileName = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                sec = "-private-window ";
            }

            SetChromeURL();
            chr.Start();
            OpenFolder();
            this.Close();
            return;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {

        }

        private void movefile_form_selectbrowser_Load(object sender, EventArgs e)
        {
            //Firefox → Brave → Whale → Edge → Chrome
            //Google Chrome will unsupport after 2025.5.2
            if (File.Exists(@"C:\Program Files\Mozilla Firefox\firefox.exe"))
            {
                openFirefox.Enabled = true;
                //chr.StartInfo.FileName = @"C:\Program Files\Mozilla Firefox\firefox.exe";
                //sec = "-private ";
            }
            else if (File.Exists(@"C:\Program Files (x86)\Mozilla Firefox\firefox.exe"))
            {
                openFirefox.Enabled = true;
                //chr.StartInfo.FileName = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                //sec = "-private ";
            }

            if (File.Exists(@"C:\Program Files\BraveSoftware\Brave-Browser\Application\brave.exe"))
            {
                openBrave.Enabled = true;
                //chr.StartInfo.FileName = @"C:\Program Files\BraveSoftware\Brave-Browser\Application\brave.exe";
                //sec = "--incognito ";
            }
            else if (File.Exists(@"C:\Program Files (x86)\BraveSoftware\Brave-Browser\Application\brave.exe"))
            {
                openBrave.Enabled = true;
                //chr.StartInfo.FileName = @"C:\Program Files (x86)\BraveSoftware\Brave-Browser\Application\brave.exe";
                //sec = "--incognito ";
            }

            if (File.Exists(@"C:\Program Files (x86)\Naver\Naver Whale\Application\whale.exe"))
            {
                openWhale.Enabled = true;
                //chr.StartInfo.FileName = @"C:\Program Files (x86)\Naver\Naver Whale\Application\whale.exe";
                //sec = "--incognito ";
            }
            else if (File.Exists(@"C:\Program Files\Naver\Naver Whale\Application\whale.exe"))
            {
                openWhale.Enabled = true;
                //chr.StartInfo.FileName = @"C:\Program Files\Naver\Naver Whale\Application\whale.exe";
                //sec = "--incognito ";
            }

            if (File.Exists(@"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe"))
            {
                openEdge.Enabled = true;
                //chr.StartInfo.FileName = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";
                //sec = "--inprivate ";
            }
            else if (File.Exists(@"C:\Program Files\Microsoft\Edge\Application\msedge.exe"))
            {
                openEdge.Enabled = true;
                //chr.StartInfo.FileName = @"C:\Program Files\Microsoft\Edge\Application\msedge.exe";
                //sec = "--inprivate ";
            }

            if (File.Exists(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe"))
            {
                openChrome.Enabled = true;
                //chr.StartInfo.FileName = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
                //sec = "--incognito ";
                //sdvxwin.isGoogleChromeisOnlyAvailableinThisComputer = true; //크롬제발좀지워라!!
            }
            else if (File.Exists(@"C:\Program Files\Google\Chrome\Application\chrome.exe"))
            {
                openChrome.Enabled = true;
                //chr.StartInfo.FileName = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
                //sec = "--incognito ";
                //sdvxwin.isGoogleChromeisOnlyAvailableinThisComputer = true; //크롬제발좀지워라!!
            }

            this.Font = new Font(sdvxwin.font_5_0_r.Families[0], 14f);
            lbl_name.Font = new Font(sdvxwin.font_5_0_b.Families[0], 20f);
        }

        private void openChrome_Click(object sender, EventArgs e)
        {
            if (pm == null) //기본 브라우저 세팅용(아직 미구현)
            {
                this.Close();
                return;
            }


            if (File.Exists(@"C:\Program Files\Google\Chrome\Application\chrome.exe"))
            {
                //openFirefox.Enabled = true;
                chr.StartInfo.FileName = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
                sec = "--incognito ";
            }
            else if (File.Exists(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe"))
            {
                //openFirefox.Enabled = true;
                chr.StartInfo.FileName = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
                sec = "--incognito ";
            }

            SetChromeURL();
            chr.Start();
            OpenFolder();
            this.Close();
            return;
        }

        private void openBrave_Click(object sender, EventArgs e)
        {
            if (pm == null) //기본 브라우저 세팅용(아직 미구현)
            {
                this.Close();
                return;
            }


            if (File.Exists(@"C:\Program Files\BraveSoftware\Brave-Browser\Application\brave.exe"))
            {
                //openFirefox.Enabled = true;
                chr.StartInfo.FileName = @"C:\Program Files\BraveSoftware\Brave-Browser\Application\brave.exe";
                sec = "--incognito ";
            }
            else if (File.Exists(@"C:\Program Files\Naver\Naver Whale\Application\whale.exe"))
            {
                //openFirefox.Enabled = true;
                chr.StartInfo.FileName = @"C:\Program Files\Naver\Naver Whale\Application\whale.exe";
                sec = "--incognito ";
            }

            SetChromeURL();
            chr.Start();
            OpenFolder();
            this.Close();
            return;
        }

        private void openEdge_Click(object sender, EventArgs e)
        {
            if (pm == null) //기본 브라우저 세팅용(아직 미구현)
            {
                this.Close();
                return;
            }


            if (File.Exists(@"C:\Program Files (x86)\Naver\Naver Whale\Application\whale.exe"))
            {
                //openFirefox.Enabled = true;
                chr.StartInfo.FileName = @"C:\Program Files (x86)\Naver\Naver Whale\Application\whale.exe";
                sec = "--inprivate ";
            }
            else if (File.Exists(@"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe"))
            {
                //openFirefox.Enabled = true;
                chr.StartInfo.FileName = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";
                sec = "--inprivate ";
            }

            SetChromeURL();
            chr.Start();
            OpenFolder();
            this.Close();
            return;
        }

        private void openWhale_Click_1(object sender, EventArgs e)
        {
            if (pm == null) //기본 브라우저 세팅용(아직 미구현)
            {
                this.Close();
                return;
            }


            if (File.Exists(@"C:\Program Files\BraveSoftware\Brave-Browser\Application\brave.exe"))
            {
                //openFirefox.Enabled = true;
                chr.StartInfo.FileName = @"C:\Program Files\BraveSoftware\Brave-Browser\Application\brave.exe";
                sec = "--incognito ";
            }
            else if (File.Exists(@"C:\Program Files (x86)\BraveSoftware\Brave-Browser\Application\brave.exe"))
            {
                //openFirefox.Enabled = true;
                chr.StartInfo.FileName = @"C:\Program Files (x86)\BraveSoftware\Brave-Browser\Application\brave.exe";
                sec = "--incognito ";
            }

            SetChromeURL();
            chr.Start();
            OpenFolder();
            this.Close();
            return;
        }
    }
}
