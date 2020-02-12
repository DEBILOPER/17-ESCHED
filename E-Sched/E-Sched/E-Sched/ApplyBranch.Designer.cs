namespace E_Sched
{
    partial class ApplyBranch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplyBranch));
            this.bunifuProgressBar1 = new Bunifu.Framework.UI.BunifuProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.exit_Btn = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuLabel3 = new Bunifu.UI.WinForms.BunifuLabel();
            this.temperature = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
            this.cancel_Btn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.ok_Btn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.tw = new System.Windows.Forms.CheckBox();
            this.thw = new System.Windows.Forms.CheckBox();
            this.thhn = new System.Windows.Forms.CheckBox();
            this.bunifuLabel4 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuLabel2 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuLabel5 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuLabel8 = new Bunifu.UI.WinForms.BunifuLabel();
            this.imc = new System.Windows.Forms.CheckBox();
            this.emt = new System.Windows.Forms.CheckBox();
            this.pvc = new System.Windows.Forms.CheckBox();
            this.rmc = new System.Windows.Forms.CheckBox();
            this.no_of_conductors = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exit_Btn)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuProgressBar1
            // 
            this.bunifuProgressBar1.BackColor = System.Drawing.Color.Silver;
            this.bunifuProgressBar1.BorderRadius = 5;
            this.bunifuProgressBar1.Location = new System.Drawing.Point(-12, 39);
            this.bunifuProgressBar1.MaximumValue = 100;
            this.bunifuProgressBar1.Name = "bunifuProgressBar1";
            this.bunifuProgressBar1.ProgressColor = System.Drawing.Color.Teal;
            this.bunifuProgressBar1.Size = new System.Drawing.Size(442, 10);
            this.bunifuProgressBar1.TabIndex = 45;
            this.bunifuProgressBar1.Value = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panel1.Controls.Add(this.exit_Btn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(398, 39);
            this.panel1.TabIndex = 44;
            // 
            // exit_Btn
            // 
            this.exit_Btn.BackColor = System.Drawing.Color.Transparent;
            this.exit_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.exit_Btn.Image = global::E_Sched.Properties.Resources.Close_Button_1;
            this.exit_Btn.ImageActive = null;
            this.exit_Btn.Location = new System.Drawing.Point(352, 0);
            this.exit_Btn.Name = "exit_Btn";
            this.exit_Btn.Size = new System.Drawing.Size(46, 39);
            this.exit_Btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.exit_Btn.TabIndex = 2;
            this.exit_Btn.TabStop = false;
            this.exit_Btn.Zoom = 10;
            this.exit_Btn.Click += new System.EventHandler(this.exit_Btn_Click);
            // 
            // bunifuLabel3
            // 
            this.bunifuLabel3.AutoEllipsis = false;
            this.bunifuLabel3.CursorType = null;
            this.bunifuLabel3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.bunifuLabel3.ForeColor = System.Drawing.Color.Yellow;
            this.bunifuLabel3.Location = new System.Drawing.Point(16, 209);
            this.bunifuLabel3.Name = "bunifuLabel3";
            this.bunifuLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel3.Size = new System.Drawing.Size(165, 18);
            this.bunifuLabel3.TabIndex = 51;
            this.bunifuLabel3.Text = "APPLY DERATING FACTOR";
            this.bunifuLabel3.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel3.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // temperature
            // 
            this.temperature.BorderColorFocused = System.Drawing.Color.Blue;
            this.temperature.BorderColorIdle = System.Drawing.Color.White;
            this.temperature.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.temperature.BorderThickness = 3;
            this.temperature.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.temperature.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.temperature.ForeColor = System.Drawing.Color.White;
            this.temperature.isPassword = false;
            this.temperature.Location = new System.Drawing.Point(227, 153);
            this.temperature.Margin = new System.Windows.Forms.Padding(4);
            this.temperature.Name = "temperature";
            this.temperature.Size = new System.Drawing.Size(155, 44);
            this.temperature.TabIndex = 47;
            this.temperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.AutoEllipsis = false;
            this.bunifuLabel1.CursorType = null;
            this.bunifuLabel1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.bunifuLabel1.ForeColor = System.Drawing.Color.White;
            this.bunifuLabel1.Location = new System.Drawing.Point(12, 164);
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel1.Size = new System.Drawing.Size(208, 18);
            this.bunifuLabel1.TabIndex = 46;
            this.bunifuLabel1.Text = "TEMPERATURE (DEGREE CELCIUS)";
            this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // cancel_Btn
            // 
            this.cancel_Btn.Activecolor = System.Drawing.Color.Red;
            this.cancel_Btn.BackColor = System.Drawing.Color.Red;
            this.cancel_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cancel_Btn.BorderRadius = 0;
            this.cancel_Btn.ButtonText = "CANCEL";
            this.cancel_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancel_Btn.DisabledColor = System.Drawing.Color.Gray;
            this.cancel_Btn.Iconcolor = System.Drawing.Color.Transparent;
            this.cancel_Btn.Iconimage = ((System.Drawing.Image)(resources.GetObject("cancel_Btn.Iconimage")));
            this.cancel_Btn.Iconimage_right = null;
            this.cancel_Btn.Iconimage_right_Selected = null;
            this.cancel_Btn.Iconimage_Selected = null;
            this.cancel_Btn.IconMarginLeft = 0;
            this.cancel_Btn.IconMarginRight = 0;
            this.cancel_Btn.IconRightVisible = true;
            this.cancel_Btn.IconRightZoom = 0D;
            this.cancel_Btn.IconVisible = true;
            this.cancel_Btn.IconZoom = 90D;
            this.cancel_Btn.IsTab = false;
            this.cancel_Btn.Location = new System.Drawing.Point(169, 383);
            this.cancel_Btn.Name = "cancel_Btn";
            this.cancel_Btn.Normalcolor = System.Drawing.Color.Red;
            this.cancel_Btn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.cancel_Btn.OnHoverTextColor = System.Drawing.Color.DimGray;
            this.cancel_Btn.selected = false;
            this.cancel_Btn.Size = new System.Drawing.Size(118, 48);
            this.cancel_Btn.TabIndex = 49;
            this.cancel_Btn.Text = "CANCEL";
            this.cancel_Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancel_Btn.Textcolor = System.Drawing.Color.White;
            this.cancel_Btn.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel_Btn.Click += new System.EventHandler(this.cancel_Btn_Click);
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
            this.ok_Btn.Location = new System.Drawing.Point(294, 383);
            this.ok_Btn.Name = "ok_Btn";
            this.ok_Btn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.ok_Btn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.ok_Btn.OnHoverTextColor = System.Drawing.Color.White;
            this.ok_Btn.selected = false;
            this.ok_Btn.Size = new System.Drawing.Size(92, 48);
            this.ok_Btn.TabIndex = 48;
            this.ok_Btn.Text = "OK";
            this.ok_Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ok_Btn.Textcolor = System.Drawing.Color.White;
            this.ok_Btn.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ok_Btn.Click += new System.EventHandler(this.ok_Btn_Click);
            // 
            // tw
            // 
            this.tw.AutoSize = true;
            this.tw.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tw.ForeColor = System.Drawing.Color.White;
            this.tw.Location = new System.Drawing.Point(91, 86);
            this.tw.Name = "tw";
            this.tw.Size = new System.Drawing.Size(45, 20);
            this.tw.TabIndex = 53;
            this.tw.Text = "TW";
            this.tw.UseVisualStyleBackColor = true;
            this.tw.Click += new System.EventHandler(this.tw_Click);
            // 
            // thw
            // 
            this.thw.AutoSize = true;
            this.thw.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thw.ForeColor = System.Drawing.Color.White;
            this.thw.Location = new System.Drawing.Point(164, 86);
            this.thw.Name = "thw";
            this.thw.Size = new System.Drawing.Size(54, 20);
            this.thw.TabIndex = 54;
            this.thw.Text = "THW";
            this.thw.UseVisualStyleBackColor = true;
            this.thw.Click += new System.EventHandler(this.thw_Click);
            // 
            // thhn
            // 
            this.thhn.AutoSize = true;
            this.thhn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thhn.ForeColor = System.Drawing.Color.White;
            this.thhn.Location = new System.Drawing.Point(246, 86);
            this.thhn.Name = "thhn";
            this.thhn.Size = new System.Drawing.Size(61, 20);
            this.thhn.TabIndex = 55;
            this.thhn.Text = "THHN";
            this.thhn.UseVisualStyleBackColor = true;
            this.thhn.Click += new System.EventHandler(this.thhn_Click);
            // 
            // bunifuLabel4
            // 
            this.bunifuLabel4.AutoEllipsis = false;
            this.bunifuLabel4.CursorType = null;
            this.bunifuLabel4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.bunifuLabel4.ForeColor = System.Drawing.Color.White;
            this.bunifuLabel4.Location = new System.Drawing.Point(12, 55);
            this.bunifuLabel4.Name = "bunifuLabel4";
            this.bunifuLabel4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel4.Size = new System.Drawing.Size(261, 18);
            this.bunifuLabel4.TabIndex = 56;
            this.bunifuLabel4.Text = "PLEASE SELECT TYPE OF WIRE TO BE USED:";
            this.bunifuLabel4.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel4.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuLabel2
            // 
            this.bunifuLabel2.AutoEllipsis = false;
            this.bunifuLabel2.CursorType = null;
            this.bunifuLabel2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.bunifuLabel2.ForeColor = System.Drawing.Color.Yellow;
            this.bunifuLabel2.Location = new System.Drawing.Point(12, 129);
            this.bunifuLabel2.Name = "bunifuLabel2";
            this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel2.Size = new System.Drawing.Size(185, 18);
            this.bunifuLabel2.TabIndex = 57;
            this.bunifuLabel2.Text = "APPLY CORRECTION FACTOR";
            this.bunifuLabel2.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel2.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuLabel5
            // 
            this.bunifuLabel5.AutoEllipsis = false;
            this.bunifuLabel5.CursorType = null;
            this.bunifuLabel5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.bunifuLabel5.ForeColor = System.Drawing.Color.White;
            this.bunifuLabel5.Location = new System.Drawing.Point(15, 245);
            this.bunifuLabel5.Name = "bunifuLabel5";
            this.bunifuLabel5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel5.Size = new System.Drawing.Size(166, 34);
            this.bunifuLabel5.TabIndex = 58;
            this.bunifuLabel5.Text = "NO. OF CURRENT \r\nCARRYING CONDUCTORS";
            this.bunifuLabel5.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel5.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuLabel8
            // 
            this.bunifuLabel8.AutoEllipsis = false;
            this.bunifuLabel8.CursorType = null;
            this.bunifuLabel8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.bunifuLabel8.ForeColor = System.Drawing.Color.White;
            this.bunifuLabel8.Location = new System.Drawing.Point(16, 314);
            this.bunifuLabel8.Name = "bunifuLabel8";
            this.bunifuLabel8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel8.Size = new System.Drawing.Size(288, 18);
            this.bunifuLabel8.TabIndex = 64;
            this.bunifuLabel8.Text = "PLEASE SELECT TYPE OF CONDUIT TO BE USED:";
            this.bunifuLabel8.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel8.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // imc
            // 
            this.imc.AutoSize = true;
            this.imc.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imc.ForeColor = System.Drawing.Color.White;
            this.imc.Location = new System.Drawing.Point(219, 345);
            this.imc.Name = "imc";
            this.imc.Size = new System.Drawing.Size(53, 20);
            this.imc.TabIndex = 63;
            this.imc.Text = "IMC";
            this.imc.UseVisualStyleBackColor = true;
            this.imc.Click += new System.EventHandler(this.imc_Click);
            // 
            // emt
            // 
            this.emt.AutoSize = true;
            this.emt.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emt.ForeColor = System.Drawing.Color.White;
            this.emt.Location = new System.Drawing.Point(118, 345);
            this.emt.Name = "emt";
            this.emt.Size = new System.Drawing.Size(52, 20);
            this.emt.TabIndex = 62;
            this.emt.Text = "EMT";
            this.emt.UseVisualStyleBackColor = true;
            this.emt.Click += new System.EventHandler(this.emt_Click);
            // 
            // pvc
            // 
            this.pvc.AutoSize = true;
            this.pvc.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pvc.ForeColor = System.Drawing.Color.White;
            this.pvc.Location = new System.Drawing.Point(16, 345);
            this.pvc.Name = "pvc";
            this.pvc.Size = new System.Drawing.Size(53, 20);
            this.pvc.TabIndex = 61;
            this.pvc.Text = "PVC";
            this.pvc.UseVisualStyleBackColor = true;
            this.pvc.Click += new System.EventHandler(this.pvc_Click);
            // 
            // rmc
            // 
            this.rmc.AutoSize = true;
            this.rmc.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rmc.ForeColor = System.Drawing.Color.White;
            this.rmc.Location = new System.Drawing.Point(321, 345);
            this.rmc.Name = "rmc";
            this.rmc.Size = new System.Drawing.Size(57, 20);
            this.rmc.TabIndex = 65;
            this.rmc.Text = "RMC";
            this.rmc.UseVisualStyleBackColor = true;
            this.rmc.Click += new System.EventHandler(this.rmc_Click);
            // 
            // no_of_conductors
            // 
            this.no_of_conductors.BorderColorFocused = System.Drawing.Color.Blue;
            this.no_of_conductors.BorderColorIdle = System.Drawing.Color.White;
            this.no_of_conductors.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.no_of_conductors.BorderThickness = 3;
            this.no_of_conductors.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.no_of_conductors.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.no_of_conductors.ForeColor = System.Drawing.Color.White;
            this.no_of_conductors.isPassword = false;
            this.no_of_conductors.Location = new System.Drawing.Point(227, 235);
            this.no_of_conductors.Margin = new System.Windows.Forms.Padding(4);
            this.no_of_conductors.Name = "no_of_conductors";
            this.no_of_conductors.Size = new System.Drawing.Size(155, 44);
            this.no_of_conductors.TabIndex = 66;
            this.no_of_conductors.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // ApplyBranch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(398, 447);
            this.Controls.Add(this.no_of_conductors);
            this.Controls.Add(this.rmc);
            this.Controls.Add(this.bunifuLabel8);
            this.Controls.Add(this.imc);
            this.Controls.Add(this.emt);
            this.Controls.Add(this.pvc);
            this.Controls.Add(this.bunifuLabel5);
            this.Controls.Add(this.bunifuLabel2);
            this.Controls.Add(this.bunifuLabel4);
            this.Controls.Add(this.thhn);
            this.Controls.Add(this.thw);
            this.Controls.Add(this.tw);
            this.Controls.Add(this.bunifuProgressBar1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bunifuLabel3);
            this.Controls.Add(this.temperature);
            this.Controls.Add(this.bunifuLabel1);
            this.Controls.Add(this.cancel_Btn);
            this.Controls.Add(this.ok_Btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ApplyBranch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ApplyBranch";
            this.Load += new System.EventHandler(this.ApplyBranch_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exit_Btn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuProgressBar bunifuProgressBar1;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuImageButton exit_Btn;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel3;
        private Bunifu.Framework.UI.BunifuMetroTextbox temperature;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel1;
        private Bunifu.Framework.UI.BunifuFlatButton cancel_Btn;
        private Bunifu.Framework.UI.BunifuFlatButton ok_Btn;
        private System.Windows.Forms.CheckBox tw;
        private System.Windows.Forms.CheckBox thw;
        private System.Windows.Forms.CheckBox thhn;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel4;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel2;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel5;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel8;
        private System.Windows.Forms.CheckBox imc;
        private System.Windows.Forms.CheckBox emt;
        private System.Windows.Forms.CheckBox pvc;
        private System.Windows.Forms.CheckBox rmc;
        private Bunifu.Framework.UI.BunifuMetroTextbox no_of_conductors;
    }
}