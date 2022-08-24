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
using nolja_rtmp;

namespace NoljaBroadcast
{
    public partial class update_rtmpmodule : Form
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

        public update_rtmpmodule()
        {
            InitializeComponent();
        }

        private void update_rtmpmodule_Load(object sender, EventArgs e)
        {
            this.Font = new Font(sdvxwin.font_3_0_s.Families[1], 11f);
            lbl_n_0.Font = new Font(sdvxwin.font_3_0_s.Families[0], 24f);
            label1.Font = new Font(sdvxwin.font_3_0_s.Families[1], 12f);

            sourceFileURI[0] = "ftp://nolja.bizotoge.areatm.com/public_html/otoge_patch/_plivecommon/nolja_rtmp.dll";

            targetpath[0] = System.IO.Path.GetFullPath("nolja_rtmp.dll");
        }

        private void update_rtmpmodule_Active(object sender, EventArgs e)
        {
            Delay(5000);

            try
            {
                //sdvxwin.ytvideo.Load("about:blank");


                for (int i = 0; i < 1; i++)
                {
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
            }
            catch
            {
                
            }
            //sdvxwin.ytvideo.Load("file:///" + sdvxwin.ytvd_pt.Replace(@"\", "/") + "/index.html?" + maintaince_check.isupd_ver);


            maintaince_check.isupd_rtmp = false;
            this.Close();
        }
    }
}
