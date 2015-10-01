using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.Net;

namespace DemoJSON
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string json = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGet_Click(object sender, RoutedEventArgs e)
        {
            Demo2();
        }

        private void Demo1()
        {
            //haetaan json
            json = getSimpleJSON();
            //deserialisoidaan json
            List<person> persons = JsonConvert.DeserializeObject<List<person>>(json);
            //naytetaan UI:ssa
            dgData.DataContext = persons;
        }
        private void Demo2()
        {
            dgData.DataContext = JsonConvert.DeserializeObject<List<politik>>(readTextFrom("http://student.labranet.jamk.fi/~salesa/mat/JsonTest"));
        }

        private string getSimpleJSON()
        {
            return @"[{'name':'olli1','gender':'male','birthday':'1995-12-14'},
                      {'name':'olli2','gender':'male','birthday':'1995-12-14'},
                      {'name':'olli3','gender':'male','birthday':'1995-12-14'},
                      {'name':'olli4','gender':'male','birthday':'1995-12-14'},
                      {'name':'olli5','gender':'male','birthday':'1995-12-14'}]";
        }
        private string readTextFrom(string url)
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
}
