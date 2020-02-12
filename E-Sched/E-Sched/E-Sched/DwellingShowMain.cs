using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Sched
{
    public partial class DwellingShowMain : UserControl
    {
        public DwellingShowMain()
        {
            InitializeComponent();
        }

        private void DwellingShowMain_Load(object sender, EventArgs e)
        {

        }

        public void Initialize(double total_connectedLoad, double LO_CO, double rangeTotal, double dryerTotal, double acuTotal, double motorTotal, double otherTotal, double spareTotal, double total_netLoad, double mainService, double ampacity, string hotWire, string grounding, int AT, BreakerType breakerType, PhaseType phaseType, int voltageValue)
        {
            label1.Text = "TOTAL CONNECTED LOAD = " + total_connectedLoad.ToString();
            label2.Text = "LIGHTING AND CONVENIENCE OUTLET = " + LO_CO.ToString();
            label3.Text = "RANGE = " + rangeTotal.ToString();
            label4.Text = "DRYER = " + dryerTotal.ToString();
            label5.Text = "ACU = " + acuTotal.ToString();
            label6.Text = "MOTOR = " + motorTotal.ToString();
            label7.Text = "OTHER LOAD = " + otherTotal.ToString();
            label8.Text = "SPARE = " + spareTotal.ToString();
            label9.Text = "TOTAL NET LOAD = " + total_netLoad.ToString();

            label11.Text = "MAIN SERVICE = " + mainService.ToString();
            label12.Text = "CONDUCTOR AMPACITY = " + ampacity.ToString();
            label13.Text = "USE " + hotWire + " and " + grounding;

            string phase = string.Empty;

            if (phaseType == PhaseType.SinglePhase)
                phase = "SINGLE PHASE";
            else if (phaseType == PhaseType.ThreePhase)
                phase = "THREE PHASE";

            string temp = string.Empty;

            if (breakerType == BreakerType.INSTANTANEOUS_TRIP)
                temp = "INSTANTANEOUS TRIP CIRCUIT BREAKER";
            else
                temp = "INVERSE TIME CIRCUIT BREAKER";

            label14.Text = "PROVIDE " + AT.ToString() + " AT, " + temp + ", " + phase + ", " + voltageValue.ToString() + "V, " + "60 Hz";
        }

        public void Initialize()
        {
            label1.Text = "TOTAL CONNECTED LOAD = 0";
            label2.Text = "LIGHTING AND CONVENIENCE OUTLET = 0";
            label3.Text = "RANGE = 0";
            label4.Text = "DRYER = 0";
            label5.Text = "ACU = 0";
            label6.Text = "MOTOR = 0";
            label7.Text = "OTHER LOAD = 0";
            label8.Text = "SPARE = 0";
            label9.Text = "TOTAL NET LOAD = 0";

            label11.Text = "MAIN SERVICE = 0";
            label12.Text = "CONDUCTOR AMPACITY = 0";
            label13.Text = "USE ";
            label14.Text = "PROVIDE ";
        }
    }
}
