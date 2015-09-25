using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava5Lasnaolo
{
    public static class DataBaseConnection
    {
        public static DataTable GetAll()
        {
            // basic principle: connect - execute query - disconnect
            try
            {
                String connStr = System.Configuration.ConfigurationManager.ConnectionStrings["Lasnaolot"].ConnectionString; ;
                SqlConnection myConn = new SqlConnection(connStr);
                myConn.Open();
                SqlCommand cmd = new SqlCommand("SELECT asioid,lastname,firstname,date FROM lasnaolot", myConn);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                myConn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /*Turha sillä on parempi käsitellä Datatablea erikseen
        public static DataTable GetMy(String name)
        {
            // basic principle: connect - execute query - disconnect
            try
            {
                String connStr = System.Configuration.ConfigurationManager.ConnectionStrings["Lasnaolot"].ConnectionString; ;
                SqlConnection myConn = new SqlConnection(connStr);
                myConn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM lasnaolot WHERE ", myConn);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                myConn.Close();
                return dt;
            }
            catch (Exception ex)
            {
            //kunhan on jokin muutos luokassa jonka pitäisi mennä puhiin mukaan
                return null;
            }
        }
        */
    }
}
