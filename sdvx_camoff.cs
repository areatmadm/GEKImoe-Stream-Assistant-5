using System;
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

using System.IO;
using System.Net;

namespace AreaTM_acbas
{
    public partial class sdvx_camoff : Form
    {
        int quick = 7200;
        int pd = 0;
        int qtemp;

        string sdname;
        string dd;

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

        public sdvx_camoff()
        {
            InitializeComponent();
        }

        private void howtochat_Load(object sender, EventArgs e)
        {
            
            NOLJA_BlackEdition();
        }

        private void howtochat_activate(object sender, EventArgs e)
        {
            
        }
        

        private void NOLJA_BlackEdition()
        {
            //lbl_info.Font = new Font(sdvxwin.font_3_0_s.Families[0], 15.75f);
            //btn_finishmute.Font= new Font(sdvxwin.font_3_0_s.Families[0], 14.25f);

            this.Font = new Font(sdvxwin.font_5_0_r.Families[0], 12f);//카카오 Regular, 12pt
            lbl_name.Font = new Font(sdvxwin.font_5_0_b.Families[0], 24f);
        }

        private void btn_off_Click(object sender, EventArgs e)
        {
            this.Hide();
            sdvxwin.sdvx_camoffstatus = 2;

            string nullSt;
            nullSt = GetHtmlString("https://nolja.bizotoge.areatm.com/public/plive/forgotid/sdvx_camstat.php?mod=twelv");//ban

            try
            {
                sdvxwin._obs.SetCurrentScene("camoff");
                timer1.Enabled = true;
            }
            catch
            {
                timer1.Enabled = false;
                sdvxwin.sdvx_camoffstatus = 0;
                this.Close();
            }

            
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(pd >= quick)
            {
                try
                {
                    sdvxwin._obs.SetCurrentScene("camon");
                    Delay(500);
                    sdvxwin.sdvx_camoffstatus = 0;
                }
                catch { }

                Delay(200);

                this.Close();
            }
            else if(sdvxwin._obs.GetCurrentScene().Name == "camon")
            {
                timer1.Enabled = false;

                pd = 0;
                sdvxwin.sdvx_camoffstatus = 0;
                this.Close();
            }

            pd += 1;
        }

        private void btn_offon_Click(object sender, EventArgs e)
        {
            sdvxwin.sdvx_camoffstatus = 1;

            sdvxwin._obs.SetCurrentScene("camoff");
            Delay(300);
            sdvxwin._obs.SetCurrentScene("camon");
            Delay(300);
            sdvxwin.sdvx_camoffstatus = 0;

            this.Close();
        }
    }
}
