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
    public partial class Number_of_Lamps : UserControl
    {
        public Number_of_Lamps()
        {
            InitializeComponent();
        }

        private void Number_of_Lamps_Load(object sender, EventArgs e)
        {
            bunifuCustomDataGrid1.Rows.Add("EFFICIENT FIXTURE, LARGE UNIT COLORED ROOM", "0.45");
            bunifuCustomDataGrid1.Rows.Add("AVERAGE FIXTURE, MEDIUM SIZE ROOM", "0.35");
            bunifuCustomDataGrid1.Rows.Add("INEFFICIENT FIXTURE, SMALL OR DARK ROOM", "0.25");

            bunifuCustomDataGrid3.Rows.Add("ENCLOSED FIXTURE, CLEAN ROOM", "0.80");
            bunifuCustomDataGrid3.Rows.Add("AVERAGE CONDITIONS", "0.70");
            bunifuCustomDataGrid3.Rows.Add("OPEN FIXTURE OR DIRTY ROOM", "0.60");
        }

        private void area_OnValueChanged(object sender, EventArgs e)
        {
            try
            {
                float a = (area.Text == string.Empty) ? 0 : float.Parse(area.Text);

                float lumen = (lumens.Text == string.Empty) ? 0 : float.Parse(lumens.Text);

                float lvl = (level.Text == string.Empty) ? 0 : float.Parse(level.Text);

                if(lvl < 150f || lvl > 40000f)
                {
                    throw new Exception("Please refer to the Illumination Level!");
                }

                float cf = (coefficient.Text == string.Empty) ? 0 : float.Parse(coefficient.Text);

                if (cf != 0.45f && cf != 0.35f && cf != 0.25f)
                {
                    throw new Exception("Please refer to the Coefficient Utilization table.");
                }

                float fact = (factor.Text == string.Empty) ? 0 : float.Parse(factor.Text);

                if(fact != 0.8f && fact != 0.7f && fact != 0.6f)
                {
                    throw new Exception("Please refer to the Maintenance Factor table.");
                }

                double r = Math.Round((lvl * a) / (lumen * fact * cf));
                lampCount.Text = ((long)r).ToString();
            }
            catch(Exception ex)
            {
                lampCount.Text = ex.Message;
            }
        }

        private void coefficient_OnValueChanged(object sender, EventArgs e)
        {
            try
            {
                float a = (area.Text == string.Empty) ? 0 : float.Parse(area.Text);

                float lumen = (lumens.Text == string.Empty) ? 0 : float.Parse(lumens.Text);

                float lvl = (level.Text == string.Empty) ? 0 : float.Parse(level.Text);

                if (lvl < 150f || lvl > 40000f)
                {
                    throw new Exception("Please refer to the Illumination Level!");
                }

                float cf = (coefficient.Text == string.Empty) ? 0 : float.Parse(coefficient.Text);

                if (cf != 0.45f && cf != 0.35f && cf != 0.25f)
                {
                    throw new Exception("Please refer to the Coefficient Utilization table.");
                }

                float fact = (factor.Text == string.Empty) ? 0 : float.Parse(factor.Text);

                if (fact != 0.8f && fact != 0.7f && fact != 0.6f)
                {
                    throw new Exception("Please refer to the Maintenance Factor table.");
                }

                double r = Math.Round((lvl * a) / (lumen * fact * cf));
                lampCount.Text = ((long)r).ToString();
            }
            catch (Exception ex)
            {
                lampCount.Text = ex.Message;
            }
        }

        private void lumens_OnValueChanged(object sender, EventArgs e)
        {
            try
            {
                float a = (area.Text == string.Empty) ? 0 : float.Parse(area.Text);

                float lumen = (lumens.Text == string.Empty) ? 0 : float.Parse(lumens.Text);

                float lvl = (level.Text == string.Empty) ? 0 : float.Parse(level.Text);

                if (lvl < 150f || lvl > 40000f)
                {
                    throw new Exception("Please refer to the Illumination Level!");
                }

                float cf = (coefficient.Text == string.Empty) ? 0 : float.Parse(coefficient.Text);

                if (cf != 0.45f && cf != 0.35f && cf != 0.25f)
                {
                    throw new Exception("Please refer to the Coefficient Utilization table.");
                }

                float fact = (factor.Text == string.Empty) ? 0 : float.Parse(factor.Text);

                if (fact != 0.8f && fact != 0.7f && fact != 0.6f)
                {
                    throw new Exception("Please refer to the Maintenance Factor table.");
                }

                double r = Math.Round((lvl * a) / (lumen * fact * cf));
                lampCount.Text = ((long)r).ToString();
            }
            catch (Exception ex)
            {
                lampCount.Text = ex.Message;
            }
        }

        private void factor_OnValueChanged(object sender, EventArgs e)
        {
            try
            {
                float a = (area.Text == string.Empty) ? 0 : float.Parse(area.Text);

                float lumen = (lumens.Text == string.Empty) ? 0 : float.Parse(lumens.Text);

                float lvl = (level.Text == string.Empty) ? 0 : float.Parse(level.Text);

                if (lvl < 150f || lvl > 40000f)
                {
                    throw new Exception("Please refer to the Illumination Level!");
                }

                float cf = (coefficient.Text == string.Empty) ? 0 : float.Parse(coefficient.Text);

                if (cf != 0.45f && cf != 0.35f && cf != 0.25f)
                {
                    throw new Exception("Please refer to the Coefficient Utilization table.");
                }

                float fact = (factor.Text == string.Empty) ? 0 : float.Parse(factor.Text);

                if (fact != 0.8f && fact != 0.7f && fact != 0.6f)
                {
                    throw new Exception("Please refer to the Maintenance Factor table.");
                }

                double r = Math.Round((lvl * a) / (lumen * fact * cf));
                lampCount.Text = ((long)r).ToString();
            }
            catch (Exception ex)
            {
                lampCount.Text = ex.Message;
            }
        }

        private void level_OnValueChanged(object sender, EventArgs e)
        {
            try
            {
                float a = (area.Text == string.Empty) ? 0 : float.Parse(area.Text);

                float lumen = (lumens.Text == string.Empty) ? 0 : float.Parse(lumens.Text);

                float lvl = (level.Text == string.Empty) ? 0 : float.Parse(level.Text);

                if (lvl < 150f || lvl > 40000f)
                {
                    throw new Exception("Please refer to the Illumination Level!");
                }

                float cf = (coefficient.Text == string.Empty) ? 0 : float.Parse(coefficient.Text);

                if (cf != 0.45f && cf != 0.35f && cf != 0.25f)
                {
                    throw new Exception("Please refer to the Coefficient Utilization table.");
                }

                float fact = (factor.Text == string.Empty) ? 0 : float.Parse(factor.Text);

                if (fact != 0.8f && fact != 0.7f && fact != 0.6f)
                {
                    throw new Exception("Please refer to the Maintenance Factor table.");
                }

                double r = Math.Round((lvl * a) / (lumen * fact * cf));
                lampCount.Text = ((long)r).ToString();
            }
            catch (Exception ex)
            {
                lampCount.Text = ex.Message;
            }
        }

        private void lampCount_OnValueChanged(object sender, EventArgs e)
        {

        }
    }
}