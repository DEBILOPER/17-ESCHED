namespace E_Sched
{
    partial class MainDialogBox
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.exit_Btn = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuProgressBar1 = new Bunifu.Framework.UI.BunifuProgressBar();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.newFile_Btn = new Bunifu.Framework.UI.BunifuImageButton();
            this.dragControl = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.newFile_toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exit_Btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newFile_Btn)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panel1.Controls.Add(this.exit_Btn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(589, 39);
            this.panel1.TabIndex = 0;
            // 
            // exit_Btn
            // 
            this.exit_Btn.BackColor = System.Drawing.Color.Transparent;
            this.exit_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.exit_Btn.Image = global::E_Sched.Properties.Resources.Close_Button_1;
            this.exit_Btn.ImageActive = null;
            this.exit_Btn.Location = new System.Drawing.Point(543, 0);
            this.exit_Btn.Name = "exit_Btn";
            this.exit_Btn.Size = new System.Drawing.Size(46, 39);
            this.exit_Btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.exit_Btn.TabIndex = 2;
            this.exit_Btn.TabStop = false;
            this.exit_Btn.Zoom = 10;
            this.exit_Btn.Click += new System.EventHandler(this.exit_Btn_Click);
            // 
            // bunifuProgressBar1
            // 
            this.bunifuProgressBar1.BackColor = System.Drawing.Color.Silver;
            this.bunifuProgressBar1.BorderRadius = 5;
            this.bunifuProgressBar1.Location = new System.Drawing.Point(-13, 40);
            this.bunifuProgressBar1.MaximumValue = 100;
            this.bunifuProgressBar1.Name = "bunifuProgressBar1";
            this.bunifuProgressBar1.ProgressColor = System.Drawing.Color.Teal;
            this.bunifuProgressBar1.Size = new System.Drawing.Size(612, 10);
            this.bunifuProgressBar1.TabIndex = 1;
            this.bunifuProgressBar1.Value = 0;
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel.Location = new System.Drawing.Point(12, 100);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(565, 329);
            this.flowLayoutPanel.TabIndex = 2;
            // 
            // newFile_Btn
            // 
            this.newFile_Btn.BackColor = System.Drawing.Color.Transparent;
            this.newFile_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.newFile_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.newFile_Btn.Image = global::E_Sched.Properties.Resources.add_icon_2;
            this.newFile_Btn.ImageActive = null;
            this.newFile_Btn.Location = new System.Drawing.Point(6, 55);
            this.newFile_Btn.Name = "newFile_Btn";
            this.newFile_Btn.Size = new System.Drawing.Size(46, 39);
            this.newFile_Btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.newFile_Btn.TabIndex = 3;
            this.newFile_Btn.TabStop = false;
            this.newFile_Btn.Zoom = 10;
            this.newFile_Btn.Click += new System.EventHandler(this.newFile_Btn_Click);
            // 
            // dragControl
            // 
            this.dragControl.Fixed = true;
            this.dragControl.Horizontal = true;
            this.dragControl.TargetControl = this.panel1;
            this.dragControl.Vertical = true;
            // 
            // newFile_toolTip
            // 
            this.newFile_toolTip.IsBalloon = true;
            this.newFile_toolTip.ToolTipTitle = "CREATE NEW FILE";
            // 
            // MainDialogBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(589, 441);
            this.Controls.Add(this.newFile_Btn);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.bunifuProgressBar1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainDialogBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainDialogBox";
            this.Load += new System.EventHandler(this.MainDialogBox_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exit_Btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newFile_Btn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuProgressBar bunifuProgressBar1;
        private Bunifu.Framework.UI.BunifuImageButton exit_Btn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private Bunifu.Framework.UI.BunifuImageButton newFile_Btn;
        private Bunifu.Framework.UI.BunifuDragControl dragControl;
        private System.Windows.Forms.ToolTip newFile_toolTip;
    }
}