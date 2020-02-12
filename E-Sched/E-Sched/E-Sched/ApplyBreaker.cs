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
    public partial class ApplyBreaker : Form
    {
        public bool close;
        public double percentage;
        public BreakerType breaker;

        public ApplyBreaker()
        {
            InitializeComponent();
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

        private void ApplyBreaker_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            percentage = 1.5d;

            breaker = BreakerType.SYNCHRONOUS;

            checkBox2.Checked = false;
            checkBox1.Checked = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            percentage = 0.5d;

            breaker = BreakerType.WOUND;

            checkBox3.Checked = false;
            checkBox1.Checked = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            percentage = 7d;

            breaker = BreakerType.INSTANTANEOUS_TRIP;

            checkBox2.Checked = false;
            checkBox3.Checked = false;
        }

        private void ok_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false)
                    throw new Exception(bunifuLabel1.Text);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
