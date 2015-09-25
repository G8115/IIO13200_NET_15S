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
            dt = DBPlacebo.GetAllCustomersFromSQLServer(JAMK.ICT.Properties.Settings.Default.Tietokanta, "Viini", out viesti);
        }
        public DataTable GetAll()
        {
            return dt;
        }
        public List<String> GetCities()
        {
            List<String> tempString = new List<String>();
            foreach (DataRow row in dt.Rows)
            {
                tempString.Add(row["City"]);
            }
            return tempString;
        }
    }
}
