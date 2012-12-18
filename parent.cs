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
    public partial class parent : Form
    {
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
    }
}
