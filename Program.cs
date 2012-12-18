using System;
using System.Windows.Forms;

namespace Kindergarten
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            func.start();
            Application.Run(func.loginForm);
        }
    }
}
