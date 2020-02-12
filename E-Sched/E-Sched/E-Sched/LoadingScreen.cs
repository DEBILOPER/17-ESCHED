using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Sched
{
    public partial class LoadingScreen : Form
    {
        private MainDialogBox main = new MainDialogBox();

        public LoadingScreen()
        {
            InitializeComponent();
        }

        private void LoadingScreen_Load(object sender, EventArgs e)
        {
            // start timer
            timer1.Start();

            DatabaseConnection connection = new DatabaseConnection();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // increment progressbar by 1
            progressBar.Value += 10;

            if(progressBar.Value == 100)
            {
                // stop timer
                timer1.Stop();

                this.Hide();

                // show next form
                main.ShowDialog();

                this.Close();
            }
        }
    }
}
