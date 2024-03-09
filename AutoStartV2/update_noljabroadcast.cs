//using nolja_game_set;
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

namespace AutoStartV2
{
    public partial class update_noljabroadcast : Form
    {
        // Download 7z
        string[] sourceFileURI = new string[3];
        string[] targetpath = new string[3];

        string[] postStringKey;
        string[] postStringValue;

        string vender; //오락실 업체
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

        private string PostHtmlString(string url, string[] postDataKey, string[] postDataValue) //POST 전송에 필요한 데이터 수집
        {
            try
            {

                String callUrl = url;
                //String[] data = new String[1];

                String postDataToSend = null;
                for (int i = 0; i < postDataKey.Length; i++) //값 전달할 key 전달
                {
                    if (i > 0) postDataToSend += "&";
                    postDataToSend += postDataKey[i];
                    postDataToSend += "=";
                    postDataToSend += postDataValue[i];
                }

                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(callUrl);

                //인코딩 UTF-8
                byte[] sendData = UTF8Encoding.UTF8.GetBytes(postDataToSend);
                httpWebRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                httpWebRequest.Method = "POST";
                httpWebRequest.ContentLength = sendData.Length;

                Stream requestStream = httpWebRequest.GetRequestStream();
                requestStream.Write(sendData, 0, sendData.Length);
                requestStream.Close();

                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
                String response = streamReader.ReadToEnd();

                streamReader.Close();
                httpWebResponse.Close();

                return response;
            }
            catch
            {
                return "__Error__";
            }
        }

        public update_noljabroadcast(string vender)
        {
            InitializeComponent();
            this.vender = vender;
        }

        private void update_noljabroadcast_Load(object sender, EventArgs e)
        {
            lbl_name.Font = new Font(AutoStartV3Main.font_3_0_s.Families[0], 25f, FontStyle.Bold);
            lbl_status.Font = new Font(AutoStartV3Main.font_3_0_s.Families[0], 14f);

            lbl_status.Text = "업데이트 준비 중...";
            

            //sdvxwin.ActiveForm.Hide();

            
        }

        private void update_noljabroadcast_Shown(object sender, EventArgs e)
        {
            //sdvxwin.ActiveForm.Hide();
            Delay(5000);

            string downver;
            lbl_status.Text = "업데이트 정보를 받는 중...";
            downver = GetHtmlString("https://streamassistant.sv.gekimoe.areatm.com/updatecheck/" + AutoStartV3Main.acbas_partnum + "?ver=" + AutoStartV3Main.acbas_build);
            

            Delay(3000);
            //sourceFileURI[0] = "https://update.streamassistant.sv.gekimoe.areatm.com/sa/" + AutoStartV3Main.acbas_partnum + "/" + downver + ".7z";
            sourceFileURI[0] = "https://download.stream-assistant-5.gekimoe.areatm.com/sa/" + AutoStartV3Main.acbas_partnum + "/" + downver + ".7z";
            targetpath[0] = System.IO.Path.GetFullPath("gekimoe_acbas_update.7z");

            lbl_status.Text = "다운로드 준비 중..";
            Delay(2000);

            lbl_status.Text = "다운로드 중...";
            Delay(500);

            try
            {
                //NOLJA_Game_Set newnoj = new NOLJA_Game_Set();
                //string usrid = newnoj.setgame_dll(4326);
                //string pwd = newnoj.setgame_dll(4635);

                //Uri sourceFileUri = new Uri(sourceFileURI[0]);
                /*FtpWebRequest ftpWebRequest = WebRequest.Create(sourceFileUri) as FtpWebRequest;
                ftpWebRequest.Credentials = new NetworkCredential(usrid, pwd);
                ftpWebRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                FtpWebResponse ftpWebResponse = ftpWebRequest.GetResponse() as FtpWebResponse;
                Stream sourceStream = ftpWebResponse.GetResponseStream();
                FileStream targetFileStream = new FileStream(targetpath[0], FileMode.Create, FileAccess.Write);

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
                sourceStream.Close();*/

                try
                {
                    WebClient mywebClient = new WebClient();
                    mywebClient.DownloadFile(sourceFileURI[0], targetpath[0]);
                }
                catch { return; }

                lbl_status.Text = "다운로드 완료...";
                //File.WriteAllText("_firstrun_update", "");
                Delay(2000);

                
                Process[] processifusenjbtmpcht = Process.GetProcessesByName("Nolja_OpenUp");
                if (processifusenjbtmpcht.Length >= 1)
                {
                    for (int i = 0; i < processifusenjbtmpcht.Length; i++)
                    {
                        processifusenjbtmpcht[i].Kill();
                    }
                    /*Process killtask = new Process();
                    killtask.StartInfo.FileName = @"C:\Windows\SysWOW64\taskkill.exe";
                    killtask.StartInfo.Arguments = "/f /im Nolja_OpenUp.exe";
                    try { killtask.Start(); } catch { }*/
                    //C:\Windows\SysWOW64\taskkill.exe /f /im Nolja_OpenUp.exe
                    Delay(200);
                }

                Process[] processifusenjbtmpcht2 = Process.GetProcessesByName("AreaTM_IoT");
                if (processifusenjbtmpcht2.Length >= 1)
                {
                    for (int i = 0; i < processifusenjbtmpcht2.Length; i++)
                    {
                        processifusenjbtmpcht2[i].Kill();
                    }
                    /*Process killtask = new Process();
                    killtask.StartInfo.FileName = @"C:\Windows\SysWOW64\taskkill.exe";
                    killtask.StartInfo.Arguments = "/f /im AreaTM_IoT.exe";
                    try { killtask.Start(); } catch { }*/
                    //C:\Windows\SysWOW64\taskkill.exe /f /im Nolja_OpenUp.exe
                    Delay(200);
                }

                String N_null;
                postStringKey = new string[4];
                postStringValue = new string[4];
                postStringKey[0] = "vender"; postStringValue[0] = vender; // key_vender
                postStringKey[1] = "game"; postStringValue[1] = AutoStartV3Main.p; //game
                postStringKey[2] = "mode"; postStringValue[2] = "3"; //mode
                postStringKey[3] = "submode"; postStringValue[3] = "1"; //submode
                //N_null = GetHtmlString("https://service.stream-assistant-5.gekimoe.areatm.com/public/serverstatus?mode=4&submode=0&game=" + AutoStartV3Main.p + "&vender=" + vender);
                N_null = PostHtmlString("https://service.stream-assistant-5.gekimoe.areatm.com/v2/serverstatus/v1/", postStringKey, postStringValue);

                Process.Start("AreaTM_acbas_updater_0.exe");
                //Application.ExitThread();

                Application.ExitThread(); //S/W NEW Exit Source

                Process killtask2 = new Process();
                killtask2.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
                killtask2.StartInfo.FileName = @"C:\Windows\system32\taskkill.exe";
                killtask2.StartInfo.Arguments = "/f /im AutoStartV3.exe";
                try { killtask2.Start(); } catch { }
                
            }
            catch
            {
                lbl_status.Text = "다운로드 중 오류 발생! 관리자가 수동으로 업데이트 예정";
                File.WriteAllText("error_update", "");
                Delay(2000);

                this.Close();
            }
        }
    }
}
