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
    public partial class OtherLoad : Form
    {
        public bool close = false;
        public string Description = string.Empty;
        public string VoltAmp = string.Empty;

        public OtherLoad()
        {
            InitializeComponent();
        }

        private void ok_Btn_Click(object sender, EventArgs e)
        {
            if(voltageAmp.Text == string.Empty)
            {
                MessageBox.Show("INVALID INPUT!", "ERROR INPUT!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int result = Convert.ToInt32(voltageAmp.Text);

                if(result == 0)
                {
                    MessageBox.Show("INPUT MUST NOT EQUAL TO ZERO!", "ERROR INPUT!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if(description.Text == string.Empty)
                    {
                        MessageBox.Show("DESCRIPTION MUST HAVE AN INPUT!", "ERROR INPUT!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Description = description.Text;
                        
                        VoltAmp = voltageAmp.Text;

                        close = false;
                        this.Close();
                    }
                }
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            close = true;
            this.Close();
        }

        private void exit_Btn_Click(object sender, EventArgs e)
        {
            close = true;
            this.Close();
        }
    }
}
