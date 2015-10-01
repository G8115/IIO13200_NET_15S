using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

namespace Tehtava7LuntaSataaTalvella
{
    class blTehtava7
    {

    }

    public class getJson
    {
        private String urlBeginning = "http://rata.digitraffic.fi/api/v1/";
        public List<station> getStations()
        {
            return JsonConvert.DeserializeObject<List<station>>(readTextFrom(urlBeginning + "/metadata/station"));
        }
        public List<train> getTrains(String station)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<train>>(readTextFrom(urlBeginning + "live-trains?station=" + station ));
            }
            catch (Exception e)
            {
                List<train> temp = new List<train>();
                train perse = new train();
                perse.trainNumber = "ei junaa";
                perse.departureDate = "ei junaa";
                perse.cancelled = false;
                temp.Add(perse);
                return temp;
            }
        }

        private String readTextFrom(String url)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    return client.DownloadString(url);
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
    public class train
    {
        /*
        trainNumber":173,
        "departureDate":"2015-10-01",
        "operatorUICCode":10,
        "operatorShortCode":"vr",
        "trainType":"IC","trainCategory":"Long-distance",
        "runningCurrently":false,
        "cancelled":false,"version":5380998880,"
        */
        public String trainNumber { get; set; }
        public String departureDate { get; set; }
        public String operatorShortCode { get; set; }
        public bool cancelled { get; set; }

    }
    public class station
    {
        /*stationName":"Ahvenus",
        "stationShortCode":"AHV",
        "countryCode":
        "FI",
        "stationUICCode":1000,
        "longitude":22.49818444747139,
        "latitude":61.291923152550574
        */
        public String stationName { get; set; }
        public String stationShortCode { get; set; }
        public String countryCode { get; set; }
        public String stationUICCode { get; set; }
        public String longitude { get; set; }
        public String latitude { get; set; }
    }
}
