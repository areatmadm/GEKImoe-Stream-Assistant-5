using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

using OBSWebsocketDotNet;
using OBSWebsocketDotNet.Types;
using System.Drawing.Text;
using System.Net;
using System.Security.Cryptography;

namespace AutoStartV2
{
    public partial class AutoStartV3Main : Form
    {
        public static long acbas_build;
        public static string acbas_partnum;

        public static string vender; //오락실 정보
        public static string vender_swdf; //오락실별 이용 소프트웨어 구분

        public static string p; //gamecode
        public static int pc_num; //동일 게임에 여러대 방송PC 운영할 경우, 구분을 위해 필요
        public string gc_name;

        public static bool ExitThread = false; //버전체크 직후인지 확인하는 용도, Windows 빌드 미지원으로 인한 강제종료 여부
        public static bool isAvailableOS = false; //Windows 빌드 체크 적합성 확인
        //public string game_name;

        public static PrivateFontCollection font_3_0_s = new PrivateFontCollection();

        bool isstr = false;

        protected OBSWebsocket _obs;

        //Process[] killProcess;

        string[] postStringKey;
        string[] postStringValue;

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

        public AutoStartV3Main()
        {
            InitializeComponent();
        }

        private void AutoStartV3Main_Load(object sender, EventArgs e)
        {
            //20240403 Windows 7, 8, 8.1 구동 제한
            OperatingSystem os = Environment.OSVersion;
            int majorVersion = os.Version.Major;//메이저
            int minorVersion = os.Version.Minor;//마이너
            int buildVersion = os.Version.Build;//빌드

            //OS VersionCheck
            CheckOS();

            /*string pvd = "taskkill /f /im explorer.exe";

            string pve = "";
            pve += "Set WshShell = CreateObject (\"WScript.shell\")" + "\r\n";
            pve += "Dim strArgs" + "\r\n";
            pve += "strArgs = \"imshi.bat\"" + "\r\n";
            pve += "WshShell.Run strArgs, 0, false";

            File.WriteAllText("imshi.bat", pvd);
            File.WriteAllText("start.vbs", pve);
            Delay(500);
            Process.Start("start.vbs");
            Delay(1500);
            File.Delete("imshi.bat");
            File.Delete("start.vbs");*/
            //vbs 지원 종료로 인한 코드 주석화(아래 코드가 안정적일 경우 주석 코드 삭제 요망)

            //vbs(Vivid BAD SQUAD 아님)를 대체할 신규 코드 작성
            if (!ExitThread) //OS 미지원일 경우 강제종료 하면 안됨
            {
                Process killtask1 = new Process();
                killtask1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden; //일단 창 생성 없이 구동
                killtask1.StartInfo.FileName = @"C:\Windows\system32\taskkill.exe";
                killtask1.StartInfo.Arguments = "/f /im explorer.exe";
                try { killtask1.Start(); } catch { }
                Delay(1000);//임시
            }

            if (!ExitThread)
            {
                try
                {
                    font_3_0_s.AddFontFile(@"font_3.0\nanum-barun-gothic\NanumBarunGothicBold.otf");
                    font_3_0_s.AddFontFile(@"font_3.0\nanum-barun-gothic\NanumBarunGothic.otf");

                    lbl_information.Font = new Font(font_3_0_s.Families[0], 15f, FontStyle.Bold);
                    lbl_name.Font = new Font(font_3_0_s.Families[0], 24f, FontStyle.Bold);
                    lbl_nowver_txt.Font = new Font(font_3_0_s.Families[0], 15f, FontStyle.Bold);

                    lbl_nowver.Font = new Font(font_3_0_s.Families[0], 14f);
                    pg.Font = new Font(font_3_0_s.Families[0], 15f);
                }
                catch { }
                lbl_nowver.Text = "5.12_E_20240822";

                lbl_information.Text = language_.ko_kr_DONOTDISTURB + "\r\n" + language_.en_us_DONOTDISTURB;

                try
                {
                    //gc_name = "놀자";

                    //구형 파일 제거, Ver.5.22에서 삭제 시작
                    if (File.Exists(@"nolja_game_set.txt") && File.Exists(@"game_set.txt"))
                    {
                        File.Delete(@"nolja_game_set.txt");
                    }
                    else if (File.Exists(@"nolja_game_set.txt") && !File.Exists(@"game_set.txt"))
                    {
                        File.Move(@"nolja_game_set.txt", @"game_set.txt");
                    }
                    else if (!File.Exists(@"nolja_game_set.txt") && !File.Exists(@"game_set.txt"))
                    {
                        MessageBox.Show("Error", "Error");
                        Application.ExitThread();
                    }
                    //구형 파일 제거, Ver.5.22에서 삭제 끝

                    p = File.ReadAllText(@"game_set.txt");
                    if (File.Exists(@"game_pc_num.txt")) { pc_num = Int32.Parse(File.ReadAllText(@"game_pc_num.txt")); } //PC 여러대 감지되면 구분.
                                                                                                                         //PC 여러대 감지되었다 해도 DB에 반영되어 있지 않으면 0을 제외한 모든 PC는 서버에서 무시 처리될 수도 있음

                    //game_name = File.ReadAllText(@"ResourceFiles\" + p + @"\gamename.otogeonpf");

                    //구형 파일 제거, Ver.5.24에서 삭제 시작
                    if (Directory.Exists(@"cache_drumchat")){ //cefsharp cache delete
                        string path = Directory.GetCurrentDirectory() + @"\cache_drumchat";
                        Directory.Delete(path, true);
                    }

                    //cefsharp library delete start
                    if (Directory.Exists(@"locales")) { //locales directory delete
                        string path = Directory.GetCurrentDirectory() + @"\locales";
                        Directory.Delete(path, true); //all files of cefsharp locales delete
                    }
                    if (File.Exists(@"CefSharp.BrowserSubprocess.Core.dll")) { File.Delete(@"CefSharp.BrowserSubprocess.Core.dll"); }
                    if (File.Exists(@"CefSharp.BrowserSubprocess.exe")) { File.Delete(@"CefSharp.BrowserSubprocess.exe"); }
                    if (File.Exists(@"CefSharp.Core.dll")) { File.Delete(@"CefSharp.Core.dll"); }
                    if (File.Exists(@"CefSharp.Core.Runtime.xml")) { File.Delete(@"CefSharp.Core.Runtime.xml"); }
                    if (File.Exists(@"CefSharp.Core.xml")) { File.Delete(@"CefSharp.Core.xml"); }
                    if (File.Exists(@"CefSharp.dll")) { File.Delete(@"CefSharp.dll"); }
                    if (File.Exists(@"CefSharp.WinForms.dll")) { File.Delete(@"CefSharp.WinForms.dll"); }
                    if (File.Exists(@"CefSharp.WinForms.XML")) { File.Delete(@"CefSharp.WinForms.XML"); }
                    if (File.Exists(@"CefSharp.XML")) { File.Delete(@"CefSharp.XML"); }
                    if (File.Exists(@"chrome_100_percent.pak")) { File.Delete(@"chrome_100_percent.pak"); }
                    if (File.Exists(@"chrome_200_percent.pak")) { File.Delete(@"chrome_200_percent.pak"); }
                    if (File.Exists(@"chrome_elf.dll")) { File.Delete(@"chrome_elf.dll"); }
                    if (File.Exists(@"d3dcompiler_47.dll")) { File.Delete(@"d3dcompiler_47.dll"); }
                    if (File.Exists(@"icudtl.dat")) { File.Delete(@"icudtl.dat"); }
                    if (File.Exists(@"libcef.dll")) { File.Delete(@"libcef.dll"); }
                    if (File.Exists(@"libEGL.dll")) { File.Delete(@"libEGL.dll"); }
                    if (File.Exists(@"libGLESv2.dll")) { File.Delete(@"libGLESv2.dll"); }
                    if (File.Exists(@"LICENSE.txt")) { File.Delete(@"LICENSE.txt"); }
                    if (File.Exists(@"README_cef.txt")) { File.Delete(@"README_cef.txt"); }
                    if (File.Exists(@"resources.pak")) { File.Delete(@"resources.pak"); }
                    if (File.Exists(@"snapshot_blob.bin")) { File.Delete(@"snapshot_blob.bin"); }
                    if (File.Exists(@"v8_context_snapshot.bin")) { File.Delete(@"v8_context_snapshot.bin"); }
                    if (File.Exists(@"vk_swiftshader.dll")) { File.Delete(@"vk_swiftshader.dll"); }
                    if (File.Exists(@"vk_swiftshader_icd.json")) { File.Delete(@"vk_swiftshader_icd.json"); }
                    if (File.Exists(@"vulkan-1.dll")) { File.Delete(@"vulkan-1.dll"); }
                    //cefsharp library delete end

                    if (File.Exists(@"autoobs.lnk")) { File.Delete(@"autoobs.lnk"); } //autoobs.lnk 제거 (더이상 미사용)
                    //구형 파일 제거, Ver.5.24에서 삭제 끝
                }
                catch
                {
                    MessageBox.Show(language_.ko_kr_ERRORACCURED_msgbox);
                    this.Close();
                }

                lbl_name.Text = language_.ko_kr_BOOTING;
            }
            
        }

