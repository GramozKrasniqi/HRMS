using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    public class DALHelper
    {
        /// <summary>
        /// Static Create SqlDbConnection
        /// </summary>
        /// <returns></returns>
        internal static SqlConnection CreateSqlDbConnection()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["HRConnectionString"].ConnectionString);
            con.Open();
            return con;
        }
    }
}
