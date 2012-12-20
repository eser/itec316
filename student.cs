using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            func.mciSendString("save recsound c:\\itec316\\result.wav", "", 0, 0);
            func.mciSendString("close recsound ", "", 0, 0);
        }
    }
}
