using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava4Wiinikellari
{
    public class wine
    {
        public String nimi { set; get; }
        public String maa { set; get; }
        public int arvio { set; get; }

        public wine()
        {
            nimi = "";
            maa = "";
            arvio= 0;
        }
        public wine(String name,String country,int score)
        {
            nimi = name;
            maa = country;
            arvio = score;
        }
    }
}
