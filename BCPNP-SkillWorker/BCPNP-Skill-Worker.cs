using System;
using System.Drawing;
using System.Windows.Forms;
using CIPolicyLib;
using ToolLib;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;

namespace ImmManager
{

    public partial class BCPNP_Skill_Worker : Form
    {
        // initialize a BCPNP Skill Worker Policy
        BCPNP_SW_Policy swp = new BCPNP_SW_Policy();
        //CLB clb = new CLB();


        public BCPNP_Skill_Worker()
        {
            InitializeComponent();

            // initialize education combo box

            for (int i = 0; i < swp.education.Length / 2; i++)
            {
                cmbEducaton.Items.Add(swp.education[i, 0]);
            }

            // initialize education bonus combo box
            for (int i = 0; i < swp.eduBonus.Length / 2; i++)
            {
                cmbEduBonus.Items.Add(swp.eduBonus[i, 0]);
            }

            // initialize region combo box
            for (int i = 0; i < swp.region.Length / 2; i++)
            {
                cmbRegion.Items.Add(swp.region[i, 0]);
            }
            // initialize Language type combo box

            for (int i = 0; i < CLB.TestType.Length; i++)
            {
                cmbTestType.Items.Add(CLB.TestType[i]);
            }
            cmbTestType.SelectedIndex = 1; // set default selection is IETLS

        }

