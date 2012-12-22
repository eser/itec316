using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Kindergarten
{
    public static class func
    {
        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int mciSendString(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);

        public static MySqlConnection connection;
        public static login loginForm;
        public static admin adminForm;
        public static parent parentForm;
        public static student studentForm;
        public static string userid;

        public static void conn()
        {
            func.connection = new MySqlConnection("SERVER=localhost;DATABASE=kindergarten;UID=root;PASSWORD=;");
            func.connection.Open();

        }

        public static void start()
        {
            conn();
            func.loginForm = new login();
            // func.adminForm = new admin();
            // func.parentForm = new parent();
            // func.studentForm = new student();
        }

        public static void about(Form container)
        {
            MessageBox.Show(container, "about form");
        }
    }
}

