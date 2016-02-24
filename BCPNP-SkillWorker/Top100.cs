using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CIPolicyLib;

namespace ImmManager
{
    public partial class Top100 : Form
    {
        BCPNP_SW_Policy swp = new BCPNP_SW_Policy();
        
        public Top100()
        {
            InitializeComponent();
            
            
            dgvTop100.DataSource = swp.top100NOC1;

            DataTable dt = new DataTable();
            dt.Columns.Add("Occupation");
            dt.Columns.Add("Job Opens");
            dt.Columns.Add("Median Wage");
            dt.Columns.Add("NOC");
            dt.Columns.Add("Level");

            foreach (BCPNP_SW_Policy.Occupation ocp in swp.top100NOC1)
            {
                 dt.Rows.Add(ocp.occupation, ocp.jobOpens, ocp.medianWage, ocp.noc,ocp.level);
            }
            dgvTop100.DataSource = dt;
            
            for(int i=0;i<dgvTop100.Rows.Count;i++)
            {
                if (i % 2 == 0) dgvTop100.Rows[i].DefaultCellStyle.BackColor = Color.Red;
            
            }
            dgvTop100.Columns[0].Width = swp.top100NOC1.Max(x=>x.occupation.Length)*4;
           
            //dgvTop100.Columns[1].Width = swp.top100NOC1.Max(x => x.jobOpens.ToString().Length) * 20;
            //dgvTop100.Columns[2].Width = swp.top100NOC1.Max(x => x.medianWage.ToString().Length) * 20;
            //dgvTop100.Columns[3].Width = swp.top100NOC1.Max(x => x.noc.Length) * 20;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void r(object sender, DataGridViewAutoSizeModeEventArgs e)
        {

        }

        private void dgvTop100_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int i = dgvTop100.SelectedRows[0].Index;
            
            Enviorment.f1.txtNocBonus.Text = swp.top100NOC1[i].noc.ToString();
                      
            this.Close();
        }
    }
}
