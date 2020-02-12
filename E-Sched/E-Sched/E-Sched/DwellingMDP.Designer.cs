namespace E_Sched
{
    partial class DwellingMDP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DwellingMDP));
            this.bunifuProgressBar1 = new Bunifu.Framework.UI.BunifuProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.exit_Btn = new Bunifu.Framework.UI.BunifuImageButton();
            this.dragControl = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.units = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.ok_Btn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exit_Btn)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuProgressBar1
            // 
            this.bunifuProgressBar1.BackColor = System.Drawing.Color.Silver;
            this.bunifuProgressBar1.BorderRadius = 5;
            this.bunifuProgressBar1.Location = new System.Drawing.Point(-7, 35);
            this.bunifuProgressBar1.MaximumValue = 100;
            this.bunifuProgressBar1.Name = "bunifuProgressBar1";
            this.bunifuProgressBar1.ProgressColor = System.Drawing.Color.Teal;
            this.bunifuProgressBar1.Size = new System.Drawing.Size(393, 10);
            this.bunifuProgressBar1.TabIndex = 25;
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
            this.panel1.Size = new System.Drawing.Size(367, 39);
            this.panel1.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(10, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "DWELLING UNIT";
            // 
            // exit_Btn
            // 
            this.exit_Btn.BackColor = System.Drawing.Color.Transparent;
            this.exit_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.exit_Btn.Image = global::E_Sched.Properties.Resources.Close_Button_1;
            this.exit_Btn.ImageActive = null;
            this.exit_Btn.Location = new System.Drawing.Point(319, 0);
            this.exit_Btn.Name = "exit_Btn";
            this.exit_Btn.Size = new System.Drawing.Size(46, 39);
            this.exit_Btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.exit_Btn.TabIndex = 2;
            this.exit_Btn.TabStop = false;
            this.exit_Btn.Zoom = 10;
            this.exit_Btn.Click += new System.EventHandler(this.exit_Btn_Click);
            // 
            // dragControl
            // 
            this.dragControl.Fixed = true;
            this.dragControl.Horizontal = true;
            this.dragControl.TargetControl = this.panel1;
            this.dragControl.Vertical = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 16);
            this.label1.TabIndex = 27;
            this.label1.Text = "PLEASE INDICATE NO. OF UNITS";
            // 
            // units
            // 
            this.units.BorderColorFocused = System.Drawing.Color.Silver;
            this.units.BorderColorIdle = System.Drawing.Color.Gray;
            this.units.BorderColorMouseHover = System.Drawing.Color.Silver;
            this.units.BorderThickness = 3;
            this.units.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.units.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.units.ForeColor = System.Drawing.Color.White;
            this.units.isPassword = false;
            this.units.Location = new System.Drawing.Point(17, 117);
            this.units.Margin = new System.Windows.Forms.Padding(4);
            this.units.Name = "units";
            this.units.Size = new System.Drawing.Size(343, 44);
            this.units.TabIndex = 26;
            this.units.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // ok_Btn
            // 
            this.ok_Btn.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ok_Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
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
            this.ok_Btn.Location = new System.Drawing.Point(269, 199);
            this.ok_Btn.Name = "ok_Btn";
            this.ok_Btn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ok_Btn.OnHovercolor = System.Drawing.Color.Gray;
            this.ok_Btn.OnHoverTextColor = System.Drawing.Color.White;
            this.ok_Btn.selected = false;
            this.ok_Btn.Size = new System.Drawing.Size(91, 35);
            this.ok_Btn.TabIndex = 28;
            this.ok_Btn.Text = "OK";
            this.ok_Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ok_Btn.Textcolor = System.Drawing.Color.White;
            this.ok_Btn.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ok_Btn.Click += new System.EventHandler(this.ok_Btn_Click);
            // 
            // DwellingMDP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(367, 246);
            this.Controls.Add(this.bunifuProgressBar1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.units);
            this.Controls.Add(this.ok_Btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DwellingMDP";
            this.Text = "DwellingMDP";
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
        private Bunifu.Framework.UI.BunifuDragControl dragControl;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuMetroTextbox units;
        private Bunifu.Framework.UI.BunifuFlatButton ok_Btn;
    }
}