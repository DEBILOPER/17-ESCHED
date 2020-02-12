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
    public partial class MotorLoad : Form
    {
        public bool cancel;
        public UnitType unit;
        public string voltAmpere;
        public string description;
        public PhaseType phase;
        public VoltageValue volt;
        public float ampere;

        private Three_Phase_AC_Motor motor;

        private DialogResult result;

        public MotorLoad()
        {
            InitializeComponent();
        }

        private void MotorLoad_Load(object sender, EventArgs e)
        {
            voltAmpere = description = string.Empty;
            
            cancel = false;
            unit = UnitType.None;
            motor = Three_Phase_AC_Motor.None;

            horse_power.Checked = false;
            volt_amp.Checked = false;

            SINGLE.Checked = false;
            TWO.Checked = false;
            THREE.Checked = false;

            SINGLE.Enabled = false;
            TWO.Enabled = false;
            THREE.Enabled = false;

            induction.Checked = false;
            synchronous.Checked = false;

            induction.Enabled = false;
            synchronous.Enabled = false;

            horsePower.Enabled = false;
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

        private void ok_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!horse_power.Checked && !volt_amp.Checked)
                    throw new Exception("PLEASE SELECT TYPE OF INPUT!");

                if (horse_power.Checked)
                {
                    if(horsePower.selectedValue != string.Empty)
                    {
                        if (!SINGLE.Checked && !TWO.Checked && !THREE.Checked)
                            throw new Exception("PLEASE SELECT TYPE OF AC MOTOR");

                        if(SINGLE.Checked)
                        {
                            if (horsePower.selectedValue == string.Empty)
                                throw new Exception("PLEASE SELECT HORSEPOWER");

                            if (description_Txt.Text == string.Empty)
                                throw new Exception("PLEASE ENTER DESCRIPTION");

                            ampere = singlePhaseAmp(horsePower.selectedValue);
                            float VA = 230f * ampere;
                            volt = VoltageValue.SINGLEPHASE_VOLTAGE;

                            voltAmpere = VA.ToString();
                            description = description_Txt.Text;

                            cancel = false;
                            this.Close();
                        }
                        else if(TWO.Checked)
                        {
                            if (horsePower.selectedValue == string.Empty)
                                throw new Exception("PLEASE SELECT HORSEPOWER");

                            if (description_Txt.Text == string.Empty)
                                throw new Exception("PLEASE ENTER DESCRIPTION");

                            ampere = twoPhaseAmp(horsePower.selectedValue);
                            float VA = 230f * ampere;
                            volt = VoltageValue.SINGLEPHASE_VOLTAGE;

                            voltAmpere = VA.ToString();
                            description = description_Txt.Text;

                            cancel = false;
                            this.Close();
                        }
                        else if(THREE.Checked)
                        {
                            if (!induction.Checked && !synchronous.Checked)
                                throw new Exception("PLEASE SELECT TYPE OF AC MOTOR");

                            if(induction.Checked)
                            {
                                if (horsePower.selectedValue == string.Empty)
                                    throw new Exception("PLEASE SELECT HORSEPOWER");

                                if (description_Txt.Text == string.Empty)
                                    throw new Exception("PLEASE ENTER DESCRIPTION");

                                ampere = threePhaseInductionAmp(horsePower.selectedValue);
                                float VA = 400f * ampere;
                                volt = VoltageValue.THREEPHASE_VOLTAGE;

                                voltAmpere = VA.ToString();
                                description = description_Txt.Text;

                                cancel = false;
                                this.Close();
                            }
                            else if(synchronous.Checked)
                            {
                                if (horsePower.selectedValue == string.Empty)
                                    throw new Exception("PLEASE SELECT HORSEPOWER");

                                if (description_Txt.Text == string.Empty)
                                    throw new Exception("PLEASE ENTER DESCRIPTION");

                                ampere = threePhaseInductionAmp(horsePower.selectedValue);
                                float VA = 400f * ampere;
                                volt = VoltageValue.THREEPHASE_VOLTAGE;

                                voltAmpere = VA.ToString();
                                description = description_Txt.Text;

                                cancel = false;
                                this.Close();
                            }
                        }
                        
                        this.Close();
                    }
                    else
                    {
                        throw new Exception("PLEASE CHOOSE A HORSEPOWER");
                    }
                }
                else if (volt_amp.Checked)
                {
                    if (voltAmp.Text != string.Empty || description_Txt.Text != string.Empty)
                    {
                        double.Parse(voltAmp.Text);

                        voltAmpere = voltAmp.Text;
                        description = description_Txt.Text;

                        this.Close();
                    }
                    else
                    {
                        throw new Exception("PLEASE PROVIDE AN INPUT FOR VOLT-AMPERE AND DESCRIPTION!");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR INPUT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            result = MessageBox.Show("DO YOU WANT TO EXIT?", "EXIT?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                cancel = true;
                this.Close();
            }
        }

        private void horse_power_Click(object sender, EventArgs e)
        {
            horsePower.Clear();
            if (horse_power.Checked == false)
            {
                voltAmpere = description = string.Empty;

                cancel = false;
                motor = Three_Phase_AC_Motor.None;

                horse_power.Checked = false;
                volt_amp.Checked = false;

                SINGLE.Checked = false;
                TWO.Checked = false;
                THREE.Checked = false;

                SINGLE.Enabled = false;
                TWO.Enabled = false;
                THREE.Enabled = false;

                induction.Checked = false;
                synchronous.Checked = false;

                induction.Enabled = false;
                synchronous.Enabled = false;

                horsePower.Enabled = false;

                return;
            }

            volt_amp.Checked = false;
            voltAmp.Enabled = false;
            voltAmp.Text = string.Empty;

            if (unit == UnitType.DwellingUnit)
            {
                horsePower.Enabled = true;

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
            else
            {
                horsePower.Enabled = true;

                SINGLE.Enabled = true;
                TWO.Enabled = true;

                if(phase == PhaseType.ThreePhase)
                    THREE.Enabled = true;
            }
        }

        private void volt_amp_Click(object sender, EventArgs e)
        {
            horsePower.Clear();
            if (volt_amp.Checked == false)
            {
                voltAmpere = description = string.Empty;

                cancel = false;
                motor = Three_Phase_AC_Motor.None;

                horse_power.Checked = false;
                volt_amp.Checked = false;

                SINGLE.Checked = false;
                TWO.Checked = false;
                THREE.Checked = false;

                SINGLE.Enabled = false;
                TWO.Enabled = false;
                THREE.Enabled = false;

                induction.Checked = false;
                synchronous.Checked = false;

                induction.Enabled = false;
                synchronous.Enabled = false;

                horsePower.Enabled = false;

                return;
            }

            SINGLE.Checked = false;
            TWO.Checked = false;
            THREE.Checked = false;

            SINGLE.Enabled = false;
            TWO.Enabled = false;
            THREE.Enabled = false;

            induction.Checked = false;
            synchronous.Checked = false;

            induction.Enabled = false;
            synchronous.Enabled = false;

            horse_power.Checked = false;
            horsePower.Enabled = false;

            voltAmp.Enabled = true;
        }

        private void SINGLE_Click(object sender, EventArgs e)
        {
            horsePower.Clear();
            if (SINGLE.Checked == false)
            {
                return;
            }

            horsePower.Enabled = true;

            synchronous.Checked = false;
            induction.Checked = false;

            induction.Enabled = false;
            synchronous.Enabled = false;

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

        private void TWO_Click(object sender, EventArgs e)
        {
            horsePower.Clear();
            if (TWO.Checked == false)
            {
                return;
            }

            horsePower.Enabled = true;

            synchronous.Checked = false;
            induction.Checked = false;

            induction.Enabled = false;
            synchronous.Enabled = false;

            SINGLE.Checked = false;
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

        private void THREE_Click(object sender, EventArgs e)
        {
            horsePower.Clear();
            
            if (THREE.Checked == false)
            {
                voltAmpere = description = string.Empty;

                cancel = false;
                unit = UnitType.None;
                motor = Three_Phase_AC_Motor.None;

                horse_power.Checked = false;
                volt_amp.Checked = false;

                SINGLE.Checked = false;
                TWO.Checked = false;
                THREE.Checked = false;

                SINGLE.Enabled = false;
                TWO.Enabled = false;
                THREE.Enabled = false;

                induction.Checked = false;
                synchronous.Checked = false;

                induction.Enabled = false;
                synchronous.Enabled = false;

                horsePower.Enabled = false;

                return;
            }

            induction.Enabled = true;
            synchronous.Enabled = true;

            SINGLE.Checked = false;
            TWO.Checked = false;

            horsePower.Enabled = false;
        }

        private void induction_Click(object sender, EventArgs e)
        {
            horsePower.Enabled = true;
            horsePower.Clear();

            motor = Three_Phase_AC_Motor.INDUCTION;
            synchronous.Checked = false;

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

        private void synchronous_Click(object sender, EventArgs e)
        {
            horsePower.Enabled = true;
            horsePower.Clear();

            motor = Three_Phase_AC_Motor.SYNCHRONOUS;
            induction.Checked = false;

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
            return (hp == "0.5")  ? 2.2f    :
                   (hp == "0.75") ? 3.4f  :
                   (hp == "1")    ? 4.2f  :
                   (hp == "1.5")  ? 6.0f  :
                   (hp == "2")    ? 6.8f  :
                   (hp == "3")    ? 9.6f  :
                   (hp == "5")    ? 15.2f :
                   (hp == "7.5")  ? 22f   :
                   (hp == "10")   ? 28f   :
                   (hp == "15")   ? 42f   :
                   (hp == "20")   ? 54f   :
                   (hp == "25")   ? 68f   :
                   (hp == "30")   ? 80f   :
                   (hp == "40")   ? 104f  :
                   (hp == "50")   ? 130f  :
                   (hp == "60")   ? 154f  :
                   (hp == "75")   ? 192f  :
                   (hp == "100")  ? 248f  :
                   (hp == "125")  ? 312f  :
                   (hp == "150")  ? 360f  :
                   (hp == "200")  ? 480f  : 0f;
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
