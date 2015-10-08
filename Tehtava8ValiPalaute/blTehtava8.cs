using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tehtava8ValiPalaute
{
    class blTehtava8
    {
        public List<palaute> palautteet;
        String path = "Z:\\Palautteet.xml";//"\\\\ghost.labranet.jamk.fi\\temp\\Palautteet.xml";
        public blTehtava8()
        {
            palautteet = new List<palaute>();
        }


        public List<palaute> readData()
        {
            palautteet = new List<palaute>();
            XmlSerializer reader = new XmlSerializer(typeof(List<palaute>), new XmlRootAttribute("palautteet"));
            StreamReader file = new StreamReader(path);
            palautteet = (List<palaute>)reader.Deserialize(file);
            file.Close();
            return palautteet;
        }
        public bool saveData(palaute p)
        {
            try
            {
                List<palaute> ps = readData();
                ps.Add(p);                  
                XmlSerializer writer = new XmlSerializer(typeof(palaute));

                FileStream file = File.Open(path,FileMode.Open);
                writer.Serialize(file, ps);

                file.Close();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }

}
