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
    public partial class parent : Form
    {
        public static string stdid;
        public parent()
        {
            InitializeComponent();
        }

        private void parent_Shown(object sender, EventArgs e)
        {
            func.loginForm.Hide();
        }

        private void parent_FormClosed(object sender, FormClosedEventArgs e)
        {
            func.loginForm.Show();
        }

        private void parent_Load(object sender, EventArgs e)
        {
            label1.Text = "Last 3 Scores:";

            MySqlCommand cmd = new MySqlCommand("SELECT username FROM accounts where accounttype='student' and parent_username='" + func.userid + "'", func.connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
               comboBox1.Items.Add(dataReader["username"]);
            }

            dataReader.Close();
            comboBox1.SelectedIndex = 0;
            stdid = comboBox1.SelectedItem.ToString();
            label1.Text = "Last 3 Scores for " + stdid + ":";
            using (MySqlDataAdapter a = new MySqlDataAdapter("SELECT recorddate,score,level FROM gameresults where stdid='"
                + stdid + "' and gameid=3 ORDER BY recorddate DESC LIMIT 0 , 3", func.connection))
            {
                DataTable t = new DataTable();
                a.Fill(t);
                snakegrid.DataSource = t;
            }
            label2.Text = "Last 3 Scores for "+stdid+":";
            using (MySqlDataAdapter a = new MySqlDataAdapter("SELECT recorddate,score,level FROM gameresults where stdid='"
                + stdid + "' and gameid=1 ORDER BY recorddate DESC LIMIT 0 , 3", func.connection))
            {
                DataTable t = new DataTable();
                a.Fill(t);
                hanoigrid.DataSource = t;
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                this.tabControl1.SelectedIndex = this.listView1.SelectedItems[0].Index;
            }
        }

        //Hanoi
        private void button6_Click(object sender, EventArgs e)
        {
            stdid = comboBox1.SelectedItem.ToString();
            label2.Text = "All Scores for "+stdid+":";
            using (MySqlDataAdapter a = new MySqlDataAdapter("SELECT recorddate,score,level FROM gameresults where stdid='"
                + stdid + "' and gameid=1 ORDER BY recorddate DESC", func.connection))
            {
                DataTable t = new DataTable();
                a.Fill(t);
                hanoigrid.DataSource = t;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            stdid = comboBox1.SelectedItem.ToString();
            label2.Text = "Last 3 Scores for "+stdid+":";
            using (MySqlDataAdapter a = new MySqlDataAdapter("SELECT recorddate,score,level FROM gameresults where stdid='"
              + stdid + "' and gameid=1 ORDER BY recorddate DESC LIMIT 0 , 3", func.connection))
            {
                DataTable t = new DataTable();
                a.Fill(t);
                hanoigrid.DataSource = t;
            }
        }
        //Snake
        private void button1_Click(object sender, EventArgs e)
        {
            stdid = comboBox1.SelectedItem.ToString();
            label1.Text = "All Scores for " + stdid + ":";
            using (MySqlDataAdapter a = new MySqlDataAdapter("SELECT recorddate,score,level FROM gameresults where stdid='"
                + stdid + "' and gameid=3 ORDER BY recorddate DESC", func.connection))
            {
                DataTable t = new DataTable();
                a.Fill(t);
                snakegrid.DataSource = t;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stdid = comboBox1.SelectedItem.ToString();
            label1.Text = "Last 3 Scores for " + stdid + ":";
            using (MySqlDataAdapter a = new MySqlDataAdapter("SELECT recorddate,score,level FROM gameresults where stdid='"
                + stdid + "' and gameid=3 ORDER BY recorddate DESC LIMIT 0 , 3", func.connection))
            {
                DataTable t = new DataTable();
                a.Fill(t);
                snakegrid.DataSource = t;
            }
        }


    }
}
