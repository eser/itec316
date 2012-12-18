using MySql.Data.MySqlClient;

namespace Kindergarten
{
    static class func
    {
        public static MySqlConnection connection;
        public static login loginForm;
        public static admin adminForm;

        public static void start()
        {
            func.connection = new MySqlConnection("SERVER=localhost;DATABASE=kindergarten;UID=root;PASSWORD=paddole;");
            func.connection.Open();

            func.loginForm = new login();
            // func.adminForm = new admin();
        }
    }
}

