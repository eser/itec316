using System;
using System.Windows.Forms;
using Kindergarten;

namespace toh
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
        public static string[] arg;
        [STAThread]
        static void Main(string[] args)
        {
            arg = args;
            if (arg.Length > 0)
            {
                Kindergarten.func.conn();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new GameForm());
            }
        }
	}
}
