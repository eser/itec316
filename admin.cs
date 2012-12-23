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

            using (MySqlDataAdapter a = new MySqlDataAdapter("SELECT fullname,email,username,classid,level,password FROM accounts where accounttype='teacher'", func.connection))
            {
                DataTable t = new DataTable();
                a.Fill(t);
                teachergrid.DataSource = t;
            }

            using (MySqlDataAdapter b = new MySqlDataAdapter("SELECT fullname,email,username,birthdate,classid,level,parent_username,password FROM accounts where accounttype='student'", func.connection))
            {
                DataTable t = new DataTable();
                b.Fill(t);
                //studentgrid.Columns[3].DefaultCellStyle.Format = "yyyy-mm-dd";
                studentgrid.DataSource = t;
            }

            using (MySqlDataAdapter c = new MySqlDataAdapter("SELECT fullname,email,username,telephone,address,password FROM accounts where accounttype='parent'", func.connection))
            {
                DataTable t = new DataTable();
                c.Fill(t);
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
            using (MySqlDataAdapter a = new MySqlDataAdapter("SELECT fullname,email,username,classid,level,password FROM accounts where accounttype='teacher'", func.connection))
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
                 + teachergrid.Rows[i].Cells["username"].Value.ToString() + "','"
                 + teachergrid.Rows[i].Cells["password"].Value.ToString() + "','"
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
            using (MySqlDataAdapter a = new MySqlDataAdapter("SELECT fullname,email,username,birthdate,classid,level,parent_username,password FROM accounts where accounttype='student'", func.connection))
            {

                DataTable t = new DataTable();
                a.Fill(t);
                //studentgrid.Columns[4].DefaultCellStyle.Format = "yyyy-mm-dd";
                studentgrid.DataSource = t;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlCommand comm = new MySqlCommand("delete from accounts where accounttype='student'", func.connection);
            comm.ExecuteNonQuery();
            DataTable t = new DataTable();
            DateTime dt = new DateTime();
            for (int i = 0; i < studentgrid.Rows.Count - 1; i++)
            {
               // studentgrid.Columns[5].DefaultCellStyle.Format = "yyyy-mm-dd";
                string tmp;
                tmp = studentgrid.Rows[i].Cells["birthdate"].Value.ToString();
                dt = DateTime.Parse(tmp);
               

                comm.CommandText = "INSERT INTO accounts (accounttype,fullname,email,username,password,birthdate,level,classid,parent_username) VALUES ('student', '"
                 + studentgrid.Rows[i].Cells["fullname"].Value.ToString() + "','"
                 + studentgrid.Rows[i].Cells["email"].Value.ToString() + "','"
                 + studentgrid.Rows[i].Cells["username"].Value.ToString() + "','"
                 + studentgrid.Rows[i].Cells["password"].Value.ToString() + "','"
                 + String.Format("{0:yyyy-M-dd}", dt) + "','"
                 + studentgrid.Rows[i].Cells["level"].Value + "','"
                 + studentgrid.Rows[i].Cells["classid"].Value + "','"
                 + studentgrid.Rows[i].Cells["parent_username"].Value.ToString() + "');";
                //System.Windows.Forms.MessageBox.Show(comm.CommandText);
                comm.ExecuteNonQuery();
            }
        }


        //parent
        private void button6_Click(object sender, EventArgs e)
        {
            using (MySqlDataAdapter a = new MySqlDataAdapter("SELECT fullname,email,username,password,telephone,address FROM accounts where accounttype='parent'", func.connection))
            {
                DataTable t = new DataTable();
                a.Fill(t);
                parentgrid.DataSource = t;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MySqlCommand comm = new MySqlCommand("delete from accounts where accounttype='parent'", func.connection);
            comm.ExecuteNonQuery();
            DataTable t = new DataTable();
            for (int i = 0; i < parentgrid.Rows.Count - 1; i++)
            {
                comm.CommandText = "INSERT INTO accounts (accounttype,fullname,email,username,password,telephone,address) VALUES ('parent', '"
                 + parentgrid.Rows[i].Cells["fullname"].Value.ToString() + "','"
                 + parentgrid.Rows[i].Cells["email"].Value.ToString() + "','"
                 + parentgrid.Rows[i].Cells["username"].Value.ToString() + "','"
                 + parentgrid.Rows[i].Cells["password"].Value.ToString() + "','"
                 + parentgrid.Rows[i].Cells["telephone"].Value.ToString() + "','"
                 + parentgrid.Rows[i].Cells["address"].Value.ToString() + "');";
                //System.Windows.Forms.MessageBox.Show(comm.CommandText);
                comm.ExecuteNonQuery();
            }
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
