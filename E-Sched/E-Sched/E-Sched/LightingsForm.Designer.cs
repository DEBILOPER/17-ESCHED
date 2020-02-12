namespace E_Sched
{
    partial class LightingsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LightingsForm));
            this.bunifuProgressBar1 = new Bunifu.Framework.UI.BunifuProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.exit_Btn = new Bunifu.Framework.UI.BunifuImageButton();
            this.dataGridView = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.NO_OF_LAMPS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WATTS_PER_LAMP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCRIPTION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cancel = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuFlatButton1 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.remove_Btn = new Bunifu.Framework.UI.BunifuImageButton();
            this.add_Btn = new Bunifu.Framework.UI.BunifuImageButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exit_Btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.remove_Btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.add_Btn)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuProgressBar1
            // 
            this.bunifuProgressBar1.BackColor = System.Drawing.Color.Silver;
            this.bunifuProgressBar1.BorderRadius = 5;
            this.bunifuProgressBar1.Location = new System.Drawing.Point(-12, 40);
            this.bunifuProgressBar1.MaximumValue = 100;
            this.bunifuProgressBar1.Name = "bunifuProgressBar1";
            this.bunifuProgressBar1.ProgressColor = System.Drawing.Color.Teal;
            this.bunifuProgressBar1.Size = new System.Drawing.Size(712, 10);
            this.bunifuProgressBar1.TabIndex = 5;
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
            this.panel1.Size = new System.Drawing.Size(669, 39);
            this.panel1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(10, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "LIGHTINGS";
            // 
            // exit_Btn
            // 
            this.exit_Btn.BackColor = System.Drawing.Color.Transparent;
            this.exit_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.exit_Btn.Image = global::E_Sched.Properties.Resources.Close_Button_1;
            this.exit_Btn.ImageActive = null;
            this.exit_Btn.Location = new System.Drawing.Point(623, 0);
            this.exit_Btn.Name = "exit_Btn";
            this.exit_Btn.Size = new System.Drawing.Size(46, 39);
            this.exit_Btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.exit_Btn.TabIndex = 2;
            this.exit_Btn.TabStop = false;
            this.exit_Btn.Zoom = 10;
            this.exit_Btn.Click += new System.EventHandler(this.exit_Btn_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NO_OF_LAMPS,
            this.WATTS_PER_LAMP,
            this.DESCRIPTION});
            this.dataGridView.DoubleBuffered = true;
            this.dataGridView.EnableHeadersVisualStyles = false;
            this.dataGridView.HeaderBgColor = System.Drawing.Color.SeaGreen;
            this.dataGridView.HeaderForeColor = System.Drawing.Color.Black;
            this.dataGridView.Location = new System.Drawing.Point(12, 102);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView.Size = new System.Drawing.Size(645, 199);
            this.dataGridView.TabIndex = 6;
            this.dataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellValueChanged);
            this.dataGridView.CurrentCellChanged += new System.EventHandler(this.dataGridView_CurrentCellChanged);
            // 
            // NO_OF_LAMPS
            // 
            this.NO_OF_LAMPS.HeaderText = "NO. OF LAMPS";
            this.NO_OF_LAMPS.Name = "NO_OF_LAMPS";
            // 
            // WATTS_PER_LAMP
            // 
            this.WATTS_PER_LAMP.HeaderText = "WATTS PER LAMP";
            this.WATTS_PER_LAMP.Name = "WATTS_PER_LAMP";
            // 
            // DESCRIPTION
            // 
            this.DESCRIPTION.HeaderText = "DESCRIPTION";
            this.DESCRIPTION.Name = "DESCRIPTION";
            // 
            // cancel
            // 
            this.cancel.Activecolor = System.Drawing.Color.Red;
            this.cancel.BackColor = System.Drawing.Color.Red;
            this.cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cancel.BorderRadius = 0;
            this.cancel.ButtonText = "CANCEL";
            this.cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancel.DisabledColor = System.Drawing.Color.Gray;
            this.cancel.Iconcolor = System.Drawing.Color.Transparent;
            this.cancel.Iconimage = ((System.Drawing.Image)(resources.GetObject("cancel.Iconimage")));
            this.cancel.Iconimage_right = null;
            this.cancel.Iconimage_right_Selected = null;
            this.cancel.Iconimage_Selected = null;
            this.cancel.IconMarginLeft = 0;
            this.cancel.IconMarginRight = 0;
            this.cancel.IconRightVisible = true;
            this.cancel.IconRightZoom = 0D;
            this.cancel.IconVisible = true;
            this.cancel.IconZoom = 90D;
            this.cancel.IsTab = false;
            this.cancel.Location = new System.Drawing.Point(441, 309);
            this.cancel.Name = "cancel";
            this.cancel.Normalcolor = System.Drawing.Color.Red;
            this.cancel.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.cancel.OnHoverTextColor = System.Drawing.Color.DimGray;
            this.cancel.selected = false;
            this.cancel.Size = new System.Drawing.Size(118, 48);
            this.cancel.TabIndex = 18;
            this.cancel.Text = "CANCEL";
            this.cancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancel.Textcolor = System.Drawing.Color.White;
            this.cancel.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // bunifuFlatButton1
            // 
            this.bunifuFlatButton1.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.bunifuFlatButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.bunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton1.BorderRadius = 0;
            this.bunifuFlatButton1.ButtonText = "OK";
            this.bunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton1.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton1.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton1.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuFlatButton1.Iconimage")));
            this.bunifuFlatButton1.Iconimage_right = null;
            this.bunifuFlatButton1.Iconimage_right_Selected = null;
            this.bunifuFlatButton1.Iconimage_Selected = null;
            this.bunifuFlatButton1.IconMarginLeft = 0;
            this.bunifuFlatButton1.IconMarginRight = 0;
            this.bunifuFlatButton1.IconRightVisible = true;
            this.bunifuFlatButton1.IconRightZoom = 0D;
            this.bunifuFlatButton1.IconVisible = true;
            this.bunifuFlatButton1.IconZoom = 90D;
            this.bunifuFlatButton1.IsTab = false;
            this.bunifuFlatButton1.Location = new System.Drawing.Point(565, 309);
            this.bunifuFlatButton1.Name = "bunifuFlatButton1";
            this.bunifuFlatButton1.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.bunifuFlatButton1.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.bunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton1.selected = false;
            this.bunifuFlatButton1.Size = new System.Drawing.Size(92, 48);
            this.bunifuFlatButton1.TabIndex = 17;
            this.bunifuFlatButton1.Text = "OK";
            this.bunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton1.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatButton1.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton1.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // remove_Btn
            // 
            this.remove_Btn.BackColor = System.Drawing.Color.Transparent;
            this.remove_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.remove_Btn.Image = global::E_Sched.Properties.Resources.delete_row;
            this.remove_Btn.ImageActive = null;
            this.remove_Btn.Location = new System.Drawing.Point(64, 57);
            this.remove_Btn.Name = "remove_Btn";
            this.remove_Btn.Size = new System.Drawing.Size(46, 39);
            this.remove_Btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.remove_Btn.TabIndex = 8;
            this.remove_Btn.TabStop = false;
            this.remove_Btn.Zoom = 10;
            this.remove_Btn.Click += new System.EventHandler(this.remove_Btn_Click);
            // 
            // add_Btn
            // 
            this.add_Btn.BackColor = System.Drawing.Color.Transparent;
            this.add_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.add_Btn.Image = global::E_Sched.Properties.Resources.new_button;
            this.add_Btn.ImageActive = null;
            this.add_Btn.Location = new System.Drawing.Point(12, 57);
            this.add_Btn.Name = "add_Btn";
            this.add_Btn.Size = new System.Drawing.Size(46, 39);
            this.add_Btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.add_Btn.TabIndex = 7;
            this.add_Btn.TabStop = false;
            this.add_Btn.Zoom = 10;
            this.add_Btn.Click += new System.EventHandler(this.add_Btn_Click);
            // 
            // LightingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(669, 369);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.bunifuFlatButton1);
            this.Controls.Add(this.remove_Btn);
            this.Controls.Add(this.add_Btn);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.bunifuProgressBar1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LightingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LightingsForm";
            this.Load += new System.EventHandler(this.LightingsForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exit_Btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.remove_Btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.add_Btn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuProgressBar bunifuProgressBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuImageButton exit_Btn;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dataGridView;
        private Bunifu.Framework.UI.BunifuImageButton add_Btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NO_OF_LAMPS;
        private System.Windows.Forms.DataGridViewTextBoxColumn WATTS_PER_LAMP;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRIPTION;
        private Bunifu.Framework.UI.BunifuImageButton remove_Btn;
        private Bunifu.Framework.UI.BunifuFlatButton cancel;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton1;
    }
}