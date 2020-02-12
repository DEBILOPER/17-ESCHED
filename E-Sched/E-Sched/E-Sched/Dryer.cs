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
    public partial class Dryer : Form
    {
        private DialogResult result;

        public string VoltageAmp = string.Empty;
        public string description = string.Empty;

        public bool close = false;
        
        public Dryer()
        {
            InitializeComponent();
        }

        private void exit_Btn_Click(object sender, EventArgs e)
        {
            result = MessageBox.Show("DO YOU WANT TO EXIT?", "EXIT?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(result == DialogResult.Yes)
            {
                close = true;
                this.Close();
            }
        }

        private void ok_Btn_Click(object sender, EventArgs e)
        {
            if(voltageAmp.Text == string.Empty)
            {
                MessageBox.Show("PLEASE SPECIFY AN INPUT!", "ERROR INPUT", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                int va = Convert.ToInt32(voltageAmp.Text);

                if(va < 5000)
                {
                    MessageBox.Show("VOLTAGE AMPRERE MUST BE GREATER OR EQUAL TO 5000!", "ERROR INPUT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    VoltageAmp = voltageAmp.Text;
                    description = "DRYER";

                    close = false;
                    this.Close();
                }
            }
        }

        private void Dryer_Load(object sender, EventArgs e)
        {
            close = false;
            voltageAmp.Text = string.Empty;
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            result = MessageBox.Show("DO YOU WANT TO EXIT?", "EXIT?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                close = true;
                this.Close();
            }
        }
    }
}
