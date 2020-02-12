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
    public partial class Occupancy : Form
    {
        public bool close;
        public OccupancyType oType;

        public Occupancy()
        {
            InitializeComponent();
        }

        private void ok_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false && radioButton4.Checked == false)
                    throw new Exception(label3.Text);

                if (radioButton1.Checked)
                    oType = OccupancyType.Hospitals;
                else if (radioButton2.Checked)
                    oType = OccupancyType.Hotels_Motels;
                else if (radioButton3.Checked)
                    oType = OccupancyType.Warehouses;
                else if (radioButton4.Checked)
                    oType = OccupancyType.Others;

                close = false;
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}
