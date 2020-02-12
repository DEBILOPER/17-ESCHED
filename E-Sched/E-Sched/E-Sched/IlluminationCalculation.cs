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
    public partial class IlluminationCalculation : Form
    {
        private DialogResult result;

        public IlluminationCalculation()
        {
            InitializeComponent();
        }

        private void exit_Btn_Click(object sender, EventArgs e)
        {
            result = MessageBox.Show("DO YOU WANT TO EXIT?", "EXIT?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (!checkBox1.Checked && !checkBox2.Checked)
            {
                number_of_Lamps1.Visible = false;
                spacing_of_Light_Fixtures1.Visible = false;

                number_of_Lamps1.Enabled = false;
                spacing_of_Light_Fixtures1.Enabled = false;

                return;
            }

            checkBox2.Checked = false;

            spacing_of_Light_Fixtures1.Visible = false;
            number_of_Lamps1.Visible = true;

            spacing_of_Light_Fixtures1.Enabled = false;
            number_of_Lamps1.Enabled = true;

            number_of_Lamps1.BringToFront();
        }

        private void IlluminationCalculation_Load(object sender, EventArgs e)
        {
            number_of_Lamps1.Visible = false;
            spacing_of_Light_Fixtures1.Visible = false;

            number_of_Lamps1.Enabled = false;
            spacing_of_Light_Fixtures1.Enabled = false;
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            if(!checkBox1.Checked && !checkBox2.Checked)
            {
                number_of_Lamps1.Visible = false;
                spacing_of_Light_Fixtures1.Visible = false;

                number_of_Lamps1.Enabled = false;
                spacing_of_Light_Fixtures1.Enabled = false;

                return;
            }

            checkBox1.Checked = false;

            number_of_Lamps1.Visible = false;
            spacing_of_Light_Fixtures1.Visible = true;

            spacing_of_Light_Fixtures1.Enabled = true;
            number_of_Lamps1.Enabled = false;

            spacing_of_Light_Fixtures1.BringToFront();
        }

        private void spacing_of_Light_Fixtures1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
