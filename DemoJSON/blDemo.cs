using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace DemoJSON
{
    public class person
    {
        public string name { get; set; }
        public string gender { get; set; }
        public string birthday { get; set; }
        public person()
        {
            name = "";
            gender = "";
            birthday = "";
        }
    }
    public class politik : person
    {
        public string party { get; set; }
        //jos nimet eri käytä seuraavaa
        [JsonProperty("position")]
        public string virka { get; set; }
    }

}