        private void AutoStartV3Main_Activate(object sender, EventArgs e)
        {
            if (ExitThread)
            {
                Application.Exit();
                //this.Close();
                return;
                //this.Close();

                /*Process killtask_D = new Process();
                killtask_D.StartInfo.WindowStyle = ProcessWindowStyle.Hidden; //일단 창 생성 없이 구동
                killtask_D.StartInfo.FileName = @"C:\Windows\system32\taskkill.exe";
                killtask_D.StartInfo.Arguments = "/f /im explorer.exe";
                try { killtask_D.Start(); } catch { }*/
            }

            string pvd;
            string pve;

            pg.Text = language_.ko_kr_NOWLOADING;
            Delay(500);

            if (File.Exists("restart_pc.bat")) //2024.04부터 삭제
            {
                pg.Text = language_.ko_kr_DELETE_UNUSED + "(A)...";
                File.Delete("restart_pc.bat");
                Delay(800);
            }
            if (File.Exists("restart_pc.vbs")) //2024.04부터 삭제
            {
                pg.Text = language_.ko_kr_DELETE_UNUSED + "(B)...";
                File.Delete("restart_pc.vbs");
                Delay(800);
            }
            if (File.Exists("upd_version")) //2024.03부터 삭제
            {
                pg.Text = language_.ko_kr_DELETE_UNUSED + "(C)...";
                File.Delete("upd_version");
                Delay(800);
            }

            if (File.Exists("AreaTM_acbas_updater_1.exe")) //Updater의 업데이트가 있을 경우
            {
                pg.Text = "Updater is now update...";
                File.Copy("AreaTM_acbas_updater_1.exe", "AreaTM_acbas_updater_0.exe", true);
                Delay(2000);
                File.Delete("AreaTM_acbas_updater_1.exe");
                Delay(1750);

                pg.Text = "Done.";
                Delay(200);
            }

            while (true)
            {
                pg.Text = "GEKImoe Stream Assistant 5 인증서버에서 인증을 받는 중...";
                string get_auth;
                //public(v1) 구형 방식 인증 시작
                /*
                if (!File.Exists("vender.txt"))
                {
                    // 라이선스 체크 프로세싱(놀자)
                    vender = "NOLJA";
                    while (true)
                    {
                        get_auth = GetHtmlString("https://service.stream-assistant-5.gekimoe.areatm.com/public/checklicense?vender=" + vender + "&game=" + p);
                        if (get_auth != null) { break; } //서버 통신 확인
                        else
                        {
                            pg.Text = "서버 문제로 10초 후 다시 시도합니다. 잠시만 기다려 주세요...";
                            Delay(10000);
                            pg.Text = "GEKImoe Stream Assistant 5 인증서버에서 인증을 받는 중...";
                        }
                    }
                }
                else
                {
                    // 라이선스 체크 프로세싱(표준)
                    vender = File.ReadAllText("vender.txt");
                    if (vender == "NOLJA") // 놀자 프로세싱 변경 가능성 열어두기
                    {
                        get_auth = GetHtmlString("https://nolja.bizotoge.areatm.com/public/checklicense?vender=NOLJA&game=" + p);
                        if(get_auth != null) { break; } //서버 통신 확인
                        else { pg.Text = "서버 문제로 10초 후 다시 시도합니다. 잠시만 기다려 주세요..."; Delay(10000); pg.Text = "GEKImoe Stream Assistant 5 인증서버에서 인증을 받는 중..."; }
                    }
                    else
                    {
                        get_auth = GetHtmlString("https://service.stream-assistant-5.gekimoe.areatm.com/public/checklicense?vender=" + vender + "&game=" + p);
                    }
                }
                */
                //public(v1) 구형 방식 인증 끝

                //v2 보안 강화 인증 시작
                while (true)
                {
                    postStringKey = new string[2];
                    postStringValue = new string[2];

                    if (!File.Exists("vender.txt")) { vender = "NOLJA"; } //놀자 vender
                    else { vender = File.ReadAllText("vender.txt"); } //그외 vender
                    postStringKey[0] = "vender"; postStringValue[0] = vender; //postkey_vender
                    postStringKey[1] = "game"; postStringValue[1] = p; //game

                    get_auth = PostHtmlString("https://service.stream-assistant-5.gekimoe.areatm.com/v2/checklicense/", postStringKey, postStringValue);

                    if (get_auth != null && get_auth != "__ERROR__") { break; }
                    else { pg.Text = "서버 문제로 10초 후 다시 시도합니다. 잠시만 기다려 주세요..."; Delay(10000); pg.Text = "GEKImoe Stream Assistant 5 인증서버에서 인증을 받는 중..."; }
                }
                //v2 보안 강화 인증 끝


                if (get_auth == "NotAuthorized")
                {
                    this.Hide();
                    Form dpp = new AutoStartV3.None_N();
                    dpp.Show();

                    while (true)
                    {
                        Delay(300000);
                    }
                }

                else if (get_auth == "Authorized")
                {
                    pg.Text = "GEKImoe Stream Assistant 5 서버 인증 성공!";

                    Delay(1000);
                    pg.Text = "서버에서 추가 정보를 불러오는 중...";
                    //신. plan별 SW 나누기 시작

                    //구 GET Code(비활성화) 시작
                    /*
                    if (vender == "NOLJA")
                    {
                        while (true)
                        {
                            vender_swdf = GetHtmlString("https://nolja.bizotoge.areatm.com/public/checklicense?mode=1&vender=" + vender + "&game=" + p);
                            if (vender_swdf != null) { break; }
                            else { pg.Text = "서버 문제로 10초 후 다시 시도합니다. 잠시만 기다려 주세요..."; Delay(10000); pg.Text = "서버에서 추가 정보를 불러오는 중..."; }
                        }
                    }
                    else
                    {
                        while (true)
                        {
                            vender_swdf = GetHtmlString("https://service.stream-assistant-5.gekimoe.areatm.com/public/checklicense?mode=1&vender=" + vender + "&game=" + p);
                            if (vender_swdf != null) { break; }
                            else { pg.Text = "서버 문제로 10초 후 다시 시도합니다. 잠시만 기다려 주세요..."; Delay(10000); pg.Text = "서버에서 추가 정보를 불러오는 중..."; }
                        }
                    }
                    */
                    //구 GET Code(비활성화) 끝

                    //신 POST Code 시작
                    while (true)
                    {
                        postStringKey = new string[3]; postStringValue = new string[3]; //보낼 키값 초기화
                        postStringKey[0] = "mode"; postStringValue[0] = "1"; //mode
                        postStringKey[1] = "vender"; postStringValue[1] = vender; // key_vender
                        postStringKey[2] = "game"; postStringValue[2] = p; //game

                        vender_swdf = PostHtmlString("https://service.stream-assistant-5.gekimoe.areatm.com/v2/checklicense/", postStringKey, postStringValue);

                        if (vender_swdf != null && vender_swdf != "__Error__") { break; }
                        else { pg.Text = "서버 문제로 10초 후 다시 시도합니다. 잠시만 기다려 주세요..."; Delay(10000); pg.Text = "서버에서 추가 정보를 불러오는 중..."; }
                    }
                    //신 POST Code 끝

                    //신. plan별 SW 나누기 끝
                    Delay(1000);
                    pg.Text = "잠시만 기다려 주세요...";
                    if (File.Exists(@"SangguGSA5.exe")) { File.Delete(@"SangguGSA5.exe"); } //SangguGSA5.exe는 더이상 사용되지 않음
                    //mini, full 소프트웨어 나누기 - 소프트웨어 삭제는 없어짐
                    //if (vender_swdf == "mini") { if (File.Exists(@"AreaTM_acbas.exe")) { File.Delete(@"AreaTM_acbas.exe"); } } // mini 플랜 이용 시 앱만 남기기
                    //else { if (File.Exists(@"GEKImoeStreamAssistant5Lite.exe")) { File.Delete(@"GEKImoeStreamAssistant5Lite.exe"); } } // 그외 플랜
                    break;
                }

                else
                {
                    for (int i = 30; i > 0; i--)
                    {
                        pg.Text = "네트워크 연결 실패! " + i + "초 후 재시도합니다...";
                        Delay(1000);
                    }
                }
            }
            Delay(1000);

            if (!File.Exists("error_update"))
            {
                pg.Text = language_.ko_kr_CHECKUPDATE + language_.ko_kr_CHECKUPDATE_GET_READY;
                //File.WriteAllText("_CheckVersion_", "0");
                Delay(600);

                pg.Text = language_.ko_kr_CHECKUPDATE + language_.ko_kr_CHECKUPDATE_GET + "(1 / 3)";
                Process acbas_get_version = new Process();

                if(vender_swdf == "mini") { acbas_get_version.StartInfo.FileName = System.IO.Path.GetFullPath("GEKImoeStreamAssistant5Lite.exe"); } //mini플랜 간소화버전 사용
                else if(vender_swdf == "full") { acbas_get_version.StartInfo.FileName = System.IO.Path.GetFullPath("AreaTM_acbas.exe"); } //full플랜 full버전 사용
                else { MessageBox.Show("에러: areatmadm@areatm.com, 070-8018-6973, https://areatm.com → 채팅상담 으로 문의 요망"); Process.Start("explorer.exe");  Application.ExitThread(); }
                acbas_get_version.StartInfo.Arguments = "getver";
                try { acbas_get_version.Start(); } catch { }
                Delay(1600);

                pg.Text = language_.ko_kr_CHECKUPDATE + language_.ko_kr_CHECKUPDATE_GET + "(2 / 3)";
                acbas_build = Convert.ToInt64(File.ReadAllText("_CheckVersion_"));
                Delay(400);
                acbas_partnum = File.ReadAllText("_ChecPartNUM_");
                acbas_partnum.Replace("\r\n", "");
                Delay(600);

                pg.Text = language_.ko_kr_CHECKUPDATE + language_.ko_kr_CHECKUPDATE_GET + "(3 / 3)";
                File.Delete("_CheckVersion_");
                File.Delete("_ChecPartNUM_");
                Delay(600);

                pg.Text = language_.ko_kr_CHECKUPDATE + language_.ko_kr_CHECKUPDATE_CHECK;
                string getp;
                getp = GetHtmlString("https://streamassistant.sv.gekimoe.areatm.com/updatecheck/" + acbas_partnum + "?mod=1&ver=" + acbas_build);
                Delay(1200);
                if (getp == "1")
                {
                    pg.Text = language_.ko_kr_CHECKUPDATE + language_.ko_kr_CHECKUPDATE_DO;
                    Delay(1000);
                    /*Process[] processifusenjbtmpcht = Process.GetProcessesByName("Nolja_OpenUp");
                    if (processifusenjbtmpcht.Length >= 1)
                    {
                        Process killtask = new Process();
                        killtask.StartInfo.FileName = @"C:\Windows\SysWOW64\taskkill.exe";
                        killtask.StartInfo.Arguments = "/f /im Nolja_OpenUp.exe";
                        try { killtask.Start(); } catch { }
                        //C:\Windows\SysWOW64\taskkill.exe /f /im Nolja_OpenUp.exe
                        Delay(200);
                    }*/

                    Form updateForm = new update_noljabroadcast(vender);
                    updateForm.ShowDialog();
                }
                else pg.Text = language_.ko_kr_CHECKUPDATE + language_.ko_kr_CHECKUPDATE_NONE + " " + language_.ko_kr_NOWLOADING;
            }
            
            
            Delay(1100);
            //pg.Text = "잠시만 기다려주세요...";
            if (!File.Exists("test"))
            {
                string getp_d = ""; //의미없는거
                //구 GET Code(비활성화) 시작
                /*
                if (vender != "NOLJA")
                {
                    getp_d = GetHtmlString("https://service.stream-assistant-5.gekimoe.areatm.com/temp_sanggu_2/serverstatus?game=" + p +
                            "&mode=3&submode=1");
                }
                else
                {
                    getp_d = GetHtmlString("https://nolja.bizotoge.areatm.com/public/serverstatus?game=" + p +
                            "&mode=3&submode=1");
                }
                */
                //구 GET Code(비활성화) 끝
                //신 POST Code 시작
                postStringKey = new string[5];
                postStringValue = new string[5];
                postStringKey[0] = "vender"; postStringValue[0] = vender; // key_vender
                postStringKey[1] = "game"; postStringValue[1] = p; //game
                postStringKey[2] = "mode"; postStringValue[2] = "3"; //mode
                postStringKey[3] = "submode"; postStringValue[3] = "1"; //submode

                while (true) //에러 뜰때만 다시 시도하자
                {
                    getp_d = PostHtmlString("https://service.stream-assistant-5.gekimoe.areatm.com/v2/serverstatus/v1/", postStringKey, postStringValue);
                    if (getp_d == "__ERROR__") { Delay(1200); }
                    else { break; }
                }
                //신 POST Code 끝
            }
            Delay(2000);

            //pg.Text = "인터넷 상태 점검 중...";
            //Delay(500);

            Process[] processifusenjb = Process.GetProcessesByName("AreaTM_acbas");
            if (processifusenjb.Length >= 1)
            {
                for (int i = 0; i < processifusenjb.Length; i++) processifusenjb[i].Kill(); //중복 실행 방지
                //pg.Text = language_.ko_kr_ERROR_needreboot;
                //Delay(120000);
                //Application.Exit();
            }

            /*if(p== "1_namco_taiko")
            {
                pg.Text = "태고 스트리밍 필수 프로그램 실행 중...";
                Process.Start(@"iiui.lnk");
                Delay(7000);
            }*/

            //초기실행 S/W 코드 작성예정


            Process[] processifuseobs = Process.GetProcessesByName("obs64"); //obs 선실행 중인지 체크
            if (processifuseobs.Length < 1)
            {
                //2023.11.15 : OBS 30.0.0 Logic changed - Safety mode disable
                pg.Text = "OBS Studio (amd64)" + language_.ko_kr_STARTING_PG_before;
                Delay(900);
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\obs-studio\safe_mode")) //Find safemode enable status
                {
                    pg.Text = "OBS Studio (amd64)" + language_.ko_kr_STARTING_PG_before_delete;
                    Delay(1000);
                    try { File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\obs-studio\safe_mode"); } catch { }//do not run safe mode
                }

                pg.Text = "OBS Studio (amd64)" + language_.ko_kr_STARTING_PG;
                //Process.Start(Path.GetFullPath(@"autoobs.lnk")); //Start OBS (Old)

                //2021.11.16 : OBS Studio excuting code changed
                //2024.1.13 : Modified
                Process findOBS = new Process();
                if (File.Exists(@"C:\Program Files\obs-studio\bin\64bit\obs64.exe"))
                {
                    findOBS.StartInfo.FileName = @"C:\Program Files\obs-studio\bin\64bit\obs64.exe";
                    findOBS.StartInfo.WorkingDirectory = @"C:\Program Files\obs-studio\bin\64bit\";
                }
                else if (File.Exists(@"C:\Program Files\obs-studio\bin\32bit\obs32.exe"))
                {
                    findOBS.StartInfo.FileName = @"C:\Program Files\obs-studio\bin\32bit\obs32.exe";
                    findOBS.StartInfo.WorkingDirectory = @"C:\Program Files\obs-studio\bin\32bit\";
                }
                else if (File.Exists(@"C:\Program Files (x86)\obs-studio\bin\64bit\obs64.exe"))
                {
                    findOBS.StartInfo.FileName = @"C:\Program Files (x86)\obs-studio\bin\64bit\obs64.exe";
                    findOBS.StartInfo.WorkingDirectory = @"C:\Program Files (x86)\obs-studio\bin\64bit\";
                }
                else if (File.Exists(@"C:\Program Files (x86)\obs-studio\bin\32bit\obs32.exe"))
                {
                    findOBS.StartInfo.FileName = @"C:\Program Files (x86)\obs-studio\bin\32bit\obs32.exe";
                    findOBS.StartInfo.WorkingDirectory = @"C:\Program Files (x86)\obs-studio\bin\32bit\";
                }
                else
                {
                    MessageBox.Show(language_.ko_kr_ERRORACCURED_msgbox_OBSnotfound);
                    Process.Start("explorer.exe");
                    Application.ExitThread();
                    return;
                }
                findOBS.Start();

                Delay(8000);
            }
            else //OBS 이미 실행중
            {
                pg.Text = "OBS Studio (amd64)" + language_.ko_kr_STARTING_PG_alreadyrun;
                Delay(3000);
            }
            

            if (processifuseobs.Length < 1)
            {

            }

            pg.Text = language_.ko_kr_STARTING_PG_sync;
            _obs = new OBSWebsocket();

            Process[] processifuseobs2;
            while (true)
            {
                processifuseobs2 = null;
                processifuseobs2 = Process.GetProcessesByName("obs64");
                if (processifuseobs2.Length >= 1) break;
                Delay(2000);
            }
            
            Delay(1890);

            try
            {
                if(File.Exists("test")) _obs.Connect("ws://127.0.0.1:7849", "noljabroadcastpc");
                else _obs.Connect("ws://127.0.0.1:4444", "noljabroadcastpc");
                //_obs.Connect("ws://127.0.0.1:4444", "geosungbroadcastpc");

                //pg.Text = "소켓을 찾았습니다";
                Delay(1410);

                OutputStatus optstr = _obs.GetStreamingStatus();
                if (!optstr.IsStreaming)
                {
                    Delay(500);

                    //CamPatcher
                    if (File.Exists(@"WebCameraConfig\cam_sett.cfg"))
                    {
                        pg.Text = language_.ko_kr_WEBCAM_autosetup;

                        /*pve = "";
                        pve += "Set WshShell = CreateObject (\"WScript.shell\")" + "\r\n";
                        pve += "Dim strArgs" + "\r\n";

                        pve += "strArgs = \"WebCameraConfig" + @"\" + "restore.bat\"" + "\r\n";
                        
                        pve += "WshShell.Run strArgs, 0, false";

                        //File.WriteAllText("chromium_taskkill.bat", pvd);
                        File.WriteAllText("start.vbs", pve);
                        Delay(500);
                        Process.Start("start.vbs");
                        Delay(2000);*/
                        //vbs 지원 종료로 인한 주석화(아래 코드가 안정적일 경우, 이후 업데이트에서 해당 코드 삭제)

                        //vbs(Vivid BAD SQUAD 아님) 지원종료로 인해 다른 방식으로 구현
                        Process runCamSett = new Process(); //새로운 Process 생성
                        runCamSett.StartInfo.WindowStyle = ProcessWindowStyle.Hidden; //일단 창 생성 없이 구동
                        runCamSett.StartInfo.FileName = "restore.bat"; //WebCameraConfig\restore.bat
                        runCamSett.StartInfo.WorkingDirectory = "WebCameraConfig"; //실행 자체가 그 폴더에 있는 cam_sett.cfg 파일을 필요로 함
                        runCamSett.Start(); //PROFIT!!
                        Delay(2000);
                        runCamSett.Start(); //Profit!!(2회 적용시켜 적용이 안되는 현상이 일어나지 않도록 함.)
                        Delay(2000);
                    }

                    pg.Text = language_.ko_kr_STARTING_PG_startstream;
                    _obs.StartStreaming();
                }
                else
                {
                    pg.Text = language_.ko_kr_STARTING_PG_alreadystream;
                    File.Create("already_stream");
                }
                Delay(2890);

                if (processifuseobs.Length < 1)
                {
                    pg.Text = language_.ko_kr_WEBCAM_initialize;

                    string nowscene;
                    nowscene = _obs.GetCurrentScene().Name;

                    if (nowscene != "camoff")
                    {
                        _obs.SetCurrentScene("camoff");
                        Delay(1000);
                        _obs.SetCurrentScene("camon");
                        Delay(1000);
                    }

                    else
                    {
                        _obs.SetCurrentScene("camon");

                        Delay(1000);
                    }
                }
                else if (p == "5_konami_sdvx")
                {
                    if (_obs.GetCurrentScene().Name == "camon")
                        pg.Text = language_.ko_kr_WEBCAM_initialize_alreadyon;

                    else
                    {
                        pg.Text = language_.ko_kr_WEBCAM_initialize_switching;
                        _obs.SetCurrentScene("camon");
                    }
                    Delay(1000);
                }
                else
                {
                    pg.Text = language_.ko_kr_WEBCAM_initialize_alreadyon;
                    Delay(1000);
                }

                if (isstr)
                {
                    File.WriteAllText("laterseechat", "");
                    pg.Text = "YouTube의 스트리밍 버그로 인한 패치 가동...";
                    Delay(15000);

                    _obs.StopStreaming();
                    Delay(5000);
                    pg.Text = "스트리밍을 시작합니다... [2 / 2]";
                    _obs.StartStreaming();
                    Delay(2000);
                }

                //Royal SangGu maimaiDX & CHUNITHM CamPatcher
                /*if (vender == "SANGGU")
                {
                    pg.Text = language_.ko_kr_WEBCAM_autosetup;

                    pve = "";
                    pve += "Set WshShell = CreateObject (\"WScript.shell\")" + "\r\n";
                    pve += "Dim strArgs" + "\r\n";

                    pve += "strArgs = \"WebCameraConfig" + @"\" + "restore.bat\"" + "\r\n";

                    pve += "WshShell.Run strArgs, 0, false";

                    //File.WriteAllText("chromium_taskkill.bat", pvd);
                    File.WriteAllText("start.vbs", pve);
                    Delay(500);
                    Process.Start("start.vbs");
                    Delay(2000);
                    Process.Start("start.vbs"); //간혹 저장값을 못 불러오는 경우가 있어 한번 더 실행
                    Delay(2000);
                }*/

                /*if (File.Exists(@"WebCameraConfig\cam_sett.cfg"))
                {
                    pg.Text = language_.ko_kr_WEBCAM_autosetup;

                    pve = "";
                    pve += "Set WshShell = CreateObject (\"WScript.shell\")" + "\r\n";
                    pve += "Dim strArgs" + "\r\n";

                    pve += "strArgs = \"WebCameraConfig" + @"\" + "restore.bat\"" + "\r\n";

                    pve += "WshShell.Run strArgs, 0, false";

                    File.WriteAllText("start.vbs", pve);
                    Delay(500);
                    Process.Start("start.vbs");
                    Delay(2000);
                    Process.Start("start.vbs"); //간혹 저장값을 못 불러오는 경우가 있어 한번 더 실행
                    Delay(2000);
                }*/

                _obs.Disconnect();
            }
            catch
            {
                MessageBox.Show(language_.ko_kr_ERRORACCURED_msgbox_1);
                Application.ExitThread();
            }

            pg.Text = language_.ko_kr_DONE + " " + language_.ko_kr_NOWLOADING;

            Process.Start("explorer.exe"); //Windows Explorer 실행(신) - vbs(Vivid Bad SQUAD 아님) 지원 종료에 따른 신규 작성

            Delay(4000);

            /*pg.Text = "Time Check... Please Wait...";
            int calcTime;
            DateTime currentTime = DateTime.Now;//현재시간 불러오기

            //시간 계산
            if(currentTime.Hour > 5) { calcTime = 105600 - ((currentTime.Hour*3600) + (currentTime.Minute*60) + currentTime.Second); }
            else if(currentTime.Hour == 5 && currentTime.Minute >= 20) { calcTime = 105600 - ((currentTime.Hour * 3600) + (currentTime.Minute * 60) + currentTime.Second); }
            else { calcTime = 19200 - ((currentTime.Hour * 3600) + (currentTime.Minute * 60) + currentTime.Second); }
            Delay(300);

            pg.Text = "Auto reboot enable... Please Wait...";
            Process rebootAutoTime = new Process();//05:20 자동 재부팅
            rebootAutoTime.StartInfo.FileName = @"C:\Windows\system32\shutdown.exe";
            rebootAutoTime.StartInfo.Arguments = "-r -t " + calcTime;
            rebootAutoTime.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            rebootAutoTime.Start();
            Delay(300);*/

            pg.Text = language_.ko_kr_DONE_;
            if(vender_swdf == "mini") { Process.Start(Path.GetFullPath(@"GEKImoeStreamAssistant5Lite.exe")); }
            else if(vender_swdf == "full") { Process.Start(Path.GetFullPath(@"AreaTM_acbas.exe")); }
            else { MessageBox.Show("에러: areatmadm@areatm.com, 070-8018-6973, https://areatm.com → 오른쪽 하단 채팅상담으로 문의 요망"); }

            Delay(400);

            //pg.Text = "놀자 코로나19 알리미 프로그램 실행";
            //Process.Start(@"Nolja_covid19.exe");
            //Delay(2000);

            this.Close();
        }
    }
}
