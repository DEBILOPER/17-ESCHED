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
    public partial class Phase : Form
    {
        private DialogResult result;

        public bool cancelled;
        public bool closed;

        public PhaseType phaseType;

        public Phase()
        {
            InitializeComponent();
        }

        private void Phase_Load(object sender, EventArgs e)
        {
            closed = false;
            cancelled = false;

            singlePhase.Checked = false;
            threePhase.Checked = false;
        }

        private void singlePhase_CheckedChanged(object sender, EventArgs e)
        {
            threePhase.Checked = false;
        }

        private void threePhase_CheckedChanged(object sender, EventArgs e)
        {
            singlePhase.Checked = false;
        }

        private void ok_Btn_Click(object sender, EventArgs e)
        {
            phaseType = (singlePhase.Checked) ? PhaseType.SinglePhase : (threePhase.Checked) ? PhaseType.ThreePhase : PhaseType.None;

            if(phaseType == PhaseType.None)
            {
                MessageBox.Show("Please select a phase type", "Error 404: Phase not found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                cancelled = false;
                this.Close();
            }
        }

        private void cancel_Btn_Click(object sender, EventArgs e)
        {
            result = MessageBox.Show("Are you sure you want to cancel creating a new file?", "CANCEL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                cancelled = true;

                phaseType = PhaseType.None;
                this.Close();
            }
        }

        private void exit_Btn_Click(object sender, EventArgs e)
        {
            result = MessageBox.Show("Are you sure you want to cancel creating a new file?", "CANCEL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                cancelled = true;

                phaseType = PhaseType.None;
                this.Close();
            }
        }
    }
}
