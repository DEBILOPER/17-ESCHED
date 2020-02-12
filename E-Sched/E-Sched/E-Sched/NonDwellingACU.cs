using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Sched
{
    public partial class NonDwellingACU : Form
    {
        public PhaseType phase;
        public string voltAmpere;
        public string description;
        public bool cancel;
        public float ampere;
        public VoltageValue volt;

        private DialogResult result;
        private Three_Phase_AC_Motor motor;

        public NonDwellingACU()
        {
            InitializeComponent();
        }

        private void exit_Btn_Click(object sender, EventArgs e)
        {
            result = MessageBox.Show("DO YOU WANT TO EXIT?", "EXIT?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                cancel = true;
                this.Close();
            }
        }

        private void NonDwellingACU_Load(object sender, EventArgs e)
        {
            phase = PhaseType.None;
            voltAmpere = description = string.Empty;
            cancel = false;

            motor = Three_Phase_AC_Motor.None;

            INDUCTION.Enabled = false;
            SYNCHRONOUS.Enabled = false;

            SINGLE.Checked = false;
            TWO.Checked = false;
            THREE.Checked = false;

            if (phase == PhaseType.ThreePhase)
                THREE.Enabled = false;

            horsePower.Enabled = false;
            horsePower.Clear();
        }

        private void ok_Btn_Click(object sender, EventArgs e)
        {
            if (SINGLE.Checked == false && TWO.Checked == false && THREE.Checked == false)
            {
                MessageBox.Show("PLEASE SELECT TYPE OF AC MOTOR!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if(horsePower.selectedValue == string.Empty)
            {
                MessageBox.Show("PLEASE SELECT TYPE OF 3 PHASE AC MOTOR!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (SINGLE.Checked)
            {
                if (horsePower.selectedValue == string.Empty)
                    throw new Exception("PLEASE SELECT HORSEPOWER");
                
                ampere = singlePhaseAmp(horsePower.selectedValue);
                float VA = 230f * ampere;
                volt = VoltageValue.SINGLEPHASE_VOLTAGE;

                voltAmpere = VA.ToString();
                description = "ACU";

                cancel = false;
                this.Close();
            }
            else if (TWO.Checked)
            {
                if (horsePower.selectedValue == string.Empty)
                    throw new Exception("PLEASE SELECT HORSEPOWER");

                ampere = twoPhaseAmp(horsePower.selectedValue);
                float VA = 230f * ampere;
                volt = VoltageValue.SINGLEPHASE_VOLTAGE;

                voltAmpere = VA.ToString();
                description = "ACU";

                cancel = false;
                this.Close();
            }
            else if (THREE.Checked)
            {
                if (!INDUCTION.Checked && !SYNCHRONOUS.Checked)
                    throw new Exception("PLEASE SELECT TYPE OF AC MOTOR");

                if (INDUCTION.Checked)
                {
                    if (horsePower.selectedValue == string.Empty)
                        throw new Exception("PLEASE SELECT HORSEPOWER");
                    
                    ampere = threePhaseInductionAmp(horsePower.selectedValue);
                    float VA = 400f * ampere;
                    volt = VoltageValue.THREEPHASE_VOLTAGE;

                    voltAmpere = VA.ToString();
                    description = "ACU";

                    cancel = false;
                    this.Close();
                }
                else if (SYNCHRONOUS.Checked)
                {
                    if (horsePower.selectedValue == string.Empty)
                        throw new Exception("PLEASE SELECT HORSEPOWER");
                    
                    ampere = threePhaseInductionAmp(horsePower.selectedValue);
                    float VA = 400f * ampere;
                    volt = VoltageValue.THREEPHASE_VOLTAGE;

                    voltAmpere = VA.ToString();
                    description = "ACU";

                    cancel = false;
                    this.Close();
                }
            }
            
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SINGLE_Click_1(object sender, EventArgs e)
        {
            if(SINGLE.Checked == false)
            {
                motor = Three_Phase_AC_Motor.None;

                INDUCTION.Enabled = false;
                SYNCHRONOUS.Enabled = false;

                SINGLE.Checked = false;
                TWO.Checked = false;
                THREE.Checked = false;

                horsePower.Enabled = false;
                horsePower.Clear();
                return;
            }

            horsePower.Enabled = true;

            horsePower.Clear();

            SYNCHRONOUS.Checked = false;
            INDUCTION.Checked = false;

            INDUCTION.Enabled = false;
            SYNCHRONOUS.Enabled = false;

            TWO.Checked = false;
            THREE.Checked = false;

            horsePower.AddItem("1/6");
            horsePower.AddItem("0.25");
            horsePower.AddItem("1/3");
            horsePower.AddItem("0.5");
            horsePower.AddItem("0.75");
            horsePower.AddItem("1");
            horsePower.AddItem("1.5");
            horsePower.AddItem("2");
            horsePower.AddItem("3");
            horsePower.AddItem("5");
            horsePower.AddItem("7.5");
            horsePower.AddItem("10");
        }

        private void TWO_Click_1(object sender, EventArgs e)
        {
            if (TWO.Checked == false)
            {
                motor = Three_Phase_AC_Motor.None;

                INDUCTION.Enabled = false;
                SYNCHRONOUS.Enabled = false;

                SINGLE.Checked = false;
                TWO.Checked = false;
                THREE.Checked = false;

                horsePower.Enabled = false;
                horsePower.Clear();
                return;
            }

            horsePower.Enabled = true;

            horsePower.Clear();

            SYNCHRONOUS.Checked = false;
            INDUCTION.Checked = false;

            INDUCTION.Enabled = false;
            SYNCHRONOUS.Enabled = false;

            SINGLE.Checked = false;
            THREE.Checked = false;

            horsePower.AddItem("0.5");
            horsePower.AddItem("0.75");
            horsePower.AddItem("1");
            horsePower.AddItem("1.5");
            horsePower.AddItem("2");
            horsePower.AddItem("3");
            horsePower.AddItem("5");
            horsePower.AddItem("7.5");
            horsePower.AddItem("10");
            horsePower.AddItem("15");
            horsePower.AddItem("20");
            horsePower.AddItem("25");
            horsePower.AddItem("30");
            horsePower.AddItem("40");
            horsePower.AddItem("50");
            horsePower.AddItem("60");
            horsePower.AddItem("75");
            horsePower.AddItem("100");
            horsePower.AddItem("125");
            horsePower.AddItem("150");
            horsePower.AddItem("200");
        }

        private void THREE_Click_1(object sender, EventArgs e)
        {
            if (THREE.Checked == false)
            {
                motor = Three_Phase_AC_Motor.None;

                INDUCTION.Enabled = false;
                SYNCHRONOUS.Enabled = false;

                SINGLE.Checked = false;
                TWO.Checked = false;
                THREE.Checked = false;

                INDUCTION.Checked = false;
                SYNCHRONOUS.Checked = false;

                horsePower.Enabled = false;
                horsePower.Clear();
                return;
            }

            horsePower.Clear();

            SINGLE.Checked = false;
            TWO.Checked = false;

            INDUCTION.Enabled = true;
            SYNCHRONOUS.Enabled = true;

            horsePower.Enabled = false;
        }

        private void SYNCHRONOUS_Click_1(object sender, EventArgs e)
        {
            horsePower.Enabled = true;
            horsePower.Clear();

            motor = Three_Phase_AC_Motor.SYNCHRONOUS;
            INDUCTION.Checked = false;

            horsePower.AddItem("25");
            horsePower.AddItem("30");
            horsePower.AddItem("40");
            horsePower.AddItem("50");
            horsePower.AddItem("60");
            horsePower.AddItem("75");
            horsePower.AddItem("100");
            horsePower.AddItem("125");
            horsePower.AddItem("150");
            horsePower.AddItem("200");
        }

        private void INDUCTION_Click_1(object sender, EventArgs e)
        {
            horsePower.Enabled = true;
            horsePower.Clear();

            motor = Three_Phase_AC_Motor.INDUCTION;
            SYNCHRONOUS.Checked = false;

            horsePower.AddItem("0.5");
            horsePower.AddItem("0.75");
            horsePower.AddItem("1");
            horsePower.AddItem("1.5");
            horsePower.AddItem("2");
            horsePower.AddItem("3");
            horsePower.AddItem("5");
            horsePower.AddItem("7.5");
            horsePower.AddItem("10");
            horsePower.AddItem("15");
            horsePower.AddItem("20");
            horsePower.AddItem("25");
            horsePower.AddItem("30");
            horsePower.AddItem("40");
            horsePower.AddItem("50");
            horsePower.AddItem("60");
            horsePower.AddItem("75");
            horsePower.AddItem("100");
            horsePower.AddItem("125");
            horsePower.AddItem("150");
            horsePower.AddItem("200");
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            cancel = true;
            this.Close();
        }

        float singlePhaseAmp(string hp)
        {
            return (hp == "1/6") ? 2.2f :
                   (hp == "0.25") ? 2.9f :
                   (hp == "1/3") ? 3.6f :
                   (hp == "0.5") ? 4.9f :
                   (hp == "0.75") ? 6.9f :
                   (hp == "1") ? 8.0f :
                   (hp == "1.5") ? 10f :
                   (hp == "2") ? 12f :
                   (hp == "3") ? 17f :
                   (hp == "5") ? 28f :
                   (hp == "7.5") ? 40f :
                   (hp == "10") ? 50f : 0f;
        }

        float twoPhaseAmp(string hp)
        {
            return (hp == "0.5") ? 2f :
                   (hp == "0.75") ? 2.4f :
                   (hp == "1") ? 3.2f :
                   (hp == "1.5") ? 4.5f :
                   (hp == "2") ? 5.9f :
                   (hp == "3") ? 8.3f :
                   (hp == "5") ? 13.2f :
                   (hp == "7.5") ? 19f :
                   (hp == "10") ? 24f :
                   (hp == "15") ? 36f :
                   (hp == "20") ? 47f :
                   (hp == "25") ? 59f :
                   (hp == "30") ? 69f :
                   (hp == "40") ? 90f :
                   (hp == "50") ? 113f :
                   (hp == "60") ? 133f :
                   (hp == "75") ? 166f :
                   (hp == "100") ? 218f :
                   (hp == "125") ? 270f :
                   (hp == "150") ? 312f :
                   (hp == "200") ? 416f : 0f;
        }

        float threePhaseInductionAmp(string hp)
        {
            return (hp == "0.5") ? 2.2f :
                   (hp == "0.75") ? 3.4f :
                   (hp == "1") ? 4.2f :
                   (hp == "1.5") ? 6.0f :
                   (hp == "2") ? 6.8f :
                   (hp == "3") ? 9.6f :
                   (hp == "5") ? 15.2f :
                   (hp == "7.5") ? 22f :
                   (hp == "10") ? 28f :
                   (hp == "15") ? 42f :
                   (hp == "20") ? 54f :
                   (hp == "25") ? 68f :
                   (hp == "30") ? 80f :
                   (hp == "40") ? 104f :
                   (hp == "50") ? 130f :
                   (hp == "60") ? 154f :
                   (hp == "75") ? 192f :
                   (hp == "100") ? 248f :
                   (hp == "125") ? 312f :
                   (hp == "150") ? 360f :
                   (hp == "200") ? 480f : 0f;
        }

        float threePhaseSynchronousAmp(string hp)
        {
            return (hp == "25") ? 53f :
                   (hp == "30") ? 63f :
                   (hp == "40") ? 83f :
                   (hp == "50") ? 104f :
                   (hp == "60") ? 123f :
                   (hp == "75") ? 155f :
                   (hp == "100") ? 202f :
                   (hp == "125") ? 253f :
                   (hp == "150") ? 302f :
                   (hp == "200") ? 400f : 0f;
        }
    }
}
