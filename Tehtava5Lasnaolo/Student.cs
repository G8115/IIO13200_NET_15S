using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//temporay class done without knowing the db structure
namespace Tehtava5Lasnaolo
{
    class Student
    {
        public String asioid { get; set; }
        public String lastname { get; set; }
        public String firstname { get; set; }
        public DateTime date { get; set; }
        public Student()
        {
            asioid = "";
            lastname = "";
            firstname = "";
            date = new DateTime();
        }
    }
}
