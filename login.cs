using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string _password = null;
            string _accounttype = null;

            using (MySqlCommand _cmd = func.connection.CreateCommand())
            {
                _cmd.CommandText = "SELECT * FROM accounts WHERE username=@username";
                _cmd.Parameters.AddWithValue("username", textBox1.Text);

                using (MySqlDataReader _reader = _cmd.ExecuteReader(CommandBehavior.SingleRow))
                {
                    if (_reader.Read())
                    {
                        _password = (string)_reader["password"];
                        _accounttype = (string)_reader["accounttype"];
                    }
                    else
                    {
                        MessageBox.Show("user not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.textBox2.Text = "";
                        this.textBox1.SelectAll();
                        this.textBox1.Focus();
                        return;
                    }
                }
            }

            //TODO: Login implement database
            if (_password != this.textBox2.Text)
            {
                MessageBox.Show("password error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBox2.SelectAll();
                this.textBox2.Focus();
                return;
            }

            switch (_accounttype)
            {
                case "teacher":
                    func.adminForm = new admin();
                    func.adminForm.Show();
                    break;
                case "parent":
                    func.parentForm = new parent();
                    func.parentForm.Show();
                    break;
                case "student":
                    func.studentForm = new student();
                    func.studentForm.Show();
                    break;
            }
        }
    }
}
