using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Kindergarten
{
    static class func
    {
        public static MySqlConnection connection;
 
        public static void condb()
        {
            func.connection = new MySqlConnection("SERVER=localhost;DATABASE=kindergarten;UID=root;PASSWORD=;");
        }
    }
}

