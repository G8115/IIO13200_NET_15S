using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava8ValiPalaute
{
    public class palaute
    {
        public String pvm { get; set; }
        public String tekija { get; set; }
        public String opittu { get; set; }
        public String haluanoppia { get; set; }
        public String hyvaa { get; set; }
        public String parannettavaa { get; set; }
        public String muuta { get; set; }
        public palaute()
        {
            pvm = "";
            tekija = "";
            opittu = "";
            haluanoppia = "";
            hyvaa = "";
            parannettavaa = "";
            muuta = "";
        }
        public palaute(String pvm0,String tekija0,String opittu0,String haluanoppia0,String hyvaa0,String parannettavaa0,String muuta0)
        {
            pvm = pvm0;
            tekija = tekija0;
            opittu = opittu0;
            haluanoppia = haluanoppia0;
            hyvaa = hyvaa0;
            parannettavaa = parannettavaa0;
            muuta = muuta0;
        }
    }
}
