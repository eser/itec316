using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using System.IO;

namespace Kindergarten
{
    public partial class student : Form
    {
        public student()
        {
            InitializeComponent();
        }

        private void student_Shown(object sender, EventArgs e)
        {
            func.loginForm.Hide();
        }

        private void student_FormClosed(object sender, FormClosedEventArgs e)
        {
            func.loginForm.Show();
        }

        private void student_Load(object sender, EventArgs e)
        {
            this.listView1.Items[0].Selected = true;
            label1.Text = "Last 3 Scores:";
            using (MySqlDataAdapter a = new MySqlDataAdapter("SELECT recorddate,score,level FROM gameresults where stdid='" 
                + func.userid + "' and gameid=3 ORDER BY recorddate DESC LIMIT 0 , 3", func.connection))
            {
                DataTable t = new DataTable();
                a.Fill(t);
                resultgrid.DataSource = t;
            }
            label2.Text = "Last 3 Scores:";
            using (MySqlDataAdapter a = new MySqlDataAdapter("SELECT recorddate,score,level FROM gameresults where stdid='"
                + func.userid + "' and gameid=1 ORDER BY recorddate DESC LIMIT 0 , 3", func.connection))
            {
                DataTable t = new DataTable();
                a.Fill(t);
                hanoigrid.DataSource = t;
            }
            if (File.Exists(Environment.CurrentDirectory + "\\" + func.userid + ".wav"))
            {
                button9.Enabled = true;
            }
            else
            {
                button9.Enabled = false;
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

        private void button1_Click(object sender, EventArgs e)
        {
            func.mciSendString("open new Type waveaudio Alias recsound", "", 0, 0);
            func.mciSendString("record recsound", "", 0, 0);
            this.button1.Enabled = false;
            this.button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            func.mciSendString("save recsound \"" + Environment.CurrentDirectory + "\\" + func.userid + ".wav\"", "", 0, 0);
            func.mciSendString("close recsound ", "", 0, 0);
            this.button1.Enabled = true;
            this.button2.Enabled = false;
            MessageBox.Show("Recording completed");
            if (File.Exists(Environment.CurrentDirectory + "\\" + func.userid + ".wav"))
            {
                button9.Enabled = true;
            }
            else
            {
                button9.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("Snake.exe ",func.userid + " " + "3");
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text = "Last 3 Scores:";
            using (MySqlDataAdapter a = new MySqlDataAdapter("SELECT recorddate,score,level FROM gameresults where stdid='"
                + func.userid + "' and gameid=3 ORDER BY recorddate DESC LIMIT 0 , 3", func.connection))
            {

                DataTable t = new DataTable();
                a.Fill(t);
                resultgrid.DataSource = t;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label1.Text = "All Scores:";
            using (MySqlDataAdapter a = new MySqlDataAdapter("SELECT recorddate,score,level FROM gameresults where stdid='"
    + func.userid + "' and gameid=3 ORDER BY recorddate DESC", func.connection))
            {
                DataTable t = new DataTable();
                a.Fill(t);
                resultgrid.DataSource = t;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Process.Start("toh.exe ", func.userid + " " + "1");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label2.Text = "All Scores:";
            using (MySqlDataAdapter a = new MySqlDataAdapter("SELECT recorddate,score,level FROM gameresults where stdid='"
    + func.userid + "' and gameid=1 ORDER BY recorddate DESC", func.connection))
            {
                DataTable t = new DataTable();
                a.Fill(t);
                hanoigrid.DataSource = t;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label2.Text = "Last 3 Scores:";
            using (MySqlDataAdapter a = new MySqlDataAdapter("SELECT recorddate,score,level FROM gameresults where stdid='"
    + func.userid + "' and gameid=1 ORDER BY recorddate DESC LIMIT 0 , 3", func.connection))
            {
                DataTable t = new DataTable();
                a.Fill(t);
                hanoigrid.DataSource = t;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void hanoigrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            func.PlaySound(Environment.CurrentDirectory + "\\" + func.userid + ".wav", IntPtr.Zero, func.SoundFlags.SND_FILENAME | func.SoundFlags.SND_ASYNC);
        }


    }
}
