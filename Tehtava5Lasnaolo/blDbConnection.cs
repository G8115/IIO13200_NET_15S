using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Tehtava5Lasnaolo
{
    class blDbConnection
    {
        public string query;

        public blDbConnection()
        {
            query = ConfigurationManager.AppSettings["dbConnection"];
        }
        public DataTable dbSearch(String connectionString)
        {
            DataTable temp = new DataTable();
            // Open connection
            using (SqlConnection c = new SqlConnection(connectionString))
            {
                c.Open();
                // Create new DataAdapter
                using (SqlDataAdapter a = new SqlDataAdapter(query, c))
                {
                    // Use DataAdapter to fill DataTable
                    a.Fill(temp);
                }
            }
            return temp;
        }
    }
}
