namespace E_Sched
{
    partial class Schedule
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Schedule));
            this.bunifuProgressBar1 = new Bunifu.Framework.UI.BunifuProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.exit_Btn = new Bunifu.Framework.UI.BunifuImageButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sAVEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eXITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tOOLSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gENERATEMAINDISTRIBUTIONPANELToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.illuminationToolStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gENERATESERVICETRANSFORMERANDGENERATORToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.mainTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.addTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.branchTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.mainSingleTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.delRow = new Bunifu.Framework.UI.BunifuImageButton();
            this.mainSingleLine = new Bunifu.Framework.UI.BunifuImageButton();
            this.calculateMain = new Bunifu.Framework.UI.BunifuImageButton();
            this.printTable = new Bunifu.Framework.UI.BunifuImageButton();
            this.addTab_btn = new Bunifu.Framework.UI.BunifuImageButton();
            this.addBranchCircuit_Btn = new Bunifu.Framework.UI.BunifuImageButton();
            this.deleteRowTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.dwellingShowMainL1 = new E_Sched.DwellingShowMainL();
            this.dwellingShowMain1 = new E_Sched.DwellingShowMain();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exit_Btn)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainSingleLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calculateMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addTab_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addBranchCircuit_Btn)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuProgressBar1
            // 
            this.bunifuProgressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuProgressBar1.BackColor = System.Drawing.Color.Silver;
            this.bunifuProgressBar1.BorderRadius = 5;
            this.bunifuProgressBar1.Location = new System.Drawing.Point(-18, 40);
            this.bunifuProgressBar1.MaximumValue = 100;
            this.bunifuProgressBar1.Name = "bunifuProgressBar1";
            this.bunifuProgressBar1.ProgressColor = System.Drawing.Color.Teal;
            this.bunifuProgressBar1.Size = new System.Drawing.Size(1304, 10);
            this.bunifuProgressBar1.TabIndex = 21;
            this.bunifuProgressBar1.Value = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.exit_Btn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1274, 39);
            this.panel1.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(10, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "E-SCHED";
            // 
            // exit_Btn
            // 
            this.exit_Btn.BackColor = System.Drawing.Color.Transparent;
            this.exit_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.exit_Btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.exit_Btn.Image = global::E_Sched.Properties.Resources.Close_Button_1;
            this.exit_Btn.ImageActive = null;
            this.exit_Btn.Location = new System.Drawing.Point(1228, 0);
            this.exit_Btn.Name = "exit_Btn";
            this.exit_Btn.Size = new System.Drawing.Size(46, 39);
            this.exit_Btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.exit_Btn.TabIndex = 2;
            this.exit_Btn.TabStop = false;
            this.exit_Btn.Zoom = 10;
            this.exit_Btn.Click += new System.EventHandler(this.exit_Btn_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Location = new System.Drawing.Point(13, 123);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1249, 188);
            this.tabControl1.TabIndex = 27;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fILEToolStripMenuItem,
            this.tOOLSToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(13, 53);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(107, 24);
            this.menuStrip1.TabIndex = 28;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fILEToolStripMenuItem
            // 
            this.fILEToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.fILEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sAVEToolStripMenuItem,
            this.eXITToolStripMenuItem});
            this.fILEToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fILEToolStripMenuItem.Name = "fILEToolStripMenuItem";
            this.fILEToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.fILEToolStripMenuItem.Text = "FILE";
            // 
            // sAVEToolStripMenuItem
            // 
            this.sAVEToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.sAVEToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.sAVEToolStripMenuItem.Name = "sAVEToolStripMenuItem";
            this.sAVEToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.sAVEToolStripMenuItem.Text = "SAVE";
            this.sAVEToolStripMenuItem.Click += new System.EventHandler(this.sAVEToolStripMenuItem_Click);
            // 
            // eXITToolStripMenuItem
            // 
            this.eXITToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.eXITToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.eXITToolStripMenuItem.Name = "eXITToolStripMenuItem";
            this.eXITToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.eXITToolStripMenuItem.Text = "EXIT";
            this.eXITToolStripMenuItem.Click += new System.EventHandler(this.eXITToolStripMenuItem_Click);
            // 
            // tOOLSToolStripMenuItem
            // 
            this.tOOLSToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.tOOLSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gENERATEMAINDISTRIBUTIONPANELToolStripMenuItem,
            this.illuminationToolStripItem,
            this.gENERATESERVICETRANSFORMERANDGENERATORToolStripMenuItem});
            this.tOOLSToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.tOOLSToolStripMenuItem.Name = "tOOLSToolStripMenuItem";
            this.tOOLSToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.tOOLSToolStripMenuItem.Text = "TOOLS";
            // 
            // gENERATEMAINDISTRIBUTIONPANELToolStripMenuItem
            // 
            this.gENERATEMAINDISTRIBUTIONPANELToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.gENERATEMAINDISTRIBUTIONPANELToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.gENERATEMAINDISTRIBUTIONPANELToolStripMenuItem.Name = "gENERATEMAINDISTRIBUTIONPANELToolStripMenuItem";
            this.gENERATEMAINDISTRIBUTIONPANELToolStripMenuItem.Size = new System.Drawing.Size(358, 22);
            this.gENERATEMAINDISTRIBUTIONPANELToolStripMenuItem.Text = "GENERATE MAIN DISTRIBUTION PANEL";
            this.gENERATEMAINDISTRIBUTIONPANELToolStripMenuItem.Click += new System.EventHandler(this.gENERATEMAINDISTRIBUTIONPANELToolStripMenuItem_Click);
            // 
            // illuminationToolStripItem
            // 
            this.illuminationToolStripItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.illuminationToolStripItem.ForeColor = System.Drawing.Color.White;
            this.illuminationToolStripItem.Name = "illuminationToolStripItem";
            this.illuminationToolStripItem.Size = new System.Drawing.Size(358, 22);
            this.illuminationToolStripItem.Text = "ILLUMINATION CALCULATION";
            this.illuminationToolStripItem.Click += new System.EventHandler(this.illuminationToolStripItem_Click);
            // 
            // gENERATESERVICETRANSFORMERANDGENERATORToolStripMenuItem
            // 
            this.gENERATESERVICETRANSFORMERANDGENERATORToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.gENERATESERVICETRANSFORMERANDGENERATORToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.gENERATESERVICETRANSFORMERANDGENERATORToolStripMenuItem.Name = "gENERATESERVICETRANSFORMERANDGENERATORToolStripMenuItem";
            this.gENERATESERVICETRANSFORMERANDGENERATORToolStripMenuItem.Size = new System.Drawing.Size(358, 22);
            this.gENERATESERVICETRANSFORMERANDGENERATORToolStripMenuItem.Text = "GENERATE SERVICE TRANSFORMER AND GENERATOR";
            this.gENERATESERVICETRANSFORMERANDGENERATORToolStripMenuItem.Click += new System.EventHandler(this.gENERATESERVICETRANSFORMERANDGENERATORToolStripMenuItem_Click);
            // 
            // printTooltip
            // 
            this.printTooltip.IsBalloon = true;
            this.printTooltip.ToolTipTitle = "PRINT TABLE";
            // 
            // mainTooltip
            // 
            this.mainTooltip.IsBalloon = true;
            this.mainTooltip.ToolTipTitle = "CALCULATE MAIN";
            // 
            // addTooltip
            // 
            this.addTooltip.IsBalloon = true;
            this.addTooltip.ToolTipTitle = "ADD TAB";
            // 
            // branchTooltip
            // 
            this.branchTooltip.IsBalloon = true;
            this.branchTooltip.ToolTipTitle = "ADD BRANCH CIRCUIT";
            // 
            // mainSingleTooltip
            // 
            this.mainSingleTooltip.IsBalloon = true;
            this.mainSingleTooltip.ToolTipTitle = "SINGLE LINE DIAGRAM";
            // 
            // delRow
            // 
            this.delRow.BackColor = System.Drawing.Color.Transparent;
            this.delRow.Image = global::E_Sched.Properties.Resources.delete_row;
            this.delRow.ImageActive = null;
            this.delRow.Location = new System.Drawing.Point(147, 84);
            this.delRow.Name = "delRow";
            this.delRow.Size = new System.Drawing.Size(39, 33);
            this.delRow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.delRow.TabIndex = 36;
            this.delRow.TabStop = false;
            this.delRow.Zoom = 10;
            this.delRow.Click += new System.EventHandler(this.delRow_Click);
            // 
            // mainSingleLine
            // 
            this.mainSingleLine.BackColor = System.Drawing.Color.Transparent;
            this.mainSingleLine.Image = global::E_Sched.Properties.Resources.open_icon_1;
            this.mainSingleLine.ImageActive = null;
            this.mainSingleLine.Location = new System.Drawing.Point(237, 84);
            this.mainSingleLine.Name = "mainSingleLine";
            this.mainSingleLine.Size = new System.Drawing.Size(39, 33);
            this.mainSingleLine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.mainSingleLine.TabIndex = 35;
            this.mainSingleLine.TabStop = false;
            this.mainSingleLine.Zoom = 10;
            this.mainSingleLine.Click += new System.EventHandler(this.mainSingleLine_Click);
            // 
            // calculateMain
            // 
            this.calculateMain.BackColor = System.Drawing.Color.Transparent;
            this.calculateMain.Image = global::E_Sched.Properties.Resources.pencil_1_;
            this.calculateMain.ImageActive = null;
            this.calculateMain.Location = new System.Drawing.Point(192, 84);
            this.calculateMain.Name = "calculateMain";
            this.calculateMain.Size = new System.Drawing.Size(39, 33);
            this.calculateMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.calculateMain.TabIndex = 32;
            this.calculateMain.TabStop = false;
            this.calculateMain.Zoom = 10;
            this.calculateMain.Click += new System.EventHandler(this.calculateMain_Click);
            // 
            // printTable
            // 
            this.printTable.BackColor = System.Drawing.Color.Transparent;
            this.printTable.Image = global::E_Sched.Properties.Resources.open_icon_1;
            this.printTable.ImageActive = null;
            this.printTable.Location = new System.Drawing.Point(102, 84);
            this.printTable.Name = "printTable";
            this.printTable.Size = new System.Drawing.Size(39, 33);
            this.printTable.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.printTable.TabIndex = 31;
            this.printTable.TabStop = false;
            this.printTable.Zoom = 10;
            this.printTable.Click += new System.EventHandler(this.printTable_Click);
            // 
            // addTab_btn
            // 
            this.addTab_btn.BackColor = System.Drawing.Color.Transparent;
            this.addTab_btn.Image = global::E_Sched.Properties.Resources.add_icon_2;
            this.addTab_btn.ImageActive = null;
            this.addTab_btn.Location = new System.Drawing.Point(12, 84);
            this.addTab_btn.Name = "addTab_btn";
            this.addTab_btn.Size = new System.Drawing.Size(39, 33);
            this.addTab_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.addTab_btn.TabIndex = 26;
            this.addTab_btn.TabStop = false;
            this.addTab_btn.Zoom = 10;
            this.addTab_btn.Click += new System.EventHandler(this.addTab_btn_Click);
            // 
            // addBranchCircuit_Btn
            // 
            this.addBranchCircuit_Btn.BackColor = System.Drawing.Color.Transparent;
            this.addBranchCircuit_Btn.Image = ((System.Drawing.Image)(resources.GetObject("addBranchCircuit_Btn.Image")));
            this.addBranchCircuit_Btn.ImageActive = null;
            this.addBranchCircuit_Btn.Location = new System.Drawing.Point(57, 84);
            this.addBranchCircuit_Btn.Name = "addBranchCircuit_Btn";
            this.addBranchCircuit_Btn.Size = new System.Drawing.Size(39, 33);
            this.addBranchCircuit_Btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.addBranchCircuit_Btn.TabIndex = 24;
            this.addBranchCircuit_Btn.TabStop = false;
            this.addBranchCircuit_Btn.Zoom = 10;
            this.addBranchCircuit_Btn.Click += new System.EventHandler(this.addBranchCircuit_Btn_Click);
            // 
            // deleteRowTooltip
            // 
            this.deleteRowTooltip.IsBalloon = true;
            this.deleteRowTooltip.ToolTipTitle = "DELETE ROW";
            // 
            // dwellingShowMainL1
            // 
            this.dwellingShowMainL1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dwellingShowMainL1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.dwellingShowMainL1.Location = new System.Drawing.Point(13, 317);
            this.dwellingShowMainL1.Name = "dwellingShowMainL1";
            this.dwellingShowMainL1.Size = new System.Drawing.Size(459, 270);
            this.dwellingShowMainL1.TabIndex = 34;
            // 
            // dwellingShowMain1
            // 
            this.dwellingShowMain1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dwellingShowMain1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.dwellingShowMain1.Location = new System.Drawing.Point(12, 317);
            this.dwellingShowMain1.Name = "dwellingShowMain1";
            this.dwellingShowMain1.Size = new System.Drawing.Size(460, 270);
            this.dwellingShowMain1.TabIndex = 33;
            // 
            // Schedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1274, 594);
            this.Controls.Add(this.delRow);
            this.Controls.Add(this.mainSingleLine);
            this.Controls.Add(this.dwellingShowMainL1);
            this.Controls.Add(this.dwellingShowMain1);
            this.Controls.Add(this.calculateMain);
            this.Controls.Add(this.printTable);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.addTab_btn);
            this.Controls.Add(this.addBranchCircuit_Btn);
            this.Controls.Add(this.bunifuProgressBar1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Schedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schedule";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Schedule_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exit_Btn)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainSingleLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calculateMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addTab_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addBranchCircuit_Btn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuProgressBar bunifuProgressBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuImageButton exit_Btn;
        private Bunifu.Framework.UI.BunifuImageButton addBranchCircuit_Btn;
        private Bunifu.Framework.UI.BunifuImageButton addTab_btn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tOOLSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gENERATEMAINDISTRIBUTIONPANELToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem illuminationToolStripItem;
        private Bunifu.Framework.UI.BunifuImageButton printTable;
        private Bunifu.Framework.UI.BunifuImageButton calculateMain;
        private DwellingShowMain dwellingShowMain1;
        private System.Windows.Forms.ToolTip printTooltip;
        private System.Windows.Forms.ToolTip mainTooltip;
        private System.Windows.Forms.ToolTip addTooltip;
        private System.Windows.Forms.ToolTip branchTooltip;
        private DwellingShowMainL dwellingShowMainL1;
        private Bunifu.Framework.UI.BunifuImageButton mainSingleLine;
        private System.Windows.Forms.ToolTip mainSingleTooltip;
        private Bunifu.Framework.UI.BunifuImageButton delRow;
        private System.Windows.Forms.ToolStripMenuItem gENERATESERVICETRANSFORMERANDGENERATORToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sAVEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eXITToolStripMenuItem;
        private System.Windows.Forms.ToolTip deleteRowTooltip;
    }
}