        private void txtNocBonus_Leave(object sender, EventArgs e)
        {
            NOCScoreCalculation();
        }
        private void txtWage_Leave(object sender, EventArgs e)
        {

            float value;

            if (txtWage.Text != "" && float.TryParse(txtWage.Text, out value) && YRateValid(float.Parse(txtWage.Text)))
            {
                // get score from Scoring
                lblWagePoints.Text = Scoring.getScore(swp.wagePoints, ((int)float.Parse(txtWage.Text))).ToString();
                // Send Annual income to wage calculation and calculate all kind of wages
                txtYrate.Text = float.Parse(txtWage.Text).ToString("0.00");
                YRateToMRate(float.Parse(txtWage.Text));
                YRateToHRate(float.Parse(txtWHWeekly.Text), float.Parse(txtYrate.Text));
                // update all scores
                updateTotalScore();
            }
            else
            {
                lblWagePoints.Text = "0";
                updateTotalScore();
            }

        }
        private void txtWage_TextChanged(object sender, EventArgs e)
        {
            float anyvalue=0f;
            if (txtWage.Text != "" && float.TryParse(txtWage.Text, out anyvalue))
            {
                lblWagePoints.Text = Scoring.getScore(swp.wagePoints, ((int)float.Parse(txtWage.Text))).ToString();
                updateTotalScore();
            }
        }
        private void cbxCurrentWork_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxCurrentWork.Checked == true) lblCurrentWorkPoints.Text = "10";
            else lblCurrentWorkPoints.Text = "0";
            updateTotalScore();
        }
        private void txtDirectWorkExp_TextChanged(object sender, EventArgs e)
        {
            float value;
            if (txtDirectWorkExp.Text != "" && float.TryParse(txtDirectWorkExp.Text, out value))
            {
                lblDirectWorkExpPoints.Text = Scoring.getScore(swp.workExperiencePoints, float.Parse(txtDirectWorkExp.Text)).ToString();
                updateTotalScore();
            }
            else
            {
                lblDirectWorkExpPoints.Text = "0";
                updateTotalScore();
            }
        }
        private void txtNocBonus_TextChanged(object sender, EventArgs e)
        {
            if (txtNocBonus.Text.Length == 4) NOCScoreCalculation();
        }
        private void cbxCanadianExp_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxCanadianExp.Checked == true) lblCanadianExpPoints.Text = "10";
            else lblCanadianExpPoints.Text = "0";
            updateTotalScore();
        }
        private void txtCLBLevel_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (txtCLBLevel.Text != "" && int.TryParse(txtCLBLevel.Text, out value))
            {
                lblCLBpoints.Text = Scoring.getScore(swp.CLBLevel, int.Parse(txtCLBLevel.Text)).ToString(); // Get score
                updateTotalScore();
            }
            else
            {
                lblCLBpoints.Text = "0";
                updateTotalScore();
            }
        }
        private void txtCLBLevel_Leave(object sender, EventArgs e)
        {
            // get detailed 4 scores of reading, writing, lisenting and speaking
           

            switch (cmbTestType.SelectedIndex)
            {

                case 0:
                    clearDetail4Scores();
                    break;

                case 1:
                    if (txtCLBLevel.Text != "") fill4Ielts();
                    else clearDetail4Scores();
                    break;
                case 2:
                    if (txtCLBLevel.Text != "") fill4Celpip();
                    else clearDetail4Scores();
                    break;
                case 3:
                    if (txtCLBLevel.Text != "") fill4Celpip13();
                    else clearDetail4Scores();
                    break;
                default:
                    break;
            }
        }

        private string fill4Celpip13()
        {
            string scores2;
            if (txtCLBLevel.Text != "") scores2 = CLB.CLBtoCELPIPG13(int.Parse(txtCLBLevel.Text));
            else scores2 = "0";
            txtReading.Text = scores2;
            txtWriting.Text = scores2;
            txtListening.Text = scores2;
            txtSpeaking.Text = scores2;
            return scores2;
        }

        private List<int> fill4Celpip()
        {
            List<int> scores1;
            if (txtCLBLevel.Text != "") scores1 = CLB.CLBtoCELPIPG(int.Parse(txtCLBLevel.Text));
            else scores1 = new List<int> { 0, 0, 0, 0 };
            if (scores1[0] != 0f && scores1[1] != 0f && scores1[2] != 0f && scores1[3] != 0f)
            {
                txtReading.Text = scores1[0].ToString();
                txtWriting.Text = scores1[1].ToString();
                txtListening.Text = scores1[2].ToString();
                txtSpeaking.Text = scores1[3].ToString();
            }

            return scores1;
        }

        private List<float> fill4Ielts()
        {
            List<float> scores;
            if (txtCLBLevel.Text != "") scores = CLB.CLBtoIELTSG(int.Parse(txtCLBLevel.Text));
            else scores = new List<float> { 0f, 0f, 0f, 0f };
            if (scores[0] != 0f && scores[1] != 0f && scores[2] != 0f && scores[3] != 0f)
            {
                txtReading.Text = scores[0].ToString("0.0");
                txtWriting.Text = scores[1].ToString("0.0");
                txtListening.Text = scores[2].ToString("0.0");
                txtSpeaking.Text = scores[3].ToString("0.0");
            }

            return scores;
        }

        private void clearDetail4Scores()
        {
            txtReading.Text = "0";
            txtWriting.Text = "0";
            txtListening.Text = "0";
            txtSpeaking.Text = "0";
        }

        private void cmbEducaton_SelectionChangeCommitted(object sender, EventArgs e)
        {

            lblEducationPoints.Text = Scoring.getScore(swp.education, cmbEducaton.SelectedIndex).ToString();
            updateTotalScore();
        }
        private void cmbEduBonus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lblEduBonusPoints.Text = Scoring.getScore(swp.eduBonus, cmbEduBonus.SelectedIndex).ToString();
            updateTotalScore();
        }
        private void cmbRegion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lblRegionalPoints.Text = Scoring.getScore(swp.region, cmbRegion.SelectedIndex).ToString();
            updateTotalScore();
        }
        private void lklblJobBank_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String url = "http://www.jobbank.gc.ca/show-search-results.do?reportOption=wage&titleKeyword=" + txtNocBonus.Text + "&searchJobTitle=Search";
            Process.Start(url);
        }

        // Pick up the occupation and send back NOC code
        private void btnTop100_Click(object sender, EventArgs e)
        {
            // open a new form to pick top 100 occupations and send the NOC code to main form NOC field
            Top100 pickNOC = new Top100();
            pickNOC.Show();

        }

        // Working time, hourly wage, monthly wage, and annual wage calculation
        private void txtWHWeekly_Leave(object sender, EventArgs e)
        {

            if (txtWHWeekly.Text != "")
            {
                float whweekly = float.Parse(txtWHWeekly.Text);
                if (Validation.isValidated(30f, 40f, whweekly))
                {


                    if (txtHRate.Text != "" && Validation.isValidated(BCPNP_SW_Policy.lowestWage, float.Parse(txtHRate.Text)))
                    {
                        float hrate = float.Parse(txtHRate.Text);
                        HRateToMRate(whweekly, hrate);
                        HRateToYRate(whweekly, hrate);
                    }
                    else if (txtMRate.Text != "" && MRateValid(float.Parse(txtMRate.Text)))
                    {
                        float mrate = float.Parse(txtMRate.Text);
                        MRateToYRate(whweekly, mrate);
                        MRateToHRate(whweekly, mrate);
                    }
                    else if (txtYrate.Text != "" && YRateValid(float.Parse(txtYrate.Text)))
                    {
                        float yrate = float.Parse(txtYrate.Text);
                        YRateToMRate(yrate);
                        YRateToHRate(whweekly, yrate);

                    }
                }
                else
                {

                    MessageBox.Show("Weekly working hours must be between 30 to 40");
                }

            }

        }
        private void txtYrate_Leave(object sender, EventArgs e)
        {
            if (txtYrate.Text != "" && txtWHWeekly.Text != "" && YRateValid(float.Parse(txtYrate.Text)))
            {

                YRateToMRate(float.Parse(txtYrate.Text));
                YRateToHRate(float.Parse(txtWHWeekly.Text), float.Parse(txtYrate.Text));
            }
        }
        private void txtYrate_TextChanged(object sender, EventArgs e)
        {
            txtWage.Text = float.Parse(txtYrate.Text).ToString();
        }
        private void txtMRate_Leave(object sender, EventArgs e)
        {
            if (txtMRate.Text != "" && txtWHWeekly.Text != "" && MRateValid(float.Parse(txtMRate.Text)))
            {
                MRateToHRate(float.Parse(txtWHWeekly.Text), float.Parse(txtMRate.Text));
                MRateToYRate(float.Parse(txtWHWeekly.Text), float.Parse(txtMRate.Text));
            }
        }



        // Validation check based on BC lowest hourly wage
        private bool YRateValid(float yrate)
        {
            return Validation.isValidated(BCPNP_SW_Policy.lowestWage * 30 * 365 / 7, yrate);
        }
        private bool MRateValid(float mrate)
        {
            return Validation.isValidated(BCPNP_SW_Policy.lowestWage * 30 * 365 / 7 / 12, mrate);
        }

        // Rate convert functions  
        private void YRateToMRate(float yrate)
        {
            txtMRate.Text = (yrate / 12).ToString("0.00");
        }
        private void YRateToHRate(float whweekly, float yrate)
        {
            txtHRate.Text = (yrate / (365 / 7) / whweekly).ToString("0.00");
        }
        private void MRateToYRate(float whweekly, float mrate)
        {
            txtYrate.Text = (mrate * 12).ToString("0.00");
        }
        private void MRateToHRate(float whweekly, float mrate)
        {
            txtHRate.Text = (mrate * 12 / (365 / 7) / whweekly).ToString("0.00");
        }
        private void HRateToMRate(float whweekly, float hrate)
        {
            txtMRate.Text = (hrate * whweekly * 365 / 7 / 12).ToString("0.00");

        }
        private void HRateToYRate(float whweekly, float hrate)
        {
            txtYrate.Text = (hrate * whweekly * 365 / 7).ToString("0.00");

        }

        // update all scores to total
        public void updateTotalScore()
        {
            int nocbonus = int.Parse(lblNOCBonusPoints.Text);
            int joblevel = int.Parse(lblJobLevelPoints.Text);
            int top100 = int.Parse(inTop100Score.Text);
            int currentWKPoints = int.Parse(lblCurrentWorkPoints.Text);
            int wagePoints = int.Parse(lblWagePoints.Text);
            int regionPoints = int.Parse(lblRegionalPoints.Text);
            int directWKExpPoints = int.Parse(lblDirectWorkExpPoints.Text);
            int cndExpPoints = int.Parse(lblCanadianExpPoints.Text);
            int educationPoints = int.Parse(lblEducationPoints.Text);
            int clbPoints = int.Parse(lblCLBpoints.Text);
            int edubns = int.Parse(lblEduBonusPoints.Text);
            lblTotalPoints.Text = (nocbonus + joblevel + top100 + currentWKPoints + wagePoints + regionPoints + directWKExpPoints + cndExpPoints + educationPoints + edubns + clbPoints).ToString();

        }
        private void NOCScoreCalculation()
        {
            // Check if NOC includes 00
            int value;
            if (txtNocBonus.Text != "" && txtNocBonus.Text.Length == 4 && int.TryParse(txtNocBonus.Text, out value))
            {
                if (txtNocBonus.Text[0] == '0' && txtNocBonus.Text[1] == '0') lblNOCBonusPoints.Text = "15";
                else lblNOCBonusPoints.Text = "0";


                if (txtNocBonus.Text.Length == 4)  // after noc code finish, then decide whether it belongs to top 100
                {
                    if (swp.top100NOC.Contains(int.Parse(txtNocBonus.Text)))
                    {
                        inTop100Score.Text = "10";
                        lblTop100.ForeColor = Color.Green;
                        lblTop100.Text = "Your job is in top 100. 10 bonus points granted";
                    }
                    else
                    {
                        inTop100Score.Text = "0";
                        lblTop100.ForeColor = Color.Red;
                        lblTop100.Text = "Your job is not in top 100. No bonus point";
                    }
                }
                if (txtNocBonus.Text[0] == '0')
                {
                    lblJobLevel.Text = "0";
                    lblJobLevelPoints.Text = "25";
                }
                else
                {
                    char var = Scoring.getScore(swp.NOC, txtNocBonus.Text[1]);
                    lblJobLevel.Text = var.ToString();
                    lblJobLevelPoints.Text = Scoring.getScore(swp.jobLevel, var).ToString();
                }
            }
            else if (txtNocBonus.Text != "") MessageBox.Show("Invalid NOC Code! Do it again");
            updateTotalScore();
        }
        private void txtSpeaking_TextChanged(object sender, EventArgs e)
        {
            if (txtListening.Text != "" && txtReading.Text != "" && txtWriting.Text != "" && txtSpeaking.Text != "" && isAllValidated())
            {

                txtCLBLevel.Text = CLBConvert().ToString();
            }
        }

        private void txtListening_TextChanged(object sender, EventArgs e)
        {
            if (txtListening.Text != "" && txtReading.Text != "" && txtWriting.Text != "" && txtSpeaking.Text != "" && isAllValidated())
            {

                txtCLBLevel.Text = CLBConvert().ToString();
            }
        }

        private void txtReading_TextChanged(object sender, EventArgs e)
        {
            if (txtListening.Text != "" && txtReading.Text != "" && txtWriting.Text != "" && txtSpeaking.Text != "" && isAllValidated())
            {

                txtCLBLevel.Text = CLBConvert().ToString();
            }
        }

        private void txtWriting_TextChanged(object sender, EventArgs e)
        {
            if (txtListening.Text != "" && txtReading.Text != "" && txtWriting.Text != "" && txtSpeaking.Text != "" && isAllValidated())
            {

                txtCLBLevel.Text = CLBConvert().ToString();
            }
        }
        // Enter key down events        
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void txtNocBonus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void txtWage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void txtDirectWorkExp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void cmbEduBonus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void txtCLBLevel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void cmbRegion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void cbxCurrentWork_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void cbxCanadianExp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void cmbEducaton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void txtWHWeekly_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }

        }
        private void txtHRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void txtHRate_Leave(object sender, EventArgs e)
        {
            if (txtHRate.Text != "" && txtWHWeekly.Text != "")
            {
                if (Validation.isValidated(BCPNP_SW_Policy.lowestWage, float.Parse(txtHRate.Text)))
                {
                    HRateToMRate(float.Parse(txtWHWeekly.Text), float.Parse(txtHRate.Text));
                    HRateToYRate(float.Parse(txtWHWeekly.Text), float.Parse(txtHRate.Text));
                }
                else
                {

                    MessageBox.Show("Hourly rate must be higher than BC's lowest rage $10.25");
                }

            }
        }
        private void txtYrate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void txtMRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void txtListening_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void cmbTestType_DragEnter(object sender, DragEventArgs e)
        {
            //if (e.KeyCode.Equals(Keys.Enter))
            //{
            //    SendKeys.Send("{TAB}");
            //}
        }
        private void txtReading_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void txtWriting_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void txtSpeaking_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }


        public bool isAllValidated()
        {
            float tryout;
            int outtry;
            switch (cmbTestType.SelectedIndex)
            {
                case 0:
                    return false;
                case 1:  //LELTS
                    if (float.TryParse(txtListening.Text, out tryout) && float.TryParse(txtReading.Text, out tryout) && float.TryParse(txtWriting.Text, out tryout) && float.TryParse(txtSpeaking.Text, out tryout)) return true;
                    else return false;

                case 2:// CELPIP G 14
                    if (int.TryParse(txtListening.Text, out outtry) && int.TryParse(txtReading.Text, out outtry) && int.TryParse(txtWriting.Text, out outtry) && int.TryParse(txtSpeaking.Text, out outtry)) return true;
                    else return false;

                case 3: //CELPIP G 13
                    // validate two chars
                    if (txtListening.Text.Length != 2 || txtWriting.Text.Length != 2 || txtReading.Text.Length != 2 || txtSpeaking.Text.Length != 2) return false;
                    // switch any input to upper letter
                    txtReading.Text = txtReading.Text.ToUpper();
                    txtWriting.Text = txtWriting.Text.ToUpper();
                    txtSpeaking.Text = txtSpeaking.Text.ToUpper();
                    txtListening.Text = txtListening.Text.ToUpper();
                    List<string> celpip = new List<string> { "2H", "3L", "3H", "4L", "4H", "5L", "5H" };

                    //if ((int.Parse(txtListening.Text[0].ToString()) >= 2 && int.Parse(txtListening.Text[0].ToString()) <= 5) &&
                    //   (int.Parse(txtReading.Text[0].ToString()) >= 2 && int.Parse(txtReading.Text[0].ToString()) <= 5) &&
                    //   (int.Parse(txtWriting.Text[0].ToString()) >= 2 && int.Parse(txtWriting.Text[0].ToString()) <= 5) &&
                    //   (int.Parse(txtSpeaking.Text[0].ToString()) >= 2 && int.Parse(txtSpeaking.Text[0].ToString()) <= 5))
                    //{

                    //    if ((txtListening.Text[1] == 'H' || txtListening.Text[1] == 'L') && (txtReading.Text[1] == 'H' || txtReading.Text[1] == 'L') &&
                    //        (txtWriting.Text[1] == 'H' || txtWriting.Text[1] == 'L') && (txtSpeaking.Text[1] == 'H' || txtSpeaking.Text[1] == 'L'))
                    //        return true;
                    //    else return false;
                    if (celpip.Contains(txtListening.Text) && celpip.Contains(txtReading.Text) && celpip.Contains(txtSpeaking.Text) && celpip.Contains(txtWriting.Text)) return true;

                    else return false;

                default:
                    return false;


            }

        }

        public int CLBConvert()
        {

            switch (cmbTestType.SelectedIndex)
            {
                case 0:
                    return 0;
                case 1:  //LELTS
                    return CLB.IELTSGtoCLB(float.Parse(txtReading.Text), float.Parse(txtWriting.Text), float.Parse(txtListening.Text), float.Parse(txtSpeaking.Text));

                case 2:   // CELPIP G 14
                    return CLB.CELPIPGtoCLB(int.Parse(txtReading.Text), int.Parse(txtWriting.Text), int.Parse(txtListening.Text), int.Parse(txtSpeaking.Text));

                case 3: //CELPIP G 13
                    return CLB.CELPIPG13toCLB(txtReading.Text, txtWriting.Text, txtListening.Text, txtSpeaking.Text);
                default:
                    return 0;
            }

        }

        private void cmbTestType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (cmbTestType.SelectedIndex)
            {
                case 0:
                    clearDetail4Scores();
                    break;
                case 1:
                    if (txtCLBLevel.Text != "") fill4Ielts();
                    break;
                case 2:
                    if (txtCLBLevel.Text != "") fill4Celpip();
                    break;
                case 3:
                    if (txtCLBLevel.Text != "") fill4Celpip13();
                    break;
                default:
                    break;
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            SWInfo sw = new SWInfo();
            if(txtClient.Text!="") sw.Client = txtClient.Text;
            else
            {
                MessageBox.Show("Please enter your client's name");
                return;
            }
            sw.NOC= txtNocBonus.Text;
            if (lblTotalPoints.Text != "0") sw.TotalPoints = int.Parse(lblTotalPoints.Text);
            else
            {
                MessageBox.Show("You didn't even do anything. Why so hurry to generate report?!");
                return;
            }
            if (int.Parse(inTop100Score.Text) != 0) sw.Intop100 = true;
            else sw.Intop100 = false;
           
            //sw.SkillLevel=char.Parse(lblJobLevel.Text);
            //if (cbxCurrentWork.Checked) sw.CurrentWorkInBCPosition = true;
            //else sw.CurrentWorkInBCPosition =false;

            //if(txtWage.Text!="") sw.Wage = float.Parse(txtWage.Text);
            //else
            //{
            //    MessageBox.Show("Pleae input annual wage");
            //    return;
            //}

            //if (cmbRegion.SelectedIndex > -1)
            //{
                
            //    sw.Region = swp.region[cmbRegion.SelectedIndex,0];
            //}
            //else
            //{
            //    MessageBox.Show("Pleae select the work region");
            //    return;
            //}

            //if (txtDirectWorkExp.Text!="") sw.DirectWorkExperience = float.Parse(txtDirectWorkExp.Text);
            //else
            //{
            //    MessageBox.Show("Pleae input direct work experience");
            //    return;
            //}

            //if (cbxCanadianExp.Checked) sw.OneYearDirectExperienceInCanada = true;
            //else sw.OneYearDirectExperienceInCanada = false;

            //if (cmbEducaton.SelectedIndex > -1)
            //{
            //    sw.Education = swp.education[cmbEducaton.SelectedIndex,0];
            //}
            //else
            //{
            //    MessageBox.Show("Pleae select education level");
            //    return;
            //}

            //if (cmbEduBonus.SelectedIndex > -1) sw.EducationBonus = swp.eduBonus[cmbEduBonus.SelectedIndex,0];
            //else
            //{
            //    MessageBox.Show("Pleae select education bonus");
            //    return;
            //}
            //if (txtCLBLevel.Text != "") sw.CLB = int.Parse(txtCLBLevel.Text);
            //else
            //{
            //    MessageBox.Show("Pleae input CLB level");
            //    return;
            //}


            sw.NocBonusPoints=int.Parse(lblNOCBonusPoints.Text);
            sw.JobLevelPoints=int.Parse(lblJobLevelPoints.Text);
            sw.Top100Bonus=int.Parse(inTop100Score.Text);
            sw.CurrentWorkPoints=int.Parse(lblCurrentWorkPoints.Text);
            sw.WagePoints=int.Parse(lblWagePoints.Text);
            sw.RegionPoints=int.Parse(lblRegionalPoints.Text);
            sw.DirectWorkExperiencePoints=int.Parse(lblDirectWorkExpPoints.Text);
            sw.OneYearDirectExperienceInCanadaPoints=int.Parse(lblCanadianExpPoints.Text);
            sw.EducationPoints=int.Parse(lblEducationPoints.Text);
            sw.EducationBonusPoints=int.Parse(lblEduBonusPoints.Text);
            sw.CLBPoints=int.Parse(lblCLBpoints.Text);

            //txtWHWeekly.Text;
            //txtHRate.Text;
            //txtMRate.Text;
            //txtYrate.Text;

            //cmbTestType.Text;
            //txtListening.Text;
            //txtReading.Text;
            //txtWriting.Text;
            //txtSpeaking.Text;


            Report.generateReport(sw);

        }
    }
}



