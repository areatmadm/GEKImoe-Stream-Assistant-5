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
using System.Drawing.Text;

namespace NoljaPromUpdater
{
    public partial class update_noljaprom : Form
    {
        string[] sourceFileURI = new string[3];
        string[] targetpath = new string[3];

        string isupd_ver;

        string createbat = "";

        //NOLJA New Fonts
        public static PrivateFontCollection font_3_0_s = new PrivateFontCollection();

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
            if (!File.Exists(("need_upd_njpv")))
            {
                Application.ExitThread();
            }
            else
            {
                File.Delete("need_upd_njpv");
                Delay(300);

                string setgame;
                setgame = File.ReadAllText(@"nolja_game_set.txt");

                isupd_ver = GetHtmlString("https://nolja.bizotoge.areatm.com/public/prom?mk=1&game=" + setgame);

                //NOLJA New Fonts_Kakao NOLNABroadcast 3.0
                font_3_0_s.AddFontFile(@"font_3.0\kakao\KakaoBold.ttf");
                font_3_0_s.AddFontFile(@"font_3.0\kakao\KakaoRegular.ttf");

                //this.Font = new Font(sdvxwin.font_3_0_s.Families[1], 11f);
                lbl_n_0.Font = new Font(font_3_0_s.Families[0], 24f);
                label1.Font = new Font(font_3_0_s.Families[1], 15f);
                lbl_status.Font = new Font(font_3_0_s.Families[1], 12f);

                sourceFileURI[0] = "ftp://nolja.bizotoge.areatm.com/public_html/autoupdate/promotionvideo/index.html";
                //sourceFileURI[1] = "ftp://nolja.bizotoge.areatm.com/public_html/otoge_patch/promotionvideo/nolja_ad_mute.webm";
                sourceFileURI[1] = "ftp://nolja.bizotoge.areatm.com/public_html/autoupdate/promotionvideo/" + isupd_ver + ".7z";
                //sourceFileURI[2] = "ftp://nolja.bizotoge.areatm.com/public_html/otoge_patch/promotionvideo/chinatsu.html";

                targetpath[0] = System.IO.Path.GetFullPath("promotionvideo") + @"\index.html";
                //targetpath[1] = System.IO.Path.GetFullPath("promotionvideo") + @"\nolja_ad_mute.webm";
                targetpath[1] = System.IO.Path.GetFullPath("promotionvideo") + @"\" + isupd_ver + ".7z";
                //targetpath[2] = System.IO.Path.GetFullPath("promotionvideo") + @"\chinatsu.html";
            }
        }

        private void update_noljaprom_Active(object sender, EventArgs e)
        {
            this.Hide();
            lbl_status.Text = "업데이트 준비 중...";
            Delay(5000);

            //lbl_status.Text = "NOLJA 프로모션 영상 표시 중지";
            //Delay(1300);

            lbl_status.Text = "NOLJA 프로모션 기존 영상 백업 중...";
            bool p = true;
            while (p)
            {
                Delay(2000);

                createbat += "@ECHO OFF" + "\r\n";
                createbat += "cd promotionvideo" + "\r\n";
                createbat += "ren *.html *.html.bak" + "\r\n";
                createbat += "ren *.webm *.webm.bak" + "\r\n";
                createbat += "ren *.mp4 *.mp4.bak";
                File.WriteAllText("promvd_update.bat", createbat);
                Delay(200);

                Process.Start("promvd_update.bat");
                Delay(1000);

                File.Delete("promvd_update.bat");
                createbat = "";
                Delay(200);
                if (!File.Exists(@"promotionvideo\index.html")) p = false;
            }
            //Directory.CreateDirectory(System.IO.Path.GetFullPath("promotionvideo"));

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
                SevenZipExtractor se = new SevenZipExtractor(System.IO.Path.GetFullPath("promotionvideo") + @"\" + isupd_ver + ".7z");

                se.BeginExtractArchive(System.IO.Path.GetFullPath("promotionvideo"));

                se.ExtractionFinished += new EventHandler<EventArgs>(se_ExtFinished);
            }
            catch
            {
                lbl_status.Text = "파일 다운로드 실패!";
                //Process.Start("promvd_rollback.bat");

                createbat += "@ECHO OFF" + "\r\n";
                createbat += "cd promotionvideo" + "\r\n";
                createbat += "del *.7z" + "\r\n";
                createbat += "del *.html" + "\r\n";
                createbat += "del *.webm" + "\r\n";
                createbat += "del *.mp4" + "\r\n";
                createbat += "ren *.html.bak *.html" + "\r\n";
                createbat += "ren *.webm.bak *.webm" + "\r\n";
                createbat += "ren *.mp4.bak *.mp4";
                File.WriteAllText("promvd_update.bat", createbat);

                Delay(200);
                createbat = "";

                Process.Start("promvd_update.bat");
                Delay(1000);
                File.Delete("promvd_update.bat");

                Delay(1200);
                //sdvxwin.ytvideo.Load("file:///" + sdvxwin.ytvd_pt.Replace(@"\", "/") + "/index.html");
                Application.ExitThread();
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
            File.WriteAllText(@"promotionvideo\version", isupd_ver);
            Delay(200);
            try
            {
                File.Delete(@"promotionvideo\" + isupd_ver + ".7z");
            }
            catch { }

            lbl_status.Text = "백업영상 삭제 중...";

            createbat += "@ECHO OFF" + "\r\n";
            createbat += "cd promotionvideo" + "\r\n";
            //createbat += "del *.7z" + "\r\n";
            createbat += "del *.html.bak" + "\r\n";
            createbat += "del *.webm.bak" + "\r\n";
            createbat += "del *.mp4.bak";
            File.WriteAllText("promvd_update.bat", createbat);

            Delay(200);
            createbat = "";

            Process.Start("promvd_update.bat");
            Delay(1000);
            File.Delete("promvd_update.bat");

            lbl_status.Text = "작업 완료! NOLJA 프로모션 비디오 활성화 중...";
            Delay(1000);

            Application.ExitThread();
            //Delay(1000);
        }

        private void update_noljaprom_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
