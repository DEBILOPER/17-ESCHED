using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace E_Sched
{
    public partial class NewFileDialogBox : Form
    {
        private Phase phase = new Phase();
        private DialogResult result;

        public bool cancelled;

        public NewFileDialogBox()
        {
            InitializeComponent();
        }

        private void exit_Btn_Click(object sender, EventArgs e)
        {
            result = MessageBox.Show("Are you sure you want to cancel creating a new file?", "CANCEL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(result == DialogResult.Yes)
            {
                cancelled = true;
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

        private void ok_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (filename.Text == string.Empty || password.Text == string.Empty)
                    throw new Exception("PLEASE SPECIFY AN INPUT!");

                if(filename.Text.Contains('.'))
                    throw new Exception("Invalid filename input!");

                DatabaseConnection.connection.Open();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = DatabaseConnection.connection;
                cmd.CommandText = "SELECT [FILENAME] from FILES";

                var file = cmd.ExecuteReader();

                bool found = false;
                while(file.Read())
                {
                    if(file["FILENAME"].ToString() == filename.Text)
                    {
                        found = true;
                        break;
                    }
                }

                DatabaseConnection.connection.Close();

                if (!found)
                {
                    Data.Filename = filename.Text;
                    Data.Password = password.Text;

                    cancelled = false;
                    this.Close();
                }
                else
                    throw new Exception("FILENAME ALREADY EXISTS");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NewFileDialogBox_Load(object sender, EventArgs e)
        {
            cancelled = false;

            filename.Text = string.Empty;
            password.Text = string.Empty;
        }
    }
}
