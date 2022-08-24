using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using nolja_game_set;
using System.Diagnostics;
using SevenZip;

namespace NoljaBroadcast
{
    public partial class update_noljaprom : Form
    {
        string[] sourceFileURI = new string[3];
        string[] targetpath = new string[3];

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

        public update_noljaprom()
        {
            InitializeComponent();
        }

        private void update_noljaprom_Load(object sender, EventArgs e)
        {
            //this.Font = new Font(sdvxwin.font_3_0_s.Families[1], 11f);
            lbl_n_0.Font = new Font(sdvxwin.font_3_0_s.Families[0], 24f);
            label1.Font = new Font(sdvxwin.font_3_0_s.Families[1], 15f);
            lbl_status.Font = new Font(sdvxwin.font_3_0_s.Families[1], 12f);

            sourceFileURI[0] = "ftp://nolja.bizotoge.areatm.com/public_html/autoupdate/promotionvideo/index.html";
            //sourceFileURI[1] = "ftp://nolja.bizotoge.areatm.com/public_html/otoge_patch/promotionvideo/nolja_ad_mute.webm";
            sourceFileURI[1] = "ftp://nolja.bizotoge.areatm.com/public_html/autoupdate/promotionvideo/" + maintaince_check.isupd_ver + ".7z";
            //sourceFileURI[2] = "ftp://nolja.bizotoge.areatm.com/public_html/otoge_patch/promotionvideo/chinatsu.html";

            targetpath[0] = System.IO.Path.GetFullPath("promotionvideo") + @"\index.html";
            //targetpath[1] = System.IO.Path.GetFullPath("promotionvideo") + @"\nolja_ad_mute.webm";
            targetpath[1] = System.IO.Path.GetFullPath("promotionvideo") + @"\" + maintaince_check.isupd_ver + ".7z";
            //targetpath[2] = System.IO.Path.GetFullPath("promotionvideo") + @"\chinatsu.html";
        }

        private void update_noljaprom_Active(object sender, EventArgs e)
        {
            lbl_status.Text = "업데이트 준비 중...";
            Delay(5000);
            sdvxwin.ytvideo.Load("about:blank");
            lbl_status.Text = "NOLJA 프로모션 영상 표시 중지";
            Delay(1300);
            lbl_status.Text = "NOLJA 프로모션 기존 영상 삭제 중...";
            Process.Start("promvd_update.bat");
            Delay(1000);
            Directory.CreateDirectory(System.IO.Path.GetFullPath("promotionvideo"));

            try
            {
                //lbl_status.Text = "다운로드 중... [ 0 / 3 ]";
                for (int i = 0; i < 2; i++)
                {
                    lbl_status.Text = "다운로드 중... [ " + (i + 1) + " / 2 ]";
                    Delay(100);
                    NOLJA_Game_Set newnoj = new NOLJA_Game_Set();
                    string usrid = newnoj.setgame_dll(3815);
                    string pwd = newnoj.setgame_dll(5267);

                    Uri sourceFileUri = new Uri(sourceFileURI[i]);
                    FtpWebRequest ftpWebRequest = WebRequest.Create(sourceFileUri) as FtpWebRequest;

                    ftpWebRequest.Credentials = new NetworkCredential(usrid, pwd);
                    ftpWebRequest.Method = WebRequestMethods.Ftp.DownloadFile;

                    FtpWebResponse ftpWebResponse = ftpWebRequest.GetResponse() as FtpWebResponse;

                    Stream sourceStream = ftpWebResponse.GetResponseStream();
                    FileStream targetFileStream = new FileStream(targetpath[i], FileMode.Create, FileAccess.Write);

                    byte[] bufferByteArray = new byte[1024];
                    while (true)
                    {
                        int byteCount = sourceStream.Read(bufferByteArray, 0, bufferByteArray.Length);

                        if (byteCount == 0)
                        {
                            break;
                        }
                        targetFileStream.Write(bufferByteArray, 0, byteCount);
                    }

                    targetFileStream.Close();
                    sourceStream.Close();
                    Delay(2000);
                }
                lbl_status.Text = "파일 다운로드 성공! 압축해제 준비 중...";
                //Process.Start("promvd_success.bat");
                Delay(1000);
                lbl_status.Text = "압축해제 중...";
                Delay(200);

                SevenZipExtractor.SetLibraryPath(System.IO.Path.GetFullPath("7z.dll"));
                SevenZipExtractor se = new SevenZipExtractor(System.IO.Path.GetFullPath("promotionvideo") + @"\" + maintaince_check.isupd_ver + ".7z");

                se.BeginExtractArchive(System.IO.Path.GetFullPath("promotionvideo"));

                se.ExtractionFinished += new EventHandler<EventArgs>(se_ExtFinished);
            }
            catch
            {
                lbl_status.Text = "파일 다운로드 실패!";
                //Process.Start("promvd_rollback.bat");
                Delay(1200);
                maintaince_check.isupd = false;
                maintaince_check.isupd_ver = "";
                //sdvxwin.ytvideo.Load("file:///" + sdvxwin.ytvd_pt.Replace(@"\", "/") + "/index.html");
                this.Close();
            }
            /*if (maintaince_check.chinatsu_html_yt_enabled)
            {
                sdvxwin.ytvideo.Load("file:///" + sdvxwin.ytvd_pt.Replace(@"\", "/") + "/index.html");
                maintaince_check.chinatsu_html_yt_enabled = false;
            }
            else
            {
                if (!File.Exists(@"promotionvideo\chinatsu.html"))
                    File.Copy(@"promotionvideo\index.html", @"promotionvideo\chinatsu.html");
                sdvxwin.ytvideo.Load("file:///" + sdvxwin.ytvd_pt.Replace(@"\", "/") + "/chinatsu.html");
                maintaince_check.chinatsu_html_yt_enabled = true;
            }


            lbl_status.Text = "업데이트 완료";
            Delay(800);
            maintaince_check.isupd = false;
            maintaince_check.isupd_ver = "";
            this.Close();*/
        }

        private void se_ExtFinished(object sender, EventArgs e)
        {
            File.WriteAllText(@"promotionvideo\version", maintaince_check.isupd_ver);
            Delay(200);
            try
            {
                File.Delete(@"promotionvideo\" + maintaince_check.isupd_ver + ".7z");
            }
            catch { }
            lbl_status.Text = "작업 완료! 놀자 방송 소프트웨어 재실행...";
            Delay(1100);

            Process[] processifusenjbtmpcht = Process.GetProcessesByName("Nolja_OpenUp");
            if (processifusenjbtmpcht.Length >= 1)
            {
                Process killtask = new Process();
                killtask.StartInfo.FileName = @"C:\Windows\SysWOW64\taskkill.exe";
                killtask.StartInfo.Arguments = "/f /im Nolja_OpenUp.exe";
                try { killtask.Start(); } catch { }
                //C:\Windows\SysWOW64\taskkill.exe /f /im Nolja_OpenUp.exe
                Delay(200);
            }

            Process.Start("NOLJA_Restart.exe");
            Application.ExitThread();
            //Delay(1000);
        }
    }
}
