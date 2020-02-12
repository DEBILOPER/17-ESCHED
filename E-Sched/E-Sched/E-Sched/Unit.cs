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
    public partial class Unit : Form
    {
        public bool cancelled;
        public bool closed;

        private DialogResult result;

        public Unit()
        {
            InitializeComponent();
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
                cancelled = true;
                this.Close();
            }
        }

        private void Unit_Load(object sender, EventArgs e)
        {
            closed = false;
            cancelled = false;
        }

        private void ok_Btn_Click(object sender, EventArgs e)
        {
            Data.unitType = (dwelling.Checked) ? UnitType.DwellingUnit : (nonDwelling.Checked) ? UnitType.NonDwellingUnit : UnitType.None;

            if(Data.unitType == UnitType.None)
            {
                MessageBox.Show("Please select a unit type!", "ERROR 404: Type Not found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                cancelled = false;
                this.Close();
            }
        }
    }
}
