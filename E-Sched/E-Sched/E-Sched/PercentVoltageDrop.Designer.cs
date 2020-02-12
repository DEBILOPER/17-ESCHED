namespace E_Sched
{
    partial class PercentVoltageDrop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PercentVoltageDrop));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bunifuProgressBar1 = new Bunifu.Framework.UI.BunifuProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sizeLabel = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuLabel9 = new Bunifu.UI.WinForms.BunifuLabel();
            this.resistance = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.bunifuLabel7 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuLabel6 = new Bunifu.UI.WinForms.BunifuLabel();
            this.length = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.conduitSizeLabel = new Bunifu.UI.WinForms.BunifuLabel();
            this.conduitSizeGrid = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.resistanceGrid = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.bunifuFlatButton2 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.ok_Btn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.wireLabel = new Bunifu.UI.WinForms.BunifuLabel();
            this.racewaySize = new Bunifu.UI.WinForms.BunifuLabel();
            ((System.ComponentModel.ISupportInitialize)(this.conduitSizeGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resistanceGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuProgressBar1
            // 
            this.bunifuProgressBar1.BackColor = System.Drawing.Color.Silver;
            this.bunifuProgressBar1.BorderRadius = 5;
            this.bunifuProgressBar1.Location = new System.Drawing.Point(-11, 40);
            this.bunifuProgressBar1.MaximumValue = 100;
            this.bunifuProgressBar1.Name = "bunifuProgressBar1";
            this.bunifuProgressBar1.ProgressColor = System.Drawing.Color.Teal;
            this.bunifuProgressBar1.Size = new System.Drawing.Size(1042, 10);
            this.bunifuProgressBar1.TabIndex = 47;
            this.bunifuProgressBar1.Value = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 39);
            this.panel1.TabIndex = 46;
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoEllipsis = false;
            this.sizeLabel.CursorType = null;
            this.sizeLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.sizeLabel.ForeColor = System.Drawing.Color.White;
            this.sizeLabel.Location = new System.Drawing.Point(21, 90);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sizeLabel.Size = new System.Drawing.Size(97, 18);
            this.sizeLabel.TabIndex = 57;
            this.sizeLabel.Text = "HOT WIRE SIZE:";
            this.sizeLabel.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.sizeLabel.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuLabel9
            // 
            this.bunifuLabel9.AutoEllipsis = false;
            this.bunifuLabel9.CursorType = null;
            this.bunifuLabel9.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.bunifuLabel9.ForeColor = System.Drawing.Color.White;
            this.bunifuLabel9.Location = new System.Drawing.Point(14, 437);
            this.bunifuLabel9.Name = "bunifuLabel9";
            this.bunifuLabel9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel9.Size = new System.Drawing.Size(103, 18);
            this.bunifuLabel9.TabIndex = 73;
            this.bunifuLabel9.Text = "AC RESISTANCE";
            this.bunifuLabel9.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel9.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // resistance
            // 
            this.resistance.BackColor = System.Drawing.Color.White;
            this.resistance.BorderColorFocused = System.Drawing.Color.Blue;
            this.resistance.BorderColorIdle = System.Drawing.Color.White;
            this.resistance.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.resistance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.resistance.BorderThickness = 3;
            this.resistance.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.resistance.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.resistance.ForeColor = System.Drawing.Color.Black;
            this.resistance.isPassword = false;
            this.resistance.Location = new System.Drawing.Point(133, 424);
            this.resistance.Margin = new System.Windows.Forms.Padding(4);
            this.resistance.Name = "resistance";
            this.resistance.Size = new System.Drawing.Size(252, 44);
            this.resistance.TabIndex = 72;
            this.resistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuLabel7
            // 
            this.bunifuLabel7.AutoEllipsis = false;
            this.bunifuLabel7.CursorType = null;
            this.bunifuLabel7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.bunifuLabel7.ForeColor = System.Drawing.Color.White;
            this.bunifuLabel7.Location = new System.Drawing.Point(15, 385);
            this.bunifuLabel7.Name = "bunifuLabel7";
            this.bunifuLabel7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel7.Size = new System.Drawing.Size(78, 18);
            this.bunifuLabel7.TabIndex = 71;
            this.bunifuLabel7.Text = "LENGTH (m)";
            this.bunifuLabel7.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel7.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuLabel6
            // 
            this.bunifuLabel6.AutoEllipsis = false;
            this.bunifuLabel6.CursorType = null;
            this.bunifuLabel6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.bunifuLabel6.ForeColor = System.Drawing.Color.Yellow;
            this.bunifuLabel6.Location = new System.Drawing.Point(15, 338);
            this.bunifuLabel6.Name = "bunifuLabel6";
            this.bunifuLabel6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel6.Size = new System.Drawing.Size(197, 18);
            this.bunifuLabel6.TabIndex = 70;
            this.bunifuLabel6.Text = "VOLTAGE DROP CALCULATION";
            this.bunifuLabel6.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel6.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // length
            // 
            this.length.BackColor = System.Drawing.Color.White;
            this.length.BorderColorFocused = System.Drawing.Color.Blue;
            this.length.BorderColorIdle = System.Drawing.Color.White;
            this.length.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.length.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.length.BorderThickness = 3;
            this.length.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.length.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.length.ForeColor = System.Drawing.Color.Black;
            this.length.isPassword = false;
            this.length.Location = new System.Drawing.Point(133, 372);
            this.length.Margin = new System.Windows.Forms.Padding(4);
            this.length.Name = "length";
            this.length.Size = new System.Drawing.Size(252, 44);
            this.length.TabIndex = 69;
            this.length.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // conduitSizeLabel
            // 
            this.conduitSizeLabel.AutoEllipsis = false;
            this.conduitSizeLabel.CursorType = null;
            this.conduitSizeLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.conduitSizeLabel.ForeColor = System.Drawing.Color.White;
            this.conduitSizeLabel.Location = new System.Drawing.Point(21, 150);
            this.conduitSizeLabel.Name = "conduitSizeLabel";
            this.conduitSizeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.conduitSizeLabel.Size = new System.Drawing.Size(94, 18);
            this.conduitSizeLabel.TabIndex = 76;
            this.conduitSizeLabel.Text = "CONDUIT SIZE:";
            this.conduitSizeLabel.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.conduitSizeLabel.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // conduitSizeGrid
            // 
            this.conduitSizeGrid.AllowUserToAddRows = false;
            this.conduitSizeGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.conduitSizeGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.conduitSizeGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.conduitSizeGrid.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.conduitSizeGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.conduitSizeGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.conduitSizeGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.conduitSizeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.conduitSizeGrid.DoubleBuffered = true;
            this.conduitSizeGrid.EnableHeadersVisualStyles = false;
            this.conduitSizeGrid.HeaderBgColor = System.Drawing.Color.SeaGreen;
            this.conduitSizeGrid.HeaderForeColor = System.Drawing.Color.Black;
            this.conduitSizeGrid.Location = new System.Drawing.Point(444, 114);
            this.conduitSizeGrid.Name = "conduitSizeGrid";
            this.conduitSizeGrid.ReadOnly = true;
            this.conduitSizeGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.conduitSizeGrid.Size = new System.Drawing.Size(552, 199);
            this.conduitSizeGrid.TabIndex = 77;
            this.conduitSizeGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.conduitSizeGrid_CellClick);
            this.conduitSizeGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.conduitSizeGrid_CellContentClick);
            // 
            // resistanceGrid
            // 
            this.resistanceGrid.AllowUserToAddRows = false;
            this.resistanceGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.resistanceGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.resistanceGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.resistanceGrid.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.resistanceGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.resistanceGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.resistanceGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.resistanceGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resistanceGrid.DoubleBuffered = true;
            this.resistanceGrid.EnableHeadersVisualStyles = false;
            this.resistanceGrid.HeaderBgColor = System.Drawing.Color.SeaGreen;
            this.resistanceGrid.HeaderForeColor = System.Drawing.Color.Black;
            this.resistanceGrid.Location = new System.Drawing.Point(444, 338);
            this.resistanceGrid.Name = "resistanceGrid";
            this.resistanceGrid.ReadOnly = true;
            this.resistanceGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.resistanceGrid.Size = new System.Drawing.Size(552, 199);
            this.resistanceGrid.TabIndex = 78;
            this.resistanceGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.resistanceGrid_CellContentClick);
            this.resistanceGrid.Click += new System.EventHandler(this.resistanceGrid_Click);
            // 
            // bunifuFlatButton2
            // 
            this.bunifuFlatButton2.Activecolor = System.Drawing.Color.Red;
            this.bunifuFlatButton2.BackColor = System.Drawing.Color.Red;
            this.bunifuFlatButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton2.BorderRadius = 0;
            this.bunifuFlatButton2.ButtonText = "CANCEL";
            this.bunifuFlatButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton2.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton2.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton2.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuFlatButton2.Iconimage")));
            this.bunifuFlatButton2.Iconimage_right = null;
            this.bunifuFlatButton2.Iconimage_right_Selected = null;
            this.bunifuFlatButton2.Iconimage_Selected = null;
            this.bunifuFlatButton2.IconMarginLeft = 0;
            this.bunifuFlatButton2.IconMarginRight = 0;
            this.bunifuFlatButton2.IconRightVisible = true;
            this.bunifuFlatButton2.IconRightZoom = 0D;
            this.bunifuFlatButton2.IconVisible = true;
            this.bunifuFlatButton2.IconZoom = 90D;
            this.bunifuFlatButton2.IsTab = false;
            this.bunifuFlatButton2.Location = new System.Drawing.Point(780, 548);
            this.bunifuFlatButton2.Name = "bunifuFlatButton2";
            this.bunifuFlatButton2.Normalcolor = System.Drawing.Color.Red;
            this.bunifuFlatButton2.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.bunifuFlatButton2.OnHoverTextColor = System.Drawing.Color.DimGray;
            this.bunifuFlatButton2.selected = false;
            this.bunifuFlatButton2.Size = new System.Drawing.Size(118, 48);
            this.bunifuFlatButton2.TabIndex = 80;
            this.bunifuFlatButton2.Text = "CANCEL";
            this.bunifuFlatButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton2.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatButton2.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton2.Click += new System.EventHandler(this.bunifuFlatButton2_Click);
            // 
            // ok_Btn
            // 
            this.ok_Btn.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.ok_Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.ok_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ok_Btn.BorderRadius = 0;
            this.ok_Btn.ButtonText = "OK";
            this.ok_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ok_Btn.DisabledColor = System.Drawing.Color.Gray;
            this.ok_Btn.Iconcolor = System.Drawing.Color.Transparent;
            this.ok_Btn.Iconimage = ((System.Drawing.Image)(resources.GetObject("ok_Btn.Iconimage")));
            this.ok_Btn.Iconimage_right = null;
            this.ok_Btn.Iconimage_right_Selected = null;
            this.ok_Btn.Iconimage_Selected = null;
            this.ok_Btn.IconMarginLeft = 0;
            this.ok_Btn.IconMarginRight = 0;
            this.ok_Btn.IconRightVisible = true;
            this.ok_Btn.IconRightZoom = 0D;
            this.ok_Btn.IconVisible = true;
            this.ok_Btn.IconZoom = 90D;
            this.ok_Btn.IsTab = false;
            this.ok_Btn.Location = new System.Drawing.Point(904, 548);
            this.ok_Btn.Name = "ok_Btn";
            this.ok_Btn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.ok_Btn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.ok_Btn.OnHoverTextColor = System.Drawing.Color.White;
            this.ok_Btn.selected = false;
            this.ok_Btn.Size = new System.Drawing.Size(92, 48);
            this.ok_Btn.TabIndex = 79;
            this.ok_Btn.Text = "OK";
            this.ok_Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ok_Btn.Textcolor = System.Drawing.Color.White;
            this.ok_Btn.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ok_Btn.Click += new System.EventHandler(this.ok_Btn_Click);
            // 
            // wireLabel
            // 
            this.wireLabel.AutoEllipsis = false;
            this.wireLabel.CursorType = null;
            this.wireLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.wireLabel.ForeColor = System.Drawing.Color.White;
            this.wireLabel.Location = new System.Drawing.Point(444, 56);
            this.wireLabel.Name = "wireLabel";
            this.wireLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.wireLabel.Size = new System.Drawing.Size(70, 18);
            this.wireLabel.TabIndex = 81;
            this.wireLabel.Text = "WIRE TYPE: ";
            this.wireLabel.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.wireLabel.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // racewaySize
            // 
            this.racewaySize.AutoEllipsis = false;
            this.racewaySize.CursorType = null;
            this.racewaySize.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.racewaySize.ForeColor = System.Drawing.Color.White;
            this.racewaySize.Location = new System.Drawing.Point(691, 90);
            this.racewaySize.Name = "racewaySize";
            this.racewaySize.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.racewaySize.Size = new System.Drawing.Size(135, 18);
            this.racewaySize.TabIndex = 82;
            this.racewaySize.Text = "RACEWAY SIZE (mm)";
            this.racewaySize.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.racewaySize.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // PercentVoltageDrop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(1008, 608);
            this.Controls.Add(this.racewaySize);
            this.Controls.Add(this.wireLabel);
            this.Controls.Add(this.bunifuFlatButton2);
            this.Controls.Add(this.ok_Btn);
            this.Controls.Add(this.resistanceGrid);
            this.Controls.Add(this.conduitSizeGrid);
            this.Controls.Add(this.conduitSizeLabel);
            this.Controls.Add(this.bunifuLabel9);
            this.Controls.Add(this.resistance);
            this.Controls.Add(this.bunifuLabel7);
            this.Controls.Add(this.bunifuLabel6);
            this.Controls.Add(this.length);
            this.Controls.Add(this.sizeLabel);
            this.Controls.Add(this.bunifuProgressBar1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PercentVoltageDrop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PercentVoltageDrop";
            this.Load += new System.EventHandler(this.PercentVoltageDrop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.conduitSizeGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resistanceGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuProgressBar bunifuProgressBar1;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.UI.WinForms.BunifuLabel sizeLabel;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel9;
        private Bunifu.Framework.UI.BunifuMetroTextbox resistance;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel7;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel6;
        private Bunifu.Framework.UI.BunifuMetroTextbox length;
        private Bunifu.UI.WinForms.BunifuLabel conduitSizeLabel;
        private Bunifu.Framework.UI.BunifuCustomDataGrid conduitSizeGrid;
        private Bunifu.Framework.UI.BunifuCustomDataGrid resistanceGrid;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton2;
        private Bunifu.Framework.UI.BunifuFlatButton ok_Btn;
        private Bunifu.UI.WinForms.BunifuLabel wireLabel;
        private Bunifu.UI.WinForms.BunifuLabel racewaySize;
    }
}