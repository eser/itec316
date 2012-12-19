using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Kindergarten
{
    static class func
    {
        public static MySqlConnection connection;
        public static login loginForm;
        public static admin adminForm;
        public static parent parentForm;
        public static student studentForm;

        public static void start()
        {
            func.connection = new MySqlConnection("SERVER=localhost;DATABASE=kindergarten;UID=root;PASSWORD=paddole;");
            func.connection.Open();

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

