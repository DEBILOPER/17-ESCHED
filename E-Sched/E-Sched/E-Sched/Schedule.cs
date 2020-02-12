using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using DGVPrinterHelper;
using System.Drawing.Printing;

namespace E_Sched
{
    public partial class Schedule : Form
    {
        private PrintDocument doc;

        private List<PhaseType> phaseList = new List<PhaseType>();
        private List<VoltageValue> voltageValue = new List<VoltageValue>();

        private List<List<BranchCircuit>> branches = new List<List<BranchCircuit>>();
        private List<BranchCircuit> circuits;

        private List<string> tabNameList = new List<string>();
        private List<CalculateMain> mains = new List<CalculateMain>();

        private string Filename;

        private UnitType unitType;
        
        private PercentVoltageDrop voltageDrop;

        public ApplyBranch apply = new ApplyBranch();

        private Phase phase = new Phase();

        private BranchCircuits circuit = new BranchCircuits();

        private LightingsForm lightings   = new LightingsForm();
        private LightingsForm1 lightings1 = new LightingsForm1();

        private ConvenienceOutlet outlet = new ConvenienceOutlet();

        private RANGE range = new RANGE();

        private Dryer dryer = new Dryer();

        private AirCondition airCondition = new AirCondition();
        private NonDwellingACU acu = new NonDwellingACU();

        private MotorLoad motor = new MotorLoad();

        private Spare spare = new Spare();

        private OtherLoad load = new OtherLoad();

        private AddTab addTab = new AddTab();

        private DialogResult result;

        private Bunifu.Framework.UI.BunifuCustomDataGrid data;
        private Bunifu.Framework.UI.BunifuCustomDataGrid customDataGrid;

        private Font font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Pixel);

        public Schedule()
        {
            InitializeComponent();
        }

        public Schedule(string filename)
        {
            Filename = filename;

            InitializeComponent();

            LoadDatabase(Filename);
            LoadMain();

            // load unit type
            DatabaseConnection.connection.Open();

            using (OleDbCommand cmd = new OleDbCommand())
            {
                cmd.CommandText = "Select *from FILES where FILENAME = '" + filename + "'";
                cmd.Connection = DatabaseConnection.connection;

                var reader = cmd.ExecuteReader();

                string unit = string.Empty;
                while(reader.Read())
                {
                    unit = (string)reader[3];
                }

                if(unit == "DwellingUnit")
                {
                    unitType = UnitType.DwellingUnit;
                }
                else
                {
                    unitType = UnitType.NonDwellingUnit;
                }
            }

            DatabaseConnection.connection.Close();
        }

        public Schedule(string filename, UnitType unitType)
        {
            Filename = filename;
            this.unitType = unitType;

            InitializeComponent();
        }

        void LoadDatabase(string file)
        {
            try
            {
                // load tabnames
                DatabaseConnection.connection.Open();

                using (OleDbCommand command = new OleDbCommand())
                {
                    command.CommandText = "SELECT DISTINCT TABNAME from ["+ Filename + "]";
                    command.Connection = DatabaseConnection.connection;

                    var reader = command.ExecuteReader();

                    if(reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            tabControl1.TabPages.Add("tabpage" + tabControl1.TabCount.ToString(), reader[0].ToString());

                            CalculateMain main = new CalculateMain();
                            mains.Add(main);
                        }
                    }
                    else
                    {
                        DatabaseConnection.connection.Close();
                        return;
                    }
                }

                DatabaseConnection.connection.Close();


                // load phases
                int count = 0;
                foreach (TabPage page in tabControl1.TabPages)
                {
                    DatabaseConnection.connection.Open();

                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.CommandText = "SELECT DISTINCT [PHASE] from [" + Filename + "] where [TABNAME] = '"+ page.Text +"'";
                        cmd.Connection = DatabaseConnection.connection;

                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            string p = reader["PHASE"].ToString();
                            data = new Bunifu.Framework.UI.BunifuCustomDataGrid();

                            if (p == "SinglePhase")
                            {
                                voltageValue.Add(VoltageValue.SINGLEPHASE_VOLTAGE);
                                phaseList.Add(PhaseType.SinglePhase);

                                data.Columns.Add("Column1", "Circuit No.");
                                data.Columns.Add("Column2", "LO");
                                data.Columns.Add("Column3", "CO");
                                data.Columns.Add("Column4", "OTHER OUTLET");
                                data.Columns.Add("Column5", "S1");
                                data.Columns.Add("Column6", "S2");
                                data.Columns.Add("Column7", "S3");
                                data.Columns.Add("Column8", "S3W");
                                data.Columns.Add("Column9", "LOAD DESCRIPTION");
                                data.Columns.Add("Column10", "VA");
                                data.Columns.Add("Column11", "VOLTAGE");
                                data.Columns.Add("Column12", "AMPERE");
                                data.Columns.Add("Column13", "POLE");
                                data.Columns.Add("Column14", "AT");
                                data.Columns.Add("Column15", "AF");
                                data.Columns.Add("Column16", "KAIC");
                                data.Columns.Add("Column17", "HOT WIRE (SIZE)");
                                data.Columns.Add("Column18", "GROUNDING WIRE (SIZE)");
                                data.Columns.Add("Column19", "CONDUIT SIZE");

                                for (int i = 2; i < 5; i++)
                                {
                                    data.Columns["Column" + i.ToString()].ReadOnly = true;
                                }

                                for (int i = 9; i < 20; i++)
                                {
                                    data.Columns["Column" + i.ToString()].ReadOnly = true;
                                }
                            }
                            else if (p == "ThreePhase")
                            {
                                voltageValue.Add(VoltageValue.THREEPHASE_VOLTAGE);
                                phaseList.Add(PhaseType.ThreePhase);

                                data.Columns.Add("Column1", "Circuit No.");
                                data.Columns.Add("Column2", "LO");
                                data.Columns.Add("Column3", "CO");
                                data.Columns.Add("Column4", "OTHER OUTLET");
                                data.Columns.Add("Column5", "S1");
                                data.Columns.Add("Column6", "S2");
                                data.Columns.Add("Column7", "S3");
                                data.Columns.Add("Column8", "S3W");
                                data.Columns.Add("Column9", "LOAD DESCRIPTION");
                                data.Columns.Add("Column10", "AB");
                                data.Columns.Add("Column11", "BC");
                                data.Columns.Add("Column12", "CA");
                                data.Columns.Add("Column13", "3P");
                                data.Columns.Add("Column14", "VOLTAGE");
                                data.Columns.Add("Column15", "AMPERE");
                                data.Columns.Add("Column16", "POLE");
                                data.Columns.Add("Column17", "AT");
                                data.Columns.Add("Column18", "AF");
                                data.Columns.Add("Column19", "KAIC");
                                data.Columns.Add("Column20", "HOT WIRE (SIZE)");
                                data.Columns.Add("Column21", "GROUNDING WIRE (SIZE)");
                                data.Columns.Add("Column22", "CONDUIT SIZE");

                                for (int i = 2; i < 5; i++)
                                {
                                    data.Columns["Column" + i.ToString()].ReadOnly = true;
                                }

                                for (int i = 9; i < 20; i++)
                                {
                                    data.Columns["Column" + i.ToString()].ReadOnly = true;
                                }
                            }

                            foreach (DataGridViewColumn col in data.Columns)
                            {
                                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                col.HeaderCell.Style.Font = font;
                            }

                            data.HeaderForeColor = Color.Black;
                            data.Dock = DockStyle.Fill;

                            data.AllowUserToAddRows = false;
                            data.AllowUserToDeleteRows = false;
                            data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            data.ColumnHeadersHeight = 50;
                            data.BorderStyle = BorderStyle.FixedSingle;
                            data.BackgroundColor = this.BackColor;
                            data.GridColor = Color.Black;
                            data.ForeColor = Color.Black;

                            tabControl1.TabPages[count].Controls.Add(data);
                            count++;
                        }
                    }
                    
