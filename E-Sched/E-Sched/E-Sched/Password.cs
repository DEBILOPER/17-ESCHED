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
    public partial class Password : Form
    {
        private string filename;

        public bool cancelled;

        public Password(string filename)
        {
            this.filename = filename;
            InitializeComponent();
        }

        private void exit_Btn_Click(object sender, EventArgs e)
        {
            cancelled = true;
            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            cancelled = true;
            this.Close();
        }

        private void Password_Load(object sender, EventArgs e)
        {
            cancelled = false;
        }

        private void ok_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (pass_word.Text == string.Empty)
                    throw new Exception("PLEASE ENTER PASSWORD!");

                DatabaseConnection.connection.Open();

                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.CommandText = "SELECT *from FILES where [PASSWORD] = '" + pass_word.Text + "' and [FILENAME] = '" + filename + "'";
                    cmd.Connection = DatabaseConnection.connection;

                    var reader = cmd.ExecuteReader();

                    int count = 0;
                    while(reader.Read())
                    {
                        count++;
                    }

                    if (count == 0)
                        throw new Exception("INVALID PASSWORD!");
                    else if(count == 1)
                    {
                        DatabaseConnection.connection.Close();
                        this.Close();
                    }
                }
            }
            catch(Exception ex)
            {
                pass_word.Text = string.Empty;

                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DatabaseConnection.connection.Close();
            }
        }
    }
}
