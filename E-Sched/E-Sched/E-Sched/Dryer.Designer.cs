namespace E_Sched
{
    partial class Dryer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dryer));
            this.bunifuProgressBar1 = new Bunifu.Framework.UI.BunifuProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.exit_Btn = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuFlatButton2 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.ok_Btn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.voltageAmp = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exit_Btn)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuProgressBar1
            // 
            this.bunifuProgressBar1.BackColor = System.Drawing.Color.Silver;
            this.bunifuProgressBar1.BorderRadius = 5;
            this.bunifuProgressBar1.Location = new System.Drawing.Point(-22, 39);
            this.bunifuProgressBar1.MaximumValue = 100;
            this.bunifuProgressBar1.Name = "bunifuProgressBar1";
            this.bunifuProgressBar1.ProgressColor = System.Drawing.Color.Teal;
            this.bunifuProgressBar1.Size = new System.Drawing.Size(442, 10);
            this.bunifuProgressBar1.TabIndex = 29;
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
            this.panel1.Size = new System.Drawing.Size(398, 39);
            this.panel1.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(10, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "DRYER";
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
            this.bunifuFlatButton2.Location = new System.Drawing.Point(169, 148);
            this.bunifuFlatButton2.Name = "bunifuFlatButton2";
            this.bunifuFlatButton2.Normalcolor = System.Drawing.Color.Red;
            this.bunifuFlatButton2.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.bunifuFlatButton2.OnHoverTextColor = System.Drawing.Color.DimGray;
            this.bunifuFlatButton2.selected = false;
            this.bunifuFlatButton2.Size = new System.Drawing.Size(118, 48);
            this.bunifuFlatButton2.TabIndex = 34;
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
            this.ok_Btn.Location = new System.Drawing.Point(294, 148);
            this.ok_Btn.Name = "ok_Btn";
            this.ok_Btn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.ok_Btn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.ok_Btn.OnHoverTextColor = System.Drawing.Color.White;
            this.ok_Btn.selected = false;
            this.ok_Btn.Size = new System.Drawing.Size(92, 48);
            this.ok_Btn.TabIndex = 33;
            this.ok_Btn.Text = "OK";
            this.ok_Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ok_Btn.Textcolor = System.Drawing.Color.White;
            this.ok_Btn.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ok_Btn.Click += new System.EventHandler(this.ok_Btn_Click);
            // 
            // voltageAmp
            // 
            this.voltageAmp.BorderColorFocused = System.Drawing.Color.Blue;
            this.voltageAmp.BorderColorIdle = System.Drawing.Color.White;
            this.voltageAmp.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.voltageAmp.BorderThickness = 3;
            this.voltageAmp.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.voltageAmp.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.voltageAmp.ForeColor = System.Drawing.Color.White;
            this.voltageAmp.isPassword = false;
            this.voltageAmp.Location = new System.Drawing.Point(160, 67);
            this.voltageAmp.Margin = new System.Windows.Forms.Padding(4);
            this.voltageAmp.Name = "voltageAmp";
            this.voltageAmp.Size = new System.Drawing.Size(225, 44);
            this.voltageAmp.TabIndex = 31;
            this.voltageAmp.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.AutoEllipsis = false;
            this.bunifuLabel1.CursorType = null;
            this.bunifuLabel1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.bunifuLabel1.ForeColor = System.Drawing.Color.White;
            this.bunifuLabel1.Location = new System.Drawing.Point(35, 79);
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel1.Size = new System.Drawing.Size(118, 18);
            this.bunifuLabel1.TabIndex = 30;
            this.bunifuLabel1.Text = "VOLTAGE AMPERE";
            this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // Dryer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(398, 206);
            this.Controls.Add(this.bunifuProgressBar1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bunifuFlatButton2);
            this.Controls.Add(this.ok_Btn);
            this.Controls.Add(this.voltageAmp);
            this.Controls.Add(this.bunifuLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dryer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dryer";
            this.Load += new System.EventHandler(this.Dryer_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exit_Btn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuProgressBar bunifuProgressBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuImageButton exit_Btn;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton2;
        private Bunifu.Framework.UI.BunifuFlatButton ok_Btn;
        private Bunifu.Framework.UI.BunifuMetroTextbox voltageAmp;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel1;
    }
}