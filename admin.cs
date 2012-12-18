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
            func.condb();
            func.connection.Open();
            using (MySqlDataAdapter a = new MySqlDataAdapter("SELECT fullname,email,username,classid,level FROM accounts where accounttype='teacher'", func.connection))
            {

                DataTable t = new DataTable();
                a.Fill(t);
                teachergrid.DataSource = t;
            }
            using (MySqlDataAdapter a = new MySqlDataAdapter("SELECT fullname,email,username,birthdate,classid,level FROM accounts where accounttype='student'", func.connection))
            {

                DataTable t = new DataTable();
                a.Fill(t);
                studentgrid.DataSource = t;
            }
            using (MySqlDataAdapter a = new MySqlDataAdapter("SELECT fullname,email,username,telephone,address FROM accounts where accounttype='parent'", func.connection))
            {

                DataTable t = new DataTable();
                a.Fill(t);
                parentgrid.DataSource = t;
            }

            func.connection.Close();

        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            login.instance.Show();
        }
        //Teacher
        private void button1_Click(object sender, EventArgs e)
        {
            func.condb();
            func.connection.Open();
            using (MySqlDataAdapter a = new MySqlDataAdapter("SELECT fullname,email,username,classid,level FROM accounts where accounttype='teacher'", func.connection))
            {

                DataTable t = new DataTable();
                a.Fill(t);
                teachergrid.DataSource = t;
            }
            func.connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            func.condb();
            func.connection.Open();
                MySqlCommand comm = new MySqlCommand("delete from accounts where accounttype='teacher'",func.connection);
                comm.ExecuteNonQuery();
                DataTable t = new DataTable();
                //a.Fill(t);
                //Object a = teachergrid.Rows[0]["0"];
                for (int i = 0; i < teachergrid.Rows.Count-1; i++)
                {
                   
                    comm.CommandText = "INSERT INTO accounts (accounttype, fullname, email, username, password, level,classid) VALUES ('teacher', '"
                     + teachergrid.Rows[i].Cells["fullname"].Value.ToString() + "','" 
                     + teachergrid.Rows[i].Cells["email"].Value.ToString() + "','" 
                     + teachergrid.Rows[i].Cells["username"].Value.ToString() + "','12345','" 
                     + teachergrid.Rows[i].Cells["level"].Value + "','" 
                     + teachergrid.Rows[i].Cells["classid"].Value + "');";
                    comm.ExecuteNonQuery();
                }
            func.connection.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        //student
        private void button4_Click(object sender, EventArgs e)
        {
            func.condb();
            func.connection.Open();
            using (MySqlDataAdapter a = new MySqlDataAdapter("SELECT fullname,email,username,birthdate,classid,level FROM accounts where accounttype='student'", func.connection))
            {

                DataTable t = new DataTable();
                a.Fill(t);
                studentgrid.DataSource = t;
            }
            func.connection.Close();

        }
        private void button3_Click(object sender, EventArgs e)
        {
            func.condb();
            func.connection.Open();
            MySqlCommand comm = new MySqlCommand("delete from accounts where accounttype='student'", func.connection);
           // comm.ExecuteNonQuery();
            DataTable t = new DataTable();
            //a.Fill(t);
            //Object a = teachergrid.Rows[0]["0"];
            for (int i = 0; i < studentgrid.Rows.Count - 1; i++)
            {

                comm.CommandText = "INSERT INTO accounts (accounttype,fullname,email,username,password,birthdate,level,classid) VALUES ('student', '"
                 + studentgrid.Rows[i].Cells["fullname"].Value.ToString() + "','"
                 + studentgrid.Rows[i].Cells["email"].Value.ToString() + "','"
                 + studentgrid.Rows[i].Cells["username"].Value.ToString() + "','12345','"
                 + studentgrid.Rows[i].Cells["birthdate"].Value + "','"
                 + studentgrid.Rows[i].Cells["level"].Value + "','"
                 + studentgrid.Rows[i].Cells["classid"].Value + "');";
                System.Windows.Forms.MessageBox.Show(comm.CommandText);
             //   comm.ExecuteNonQuery();
            }
            func.connection.Close();

        }


        //parent
        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }


    }
}
