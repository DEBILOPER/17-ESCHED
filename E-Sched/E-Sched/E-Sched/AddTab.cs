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
    public partial class AddTab : Form
    {
        public bool canceled = false;
        public string tabName = string.Empty;

        public bool closed = false;

        private DialogResult result;

        public AddTab()
        {
            InitializeComponent();
        }

        private void exit_Btn_Click(object sender, EventArgs e)
        {
            result = MessageBox.Show("DO YOU WANT TO EXIT?", "EXIT?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                closed = true;
                this.Close();
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            result = MessageBox.Show("DO YOU WANT TO EXIT?", "EXIT?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                closed = true;
                this.Close();
            }
        }

        private void ok_Btn_Click(object sender, EventArgs e)
        {
            if (newTab.Text != string.Empty)
            {
                closed = false;
                tabName = newTab.Text;
                newTab.Text = string.Empty;

                this.Close();
            }
        }
    }
}
