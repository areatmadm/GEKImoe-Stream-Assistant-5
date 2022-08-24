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
    public partial class license_used : Form
    {
        public license_used()
        {
            InitializeComponent();
        }

        private void license_used_Load(object sender, EventArgs e)
        {
            NOLJA_BlackEdition_Set();
        }

        private void NOLJA_BlackEdition_Set()
        {
            this.BackColor = sdvxwin.chinatsu_black;
            this.ForeColor = sdvxwin.chinatsu_white;
        }
    }
}
