using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Trabalho_Jef
{
    internal class DbHelper
    {
        public static MySqlConnection GetConnection()
        {
            string connectionString = "server=localhost;database=seubanco;uid=root;pwd=senha;";
            return new MySqlConnection(connectionString);
        }
    }
}
