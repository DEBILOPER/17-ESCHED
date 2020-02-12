using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

namespace E_Sched
{
    class DatabaseConnection
    {
        public static OleDbConnection connection;

        public DatabaseConnection()
        {
            connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\user\Desktop\E-Sched\ESchedDatabase.accdb;Persist Security Info=False;";

            try
            {
                connection.Open();

                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR CONNECTION", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
