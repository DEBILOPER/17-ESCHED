namespace E_Sched
{
    partial class AddTab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTab));
            this.bunifuProgressBar1 = new Bunifu.Framework.UI.BunifuProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.exit_Btn = new Bunifu.Framework.UI.BunifuImageButton();
            this.cancel = new Bunifu.Framework.UI.BunifuFlatButton();
            this.ok_Btn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.newTab = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exit_Btn)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuProgressBar1
            // 
            this.bunifuProgressBar1.BackColor = System.Drawing.Color.Silver;
            this.bunifuProgressBar1.BorderRadius = 5;
            this.bunifuProgressBar1.Location = new System.Drawing.Point(-22, 40);
            this.bunifuProgressBar1.MaximumValue = 100;
            this.bunifuProgressBar1.Name = "bunifuProgressBar1";
            this.bunifuProgressBar1.ProgressColor = System.Drawing.Color.Teal;
            this.bunifuProgressBar1.Size = new System.Drawing.Size(442, 10);
            this.bunifuProgressBar1.TabIndex = 36;
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
            this.panel1.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(10, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "ADD NEW TAB";
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
            this.cancel.Location = new System.Drawing.Point(169, 153);
            this.cancel.Name = "cancel";
            this.cancel.Normalcolor = System.Drawing.Color.Red;
            this.cancel.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.cancel.OnHoverTextColor = System.Drawing.Color.DimGray;
            this.cancel.selected = false;
            this.cancel.Size = new System.Drawing.Size(118, 48);
            this.cancel.TabIndex = 40;
            this.cancel.Text = "CANCEL";
            this.cancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancel.Textcolor = System.Drawing.Color.White;
            this.cancel.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
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
            this.ok_Btn.Location = new System.Drawing.Point(294, 153);
            this.ok_Btn.Name = "ok_Btn";
            this.ok_Btn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.ok_Btn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.ok_Btn.OnHoverTextColor = System.Drawing.Color.White;
            this.ok_Btn.selected = false;
            this.ok_Btn.Size = new System.Drawing.Size(92, 48);
            this.ok_Btn.TabIndex = 39;
            this.ok_Btn.Text = "OK";
            this.ok_Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ok_Btn.Textcolor = System.Drawing.Color.White;
            this.ok_Btn.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ok_Btn.Click += new System.EventHandler(this.ok_Btn_Click);
            // 
            // newTab
            // 
            this.newTab.BorderColorFocused = System.Drawing.Color.Blue;
            this.newTab.BorderColorIdle = System.Drawing.Color.White;
            this.newTab.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.newTab.BorderThickness = 3;
            this.newTab.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.newTab.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.newTab.ForeColor = System.Drawing.Color.White;
            this.newTab.isPassword = false;
            this.newTab.Location = new System.Drawing.Point(85, 81);
            this.newTab.Margin = new System.Windows.Forms.Padding(4);
            this.newTab.Name = "newTab";
            this.newTab.Size = new System.Drawing.Size(300, 44);
            this.newTab.TabIndex = 38;
            this.newTab.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.AutoEllipsis = false;
            this.bunifuLabel1.CursorType = null;
            this.bunifuLabel1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.bunifuLabel1.ForeColor = System.Drawing.Color.White;
            this.bunifuLabel1.Location = new System.Drawing.Point(13, 93);
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel1.Size = new System.Drawing.Size(66, 18);
            this.bunifuLabel1.TabIndex = 37;
            this.bunifuLabel1.Text = "TABNAME";
            this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // AddTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(398, 206);
            this.Controls.Add(this.bunifuProgressBar1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok_Btn);
            this.Controls.Add(this.newTab);
            this.Controls.Add(this.bunifuLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddTab";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddTab";
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
        private Bunifu.Framework.UI.BunifuFlatButton cancel;
        private Bunifu.Framework.UI.BunifuFlatButton ok_Btn;
        private Bunifu.Framework.UI.BunifuMetroTextbox newTab;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel1;
    }
}