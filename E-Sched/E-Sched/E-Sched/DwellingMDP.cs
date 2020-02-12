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
    public partial class DwellingMDP : Form
    {
        public double demandFactor = 0d;
        public bool cancel = false;

        public DwellingMDP()
        {
            InitializeComponent();
        }

        private void ok_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (units.Text == string.Empty)
                    throw new Exception(label1.Text);

                double u = double.Parse(units.Text);

                if (u < 3)
                    throw new Exception("UNIT MUST BE GREATER THAN OR EQUAL TO 3");

                demandFactor = multiFamilyDemandFactor(u);

                cancel = false;

                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private double multiFamilyDemandFactor(double u)
        {
            return (u >= 3 && u <= 5) ? 0.45 :
                   (u >= 6 && u <= 7) ? 0.44 :
                   (u >= 8 && u <= 10) ? 0.43 :
                   (u == 11) ? 0.42 :
                   (u >= 12 && u <= 13) ? 0.41 :
                   (u >= 14 && u <= 15) ? 0.4 :
                   (u >= 16 && u <= 17) ? 0.39 :
                   (u >= 18 && u <= 20) ? 0.38 :
                   (u == 21) ? 0.37 :
                   (u >= 22 && u <= 23) ? 0.36 :
                   (u >= 24 && u <= 25) ? 0.35 :
                   (u >= 26 && u <= 27) ? 0.34 :
                   (u >= 28 && u <= 30) ? 0.33 :
                   (u == 31) ? 0.32 :
                   (u >= 32 && u <= 33) ? 0.31 :
                   (u >= 34 && u <= 36) ? 0.3 :
                   (u >= 37 && u <= 38) ? 0.29 :
                   (u >= 39 && u <= 42) ? 0.28 :
                   (u >= 43 && u <= 45) ? 0.27 :
                   (u >= 46 && u <= 50) ? 26 :
                   (u >= 51 && u <= 55) ? 25 :
                   (u >= 56 && u <= 61) ? 24 :
                   (u >= 62) ? 23 : 0d;
        }

        private void exit_Btn_Click(object sender, EventArgs e)
        {
            cancel = true;
            this.Close();
        }
    }
}
