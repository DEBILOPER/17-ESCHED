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
    public partial class Voltage : Form
    {
        private DialogResult result;

        public bool cancelled;
        public bool closed;

        public Voltage()
        {
            InitializeComponent();
        }

        private void Voltage_Load(object sender, EventArgs e)
        {
            cancelled = false;
            closed = false;
        }

        private void exit_Btn_Click(object sender, EventArgs e)
        {
            result = MessageBox.Show("Are you sure you want to cancel creating a new file?", "CANCEL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                closed = true;
                this.Close();
            }
        }

        private void cancel_Btn_Click(object sender, EventArgs e)
        {
            result = MessageBox.Show("Are you sure you want to cancel creating a new file?", "CANCEL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                closed = true;
                this.Close();
            }
        }

        private void ok_Btn_Click(object sender, EventArgs e)
        {
            cancelled = false;
            this.Close();
        }
    }
}
