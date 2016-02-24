using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BCPNP_SkillWorker
{
    public partial class SkillWorker : Form
    {
        public SkillWorker()
        {
            InitializeComponent();
           
           
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BCPNP_Skill_Worker frm = new BCPNP_Skill_Worker();
            frm.Show();
        }
    }
}
