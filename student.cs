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
    }
}
