using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava5Lasnaolo
{
    class blTehtava5
    {
        private DataTable dt;
        public blTehtava5()
        {
            dt = new DataTable();
            dt = DataBaseConnection.GetAll();
        }
        public DataTable GetAllStudents()
        {
            return dt;
        }
        public DataTable GetStudent(String naem)
        {
            //"SELECT asioid,lastname,firstname,date FROM lasnaolot";
            String query = @"asioid like '%" + naem + "%' OR lastname like '%" + naem + "%' OR firstname like '%" + naem + "%'";
            DataTable filtereDataTable = dt.Select(query).CopyToDataTable();
            return filtereDataTable;
        }
    }
}
