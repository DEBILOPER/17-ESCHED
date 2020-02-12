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
    public partial class NonDwellingMDP : Form
    {
        public bool close;

        public NonDwellingMDP()
        {
            InitializeComponent();
        }

        private void exit_Btn_Click(object sender, EventArgs e)
        {
            close = true;
            this.Close();
        }

        private void ok_Btn_Click(object sender, EventArgs e)
        {

        }
    }
}
