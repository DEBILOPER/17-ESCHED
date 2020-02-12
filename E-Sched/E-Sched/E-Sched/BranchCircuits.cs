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
    public partial class BranchCircuits : Form
    {
        public bool close = false;
        public bool lighting = false;
        public bool outlet = false;
        public bool dryer = false;
        public bool range = false;
        public bool aircondition = false;
        public bool motor = false;
        public bool Spare = false;
        public bool load = false;
        
        public BranchCircuits()
        {
            InitializeComponent();
        }

        private void exit_Btn_Click(object sender, EventArgs e)
        {
            close = true;
            this.Close();
        }

        private void BranchCircuits_Load(object sender, EventArgs e)
        {
             close = false;
             lighting = false;
             outlet = false;
             dryer = false;
             range = false;
             aircondition = false;
             motor = false;
             Spare = false;
             load = false;
        }

        private void Lightings_Btn_Click(object sender, EventArgs e)
        {
            lighting = true;
            
            this.Close();
        }

        private void Outlet_Btn_Click(object sender, EventArgs e)
        {
            outlet = true;

            this.Close();
        }

        private void Dryer_Btn_Click(object sender, EventArgs e)
        {
            dryer = true;

            this.Close();
        }

        private void Range_Btn_Click(object sender, EventArgs e)
        {
            range = true;

            this.Close();
        }

        private void bunifuImageButton10_Click(object sender, EventArgs e)
        {
            aircondition = true;

            this.Close();
        }

        private void motorLoad_Click(object sender, EventArgs e)
        {
            motor = true;

            this.Close();
        }

        private void otherLoad_Click(object sender, EventArgs e)
        {
            load = true;

            this.Close();
        }

        private void spareBtn_Click(object sender, EventArgs e)
        {
            Spare = true;

            this.Close();
        }
    }
}
