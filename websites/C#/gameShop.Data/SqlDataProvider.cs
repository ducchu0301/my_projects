using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace gameShop.Data
{
    public class SqlDataProvider
    {
        public static string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString.ToString();
        public static SqlConnection connection;
        public SqlDataProvider()
        {
            if (connection == null)
            {
                connection = new SqlConnection(connectionstring);
            }
        }
        public SqlConnection GetConnection()
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Close();
                connection.Open();
                return connection;
            }
            else
            {
                return connection;
            }
        }

    }
}
