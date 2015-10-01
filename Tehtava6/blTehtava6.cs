using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using JAMK.ICT.ADOBlanco;

namespace JAMK.ICT
{
    class blTehtava6
    {
        private String viesti = "";
        private DataTable dt;
        public blTehtava6()
        {
            dt = new DataTable();
            dt = DBPlacebo.GetAllCustomersFromSQLServer(JAMK.ICT.Properties.Settings.Default.Tietokanta, "customer", out viesti);
        }
        public DataTable GetAll()
        {
            return dt;
        }
        public DataTable GetCustemersPerCity(String city)
        {
            String query = @"City = '"+city+"'";
            DataTable filtereDataTable = dt.Select(query).CopyToDataTable();
            return filtereDataTable;
        }
        public List<String> GetCities()
        {
            List<String> tempString = new List<String>();
            foreach (DataRow row in dt.Rows)
            {
                if (!tempString.Contains(row[5].ToString()))
                    tempString.Add(row[5].ToString());
            }
            return tempString;
        }
    }
}
