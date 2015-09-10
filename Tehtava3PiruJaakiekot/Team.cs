using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava3PiruJaakiekot
{
    class Team
    {
        public String Name { get; }
        public List<Jaakiekkoilija> Players;
        public Team(String name)
        {
            Name = name;
            Players = new List<Jaakiekkoilija>();
        }
        public override string ToString()
        {
            return Name;
        }
        public void removePlayer(String nimi)
        {
            for(int i = 0; i < Players.Count; i++)
            {
                if (Players.ElementAt(i).FirstName.Equals( nimi,StringComparison.Ordinal))
                    Players.RemoveAt(i);
            }
        }
    }
}
