using CefSharp.WinForms;
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
        private static string GetHtmlString(string url)
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
        private static string appGUID = "areatmgekimoestreamassistant";

        public static string acbas_ver = "5.11_A";
        public static long acbas_build = 202309082352;
        public static string acbas_partnum = "v5_3";

        //public static string ad_servercountry = "KR";
        //public static string ad_serverlocate = "gekimoe0prom";
        public static string ad_location = "southkorea/daegu/nolja"; // country/city/gamecentername
        public static long ad_version = 0; //ad ver - country/city/gamecentername?mod=1o

        public static bool ExitThread = false; //버전체크 직후인지 확인하는 용도

        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
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

                var settings = new CefSettings();
                settings.BrowserSubprocessPath = System.IO.Path.GetFullPath("CefSharp.BrowserSubprocess.exe");
                settings.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:104.0) Gecko/20100101 Firefox/110.0";
                settings.CefCommandLineArgs["autoplay-policy"] = "no-user-gesture-required";
                settings.CefCommandLineArgs["disable-features"] = "HardwareMediaKeyHandling,MediaSessionService";
                settings.Locale = "KO_KR";
                settings.CachePath = System.IO.Path.GetFullPath("cache_drumchat");
                CefSharp.Cef.Initialize(settings);

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
