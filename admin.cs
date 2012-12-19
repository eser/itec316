using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;


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
            this.listView1.Items[0].Selected = true;

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
        }

        private void about_Click(object sender, EventArgs e)
        {
            func.about(this);
        }

        private void logout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Teacher
        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlDataAdapter a = new MySqlDataAdapter("SELECT fullname,email,username,classid,level FROM accounts where accounttype='teacher'", func.connection))
            {
                DataTable t = new DataTable();
                a.Fill(t);
                teachergrid.DataSource = t;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlCommand comm = new MySqlCommand("delete from accounts where accounttype='teacher'", func.connection);
            comm.ExecuteNonQuery();
            DataTable t = new DataTable();
            //a.Fill(t);
            //Object a = teachergrid.Rows[0]["0"];
            for (int i = 0; i < teachergrid.Rows.Count - 1; i++)
            {

                comm.CommandText = "INSERT INTO accounts (accounttype, fullname, email, username, password, level,classid) VALUES ('teacher', '"
                 + teachergrid.Rows[i].Cells["fullname"].Value.ToString() + "','"
                 + teachergrid.Rows[i].Cells["email"].Value.ToString() + "','"
                 + teachergrid.Rows[i].Cells["username"].Value.ToString() + "','12345','"
                 + teachergrid.Rows[i].Cells["level"].Value + "','"
                 + teachergrid.Rows[i].Cells["classid"].Value + "');";
                comm.ExecuteNonQuery();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        //student
        private void button4_Click(object sender, EventArgs e)
        {
            using (MySqlDataAdapter a = new MySqlDataAdapter("SELECT fullname,email,username,birthdate,classid,level FROM accounts where accounttype='student'", func.connection))
            {

                DataTable t = new DataTable();
                a.Fill(t);
                studentgrid.DataSource = t;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
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
        }


        //parent
        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void admin_Shown(object sender, EventArgs e)
        {
            func.loginForm.Hide();
        }

        private void admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            func.loginForm.Show();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                this.tabControl1.SelectedIndex = this.listView1.SelectedItems[0].Index;
            }
        }
    }
}
