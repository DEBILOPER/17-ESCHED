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
    public partial class ApplyBranch : Form
    {
        public string _temparature;
        public string _conductor;

        public WireType wireType;
        public ConduitType conduitType;

        public string Ampacity;
        private DialogResult result;

        public bool closed;
        public bool cancel;

        public float correctionFactor;
        public string conductorSize;
        public float derating;
        
        public ApplyBranch()
        {
            InitializeComponent();
        }

        private void ApplyBranch_Load(object sender, EventArgs e)
        {
            _temparature = string.Empty;

            correctionFactor = 0f;
            derating = 0f;
            conductorSize = string.Empty;

            closed = false;
            cancel = false;

            Ampacity = string.Empty;

            tw.Checked = false;
            thw.Checked = false;
            thhn.Checked = false;

            pvc.Checked = false;
            emt.Checked = false;
            imc.Checked = false;
            rmc.Checked = false;

            temperature.Text = string.Empty;
            no_of_conductors.Text = string.Empty;
        }

        private void exit_Btn_Click(object sender, EventArgs e)
        {
            result = MessageBox.Show("DO YOU WANT TO EXIT?", "EXIT?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                closed = true;
                this.Close();
            }
        }

        private void tw_Click(object sender, EventArgs e)
        {
            thw.Checked = false;
            thhn.Checked = false;
        }

        private void thw_Click(object sender, EventArgs e)
        {
            tw.Checked = false;
            thhn.Checked = false;
        }

        private void thhn_Click(object sender, EventArgs e)
        {
            tw.Checked = false;
            thw.Checked = false;
        }

        private void cancel_Btn_Click(object sender, EventArgs e)
        {
            result = MessageBox.Show("DO YOU WANT TO CANCEL ADDING BRANCH CIRCUIT?", "CANCEL?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                cancel = true;
                this.Close();
            }
        }

        private void pvc_Click(object sender, EventArgs e)
        {
            emt.Checked = false;
            imc.Checked = false;
            rmc.Checked = false;
        }

        private void emt_Click(object sender, EventArgs e)
        {
            pvc.Checked = false;
            imc.Checked = false;
            rmc.Checked = false;
        }

        private void imc_Click(object sender, EventArgs e)
        {
            pvc.Checked = false;
            emt.Checked = false;
            rmc.Checked = false;
        }

        private void rmc_Click(object sender, EventArgs e)
        {
            pvc.Checked = false;
            emt.Checked = false;
            imc.Checked = false;
        }

        private void ok_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!tw.Checked && !thw.Checked && !thhn.Checked)
                {
                    throw new Exception("PLEASE SELECT TYPE OF WIRE TO BE USED!");
                }
                else
                {
                    if (!pvc.Checked && !emt.Checked && !imc.Checked && !rmc.Checked)
                    {
                        throw new Exception("PLEASE SELECT TYPE OF CONDUIT TO BE USED!");
                    }
                    else
                    {
                        if (temperature.Text == string.Empty)
                        {
                            throw new Exception("PLEASE SPECIFY AN INPUT FOR TEMPERATURE!");
                        }
                        else
                        {
                            if(no_of_conductors.Text == string.Empty)
                            {
                                throw new Exception("PLEASE SPECIFY AN INPUT FOR NO. OF CURRENT-CARRYING CONDUTORS!");
                            }
                            else
                            {
                                int temp = int.Parse(temperature.Text);
                                int conductor = int.Parse(no_of_conductors.Text);
                                
                                if(conductor < 0)
                                {
                                    throw new Exception("INVALID NO. OF CONDUCTORS!");
                                }

                                if(conductor >= 1 && conductor <= 3)
                                {
                                    derating = 1;
                                }
                                else if(conductor >= 4 && conductor <= 6)
                                {
                                    derating = 0.8f;
                                }
                                else if(conductor >= 7 && conductor <= 9)
                                {
                                    derating = 0.7f;
                                }
                                else if(conductor >= 10 && conductor <= 20)
                                {
                                    derating = 0.5f;
                                }
                                else if(conductor >= 21 && conductor <= 30)
                                {
                                    derating = 0.45f;
                                }
                                else if(conductor >= 31 && conductor <= 40)
                                {
                                    derating = 0.4f;
                                }
                                else if(conductor >= 41)
                                {
                                    derating = 0.35f;
                                }

                                if(temp < 21 || temp > 80)
                                {
                                    throw new Exception("TEMPERATURE MUST BE > or = 21 and < or = 80");
                                }

                                _temparature = temp.ToString();
                                _conductor = conductor.ToString();

                                if(temp >= 21 && temp <= 25)
                                {
                                    if(tw.Checked)
                                    {
                                        correctionFactor = 1.08f;
                                    }
                                    else if(thw.Checked)
                                    {
                                        correctionFactor = 1.05f;
                                    }
                                    else if(thhn.Checked)
                                    {
                                        correctionFactor = 1.04f;
                                    }
                                }
                                else if (temp >= 26 && temp <= 30)
                                {
                                    if (tw.Checked)
                                    {
                                        correctionFactor = 1f;
                                    }
                                    else if (thw.Checked)
                                    {
                                        correctionFactor = 1f;
                                    }
                                    else if (thhn.Checked)
                                    {
                                        correctionFactor = 1f;
                                    }
                                }
                                else if (temp >= 31 && temp <= 35)
                                {
                                    if (tw.Checked)
                                    {
                                        correctionFactor = 0.91f;
                                    }
                                    else if (thw.Checked)
                                    {
                                        correctionFactor = 0.94f;
                                    }
                                    else if (thhn.Checked)
                                    {
                                        correctionFactor = 0.96f;
                                    }
                                }
                                else if (temp >= 36 && temp <= 40)
                                {
                                    if (tw.Checked)
                                    {
                                        correctionFactor = 0.82f;
                                    }
                                    else if (thw.Checked)
                                    {
                                        correctionFactor = 0.88f;
                                    }
                                    else if (thhn.Checked)
                                    {
                                        correctionFactor = 0.91f;
                                    }
                                }
                                else if (temp >= 41 && temp <= 45)
                                {
                                    if (tw.Checked)
                                    {
                                        correctionFactor = 0.71f;
                                    }
                                    else if (thw.Checked)
                                    {
                                        correctionFactor = 0.82f;
                                    }
                                    else if (thhn.Checked)
                                    {
                                        correctionFactor = 0.87f;
                                    }
                                }
                                else if (temp >= 46 && temp <= 50)
                                {
                                    if (tw.Checked)
                                    {
                                        correctionFactor = 0.58f;
                                    }
                                    else if (thw.Checked)
                                    {
                                        correctionFactor = 0.75f;
                                    }
                                    else if (thhn.Checked)
                                    {
                                        correctionFactor = 0.82f;
                                    }
                                }
                                else if (temp >= 51 && temp <= 55)
                                {
                                    if (tw.Checked)
                                    {
                                        correctionFactor = 0.41f;
                                    }
                                    else if (thw.Checked)
                                    {
                                        correctionFactor = 0.67f;
                                    }
                                    else if (thhn.Checked)
                                    {
                                        correctionFactor = 0.76f;
                                    }
                                }
                                else if (temp >= 56 && temp <= 60)
                                {
                                    if (tw.Checked)
                                    {
                                        correctionFactor = 0f;
                                    }
                                    else if (thw.Checked)
                                    {
                                        correctionFactor = 0.58f;
                                    }
                                    else if (thhn.Checked)
                                    {
                                        correctionFactor = 0.71f;
                                    }
                                }
                                else if (temp >= 61 && temp <= 70)
                                {
                                    if (tw.Checked)
                                    {
                                        correctionFactor = 0f;
                                    }
                                    else if (thw.Checked)
                                    {
                                        correctionFactor = 0.33f;
                                    }
                                    else if (thhn.Checked)
                                    {
                                        correctionFactor = 0.58f;
                                    }
                                }
                                else if (temp >= 71 && temp <= 80)
                                {
                                    if (tw.Checked)
                                    {
                                        correctionFactor = 0f;
                                    }
                                    else if (thw.Checked)
                                    {
                                        correctionFactor = 0f;
                                    }
                                    else if (thhn.Checked)
                                    {
                                        correctionFactor = 0.41f;
                                    }
                                }

                                if (tw.Checked)
                                {
                                    wireType = WireType.TW;
                                }
                                else if(thw.Checked)
                                {
                                    wireType = WireType.THW;
                                }
                                else if(thhn.Checked)
                                {
                                    wireType = WireType.THHN;
                                }

                                if(pvc.Checked)
                                {
                                    conduitType = ConduitType.PVC;
                                }
                                else if(emt.Checked)
                                {
                                    conduitType = ConduitType.EMT;
                                }
                                else if(rmc.Checked)
                                {
                                    conduitType = ConduitType.RMC;
                                }
                                else if(imc.Checked)
                                {
                                    conduitType = ConduitType.IMC;
                                }

                                this.Close();
                                
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR INPUT!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
