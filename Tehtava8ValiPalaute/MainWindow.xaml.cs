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

namespace Tehtava8ValiPalaute
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        blTehtava8 business;
        public MainWindow()
        {
            init();
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            dgData.ItemsSource = business.readData();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!(txtBad.Equals("") && txtGood.Equals("") && txtLearned.Equals("") && txtName.Equals("") && txtPVM.Equals("") && txtWant.Equals("")))
            {
                business.saveData(new palaute(txtPVM.Text,txtName.Text,txtLearned.Text,txtWant.Text,txtGood.Text,txtBad.Text,txtOther.Text));
            }
        }
        private void init()
        {
            business = new blTehtava8();
        }
    }
}
