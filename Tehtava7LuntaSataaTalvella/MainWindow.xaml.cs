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

namespace Tehtava7LuntaSataaTalvella
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        getJson j;
        public MainWindow()
        {
            InitializeComponent();
            j = new getJson();
            cbDistrict.ItemsSource = j.getStations();
            cbDistrict.SelectedIndex = 1;
            cbDistrict.DisplayMemberPath = "stationName";
            cbDistrict.SelectedValuePath = "stationShortCode";
        }

        private void btnGetTrains_Click(object sender, RoutedEventArgs e)
        {
            dgData.ItemsSource = j.getTrains(cbDistrict.SelectedValue.ToString());
        }
    }
}
