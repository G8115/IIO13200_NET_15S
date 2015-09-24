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
using System.Data;

namespace Tehtava5Lasnaolo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        blTehtava5 businesslokiikka;
        public MainWindow()
        {
            InitializeComponent();
            businesslokiikka=new blTehtava5();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            dgData.ItemsSource = businesslokiikka.GetStudent(txtSearch.Text).AsDataView();
        }

        private void btnGetAll_Click(object sender, RoutedEventArgs e)
        {
            dgData.ItemsSource = businesslokiikka.GetAllStudents().AsDataView();
        }
    }
}
