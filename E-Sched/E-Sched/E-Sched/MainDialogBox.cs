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
    public partial class MainDialogBox : Form
    {
        private NewFileDialogBox newDialog = new NewFileDialogBox();
        private Unit unit                  = new Unit();
        private Phase phase                = new Phase();
        private Voltage voltage            = new Voltage();

        private Schedule schedule;

        private bool cancelled = false;

        public MainDialogBox()
        {
            InitializeComponent();
        }

        private void MainDialogBox_Load(object sender, EventArgs e)
        {
            newFile_toolTip.SetToolTip(newFile_Btn, "Creates a new schedule file.");

            try
            {
                DatabaseConnection.connection.Open();

                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = DatabaseConnection.connection;
                    cmd.CommandText = "SELECT *from FILES";

                    var reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        Button button = new Button();

                        button.Height = 100;
                        button.Width = 565;
                        button.Text = "FILENAME: "+ reader[0];
                        button.Text = button.Text + "\nDATE LAST CREATED: " + reader[2];
                        button.ForeColor = Color.GhostWhite;
                        button.Cursor = Cursors.Hand;
                        button.Click += buttonClick;

                        flowLayoutPanel.Controls.Add(button);
                    }
                }

                DatabaseConnection.connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            List<string> str = button.Text.Split('\n').ToList();

            Password passW = new Password(str[0].Replace("FILENAME: ", string.Empty));
            passW.ShowDialog();

            if (!passW.cancelled)
            {
                schedule = new Schedule(str[0].Replace("FILENAME: ", string.Empty));
                schedule.ShowDialog();
                
                this.Close();
            }
        }

        private void newFile_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                newDialog.ShowDialog();

                if (newDialog.cancelled)
                {
                    cancelled = true;

                    Data.Reset();
                }
                else
                {
                    Data.fileType = FileType.New;

                    unit.ShowDialog();

                    if (unit.closed)
                    {
                        cancelled = true;

                        Data.Reset();
                    }
                }

                if (cancelled)
                {
                    Data.Reset();
                }
                else
                {
                    this.Hide();

                    //inserting new file in the FILES table
                    DatabaseConnection.connection.Open();

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = DatabaseConnection.connection;
                    cmd.CommandText = "INSERT INTO FILES ([FILENAME], [PASSWORD], [DATE LAST MODIFIED], [UNIT]) values('" + Data.Filename + "', '" + Data.Password + "', '" + DateTime.Now.Date.ToString() + "', '"+ Data.unitType +"')";
                    cmd.ExecuteNonQuery();

                    DatabaseConnection.connection.Close();

                    //creating filename table
                    CreateTable(Data.Filename);

                    CreateMainTable(Data.Filename);
                    
                    schedule = new Schedule(Data.Filename, Data.unitType);

                    Data.Reset();

                    schedule.ShowDialog();

                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exit_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void CreateTable(string filename)
        {
            try
            {
                DatabaseConnection.connection.Open();

                string parameters = "[TABNAME] TEXT, " + 
                                    "[PHASE] TEXT, " + 
                                    "[BRANCH CIRCUIT] TEXT, " + 
                                    "[CIRCUIT NUMBER] TEXT, " +
                                    "[LO] TEXT, " +
                                    "[CO] TEXT, " +
                                    "[OTHER OUTLET] TEXT, " +
                                    "[S1] TEXT, " +
                                    "[S2] TEXT, " +
                                    "[S3] TEXT, " +
                                    "[S3W] TEXT, " +
                                    "[DESCRIPTION] TEXT, " +
                                    "[VA] TEXT, " + 
                                    "[AB] TEXT, " +
                                    "[BC] TEXT, " +
                                    "[CA] TEXT, " +
                                    "[THREE_P] TEXT, " +
                                    "[VOLTAGE] TEXT, " +
                                    "[AMPERE] TEXT, " +
                                    "[POLE] TEXT, " +
                                    "[AT] TEXT, " +
                                    "[AF] TEXT, " + 
                                    "[KAIC] TEXT, " +
                                    "[HOT WIRE] TEXT, " + 
                                    "[GROUNDING WIRE] TEXT, " +
                                    "[CONDUIT SIZE] TEXT";

                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = DatabaseConnection.connection;
                    cmd.CommandText = "CREATE TABLE [" + filename + "](" + parameters + ")";
                    cmd.ExecuteNonQuery();
                }

                DatabaseConnection.connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void CreateMainTable(string Filename)
        {
            try
            {
                DatabaseConnection.connection.Open();

                string parameters = "[CALCULATED] TEXT, " +
                                    "[LARGEST MOTOR] TEXT, " +
                                    "[BREAKER TYPE] TEXT, " +
                                    "[AREA] TEXT, " +
                                    "[UNIT] TEXT, " +
                                    "[LO] TEXT, " +
                                    "[CO] TEXT, " +
                                    "[RANGE] TEXT, " +
                                    "[DRYER] TEXT, " +
                                    "[ACU] TEXT, " +
                                    "[MOTOR] TEXT, " +
                                    "[OTHER LOAD] TEXT, " +
                                    "[SPARE] TEXT, " +
                                    "[MAIN SERVICE] TEXT, " +
                                    "[CONDUCTOR AMPACITY] TEXT, " +
                                    "[AT] TEXT, " +
                                    "[KAIC] TEXT, " +
                                    "[HOT WIRE] TEXT, " +
                                    "[GROUNDING WIRE] TEXT, " +
                                    "[CONDUIT SIZE] TEXT, " +
                                    "[TOTAL CONNECTED LOAD] TEXT, " +
                                    "[TOTAL NET LOAD] TEXT";

                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = DatabaseConnection.connection;
                    cmd.CommandText = "CREATE TABLE [" + Filename + "_MAIN" + "](" + parameters + ")";
                    cmd.ExecuteNonQuery();
                }

                DatabaseConnection.connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
