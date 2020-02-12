namespace E_Sched
{
    partial class Phase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Phase));
            this.bunifuProgressBar1 = new Bunifu.Framework.UI.BunifuProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.exit_Btn = new Bunifu.Framework.UI.BunifuImageButton();
            this.threePhase = new System.Windows.Forms.RadioButton();
            this.singlePhase = new System.Windows.Forms.RadioButton();
            this.cancel_Btn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.ok_Btn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.dragControl = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exit_Btn)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuProgressBar1
            // 
            this.bunifuProgressBar1.BackColor = System.Drawing.Color.Silver;
            this.bunifuProgressBar1.BorderRadius = 5;
            this.bunifuProgressBar1.Location = new System.Drawing.Point(-17, 40);
            this.bunifuProgressBar1.MaximumValue = 100;
            this.bunifuProgressBar1.Name = "bunifuProgressBar1";
            this.bunifuProgressBar1.ProgressColor = System.Drawing.Color.Teal;
            this.bunifuProgressBar1.Size = new System.Drawing.Size(399, 10);
            this.bunifuProgressBar1.TabIndex = 13;
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
            this.panel1.Size = new System.Drawing.Size(365, 39);
            this.panel1.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(10, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "PLEASE SELECT TO CONTINUE";
            // 
            // exit_Btn
            // 
            this.exit_Btn.BackColor = System.Drawing.Color.Transparent;
            this.exit_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.exit_Btn.Image = global::E_Sched.Properties.Resources.Close_Button_1;
            this.exit_Btn.ImageActive = null;
            this.exit_Btn.Location = new System.Drawing.Point(317, 0);
            this.exit_Btn.Name = "exit_Btn";
            this.exit_Btn.Size = new System.Drawing.Size(46, 39);
            this.exit_Btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.exit_Btn.TabIndex = 2;
            this.exit_Btn.TabStop = false;
            this.exit_Btn.Zoom = 10;
            this.exit_Btn.Click += new System.EventHandler(this.exit_Btn_Click);
            // 
            // threePhase
            // 
            this.threePhase.AutoSize = true;
            this.threePhase.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.threePhase.ForeColor = System.Drawing.Color.White;
            this.threePhase.Location = new System.Drawing.Point(115, 146);
            this.threePhase.Name = "threePhase";
            this.threePhase.Size = new System.Drawing.Size(126, 23);
            this.threePhase.TabIndex = 15;
            this.threePhase.TabStop = true;
            this.threePhase.Text = "THREE_PHASE\r\n";
            this.threePhase.UseVisualStyleBackColor = true;
            this.threePhase.CheckedChanged += new System.EventHandler(this.threePhase_CheckedChanged);
            // 
            // singlePhase
            // 
            this.singlePhase.AutoSize = true;
            this.singlePhase.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.singlePhase.ForeColor = System.Drawing.Color.White;
            this.singlePhase.Location = new System.Drawing.Point(115, 100);
            this.singlePhase.Name = "singlePhase";
            this.singlePhase.Size = new System.Drawing.Size(134, 23);
            this.singlePhase.TabIndex = 14;
            this.singlePhase.TabStop = true;
            this.singlePhase.Text = "SINGLE-PHASE";
            this.singlePhase.UseVisualStyleBackColor = true;
            this.singlePhase.CheckedChanged += new System.EventHandler(this.singlePhase_CheckedChanged);
            // 
            // cancel_Btn
            // 
            this.cancel_Btn.Activecolor = System.Drawing.Color.Black;
            this.cancel_Btn.BackColor = System.Drawing.Color.Black;
            this.cancel_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cancel_Btn.BorderRadius = 0;
            this.cancel_Btn.ButtonText = "CANCEL";
            this.cancel_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancel_Btn.DisabledColor = System.Drawing.Color.Gray;
            this.cancel_Btn.ForeColor = System.Drawing.Color.Black;
            this.cancel_Btn.Iconcolor = System.Drawing.Color.Transparent;
            this.cancel_Btn.Iconimage = global::E_Sched.Properties.Resources.Close_Button_1;
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
            this.cancel_Btn.Location = new System.Drawing.Point(152, 222);
            this.cancel_Btn.Name = "cancel_Btn";
            this.cancel_Btn.Normalcolor = System.Drawing.Color.Black;
            this.cancel_Btn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cancel_Btn.OnHoverTextColor = System.Drawing.Color.White;
            this.cancel_Btn.selected = false;
            this.cancel_Btn.Size = new System.Drawing.Size(104, 35);
            this.cancel_Btn.TabIndex = 17;
            this.cancel_Btn.Text = "CANCEL";
            this.cancel_Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancel_Btn.Textcolor = System.Drawing.Color.White;
            this.cancel_Btn.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel_Btn.Click += new System.EventHandler(this.cancel_Btn_Click);
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
            this.ok_Btn.Location = new System.Drawing.Point(262, 222);
            this.ok_Btn.Name = "ok_Btn";
            this.ok_Btn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ok_Btn.OnHovercolor = System.Drawing.Color.Gray;
            this.ok_Btn.OnHoverTextColor = System.Drawing.Color.White;
            this.ok_Btn.selected = false;
            this.ok_Btn.Size = new System.Drawing.Size(91, 35);
            this.ok_Btn.TabIndex = 16;
            this.ok_Btn.Text = "OK";
            this.ok_Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ok_Btn.Textcolor = System.Drawing.Color.White;
            this.ok_Btn.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ok_Btn.Click += new System.EventHandler(this.ok_Btn_Click);
            // 
            // dragControl
            // 
            this.dragControl.Fixed = true;
            this.dragControl.Horizontal = true;
            this.dragControl.TargetControl = this.panel1;
            this.dragControl.Vertical = true;
            // 
            // Phase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(365, 269);
            this.Controls.Add(this.bunifuProgressBar1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cancel_Btn);
            this.Controls.Add(this.ok_Btn);
            this.Controls.Add(this.threePhase);
            this.Controls.Add(this.singlePhase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Phase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phase";
            this.Load += new System.EventHandler(this.Phase_Load);
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
        private Bunifu.Framework.UI.BunifuFlatButton cancel_Btn;
        private Bunifu.Framework.UI.BunifuFlatButton ok_Btn;
        private System.Windows.Forms.RadioButton threePhase;
        private System.Windows.Forms.RadioButton singlePhase;
        private Bunifu.Framework.UI.BunifuDragControl dragControl;
    }
}