                    DatabaseConnection.connection.Close();
                }
                
                //load branch circuits in each tab
                int c = 0;
                foreach(TabPage page in tabControl1.TabPages)
                {
                    DatabaseConnection.connection.Open();
                
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.CommandText = "SELECT *from [" + Filename + "] where [TABNAME] = '" + page.Text + "'";
                        cmd.Connection = DatabaseConnection.connection;
                
                        var reader = cmd.ExecuteReader();
                        customDataGrid = (Bunifu.Framework.UI.BunifuCustomDataGrid)tabControl1.TabPages[c].Controls[0];
                
                        if (phaseList[c] == PhaseType.SinglePhase)
                        {
                            circuits = new List<BranchCircuit>();
                
                            while (reader.Read())
                            {
                                string circuit = reader["BRANCH CIRCUIT"].ToString();
                
                                if (circuit == "LIGHTINGS")
                                    circuits.Add(BranchCircuit.LIGHTINGS);
                                else if (circuit == "CONVENIENCE_OUTLET")
                                    circuits.Add(BranchCircuit.CONVENIENCE_OUTLET);
                                else if (circuit == "RANGE")
                                    circuits.Add(BranchCircuit.RANGE);
                                else if (circuit == "DRYER")
                                    circuits.Add(BranchCircuit.DRYER);
                                else if (circuit == "ACU")
                                    circuits.Add(BranchCircuit.ACU);
                                else if (circuit == "MOTOR")
                                    circuits.Add(BranchCircuit.MOTOR);
                                else if (circuit == "OTHER_LOAD")
                                    circuits.Add(BranchCircuit.OTHER_LOAD);
                                else if (circuit == "SPARE")
                                    circuits.Add(BranchCircuit.SPARE);
                
                                customDataGrid.Rows.Add(
                                    reader["CIRCUIT NUMBER"],
                                    reader["LO"],
                                    reader["CO"],
                                    reader["OTHER OUTLET"],
                                    reader["S1"],
                                    reader["S2"],
                                    reader["S3"],
                                    reader["S3W"],
                                    reader["DESCRIPTION"],
                                    reader["VA"],
                                    reader["VOLTAGE"],
                                    reader["AMPERE"],
                                    reader["POLE"],
                                    reader["AT"],
                                    reader["AF"],
                                    reader["KAIC"],
                                    reader["HOT WIRE"],
                                    reader["GROUNDING WIRE"],
                                    reader["CONDUIT SIZE"]
                                    );
                            }
                
                            branches.Add(circuits);
                        }
                        else if (phaseList[c] == PhaseType.ThreePhase)
                        {
                            circuits = new List<BranchCircuit>();
                
                            while (reader.Read())
                            {
                                string circuit = reader["BRANCH CIRCUIT"].ToString();
                
                                if (circuit == "LIGHTINGS")
                                    circuits.Add(BranchCircuit.LIGHTINGS);
                                else if (circuit == "CONVENIENCE_OUTLET")
                                    circuits.Add(BranchCircuit.CONVENIENCE_OUTLET);
                                else if (circuit == "RANGE")
                                    circuits.Add(BranchCircuit.RANGE);
                                else if (circuit == "DRYER")
                                    circuits.Add(BranchCircuit.DRYER);
                                else if (circuit == "ACU")
                                    circuits.Add(BranchCircuit.ACU);
                                else if (circuit == "MOTOR")
                                    circuits.Add(BranchCircuit.MOTOR);
                                else if (circuit == "OTHER_LOAD")
                                    circuits.Add(BranchCircuit.OTHER_LOAD);
                                else if (circuit == "SPARE")
                                    circuits.Add(BranchCircuit.SPARE);
                
                                customDataGrid.Rows.Add(
                                    reader["CIRCUIT NUMBER"],
                                    reader["LO"],
                                    reader["CO"],
                                    reader["OTHER OUTLET"],
                                    reader["S1"],
                                    reader["S2"],
                                    reader["S3"],
                                    reader["S3W"],
                                    reader["DESCRIPTION"],
                                    reader["AB"],
                                    reader["BC"],
                                    reader["CA"],
                                    reader["THREE_P"],
                                    reader["VOLTAGE"],
                                    reader["AMPERE"],
                                    reader["POLE"],
                                    reader["AT"],
                                    reader["AF"],
                                    reader["KAIC"],
                                    reader["HOT WIRE"],
                                    reader["GROUNDING WIRE"],
                                    reader["CONDUIT SIZE"]
                                    );
                            }
                
                            branches.Add(circuits);
                        }
                    }
                
                    c++;
                    DatabaseConnection.connection.Close();
                }
            }
            catch(Exception ex)
            {
                result = MessageBox.Show(ex.ToString(), "DATABASE ERROR 1", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if(result == DialogResult.OK)
                {
                    DatabaseConnection.connection.Close();
                    this.Close();
                }
                
                DatabaseConnection.connection.Close();
            }
        }
        
        void LoadMain()
        {
            try
            {
                DatabaseConnection.connection.Open();

                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "SELECT *from [" + Filename + "_MAIN]";
                cmd.Connection = DatabaseConnection.connection;

                var reader = cmd.ExecuteReader();

                int index = 0;
                while(reader.Read())
                {
                    mains[index].calculated = (reader[0].ToString() == "True") ? true : false;
                    mains[index].largestMotor = Convert.ToDouble(reader[1].ToString());
                    mains[index].breakerType = (reader[2].ToString() == "SYNCHRONOUS") ? BreakerType.SYNCHRONOUS : (reader[2].ToString() == "INSTANTANEOUS_TRIP") ? BreakerType.INSTANTANEOUS_TRIP : (reader[2].ToString() == "WOUND") ? BreakerType.WOUND : BreakerType.NONE;
                    mains[index].area = reader[3].ToString();
                    mains[index].unitType = (reader[4].ToString() == "DwellingUnit") ? UnitType.DwellingUnit : UnitType.NonDwellingUnit;
                    mains[index].LO = Convert.ToDouble(reader[5].ToString());
                    mains[index].CO = Convert.ToDouble(reader[6].ToString());
                    mains[index].RANGE = Convert.ToDouble(reader[7].ToString());
                    mains[index].DRYER = Convert.ToDouble(reader[8].ToString());
                    mains[index].ACU = Convert.ToDouble(reader[9].ToString());
                    mains[index].MOTOR = Convert.ToDouble(reader[10].ToString());
                    mains[index].OTHER_LOAD = Convert.ToDouble(reader[11].ToString());
                    mains[index].SPARE = Convert.ToDouble(reader[12].ToString());
                    mains[index].mainService = Convert.ToDouble(reader[13].ToString());
                    mains[index].conductorAmpacity = Convert.ToDouble(reader[14].ToString());
                    mains[index].AT = reader[15].ToString();
                    mains[index].KAIC = Convert.ToDouble(reader[16].ToString());
                    mains[index].conductorSize = reader[17].ToString();
                    mains[index].breakerSize = reader[18].ToString();
                    mains[index].conduitSize = reader[19].ToString();
                    mains[index].total_connected_load = Convert.ToDouble(reader[20].ToString());
                    mains[index].total_net_load = Convert.ToDouble(reader[21].ToString());

                    index++;
                }

                DatabaseConnection.connection.Close();

                CalculateMain m = mains[0];

                if (m.calculated == false)
                    return;

                if (m.unitType == UnitType.None || m.unitType == UnitType.NonDwellingUnit)
                {
                    dwellingShowMainL1.BringToFront();

                    dwellingShowMainL1.Initialize(m.total_connected_load, m.LO, m.CO, m.RANGE, m.DRYER, m.ACU, m.MOTOR, m.OTHER_LOAD, m.SPARE, m.total_net_load, m.mainService, m.conductorAmpacity, m.conductorSize, m.breakerSize, Convert.ToInt32(m.AT), m.breakerType, phaseList[tabControl1.SelectedIndex], Convert.ToInt32(voltageValue[tabControl1.SelectedIndex]));
                }
                else if (m.unitType == UnitType.DwellingUnit)
                {
                    dwellingShowMain1.BringToFront();

                    dwellingShowMain1.Initialize(m.total_connected_load, m.LO + m.CO, m.RANGE, m.DRYER, m.ACU, m.MOTOR, m.OTHER_LOAD, m.SPARE, m.total_net_load, m.mainService, m.conductorAmpacity, m.conductorSize, m.breakerSize, Convert.ToInt32(m.AT), m.breakerType, phaseList[tabControl1.SelectedIndex], Convert.ToInt32(voltageValue[tabControl1.SelectedIndex]));
                }

                for (int i = 0; i < tabControl1.TabCount; i++)
                {
                    if (mains[i].calculated == false)
                        return;

                    var grid = (Bunifu.Framework.UI.BunifuCustomDataGrid)tabControl1.TabPages[i].Controls[0];

                    List<double> total = new List<double>(12)
                        {
                            0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d
                        };

                    foreach (DataGridViewRow row in grid.Rows)
                    {
                        if (row.Cells[0].Value.ToString() == "TOTAL")
                            continue;

                        if (row.Cells[1].Value.ToString() != string.Empty)
                            total[0] = total[0] + Convert.ToDouble(row.Cells[1].Value);

                        if (row.Cells[2].Value.ToString() != string.Empty)
                            total[1] = total[1] + Convert.ToDouble(row.Cells[2].Value);

                        if (row.Cells[3].Value.ToString() != string.Empty)
                            total[2] = total[2] + Convert.ToDouble(row.Cells[3].Value);

                        if (row.Cells[4].Value.ToString() != string.Empty)
                            total[3] = total[3] + Convert.ToDouble(row.Cells[4].Value);

                        if (row.Cells[5].Value.ToString() != string.Empty)
                            total[4] = total[4] + Convert.ToDouble(row.Cells[5].Value);

                        if (row.Cells[6].Value.ToString() != string.Empty)
                            total[5] = total[5] + Convert.ToDouble(row.Cells[6].Value);

                        if (row.Cells[7].Value.ToString() != string.Empty)
                            total[6] = total[6] + Convert.ToDouble(row.Cells[7].Value);

                        if (row.Cells[9].Value.ToString() != string.Empty)
                            total[7] = total[7] + Convert.ToDouble(row.Cells[9].Value.ToString());

                        if (phaseList[i] == PhaseType.ThreePhase)
                        {
                            if (row.Cells[10].Value.ToString() != string.Empty)
                                total[8] = total[8] + Convert.ToDouble(row.Cells[10].Value.ToString());

                            if (row.Cells[11].Value.ToString() != string.Empty)
                                total[9] = total[9] + Convert.ToDouble(row.Cells[11].Value.ToString());

                            if (row.Cells[12].Value.ToString() != string.Empty)
                                total[10] = total[10] + Convert.ToDouble(row.Cells[12].Value.ToString());
                        }
                    }

                    string pole = (phaseList[tabControl1.SelectedIndex] == PhaseType.SinglePhase) ? "2" : "3";

                    if (grid.Rows[grid.Rows.Count - 1].Cells[0].Value.ToString() == "TOTAL")
                        grid.Rows.RemoveAt(grid.Rows.Count - 1);

                    if (phaseList[i] == PhaseType.SinglePhase)
                        grid.Rows.Add("TOTAL", total[0], total[1], total[2], total[3], total[4], total[5], total[6], string.Empty, total[7], Convert.ToInt16(voltageValue[tabControl1.SelectedIndex]), (m.total_connected_load / Convert.ToDouble(voltageValue[tabControl1.SelectedIndex])), pole, m.AT, AF(Convert.ToInt32(m.AT)), string.Empty, m.conductorSize, m.breakerSize, m.conduitSize);
                    else if (phaseList[i] == PhaseType.ThreePhase)
                        grid.Rows.Add("TOTAL", total[0], total[1], total[2], total[3], total[4], total[5], total[6], string.Empty, total[7], total[8], total[9], total[10], Convert.ToInt16(voltageValue[tabControl1.SelectedIndex]), (m.total_connected_load / Convert.ToDouble(voltageValue[tabControl1.SelectedIndex])), pole, m.AT, AF(Convert.ToInt32(m.AT)), string.Empty, m.conductorSize, m.breakerSize, m.conduitSize);
                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DatabaseConnection.connection.Close();
            }
        }

        private void exit_Btn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("DO YOU WANT TO SAVE YOUR WORK BEFORE LEAVING?", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(result == DialogResult.No)
            {
                this.Close();
            }
            else
            {
                SaveDatabase();
                SaveMain();
                this.Close();
            }
        }

        private void Schedule_Load(object sender, EventArgs e)
        {
            branchTooltip.SetToolTip(addBranchCircuit_Btn, "ADDS A BRANCH CIRCUIT IN THE CURRENT TAB.");
            addTooltip.SetToolTip(addTab_btn, "ADDS A NEW TAB.");
            printTooltip.SetToolTip(printTable, "PRINTS THE TABLE OF THE CURRENT TAB YOU ARE IN.");
            mainTooltip.SetToolTip(calculateMain, "CALCULATES THE MAIN OF THE CURRENT TAB YOU ARE IN.");
            mainSingleTooltip.SetToolTip(mainSingleLine, "GENERATES A SINGLE LINE DIAGRAM FOR THE CURRENT TAB");
            deleteRowTooltip.SetToolTip(delRow, "DELETES THE SELECTED ROW");
        }

        // add branch circuit
        private void addBranchCircuit_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.TabCount == 0)
                {
                    MessageBox.Show("There is currently no tab in the scheduler.", "ERROR: No Tab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    circuit.ShowDialog();

                    if (circuit.close)
                        return;

                    if (circuit.lighting)
                    {
                        result = MessageBox.Show("DO YOU WANT TO CALCULATE ACTUAL LOADING?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            lightings.ShowDialog();

                            if (lightings.close)
                                return;
                            
                            if (tabControl1.TabCount != 0)
                            {
                                if (phaseList[tabControl1.SelectedIndex] == PhaseType.SinglePhase)
                                {
                                    apply.ShowDialog();

                                    if (!apply.closed && !apply.cancel)
                                    {
                                        float vA = lightings.VA;
                                        Single("LO", lightings.LO, string.Empty, string.Empty, lightings.description, vA.ToString());

                                        circuits = branches[tabControl1.SelectedIndex];
                                        circuits.Add(BranchCircuit.LIGHTINGS);
                                    }
                                }
                                else
                                {
                                    // three phase
                                    apply.ShowDialog();

                                    if (!apply.closed && !apply.cancel)
                                    {
                                        float vA = lightings.VA;
                                        Three("LO", lightings.LO, string.Empty, string.Empty, lightings.description, vA.ToString());

                                        circuits = branches[tabControl1.SelectedIndex];
                                        circuits.Add(BranchCircuit.LIGHTINGS);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("There is currently no tab in the scheduler.", "ERROR: No Tab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else if (result == DialogResult.No)
                        {
                            lightings1.ShowDialog();

                            if (lightings1.close)
                                return;

                            if (tabControl1.TabCount != 0)
                            {
                                if (phaseList[tabControl1.SelectedIndex] == PhaseType.SinglePhase)
                                {
                                    apply.ShowDialog();

                                    if (!apply.closed && !apply.cancel)
                                    {
                                        Single("LO", lightings1.lightingOutlet, string.Empty, string.Empty, lightings1.Description, lightings1.voltageAmp);

                                        circuits = branches[tabControl1.SelectedIndex];
                                        circuits.Add(BranchCircuit.LIGHTINGS);
                                    }
                                }
                                else
                                {
                                    // three phase
                                    apply.ShowDialog();

                                    if (!apply.closed && !apply.cancel)
                                    {
                                        Three("LO", lightings1.lightingOutlet, string.Empty, string.Empty, lightings1.Description, lightings1.voltageAmp);

                                        circuits = branches[tabControl1.SelectedIndex];
                                        circuits.Add(BranchCircuit.LIGHTINGS);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("There is currently no tab in the scheduler.", "ERROR: No Tab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else if (circuit.outlet)
                    {
                        outlet.ShowDialog();

                        if (outlet.close)
                            return;

                        if (tabControl1.TabCount != 0)
                        {
                            if (phaseList[tabControl1.SelectedIndex] == PhaseType.SinglePhase)
                            {
                                apply.ShowDialog();

                                if (!apply.closed && !apply.cancel)
                                {
                                    Single(string.Empty, string.Empty, outlet.convenienceOutlet, string.Empty, outlet.description, outlet.voltAmpere);

                                    circuits = branches[tabControl1.SelectedIndex];
                                    circuits.Add(BranchCircuit.CONVENIENCE_OUTLET);
                                }
                            }
                            else
                            {
                                // three phase
                                apply.ShowDialog();

                                if (!apply.closed && !apply.cancel)
                                {
                                    Three(string.Empty, string.Empty, outlet.convenienceOutlet, string.Empty, outlet.description, outlet.voltAmpere);

                                    circuits = branches[tabControl1.SelectedIndex];
                                    circuits.Add(BranchCircuit.CONVENIENCE_OUTLET);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("There is currently no tab in the scheduler.", "ERROR: No Tab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (circuit.dryer)
                    {
                        dryer.ShowDialog();

                        if (dryer.close)
                            return;

                        if (tabControl1.TabCount != 0)
                        {
                            if (phaseList[tabControl1.SelectedIndex] == PhaseType.SinglePhase)
                            {
                                apply.ShowDialog();

                                if (!apply.closed && !apply.cancel)
                                {
                                    Single(string.Empty, string.Empty, string.Empty, "1", dryer.description, dryer.VoltageAmp);

                                    circuits = branches[tabControl1.SelectedIndex];
                                    circuits.Add(BranchCircuit.DRYER);
                                }
                            }
                            else
                            {
                                // three phase
                                apply.ShowDialog();

                                if (!apply.closed && !apply.cancel)
                                {
                                    Three(string.Empty, string.Empty, string.Empty, "1", outlet.description, dryer.VoltageAmp);

                                    circuits = branches[tabControl1.SelectedIndex];
                                    circuits.Add(BranchCircuit.DRYER);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("There is currently no tab in the scheduler.", "ERROR: No Tab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (circuit.range)
                    {
                        range.ShowDialog();

                        if (range.close)
                            return;

                        if (tabControl1.TabCount != 0)
                        {
                            if (phaseList[tabControl1.SelectedIndex] == PhaseType.SinglePhase)
                            {
                                apply.ShowDialog();

                                if (!apply.closed && !apply.cancel)
                                {
                                    Single(string.Empty, string.Empty, string.Empty, "1", range.description, range.VoltageAmp);

                                    circuits = branches[tabControl1.SelectedIndex];
                                    circuits.Add(BranchCircuit.RANGE);
                                }
                            }
                            else
                            {
                                // three phase
                                apply.ShowDialog();

                                if (!apply.closed && !apply.cancel)
                                {
                                    Three(string.Empty, string.Empty, string.Empty, "1", range.description, range.VoltageAmp);

                                    circuits = branches[tabControl1.SelectedIndex];
                                    circuits.Add(BranchCircuit.RANGE);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("There is currently no tab in the scheduler.", "ERROR: No Tab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (circuit.aircondition)
                    {
                        // editon pani
                        if (unitType == UnitType.DwellingUnit)
                        {
                            airCondition.phase = phaseList[tabControl1.SelectedIndex];
                            airCondition.ShowDialog();
                            
                            if (!airCondition.cancel)
                            {

                                apply.ShowDialog();

                                if (apply.cancel)
                                    return;

                                // single
                                if (phaseList[tabControl1.SelectedIndex] == PhaseType.SinglePhase)
                                {
                                    SingleACU(string.Empty, string.Empty, string.Empty, "1", airCondition.description, airCondition.voltAmpere, airCondition.ampere);

                                    circuits = branches[tabControl1.SelectedIndex];
                                    circuits.Add(BranchCircuit.ACU);
                                }
                                else if(phaseList[tabControl1.SelectedIndex] == PhaseType.ThreePhase)
                                {
                                    ThreeMotor(string.Empty, string.Empty, string.Empty, "1", airCondition.description, airCondition.voltAmpere, airCondition.ampere);

                                    circuits = branches[tabControl1.SelectedIndex];
                                    circuits.Add(BranchCircuit.ACU);
                                }
                            }
                        }
                        else if (unitType == UnitType.NonDwellingUnit)
                        {
                            acu.phase = phaseList[tabControl1.SelectedIndex];
                            acu.ShowDialog();

                            if(!acu.cancel)
                            {
                                apply.ShowDialog();

                                if (apply.cancel)
                                    return;

                                if (phaseList[tabControl1.SelectedIndex] == PhaseType.SinglePhase)
                                {
                                    SingleACU(string.Empty, string.Empty, string.Empty, "1", acu.description, acu.voltAmpere, acu.ampere);

                                    circuits = branches[tabControl1.SelectedIndex];
                                    circuits.Add(BranchCircuit.ACU);
                                }
                                // three
                                else
                                {
                                    if(acu.volt == VoltageValue.SINGLEPHASE_VOLTAGE)
                                        ThreeMotor(string.Empty, string.Empty, "1", string.Empty, acu.description, acu.voltAmpere, acu.ampere);
                                    else if(acu.volt == VoltageValue.THREEPHASE_VOLTAGE)
                                        MotorThree(string.Empty, string.Empty, "1", string.Empty, acu.description, acu.voltAmpere, acu.ampere);

                                    circuits = branches[tabControl1.SelectedIndex];
                                    circuits.Add(BranchCircuit.ACU);
                                }
                            }
                        }
                    }
                    else if (circuit.motor)
                    {
                        if(tabControl1.TabCount != 0)
                        {
                            motor.phase = phaseList[tabControl1.SelectedIndex];
                            motor.ShowDialog();

                            if (phaseList[tabControl1.SelectedIndex] == PhaseType.SinglePhase)
                            {
                                apply.ShowDialog();

                                if (!motor.cancel)
                                {
                                    if (apply.closed)
                                        return;
                                    
                                    Single(string.Empty, string.Empty, string.Empty, "1", motor.description, motor.voltAmpere);

                                    circuits = branches[tabControl1.SelectedIndex];
                                    circuits.Add(BranchCircuit.MOTOR);
                                }
                            }
                            else
                            {
                                apply.ShowDialog();

                                // three phase
                                if (!motor.cancel)
                                {
                                    if (apply.closed)
                                        return;

                                    if (motor.volt == VoltageValue.SINGLEPHASE_VOLTAGE)
                                        ThreeMotor(string.Empty, string.Empty, string.Empty, "1", motor.description, motor.voltAmpere, motor.ampere);
                                    else if(motor.volt == VoltageValue.THREEPHASE_VOLTAGE)
                                        MotorThree(string.Empty, string.Empty, string.Empty, "1", motor.description, motor.voltAmpere, motor.ampere);

                                    circuits = branches[tabControl1.SelectedIndex];
                                    circuits.Add(BranchCircuit.MOTOR);
                                }
                            }
                        }
                    }
                    else if (circuit.Spare)
                    {
                        spare.ShowDialog();

                        if (spare.close)
                            return;

                        if (tabControl1.TabCount != 0)
                        {
                            if (phaseList[tabControl1.SelectedIndex] == PhaseType.SinglePhase)
                            {
                                SingleSpare("SPARE", spare.VoltageAmpere);

                                circuits = branches[tabControl1.SelectedIndex];
                                circuits.Add(BranchCircuit.SPARE);
                            }
                            else
                            {
                                // three phase
                                ThreeSpare("SPARE", spare.VoltageAmpere);

                                circuits = branches[tabControl1.SelectedIndex];
                                circuits.Add(BranchCircuit.SPARE);
                            }
                        }
                        else
                        {
                            MessageBox.Show("There is currently no tab in the scheduler.", "ERROR: No Tab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (circuit.load)
                    {
                        load.ShowDialog();

                        if (load.close)
                            return;

                        if (tabControl1.TabCount != 0)
                        {
                            if (phaseList[tabControl1.SelectedIndex] == PhaseType.SinglePhase)
                            {
                                apply.ShowDialog();

                                if (!apply.closed && !apply.cancel)
                                {
                                    Single(string.Empty, string.Empty, string.Empty, "1", load.Description, load.VoltAmp);

                                    circuits = branches[tabControl1.SelectedIndex];
                                    circuits.Add(BranchCircuit.OTHER_LOAD);
                                }
                            }
                            else
                            {
                                // three phase
                                apply.ShowDialog();

                                if (!apply.closed && !apply.cancel)
                                {
                                    Three(string.Empty, string.Empty, string.Empty, "1", load.Description, load.VoltAmp);

                                    circuits = branches[tabControl1.SelectedIndex];
                                    circuits.Add(BranchCircuit.OTHER_LOAD);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("There is currently no tab in the scheduler.", "ERROR: No Tab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                var dataGrid = (Bunifu.Framework.UI.BunifuCustomDataGrid)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];

                if (dataGrid.Rows.Count == 1)
                    return;

                if (dataGrid.Rows[dataGrid.Rows.Count - 2].Cells[0].Value.ToString() == "TOTAL")
                    dataGrid.Rows.RemoveAt(dataGrid.Rows.Count - 2);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // ADD TAB
        private void addTab_btn_Click(object sender, EventArgs e)
        {
            phase.ShowDialog();

            if (!phase.cancelled && !phase.closed)
            {
                addTab.ShowDialog();

                if (!addTab.closed)
                {
                    bool found = false;
                    foreach (TabPage tabPage in tabControl1.TabPages)
                    {
                        if (tabPage.Text == addTab.tabName)
                        {
                            found = true;
                        }
                    }

                    if (!found)
                    {
                        phaseList.Add(phase.phaseType);
                        
                        if (phase.phaseType == PhaseType.SinglePhase)
                        {
                            voltageValue.Add(VoltageValue.SINGLEPHASE_VOLTAGE);
                        }
                        else
                        {
                            voltageValue.Add(VoltageValue.THREEPHASE_VOLTAGE);
                        }

                        data = new Bunifu.Framework.UI.BunifuCustomDataGrid();

                        if(phase.phaseType == PhaseType.SinglePhase)
                        {
                            data.Columns.Add("Column1", "Circuit No.");
                            data.Columns.Add("Column2", "LO");
                            data.Columns.Add("Column3", "CO");
                            data.Columns.Add("Column4", "OTHER OUTLET");
                            data.Columns.Add("Column5", "S1");
                            data.Columns.Add("Column6", "S2");
                            data.Columns.Add("Column7", "S3");
                            data.Columns.Add("Column8", "S3W");
                            data.Columns.Add("Column9", "LOAD DESCRIPTION");
                            data.Columns.Add("Column10", "VA");
                            data.Columns.Add("Column11", "VOLTAGE");
                            data.Columns.Add("Column12", "AMPERE");
                            data.Columns.Add("Column13", "POLE");
                            data.Columns.Add("Column14", "AT");
                            data.Columns.Add("Column15", "AF");
                            data.Columns.Add("Column16", "KAIC");
                            data.Columns.Add("Column17", "HOT WIRE (SIZE)");
                            data.Columns.Add("Column18", "GROUNDING WIRE (SIZE)");
                            data.Columns.Add("Column19", "CONDUIT SIZE");

                            for (int i = 2; i < 5; i++)
                            {
                                data.Columns["Column" + i.ToString()].ReadOnly = true;
                            }

                            for (int i = 9; i < 20; i++)
                            {
                                data.Columns["Column" + i.ToString()].ReadOnly = true;
                            }
                        }
                        else
                        {
                            data.Columns.Add("Column1", "Circuit No.");
                            data.Columns.Add("Column2", "LO");
                            data.Columns.Add("Column3", "CO");
                            data.Columns.Add("Column4", "OTHER OUTLET");
                            data.Columns.Add("Column5", "S1");
                            data.Columns.Add("Column6", "S2");
                            data.Columns.Add("Column7", "S3");
                            data.Columns.Add("Column8", "S3W");
                            data.Columns.Add("Column9", "LOAD DESCRIPTION");
                            data.Columns.Add("Column10", "AB");
                            data.Columns.Add("Column11", "BC");
                            data.Columns.Add("Column12", "CA");
                            data.Columns.Add("Column13", "3P");
                            data.Columns.Add("Column14", "VOLTAGE");
                            data.Columns.Add("Column15", "AMPERE");
                            data.Columns.Add("Column16", "POLE");
                            data.Columns.Add("Column17", "AT");
                            data.Columns.Add("Column18", "AF");
                            data.Columns.Add("Column19", "KAIC");
                            data.Columns.Add("Column20", "HOT WIRE (SIZE)");
                            data.Columns.Add("Column21", "GROUNDING WIRE (SIZE)");
                            data.Columns.Add("Column22", "CONDUIT SIZE");

                            for(int i=2; i<5; i++)
                            {
                                data.Columns["Column" + i.ToString()].ReadOnly = true;
                            }

                            for (int i = 9; i < 20; i++)
                            {
                                data.Columns["Column" + i.ToString()].ReadOnly = true;
                            }
                        }

                        foreach (DataGridViewColumn col in data.Columns)
                        {
                            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            col.HeaderCell.Style.Font = font;
                        }

                        data.HeaderForeColor = Color.Black;
                        data.Dock = DockStyle.Fill;

                        data.AllowUserToAddRows = false;
                        data.AllowUserToDeleteRows = false;
                        data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        data.ColumnHeadersHeight = 50;
                        data.BorderStyle = BorderStyle.FixedSingle;
                        data.BackgroundColor = this.BackColor;
                        data.GridColor = Color.Black;
                        data.ForeColor = Color.Black;

                        tabControl1.TabPages.Add("tabpage" + tabControl1.TabCount.ToString(), addTab.tabName);
                        tabControl1.TabPages[tabControl1.TabCount - 1].Controls.Add(data);

                        circuits = new List<BranchCircuit>();
                        branches.Add(circuits);

                        CalculateMain main = new CalculateMain();
                        mains.Add(main);

                        dwellingShowMain1.Initialize();
                        dwellingShowMainL1.Initialize();

                        tabControl1.SelectedIndex = tabControl1.TabCount - 1;
                    }
                    else
                    {
                        MessageBox.Show("TABNAME ALREADY EXIST!", "ERROR TABNAME!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            phase.phaseType = PhaseType.None;
            addTab.canceled = false;
        }

        private void SingleSpare(string Description, string VA)
        {
            float va = Convert.ToSingle(VA);
            float ampere = va / 230;
            
            customDataGrid = (Bunifu.Framework.UI.BunifuCustomDataGrid)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
            customDataGrid.Rows.Add((customDataGrid.Rows.Count + 1).ToString());

            customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[1].Value = string.Empty;
            customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[2].Value = string.Empty;
            customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[3].Value = string.Empty;

            customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[4].Value = string.Empty;
            customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[5].Value = string.Empty;
            customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[6].Value = string.Empty;
            customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[7].Value = string.Empty;

            customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[8].Value = Description;
            customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[9].Value = VA;

            // editon pa ang voltage value
            customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[10].Value = Convert.ToInt32(voltageValue[tabControl1.SelectedIndex]);
            customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[11].Value = ampere;

            customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[12].Value = 2;

            // AT
            int AT = ampereTrip("LO", ampere);
            customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[13].Value = AT;

            // AF
            customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[14].Value = AF(AT);

            //KAIC
            customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[15].Value = 10;

            //HOT WIRE
            customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[16].Value = string.Empty;

            //GROUNDING WIRE
            customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[17].Value = string.Empty;

            //CONDUIT SIZE
            customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[18].Value = string.Empty;
        }

        private void ThreeSpare(string Description, string VA)
        {
            float va = Convert.ToSingle(VA);
            float ampere = va / 230;

            customDataGrid = (Bunifu.Framework.UI.BunifuCustomDataGrid)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
            customDataGrid.Rows.Add((customDataGrid.Rows.Count + 1).ToString());

            customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[1].Value = string.Empty;
            customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[2].Value = string.Empty;
            customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[3].Value = string.Empty;

            customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[4].Value = string.Empty;
            customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[5].Value = string.Empty;
            customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[6].Value = string.Empty;
            customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[7].Value = string.Empty;

            customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[8].Value = Description;

            string ABBCCA = string.Empty;

            for (int i = customDataGrid.Rows.Count - 2; i >= 0; i--)
            {
                if (customDataGrid.Rows[i].Cells[9].Value.ToString() == string.Empty && customDataGrid.Rows[i].Cells[10].Value.ToString() == string.Empty && customDataGrid.Rows[i].Cells[11].Value.ToString() == string.Empty)
                    continue;

                if (customDataGrid.Rows[i].Cells[9].Value.ToString() != string.Empty)
                {
                    ABBCCA = "AB";
                    break;
                }
                else if (customDataGrid.Rows[i].Cells[10].Value.ToString() != string.Empty)
                {
                    ABBCCA = "BC";
                    break;
                }
                else if (customDataGrid.Rows[i].Cells[11].Value.ToString() != string.Empty)
                {
                    ABBCCA = "CA";
                    break;
                }
            }

            if (ABBCCA == string.Empty)
            {
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[9].Value = VA;
                ABBCCA = "AB";

                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[10].Value = string.Empty;
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[11].Value = string.Empty;
            }
            else if (ABBCCA == "AB")
            {
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[10].Value = VA;
                ABBCCA = "BC";

                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[9].Value = string.Empty;
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[11].Value = string.Empty;
            }
            else if (ABBCCA == "BC")
            {
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[11].Value = VA;
                ABBCCA = "CA";

                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[9].Value = string.Empty;
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[10].Value = string.Empty;
            }
            else if (ABBCCA == "CA")
            {
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[9].Value = VA;
                ABBCCA = "AB";

                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[10].Value = string.Empty;
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[11].Value = string.Empty;
            }

            customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[12].Value = string.Empty;
            customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[13].Value = 230;
            customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[14].Value = ampere;

            customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[15].Value = 2;

            // AT
            int AT = ampereTrip("LO", ampere);
            customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[16].Value = AT;

            // AF
            customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[17].Value = AF(AT);

            //KAIC
            customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[18].Value = 10;

            //HOT WIRE
            customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[19].Value = string.Empty;

            //GROUNDING WIRE
            customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[20].Value = string.Empty;

            //CONDUIT SIZE
            customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[21].Value = string.Empty;
        }

        private void Single(string type, string LO, string CO, string OtherOutlet, string Description, string VA)
        {
            float va = Convert.ToSingle(VA);
            float ampere = va / Convert.ToSingle(voltageValue[tabControl1.SelectedIndex]);
        
            // ampacity
            float ampacity = ampere * 1.25f * apply.correctionFactor * apply.derating;
            
            // hot wire calculation
            string hotWireSize = string.Empty;
            if (apply.wireType == WireType.TW)
            {
                hotWireSize = TW(type, ampacity);
            }
            else if (apply.wireType == WireType.THW)
            {
                hotWireSize = THW(type, ampacity);
            }
            else
            {
                hotWireSize = THHN(type, ampacity);
            }

            voltageDrop = new PercentVoltageDrop(PhaseType.SinglePhase);
            
            voltageDrop.ampere = ampere;
            voltageDrop.wireType = apply.wireType;
            voltageDrop.wireSize = hotWireSize;
            voltageDrop.conduitType = apply.conduitType;

            // editon pa ag voltage value
            voltageDrop.voltage = Convert.ToInt32(voltageValue[tabControl1.SelectedIndex]);

            do
            {
                voltageDrop.ShowDialog();
            }
            while (!voltageDrop.close);

            hotWireSize = voltageDrop.wireSize;

            if (!voltageDrop.cancel)
            {
                customDataGrid = (Bunifu.Framework.UI.BunifuCustomDataGrid)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
                customDataGrid.Rows.Add((customDataGrid.Rows.Count + 1).ToString());

                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[1].Value = LO;
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[2].Value = CO;
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[3].Value = OtherOutlet;

                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[4].Value = string.Empty;
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[5].Value = string.Empty;
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[6].Value = string.Empty;
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[7].Value = string.Empty;

                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[8].Value = Description;
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[9].Value = VA;

                // editon pa ang voltage value
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[10].Value = Convert.ToInt32(voltageValue[tabControl1.SelectedIndex]);
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[11].Value = ampere;

                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[12].Value = 2;

                // AT
                int AT = (type == "LO") ? ampereTrip("LO", ampacity) : ampereTrip(string.Empty, ampacity);
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[13].Value = AT;

                // AF
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[14].Value = AF(AT);

                //KAIC
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[15].Value = 10;

                //HOT WIRE

                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[16].Value = 2.ToString() + "-" + hotWireSize + "-" + apply.wireType;

                //GROUNDING WIRE
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[17].Value = 1 + "-" + groundingSize(AT) + "-" + apply.wireType;

                //CONDUIT SIZE
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[18].Value = voltageDrop.ConduitSize;
            }
        }

        private void Three(string type, string LO, string CO, string OtherOutlet, string Description, string VA)
        {
            float va = Convert.ToSingle(VA);
            float ampere = va / 230;

            // ampacity
            float ampacity = ampere * 1.25f * apply.correctionFactor * apply.derating;

            string hotWireSize = string.Empty;
            if (apply.wireType == WireType.TW)
            {
                hotWireSize = TW(type, ampacity);
            }
            else if (apply.wireType == WireType.THW)
            {
                hotWireSize = THW(type, ampacity);
            }
            else
            {
                hotWireSize = THHN(type, ampacity);
            }

            voltageDrop = new PercentVoltageDrop(PhaseType.ThreePhase);

            voltageDrop.ampere = ampere;
            voltageDrop.wireType = apply.wireType;
            voltageDrop.wireSize = hotWireSize;
            voltageDrop.conduitType = apply.conduitType;

            // editon pa ag voltage value
            voltageDrop.voltage = Convert.ToInt32(voltageValue[tabControl1.SelectedIndex]);

            do
            {
                voltageDrop.ShowDialog();
            }
            while (!voltageDrop.close);

            hotWireSize = voltageDrop.wireSize;

            if (!voltageDrop.cancel)
            {
                customDataGrid = (Bunifu.Framework.UI.BunifuCustomDataGrid)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
                customDataGrid.Rows.Add((customDataGrid.Rows.Count + 1).ToString());

                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[1].Value = LO;
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[2].Value = CO;
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[3].Value = OtherOutlet;

                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[4].Value = string.Empty;
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[5].Value = string.Empty;
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[6].Value = string.Empty;
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[7].Value = string.Empty;

                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[8].Value = Description;
                
                string ABBCCA = string.Empty;

                for (int i = customDataGrid.Rows.Count - 2; i >= 0; i--)
                {
                    if (customDataGrid.Rows[i].Cells[9].Value.ToString() == string.Empty && customDataGrid.Rows[i].Cells[10].Value.ToString() == string.Empty && customDataGrid.Rows[i].Cells[11].Value.ToString() == string.Empty)
                        continue;

                    if (customDataGrid.Rows[i].Cells[9].Value.ToString() != string.Empty)
                    {
                        ABBCCA = "AB";
                        break;
                    }
                    else if (customDataGrid.Rows[i].Cells[10].Value.ToString() != string.Empty)
                    {
                        ABBCCA = "BC";
                        break;
                    }
                    else if (customDataGrid.Rows[i].Cells[11].Value.ToString() != string.Empty)
                    {
                        ABBCCA = "CA";
                        break;
                    }
                }
                
                if (ABBCCA == string.Empty)
                {
                    customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[9].Value = VA;
                    ABBCCA = "AB";
                    
                    customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[10].Value = string.Empty;
                    customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[11].Value = string.Empty;
                }
                else if (ABBCCA == "AB")
                {
                    customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[10].Value = VA;
                    ABBCCA = "BC";

                    customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[9].Value = string.Empty;
                    customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[11].Value = string.Empty;
                }
                else if (ABBCCA == "BC")
                {
                    customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[11].Value = VA;
                    ABBCCA = "CA";

                    customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[9].Value = string.Empty;
                    customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[10].Value = string.Empty;
                }
                else if (ABBCCA == "CA")
                {
                    customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[9].Value = VA;
                    ABBCCA = "AB";
                    
                    customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[10].Value = string.Empty;
                    customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[11].Value = string.Empty;
                }
                
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[12].Value = string.Empty;
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[13].Value = 230;
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[14].Value = ampere;

                // Pole
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[15].Value = 2;

                // AT
                int AT = (type == "LO") ? ampereTrip("LO", ampacity) : ampereTrip(string.Empty, ampacity);
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[16].Value = AT;

                // AF
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[17].Value = AF(AT);

                //KAIC
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[18].Value = 10;

                //HOT WIRE
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[19].Value = 2.ToString() + "-" + hotWireSize + "-" + apply.wireType;

                //GROUNDING WIRE
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[20].Value = 1 + "-" + groundingSize(AT) + " sq. mm.-" + apply.wireType;

                //CONDUIT SIZE
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[21].Value = voltageDrop.ConduitSize;
            }
        }

        private void ThreeMotor(string type, string LO, string CO, string OtherOutlet, string Description, string VA, float ampere)
        {
            float va = Convert.ToSingle(VA);

            // ampacity
            float ampacity = ampere * 1.25f * apply.correctionFactor * apply.derating;

            string hotWireSize = string.Empty;
            if (apply.wireType == WireType.TW)
            {
                hotWireSize = TW(type, ampacity);
            }
            else if (apply.wireType == WireType.THW)
            {
                hotWireSize = THW(type, ampacity);
            }
            else
            {
                hotWireSize = THHN(type, ampacity);
            }

            voltageDrop = new PercentVoltageDrop(PhaseType.ThreePhase);

            voltageDrop.ampere = ampere;
            voltageDrop.wireType = apply.wireType;
            voltageDrop.wireSize = hotWireSize;
            voltageDrop.conduitType = apply.conduitType;

            // editon pa ag voltage value
            voltageDrop.voltage = Convert.ToInt32(voltageValue[tabControl1.SelectedIndex]);

            do
            {
                voltageDrop.ShowDialog();
            }
            while (!voltageDrop.close);

            hotWireSize = voltageDrop.wireSize;

            if (!voltageDrop.cancel)
            {
                customDataGrid = (Bunifu.Framework.UI.BunifuCustomDataGrid)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
                customDataGrid.Rows.Add((customDataGrid.Rows.Count + 1).ToString());

                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[1].Value = LO;
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[2].Value = CO;
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[3].Value = OtherOutlet;

                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[4].Value = string.Empty;
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[5].Value = string.Empty;
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[6].Value = string.Empty;
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[7].Value = string.Empty;

                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[8].Value = Description;

                string ABBCCA = string.Empty;

                for (int i = customDataGrid.Rows.Count - 2; i >= 0; i--)
                {
                    if (customDataGrid.Rows[i].Cells[9].Value.ToString() == string.Empty && customDataGrid.Rows[i].Cells[10].Value.ToString() == string.Empty && customDataGrid.Rows[i].Cells[11].Value.ToString() == string.Empty)
                        continue;

                    if (customDataGrid.Rows[i].Cells[9].Value.ToString() != string.Empty)
                    {
                        ABBCCA = "AB";
                        break;
                    }
                    else if (customDataGrid.Rows[i].Cells[10].Value.ToString() != string.Empty)
                    {
                        ABBCCA = "BC";
                        break;
                    }
                    else if (customDataGrid.Rows[i].Cells[11].Value.ToString() != string.Empty)
                    {
                        ABBCCA = "CA";
                        break;
                    }
                }

                if (ABBCCA == string.Empty)
                {
                    customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[9].Value = VA;
                    ABBCCA = "AB";

                    customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[10].Value = string.Empty;
                    customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[11].Value = string.Empty;
                }
                else if (ABBCCA == "AB")
                {
                    customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[10].Value = VA;
                    ABBCCA = "BC";

                    customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[9].Value = string.Empty;
                    customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[11].Value = string.Empty;
                }
                else if (ABBCCA == "BC")
                {
                    customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[11].Value = VA;
                    ABBCCA = "CA";

                    customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[9].Value = string.Empty;
                    customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[10].Value = string.Empty;
                }
                else if (ABBCCA == "CA")
                {
                    customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[9].Value = VA;
                    ABBCCA = "AB";

                    customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[10].Value = string.Empty;
                    customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[11].Value = string.Empty;
                }

                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[12].Value = string.Empty;
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[13].Value = 230;
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[14].Value = ampere;

                // Pole
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[15].Value = 2;

                // AT
                int AT = (type == "LO") ? ampereTrip("LO", ampacity) : ampereTrip(string.Empty, ampacity);
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[16].Value = AT;

                // AF
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[17].Value = AF(AT);

                //KAIC
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[18].Value = 10;

                //HOT WIRE
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[19].Value = 2.ToString() + "-" + hotWireSize + "-" + apply.wireType;

                //GROUNDING WIRE
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[20].Value = 1 + "-" + groundingSize(AT) + " sq. mm.-" + apply.wireType;

                //CONDUIT SIZE
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[21].Value = voltageDrop.ConduitSize;
            }
        }

        private void MotorThree(string type, string LO, string CO, string OtherOutlet, string Description, string VA, float ampere)
        {
            float va = Convert.ToSingle(VA);
            
            // ampacity
            float ampacity = ampere * 1.25f * apply.correctionFactor * apply.derating;

            string hotWireSize = string.Empty;
            if (apply.wireType == WireType.TW)
            {
                hotWireSize = TW(type, ampacity);
            }
            else if (apply.wireType == WireType.THW)
            {
                hotWireSize = THW(type, ampacity);
            }
            else
            {
                hotWireSize = THHN(type, ampacity);
            }
            
            voltageDrop = new PercentVoltageDrop(PhaseType.ThreePhase);

            voltageDrop.ampere = ampere;
            voltageDrop.wireType = apply.wireType;
            voltageDrop.wireSize = hotWireSize;
            voltageDrop.conduitType = apply.conduitType;

            // editon pa ag voltage value
            voltageDrop.voltage = Convert.ToInt32(voltageValue[tabControl1.SelectedIndex]);

            do
            {
                voltageDrop.ShowDialog();
            }
            while (!voltageDrop.close);

            hotWireSize = voltageDrop.wireSize;

            if (!voltageDrop.cancel)
            {
                customDataGrid = (Bunifu.Framework.UI.BunifuCustomDataGrid)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
                customDataGrid.Rows.Add((customDataGrid.Rows.Count + 1).ToString());

                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[1].Value = LO;
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[2].Value = CO;
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[3].Value = OtherOutlet;

                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[4].Value = string.Empty;
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[5].Value = string.Empty;
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[6].Value = string.Empty;
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[7].Value = string.Empty;

                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[8].Value = Description;

                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[9].Value = string.Empty;
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[10].Value = string.Empty;
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[11].Value = string.Empty;

                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[12].Value = VA;

                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[13].Value = 400;
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[14].Value = ampere;

                // Pole
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[15].Value = 3;

                // AT
                int AT = (type == "LO") ? ampereTrip("LO", ampacity) : ampereTrip(string.Empty, ampacity);
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[16].Value = AT;

                // AF
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[17].Value = AF(AT);

                //KAIC
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[18].Value = 10;

                //HOT WIRE
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[19].Value = 2.ToString() + "-" + hotWireSize + "-" + apply.wireType;

                //GROUNDING WIRE
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[20].Value = 1 + "-" + groundingSize(AT) + "-" + apply.wireType;

                //CONDUIT SIZE
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[21].Value = voltageDrop.ConduitSize;
            }
        }

        private void SingleACU(string type, string LO, string CO, string OtherOutlet, string Description, string VA, float ampere)
        {
            float va = Convert.ToSingle(VA);

            // ampacity
            float ampacity = ampere * 1.25f * apply.correctionFactor * apply.derating;

            string hotWireSize = string.Empty;
            if (apply.wireType == WireType.TW)
            {
                hotWireSize = TW(type, ampacity);
            }
            else if (apply.wireType == WireType.THW)
            {
                hotWireSize = THW(type, ampacity);
            }
            else
            {
                hotWireSize = THHN(type, ampacity);
            }

            voltageDrop = new PercentVoltageDrop(PhaseType.ThreePhase);

            voltageDrop.ampere = ampere;
            voltageDrop.wireType = apply.wireType;
            voltageDrop.wireSize = hotWireSize;
            voltageDrop.conduitType = apply.conduitType;

            // editon pa ag voltage value
            voltageDrop.voltage = Convert.ToInt32(voltageValue[tabControl1.SelectedIndex]);

            do
            {
                voltageDrop.ShowDialog();
            }
            while (!voltageDrop.close);

            hotWireSize = voltageDrop.wireSize;

            if (!voltageDrop.cancel)
            {
                customDataGrid = (Bunifu.Framework.UI.BunifuCustomDataGrid)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
                customDataGrid.Rows.Add((customDataGrid.Rows.Count + 1).ToString());

                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[1].Value = LO;
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[2].Value = CO;
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[3].Value = OtherOutlet;

                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[4].Value = string.Empty;
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[5].Value = string.Empty;
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[6].Value = string.Empty;
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[7].Value = string.Empty;

                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[8].Value = Description;
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[9].Value = VA;
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[10].Value = 230;
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[11].Value = ampere;

                // Pole
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[12].Value = 2;

                // AT
                int AT = (type == "LO") ? ampereTrip("LO", ampacity) : ampereTrip(string.Empty, ampacity);
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[13].Value = AT;

                // AF
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[14].Value = AF(AT);

                //KAIC
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[15].Value = 10;

                //HOT WIRE
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[16].Value = 2.ToString() + "-" + hotWireSize + "-" + apply.wireType;

                //GROUNDING WIRE
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[17].Value = 1 + "-" + groundingSize(AT) + " sq. mm.-" + apply.wireType;

                //CONDUIT SIZE
                customDataGrid.Rows[customDataGrid.Rows.Count - 1].Cells[18].Value = voltageDrop.ConduitSize;
            }
        }

        private int ampereTrip(string t, double ampere)
        {
            if (t == "LO")
            {
                return (ampere <= 15 * 0.8) ? 15
                       : (ampere <= 20 * 0.8) ? 20
                       : (ampere <= 25 * 0.8) ? 25
                       : (ampere <= 30 * 0.8) ? 30
                       : (ampere <= 35 * 0.8) ? 35
                       : (ampere <= 40 * 0.8) ? 40
                       : (ampere <= 45 * 0.8) ? 45
                       : (ampere <= 50 * 0.8) ? 50
                       : (ampere <= 60 * 0.8) ? 60
                       : (ampere <= 70 * 0.8) ? 70
                       : (ampere <= 80 * 0.8) ? 80
                       : (ampere <= 90 * 0.8) ? 90
                       : (ampere <= 100 * 0.8) ? 100
                       : (ampere <= 110 * 0.8) ? 110
                       : (ampere <= 125 * 0.8) ? 125
                       : (ampere <= 150 * 0.8) ? 150
                       : (ampere <= 175 * 0.8) ? 175
                       : (ampere <= 200 * 0.8) ? 200
                       : (ampere <= 225 * 0.8) ? 225
                       : (ampere <= 250 * 0.8) ? 250
                       : (ampere <= 300 * 0.8) ? 300
                       : (ampere <= 350 * 0.8) ? 350
                       : (ampere <= 400 * 0.8) ? 400
                       : (ampere <= 450 * 0.8) ? 450
                       : (ampere <= 500 * 0.8) ? 500
                       : (ampere <= 600 * 0.8) ? 600
                       : (ampere <= 700 * 0.8) ? 700
                       : (ampere <= 800 * 0.8) ? 800
                       : (ampere <= 1000 * 0.8) ? 1000 : 0;
            }

            if (t == string.Empty)
            {
                return (ampere <= 15 * 0.8) ? 20
                           : (ampere <= 20 * 0.8) ? 20
                           : (ampere <= 25 * 0.8) ? 25
                           : (ampere <= 30 * 0.8) ? 30
                           : (ampere <= 35 * 0.8) ? 35
                           : (ampere <= 40 * 0.8) ? 40
                           : (ampere <= 45 * 0.8) ? 45
                           : (ampere <= 50 * 0.8) ? 50
                           : (ampere <= 60 * 0.8) ? 60
                           : (ampere <= 70 * 0.8) ? 70
                           : (ampere <= 80 * 0.8) ? 80
                           : (ampere <= 90 * 0.8) ? 90
                           : (ampere <= 100 * 0.8) ? 100
                           : (ampere <= 110 * 0.8) ? 110
                           : (ampere <= 125 * 0.8) ? 125
                           : (ampere <= 150 * 0.8) ? 150
                           : (ampere <= 175 * 0.8) ? 175
                           : (ampere <= 200 * 0.8) ? 200
                           : (ampere <= 225 * 0.8) ? 225
                           : (ampere <= 250 * 0.8) ? 250
                           : (ampere <= 300 * 0.8) ? 300
                           : (ampere <= 350 * 0.8) ? 350
                           : (ampere <= 400 * 0.8) ? 400
                           : (ampere <= 450 * 0.8) ? 450
                           : (ampere <= 500 * 0.8) ? 500
                           : (ampere <= 600 * 0.8) ? 600
                           : (ampere <= 700 * 0.8) ? 700
                           : (ampere <= 800 * 0.8) ? 800
                           : (ampere <= 1000 * 0.8) ? 1000 : 0;
            }

            return (ampere <= 15) ? 20
                           : (ampere <= 20) ? 20
                           : (ampere <= 25) ? 25
                           : (ampere <= 30) ? 30
                           : (ampere <= 35) ? 35
                           : (ampere <= 40) ? 40
                           : (ampere <= 45) ? 45
                           : (ampere <= 50) ? 50
                           : (ampere <= 60) ? 60
                           : (ampere <= 70) ? 70
                           : (ampere <= 80) ? 80
                           : (ampere <= 90) ? 90
                           : (ampere <= 100) ? 100
                           : (ampere <= 110) ? 110
                           : (ampere <= 125) ? 125
                           : (ampere <= 150) ? 150
                           : (ampere <= 175) ? 175
                           : (ampere <= 200) ? 200
                           : (ampere <= 225) ? 225
                           : (ampere <= 250) ? 250
                           : (ampere <= 300) ? 300
                           : (ampere <= 350) ? 350
                           : (ampere <= 400) ? 400
                           : (ampere <= 450) ? 450
                           : (ampere <= 500) ? 500
                           : (ampere <= 600) ? 600
                           : (ampere <= 700) ? 700
                           : (ampere <= 800) ? 800
                           : (ampere <= 1000) ? 1000 : 0;
        }

        private int AF(int AT)
        {
            switch(AT)
            {
                case 15:
                case 20:
                case 25:
                case 30:
                case 35:
                    return 50;

                case 40:
                case 45:
                case 50:
                case 60:
                case 70:
                    return 100;

                case 80:
                case 90:
                case 100:
                case 110:
                case 125:
                case 150:
                    return 225;

                case 175:
                case 200:
                case 225:
                case 250:
                case 300:
                    return 400;

                case 350:
                case 400:
                case 450:
                case 500:
                case 600:
                case 700:
                    return 800;

                case 800:
                case 1000:
                    return 1200;
            }

            return 0;
        }

        private void illuminationToolStripItem_Click(object sender, EventArgs e)
        {
            IlluminationCalculation calculation = new IlluminationCalculation();
            calculation.ShowDialog();
        }

        private string TW(string type, float ampacity)
        {
            if (type == string.Empty)
            {
                return (ampacity <= 20) ? "5.5(2.6)* sq. mm." :
                       (ampacity <= 25 && ampacity > 20) ? "5.5(2.6)* sq. mm." :
                       (ampacity <= 30 && ampacity > 25) ? "5.5(2.6)* sq. mm." :
                       (ampacity <= 40 && ampacity > 30) ? "8.0(3.2) sq. mm." :
                       (ampacity <= 55 && ampacity > 40) ? "14 sq. mm." :
                       (ampacity <= 70 && ampacity > 55) ? "22 sq. mm." :
                       (ampacity <= 90 && ampacity > 70) ? "30 sq. mm." :
                       (ampacity <= 100 && ampacity > 90) ? "38 sq. mm." :
                       (ampacity <= 120 && ampacity > 100) ? "50 sq. mm." :
                       (ampacity <= 135 && ampacity > 120) ? "60 sq. mm." :
                       (ampacity <= 160 && ampacity > 135) ? "80 sq. mm." :
                       (ampacity <= 185 && ampacity > 160) ? "100 sq. mm." :
                       (ampacity <= 210 && ampacity > 185) ? "125 sq. mm." :
                       (ampacity <= 240 && ampacity > 210) ? "150 sq. mm." :
                       (ampacity <= 280 && ampacity > 240) ? "200 sq. mm." :
                       (ampacity <= 315 && ampacity > 280) ? "250 sq. mm." :
                       (ampacity <= 370 && ampacity > 315) ? "325 sq. mm." :
                       (ampacity <= 405 && ampacity > 370) ? "400 sq. mm." :
                       (ampacity <= 445 && ampacity > 405) ? "500 sq. mm." : string.Empty;
            }

            if (type == "LO")
            {
                return (ampacity <= 20) ? "3.5(2.0)* sq. mm." :
                       (ampacity <= 25 && ampacity > 20) ? "3.5(2.0)* sq. mm." :
                       (ampacity <= 30 && ampacity > 25) ? "5.5(2.6)* sq. mm." :
                       (ampacity <= 40 && ampacity > 30) ? "8.0(3.2) sq. mm." :
                       (ampacity <= 55 && ampacity > 40) ? "14 sq. mm." :
                       (ampacity <= 70 && ampacity > 55) ? "22 sq. mm." :
                       (ampacity <= 90 && ampacity > 70) ? "30 sq. mm." :
                       (ampacity <= 100 && ampacity > 90) ? "38 sq. mm." :
                       (ampacity <= 120 && ampacity > 100) ? "50 sq. mm." :
                       (ampacity <= 135 && ampacity > 120) ? "60 sq. mm." :
                       (ampacity <= 160 && ampacity > 135) ? "80 sq. mm." :
                       (ampacity <= 185 && ampacity > 160) ? "100 sq. mm." :
                       (ampacity <= 210 && ampacity > 185) ? "125 sq. mm." :
                       (ampacity <= 240 && ampacity > 210) ? "150 sq. mm." :
                       (ampacity <= 280 && ampacity > 240) ? "200 sq. mm." :
                       (ampacity <= 315 && ampacity > 280) ? "250 sq. mm." :
                       (ampacity <= 370 && ampacity > 315) ? "325 sq. mm." :
                       (ampacity <= 405 && ampacity > 370) ? "400 sq. mm." :
                       (ampacity <= 445 && ampacity > 405) ? "500 sq. mm." : string.Empty;
            }

            return (ampacity <= 20) ? "8.0(3.2) sq. mm." :
                       (ampacity <= 25 && ampacity > 20) ? "8.0(3.2) sq. mm." :
                       (ampacity <= 30 && ampacity > 25) ? "8.0(3.2) sq. mm." :
                       (ampacity <= 40 && ampacity > 30) ? "8.0(3.2) sq. mm." :
                       (ampacity <= 55 && ampacity > 40) ? "14 sq. mm." :
                       (ampacity <= 70 && ampacity > 55) ? "22 sq. mm." :
                       (ampacity <= 90 && ampacity > 70) ? "30 sq. mm." :
                       (ampacity <= 100 && ampacity > 90) ? "38 sq. mm." :
                       (ampacity <= 120 && ampacity > 100) ? "50 sq. mm." :
                       (ampacity <= 135 && ampacity > 120) ? "60 sq. mm." :
                       (ampacity <= 160 && ampacity > 135) ? "80 sq. mm." :
                       (ampacity <= 185 && ampacity > 160) ? "100 sq. mm." :
                       (ampacity <= 210 && ampacity > 185) ? "125 sq. mm." :
                       (ampacity <= 240 && ampacity > 210) ? "150 sq. mm." :
                       (ampacity <= 280 && ampacity > 240) ? "200 sq. mm." :
                       (ampacity <= 315 && ampacity > 280) ? "250 sq. mm." :
                       (ampacity <= 370 && ampacity > 315) ? "325 sq. mm." :
                       (ampacity <= 405 && ampacity > 370) ? "400 sq. mm." :
                       (ampacity <= 445 && ampacity > 405) ? "500 sq. mm." : string.Empty;
        }

        private string THW(string type, float ampacity)
        {
            if (type == string.Empty)
            {
                return (ampacity <= 20) ? "5.5(2.6)* sq. mm." :
                       (ampacity <= 25 && ampacity > 20) ? "5.5(2.6)* sq. mm." :
                       (ampacity <= 35 && ampacity > 25) ? "5.5(2.6)* sq. mm." :
                       (ampacity <= 50 && ampacity > 35) ? "8.0(3.2) sq. mm." :
                       (ampacity <= 65 && ampacity > 50) ? "14 sq. mm." :
                       (ampacity <= 85 && ampacity > 65) ? "22 sq. mm." :
                       (ampacity <= 110 && ampacity > 85) ? "30 sq. mm." :
                       (ampacity <= 125 && ampacity > 110) ? "38 sq. mm." :
                       (ampacity <= 145 && ampacity > 125) ? "50 sq. mm." :
                       (ampacity <= 160 && ampacity > 145) ? "60 sq. mm." :
                       (ampacity <= 195 && ampacity > 160) ? "80 sq. mm." :
                       (ampacity <= 220 && ampacity > 195) ? "100 sq. mm." :
                       (ampacity <= 255 && ampacity > 220) ? "125 sq. mm." :
                       (ampacity <= 280 && ampacity > 255) ? "150 sq. mm." :
                       (ampacity <= 330 && ampacity > 280) ? "200 sq. mm." :
                       (ampacity <= 375 && ampacity > 330) ? "250 sq. mm." :
                       (ampacity <= 435 && ampacity > 375) ? "325 sq. mm." :
                       (ampacity <= 485 && ampacity > 435) ? "400 sq. mm." :
                       (ampacity <= 540 && ampacity > 485) ? "500 sq. mm." : string.Empty;
            }

            if (type == "LO")
            {
                return (ampacity <= 20) ? "3.5(2.0)* sq. mm." :
                       (ampacity <= 25 && ampacity > 20) ? "3.5(2.0)* sq. mm." :
                       (ampacity <= 35 && ampacity > 25) ? "5.5(2.6)* sq. mm." :
                       (ampacity <= 50 && ampacity > 35) ? "8.0(3.2) sq. mm." :
                       (ampacity <= 65 && ampacity > 50) ? "14 sq. mm." :
                       (ampacity <= 85 && ampacity > 65) ? "22 sq. mm." :
                       (ampacity <= 110 && ampacity > 85) ? "30 sq. mm." :
                       (ampacity <= 125 && ampacity > 110) ? "38 sq. mm." :
                       (ampacity <= 145 && ampacity > 125) ? "50 sq. mm." :
                       (ampacity <= 160 && ampacity > 145) ? "60 sq. mm." :
                       (ampacity <= 195 && ampacity > 160) ? "80 sq. mm." :
                       (ampacity <= 220 && ampacity > 195) ? "100 sq. mm." :
                       (ampacity <= 255 && ampacity > 220) ? "125 sq. mm." :
                       (ampacity <= 280 && ampacity > 255) ? "150 sq. mm." :
                       (ampacity <= 330 && ampacity > 280) ? "200 sq. mm." :
                       (ampacity <= 375 && ampacity > 330) ? "250 sq. mm." :
                       (ampacity <= 435 && ampacity > 375) ? "325 sq. mm." :
                       (ampacity <= 485 && ampacity > 435) ? "400 sq. mm." :
                       (ampacity <= 540 && ampacity > 485) ? "500 sq. mm." : string.Empty;
            }

            return (ampacity <= 20) ? "8.0(3.2) sq. mm." :
                       (ampacity <= 25 && ampacity > 20) ? "8.0(3.2) sq. mm." :
                       (ampacity <= 35 && ampacity > 25) ? "8.0(3.2) sq. mm." :
                       (ampacity <= 50 && ampacity > 35) ? "8.0(3.2) sq. mm." :
                       (ampacity <= 65 && ampacity > 50) ? "14 sq. mm." :
                       (ampacity <= 85 && ampacity > 65) ? "22 sq. mm." :
                       (ampacity <= 110 && ampacity > 85) ? "30 sq. mm." :
                       (ampacity <= 125 && ampacity > 110) ? "38 sq. mm." :
                       (ampacity <= 145 && ampacity > 125) ? "50 sq. mm." :
                       (ampacity <= 160 && ampacity > 145) ? "60 sq. mm." :
                       (ampacity <= 195 && ampacity > 160) ? "80 sq. mm." :
                       (ampacity <= 220 && ampacity > 195) ? "100 sq. mm." :
                       (ampacity <= 255 && ampacity > 220) ? "125 sq. mm." :
                       (ampacity <= 280 && ampacity > 255) ? "150 sq. mm." :
                       (ampacity <= 330 && ampacity > 280) ? "200 sq. mm." :
                       (ampacity <= 375 && ampacity > 330) ? "250 sq. mm." :
                       (ampacity <= 435 && ampacity > 375) ? "325 sq. mm." :
                       (ampacity <= 485 && ampacity > 435) ? "400 sq. mm." :
                       (ampacity <= 540 && ampacity > 485) ? "500 sq. mm." : string.Empty;
        }

        private string THHN(string type, float ampacity)
        {
            if (type == string.Empty)
            {
                return (ampacity <= 25) ? "5.5(2.6)* sq. mm." :
                       (ampacity <= 30 && ampacity > 25) ? "5.5(2.6)* sq. mm." :
                       (ampacity <= 40 && ampacity > 30) ? "5.5(2.6)* sq. mm." :
                       (ampacity <= 55 && ampacity > 40) ? "8.0(3.2) sq. mm." :
                       (ampacity <= 70 && ampacity > 55) ? "14 sq. mm." :
                       (ampacity <= 90 && ampacity > 70) ? "22 sq. mm." :
                       (ampacity <= 115 && ampacity > 90) ? "30 sq. mm." :
                       (ampacity <= 130 && ampacity > 115) ? "38 sq. mm." :
                       (ampacity <= 150 && ampacity > 130) ? "50 sq. mm." :
                       (ampacity <= 170 && ampacity > 150) ? "60 sq. mm." :
                       (ampacity <= 205 && ampacity > 170) ? "80 sq. mm." :
                       (ampacity <= 225 && ampacity > 205) ? "100 sq. mm." :
                       (ampacity <= 265 && ampacity > 225) ? "125 sq. mm." :
                       (ampacity <= 295 && ampacity > 265) ? "150 sq. mm." :
                       (ampacity <= 355 && ampacity > 295) ? "200 sq. mm." :
                       (ampacity <= 400 && ampacity > 355) ? "250 sq. mm." :
                       (ampacity <= 470 && ampacity > 400) ? "325 sq. mm." :
                       (ampacity <= 515 && ampacity > 470) ? "400 sq. mm." :
                       (ampacity <= 580 && ampacity > 515) ? "500 sq. mm." : string.Empty;
            }

            if (type == "LO")
            {
                return (ampacity <= 25) ? "3.5(2.0)* sq. mm." :
                       (ampacity <= 30 && ampacity > 25) ? "3.5(2.0)* sq. mm." :
                       (ampacity <= 40 && ampacity > 30) ? "5.5(2.6)* sq. mm." :
                       (ampacity <= 55 && ampacity > 40) ? "8.0(3.2) sq. mm." :
                       (ampacity <= 70 && ampacity > 55) ? "14 sq. mm." :
                       (ampacity <= 90 && ampacity > 70) ? "22 sq. mm." :
                       (ampacity <= 115 && ampacity > 90) ? "30 sq. mm." :
                       (ampacity <= 130 && ampacity > 115) ? "38 sq. mm." :
                       (ampacity <= 150 && ampacity > 130) ? "50 sq. mm." :
                       (ampacity <= 170 && ampacity > 150) ? "60 sq. mm." :
                       (ampacity <= 205 && ampacity > 170) ? "80 sq. mm." :
                       (ampacity <= 225 && ampacity > 205) ? "100 sq. mm." :
                       (ampacity <= 265 && ampacity > 225) ? "125 sq. mm." :
                       (ampacity <= 295 && ampacity > 265) ? "150 sq. mm." :
                       (ampacity <= 355 && ampacity > 295) ? "200 sq. mm." :
                       (ampacity <= 400 && ampacity > 355) ? "250 sq. mm." :
                       (ampacity <= 470 && ampacity > 400) ? "325 sq. mm." :
                       (ampacity <= 515 && ampacity > 470) ? "400 sq. mm." :
                       (ampacity <= 580 && ampacity > 515) ? "500 sq. mm." : string.Empty;
            }

            return (ampacity <= 25) ? "8.0(3.2) sq. mm." :
                       (ampacity <= 30 && ampacity > 25) ? "8.0(3.2) sq. mm." :
                       (ampacity <= 40 && ampacity > 30) ? "8.0(3.2) sq. mm." :
                       (ampacity <= 55 && ampacity > 40) ? "8.0(3.2) sq. mm." :
                       (ampacity <= 70 && ampacity > 55) ? "14 sq. mm." :
                       (ampacity <= 90 && ampacity > 70) ? "22 sq. mm." :
                       (ampacity <= 115 && ampacity > 90) ? "30 sq. mm." :
                       (ampacity <= 130 && ampacity > 115) ? "38 sq. mm." :
                       (ampacity <= 150 && ampacity > 130) ? "50 sq. mm." :
                       (ampacity <= 170 && ampacity > 150) ? "60 sq. mm." :
                       (ampacity <= 205 && ampacity > 170) ? "80 sq. mm." :
                       (ampacity <= 225 && ampacity > 205) ? "100 sq. mm." :
                       (ampacity <= 265 && ampacity > 225) ? "125 sq. mm." :
                       (ampacity <= 295 && ampacity > 265) ? "150 sq. mm." :
                       (ampacity <= 355 && ampacity > 295) ? "200 sq. mm." :
                       (ampacity <= 400 && ampacity > 355) ? "250 sq. mm." :
                       (ampacity <= 470 && ampacity > 400) ? "325 sq. mm." :
                       (ampacity <= 515 && ampacity > 470) ? "400 sq. mm." :
                       (ampacity <= 580 && ampacity > 515) ? "500 sq. mm." : string.Empty;
        }

        public string groundingSize(float ampacity)
        {
            return (ampacity <= 15) ? "2.0(1.6) sq. mm." :
                   (ampacity <= 20 && ampacity > 15) ? "3.5(2.0) sq. mm." :
                   (ampacity <= 30 && ampacity > 20) ? "5.5(2.6) sq. mm." :
                   (ampacity <= 30 && ampacity > 20) ? "5.5(2.6) sq. mm." :
                   (ampacity <= 40 && ampacity > 30) ? "5.5(2.6) sq. mm." :
                   (ampacity <= 60 && ampacity > 40) ? "5.5(2.6) sq. mm." :
                   (ampacity <= 100 && ampacity > 60) ? "8.0(3.2) sq. mm." :
                   (ampacity <= 200 && ampacity > 100) ? "14 sq. mm." :
                   (ampacity <= 300 && ampacity > 200) ? "22 sq. mm." :
                   (ampacity <= 400 && ampacity > 300) ? "30 sq. mm." :
                   (ampacity <= 500 && ampacity > 400) ? "30 sq. mm." :
                   (ampacity <= 600 && ampacity > 500) ? "38 sq. mm." :
                   (ampacity <= 800 && ampacity > 600) ? "50 sq. mm." :
                   (ampacity <= 1000 && ampacity > 800) ? "60 sq. mm." :
                   (ampacity <= 1200 && ampacity > 1000) ? "80 sq. mm." :
                   (ampacity <= 1600 && ampacity > 1200) ? "100 sq. mm." :
                   (ampacity <= 2000 && ampacity > 1600) ? "125 sq. mm." :
                   (ampacity <= 2500 && ampacity > 2000) ? "200 sq. mm." :
                   (ampacity <= 3000 && ampacity > 2500) ? "200 sq. mm." :
                   (ampacity <= 4000 && ampacity > 3000) ? "250 sq. mm." :
                   (ampacity <= 5000 && ampacity > 4000) ? "400 sq. mm." :
                   (ampacity <= 6000 && ampacity > 5000) ? "400 sq. mm." : string.Empty;
        }

        private void calculateMainToolStrip_Click(object sender, EventArgs e)
        {
            
        }

        private void nEWToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void oPENToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sAVEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDatabase();
            SaveMain();
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            result = MessageBox.Show("DO YOU WANT TO SAVE YOUR FILE?", "SAVE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(result == DialogResult.No)
            {
                this.Close();
            }
            else
            {
                SaveDatabase();
                SaveMain();
                this.Close();
            }
        }
        
        private void printTable_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.TabCount == 0)
                    throw new Exception("CANNOT PRINT BECAUSE THERE IS CURRENTLY NO EXISTING TAB!");

                DGVPrinter printer = new DGVPrinter();
                printer.PageSettings.Landscape = true;
                printer.PageSettings.PaperSize = new System.Drawing.Printing.PaperSize("CUSTOM", 30, 20);
                printer.Title = Filename;
                printer.SubTitle = "TABLE NAME: " + tabControl1.TabPages[tabControl1.SelectedIndex].Text + string.Format(" Date: {0}", DateTime.Now.Date.ToLongDateString());
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Center;
                printer.CellAlignment = StringAlignment.Center;
                printer.Footer = "E-SCHED";
                printer.FooterSpacing = 15;

                var datagrid = (Bunifu.Framework.UI.BunifuCustomDataGrid)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
                printer.PrintPreviewDataGridView(datagrid);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // save all data before closing
        private void SaveDatabase()
        {
            //SaveTemp();

            try
            {
                // delete all contents
                DatabaseConnection.connection.Open();
            
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.CommandText = "DELETE from [" + Filename + "]";
                    cmd.Connection = DatabaseConnection.connection;
                    cmd.ExecuteNonQuery();
                }
            
                DatabaseConnection.connection.Close();
                
                // save new contents
                int index = 0;
                foreach(TabPage page in tabControl1.TabPages)
                {
                    int rowIndex = 0;

                    var grid = (Bunifu.Framework.UI.BunifuCustomDataGrid)tabControl1.TabPages[index].Controls[0];

                    if(grid.Rows.Count == 0)
                    {
                        mains.RemoveAt(index);
                        index++;

                        continue;
                    }

                    foreach (DataGridViewRow rows in grid.Rows)
                    {
                        if (rows.Cells[0].Value.ToString() == "TOTAL")
                            continue;

                        DatabaseConnection.connection.Open();
            
                        using (OleDbCommand cmd = new OleDbCommand())
                        {
                            string Tabname       = page.Text;
                            string Phase_Type    = phaseList[index].ToString();
                            string branchCircuit = branches[index].ElementAt(rowIndex).ToString();
            
                            string circuitNumber = rows.Cells[0].Value.ToString();
                            string LO            = rows.Cells[1].Value.ToString();
                            string CO            = rows.Cells[2].Value.ToString();
                            string Outlet        = rows.Cells[3].Value.ToString();
                            string S1            = rows.Cells[4].Value.ToString();
                            string S2            = rows.Cells[5].Value.ToString();
                            string S3            = rows.Cells[6].Value.ToString();
                            string S3W           = rows.Cells[7].Value.ToString();
                            string Description   = rows.Cells[8].Value.ToString();
            
                            string VA            = string.Empty;
                            string AB            = string.Empty;
                            string BC            = string.Empty;
                            string CA            = string.Empty;
                            string threeP        = string.Empty;
                            string Voltage       = string.Empty;
                            string Ampere        = string.Empty;
                            string Pole          = string.Empty;
                            string AT            = string.Empty;
                            string AF            = string.Empty;
                            string KAIC          = string.Empty;
                            string HotWire       = string.Empty;
                            string GroundingWire = string.Empty;
                            string ConduitSize   = string.Empty;
            
                            if(phaseList[index] == PhaseType.SinglePhase)
                            {
                                VA               = rows.Cells[9].Value.ToString();
                                Voltage          = rows.Cells[10].Value.ToString();
                                Ampere           = rows.Cells[11].Value.ToString();
                                Pole             = rows.Cells[12].Value.ToString();
                                AT               = rows.Cells[13].Value.ToString();
                                AF               = rows.Cells[14].Value.ToString();
                                KAIC             = rows.Cells[15].Value.ToString();
                                HotWire          = rows.Cells[16].Value.ToString();
                                GroundingWire    = rows.Cells[17].Value.ToString();
                                ConduitSize      = rows.Cells[18].Value.ToString();
                            }
                            else
                            {
                                AB               = rows.Cells[9].Value.ToString();
                                BC               = rows.Cells[10].Value.ToString();
                                CA               = rows.Cells[11].Value.ToString();
                                threeP           = rows.Cells[12].Value.ToString();
                                Voltage          = rows.Cells[13].Value.ToString();
                                Ampere           = rows.Cells[14].Value.ToString();
                                Pole             = rows.Cells[15].Value.ToString();
                                AT               = rows.Cells[16].Value.ToString();
                                AF               = rows.Cells[17].Value.ToString();
                                KAIC             = rows.Cells[18].Value.ToString();
                                HotWire          = rows.Cells[19].Value.ToString();
                                GroundingWire    = rows.Cells[20].Value.ToString();
                                ConduitSize      = rows.Cells[21].Value.ToString();
                            }
            
                            cmd.Connection = DatabaseConnection.connection;
                            cmd.CommandText = "INSERT into [" + Filename + "]" +
                                              "([TABNAME], " +
                                              "[PHASE], " +
                                              "[BRANCH CIRCUIT], " +
                                              "[CIRCUIT NUMBER], " +
                                              "[LO], " +
                                              "[CO] , " +
                                              "[OTHER OUTLET], " +
                                              "[S1], " +
                                              "[S2], " +
                                              "[S3], " +
                                              "[S3W], " +
                                              "[DESCRIPTION], ";
            
                            if (phaseList[index] == PhaseType.ThreePhase)
                            {
                                cmd.CommandText = cmd.CommandText +
                                                  "[AB], " +
                                                  "[BC], " +
                                                  "[CA], " +
                                                  "[THREE_P], ";
                            }
                            else
                            {
                                cmd.CommandText = cmd.CommandText + "[VA], ";
                            }
            
                            cmd.CommandText = cmd.CommandText +
                                              "[VOLTAGE], " +
                                              "[AMPERE], " +
                                              "[POLE], " +
                                              "[AT], " +
                                              "[AF], " +
                                              "[KAIC], " +
                                              "[HOT WIRE], " +
                                              "[GROUNDING WIRE], " +
                                              "[CONDUIT SIZE])";
            
                            cmd.CommandText = cmd.CommandText + " values('" +
                                              Tabname + "', '" +
                                              Phase_Type + "', '" +
                                              branchCircuit + "', '" +
                                              circuitNumber + "', '" +
                                              LO + "', '" +
                                              CO + "', '" +
                                              Outlet + "', '" +
                                              S1 + "', '" +
                                              S2 + "', '" +
                                              S3 + "', '" +
                                              S3W + "', '" +
                                              Description + "', '";
            
                             if (phaseList[index] == PhaseType.ThreePhase)
                            {
                                cmd.CommandText = cmd.CommandText +
                                                  AB + "', '" +
                                                  BC + "', '" +
                                                  CA + "', '" +
                                                  threeP + "', '";
                            }
                            else
                            {
                                cmd.CommandText = cmd.CommandText + VA + "', '";
                            }
            
                            cmd.CommandText = cmd.CommandText +
                                              Voltage + "', '" +
                                              Ampere + "', '" +
                                              Pole + "', '" +
                                              AT + "', '" +
                                              AF + "', '" +
                                              KAIC + "', '" +
                                              HotWire + "', '" +
                                              GroundingWire + "', '" +
                                              ConduitSize + "')";
            
                            cmd.ExecuteNonQuery();
                        }
            
                        rowIndex++;
                        DatabaseConnection.connection.Close();
                    }
            
                    index++;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DatabaseConnection.connection.Close();
            }
        }

        // save all calculated main
        private void SaveMain()
        {
            try
            {
                DatabaseConnection.connection.Open();

                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.CommandText = "DELETE from [" + Filename + "_MAIN" + "]";
                    cmd.Connection = DatabaseConnection.connection;
                    cmd.ExecuteNonQuery();
                }

                DatabaseConnection.connection.Close();

                foreach (CalculateMain m in mains)
                {
                    DatabaseConnection.connection.Open();

                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.CommandText = "Insert into [" + Filename + "_MAIN] " +
                                          "([CALCULATED], [LARGEST MOTOR], [BREAKER TYPE], [AREA], [UNIT], [LO], [CO], [RANGE], [DRYER], [ACU], [MOTOR], [OTHER LOAD], [SPARE], [MAIN SERVICE], " +
                                          "[CONDUCTOR AMPACITY], [AT], [KAIC], [HOT WIRE], [GROUNDING WIRE], [CONDUIT SIZE], [TOTAL CONNECTED LOAD], [TOTAL NET LOAD])" +
                                          "VALUES ('" + m.calculated.ToString() +"', '"+ m.largestMotor.ToString() +"', '"+ m.breakerType.ToString() +"', '"+ m.area +"', '"+ m.unitType.ToString() +"', " + 
                                          "'"+ m.LO.ToString() +"', '"+ m.CO.ToString() +"', '"+ m.RANGE.ToString() +"', '"+ m.DRYER.ToString() +"', '"+ m.ACU.ToString() +"', "+
                                          "'"+ m.MOTOR +"', '"+ m.OTHER_LOAD.ToString() +"', '"+ m.SPARE.ToString() +"', '"+ m.mainService.ToString() +"', '"+ m.conductorAmpacity.ToString() +"', " + 
                                          "'"+ m.AT +"', '"+ m.KAIC +"', '"+ m.conductorSize.ToString() +"', '"+ m.breakerSize.ToString() +"', '"+ m.conduitSize.ToString() +"', '"+ m.total_connected_load.ToString() +"', '"+ m.total_net_load.ToString() +"')";

                        cmd.Connection = DatabaseConnection.connection;
                        cmd.ExecuteNonQuery();
                    }

                    DatabaseConnection.connection.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DatabaseConnection.connection.Close();
            }
        }

        // CALCULATE MAIN
        private void calculateMain_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.TabCount == 0)
                    throw new Exception("THERE IS CURRENTLY NO TAB!");

                var dataGrid = (Bunifu.Framework.UI.BunifuCustomDataGrid)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];

                if (dataGrid.Rows.Count == 0)
                    throw new Exception("THERE ARE CURRENTLY NO BRANCH CIRCUITS!");

                double total_Lighting = 0d;
                double total_outlet = 0d;
                double totalMotor = 0d;
                double totalACU = 0d;
                double totalRange = 0d;
                double totalSpare = 0d;
                double totalDryer = 0d;
                double totalOthers = 0d;

                Hashtable hashRange = new Hashtable();  // key = VA, value = count
                int rangeCount = 0;     // counts number of ranges
                int dryerCount = 0;     // counts number of dryers
                double largestMotor = 0d;   // largest motor

                int index = 0;
                // GET TOTAL VA'S
                foreach (DataGridViewRow row in dataGrid.Rows)
                {
                    if (row.Cells[0].Value.ToString() == "TOTAL")
                        continue;

                    // Lightings
                    if (branches[tabControl1.SelectedIndex].ElementAt(index) == BranchCircuit.LIGHTINGS)
                    {
                        if (phaseList[tabControl1.SelectedIndex] == PhaseType.SinglePhase)
                        {
                            total_Lighting = total_Lighting + double.Parse(row.Cells[9].Value.ToString());
                        }
                        else if (phaseList[tabControl1.SelectedIndex] == PhaseType.ThreePhase)
                        {
                            if (row.Cells[9].Value.ToString() != string.Empty)
                            {
                                total_Lighting = total_Lighting + double.Parse(row.Cells[9].Value.ToString());
                            }
                            else if (row.Cells[10].Value.ToString() != string.Empty)
                            {
                                total_Lighting = total_Lighting + double.Parse(row.Cells[10].Value.ToString());
                            }
                            else if (row.Cells[11].Value.ToString() != string.Empty)
                            {
                                total_Lighting = total_Lighting + double.Parse(row.Cells[11].Value.ToString());
                            }
                        }

                    } // Convenience Outlet
                    else if (branches[tabControl1.SelectedIndex].ElementAt(index) == BranchCircuit.CONVENIENCE_OUTLET)
                    {
                        if (phaseList[tabControl1.SelectedIndex] == PhaseType.SinglePhase)
                        {
                            total_outlet = total_outlet + double.Parse(row.Cells[9].Value.ToString());
                        }
                        else if (phaseList[tabControl1.SelectedIndex] == PhaseType.ThreePhase)
                        {
                            if (row.Cells[9].Value.ToString() != string.Empty)
                                total_outlet = total_outlet + double.Parse(row.Cells[9].Value.ToString());
                            else if (row.Cells[10].Value.ToString() != string.Empty)
                                total_outlet = total_outlet + double.Parse(row.Cells[10].Value.ToString());
                            else if (row.Cells[11].Value.ToString() != string.Empty)
                                total_outlet = total_outlet + double.Parse(row.Cells[11].Value.ToString());
                        }
                    } // Range
                    else if (branches[tabControl1.SelectedIndex].ElementAt(index) == BranchCircuit.RANGE)
                    {
                        rangeCount++;
                        double r = 0d;

                        if (phaseList[tabControl1.SelectedIndex] == PhaseType.SinglePhase)
                        {
                            r = double.Parse(row.Cells[9].Value.ToString());
                        }
                        else if (phaseList[tabControl1.SelectedIndex] == PhaseType.ThreePhase)
                        {
                            if (row.Cells[9].Value.ToString() != string.Empty)
                            {
                                r = double.Parse(row.Cells[9].Value.ToString());
                            }
                            else if (row.Cells[10].Value.ToString() != string.Empty)
                            {
                                r = double.Parse(row.Cells[10].Value.ToString());
                            }
                            else if (row.Cells[11].Value.ToString() != string.Empty)
                            {
                                r = double.Parse(row.Cells[11].Value.ToString());
                            }
                        }

                        totalRange = totalRange + r;

                        if (hashRange.Contains(r))
                        {
                            int count = (int)hashRange[r];

                            hashRange[r] = count++;
                        }
                        else
                        {
                            hashRange.Add(r, 1);
                        }

                    } // Dryer
                    else if (branches[tabControl1.SelectedIndex].ElementAt(index) == BranchCircuit.DRYER)
                    {
                        dryerCount++;

                        if (phaseList[tabControl1.SelectedIndex] == PhaseType.SinglePhase)
                        {
                            totalDryer = totalDryer + double.Parse(row.Cells[9].Value.ToString());
                        }
                        else if (phaseList[tabControl1.SelectedIndex] == PhaseType.ThreePhase)
                        {
                            if (row.Cells[9].Value.ToString() != string.Empty)
                                totalDryer = totalDryer + double.Parse(row.Cells[9].Value.ToString());
                            else if (row.Cells[10].Value.ToString() != string.Empty)
                                totalDryer = totalDryer + double.Parse(row.Cells[10].Value.ToString());
                            else if (row.Cells[11].Value.ToString() != string.Empty)
                                totalDryer = totalDryer + double.Parse(row.Cells[11].Value.ToString());
                        }
                    } // ACU
                    else if (branches[tabControl1.SelectedIndex].ElementAt(index) == BranchCircuit.ACU)
                    {
                        if (phaseList[tabControl1.SelectedIndex] == PhaseType.SinglePhase)
                        {
                            totalACU = totalACU + double.Parse(row.Cells[9].Value.ToString());

                            if (largestMotor < double.Parse(row.Cells[9].Value.ToString()))
                                largestMotor = double.Parse(row.Cells[9].Value.ToString());
                        }
                        else if (phaseList[tabControl1.SelectedIndex] == PhaseType.ThreePhase)
                        {
                            if (row.Cells[9].Value.ToString() != string.Empty)
                            {
                                totalACU = totalACU + double.Parse(row.Cells[9].Value.ToString());

                                if (largestMotor < double.Parse(row.Cells[9].Value.ToString()))
                                    largestMotor = double.Parse(row.Cells[9].Value.ToString());
                            }
                            else if (row.Cells[10].Value.ToString() != string.Empty)
                            {
                                totalACU = totalACU + double.Parse(row.Cells[10].Value.ToString());

                                if (largestMotor < double.Parse(row.Cells[10].Value.ToString()))
                                    largestMotor = double.Parse(row.Cells[10].Value.ToString());
                            }
                            else if (row.Cells[11].Value.ToString() != string.Empty)
                            {
                                totalACU = totalACU + double.Parse(row.Cells[11].Value.ToString());

                                if (largestMotor < double.Parse(row.Cells[11].Value.ToString()))
                                    largestMotor = double.Parse(row.Cells[11].Value.ToString());
                            }
                            else if (row.Cells[12].Value.ToString() != string.Empty)
                            {
                                totalACU = totalACU + double.Parse(row.Cells[12].Value.ToString());

                                if (largestMotor < double.Parse(row.Cells[12].Value.ToString()))
                                    largestMotor = double.Parse(row.Cells[12].Value.ToString());
                            }
                        }
                    } // Motor Load
                    else if (branches[tabControl1.SelectedIndex].ElementAt(index) == BranchCircuit.MOTOR)
                    {
                        if (phaseList[tabControl1.SelectedIndex] == PhaseType.SinglePhase)
                        {
                            totalMotor = totalMotor + double.Parse(row.Cells[9].Value.ToString());

                            if (largestMotor < double.Parse(row.Cells[9].Value.ToString()))
                                largestMotor = double.Parse(row.Cells[9].Value.ToString());
                        }
                        else if (phaseList[tabControl1.SelectedIndex] == PhaseType.ThreePhase)
                        {
                            if (row.Cells[9].Value.ToString() != string.Empty)
                            {
                                totalMotor = totalMotor + double.Parse(row.Cells[9].Value.ToString());

                                if (largestMotor < double.Parse(row.Cells[9].Value.ToString()))
                                    largestMotor = double.Parse(row.Cells[9].Value.ToString());
                            }
                            else if (row.Cells[10].Value.ToString() != string.Empty)
                            {
                                totalMotor = totalMotor + double.Parse(row.Cells[10].Value.ToString());

                                if (largestMotor < double.Parse(row.Cells[10].Value.ToString()))
                                    largestMotor = double.Parse(row.Cells[10].Value.ToString());
                            }
                            else if (row.Cells[11].Value.ToString() != string.Empty)
                            {
                                totalMotor = totalMotor + double.Parse(row.Cells[11].Value.ToString());

                                if (largestMotor < double.Parse(row.Cells[11].Value.ToString()))
                                    largestMotor = double.Parse(row.Cells[11].Value.ToString());
                            }
                            else if (row.Cells[12].Value.ToString() != string.Empty)
                            {
                                totalMotor = totalMotor + double.Parse(row.Cells[12].Value.ToString());

                                if (largestMotor < double.Parse(row.Cells[12].Value.ToString()))
                                    largestMotor = double.Parse(row.Cells[12].Value.ToString());
                            }
                        }
                    }// Other load
                    else if (branches[tabControl1.SelectedIndex].ElementAt(index) == BranchCircuit.OTHER_LOAD)
                    {
                        if (phaseList[tabControl1.SelectedIndex] == PhaseType.SinglePhase)
                        {
                            totalOthers = totalOthers + double.Parse(row.Cells[9].Value.ToString());
                        }
                        else if (phaseList[tabControl1.SelectedIndex] == PhaseType.ThreePhase)
                        {
                            if (row.Cells[9].Value.ToString() != string.Empty)
                                totalOthers = totalOthers + double.Parse(row.Cells[9].Value.ToString());
                            else if (row.Cells[10].Value.ToString() != string.Empty)
                                totalOthers = totalOthers + double.Parse(row.Cells[10].Value.ToString());
                            else if (row.Cells[11].Value.ToString() != string.Empty)
                                totalOthers = totalOthers + double.Parse(row.Cells[11].Value.ToString());
                        }
                    } // Spare
                    else if (branches[tabControl1.SelectedIndex].ElementAt(index) == BranchCircuit.SPARE)
                    {
                        if (phaseList[tabControl1.SelectedIndex] == PhaseType.SinglePhase)
                        {
                            totalSpare = totalSpare + double.Parse(row.Cells[9].Value.ToString());
                        }
                        else if (phaseList[tabControl1.SelectedIndex] == PhaseType.ThreePhase)
                        {
                            if (row.Cells[9].Value.ToString() != string.Empty)
                                totalSpare = totalSpare + double.Parse(row.Cells[9].Value.ToString());
                            else if (row.Cells[10].Value.ToString() != string.Empty)
                                totalSpare = totalSpare + double.Parse(row.Cells[10].Value.ToString());
                            else if (row.Cells[11].Value.ToString() != string.Empty)
                                totalSpare = totalSpare + double.Parse(row.Cells[11].Value.ToString());
                        }
                    }

                    index++;
                }

                if (unitType == UnitType.DwellingUnit)
                {
                    Area area = new Area();
                    area.ShowDialog();

                    if (area.cancel)
                        return;

                    mains[tabControl1.SelectedIndex].area = area._area;

                    // if ang area <= 150 sq mm
                    if (double.Parse(mains[tabControl1.SelectedIndex].area) <= 150)
                    {
                        double total_ConLoad = total_Lighting + total_outlet + totalRange + totalDryer + totalACU + totalMotor + totalOthers + totalSpare;

                        double total_LO_CO = total_Lighting + total_outlet;

                        double lc = LightingDemandFactor(total_LO_CO, OccupancyType.DwellingUnit);

                        double r = RangeDemandFactor(hashRange);

                        double d = totalDryer * DryerDemandFactor(dryerCount);

                        double o = totalOthers;

                        double totalNet = lc + r + d + totalACU + totalMotor + o + totalSpare;
                        
                        double volt = 0d;

                        if (voltageValue[tabControl1.SelectedIndex] == VoltageValue.SINGLEPHASE_VOLTAGE)
                            volt = 230d;
                        else
                            volt = 400d;

                        double Ic = (totalNet + (0.25 * largestMotor)) / volt;

                        ApplyBreaker applyBreaker = new ApplyBreaker();
                        applyBreaker.ShowDialog();

                        if (applyBreaker.close)
                            return;

                        double Ib = (totalNet + (applyBreaker.percentage * largestMotor)) / volt;

                        ApplyMain applyMain = new ApplyMain();
                        applyMain.ShowDialog();

                        if (applyMain.close)
                            return;

                        string hotwire = (phaseList[tabControl1.SelectedIndex] == PhaseType.SinglePhase) ? "2-" : "3-";
                        string t = string.Empty;

                        if (applyMain.conductorWire == "TW")
                        {
                            t = TW("LO", (float)Ic);
                            hotwire = hotwire + t + " " + applyMain.conductorWire;
                        }
                        else if (applyMain.conductorWire == "THW")
                        {
                            t = THW("LO", (float)Ic);
                            hotwire = hotwire + t + " " + applyMain.conductorWire;
                        }
                        else if (applyMain.conductorWire == "THHN")
                        {
                            t = THHN("LO", (float)Ic);
                            hotwire = hotwire + t + " " + applyMain.conductorWire;
                        }

                        string breakerSize = string.Empty;

                        int at = ampereTrip("MAIN", Ib);

                        MainVoltageDrop mainVoltageDrop = new MainVoltageDrop(phaseList[tabControl1.SelectedIndex], t);
                        mainVoltageDrop.wireType = applyMain.breakerWire;
                        mainVoltageDrop.conduitType = applyMain.conduitType;
                        mainVoltageDrop.ampere = (float)Ic;
                        
                        mainVoltageDrop.voltage = Convert.ToInt32(voltageValue[tabControl1.SelectedIndex]);

                        do
                        {
                            mainVoltageDrop.ShowDialog();
                        }
                        while (!mainVoltageDrop.close);

                        string grounding = "1-" + groundingSize(at) + " " + applyMain.breakerWire;
                        breakerSize = grounding + " " + mainVoltageDrop.ConduitSize;

                        dwellingShowMain1.Initialize(total_ConLoad, lc, r, d, totalACU, totalMotor, o, totalSpare, totalNet, Ib, Ic, hotwire, breakerSize, at, applyBreaker.breaker, phaseList[tabControl1.SelectedIndex], Convert.ToInt32(voltageValue[tabControl1.SelectedIndex]));


                        // total
                        var grid = (Bunifu.Framework.UI.BunifuCustomDataGrid)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
                    
                        List<double> total = new List<double>(12)
                        {
                            0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d
                        };

                        foreach (DataGridViewRow row in grid.Rows)
                        {
                            if (row.Cells[0].Value.ToString() == "TOTAL")
                                continue;

                            if (row.Cells[1].Value.ToString() != string.Empty)
                                total[0] = total[0] + Convert.ToDouble(row.Cells[1].Value);

                            if (row.Cells[2].Value.ToString() != string.Empty)
                                total[1] = total[1] + Convert.ToDouble(row.Cells[2].Value);

                            if (row.Cells[3].Value.ToString() != string.Empty)
                                total[2] = total[2] + Convert.ToDouble(row.Cells[3].Value);

                            if (row.Cells[4].Value.ToString() != string.Empty)
                                total[3] = total[3] + Convert.ToDouble(row.Cells[4].Value);

                            if (row.Cells[5].Value.ToString() != string.Empty)
                                total[4] = total[4] + Convert.ToDouble(row.Cells[5].Value);

                            if (row.Cells[6].Value.ToString() != string.Empty)
                                total[5] = total[5] + Convert.ToDouble(row.Cells[6].Value);

                            if (row.Cells[7].Value.ToString() != string.Empty)
                                total[6] = total[6] + Convert.ToDouble(row.Cells[7].Value);

                            if (row.Cells[9].Value.ToString() != string.Empty)
                                total[7] = total[7] + Convert.ToDouble(row.Cells[9].Value.ToString());

                            if (phaseList[tabControl1.SelectedIndex] == PhaseType.ThreePhase)
                            {
                                if (row.Cells[10].Value.ToString() != string.Empty)
                                    total[8] = total[8] + Convert.ToDouble(row.Cells[10].Value.ToString());

                                if (row.Cells[11].Value.ToString() != string.Empty)
                                    total[9] = total[9] + Convert.ToDouble(row.Cells[11].Value.ToString());

                                if (row.Cells[12].Value.ToString() != string.Empty)
                                    total[10] = total[10] + Convert.ToDouble(row.Cells[12].Value.ToString());
                            }
                        }

                        string pole = (phaseList[tabControl1.SelectedIndex] == PhaseType.SinglePhase) ? "2" : "3";

                        if (grid.Rows[grid.Rows.Count - 1].Cells[0].Value.ToString() == "TOTAL")
                            grid.Rows.RemoveAt(grid.Rows.Count - 1);

                        if (phaseList[tabControl1.SelectedIndex] == PhaseType.SinglePhase)
                            grid.Rows.Add("TOTAL", total[0], total[1], total[2], total[3], total[4], total[5], total[6], string.Empty, total[7], Convert.ToInt16(voltageValue[tabControl1.SelectedIndex]), (total_ConLoad / Convert.ToDouble(voltageValue[tabControl1.SelectedIndex])), pole, at.ToString(), AF(at), string.Empty, hotwire, grounding, mainVoltageDrop.ConduitSize);
                        else if (phaseList[tabControl1.SelectedIndex] == PhaseType.ThreePhase)
                            grid.Rows.Add("TOTAL", total[0], total[1], total[2], total[3], total[4], total[5], total[6], string.Empty, total[7], total[8], total[9], total[10], Convert.ToInt16(voltageValue[tabControl1.SelectedIndex]), (total_ConLoad / Convert.ToDouble(voltageValue[tabControl1.SelectedIndex])), pole, at, AF(at), string.Empty, hotwire, grounding, mainVoltageDrop.ConduitSize);
                        
                        mains[tabControl1.SelectedIndex].total_connected_load = total_ConLoad;
                        mains[tabControl1.SelectedIndex].total_net_load = totalNet;
                        mains[tabControl1.SelectedIndex].LO = total_Lighting;
                        mains[tabControl1.SelectedIndex].CO = total_outlet;
                        mains[tabControl1.SelectedIndex].RANGE = r;
                        mains[tabControl1.SelectedIndex].DRYER = d;
                        mains[tabControl1.SelectedIndex].ACU = totalACU;
                        mains[tabControl1.SelectedIndex].MOTOR = totalMotor;
                        mains[tabControl1.SelectedIndex].OTHER_LOAD = o;
                        mains[tabControl1.SelectedIndex].SPARE = totalSpare;
                        mains[tabControl1.SelectedIndex].mainService = Ic;
                        mains[tabControl1.SelectedIndex].conductorAmpacity = Ib;
                        mains[tabControl1.SelectedIndex].conductorSize = hotwire;
                        mains[tabControl1.SelectedIndex].breakerSize = grounding;
                        mains[tabControl1.SelectedIndex].unitType = UnitType.DwellingUnit;
                        mains[tabControl1.SelectedIndex].calculated = true;
                        mains[tabControl1.SelectedIndex].AT = at.ToString();
                        mains[tabControl1.SelectedIndex].largestMotor = largestMotor;
                        mains[tabControl1.SelectedIndex].conduitSize = mainVoltageDrop.ConduitSize;
                        mains[tabControl1.SelectedIndex].breakerType = applyBreaker.breaker;

                        dwellingShowMain1.BringToFront();

                    }
                    else
                    {
                        double total_ConLoad = total_Lighting + total_outlet + totalRange + totalDryer + totalACU + totalMotor + totalOthers + totalSpare;
                        
                        double r = RangeDemandFactor(hashRange);

                        double d = totalDryer * DryerDemandFactor(dryerCount);

                        double o = totalOthers * 0.40;

                        double totalNet = total_Lighting + total_outlet + r + d + totalACU + totalMotor + o + totalSpare;

                        double volt = 0d;

                        if (voltageValue[tabControl1.SelectedIndex] == VoltageValue.SINGLEPHASE_VOLTAGE)
                            volt = 230d;
                        else
                            volt = 400d;

                        double Ic = (totalNet + (0.25 * largestMotor)) / volt;

                        ApplyBreaker applyBreaker = new ApplyBreaker();
                        applyBreaker.ShowDialog();

                        if (applyBreaker.close)
                            return;

                        double Ib = (totalNet + (applyBreaker.percentage * largestMotor)) / volt;

                        ApplyMain applyMain = new ApplyMain();
                        applyMain.ShowDialog();

                        if (applyMain.close)
                            return;

                        string hotwire = (phaseList[tabControl1.SelectedIndex] == PhaseType.SinglePhase) ? "2-" : "3-";
                        string t = string.Empty;

                        if (applyMain.conductorWire == "TW")
                        {
                            t = TW("LO", (float)Ic);
                            hotwire = hotwire + t + " " + applyMain.conductorWire;
                        }
                        else if (applyMain.conductorWire == "THW")
                        {
                            t = THW("LO", (float)Ic);
                            hotwire = hotwire + t + " " + applyMain.conductorWire;
                        }
                        else if (applyMain.conductorWire == "THHN")
                        {
                            t = THHN("LO", (float)Ic);
                            hotwire = hotwire + t + " " + applyMain.conductorWire;
                        }

                        string breakerSize = string.Empty;

                        int at = ampereTrip("MAIN", Ib);

                        MainVoltageDrop mainVoltageDrop = new MainVoltageDrop(phaseList[tabControl1.SelectedIndex], t);
                        mainVoltageDrop.wireType = applyMain.breakerWire;
                        mainVoltageDrop.conduitType = applyMain.conduitType;
                        mainVoltageDrop.ampere = (float)Ic;

                        mainVoltageDrop.voltage = Convert.ToInt32(voltageValue[tabControl1.SelectedIndex]);

                        do
                        {
                            mainVoltageDrop.ShowDialog();
                        }
                        while (!mainVoltageDrop.close);

                        string grounding = "1-" + groundingSize(at) + " " + applyMain.breakerWire;
                        breakerSize = grounding + " " + mainVoltageDrop.ConduitSize;

                        dwellingShowMainL1.Initialize(total_ConLoad, total_Lighting, total_outlet, r, d, totalACU, totalMotor, o, totalSpare, totalNet, Ib, Ic, hotwire, grounding, at, applyBreaker.breaker, phaseList[tabControl1.SelectedIndex], Convert.ToInt32(voltageValue[tabControl1.SelectedIndex]));


                        // total
                        var grid = (Bunifu.Framework.UI.BunifuCustomDataGrid)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];

                        List<double> total = new List<double>(12)
                        {
                            0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d
                        };

                        foreach (DataGridViewRow row in grid.Rows)
                        {
                            if (row.Cells[0].Value.ToString() == "TOTAL")
                                continue;

                            if (row.Cells[1].Value.ToString() != string.Empty)
                                total[0] = total[0] + Convert.ToDouble(row.Cells[1].Value);

                            if (row.Cells[2].Value.ToString() != string.Empty)
                                total[1] = total[1] + Convert.ToDouble(row.Cells[2].Value);

                            if (row.Cells[3].Value.ToString() != string.Empty)
                                total[2] = total[2] + Convert.ToDouble(row.Cells[3].Value);

                            if (row.Cells[4].Value.ToString() != string.Empty)
                                total[3] = total[3] + Convert.ToDouble(row.Cells[4].Value);

                            if (row.Cells[5].Value.ToString() != string.Empty)
                                total[4] = total[4] + Convert.ToDouble(row.Cells[5].Value);

                            if (row.Cells[6].Value.ToString() != string.Empty)
                                total[5] = total[5] + Convert.ToDouble(row.Cells[6].Value);

                            if (row.Cells[7].Value.ToString() != string.Empty)
                                total[6] = total[6] + Convert.ToDouble(row.Cells[7].Value);

                            if (row.Cells[9].Value.ToString() != string.Empty)
                                total[7] = total[7] + Convert.ToDouble(row.Cells[9].Value.ToString());

                            if(phaseList[tabControl1.SelectedIndex] == PhaseType.ThreePhase)
                            {
                                if (row.Cells[10].Value.ToString() != string.Empty)
                                    total[8] = total[8] + Convert.ToDouble(row.Cells[10].Value.ToString());

                                if (row.Cells[11].Value.ToString() != string.Empty)
                                    total[9] = total[9] + Convert.ToDouble(row.Cells[11].Value.ToString());

                                if (row.Cells[12].Value.ToString() != string.Empty)
                                    total[10] = total[10] + Convert.ToDouble(row.Cells[11].Value.ToString());
                            }
                        }

                        string pole = (phaseList[tabControl1.SelectedIndex] == PhaseType.SinglePhase) ? "2" : "3";

                        if (grid.Rows[grid.Rows.Count - 1].Cells[0].Value.ToString() == "TOTAL")
                            grid.Rows.RemoveAt(grid.Rows.Count - 1);

                        if (phaseList[tabControl1.SelectedIndex] == PhaseType.SinglePhase)
                            grid.Rows.Add("TOTAL", total[0], total[1], total[2], total[3], total[4], total[5], total[6], string.Empty, total[7], Convert.ToInt16(voltageValue[tabControl1.SelectedIndex]), (total_ConLoad / Convert.ToDouble(voltageValue[tabControl1.SelectedIndex])), pole, at.ToString(), AF(at), string.Empty, hotwire, grounding, mainVoltageDrop.ConduitSize);
                        else if (phaseList[tabControl1.SelectedIndex] == PhaseType.ThreePhase)
                            grid.Rows.Add("TOTAL", total[0], total[1], total[2], total[3], total[4], total[5], total[6], string.Empty, total[7], total[8], total[9], total[10], Convert.ToInt16(voltageValue[tabControl1.SelectedIndex]), (total_ConLoad / Convert.ToDouble(voltageValue[tabControl1.SelectedIndex])), pole, at, AF(at), string.Empty, hotwire, grounding, mainVoltageDrop.ConduitSize);

                        mains[tabControl1.SelectedIndex].total_connected_load = total_ConLoad;
                        mains[tabControl1.SelectedIndex].total_net_load = totalNet;
                        mains[tabControl1.SelectedIndex].LO = total_Lighting;
                        mains[tabControl1.SelectedIndex].CO = total_outlet;
                        mains[tabControl1.SelectedIndex].RANGE = r;
                        mains[tabControl1.SelectedIndex].DRYER = d;
                        mains[tabControl1.SelectedIndex].ACU = totalACU;
                        mains[tabControl1.SelectedIndex].MOTOR = totalMotor;
                        mains[tabControl1.SelectedIndex].OTHER_LOAD = o;
                        mains[tabControl1.SelectedIndex].SPARE = totalSpare;
                        mains[tabControl1.SelectedIndex].mainService = Ic;
                        mains[tabControl1.SelectedIndex].conductorAmpacity = Ib;
                        mains[tabControl1.SelectedIndex].conductorSize = hotwire;
                        mains[tabControl1.SelectedIndex].breakerSize = grounding;
                        mains[tabControl1.SelectedIndex].unitType = UnitType.None;
                        mains[tabControl1.SelectedIndex].calculated = true;
                        mains[tabControl1.SelectedIndex].AT = at.ToString();
                        mains[tabControl1.SelectedIndex].largestMotor = largestMotor;
                        mains[tabControl1.SelectedIndex].conduitSize = mainVoltageDrop.ConduitSize;
                        mains[tabControl1.SelectedIndex].breakerType = applyBreaker.breaker;

                        dwellingShowMainL1.BringToFront();

                    }
                } // non dwelling
                else
                {
                    Occupancy occupancy = new Occupancy();
                    occupancy.ShowDialog();

                    if (occupancy.close)
                        return;

                    double total_ConLoad = total_Lighting + total_outlet + totalRange + totalDryer + totalACU + totalMotor + totalOthers + totalSpare;

                    double l = LightingDemandFactor(total_Lighting, occupancy.oType);

                    double c = ConvenienceDemandFactor(total_outlet);

                    double r = RangeDemandFactor(totalRange, rangeCount);

                    double totalNet = l + c + r + totalDryer + totalACU + totalOthers + totalSpare + totalMotor;

                    double volt = 0d;

                    if (voltageValue[tabControl1.SelectedIndex] == VoltageValue.SINGLEPHASE_VOLTAGE)
                        volt = 230d;
                    else
                        volt = 400d;

                    double Ic = (totalNet + (0.25 * largestMotor)) / volt;

                    ApplyBreaker applyBreaker = new ApplyBreaker();
                    applyBreaker.ShowDialog();

                    if (applyBreaker.close)
                        return;

                    double Ib = (totalNet + (applyBreaker.percentage * largestMotor)) / volt;

                    ApplyMain applyMain = new ApplyMain();
                    applyMain.ShowDialog();

                    if (applyMain.close)
                        return;

                    string hotwire = (phaseList[tabControl1.SelectedIndex] == PhaseType.SinglePhase) ? "2-" : "3-";
                    string t = string.Empty;

                    if (applyMain.conductorWire == "TW")
                    {
                        t = TW("LO", (float)Ic);
                        hotwire = hotwire + t + " " + applyMain.conductorWire;
                    }
                    else if (applyMain.conductorWire == "THW")
                    {
                        t = THW("LO", (float)Ic);
                        hotwire = hotwire + t + " " + applyMain.conductorWire;
                    }
                    else if (applyMain.conductorWire == "THHN")
                    {
                        t = THHN("LO", (float)Ic);
                        hotwire = hotwire + t + " " + applyMain.conductorWire;
                    }

                    string breakerSize = string.Empty;
                    
                    int at = ampereTrip("MAIN", Ib);

                    MainVoltageDrop mainVoltageDrop = new MainVoltageDrop(phaseList[tabControl1.SelectedIndex], t);
                    mainVoltageDrop.wireType = applyMain.breakerWire;
                    mainVoltageDrop.conduitType = applyMain.conduitType;
                    mainVoltageDrop.ampere = (float)Ib;

                    mainVoltageDrop.voltage = Convert.ToInt32(voltageValue[tabControl1.SelectedIndex]);

                    do
                    {
                        mainVoltageDrop.ShowDialog();
                    }
                    while (!mainVoltageDrop.close);

                    string grounding = "1-" + groundingSize(at) + " " + applyMain.breakerWire;
                    breakerSize = grounding + " " + mainVoltageDrop.ConduitSize;

                    dwellingShowMainL1.Initialize(total_ConLoad, l, c, r, totalDryer, totalACU, totalMotor, totalOthers, totalSpare, totalNet, Ib, Ic, hotwire, breakerSize, at, applyBreaker.breaker, phaseList[tabControl1.SelectedIndex], Convert.ToInt32(voltageValue[tabControl1.SelectedIndex]));


                    // total
                    var grid = (Bunifu.Framework.UI.BunifuCustomDataGrid)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];

                    List<double> total = new List<double>(12)
                    {
                        0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d
                    };

                    foreach (DataGridViewRow row in grid.Rows)
                    {
                        if (row.Cells[0].Value.ToString() == "TOTAL")
                            continue;

                        if (row.Cells[1].Value.ToString() != string.Empty)
                            total[0] = total[0] + Convert.ToDouble(row.Cells[1].Value);

                        if (row.Cells[2].Value.ToString() != string.Empty)
                            total[1] = total[1] + Convert.ToDouble(row.Cells[2].Value);

                        if (row.Cells[3].Value.ToString() != string.Empty)
                            total[2] = total[2] + Convert.ToDouble(row.Cells[3].Value);

                        if (row.Cells[4].Value.ToString() != string.Empty)
                            total[3] = total[3] + Convert.ToDouble(row.Cells[4].Value);

                        if (row.Cells[5].Value.ToString() != string.Empty)
                            total[4] = total[4] + Convert.ToDouble(row.Cells[5].Value);

                        if (row.Cells[6].Value.ToString() != string.Empty)
                            total[5] = total[5] + Convert.ToDouble(row.Cells[6].Value);

                        if (row.Cells[7].Value.ToString() != string.Empty)
                            total[6] = total[6] + Convert.ToDouble(row.Cells[7].Value);

                        if (row.Cells[9].Value.ToString() != string.Empty)
                            total[7] = total[7] + Convert.ToDouble(row.Cells[9].Value.ToString());

                        if(phaseList[tabControl1.SelectedIndex] == PhaseType.ThreePhase)
                            {
                            if (row.Cells[10].Value.ToString() != string.Empty)
                                total[8] = total[8] + Convert.ToDouble(row.Cells[10].Value.ToString());

                            if (row.Cells[11].Value.ToString() != string.Empty)
                                total[9] = total[9] + Convert.ToDouble(row.Cells[11].Value.ToString());

                            if (row.Cells[12].Value.ToString() != string.Empty)
                                total[10] = total[10] + Convert.ToDouble(row.Cells[12].Value.ToString());
                        }
                    }

                    string pole = (phaseList[tabControl1.SelectedIndex] == PhaseType.SinglePhase) ? "2" : "3";

                    if (grid.Rows[grid.Rows.Count - 1].Cells[0].Value.ToString() == "TOTAL")
                        grid.Rows.RemoveAt(grid.Rows.Count - 1);

                    if (phaseList[tabControl1.SelectedIndex] == PhaseType.SinglePhase)
                        grid.Rows.Add("TOTAL", total[0], total[1], total[2], total[3], total[4], total[5], total[6], string.Empty, total[7], Convert.ToInt16(voltageValue[tabControl1.SelectedIndex]), (total_ConLoad / Convert.ToDouble(voltageValue[tabControl1.SelectedIndex])), pole, at.ToString(), AF(at), string.Empty, hotwire, grounding, mainVoltageDrop.ConduitSize);
                    else if (phaseList[tabControl1.SelectedIndex] == PhaseType.ThreePhase)
                        grid.Rows.Add("TOTAL", total[0], total[1], total[2], total[3], total[4], total[5], total[6], string.Empty, total[7], total[8], total[9], total[10], Convert.ToInt16(voltageValue[tabControl1.SelectedIndex]), (total_ConLoad / Convert.ToDouble(voltageValue[tabControl1.SelectedIndex])), pole, at, AF(at), string.Empty, hotwire, grounding, mainVoltageDrop.ConduitSize);

                    mains[tabControl1.SelectedIndex].total_connected_load = total_ConLoad;
                    mains[tabControl1.SelectedIndex].total_net_load = totalNet;
                    mains[tabControl1.SelectedIndex].LO = total_Lighting;
                    mains[tabControl1.SelectedIndex].CO = total_outlet;
                    mains[tabControl1.SelectedIndex].RANGE = r;
                    mains[tabControl1.SelectedIndex].DRYER = totalDryer;
                    mains[tabControl1.SelectedIndex].ACU = totalACU;
                    mains[tabControl1.SelectedIndex].MOTOR = totalMotor;
                    mains[tabControl1.SelectedIndex].OTHER_LOAD = totalOthers;
                    mains[tabControl1.SelectedIndex].SPARE = totalSpare;
                    mains[tabControl1.SelectedIndex].mainService = Ic;
                    mains[tabControl1.SelectedIndex].conductorAmpacity = Ib;
                    mains[tabControl1.SelectedIndex].conductorSize = hotwire;
                    mains[tabControl1.SelectedIndex].breakerSize = grounding;
                    mains[tabControl1.SelectedIndex].unitType = UnitType.DwellingUnit;
                    mains[tabControl1.SelectedIndex].calculated = true;
                    mains[tabControl1.SelectedIndex].AT = ampereTrip(string.Empty, Ic).ToString();
                    mains[tabControl1.SelectedIndex].largestMotor = largestMotor;
                    mains[tabControl1.SelectedIndex].conduitSize = mainVoltageDrop.ConduitSize;
                    mains[tabControl1.SelectedIndex].breakerType = applyBreaker.breaker;

                    dwellingShowMainL1.BringToFront();

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DatabaseConnection.connection.Close();
            }
        }

        // LIGHTING DEMAND FACTOR DWELLING UNIT 
        double LightingDemandFactor(double light, OccupancyType occupancyType)
        {
            if (light == 0)
                return 0;

            double l = 0d;

            if (occupancyType == OccupancyType.DwellingUnit)
            {
                if(light <= 3000)
                {
                    l = light;
                }
                else if(light <= 120000 && light >= 3001)
                {
                    l = (light + (light * 0.35));
                }
                else if (light > 120000)
                {
                    l = (light + (light * 0.25));
                }
            }
            else if(occupancyType == OccupancyType.Hospitals)
            {
                if (light <= 50000)
                {
                    l = (light + (light * 0.40));
                }
                else if (light > 50000)
                {
                    l = (light + (light * 0.20));
                }
            }
            else if (occupancyType == OccupancyType.Hotels_Motels)
            {
                if (light <= 20000)
                {
                    l = (light + (light * 0.50));
                }
                else if (light >= 20001 && light <= 100000)
                {
                    l = (light + (light * 0.40));
                }
                else if (light > 100000)
                {
                    l = (light + (light * 0.30));
                }
            }
            else if (occupancyType == OccupancyType.Warehouses)
            {
                if (light <= 12500)
                {
                    l = (light);
                }
                else if (light > 12500)
                {
                    l = (light + (light * 0.50));
                }
            }
            else if (occupancyType == OccupancyType.Others)
            {
                l = (light);
            }
            
            return l;
        }

        // RANGE DEMAND FACTOR
        double RangeDemandFactor(Hashtable hashRange)
        {
            if (hashRange.Count == 0)
                return 0;

            double r = 0d;
            
            // range demand factors
            double[,] rangeList =
                {
                            { 0.8d,  0.8d,  0.08d },
                            { 0.75d, 0.65d, 0.11d },
                            { 0.70d, 0.55d, 0.14d },
                            { 0.66d, 0.50d, 0.17d },
                            { 0.62d, 0.45d, 0.20d },

                            { 0.59d, 0.43d, 0.21d },
                            { 0.56d, 0.40d, 0.22d },
                            { 0.53d, 0.36d, 0.23d },
                            { 0.51d, 0.35d, 0.24d },
                            { 0.49d, 0.34d, 0.25d },

                            { 0.47d, 0.32d, 0.26d },
                            { 0.45d, 0.32d, 0.27d },
                            { 0.43d, 0.32d, 0.28d },
                            { 0.41d, 0.32d, 0.29d },
                            { 0.40d, 0.32d, 0.30d },

                            { 0.39d, 0.28d, 0.31d },
                            { 0.38d, 0.28d, 0.32d },
                            { 0.37d, 0.28d, 0.33d },
                            { 0.36d, 0.28d, 0.34d },
                            { 0.35d, 0.28d, 0.35d },

                            { 0.34d, 0.26d, 0.36d },
                            { 0.33d, 0.26d, 0.37d },
                            { 0.32d, 0.26d, 0.38d },
                            { 0.31d, 0.26d, 0.39d },
                            { 0.30d, 0.26d, 0.40d },

                            { 0.30d, 0.24d, 1d },
                            { 0.30d, 0.22d, 1d },

                            { 0.30d, 0.20d, 0.75d },
                            { 0.30d, 0.18d, 0.75d },
                            { 0.30d, 0.16d, 0.75d }
                        };

            // get all VA's that belong to column A
            List<DictionaryEntry> A = new List<DictionaryEntry>();
            foreach(DictionaryEntry entry in hashRange)
            {
                if((double)entry.Key < 3500d)
                {
                    A.Add(entry);
                }
            }

            // get all VA's that belong to column B
            List<DictionaryEntry> B = new List<DictionaryEntry>();
            foreach (DictionaryEntry entry in hashRange)
            {
                if ((double)entry.Key >= 3500 && (double)entry.Key <= 8750)
                {
                    B.Add(entry);
                }
            }

            //count total number in A
            int aCount = 0;
            foreach (DictionaryEntry entry in A)
            {
                aCount = aCount + (int)entry.Value;
            }

            //count total number in B
            int bCount = 0;
            foreach (DictionaryEntry entry in B)
            {
                bCount = bCount + (int)entry.Value;
            }

            int overallTotal = aCount + bCount;

            // solve all A's
            double aTotal = 0d;
            for(int i=0; i<A.Count; i++)
            {
                double df = 0d;
                if(aCount >= 26)
                {
                    df = rangeList[25, 0];
                }
                else
                {
                    df = rangeList[aCount - 1, 0];
                }

                double key = double.Parse(A[i].Key.ToString());
                double value = double.Parse(A[i].Value.ToString());

                aTotal = aTotal + (value * key * df);
            }

            // solve all B's
            double bTotal = 0d;
            for(int i=0; i<B.Count; i++)
            {
                double df = 0d;
                if (bCount >= 26 && bCount <= 30)
                {
                    df = rangeList[25, 1];
                }
                else if (bCount >= 31 && bCount <= 40)
                {
                    df = rangeList[26, 1];
                }
                else if (bCount >= 41 && bCount <= 50)
                {
                    df = rangeList[27, 1];
                }
                else if (bCount >= 51 && bCount <= 60)
                {
                    df = rangeList[28, 1];
                }
                else if (bCount >= 61)
                {
                    df = rangeList[29, 1];
                }
                else
                {
                    df = rangeList[bCount - 1, 0];
                }
                
                double key = double.Parse(B[i].Key.ToString());
                double value = double.Parse(B[i].Value.ToString());

                bTotal = bTotal + (value * key * df);
            }

            double abTotal = aTotal + bTotal;

            double cTotal = 0d;
            int totalCount = aCount + bCount;

            if(totalCount >= 26 && totalCount <= 40)
            {
                cTotal = (cTotal * 1) + 15000d;
            }
            else if(totalCount >= 41)
            {
                cTotal = (cTotal * 0.75) + 25000d;
            }
            else
            {
                cTotal = (rangeList[totalCount - 1, 2] * 100d) * 1000d; 
            }

            if (cTotal < abTotal)
                r = cTotal;
            else if (cTotal > abTotal)
                r = abTotal;
            else if (cTotal == abTotal)
                r = abTotal;

            return r;
        }

        // Dryer Demand Factor
        double DryerDemandFactor(int dryerCount)
        {
            if (dryerCount == 0)
                return 0;

            double df = 0d;

            if(dryerCount >= 1 && dryerCount <= 4)
            {
                df = 1d;
            }
            else if(dryerCount == 5)
            {
                df = 0.85d;
            }
            else if(dryerCount == 6)
            {
                df = 0.75d;
            }
            else if(dryerCount == 7)
            {
                df = 0.65;
            }
            else if (dryerCount == 8)
            {
                df = 0.6d;
            }
            else if (dryerCount == 9)
            {
                df = 0.55d;
            }
            else if (dryerCount == 10)
            {
                df = 5d;
            }
            else if (dryerCount == 11)
            {
                df = 0.47d;
            }
            else if (dryerCount >= 12 && dryerCount <= 22)
            {
                df = (double)((47 - (dryerCount - 11))/100);
            }
            else if(dryerCount == 23)
            {
                df = 0.35d;
            }
            else if (dryerCount >= 24 && dryerCount <= 42)
            {
                df = (double)((35 - (0.5 * (dryerCount - 23))) / 100);
            }
            else if(dryerCount >= 43)
            {
                df = 0.25;
            }

            return df;
        }

        // Convenience Demand Factor
        double ConvenienceDemandFactor(double totalCon)
        {
            if (totalCon == 0)
                return 0;

            return (totalCon <= 10000d) ? totalCon : 10000d + ((totalCon - 10000d) * 0.5d);
        }

        // Range Demand Factor for Non Dwelling
        double RangeDemandFactor(double rangeTotal, int units)
        {
            if (units == 0)
                return 0;

            double r = 0d;
            if (units == 1 || units == 2)
                r = rangeTotal;
            else if (units == 3)
                r = rangeTotal * 0.9d;
            else if (units == 4)
                r = rangeTotal * 0.8d;
            else if (units == 5)
                r = rangeTotal * 0.7d;
            else if (units >= 6)
                r = rangeTotal * 0.65d;

            return r;
        }
        
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CalculateMain m = mains[tabControl1.SelectedIndex];

                if (m.calculated == false)
                {
                    dwellingShowMainL1.Initialize();
                    dwellingShowMain1.Initialize();

                    return;
                }
                
                if(m.unitType == UnitType.None || m.unitType == UnitType.NonDwellingUnit)
                {
                    dwellingShowMainL1.BringToFront();

                    dwellingShowMainL1.Initialize(m.total_connected_load, m.LO, m.CO, m.RANGE, m.DRYER, m.ACU, m.MOTOR, m.OTHER_LOAD, m.SPARE, m.total_net_load, m.mainService, m.conductorAmpacity, m.conductorSize, m.breakerSize, Convert.ToInt32(m.AT), m.breakerType, phaseList[tabControl1.SelectedIndex], Convert.ToInt32(voltageValue[tabControl1.SelectedIndex]));
                }
                else if(m.unitType == UnitType.DwellingUnit)
                {
                    dwellingShowMain1.BringToFront();

                    dwellingShowMain1.Initialize(m.total_connected_load, m.LO + m.CO, m.RANGE, m.DRYER, m.ACU, m.MOTOR, m.OTHER_LOAD, m.SPARE, m.total_net_load, m.mainService, m.conductorAmpacity, m.conductorSize, m.breakerSize, Convert.ToInt32(m.AT), m.breakerType, phaseList[tabControl1.SelectedIndex], Convert.ToInt32(voltageValue[tabControl1.SelectedIndex]));
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gENERATEMAINDISTRIBUTIONPANELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach(CalculateMain m in mains)
                {
                    if (m.calculated == false)
                        throw new Exception("PLEASE CALCULATE ALL MAIN");
                }

                // get all total net load
                double totalNet = 0d;
                double totalConnected = 0d;
                double largestMotor = 0d;
                foreach(CalculateMain m in mains)
                {
                    totalNet = totalNet + m.total_net_load;
                    totalConnected += m.total_connected_load;

                    if (largestMotor < m.largestMotor)
                        largestMotor = m.largestMotor;
                }

                if(unitType == UnitType.NonDwellingUnit)
                {
                    DialogResult result = MessageBox.Show("DO YOU WANT TO CALCULATE NEW RESTAURANT", "NON-DWELLING MAIN DISTRIBUTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                        return;

                    phase.ShowDialog();

                    if (phase.closed)
                        return;

                    double volt = (phase.phaseType == PhaseType.SinglePhase) ? 230d : 400d;

                    double Ic = totalConnected * restaurantDemandFactor(totalConnected) / volt;
                    double Ib = totalConnected * restaurantDemandFactor(totalConnected) / volt;

                    ApplyBreaker applyBreaker = new ApplyBreaker();
                    applyBreaker.ShowDialog();

                    if (applyBreaker.close)
                        return;

                    ApplyMain applyMain = new ApplyMain();
                    applyMain.ShowDialog();

                    if (applyMain.close)
                        return;

                    string hotwire = (phase.phaseType == PhaseType.SinglePhase) ? "2-" : "3-";
                    string t = string.Empty;

                    if (applyMain.conductorWire == "TW")
                    {
                        t = TW("LO", (float)Ic);
                        hotwire = hotwire + t + " " + applyMain.conductorWire;
                    }
                    else if (applyMain.conductorWire == "THW")
                    {
                        t = THW("LO", (float)Ic);
                        hotwire = hotwire + t + " " + applyMain.conductorWire;
                    }
                    else if (applyMain.conductorWire == "THHN")
                    {
                        t = THHN("LO", (float)Ic);
                        hotwire = hotwire + t + " " + applyMain.conductorWire;
                    }

                    string breakerSize = string.Empty;

                    int at = ampereTrip("MAIN", Ib);

                    MainVoltageDrop mainVoltageDrop = new MainVoltageDrop(phaseList[tabControl1.SelectedIndex], t);
                    mainVoltageDrop.wireType = applyMain.breakerWire;
                    mainVoltageDrop.conduitType = applyMain.conduitType;
                    mainVoltageDrop.ampere = (float)Ic;

                    mainVoltageDrop.voltage = (int)volt;

                    do
                    {
                        mainVoltageDrop.ShowDialog();
                    }
                    while (!mainVoltageDrop.close);

                    string grounding = "1-" + groundingSize(at) + " " + applyMain.breakerWire;
                    breakerSize = grounding + " " + mainVoltageDrop.ConduitSize;

                    string temp = string.Empty;

                    if (applyBreaker.breaker == BreakerType.INSTANTANEOUS_TRIP)
                        temp = "INSTANTANEOUS TRIP CIRCUIT BREAKER";
                    else
                        temp = "INVERSE TIME CIRCUIT BREAKER";

                    string display = "USE " + hotwire + ", " + grounding + ", " + mainVoltageDrop.ConduitSize +
                                     "\n\nPROVIDE " + at.ToString() + " AT, " + temp + ", " + phase.phaseType + ", " + volt.ToString() + ", 60Hz";

                    MessageBox.Show(display, "NON-DWELLING MAIN DISTRIBUTION PANEL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if(unitType == UnitType.DwellingUnit)
                {
                    DialogResult result = MessageBox.Show("DO YOU WISH TO CALCULATE MULTIFAMILY DWELLING UNIT?", "DWELLING MAIN DISTRIBUTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                    {
                        phase.ShowDialog();

                        if (phase.cancelled)
                            return;

                        double volt = (phase.phaseType == PhaseType.SinglePhase) ? 230d : 400d;

                        double Ic = (totalNet + (0.25 * largestMotor)) / volt;

                        ApplyBreaker applyBreaker = new ApplyBreaker();
                        applyBreaker.ShowDialog();

                        if (applyBreaker.close)
                            return;

                        double Ib = (totalNet + (applyBreaker.percentage * largestMotor)) / volt;

                        ApplyMain applyMain = new ApplyMain();
                        applyMain.ShowDialog();

                        if (applyMain.close)
                            return;

                        string hotwire = (phaseList[tabControl1.SelectedIndex] == PhaseType.SinglePhase) ? "2-" : "3-";
                        string t = string.Empty;

                        if (applyMain.conductorWire == "TW")
                        {
                            t = TW("LO", (float)Ic);
                            hotwire = hotwire + t + " " + applyMain.conductorWire;
                        }
                        else if (applyMain.conductorWire == "THW")
                        {
                            t = THW("LO", (float)Ic);
                            hotwire = hotwire + t + " " + applyMain.conductorWire;
                        }
                        else if (applyMain.conductorWire == "THHN")
                        {
                            t = THHN("LO", (float)Ic);
                            hotwire = hotwire + t + " " + applyMain.conductorWire;
                        }

                        string breakerSize = string.Empty;

                        int at = ampereTrip("MAIN", Ib);

                        MainVoltageDrop mainVoltageDrop = new MainVoltageDrop(phaseList[tabControl1.SelectedIndex], t);
                        mainVoltageDrop.wireType = applyMain.breakerWire;
                        mainVoltageDrop.conduitType = applyMain.conduitType;
                        mainVoltageDrop.ampere = (float)Ic;

                        mainVoltageDrop.voltage = Convert.ToInt32(voltageValue[tabControl1.SelectedIndex]);

                        do
                        {
                            mainVoltageDrop.ShowDialog();
                        }
                        while (!mainVoltageDrop.close);

                        string grounding = "1-" + groundingSize(at) + " " + applyMain.breakerWire;
                        breakerSize = grounding + " " + mainVoltageDrop.ConduitSize;

                        string temp = string.Empty;

                        if (applyBreaker.breaker == BreakerType.INSTANTANEOUS_TRIP)
                            temp = "INSTANTANEOUS TRIP CIRCUIT BREAKER";
                        else
                            temp = "INVERSE TIME CIRCUIT BREAKER";

                        string display = "USE " + hotwire + ", " + grounding + ", " + mainVoltageDrop.ConduitSize +
                                         "\n\nPROVIDE " + at.ToString() + " AT, " + temp + ", " + phase.phaseType + ", " + volt.ToString() + ", 60Hz";

                        MessageBox.Show(display, "DWELLING MAIN DISTRIBUTION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        DwellingMDP dwellingMDP = new DwellingMDP();
                        dwellingMDP.ShowDialog();

                        if (dwellingMDP.cancel)
                            return;

                        phase.ShowDialog();

                        if (phase.closed)
                            return;

                        double volt = (phase.phaseType == PhaseType.SinglePhase) ? 230d : 400d;

                        double Ic = totalConnected * dwellingMDP.demandFactor / volt;
                        double Ib = totalConnected * dwellingMDP.demandFactor / volt;

                        ApplyBreaker applyBreaker = new ApplyBreaker();
                        applyBreaker.ShowDialog();

                        if (applyBreaker.close)
                            return;

                        ApplyMain applyMain = new ApplyMain();
                        applyMain.ShowDialog();

                        if (applyMain.close)
                            return;

                        string hotwire = (phase.phaseType == PhaseType.SinglePhase) ? "2-" : "3-";
                        string t = string.Empty;

                        if (applyMain.conductorWire == "TW")
                        {
                            t = TW("LO", (float)Ic);
                            hotwire = hotwire + t + " " + applyMain.conductorWire;
                        }
                        else if (applyMain.conductorWire == "THW")
                        {
                            t = THW("LO", (float)Ic);
                            hotwire = hotwire + t + " " + applyMain.conductorWire;
                        }
                        else if (applyMain.conductorWire == "THHN")
                        {
                            t = THHN("LO", (float)Ic);
                            hotwire = hotwire + t + " " + applyMain.conductorWire;
                        }

                        string breakerSize = string.Empty;

                        int at = ampereTrip("MAIN", Ib);

                        MainVoltageDrop mainVoltageDrop = new MainVoltageDrop(phaseList[tabControl1.SelectedIndex], t);
                        mainVoltageDrop.wireType = applyMain.breakerWire;
                        mainVoltageDrop.conduitType = applyMain.conduitType;
                        mainVoltageDrop.ampere = (float)Ic;

                        mainVoltageDrop.voltage = (int)volt;

                        do
                        {
                            mainVoltageDrop.ShowDialog();
                        }
                        while (!mainVoltageDrop.close);

                        string grounding = "1-" + groundingSize(at) + " " + applyMain.breakerWire;
                        breakerSize = grounding + " " + mainVoltageDrop.ConduitSize;

                        string temp = string.Empty;

                        if (applyBreaker.breaker == BreakerType.INSTANTANEOUS_TRIP)
                            temp = "INSTANTANEOUS TRIP CIRCUIT BREAKER";
                        else
                            temp = "INVERSE TIME CIRCUIT BREAKER";

                        string display = "USE " + hotwire + ", " + grounding + ", " + mainVoltageDrop.ConduitSize +
                                         "\n\nPROVIDE " + at.ToString() + " AT, " + temp + ", " + phase.phaseType + ", " + volt.ToString() + ", 60Hz";

                        MessageBox.Show(display, "DWELLING MAIN DISTRIBUTION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mainSingleLine_Click(object sender, EventArgs e)
        {
            try
            {
                if (mains[tabControl1.SelectedIndex].calculated == false)
                    throw new Exception("PLEASE CALCULATE THE MAIN OF THE CURRENT TAB!");

                
                PrintPreviewDialog pd = new PrintPreviewDialog();
                doc = new PrintDocument();

                doc.PrintPage += Doc_PrintPage;
                pd.Document = doc;

                if (pd.ShowDialog() == DialogResult.OK)
                    doc.Print();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            var grid = (Bunifu.Framework.UI.BunifuCustomDataGrid)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];

            int rowCount = grid.Rows.Count - 1;

            Image image = global::E_Sched.Properties.Resources.MAIN_POWER_SOURCE;

            e.Graphics.DrawImage(image, 20, 20, 100, 100);

            image = global::E_Sched.Properties.Resources.METER;
            e.Graphics.DrawImage(image, 140, 20, 100, 100);
            e.Graphics.DrawString("MAIN POWER SOURCE", new Font(FontFamily.GenericMonospace, 8, FontStyle.Regular), new SolidBrush(Color.Blue), 140, 20);

            var blackPen = new Pen(Color.Black, 3);

            e.Graphics.DrawLine(blackPen, 110, 70, 159, 70);

            image = global::E_Sched.Properties.Resources.CIRCUIT_BREAKER;
            image.RotateFlip(RotateFlipType.Rotate90FlipY);

            int y = doc.PrinterSettings.DefaultPageSettings.PaperSize.Height;
            int x = doc.PrinterSettings.DefaultPageSettings.PaperSize.Width;

            e.Graphics.DrawImage(image, (x / 2) - 20, 110, 100, 100);
            e.Graphics.DrawString(mains[tabControl1.SelectedIndex].AT + " AT", new Font(FontFamily.GenericMonospace, 8, FontStyle.Regular), new SolidBrush(Color.Blue), (x / 2) -20, 110);

            e.Graphics.DrawLine(blackPen, 225, 70, (x / 2) + 25, 70);
            e.Graphics.DrawLine(blackPen, (x / 2) + 24, 70, (x / 2) + 24, 115);

            int xPos = 150;
            int yPos = 220;

            var linePen = new Pen(Color.Red, 3);
            linePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            Image left = global::E_Sched.Properties.Resources.LEFT;
            Image right = global::E_Sched.Properties.Resources.RIGHT;

            Image arrowLeft = global::E_Sched.Properties.Resources.ARROW;
            arrowLeft.RotateFlip(RotateFlipType.Rotate180FlipY);

            Image arrowRight = global::E_Sched.Properties.Resources.ARROW;

            Image ground = global::E_Sched.Properties.Resources.GROUND;

            int r = rowCount - (rowCount / 2);

            int index = 0;

            circuits = branches[tabControl1.SelectedIndex];

            for (int i = 0; i < r; i++)
            {
                image = global::E_Sched.Properties.Resources.CIRCUIT_BREAKER;

                e.Graphics.DrawString(index.ToString() + ": " + circuits[index] + " - " + grid.Rows[i].Cells[13].Value.ToString() + " AT", new Font(FontFamily.GenericMonospace, 8, FontStyle.Regular), new SolidBrush(Color.Blue), xPos, yPos + 10);
                e.Graphics.DrawImage(image, xPos, yPos, 100, 100);
                e.Graphics.DrawImage(left, xPos - 110, (float)(yPos + 3) + 0.5f, 120, 100);
                e.Graphics.DrawImage(arrowLeft, xPos - 110, (float)(yPos + 60), 82, 60);
                
                e.Graphics.DrawLine(linePen, xPos - 35, yPos + 90, xPos - 35, yPos + 170);
                e.Graphics.DrawLine(linePen, x - 120, yPos + 90, x - 120, yPos + 170);

                if (index + 1 < rowCount)
                {

                    e.Graphics.DrawString((index + 1).ToString() + ": " + circuits[index] + " - " + grid.Rows[index + 1].Cells[13].Value.ToString() + " AT", new Font(FontFamily.GenericMonospace, 8, FontStyle.Regular), new SolidBrush(Color.Blue), x - 250, yPos + 10);
                    e.Graphics.DrawImage(image, x - 250, yPos, 100, 100);
                    e.Graphics.DrawImage(right, x - 163, (float)(yPos + 8) + 0.7f, 120, 100);
                    e.Graphics.DrawImage(arrowRight, x - 125, (float)(yPos + 60), 82, 60);
                    
                    e.Graphics.DrawLine(blackPen, xPos + 90, (float)(yPos + 55) + 0.5f, x - 240, (float)(yPos + 55) + 0.5f);
                }
                else
                {
                    e.Graphics.DrawLine(blackPen, xPos + 90, (float)(yPos + 55) + 0.5f, (x / 2) + 23, (float)(yPos + 55) + 0.5f);
                }
                

                if (i == r - 1)
                {
                    if(rowCount % 2 != 0)
                        e.Graphics.DrawLine(blackPen, (x / 2) + 23, 205, (x / 2) + 23, (float)(yPos + 60) + 0.5f);
                    else
                        e.Graphics.DrawLine(blackPen, (x / 2) + 23, 205, (x / 2) + 23, (float)(yPos + 55) + 0.5f);

                    e.Graphics.DrawImage(ground, (x / 2) - 30, yPos + 160, 100, 100);

                    e.Graphics.DrawLine(linePen, xPos - 35, yPos + 170, xPos + 265, yPos + 170);
                    e.Graphics.DrawLine(linePen, (x / 2) + 40, yPos + 170, x - 120, yPos + 170);

                    var bluePen = new Pen(Color.Blue);
                    bluePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

                    e.Graphics.DrawRectangle(bluePen, new Rectangle(xPos - 60, 200, 650, yPos + 50));
                }

                yPos += 80;
                index += 2;
            }
        }

        private void delRow_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.TabPages.Count == 0)
                    throw new Exception("THERE IS CURRENTLY NO TAB!");

                var grid = (Bunifu.Framework.UI.BunifuCustomDataGrid)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];

                if (grid.Rows.Count == 0)
                    throw new Exception("THERE IS CURRENTLY NO ROW TO DELETE IN THE CURRENT TAB!");

                if(grid.CurrentRow.Index == -1)
                    throw new Exception("PLEASE SELECT A ROW TO DELETE!");

                var r = MessageBox.Show("DO YOU WANT TO DELETE ROW 1?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.No)
                    return;

                if (grid.CurrentRow.Index == grid.RowCount - 1 && grid.Rows[grid.Rows.Count - 1].Cells[0].Value.ToString() == "TOTAL")
                {
                    grid.Rows.RemoveAt(grid.Rows.Count - 1);
                    mains[tabControl1.SelectedIndex].calculated = false;

                    dwellingShowMain1.Initialize();
                    dwellingShowMainL1.Initialize();

                    return;
                }
                
                if(grid.CurrentRow.Index == 0)
                {
                    var result = MessageBox.Show("DO YOU WANT TO DELETE ROW 1?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                        return;

                    grid.Rows.RemoveAt(0);

                    int index = 0;
                    foreach(DataGridViewRow row in grid.Rows)
                    {
                        if (row.Cells[0].Value.ToString() == "TOTAL")
                        {
                            branches[tabControl1.SelectedIndex].RemoveAt(0);

                            grid.Rows.RemoveAt(grid.Rows.Count - 1);
                            mains[tabControl1.SelectedIndex].calculated = false;

                            dwellingShowMain1.Initialize();
                            dwellingShowMainL1.Initialize();
                        }
                        else
                        {
                            row.Cells[0].Value = index;
                        }
                        index++;
                    }
                }
                else
                {
                    int index = grid.CurrentRow.Index;

                    var result = MessageBox.Show("DO YOU WANT TO DELETE ROW " + (index + 1).ToString() + "?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                        return;

                    grid.Rows.RemoveAt(index);

                    for(int i=index; i<grid.Rows.Count; i++)
                    {
                        if (grid.Rows[i].Cells[0].Value.ToString() == "TOTAL")
                        {
                            branches[tabControl1.SelectedIndex].RemoveAt(grid.Rows.Count - 1);

                            grid.Rows.RemoveAt(grid.Rows.Count - 1);
                            mains[tabControl1.SelectedIndex].calculated = false;

                            dwellingShowMain1.Initialize();
                            dwellingShowMainL1.Initialize();
                        }
                        else
                        {
                            grid.Rows[i].Cells[0].Value = index;
                        }
                        index++;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gENERATESERVICETRANSFORMERANDGENERATORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mains.Count == 0)
                    throw new Exception("THERE IS CURRENTLY NO TAB!");

                foreach (CalculateMain m in mains)
                {
                    if (m.calculated == false)
                        throw new Exception("PLEASE CALCULATE ALL MAIN IN EVERY TAB!");
                }

                double totalNetLoad = 0d;
                double totalConnectedLoad = 0d;

                foreach(CalculateMain m in mains)
                {
                    totalNetLoad += m.total_net_load;
                    totalConnectedLoad += m.total_connected_load;
                }

                double demandFactor = totalNetLoad / totalConnectedLoad;

                double totalApparentPower = (totalConnectedLoad * demandFactor) / 1000;

                MessageBox.Show("APPARENT POWER: " + totalApparentPower.ToString() + " kVA", "SERVICE TRANSFORMER AND GENERATOR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pRINTToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private double restaurantDemandFactor(double kVA)
        {
            if (kVA <= 200000)
                return kVA * 0.8;
            else if (kVA >= 201000 && kVA <= 325)
                return 0.1 * (kVA - 200000) + 160000;
            else if (kVA >= 326000 && kVA <= 800000)
                return 0.5 * (kVA - 325000) + 172000;

            return 0.5 * (kVA - 800000) + 410000;
        }
    }
}