using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava3PiruJaakiekot
{
    class blPiruJaakiekot
    {
        private List<Jaakiekkoilija> Pelaajat;
        public blPiruJaakiekot()
        {
              Pelaajat = new List<Jaakiekkoilija>();
              Pelaajat.Add(new Jaakiekkoilija("1", "1","a", 1));
              Pelaajat.Add(new Jaakiekkoilija("2", "2","a" , 1));
              Pelaajat.Add(new Jaakiekkoilija("3", "3", "a" , 1));
              Pelaajat.Add(new Jaakiekkoilija("4", "4", "a" , 1));
              Pelaajat.Add(new Jaakiekkoilija("5", "5", "aa" , 1));
              Pelaajat.Add(new Jaakiekkoilija("6", "6", "aa" , 1));
              Pelaajat.Add(new Jaakiekkoilija("7", "7", "aa" , 1));
              Pelaajat.Add(new Jaakiekkoilija("8", "8", "aa" , 1));
              Pelaajat.Add(new Jaakiekkoilija("9", "9", "aaa" , 1));
              Pelaajat.Add(new Jaakiekkoilija("10", "10", "aaa" , 1));
              Pelaajat.Add(new Jaakiekkoilija("11", "11", "aaa" , 1));
              Pelaajat.Add(new Jaakiekkoilija("12", "12", "aaa" , 1));
              Pelaajat.Add(new Jaakiekkoilija("13", "13", "aaaa" , 1));
              Pelaajat.Add(new Jaakiekkoilija("14", "14", "aaaa" , 1));
              Pelaajat.Add(new Jaakiekkoilija("15", "15", "aaaa" , 1));
              Pelaajat.Add(new Jaakiekkoilija("16", "16", "aaaa" , 1));

        }
        private bool checkName(String fName,String lName)
        {
            foreach(var p in Pelaajat)
            {
                if (p.FirstName.Equals(fName)||p.LastName.Equals(lName))
                    return false;
            }
            return true;
        }
        private bool checkOthersNames(Jaakiekkoilija j, String fName, String lName)
        {
            foreach (var p in Pelaajat)
            {
                if ((p.FirstName.Equals(fName) || p.LastName.Equals(lName))&&!p.Equals(j))
                    return false;
            }
            return true;
        }
        public void removePlayer(String nimi)
        {
            for(int i = 0; i < Pelaajat.Count; i++)
            {
                if (Pelaajat.ElementAt(i).FirstName.Equals(nimi))
                {
                    Pelaajat.RemoveAt(i);
                }
            }
        }
        public bool savePlayer(Jaakiekkoilija pelaaja, String fName, String lName, String team, int price)
        {
            if (checkOthersNames(pelaaja,fName, lName))
            {
                pelaaja.FirstName = fName;
                pelaaja.LastName = lName;
                pelaaja.team = team;
                pelaaja.Price = price;
                return true;
            }
            return false;
        }
        public List<String> getTeams()
        {
            List<String> temp = new List<string>();
            foreach( var p in Pelaajat)
            {
                if (!temp.Contains(p.team))
                {
                    temp.Add(p.team);
                }
            } 
            return temp;
        }
        public bool addPlayer(String fName, String lName, String team, int price)
        {
            if (checkName(fName, lName))
            {
                Pelaajat.Add(new Jaakiekkoilija(fName, lName, team, price));
                return true;
            }
            return false;
        }
        public List<Jaakiekkoilija> getPlayers(String team)
        {
            List<Jaakiekkoilija> tempList = new List<Jaakiekkoilija>();
            foreach(var p in Pelaajat)
            {
                if (p.team.Equals(team))
                {
                    tempList.Add(p);
                }
            }
            return tempList;
        }
    }
}
