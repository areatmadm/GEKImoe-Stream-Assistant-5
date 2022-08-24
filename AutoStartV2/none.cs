using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoStartV3
{
    public partial class None_N : Form
    {
        public None_N()
        {
            InitializeComponent();
        }

        private void none_Load(object sender, EventArgs e)
        {
            label1.Font = new Font(AutoStartV2.AutoStartV3Main.font_3_0_s.Families[0], 100f);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void None_N_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
