/*
 * Created by SharpDevelop.
 * User: garnett
 * Date: 20.11.2010
 * Time: 12:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using Kindergarten;

namespace Snake
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
        public static string[] arg;

		[STAThread]
		private static void Main(string[] args)
		{
            arg = args;
            if (arg.Length > 0)
            {
                Kindergarten.func.conn();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MyGame());
            }
            
		}
		
	}
}
