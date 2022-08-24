using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AreaTM_acbas
{
    public partial class drumwin : Form
    {
        public drumwin()
        {
            InitializeComponent();
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


        private void drumwin_Load(object sender, EventArgs e)
        {
            lbl_font.Text = "(c) 2019-2022 AreaTM GEKImoe" + "\r\n" +
                "This assistant can use only in Game Center, authorized by AreaTM GEKImoe." + "\r\n\r\n" +
                "Font Copyright (c) NAVER Corp." + "\r\n" + 
                "Chromium, OBS-Websocket, Gecko의 오픈소스가 사용되었습니다.";
            textBox1.Text = "";

            NOLJA_BlackEdition_Set();

            textBox1.Text += "아레아티엠 게키모에 스트리밍 어시스턴트 5.0 업데이트 내용" + "\r\n" +
                "업데이트 내용은 웹사이트에서 확인해 주세요." + "\r\n" +
                "- https://areatm.com/gekimoe_streamassistant" + "\r\n" +
                "------------------------------" + "\r\n" + "\r\n";
        }

        private void NOLJA_BlackEdition_Set()
        {
            UPD_NDIdD.Font = new Font(sdvxwin.font_5_0_b.Families[0], 35f);
            lbl_font.Font = new Font(sdvxwin.font_5_0_r.Families[0], 11.2f);
            textBox1.Font = new Font(sdvxwin.font_5_0_r.Families[0], 11f);
        }

        private void btn_openlicense_Click(object sender, EventArgs e)
        {
            Form license = new license_used();
            license.ShowDialog();
        }
    }
}
