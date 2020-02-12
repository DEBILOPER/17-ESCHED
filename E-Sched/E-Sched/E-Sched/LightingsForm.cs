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
    public partial class LightingsForm : Form
    {
        // example: 5-5W-FLOURESCENT, 3-6w-BULB

        public bool close = false;
        public string description;

        public string LO;
        public float VA;

        public LightingsForm()
        {
            InitializeComponent();
        }

        private void add_Btn_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Add();
        }

        private void exit_Btn_Click(object sender, EventArgs e)
        {
            close = true;
            this.Close();
        }

        private void LightingsForm_Load(object sender, EventArgs e)
        {
            close = false;
            description = string.Empty;
            LO = string.Empty;
            VA = 0f;
            dataGridView.Rows.Clear();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            close = true;
            this.Close();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                float outlet = 0f;
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    outlet = outlet + float.Parse(row.Cells[0].Value.ToString());
                    VA = VA + (float.Parse(row.Cells[0].Value.ToString()) * float.Parse(row.Cells[1].Value.ToString()));
                    
                    description = description + row.Cells[0].Value.ToString() + "-" + row.Cells[1].Value.ToString() + "W-" + row.Cells[2].Value.ToString();
                    
                    if(row != dataGridView.Rows[dataGridView.Rows.Count - 1])
                    {
                        description = description + ",";
                    }
                }

                VA = VA / 0.8F;

                LO = outlet.ToString();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void remove_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView.Rows.Count == 0)
                {
                    throw new Exception("There is currently no row to delete!");
                }

                dataGridView.Rows.RemoveAt(dataGridView.SelectedRows[0].Index);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void dataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int index = -1;
            try
            {
                if (dataGridView.Rows.Count != 0)
                {

                    index = dataGridView.CurrentCell.ColumnIndex;

                    if (index == 0)
                    {
                        int lampCount = int.Parse(dataGridView.CurrentCell.Value.ToString());
                    }
                    else if(index == 1)
                    {
                        int watts = int.Parse(dataGridView.CurrentCell.Value.ToString());
                    }
                }
            }
            catch(Exception ex)
            {
                if(index == 0 || index == 1)
                {
                    dataGridView.CurrentCell.Value = string.Empty;
                }

                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
