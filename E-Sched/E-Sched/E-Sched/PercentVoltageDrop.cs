using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace E_Sched
{
    public partial class PercentVoltageDrop : Form
    {
        public string _resistance = string.Empty;
        public string _length = string.Empty;

        public string ConduitSize;
        public string wireSize;
        public int voltage;
        public ConduitType conduitType;
        public WireType wireType;
        public bool cancel;
        public float ampere;
        public bool close;

        private float AC_Resistance;

        private PhaseType ptype;

        public PercentVoltageDrop(PhaseType phaseType)
        {
            ptype = phaseType;
            InitializeComponent();
        }

        private void PercentVoltageDrop_Load(object sender, EventArgs e)
        {
            _resistance = string.Empty;
            _length = string.Empty;

            resistanceGrid.Rows.Clear();
            resistanceGrid.Columns.Clear();

            conduitSizeGrid.Rows.Clear();
            conduitSizeGrid.Columns.Clear();

            resistanceGrid.Visible = false;
            resistanceGrid.Enabled = false;

            close = false;
            cancel = false;

            resistance.Text = string.Empty;
            length.Text = string.Empty;

            wireLabel.Text = "WIRE TYPE: ";
            sizeLabel.Text = "HOTWIRE SIZE: ";
            racewaySize.Text = "RACEWAY SIZE (mm)";

            resistance.Enabled = false;

            cancel = false;

            wireLabel.Text = wireLabel.Text + wireType.ToString(); 
            sizeLabel.Text = sizeLabel.Text + " " + wireSize;
            racewaySize.Text = conduitType.ToString() + " " + racewaySize.Text;
            
            string wire = (wireSize.Contains("*")) ? (Regex.Replace(wireSize, "\\* sq. mm.", string.Empty)) : (Regex.Replace(wireSize, " sq. mm.", string.Empty));
            
            if (wireOverSixty(wire))
            {
                resistanceGrid.Visible = true;
                resistanceGrid.Enabled = true;

                resistanceGrid.Columns.Add("C1", "WIRE SIZE");

                if(conduitType == ConduitType.PVC)
                {
                    resistanceGrid.Columns.Add("C2", "PVC");

                    resistanceGrid.Rows.Add(80 , 0.077);
                    resistanceGrid.Rows.Add(100, 0.062);
                    resistanceGrid.Rows.Add(125, 0.052);
                    resistanceGrid.Rows.Add(150, 0.044);
                    resistanceGrid.Rows.Add(175, 0.038);
                    resistanceGrid.Rows.Add(200, 0.033);
                    resistanceGrid.Rows.Add(250, 0.027);
                    resistanceGrid.Rows.Add(325, 0.023);
                    resistanceGrid.Rows.Add(375, 0.019);
                    resistanceGrid.Rows.Add(400, 0.019);
                    resistanceGrid.Rows.Add(500, 0.015);
                }
                else if(conduitType == ConduitType.RMC || conduitType == ConduitType.EMT || conduitType == ConduitType.IMC)
                {
                    resistanceGrid.Columns.Add("C2", "ALUMINUM");
                    resistanceGrid.Columns.Add("C3", "STEEL");

                    resistanceGrid.Rows.Add(80,  0.082, 0.079);
                    resistanceGrid.Rows.Add(100, 0.067, 0.063);
                    resistanceGrid.Rows.Add(125, 0.057, 0.054);
                    resistanceGrid.Rows.Add(150, 0.049, 0.045);
                    resistanceGrid.Rows.Add(175, 0.043, 0.039);
                    resistanceGrid.Rows.Add(200, 0.038, 0.035);
                    resistanceGrid.Rows.Add(250, 0.032, 0.029);
                    resistanceGrid.Rows.Add(325, 0.028, 0.025);
                    resistanceGrid.Rows.Add(375, 0.024, 0.021);
                    resistanceGrid.Rows.Add(400, 0.024, 0.021);
                    resistanceGrid.Rows.Add(500, 0.019, 0.018);
                }
            }
            else
            {
                AC_Resistance = Resistance(wire);

                resistance.Text = AC_Resistance.ToString();
            }

            conduitSizeGrid.Columns.Add("C0", "CONDUCTOR SIZE");
            conduitSizeGrid.Columns.Add("C1", "15");
            conduitSizeGrid.Columns.Add("C2", "20");
            conduitSizeGrid.Columns.Add("C3", "25");
            conduitSizeGrid.Columns.Add("C4", "32");
            conduitSizeGrid.Columns.Add("C5", "40");
            conduitSizeGrid.Columns.Add("C6", "50");
            conduitSizeGrid.Columns.Add("C7", "65");
            conduitSizeGrid.Columns.Add("C8", "80");
            conduitSizeGrid.Columns.Add("C9", "90");
            conduitSizeGrid.Columns.Add("C10", "100");

            if (conduitType == ConduitType.RMC || conduitType == ConduitType.PVC)
            {
                conduitSizeGrid.Columns.Add("C10", "125");
                conduitSizeGrid.Columns.Add("C10", "150");
            }
            
            if(wireType == WireType.TW && conduitType == ConduitType.PVC)
            {
                conduitSizeGrid.Rows.Add("2.0(1.6)", 6, 11, 20, 35, 49, 82, 118, 185, 250, 324, 514, 736);  //
                conduitSizeGrid.Rows.Add("3.5(2.0)", 5, 9, 15, 27, 38, 63, 91, 142, 192, 248, 394, 565);    //
                conduitSizeGrid.Rows.Add("5.5(2.6)", 3, 6, 11, 20, 28, 47, 67, 106, 143, 185, 294, 421);    //
                conduitSizeGrid.Rows.Add("8.0(3.2)", 1, 3, 6, 11, 15, 26, 37, 59, 79, 103, 163, 234);       //
                conduitSizeGrid.Rows.Add("14"      , 1, 1, 3, 7, 9, 16, 22, 35, 48, 62, 98, 141);           //
                conduitSizeGrid.Rows.Add("22"      , 1, 1, 3, 5, 7, 12, 17, 26, 35, 46, 73, 105);           //
                conduitSizeGrid.Rows.Add("30"      , 1, 1, 1, 3, 5, 8, 12, 19, 26, 33, 53, 77);             //
                conduitSizeGrid.Rows.Add("38"      , 0, 1, 1, 2, 3, 6, 8, 13, 18, 23, 37, 54);              //
                conduitSizeGrid.Rows.Add("50"      , 0, 1, 1, 1, 3, 5, 7, 11, 15, 20, 32, 46);              //
                conduitSizeGrid.Rows.Add("60"      , 0, 1, 1, 1, 2, 4, 6, 10, 13, 17, 27, 39);              //
                conduitSizeGrid.Rows.Add("80"      , 0, 0, 1, 1, 1, 3, 5, 8, 11, 14, 23, 33);               //
                conduitSizeGrid.Rows.Add("100"     , 0, 0, 1, 1, 1, 3, 4, 7, 9, 12, 19, 27);                //
                conduitSizeGrid.Rows.Add("125"     , 0, 0, 0, 1, 1, 2, 3, 5, 7, 9, 15, 22);                 //
                conduitSizeGrid.Rows.Add("150"     , 0, 0, 0, 1, 1, 1, 3, 5, 6, 8, 13, 19);                 //
                conduitSizeGrid.Rows.Add("175"     , 0, 0, 0, 1, 1, 1, 2, 4, 6, 7, 12, 17);                 //
                conduitSizeGrid.Rows.Add("200"     , 0, 0, 0, 1, 1, 1, 2, 4, 5, 7, 10, 15);                 //
                conduitSizeGrid.Rows.Add("250"     , 0, 0, 0, 1, 1, 1, 1, 3, 4, 5, 9, 13);                  //
                conduitSizeGrid.Rows.Add("325"     , 0, 0, 0, 0, 1, 1, 1, 2, 3, 4, 7, 10);                  //
                conduitSizeGrid.Rows.Add("375"     , 0, 0, 0, 0, 0, 1, 1, 1, 3, 4, 6, 8);                   //
                conduitSizeGrid.Rows.Add("400"     , 0, 0, 0, 0, 0, 1, 1, 1, 3, 4, 6, 8);                   //
                conduitSizeGrid.Rows.Add("500"     , 0, 0, 0, 0, 0, 1, 1, 1, 2, 3, 5, 7);                   //
            }
            else if(wireType == WireType.THW && conduitType == ConduitType.PVC)
            {
                conduitSizeGrid.Rows.Add("2.0(1.6)", 4, 8, 13, 23, 32, 55, 79, 123, 166, 215, 341, 490);    //                  
                conduitSizeGrid.Rows.Add("3.5(2.0)", 3, 6, 10, 19, 26, 44, 63, 99, 133, 173, 274, 394);     //                   
                conduitSizeGrid.Rows.Add("5.5(2.6)", 2, 5, 8, 15, 20, 34, 49, 77, 104, 135, 214, 307);      //                   
                conduitSizeGrid.Rows.Add("8.0(3.2)", 1, 3, 5, 9, 12, 20, 29, 46, 62, 81, 128, 184);         //                   
                conduitSizeGrid.Rows.Add("14"      , 1, 1, 3, 7, 9, 16, 22, 35, 48, 62, 98, 141);           //
                conduitSizeGrid.Rows.Add("22"      , 1, 1, 3, 5, 7, 12, 17, 26, 35, 46, 73, 105);           //
                conduitSizeGrid.Rows.Add("30"      , 1, 1, 1, 3, 5, 8, 12, 19, 26, 33, 53, 77);             //
                conduitSizeGrid.Rows.Add("38"      , 0, 1, 1, 2, 3, 6, 8, 13, 18, 23, 37, 54);              //
                conduitSizeGrid.Rows.Add("50"      , 0, 1, 1, 1, 3, 5, 7, 11, 15, 20, 32, 46);              //
                conduitSizeGrid.Rows.Add("60"      , 0, 1, 1, 1, 2, 4, 6, 10, 13, 17, 27, 39);              //
                conduitSizeGrid.Rows.Add("80"      , 0, 0, 1, 1, 1, 3, 5, 8, 11, 14, 23, 33);               //
                conduitSizeGrid.Rows.Add("100"     , 0, 0, 1, 1, 1, 3, 4, 7, 9, 12, 19, 27);                //
                conduitSizeGrid.Rows.Add("125"     , 0, 0, 0, 1, 1, 2, 3, 5, 7, 9, 15, 22);                 //
                conduitSizeGrid.Rows.Add("150"     , 0, 0, 0, 1, 1, 1, 3, 5, 6, 8, 13, 19);                 //
                conduitSizeGrid.Rows.Add("175"     , 0, 0, 0, 1, 1, 1, 2, 4, 6, 7, 12, 17);                 //
                conduitSizeGrid.Rows.Add("200"     , 0, 0, 0, 1, 1, 1, 2, 4, 5, 7, 10, 15);                 //
                conduitSizeGrid.Rows.Add("250"     , 0, 0, 0, 1, 1, 1, 1, 3, 4, 5, 9, 13);                  //
                conduitSizeGrid.Rows.Add("325"     , 0, 0, 0, 0, 1, 1, 1, 2, 3, 4, 7, 10);                  //
                conduitSizeGrid.Rows.Add("375"     , 0, 0, 0, 0, 0, 1, 1, 1, 3, 4, 6, 8);                   //
                conduitSizeGrid.Rows.Add("400"     , 0, 0, 0, 0, 0, 1, 1, 1, 3, 4, 6, 8);                   //
                conduitSizeGrid.Rows.Add("500"     , 0, 0, 0, 0, 0, 1, 1, 1, 2, 3, 5, 7);                   //
            }
            else if(wireType == WireType.THHN && conduitType == ConduitType.PVC)
            {
                conduitSizeGrid.Rows.Add("2.0(1.6)", 9, 17, 28, 51, 70, 118, 170, 265, 358, 464, 736, 1055);    //
                conduitSizeGrid.Rows.Add("3.5(2.0)", 6, 12, 20, 37, 51, 86, 124, 193, 261, 338, 537, 770);      // 
                conduitSizeGrid.Rows.Add("5.5(2.6)", 4, 7, 13, 23, 32, 54, 78, 122, 164, 213, 338, 485);        //
                conduitSizeGrid.Rows.Add("8.0(3.2)", 2, 4, 7, 13, 18, 31, 45, 70, 95, 123, 195, 279);           //
                conduitSizeGrid.Rows.Add("14"      , 1, 3, 5, 9, 13, 22, 32, 51, 68, 89, 141, 202);             //
                conduitSizeGrid.Rows.Add("22"      , 1, 1, 3, 6, 8, 14, 20, 31, 42, 54, 86, 124);               //
                conduitSizeGrid.Rows.Add("30"      , 1, 1, 2, 4, 6, 10, 14, 22, 30, 39, 61, 88);                //
                conduitSizeGrid.Rows.Add("38"      , 0, 1, 1, 3, 4, 7, 10, 16, 22, 29, 45, 65);                 //
                conduitSizeGrid.Rows.Add("50"      , 0, 1, 1, 2, 3, 6, 9, 14, 18, 24, 38, 55);                  //
                conduitSizeGrid.Rows.Add("60"      , 0, 1, 1, 1, 3, 5, 7, 11, 15, 20, 32, 46);                  //
                conduitSizeGrid.Rows.Add("80"      , 0, 1, 1, 1, 2, 4, 6, 9, 13, 17, 26, 38);                   //
                conduitSizeGrid.Rows.Add("100"     , 0, 0, 1, 1, 1, 3, 5, 8, 10, 14, 22, 31);                   //
                conduitSizeGrid.Rows.Add("125"     , 0, 0, 1, 1, 1, 3, 4, 6, 8, 11, 18, 25);                    //
                conduitSizeGrid.Rows.Add("150"     , 0, 0, 0, 1, 1, 2, 3, 5, 7, 9, 15, 22);                     //
                conduitSizeGrid.Rows.Add("175"     , 0, 0, 0, 1, 1, 1, 3, 5, 6, 8, 13, 19);                     //
                conduitSizeGrid.Rows.Add("200"     , 0, 0, 0, 1, 1, 1, 3, 4, 6, 7, 12, 17);                     // 
                conduitSizeGrid.Rows.Add("250"     , 0, 0, 0, 1, 1, 1, 2, 3, 5, 6, 10, 14);                     //
                conduitSizeGrid.Rows.Add("325"     , 0, 0, 0, 0, 1, 1, 1, 3, 4, 5, 8, 12);                      //
                conduitSizeGrid.Rows.Add("375"     , 0, 0, 0, 0, 1, 1, 1, 2, 3, 4, 7, 9);                       //
                conduitSizeGrid.Rows.Add("400"     , 0, 0, 0, 0, 1, 1, 1, 2, 3, 4, 7, 9);                       // 
                conduitSizeGrid.Rows.Add("500"     , 0, 0, 0, 0, 0, 1, 1, 1, 2, 3, 5, 7);                       //
            }
            else if (wireType == WireType.TW && conduitType == ConduitType.RMC)
            {
                conduitSizeGrid.Rows.Add("2.0(1.6)", 9, 15, 25, 44, 59, 98, 140, 216, 288, 370, 581, 839);      //
                conduitSizeGrid.Rows.Add("3.5(2.0)", 7, 12, 19, 33, 45, 75, 107, 165, 221, 284, 446, 644);      //
                conduitSizeGrid.Rows.Add("5.5(2.6)", 5, 9, 14, 25, 34, 56, 80, 123, 164, 212, 332, 480);        //
                conduitSizeGrid.Rows.Add("8.0(3.2)", 3, 5, 8, 14, 19, 31, 44, 68, 91, 118, 185, 267);           //
                conduitSizeGrid.Rows.Add("14"      , 1, 3, 5, 8, 11, 18, 27, 41, 55, 71, 111, 160);             //
                conduitSizeGrid.Rows.Add("22"      , 1, 1, 3, 6, 8, 14, 20, 31, 41, 53, 83, 120);               //
                conduitSizeGrid.Rows.Add("30"      , 1, 1, 2, 4, 6, 10, 14, 22, 30, 38, 60, 87);                //
                conduitSizeGrid.Rows.Add("38"      , 1, 1, 1, 3, 4, 7, 10, 15, 21, 27, 42, 61);                 //
                conduitSizeGrid.Rows.Add("50"      , 1, 1, 1, 2, 3, 6, 8, 13, 18, 23, 36, 52);                  //
                conduitSizeGrid.Rows.Add("60"      , 0, 1, 1, 2, 3, 5, 7, 11, 15, 19, 31, 44);                  //
                conduitSizeGrid.Rows.Add("80"      , 0, 1, 1, 1, 2, 4, 6, 9, 13, 16, 26, 37);                   //
                conduitSizeGrid.Rows.Add("100"     , 0, 0, 1, 1, 1, 3, 5, 8, 10, 14, 21, 31);                   //
                conduitSizeGrid.Rows.Add("125"     , 0, 0, 1, 1, 1, 3, 4, 6, 8, 11, 17, 25);                    //
                conduitSizeGrid.Rows.Add("150"     , 0, 0, 1, 1, 1, 2, 3, 5, 7, 9, 15, 22);                     //
                conduitSizeGrid.Rows.Add("175"     , 0, 0, 0, 1, 1, 1, 3, 5 ,6, 8, 13, 19);                     //
                conduitSizeGrid.Rows.Add("200"     , 0, 0, 0, 1, 1, 1, 3, 4, 6, 7, 12, 17);                     //
                conduitSizeGrid.Rows.Add("250"     , 0, 0, 0, 1, 1, 1, 2, 3, 5, 6, 10, 14);                     // 
                conduitSizeGrid.Rows.Add("325"     , 0, 0, 0, 1, 1, 1, 1, 3, 4, 5, 8, 12);                      //
                conduitSizeGrid.Rows.Add("375"     , 0, 0, 0, 0, 1, 1, 1, 2, 3, 4, 7, 10);                      //
                conduitSizeGrid.Rows.Add("400"     , 0, 0, 0, 0, 1, 1, 1, 2, 3, 4, 7, 10);                      // 
                conduitSizeGrid.Rows.Add("500"     , 0, 0, 0, 0, 0, 1, 1, 1, 2, 3, 5, 8);                       //
            }
            else if (wireType == WireType.THW && conduitType == ConduitType.RMC)
            {
                conduitSizeGrid.Rows.Add("2.0(1.6)", 6, 10, 17, 29, 39, 65, 93, 143, 191, 246, 387, 558);       //
                conduitSizeGrid.Rows.Add("3.5(2.0)", 5, 8, 13, 23, 32, 52, 75, 115, 154, 198, 311, 448);        //
                conduitSizeGrid.Rows.Add("5.5(2.6)", 3, 6, 10, 18, 25, 41, 58, 90, 120, 154, 242, 350);         //
                conduitSizeGrid.Rows.Add("8.0(3.2)", 1, 4, 6, 11, 15, 24, 35, 54, 72, 92, 145, 209);            //
                conduitSizeGrid.Rows.Add("14"      , 1, 3, 5, 8, 11, 18, 27, 41, 55, 71, 111, 160);             //
                conduitSizeGrid.Rows.Add("22"      , 1, 1, 3, 6, 8, 14, 20, 31, 41, 53, 83, 120);               //
                conduitSizeGrid.Rows.Add("30"      , 1, 1, 2, 4, 6, 10, 14, 22, 30, 38, 60, 87);                //
                conduitSizeGrid.Rows.Add("38"      , 1, 1, 1, 3, 4, 7, 10, 15, 21, 27, 42, 61);                 //
                conduitSizeGrid.Rows.Add("50"      , 1, 1, 1, 2, 3, 6, 8, 13, 18, 23, 36, 52);                  //
                conduitSizeGrid.Rows.Add("60"      , 0, 1, 1, 2, 3, 5, 7, 11, 15, 19, 31, 44);                  //
                conduitSizeGrid.Rows.Add("80"      , 0, 1, 1, 1, 2, 4, 6, 9, 13, 16, 26, 37);                   //
                conduitSizeGrid.Rows.Add("100"     , 0, 0, 1, 1, 1, 3, 5, 8, 10, 14, 21, 31);                   //
                conduitSizeGrid.Rows.Add("125"     , 0, 0, 1, 1, 1, 3, 4, 6, 8, 11, 17, 25);                    //
                conduitSizeGrid.Rows.Add("150"     , 0, 0, 1, 1, 1, 2, 3, 5, 7, 9, 15, 22);                     //
                conduitSizeGrid.Rows.Add("175"     , 0, 0, 0, 1, 1, 1, 3, 5, 6, 8, 13, 19);                     //
                conduitSizeGrid.Rows.Add("200"     , 0, 0, 0, 1, 1, 1, 3, 4, 6, 7, 12, 17);                     //
                conduitSizeGrid.Rows.Add("250"     , 0, 0, 0, 1, 1, 1, 2, 3, 5, 6, 10, 14);                     //
                conduitSizeGrid.Rows.Add("325"     , 0, 0, 0, 1, 1, 1, 1, 3, 4, 5, 8, 12);                      //
                conduitSizeGrid.Rows.Add("375"     , 0, 0, 0, 0, 1, 1, 1, 2, 3, 4, 7, 10);                      //
                conduitSizeGrid.Rows.Add("400"     , 0, 0, 0, 0, 1, 1, 1, 2, 3, 4, 7, 10);                      //
                conduitSizeGrid.Rows.Add("500"     , 0, 0, 0, 0, 0, 1, 1, 1, 2, 3, 5, 8);                       //
            }
            else if (wireType == WireType.THHN && conduitType == ConduitType.RMC)
            {
                conduitSizeGrid.Rows.Add("2.0(1.6)", 13, 22, 36, 63, 85, 140, 200, 309, 412, 531, 833, 1202);   //
                conduitSizeGrid.Rows.Add("3.5(2.0)", 9, 16, 26, 46, 62, 102, 146, 62, 301, 387, 608, 877);      //
                conduitSizeGrid.Rows.Add("5.5(2.6)", 6, 10, 17, 29, 39, 64, 92, 142, 189, 244, 383, 552);       //
                conduitSizeGrid.Rows.Add("8.0(3.2)", 3, 6, 9, 16, 22, 37, 53, 82, 109, 140, 221, 318);          //
                conduitSizeGrid.Rows.Add("14"      , 2, 4, 7, 12, 16, 27, 38, 59, 79, 101, 159, 230);           //
                conduitSizeGrid.Rows.Add("22"      , 1, 2, 4, 7, 10, 16, 23, 36, 48, 62, 98, 141);              //
                conduitSizeGrid.Rows.Add("30"      , 1, 1, 3, 5, 7, 11, 17, 26, 34, 44, 70, 100);               //
                conduitSizeGrid.Rows.Add("38"      , 1, 1, 1, 4, 5, 8, 12, 19, 25, 33, 51, 74);                 //
                conduitSizeGrid.Rows.Add("50"      , 1, 1, 1, 3, 4, 7, 10, 16, 21, 27, 43, 63);                 //
                conduitSizeGrid.Rows.Add("60"      , 0, 1, 1, 2, 3, 6, 8, 13, 18, 23, 36, 52);                  // 
                conduitSizeGrid.Rows.Add("80"      , 0, 1, 1, 1, 3, 5, 7, 11, 15, 19, 30, 43);                  //
                conduitSizeGrid.Rows.Add("100"     , 0, 1, 1, 1, 2, 4, 6, 9, 12, 16, 25, 36);                   //
                conduitSizeGrid.Rows.Add("125"     , 0, 0, 1, 1, 1, 3, 5, 7, 10, 13, 20, 29);                   //
                conduitSizeGrid.Rows.Add("150"     , 0, 0, 1, 1, 1, 3, 4, 6, 8, 11, 17, 25);                    //
                conduitSizeGrid.Rows.Add("175"     , 0, 0, 1, 1, 1, 2, 3, 5, 7, 10, 15, 22);                    //
                conduitSizeGrid.Rows.Add("200"     , 0, 0, 1, 1, 1, 2, 3, 5, 7, 8, 13, 20);                     //
                conduitSizeGrid.Rows.Add("250"     , 0, 0, 0, 1, 1, 1, 2, 4, 5, 7, 11, 16);                     //
                conduitSizeGrid.Rows.Add("325"     , 0, 0, 0, 1, 1, 1, 1, 3, 4, 6, 9, 13);                      //
                conduitSizeGrid.Rows.Add("375"     , 0, 0, 0, 0, 1, 1, 1, 3, 4, 5, 7, 11);                      //
                conduitSizeGrid.Rows.Add("400"     , 0, 0, 0, 0, 1, 1, 1, 3, 4, 5, 7, 11);                      //
                conduitSizeGrid.Rows.Add("500"     , 0, 0, 0, 0, 1, 1, 1, 1, 3, 4, 6, 8);                       //
            }
            else if (wireType == WireType.TW && conduitType == ConduitType.IMC)
            {
                conduitSizeGrid.Rows.Add("2.0(1.6)",10, 17, 27, 47, 64, 104, 147, 228, 304, 392);              //
                conduitSizeGrid.Rows.Add("3.5(2.0)",7, 13, 21, 36, 49, 80, 113, 175, 234, 301);                //
                conduitSizeGrid.Rows.Add("5.5(2.6)",5, 9, 15, 27, 36, 59, 84, 130, 174, 224);                  //
                conduitSizeGrid.Rows.Add("8.0(3.2)",3, 5, 8, 15, 20, 33, 47, 72, 97, 124);                     //
                conduitSizeGrid.Rows.Add("14"      ,1, 3, 5, 9, 12, 20, 28, 43, 58, 75);                       //
                conduitSizeGrid.Rows.Add("22"      ,1, 2, 4, 6, 9, 15, 21, 32, 43, 56);                        //
                conduitSizeGrid.Rows.Add("30"      ,1, 1, 3, 5, 6, 11, 15, 23, 31, 41);                        //
                conduitSizeGrid.Rows.Add("38"      ,1, 1, 1, 3, 4, 7, 11, 16, 22, 28);                         //
                conduitSizeGrid.Rows.Add("50"      ,1, 1, 1, 3, 4, 6, 9, 14, 19, 24);                          //
                conduitSizeGrid.Rows.Add("60"      ,0, 1, 1, 2, 3, 5, 8, 12, 16, 20);                          //
                conduitSizeGrid.Rows.Add("80"      ,0, 1, 1, 1, 3, 4, 6, 10, 13, 17);                          //
                conduitSizeGrid.Rows.Add("100"     ,0, 1, 1, 1, 2, 4, 5, 8, 11, 14);                           //
                conduitSizeGrid.Rows.Add("125"     ,0, 0, 1, 1, 1, 3, 4, 7, 9, 12);                            //
                conduitSizeGrid.Rows.Add("150"     ,0, 0, 1, 1, 1, 2, 4, 6, 8, 10);                            //
                conduitSizeGrid.Rows.Add("175"     ,0, 0, 0, 1, 1, 1, 2, 4, 5, 7);                             //
                conduitSizeGrid.Rows.Add("200"     ,0, 0, 0, 1, 1, 1, 2, 4, 5, 7);                             //
                conduitSizeGrid.Rows.Add("250");                                                               //
                conduitSizeGrid.Rows.Add("325"     ,0, 0, 0, 1, 1, 1, 1, 3, 4, 5);                             //
                conduitSizeGrid.Rows.Add("375"     ,0, 0, 0, 0, 1, 1, 1, 2, 3, 4);                             //
                conduitSizeGrid.Rows.Add("400"     ,0, 0, 0, 0, 0, 1, 1, 1, 3, 3);                             //
                conduitSizeGrid.Rows.Add("500");                                                               //
            }
            else if (wireType == WireType.THW && conduitType == ConduitType.IMC)
            {
                conduitSizeGrid.Rows.Add("2.0(1.6)",6, 11, 18, 31, 42, 69, 98, 151, 202, 261);                 //
                conduitSizeGrid.Rows.Add("3.5(2.0)",5, 9, 14, 25, 34, 56, 79, 122, 163, 209);                  //
                conduitSizeGrid.Rows.Add("5.5(2.6)",4, 7, 11, 19, 26, 43, 61, 95, 127, 163);                   //
                conduitSizeGrid.Rows.Add("8.0(3.2)",2, 4, 7, 12, 16, 26, 37, 57, 76, 98);                      //
                conduitSizeGrid.Rows.Add("14"      ,1, 3, 5, 9, 12, 20, 28, 43, 58, 75);                       //
                conduitSizeGrid.Rows.Add("22"      ,1, 2, 4, 6, 9, 15, 21, 32, 43, 56);                        //
                conduitSizeGrid.Rows.Add("30"      ,1, 1, 3, 5, 6, 11, 15, 23, 31, 41);                        //
                conduitSizeGrid.Rows.Add("38"      ,1, 1, 1, 3, 4, 7, 11, 16, 22, 28);                         //
                conduitSizeGrid.Rows.Add("50"      ,1, 1, 1, 3, 4, 6, 9, 14, 19, 24);                          //
                conduitSizeGrid.Rows.Add("60"      ,0, 1, 1, 2, 3, 5, 8, 12, 16, 20);                          //
                conduitSizeGrid.Rows.Add("80"      ,0, 1, 1, 1, 3, 4, 6, 10, 13, 17);                          //
                conduitSizeGrid.Rows.Add("100"     ,0, 1, 1, 1, 2, 4, 5, 8, 11, 14);                           //
                conduitSizeGrid.Rows.Add("125"     ,0, 0, 1, 1, 1, 3, 4, 7, 9, 12);                            //
                conduitSizeGrid.Rows.Add("150"     ,0, 0, 1, 1, 1, 2, 4, 6, 8, 10);                            //
                conduitSizeGrid.Rows.Add("175"     ,0, 0, 0, 1, 1, 1, 2, 4, 5, 7);                             //
                conduitSizeGrid.Rows.Add("200"     ,0, 0, 0, 1, 1, 1, 2, 4, 5, 7);                             //
                conduitSizeGrid.Rows.Add("250");                                                               //
                conduitSizeGrid.Rows.Add("325"     ,0, 0, 0, 1, 1, 1, 1, 3, 4, 5);                             //
                conduitSizeGrid.Rows.Add("375"     ,0, 0, 0, 0, 1, 1, 1, 2, 3, 4);                             //
                conduitSizeGrid.Rows.Add("400"     ,0, 0, 0, 0, 0, 1, 1, 1, 3, 3);                             //
                conduitSizeGrid.Rows.Add("500");                                                               //
            }
            else if (wireType == WireType.THHN && conduitType == ConduitType.IMC)
            {
                conduitSizeGrid.Rows.Add("2.0(1.6)", 14, 24, 39, 68, 91,  149, 211, 326, 436, 562);             //
                conduitSizeGrid.Rows.Add("3.5(2.0)", 10, 17, 29, 49, 67, 109, 154, 238, 318, 410);              //
                conduitSizeGrid.Rows.Add("5.5(2.6)", 6, 11, 18, 31, 42, 68, 97, 150, 200, 258);                 //
                conduitSizeGrid.Rows.Add("8.0(3.2)", 3, 6, 10, 18, 24, 39, 56, 86, 115, 149);                   //
                conduitSizeGrid.Rows.Add("14"      , 2, 4, 7, 13, 17, 28, 40, 62, 83, 107);                     //
                conduitSizeGrid.Rows.Add("22"      , 1, 3, 4, 8, 10, 17, 25, 38, 51, 66);                       //
                conduitSizeGrid.Rows.Add("30"      , 1, 1, 3, 5, 7, 12, 17, 27, 36, 47);                        //
                conduitSizeGrid.Rows.Add("38"      , 1, 1, 2, 4, 5, 9, 13, 20, 27, 35);                         //
                conduitSizeGrid.Rows.Add("50"      , 1, 1, 1, 3, 4, 8, 11, 17, 23, 29);                         //
                conduitSizeGrid.Rows.Add("60"      , 1, 1, 1, 3, 4, 6, 9, 14, 19, 24);                          //
                conduitSizeGrid.Rows.Add("80"      , 0, 1, 1, 2, 3, 5, 7, 12, 16, 20);                          //
                conduitSizeGrid.Rows.Add("100"     , 0, 1, 1, 1, 2, 4, 6, 9, 13, 17);                           //
                conduitSizeGrid.Rows.Add("125"     , 0, 0, 1, 1, 1, 3, 5, 8, 10, 13);                           //
                conduitSizeGrid.Rows.Add("150"     , 0, 0, 1, 1, 1, 3, 4, 7, 9, 12);                            //
                conduitSizeGrid.Rows.Add("175"     , 0, 0, 1, 1, 1, 3, 4, 6, 8, 10);                            //
                conduitSizeGrid.Rows.Add("200"     , 0, 0, 1, 1, 1, 2, 3, 5, 7, 9);                             //
                conduitSizeGrid.Rows.Add("250"     , 0, 0, 0, 1, 1, 1, 3, 4, 6, 7);                             //
                conduitSizeGrid.Rows.Add("325"     , 0, 0, 0, 1, 1, 1, 2, 3, 5, 6);                             //
                conduitSizeGrid.Rows.Add("375"     , 0, 0, 0, 1, 1, 1, 1, 3, 4, 5);                             //
                conduitSizeGrid.Rows.Add("400"     , 0, 0, 0, 1, 1, 1, 1, 3, 4, 6);                             //
                conduitSizeGrid.Rows.Add("500"     , 0, 0, 0, 0, 1, 1, 1, 2, 3, 4);                             //
            }
            else if (wireType == WireType.TW && conduitType == ConduitType.EMT)
            {
                conduitSizeGrid.Rows.Add("2.0(1.6)", 8, 15, 25, 43, 58, 96, 168, 254, 332, 424);                //
                conduitSizeGrid.Rows.Add("3.5(2.0)", 6, 11, 19, 33, 45, 74, 129, 195, 255, 326);                //
                conduitSizeGrid.Rows.Add("5.5(2.6)", 5, 8, 14, 24, 33, 55, 96, 145, 190, 243);                  // 
                conduitSizeGrid.Rows.Add("8.0(3.2)", 2, 5, 8, 13, 18, 30, 53, 81, 105, 135);                    //
                conduitSizeGrid.Rows.Add("14"      , 1, 3, 4, 8, 11, 18, 32, 48, 63, 81);                       //
                conduitSizeGrid.Rows.Add("22"      , 1, 1, 3, 6, 8, 13, 24, 36, 47, 60);                        //
                conduitSizeGrid.Rows.Add("30"      , 1, 1, 2, 4, 6, 10, 17, 26, 34, 44);                        //
                conduitSizeGrid.Rows.Add("38"      , 1, 1, 1, 3, 4, 7, 12, 18, 24, 31);                         //
                conduitSizeGrid.Rows.Add("50"      , 0, 1, 1, 2, 3, 6, 10, 16, 20, 26);                         //
                conduitSizeGrid.Rows.Add("60"      , 0, 1, 1, 1, 3, 5, 9, 13, 17, 22);                          //
                conduitSizeGrid.Rows.Add("80"      , 0, 1, 1, 1, 2, 4, 7, 11, 15, 19);                          //
                conduitSizeGrid.Rows.Add("100"     , 0, 0, 1, 1, 1, 3, 6, 9, 12, 16);                           //
                conduitSizeGrid.Rows.Add("125"     , 0, 0, 1, 1, 1, 3, 5, 7, 10, 13);                           //
                conduitSizeGrid.Rows.Add("150"     , 0, 0, 1, 1, 1, 2, 4, 6, 8, 11);                            //
                conduitSizeGrid.Rows.Add("175"     , 0, 0, 0, 1, 1, 1, 4 ,6, 7, 10);                            //
                conduitSizeGrid.Rows.Add("200"     , 0, 0, 0, 1, 1, 1, 3, 5, 7, 9);                             //
                conduitSizeGrid.Rows.Add("250"     , 0, 0, 0, 1, 1, 1, 3, 4, 6, 7);                             //
                conduitSizeGrid.Rows.Add("325"     , 0, 0, 0, 1, 1, 1, 2, 3, 4, 6);                             //
                conduitSizeGrid.Rows.Add("375"     , 0, 0, 0, 0, 1, 1, 1, 3, 4, 5);                             //
                conduitSizeGrid.Rows.Add("400"     , 0, 0, 0, 0, 1, 1, 1, 3, 4, 5);                             //
                conduitSizeGrid.Rows.Add("500"     ,  0, 0, 0, 0, 0, 1, 1, 2, 3, 4);                             //
            }
            else if (wireType == WireType.THW && conduitType == ConduitType.EMT)
            {
                conduitSizeGrid.Rows.Add("2.0(1.6)", 6, 10, 16, 18, 39, 64, 112, 169, 221, 282);                //
                conduitSizeGrid.Rows.Add("3.5(2.0)", 4, 8, 13, 23, 31, 51, 90, 136, 177, 227);                  //
                conduitSizeGrid.Rows.Add("5.5(2.6)", 3, 6, 10, 18, 24, 40, 70, 106, 138, 177);                  //
                conduitSizeGrid.Rows.Add("8.0(3.2)", 1, 4, 6, 10, 14, 24, 42, 63, 83, 106);                     //
                conduitSizeGrid.Rows.Add("14"      , 1, 3, 4, 8, 11, 18, 32, 48, 63, 81);                       //
                conduitSizeGrid.Rows.Add("22"      , 1, 1, 3, 6, 8, 13, 24, 36, 47, 60);                        //
                conduitSizeGrid.Rows.Add("30"      , 1, 1, 2, 4, 6, 10, 17, 26, 34, 44);                        //
                conduitSizeGrid.Rows.Add("38"      , 1, 1, 1, 3, 4, 7, 12, 18, 24, 31);                         //
                conduitSizeGrid.Rows.Add("50"      , 0, 1, 1, 2, 3, 6, 10, 16, 20, 26);                         //
                conduitSizeGrid.Rows.Add("60"      , 0, 1, 1, 1, 3, 5, 9, 13, 17, 22);                          //
                conduitSizeGrid.Rows.Add("80"      , 0, 1, 1, 1, 2, 4, 7, 11, 15, 19);                          //
                conduitSizeGrid.Rows.Add("100"     , 0, 0, 1, 1, 1, 3, 6, 9, 12, 16);                           //
                conduitSizeGrid.Rows.Add("125"     , 0, 0, 1, 1, 1, 3, 5, 7, 10, 13);                           //
                conduitSizeGrid.Rows.Add("150"     , 0, 0, 1, 1, 1, 2, 4, 6, 8, 11);                            //
                conduitSizeGrid.Rows.Add("175"     , 0, 0, 0, 1, 1, 1, 4, 6, 7, 10);                            //
                conduitSizeGrid.Rows.Add("200"     , 0, 0, 0, 1, 1, 1, 3, 5, 7, 9);                             //
                conduitSizeGrid.Rows.Add("250"     , 0, 0, 0, 1, 1, 1, 3, 4, 6, 7);                             //
                conduitSizeGrid.Rows.Add("325"     , 0, 0, 0, 1, 1, 1, 2, 3, 4, 6);                             //
                conduitSizeGrid.Rows.Add("375"     , 0, 0, 0, 0, 1, 1, 1, 3, 4, 5);                             //
                conduitSizeGrid.Rows.Add("400"     , 0, 0, 0, 0, 1, 1, 1, 3, 4, 5);                             //
                conduitSizeGrid.Rows.Add("500"     , 0, 0, 0, 0, 0, 1, 1, 2, 3, 4);                             //
            }
            else if (wireType == WireType.THHN && conduitType == ConduitType.EMT)
            {
                conduitSizeGrid.Rows.Add("2.0(1.6)", 12, 22, 35, 61, 138, 241, 364, 476, 608);                  //
                conduitSizeGrid.Rows.Add("3.5(2.0)", 9, 16, 26, 45, 61, 101, 176, 266, 347, 443);               //
                conduitSizeGrid.Rows.Add("5.5(2.6)", 5, 10, 16, 28, 38, 63, 111, 167, 219, 279);                //
                conduitSizeGrid.Rows.Add("8.0(3.2)", 3, 6, 9, 16, 22, 36, 64, 96, 126, 161);                    //
                conduitSizeGrid.Rows.Add("14"      , 2, 4, 7, 12, 26, 46, 69, 91, 116);                         //
                conduitSizeGrid.Rows.Add("22"      , 1, 2, 4, 7, 10, 16, 28, 43, 56, 71);                       //
                conduitSizeGrid.Rows.Add("30"      , 1, 1, 3, 5, 7, 11, 20, 30, 40, 51);                        //
                conduitSizeGrid.Rows.Add("38"      , 1, 1, 1, 4, 5, 8, 15, 22, 29, 37);                         //
                conduitSizeGrid.Rows.Add("50"      , 1, 1, 1, 3, 4, 7, 12, 19, 25, 32);                         //
                conduitSizeGrid.Rows.Add("60"      , 0, 1, 1, 2, 3, 6, 10, 16, 20, 26);                         //
                conduitSizeGrid.Rows.Add("80"      , 0, 1, 1, 1, 3, 5, 8, 13, 17, 22);                          //
                conduitSizeGrid.Rows.Add("100"     , 0, 1, 1, 1, 2, 4, 7, 11, 14, 18);                          //
                conduitSizeGrid.Rows.Add("125"     , 0, 0, 1, 1, 1, 3, 6, 9, 11, 15);                           //
                conduitSizeGrid.Rows.Add("150"     , 0, 0, 1, 1, 1, 3, 5, 7, 10, 13);                           //
                conduitSizeGrid.Rows.Add("175"     , 0, 0, 1, 1, 1, 2, 4, 6, 9, 11);                            //
                conduitSizeGrid.Rows.Add("200"     , 0, 0, 0, 1, 1, 1, 4, 6, 8, 10);                            //
                conduitSizeGrid.Rows.Add("250"     , 0, 0, 0, 1, 1, 1, 3, 5, 6, 8);                             //
                conduitSizeGrid.Rows.Add("325"     , 0, 0, 0, 1, 1, 1, 2, 4, 5, 7);                             //
                conduitSizeGrid.Rows.Add("375"     , 0, 0, 0, 0, 1, 1, 1, 3, 4, 5);                             //
                conduitSizeGrid.Rows.Add("400"     , 0, 0, 0, 0, 1, 1, 1, 3, 4, 5);                             //
                conduitSizeGrid.Rows.Add("500"     , 0, 0, 0, 0, 1, 1, 1, 2, 3, 4);                             //
            }
        }

        private void conduitSizeGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (conduitSizeGrid.CurrentCell.ColumnIndex != 0)
            {
                conduitSizeLabel.Text = "CONDUIT SIZE: " + conduitSizeGrid.Columns[conduitSizeGrid.CurrentCell.ColumnIndex].HeaderText + " mm. dia. " + conduitType.ToString();
                ConduitSize = conduitSizeGrid.Columns[conduitSizeGrid.CurrentCell.ColumnIndex].HeaderText + " mm. dia. " + conduitType.ToString();
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            close = true;
            cancel = true;
            this.Close();
        }

        private void ok_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (conduitSizeLabel.Text == "CONDUIT SIZE:")
                {
                    throw new Exception("PLEASE CHOOSE CONDUIT SIZE");
                }

                if(length.Text == string.Empty)
                {
                    throw new Exception("PLEASE SPECIFY AN INPUT FOR LENGTH!");
                }

                if(resistance.Enabled)
                {
                    if(resistance.Text == string.Empty)
                    {
                        throw new Exception("PLEASE SPECIFY AN INPUT FOR RESISTANCE!");
                    }

                    AC_Resistance = float.Parse(resistance.Text);
                }

                float wireLength = float.Parse(length.Text);
                
                float R = AC_Resistance / 305f;

                _resistance = R.ToString();
                _length = length.Text;

                float voltageDrop = 0f;
                if(ptype == PhaseType.SinglePhase)
                    voltageDrop = (2f * ampere * R * wireLength) / voltage;
                else
                    voltageDrop = ((float)Math.Sqrt(3) * ampere * R * wireLength) / voltage;

                if (voltageDrop > 0.05)
                {
                    DialogResult result = MessageBox.Show("VOLTAGE DROP EXCEEDS 3%!", "VOLTAGE DROP ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

                    if(result == DialogResult.Abort)
                    {
                        close = true;
                        cancel = true;
                        this.Close();
                    }
                    else if(result == DialogResult.Ignore)
                    {
                        close = true;
                        this.Close();
                    }
                    else if(result == DialogResult.Retry)
                    {
                        this.Close();
                    }
                }
                else
                {
                    close = true;
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        float Resistance(string conduitSize)
        {
            float resistance = 0f;
            switch(conduitSize)
            {
                case "2.0(1.6)":
                    resistance = 3.1f;
                    break;
                case "3.5(2.0)":
                    resistance = 2.0f;
                    break;
                case "5.5(2.6)":
                    resistance = 1.2f;
                    break;
                case "8.0(3.2)":
                    resistance = 0.78f;
                    break;
                case "14":
                    resistance = 0.49f;
                    break;
                case "22":
                    resistance = 0.31f;
                    break;
                case "30":
                    resistance = 0.20f;
                    break;
                case "38":
                    resistance = 0.16f;
                    break;
                case "50":
                    resistance = 0.13f;
                    break;
                case "60":
                    resistance = 0.10f;
                    break;
            }

            return resistance;
        }

        bool wireOverSixty(string conduitSize)
        {
            bool flag = false;
            switch (conduitSize)
            {
                case "2.0(1.6)":
                case "3.5(2.0)":
                case "5.5(2.6)":
                case "8.0(3.2)":
                case "14":
                case "22":
                case "30":
                case "38":
                case "50":
                case "60":
                    flag = false;
                    break;

                default:
                    flag = true;
                    break;
            }

            return flag;
        }

        string nextWireSize(string conduitSize)
        {
            switch(conduitSize)
            {
                case "2.0(1.6)":
                    conduitSize = "3.5(2.0)";
                    break;
                case "3.5(2.0)":
                    conduitSize = "5.5(2.6)";
                    break;
                case "5.5(2.6)":
                    conduitSize = "8.0(3.2)";
                    break;
                case "8.0(3.2)":
                    conduitSize = "14";
                    break;
                case "14":
                    conduitSize = "22";
                    break;
                case "22":
                    conduitSize = "30";
                    break;
                case "30":
                    conduitSize = "38";
                    break;
                case "38":
                    conduitSize = "50";
                    break;
                case "50":
                    conduitSize = "60";
                    break;
                case "60":
                    conduitSize = "80";
                    break;
                case "80":
                    conduitSize = "100";
                    break;
                case "100":
                    conduitSize = "125";
                    break;
                case "125":
                    conduitSize = "150";
                    break;
                case "150":
                    conduitSize = "200";
                    break;
                case "200":
                    conduitSize = "250";
                    break;
                case "250":
                    conduitSize = "325";
                    break;
                case "325":
                    conduitSize = "400";
                    break;
                case "400":
                    conduitSize = "500";
                    break;
                case "500":
                    break;
            }

            return conduitSize;
        }

        private void resistanceGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void resistanceGrid_Click(object sender, EventArgs e)
        {
            if(resistanceGrid.CurrentCell.ColumnIndex  != 0)
            {
                resistance.Text = resistanceGrid.CurrentCell.Value.ToString();
            }
        }

        private void conduitSizeGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
