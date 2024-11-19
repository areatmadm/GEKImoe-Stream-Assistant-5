using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AreaTM_acbas
{
    public partial class Authorize_acbas : Form
    {
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

        public Authorize_acbas()
        {
            InitializeComponent();
        }

        private void lbl_status_Click(object sender, EventArgs e)
        {

        }

        private void Authrize_acbas_Shown(object sender, EventArgs e)
        {
            Delay(1000);

            Boolean ispp = false;

            while(true)
            {
                lbl_status.Text = "Get Server Response...";
                Delay(1000);

                String rsp = "";

                //v2 보안 강화 인증 시작
                postStringKey = new string[2];
                postStringValue = new string[2];

                if (sdvxwin.vender == "NOLJA") { postStringKey[0] = "vender"; postStringValue[0] = "NOLJA"; } //놀자 vender
                else { postStringKey[0] = "vender"; postStringValue[0] = sdvxwin.vender; } //그외 vender
                postStringKey[1] = "game"; postStringValue[1] = sdvxwin.setgame; //game

                //rsp = Program.PostHtmlString("https://service.stream-assistant-5.gekimoe.areatm.com/v2/checklicense/", postStringKey, postStringValue);
                rsp = Program.PostHtmlString("https://auth.stream-assistant-5.gekimoe.areatm.com/run/v3.0/", postStringKey, postStringValue);
                //v2 보안 강화 인증 끝

                if (rsp == "Authorized")
                {
                    sdvxwin.isCheckedGenuine = true;

                    // Full(full) 또는 Lite(mini) 라이선스 확인. 여기서는 "full" 라이선스로, "full"이(가) 아니면 실행 거부
                    lbl_status.Text = "Get more information to load assistant...";
                    string vender_swdf; //Software Devide Form
                    while (true)
                    {
                        //신 POST Code 시작
                        postStringKey = new string[3]; postStringValue = new string[3]; //보낼 키값 초기화
                        postStringKey[0] = "mode"; postStringValue[0] = "1"; //mode
                        postStringKey[1] = "vender"; postStringValue[1] = sdvxwin.vender; //key_vender
                        postStringKey[2] = "game"; postStringValue[2] = sdvxwin.setgame; //game

                        //vender_swdf = Program.PostHtmlString("https://service.stream-assistant-5.gekimoe.areatm.com/v2/checklicense/", postStringKey, postStringValue);
                        vender_swdf = Program.PostHtmlString("https://auth.stream-assistant-5.gekimoe.areatm.com/run/v3.0/", postStringKey, postStringValue);
                        //신 POST Code 끝

                        //여기는 "full" 라이선스 입니다!!
                        if (File.Exists("test") && (vender_swdf == "full" || vender_swdf == "mini")) //Test
                        {
                            lbl_status.Text = "PASS!(test) Please wait...";
                            Delay(1120);
                            break;
                        }
                        else if (vender_swdf == "full") //통과
                        {
                            lbl_status.Text = "PASS! Please wait...";
                            Delay(1120);
                            break;
                        }
                        else if (vender_swdf == "mini") //미통과
                        {
                            lbl_status.Text = "FAIL! Please check software license.";
                            sdvxwin.isCheckedGenuine = false;
                            Delay(1120);
                            break;
                        }
                        else //인터넷 미 연결 시 또는 서버 맛갔을 때
                        {
                            lbl_status.Text = "Cannot connect server. Try after 10 sec...";
                            Delay(10000); lbl_status.Text = "Get more information to load assistant...";
                        }
                    }

                    if (!sdvxwin.isCheckedGenuine) { break; } //미통과 강제 종료

                    lbl_status.Text = "Get some settings...";
                    //텍스트 일시 비활성화
                    /*sdvxwin.setqrinfo = GetHtmlString("https://streamassistant.sv.gekimoe.areatm.com/area/" + sdvxwin.vender + "/" + 
                        sdvxwin.setgame + "/qrinfo.otogeonpf.html");*/
                    sdvxwin.setqrinfo = "";
                    Delay(1000);

                    lbl_status.Text = "Done!";
                    Delay(1000);

                    if (!File.Exists("test"))
                    {
                        string rsp_0;
                        //구 GET Code(비활성화) 시작
                        /*
                        if (sdvxwin.vender == "NOLJA")
                        {
                            rsp_0 = Program.GetHtmlString("https://nolja.bizotoge.areatm.com/public/serverstatus?mode=5&submode=0&game=" +
                            sdvxwin.setgame + "&ver=" + sdvxwin.nolja_ver);
                        } //놀자
                        else
                        {
                            rsp_0 = Program.GetHtmlString("https://service.stream-assistant-5.gekimoe.areatm.com/public/serverstatus?mode=5&submode=0&vender=" +
                            sdvxwin.vender + "&game=" + sdvxwin.setgame + "&ver=" + sdvxwin.nolja_ver);
                        } //그외
                        */
                        //구 GET Code(비활성화) 끝

                        //신 POST Code 시작
                        postStringKey = new string[5]; postStringValue = new string[5]; //보낼 키값 초기화
                        postStringKey[0] = "mode"; postStringValue[0] = "5"; //모드선택(버전 관련)
                        postStringKey[1] = "submode"; postStringValue[1] = "0"; //서브모드 선택(버전 Input)
                        postStringKey[2] = "vender"; postStringValue[2] = sdvxwin.vender; //vender 입력
                        postStringKey[3] = "game"; postStringValue[3] = sdvxwin.setgame; //game 입력
                        postStringKey[4] = "ver"; postStringValue[4] = sdvxwin.nolja_ver; //버전 입력

                        while (true)
                        {
                            rsp_0 = Program.PostHtmlString("https://service.stream-assistant-5.gekimoe.areatm.com/v2/serverstatus/v1/", postStringKey, postStringValue); //보내기
                            if(rsp_0 == "Success") { break; }
                            else if(rsp_0 == "NoService") { MessageBox.Show("Now, service is going on maintenance."); }
                            else { Delay(2000); }
                        }
                        //신 POST Code 끝
                    }
                    Delay(1000);

                    //업데이트 로그 불러오는지 불러오기
                    if (File.Exists("update_success"))
                    {
                        DateTime fileVersion = File.GetLastWriteTime("update_success"); //언제 업데이트 했는지 파일 수정 시간으로 불러오기
                        TimeSpan ts = DateTime.Now - fileVersion; //시간 계산은 TimeSpan으로 진행

                        if (ts.TotalDays <= 2) //이틀 이내로 차이가 나면
                        {
                            sdvxwin.isUpdateLogWindowShow = true; //업데이트 로그 표시
                        }
                        else //아니면 그 파일 지우기
                        {
                            File.Delete("update_success");
                        }
                    }
                    break;
                }
                else if (rsp == "NotAuthorized")
                {
                    sdvxwin.isCheckedGenuine = false;
                    Delay(1000);
                    lbl_status.Text = "Not Authorized... Please ask for manager";
                    Delay(1000);
                    break;
                }
                else
                {
                    lbl_status.Text = "Cannot connect server. Try after 10 sec...";
                    Delay(10000);
                }
            }

            this.Close();
        }

        private void Authrize_acbas_Load(object sender, EventArgs e)
        {
            lbl_0.Font = new Font(sdvxwin.font_5_0_b.Families[0], 24f, FontStyle.Bold);
            lbl_status.Font = new Font(sdvxwin.font_5_0_r.Families[0], 11f);
            lbl_status.Text = "Please Wait...";
        }
    }
}
