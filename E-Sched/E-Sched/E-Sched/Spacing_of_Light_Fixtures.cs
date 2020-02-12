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
    public partial class Spacing_of_Light_Fixtures : UserControl
    {
        public Spacing_of_Light_Fixtures()
        {
            InitializeComponent();
        }

        private void Spacing_of_Light_Fixtures_Load(object sender, EventArgs e)
        {
            bunifuCustomDataGrid2.Rows.Add("DIRECT CONCENTRATING", "0.40");
            bunifuCustomDataGrid2.Rows.Add("DIRECT SPREADING", "1.20");
            bunifuCustomDataGrid2.Rows.Add("DIRECT INDIRECT DIFFUSING", "1.30");
            bunifuCustomDataGrid2.Rows.Add("SEMI-DIRECT-INDIRECT", "1.50");

            spacing.Enabled = false;
        }

        private void height_OnValueChanged(object sender, EventArgs e)
        {
            try
            {
                Single h = (height.Text == string.Empty) ? 0 : Single.Parse(height.Text);

                Single r = (ratio.Text == string.Empty) ? 0 : Single.Parse(ratio.Text);

                if(r != 0.4f && r != 1.2f && r != 1.3f && r != 1.5f)
                {
                    throw new Exception("Please refer to the ratio on the table.");
                }

                Single sp = h * r;

                spacing.Text = sp.ToString();
            }
            catch(Exception ex)
            {
                spacing.Text = ex.Message;
            }
        }

        private void ratio_OnValueChanged(object sender, EventArgs e)
        {
            try
            {
                Single h = (height.Text == string.Empty) ? 0 : Single.Parse(height.Text);

                Single r = (ratio.Text == string.Empty) ? 0 : Single.Parse(ratio.Text);

                if (r != 0.4f && r != 1.2f && r != 1.3f && r != 1.5f)
                {
                    throw new Exception("Please refer to the ratio on the table.");
                }

                Single sp = h * r;

                spacing.Text = sp.ToString();
            }
            catch (Exception ex)
            {
                spacing.Text = ex.Message;
            }
        }
    }
}
