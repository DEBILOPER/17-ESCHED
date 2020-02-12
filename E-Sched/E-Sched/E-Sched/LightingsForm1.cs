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
    public partial class LightingsForm1 : Form
    {
        private DialogResult result;

        public bool close = false;

        public string voltageAmp  = string.Empty;
        public string Description = string.Empty;
        public string lightingOutlet = string.Empty;

        public LightingsForm1()
        {
            InitializeComponent();
        }

        private void LightingsForm1_Load(object sender, EventArgs e)
        {
            close = false;
            description.Text = string.Empty;
            lampCount.Text = string.Empty;
            lightingOutlet = string.Empty;
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

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if(lampCount.Text == string.Empty)
            {
                MessageBox.Show("INVALID INPUT IN NO. OF LAMPS!", "ERROR INPUT!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int lamp = int.Parse(lampCount.Text);

                if(lamp == 0)
                {
                    MessageBox.Show("NO. OF LAMPS MUST BE GREATER THAN ZERO!", "ERROR INPUT!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    close = false;
                    voltageAmp = (100 * lamp).ToString();
                    Description = lamp.ToString() + "-" + description.Text;
                    lightingOutlet = lampCount.Text;

                    this.Close();
                }
            }
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
