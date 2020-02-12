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
    public partial class AirCondition : Form
    {
        public string voltAmpere;
        public string description;
        public bool cancel;
        public PhaseType phase;
        public float ampere;

        private DialogResult result;
        
        public AirCondition()
        {
            InitializeComponent();
        }

        private void AirCondition_Load(object sender, EventArgs e)
        {
            horsePower.Clear();

            voltAmpere = string.Empty;
            description = string.Empty;
            cancel = false;
            phase = PhaseType.None;

            horsePower.AddItem("1/6");
            horsePower.AddItem("0.25");
            horsePower.AddItem("1/3");
            horsePower.AddItem("0.5");
            horsePower.AddItem("0.75");
            horsePower.AddItem("1");
            horsePower.AddItem("1.5");
            horsePower.AddItem("2");
            horsePower.AddItem("3");
            horsePower.AddItem("5");
            horsePower.AddItem("7.5");
            horsePower.AddItem("10");
        }

        private void exit_Btn_Click(object sender, EventArgs e)
        {
            result = MessageBox.Show("DO YOU WANT TO EXIT?", "EXIT?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                cancel = true;
                this.Close();
            }

            horsePower.Clear();
        }

        private void ok_Btn_Click(object sender, EventArgs e)
        {
            if (horsePower.selectedValue == string.Empty)
                throw new Exception("PLEASE SELECT HORSEPOWER");

            ampere = singlePhaseAmp(horsePower.selectedValue);
            float VA = 230f * ampere;

            voltAmpere = VA.ToString();
            description = "ACU";

            cancel = false;
            this.Close();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            cancel = true;
            this.Close();
        }

        float singlePhaseAmp(string hp)
        {
            return (hp == "1/6") ? 2.2f :
                   (hp == "0.25") ? 2.9f :
                   (hp == "1/3") ? 3.6f :
                   (hp == "0.5") ? 4.9f :
                   (hp == "0.75") ? 6.9f :
                   (hp == "1") ? 8.0f :
                   (hp == "1.5") ? 10f :
                   (hp == "2") ? 12f :
                   (hp == "3") ? 17f :
                   (hp == "5") ? 28f :
                   (hp == "7.5") ? 40f :
                   (hp == "10") ? 50f : 0f;
        }
    }
}
