using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Kindergarten
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        private void admin_Load(object sender, EventArgs e)
        {
            func.connection.Open();
            using (MySqlDataAdapter a = new MySqlDataAdapter("SELECT * FROM accounts", func.connection))
            {
                // 3
                // Use DataAdapter to fill DataTable
                DataTable t = new DataTable();
                a.Fill(t);
                teachergrid.DataSource = t;
                // 4
                // Render data onto the screen
                // dataGridView1.DataSource = t; // <-- From your designer
            }

        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            login.instance.Show();
        }


    }
}
