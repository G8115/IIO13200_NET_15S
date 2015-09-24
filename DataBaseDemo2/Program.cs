using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseDemo2
{
    class Program
    {
        //ado datareader demonstration
        static void Main(string[] args)
        {
            try
            {
                string sql = "";
                sql = "SELECT * FROM lasnaolot WHERE asioid='G8115';";
                string connStr = @"Data Source=eight.labranet.jamk.fi;Initial Catalog=DemoxOy;User ID=koodari;Password=koodari13";
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    //avataan db yhteys
                    conn.Open();
                    // luodaan komento olio
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        //luodaan reader
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            //käydään reader läpi
                            if (rdr.HasRows)
                                while (rdr.Read())
                                {
                                    Console.WriteLine("{0}\t{1}\t{2}\t{3}", rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetDateTime(4).ToString());
                                }
                            //suljetaan reader;
                            rdr.Close();
                        }
                    }
                    //suljetaan connection;
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
