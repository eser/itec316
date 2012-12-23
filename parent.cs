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
using System.IO;

namespace Kindergarten
{
    public partial class parent : Form
    {
        public static string stdid;
        public static string stdid2;

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
            comboBox3.Items.Add("");

            MySqlCommand cmd = new MySqlCommand("SELECT username FROM accounts where accounttype='student' and parent_username='" + func.userid + "'", func.connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
               comboBox1.Items.Add(dataReader["username"]);
               comboBox3.Items.Add(dataReader["username"]);
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

            MySqlCommand cmd1 = new MySqlCommand("SELECT messageid FROM messages where receiveraccount='" + func.userid + "'",func.connection);
            MySqlDataReader dataReader1 = cmd1.ExecuteReader();
            while (dataReader1.Read())
            {
                comboBox2.Items.Add(dataReader1["messageid"]);
            }
            comboBox2.SelectedIndex = 0;
            dataReader1.Close();
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

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            MySqlCommand cmd = new MySqlCommand("SELECT messageid FROM messages where receiveraccount='" + func.userid + "'", func.connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                comboBox2.Items.Add(dataReader["messageid"]);
            }
            comboBox2.SelectedIndex = 0;
            dataReader.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT senderaccount,text,messagedate FROM messages where messageid='" 
                + comboBox2.SelectedItem + "'", func.connection);
            //richTextBox1.Text = cmd.CommandText;
            MySqlDataReader dataReader = cmd.ExecuteReader();
            dataReader.Read();          
                richTextBox1.Text = "From: " + dataReader["senderaccount"].ToString() +
                    "\nDate: " + dataReader["messagedate"].ToString() + 
                    "\nMessage: \n" + dataReader["text"].ToString() ;
            dataReader.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd1 = new MySqlCommand("DELETE FROM messages where messageid='"
                + comboBox2.SelectedItem + "'", func.connection);
            cmd1.ExecuteNonQuery();
            comboBox2.Items.Clear();

            MySqlCommand cmd = new MySqlCommand("SELECT messageid FROM messages where receiveraccount='" + func.userid + "'", func.connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                comboBox2.Items.Add(dataReader["messageid"]);
            }
            comboBox2.SelectedIndex = 0;
            dataReader.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // func.mciSendString("open \"" + Environment.CurrentDirectory + "\\" + func.userid + ".wav\" Alias playsound", "", 0, 0);
            // func.mciSendString("play playsound", "", 0, 0);
            // func.mciSendString("close playsound", "", 0, 0);
            func.PlaySound(Environment.CurrentDirectory + "\\" + stdid2 + ".wav", IntPtr.Zero, func.SoundFlags.SND_FILENAME | func.SoundFlags.SND_ASYNC);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == 0)
            {
                return;
            }

            stdid2 = comboBox3.SelectedItem.ToString();
            if (File.Exists(Environment.CurrentDirectory + "\\" + stdid2 + ".wav"))
            {
                button8.Enabled = true;
            }
            else
            {
                button8.Enabled = false;
            }
        }


    }
}
