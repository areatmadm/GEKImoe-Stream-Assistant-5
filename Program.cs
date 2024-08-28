/*using CefSharp.WinForms;*/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AreaTM_acbas
{
    static class Program
    {
        public static string GetHtmlString(string url)
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
        public static string PostHtmlString(string url, String[] postDataKey, String[] postDataValue) //POST 전송에 필요한 데이터 수집
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
        private static void CheckOS()
        {
            OperatingSystem os = Environment.OSVersion;
            int majorVersion = os.Version.Major;//메이저
            int minorVersion = os.Version.Minor;//마이너
            int buildVersion = os.Version.Build;//빌드

            if (majorVersion < 10)//Windows 10, Windows 11이 아닐 경우 실행 차단
            {
                MessageBox.Show("GEKImoe Stream Assistant supports Windows 10 and Windows 11. Please upgrade this computer first and re-launch this assistant." + "\r\n\r\n" +
                    "GEKImoe Stream Assistant는 Windows 10과 Windows 11을 지원합니다. 이 컴퓨터를 먼저 업그레이드하고 이 어시스턴트를 다시 실행해 주세요." + "\r\n\r\n" +
                    "GEKImoe Stream AssistantはWindows 10とWindows 11に対応しています。まずこのコンピューターをアップグレードしてから、このアシスタントを再起動してください。" + "\r\n\r\n" +
                    "GEKImoe Stream Assistant支持Windows 10和Windows 11。请先升级这台电脑，然后重新启动这个助手。" + "\r\n\r\n" +
                    "GEKImoe Stream Assistant支持Windows 10和Windows 11。請先升級這台電腦，然後重新啟動這個助手。"
                    , "Not support OS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isAvailableOS = false;
                ExitThread = true;
                return;
            }
            else if (buildVersion < 17763) //Windows 10 1809 미만일 경우 실행 차단
            {
                MessageBox.Show("GEKImoe Stream Assistant supports Windows 10(over than 1809) and Windows 11. Please run Windows Update to update build over than 1809 first and re-launch this assistant." + "\r\n\r\n" +
                    "GEKImoe Stream Assistant는 Windows 10(1809 이상)과 Windows 11을 지원합니다. 먼저 Windows 업데이트를 실행하여 1809 이상으로 빌드를 업데이트한 후 이 어시스턴트를 다시 실행해 주세요." + "\r\n\r\n" +
                    "GEKImoe Stream AssistantはWindows 10（1809以上）とWindows 11に対応しています。まずWindows Updateを実行して1809以上にビルドをアップデートしてから、このアシスタントを再起動してください。" + "\r\n\r\n" +
                    "GEKImoe Stream Assistant支持Windows 10（1809以上版本）和Windows 11。请先运行Windows更新，将系统版本更新到1809以上，然后重新启动这个助手。" + "\r\n\r\n" +
                    "GEKImoe Stream Assistant支持Windows 10（1809以上版本）和Windows 11。請先執行Windows更新，將系統版本更新到1809以上，然後重新啟動這個助手。"
                    , "Not support OS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isAvailableOS = false;
                ExitThread = true;
                return;
            }
            else if (buildVersion < 19044) //Windows 10 21H2 미만일 경우 사전 경고(지원 종료 예정)
            {
                isAvailableOS = false;
                return;
            }
            else
            {
                isAvailableOS = true;
            }
        }

        private static string appGUID = "areatmgekimoestreamassistant";

        public static string acbas_ver = "5.20_J";
        public static long acbas_build = 202408290216;
        public static string acbas_partnum = "v5_6";

        //public static string ad_servercountry = "KR";
        //public static string ad_serverlocate = "gekimoe0prom";
        public static string ad_location = "southkorea/daegu/nolja"; // country/city/gamecentername
        public static long ad_version = 0; //ad ver - country/city/gamecentername?mod=1o

        public static bool ExitThread = false; //버전체크 직후인지 확인하는 용도, Windows 빌드 미지원으로 인한 강제종료 여부
        public static bool isAvailableOS = false; //Windows 빌드 체크 적합성 확인

        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            CheckOS();

            if (args.Length > 0)
            {
                if (args[0] == "getver")
                {
                    File.WriteAllText("_CheckVersion_", acbas_build + "");
                    File.WriteAllText("_ChecPartNUM_", acbas_partnum);
                    ExitThread = true;
                    return;
                }
            }
            if (File.Exists("_CheckVersion_")) File.Delete("_CheckVersion_");
            if (File.Exists("_ChecPartNUM_")) File.Delete("_ChecPartNUM_");
            using (Mutex mutex = new Mutex(false, "Global\\" + appGUID))
            {
                if (!mutex.WaitOne(0, false))
                {
                    MessageBox.Show("[AreaTM] GEKImoe Stream Assistant 5 has already running!");
                    return;
                }

                //Delay(1000);
                /*if (Process.GetProcessesByName("AutoStartV3.exe").Length > 0 && !File.Exists("_Done"))
                {
                    string pdg = File.ReadAllText("_CheckVersion_");
                    if (pdg != "0") { try { File.Delete("_CheckVersion_"); } catch { } } //찌꺼기로 확인될 경우 삭제
                    else
                    {
                        File.WriteAllText("_CheckVersion_", acbas_build + "");
                        File.WriteAllText("_ChecPartNUM_", acbas_partnum);
                        ExitThread = true;
                    }
                }*/

                //GEKImoe Promotion 2 Advertise location
                if (File.Exists("gekimoe_prom2_ad_location")) ad_location = File.ReadAllText("gekimoe_prom2_ad_location");

                //HiDPI support(Deleted)
                //CefSharp.Cef.EnableHighDPISupport();

                /*if (!ExitThread)
                {
                    var settings = new CefSettings();
                    settings.BrowserSubprocessPath = System.IO.Path.GetFullPath("CefSharp.BrowserSubprocess.exe");
                    settings.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:124.0) Gecko/20100101 Firefox/124.0";
                    settings.CefCommandLineArgs["autoplay-policy"] = "no-user-gesture-required";
                    settings.CefCommandLineArgs["disable-features"] = "HardwareMediaKeyHandling,MediaSessionService";
                    settings.Locale = "KO_KR";
                    settings.CachePath = System.IO.Path.GetFullPath("cache_drumchat");
                    CefSharp.Cef.Initialize(settings);
                }*/

                string thisprogram = "SDVX";
                //SDVX: Sound Voltex
                //GT: GITADORA GuitarFreaks
                //DR: GITADORA DrumMania
                //PP: pop'n music
                //JB: jubeat
                //MAID: maimaiDX
                //WACA: wacca
                //IIDX: Beatmania IIDX
                //DDR: DanceDacneRevolution
                //CHNI: CHUNITHM
                //ONGK: ONGEKI
                //TAIK: taiko no tatsujin
                //PIU: Pump it UP
                //EZ2: EZ2AC

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new howtomoveios());
                if (thisprogram == "SDVX" && !ExitThread)
                {
                    Application.Run(new sdvxwin());
                }

                else if (thisprogram == "DR" && !ExitThread)
                {
                    Application.Run(new drumwin());
                }
            }
        }

        static void RunCodeP()
        {
            
        }
    }
}
