using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace Tehtava4Wiinikellari
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<wine> viinit;
        List<wine> searchResult;
        blReadXML reader;
        public MainWindow()
        {
            InitializeComponent();

            reader = new blReadXML();
            viinit = new List<wine>();
            searchResult = new List<wine>();
            try
            {
                viinit = reader.readData();
                txtError.Text = reader.path;
            }
            catch
            {
                //tahan virheilmoitus että ei ole tiedostoa
                txtError.Text = reader.path+"ei ole olemassa";//"Tiedostoa "+ ConfigurationManager.AppSettings["fileName"]+" ei lyötynyt paikasta "+ ConfigurationManager.AppSettings["fileLocation"];
            }
            foreach(var w in viinit)
            {
                if(!cbSelection.Items.Contains(w.maa))
                    cbSelection.Items.Add(w.maa);
            }
            cbSelection.SelectedIndex = 1;
        }

        private void btnSort_Click(object sender, RoutedEventArgs e)
        {
            searchResult.Clear();
            foreach (var w in viinit)
            {
                if (w.maa.Equals(cbSelection.SelectedItem.ToString()))
                {
                    searchResult.Add(w);
                }
            }
            dgDisplayWines.ItemsSource = null;
            dgDisplayWines.ItemsSource = searchResult;

        }
    }
}
