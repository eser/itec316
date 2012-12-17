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
    public partial class login : Form
    {
        public static login instance;

        public login()
        {
            InitializeComponent();
            instance = this;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            login.ActiveForm.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TODO: Login implement database
            if (textBox1.Text == "admin")
            {

                this.Hide();
                new admin().Show();
                
            }
        }
    }
}
