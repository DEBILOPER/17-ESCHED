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
    public partial class ApplyMain : Form
    {
        public bool close;

        public string conductorWire;
        public WireType breakerWire;
        public ConduitType conduitType;

        public ApplyMain()
        {
            InitializeComponent();
        }

        private void ApplyMain_Load(object sender, EventArgs e)
        {
            close = false;

            conductorWire = string.Empty;

            tw.Checked = false;
            thw.Checked = false;
            thhn.Checked = false;

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;

            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
        }

        private void tw_CheckedChanged(object sender, EventArgs e)
        {
            conductorWire = "TW";

            thw.Checked = false;
            thhn.Checked = false;
        }

        private void thw_CheckedChanged(object sender, EventArgs e)
        {
            conductorWire = "THW";

            tw.Checked = false;
            thhn.Checked = false;
        }

        private void thhn_CheckedChanged(object sender, EventArgs e)
        {
            conductorWire = "THHN";

            tw.Checked = false;
            thw.Checked = false;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            breakerWire = WireType.TW;

            checkBox2.Checked = false;
            checkBox1.Checked = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            breakerWire = WireType.THW;

            checkBox3.Checked = false;
            checkBox1.Checked = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            breakerWire = WireType.THHN;

            checkBox2.Checked = false;
            checkBox3.Checked = false;
        }

        private void cancel_Btn_Click(object sender, EventArgs e)
        {
            close = true;
            this.Close();
        }

        private void exit_Btn_Click(object sender, EventArgs e)
        {
            close = true;
            this.Close();
        }

        private void ok_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (tw.Checked == false && thw.Checked == false && thhn.Checked == false)
                    throw new Exception(bunifuLabel4.Text);

                if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false)
                    throw new Exception(bunifuLabel1.Text);

                if (checkBox4.Checked == false && checkBox5.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false)
                    throw new Exception(bunifuLabel2.Text);

                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            conduitType = ConduitType.PVC;

            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            conduitType = ConduitType.RMC;

            checkBox4.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            conduitType = ConduitType.IMC;

            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox7.Checked = false;
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            conduitType = ConduitType.EMT;

            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
        }
    }
}
