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
    public partial class ConvenienceOutlet : Form
    {
        public bool close = false;
        public string description = string.Empty;
        public string convenienceOutlet = string.Empty;
        public string voltAmpere = string.Empty;

        public ConvenienceOutlet()
        {
            InitializeComponent();
        }

        private void exit_Btn_Click(object sender, EventArgs e)
        {
            close = false;
            this.Close();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if(oneGang.Text == string.Empty && twoGang.Text == string.Empty && threeGang.Text == string.Empty)
            {
                MessageBox.Show("PLEASE SPECIFY AN INPUT!", "ERROR INPUT!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int one = (oneGang.Text == string.Empty) ? 0 : Convert.ToInt32(oneGang.Text);
                int two = (twoGang.Text == string.Empty) ? 0 : Convert.ToInt32(twoGang.Text);
                int three = (threeGang.Text == string.Empty) ? 0 : Convert.ToInt32(threeGang.Text);

                string temp = string.Empty;

                convenienceOutlet = (one + two + three).ToString();

                description = (one == 0) ? string.Empty : one.ToString() + "-ONE GANG CONVENIENCE OUTLET";
                
                temp = (two == 0) ? string.Empty : two.ToString() + "-TWO GANG CONVENIENCE OUTLET";

                if (description != string.Empty && temp != string.Empty)
                {
                    description = description + "," + temp;
                }

                temp = (three == 0) ? string.Empty : three.ToString() + "-THREE GANG CONVENIENCE OUTLET";

                if (description != string.Empty && temp != string.Empty)
                {
                    description = description + "," + temp;
                }

                int summation = (180 * one) + (360 * two) + (540 * three);
                voltAmpere = summation.ToString();

                close = false;
                this.Close();
            }
        }

        private void ConvenienceOutlet_Load(object sender, EventArgs e)
        {
            close = false;

            oneGang.Text = string.Empty;
            twoGang.Text = string.Empty;
            threeGang.Text = string.Empty;
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            close = false;
            this.Close();
        }
    }
}
