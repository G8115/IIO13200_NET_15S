using System;
using System.Configuration;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tehtava3PiruJaakiekot
{

    class blReadFromFile
    {
        public string path;

        public blReadFromFile()
        {
            path = ConfigurationManager.AppSettings["fileLocation"] + "//JohanNytOn.xml";
        }

        //used to change filelocation programmatically
        public void UpdateSetting(string value)
        {
            string key = "fileLocation";//xml key to find file location in xml file
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);//finds the app.config filelocation
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save();

            ConfigurationManager.RefreshSection("appSettings");
            path = ConfigurationManager.AppSettings["fileLocation"] + "//JohanNytOn.xml";
        }
        //serialize hockeyteam list into an xml file
        public void writeData(List<Jaakiekkoilija> j)
        {
            try
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
            catch (Exception)
            {
            }
        }
        //deserialize hockeyteam list from an xml file
        public List<Jaakiekkoilija> readData()
        {
            List<Jaakiekkoilija> j = new List<Jaakiekkoilija>();
            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(List<Jaakiekkoilija>));
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            j = (List<Jaakiekkoilija>)reader.Deserialize(file);
            file.Close();
            return j;
        }
    }
}
