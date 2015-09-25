//Koodannut ja testannut toimivaksi 6.3.2014 EsaSalmik
using System;
using System.Collections.Generic;
using System.Data;
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

namespace JAMK.ICT.ADOBlanco
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        String viesti;
        blTehtava6 businesss;
        public MainWindow()
        {
            InitializeComponent();
            IniMyStuff();
        }

        private void IniMyStuff()
        {
            //TODO täytetään combobox asiakkaitten kaupunkien nimillä // ei pysty koska mitään ei tietokannasta kerrota
            //esimerkki kuinka App.Configissa oleva connectionstring luetaan
            lbMessages.Content = JAMK.ICT.Properties.Settings.Default.Tietokanta;
            businesss = new blTehtava6();
            var tenp = businesss.GetCities();
            foreach (var s in tenp)
            {
                cbCountries.Items.Add(s);
            }
        }

        private void btnGet3_Click(object sender, RoutedEventArgs e)
        {
            //TODO
            dgCustomers.ItemsSource = DBPlacebo.GetTestCustomers().AsDataView();
        }

        private void btnGetAll_Click(object sender, RoutedEventArgs e)
        {
            //TODO
            // ei voi hakea tietoa tietokannasta jota ei tunne
            //dgCustomers.ItemsSource = DBPlacebo.GetAllCustomersFromSQLServer(JAMK.ICT.Properties.Settings.Default.Tietokanta,"",out viesti).AsDataView();
            dgCustomers.ItemsSource = businesss.GetAll().AsDataView();
        }

        private void btnGetFrom_Click(object sender, RoutedEventArgs e)
        {
            //TODO
            //hakutermiin tulisi lisätä comboboxin maa mutta koska ei mitään hajua databasesta ei voi mitään
            //dgCustomers.ItemsSource = DBPlacebo.GetAllCustomersFromSQLServer(JAMK.ICT.Properties.Settings.Default.Tietokanta, "", out viesti).AsDataView();
            dgCustomers.ItemsSource = businesss.GetCustemersPerCity(cbCountries.SelectedItem.ToString()).AsDataView();
        }

        private void btnYield_Click(object sender, RoutedEventArgs e)
        {
            //opettaja ei missään kerro mitään jsonista
            JAMK.ICT.JSON.JSONPlacebo2015 roskaa = new JAMK.ICT.JSON.JSONPlacebo2015();
            MessageBox.Show(roskaa.Yield());
        }
    }
}
