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

            for(int i=0; i<10; i+=0)
            {
                lbl_status.Text = "Get Server Response...";
                Delay(1000);

                String rsp = "";
                if (!File.Exists("vender.txt")) { sdvxwin.vender = "NOLJA"; }
                else
                { sdvxwin.vender = File.ReadAllText("vender.txt"); }

                if (sdvxwin.vender == "NOLJA") { rsp = GetHtmlString("https://nolja.bizotoge.areatm.com/public/checklicense?vender=NOLJA&game=" + 
                    sdvxwin.setgame); } //놀자 인증
                else {
                    rsp = GetHtmlString("https://service.stream-assistant-5.gekimoe.areatm.com/public/checklicense?vender=" + sdvxwin.vender + "&game=" +
                    sdvxwin.setgame); } //그외 인증

                if (rsp == "Authorized")
                {
                    sdvxwin.isCheckedGenuine = true;

                    if (!File.Exists("test"))
                    {
                        string rsp_0;
                        if (sdvxwin.vender == "NOLJA") { rsp_0 = GetHtmlString("https://nolja.bizotoge.areatm.com/public/serverstatus?mode=5&submode=0&game=" +
                            sdvxwin.setgame + "&ver=" + sdvxwin.nolja_ver); } //놀자
                        else { rsp_0 = GetHtmlString("https://service.stream-assistant-5.gekimoe.areatm.com/public/serverstatus?mode=5&submode=0&vender=" +
                            sdvxwin.vender + "&game=" + sdvxwin.setgame + "&ver=" + sdvxwin.nolja_ver); } //그외
                    }
                    Delay(1000);
                    lbl_status.Text = "Get some settings...";
                    sdvxwin.setqrinfo = GetHtmlString("https://streamassistant.sv.gekimoe.areatm.com/area/" + sdvxwin.vender + "/" + 
                        sdvxwin.setgame + "/qrinfo.otogeonpf.html");
                    Delay(1000);

                    lbl_status.Text = "Done!";
                    Delay(1000);
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
