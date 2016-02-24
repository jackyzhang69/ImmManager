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
using ToolLib;

namespace ImmManager
{

    public partial class BCPNP_EI : Form
    {
        // initialize a BCPNP EI Policy
        BCPNP_EI_policy eip = new BCPNP_EI_policy();


        //  Notice! should write validate codes in ToolLib to validate inputs




        public static int totalscore = 0;

        public BCPNP_EI()
        {
            InitializeComponent();
        }



        private void updateTotalScore()
        {
            int oep = int.Parse(OEPoints.Text);
            int smp = int.Parse(SMPoints.Text);
            int tca = int.Parse(lblTotalCurrentAssets.Text);
            int ta = int.Parse(lblTotalAssets.Text);
            int ei = int.Parse(lblEligibleInvestment.Text);
            int jc = int.Parse(lblJobCreation.Text);

            TotalScore.Text = (oep + smp + tca + ta + ei + jc).ToString(); //  update here ....
        }

        private void txtOEMonth_Leave(object sender, EventArgs e)
        {
            if (txtOEMonth.Text != "")
            {
                int m = int.Parse(txtOEMonth.Text);
                OEPoints.Text = Scoring.getScore(eip.OwnerScorePolicy, m).ToString();
                summaryExp();
            }

        }

        private void txtSMEMonths_Leave(object sender, EventArgs e)
        {
            if (txtSMEMonths.Text != "")
            {
                int m = int.Parse(txtSMEMonths.Text);
                SMPoints.Text = Scoring.getScore(eip.SeniorManagerScorePolicy, m).ToString();

                summaryExp();
            }
        }

        private void summaryExp()
        {

            lblExpScore.Text = (int.Parse(OEPoints.Text) + int.Parse(SMPoints.Text)).ToString();
            updateTotalScore();
        }

        private void txtTotalCurrentAssets_Leave(object sender, EventArgs e)
        {
            if (txtTotalCurrentAssets.Text != "")
            {
                int ca = int.Parse(txtTotalCurrentAssets.Text);
                lblTotalCurrentAssets.Text = Scoring.getScore(eip.CurrentAssetPolicy, ca).ToString();
                summaryAsset();
            }
        }



        private void txtTotalAssets_Leave(object sender, EventArgs e)
        {
            if (txtTotalAssets.Text != "")
            {
                int ta = int.Parse(txtTotalAssets.Text);
                lblTotalAssets.Text = Scoring.getScore(eip.NetAssetPolicy, ta).ToString();
                summaryAsset();
            }
        }

        private void summaryAsset()
        {

            lblAssetScore.Text = (int.Parse(lblTotalCurrentAssets.Text) + int.Parse(lblTotalAssets.Text)).ToString();
            updateTotalScore();
        }

        private void finalCheck()
        {
            //if(txtTotalCurrentAssets.Text!="" && txtTotalAssets.Text!="")
            //{
            //    if(int.Parse(txtTotalCurrentAssets.Text) > int.Parse(txtTotalAssets.Text))
            //    {
            //        lblTotalCurrentAssets.Text = "0";
            //        lblTotalAssets.Text = "0";
            //        txtTotalCurrentAssets.Text = "0";
            //        txtTotalAssets.Text = "0";
            //        MessageBox.Show("How could current assets much more than net assets?");

            //    } 
            //}

            //if(txtOEMonth.Text != "" && txtSMEMonths.Text != "")
            //{
            //    if((int.Parse(txtOEMonth.Text) + int.Parse(txtSMEMonths.Text)) > 120)
            //    {
            //        MessageBox.Show("How could your work experience more than 120 months during past 10 years?");
            //        SMPoints.Text = "0";
            //    }
            //}

        }

        private void txtEligibleInvestment_Leave(object sender, EventArgs e)
        {
            if (txtEligibleInvestment.Text != "")
            {
                int ei = int.Parse(txtEligibleInvestment.Text);
                if (ei >= 0 && ei < 200000) lblEligibleInvestment.Text = "0";
                else if (ei >= 200000 && ei < 400000) lblEligibleInvestment.Text = "6";
                else if (ei >= 400000 && ei < 1000000) lblEligibleInvestment.Text = "20";
                else if (ei >= 1000000) lblEligibleInvestment.Text = "30";
                else
                {
                    lblEligibleInvestment.Text = "0";
                    MessageBox.Show("Invalid input");

                }
                lblEligibleInvestScore.Text = int.Parse(lblEligibleInvestment.Text).ToString();
                updateTotalScore();
            }
        }

        private void txtJobCreation_Leave(object sender, EventArgs e)
        {
            if (txtJobCreation.Text != "")
            {
                int jc = int.Parse(txtJobCreation.Text);
                if (jc == 0) lblJobCreation.Text = "0";
                else if (jc == 1) lblJobCreation.Text = "2";
                else if (jc == 2) lblJobCreation.Text = "6";
                else if (jc >= 3 && jc <= 4) lblJobCreation.Text = "12";
                else if (jc >= 5 && jc <= 6) lblJobCreation.Text = "20";
                else if (jc >= 7 && jc <= 8) lblJobCreation.Text = "28";
                else if (jc >= 9 && jc <= 10) lblJobCreation.Text = "32";
                else if (jc >= 11) lblJobCreation.Text = "36";

                else
                {
                    lblJobCreation.Text = "0";
                    MessageBox.Show("Invalid input");

                }
                lblTotalJobScore.Text = int.Parse(lblJobCreation.Text).ToString();
                updateTotalScore();
            }
        }


    }
}
