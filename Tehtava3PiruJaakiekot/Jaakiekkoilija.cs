using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava3PiruJaakiekot
{
    public class Jaakiekkoilija
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int Price { get; set; }
        public String team { get; set; }
        public Jaakiekkoilija()
        {
            FirstName = "";
            LastName = "";
            Price = 1;
            team = ""; 
        }
        public Jaakiekkoilija(String Fname,String LName,String Team,int TransferPrice)
        {
            FirstName = Fname;
            LastName = LName;
            team = Team;
            Price = TransferPrice;
        }
        public override string ToString()
        {
            return FirstName+" "+LastName+", "+team;
        }
    }
}
