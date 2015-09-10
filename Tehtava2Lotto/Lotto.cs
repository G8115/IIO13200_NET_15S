using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication2
{
    class Lotto
    {
        public String tyyppi {get;set;}
        private int suurinNro;
        private int numeroLkm;
        private Random random;
        public Lotto(String Tyyppi, int suurinNumero, int nmrLkm)
        {
            tyyppi = Tyyppi;
            suurinNro = suurinNumero;
            numeroLkm = nmrLkm;
            random = new Random();
        }
        public List<int> arvoRivi()
        {
            List<int> tempList=new List<int>();

            int tempNro;
            for(int i = 0; i < numeroLkm;)
            {
                tempNro = random.Next(1,suurinNro);
                if (!tempList.Contains(tempNro))
                {
                    i++;
                    tempList.Add(tempNro);
                }
            }
            return tempList;
        }
        public override string ToString()
        {
            return tyyppi;
        }
    }
}
