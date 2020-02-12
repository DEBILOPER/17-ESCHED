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
    public partial class Spare : Form
    {
        public bool close = false;
        private DialogResult result;

        public string VoltageAmpere = string.Empty;

        public Spare()
        {
            InitializeComponent();
        }

        private void exit_Btn_Click(object sender, EventArgs e)
        {
            result = MessageBox.Show("DO YOU WANT TO EXIT?", "EXIT?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                close = true;
                this.Close();
            }
        }

        private void ok_Btn_Click(object sender, EventArgs e)
        {
            // please specify input
            int rESULT = (voltageAmp.Text == string.Empty || voltageAmp.Text == "0") ? 0 : int.Parse(voltageAmp.Text);

            if(rESULT != 0)
            {
                VoltageAmpere = rESULT.ToString();
            }

            voltageAmp.Text = string.Empty;
            close = false;
            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            close = true;
            this.Close();
        }

        private void Spare_Load(object sender, EventArgs e)
        {
            close = false;
        }
    }
}
