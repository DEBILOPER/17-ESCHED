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
    public partial class Area : Form
    {
        public bool cancel;
        public string _area;
        
        public Area()
        {
            InitializeComponent();
        }

        private void exit_Btn_Click(object sender, EventArgs e)
        {
            cancel = true;
            this.Close();
        }

        private void cancel_Btn_Click(object sender, EventArgs e)
        {
            cancel = true;
            this.Close();
        }

        private void ok_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (areatxt.Text == string.Empty)
                    throw new Exception("INPUT IS EMPTY!");

                double.Parse(areatxt.Text);

                cancel = false;
                _area = areatxt.Text;

                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR INPUT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
