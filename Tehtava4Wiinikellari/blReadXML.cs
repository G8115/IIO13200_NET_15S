using System;
using System.Configuration;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tehtava4Wiinikellari
{
    class blReadXML
    {
        public string path;

        public blReadXML()
        {
            path = ConfigurationManager.AppSettings["fileLocation"] +"\\"+ ConfigurationManager.AppSettings["fileName"];
        }

        //used to change filelocation programmatically
        public void UpdateLocationSetting(string value)
        {
            string key = "fileLocation";//xml key to find file location in xml file
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);//finds the app.config filelocation
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save();

            ConfigurationManager.RefreshSection("appSettings");
            path = ConfigurationManager.AppSettings["fileLocation"] + "\\" + ConfigurationManager.AppSettings["fileName"];
        }
        //used to change filename programmatically
        public void UpdateFileNameSetting(string value)
        {
            string key = "fileName";//xml key to find file location in xml file
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);//finds the app.config filelocation
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save();

            ConfigurationManager.RefreshSection("appSettings");
            path = ConfigurationManager.AppSettings["fileLocation"] + "\\" + ConfigurationManager.AppSettings["fileName"];
        }
        /*
        //serialize hockeyteam list into an xml file
        public void writeData(List<J> j)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(List<Jaakiekkoilija>));
            System.IO.FileStream file = System.IO.File.Create(path);
            writer.Serialize(file, j);
            file.Close();
        }
        */
        //deserialize wine list from an xml file
        public List<wine> readData()
        {
            List<wine> j = new List<wine>();
            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(List<wine>));
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            j = (List<wine>)reader.Deserialize(file);
            /*
            while (!file.EndOfStream)
            {
                j.Add((wine)reader.Deserialize(file));
            }
            */
            file.Close();
            return j;
        }
    }
}
