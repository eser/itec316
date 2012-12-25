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
    public partial class changepass : Form
    {
        private object p;
        private string oldpass;
        public changepass(object p)
        {
            InitializeComponent();
            this.p = p;

        }

        private void changepass_Load(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("Select password FROM accounts WHERE accountid=" + p + "", func.connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            dataReader.Read();
                oldpass = dataReader["password"].ToString();
            dataReader.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (oldpass == textBox1.Text)
            {
                if (!string.IsNullOrEmpty(textBox2.Text) && (textBox2.Text == textBox3.Text))
                {
                    MySqlCommand cmd = new MySqlCommand("UPDATE accounts set password ='"+textBox2.Text+"' WHERE accountid=" + p + "", func.connection);
                    cmd.ExecuteNonQuery();
                    System.Windows.Forms.MessageBox.Show("Password Changed");
                    //admin.passchange();
                    this.Close();
                }
                else
                    System.Windows.Forms.MessageBox.Show("New password is empty or not match");
            }
            else
                System.Windows.Forms.MessageBox.Show("Old password is wrong");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
