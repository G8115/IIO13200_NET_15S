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

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Lotto lotto1;
        private Lotto lotto2;
        private Lotto lotto3;
        private Lotto lotto4;
        private Lotto templotto;
        private List<Lotto> lotot;
        public MainWindow()
        {
            InitializeComponent();
            lotto1 = new Lotto("Suomi", 39, 7);
            lotto2 = new Lotto("Viking", 48, 6);
            lotto3 = new Lotto("Euro", 50, 5);
            lotto4 = new Lotto("Euro+", 8, 2);

            //cbGames.ItemsSource = lotot;
            cbGames.Items.Add(lotto1);
            cbGames.Items.Add(lotto2);
            cbGames.Items.Add(lotto3);
        }

        private void btnDraw_Click(object sender, RoutedEventArgs e)
        {
            int tempDrawNumber = 0;
            if (int.TryParse(txtbNumberOfDraws.Text, out tempDrawNumber))
            {
                for (int i = 0; i < tempDrawNumber; i++)
                {
                    List<int> templist = new List<int>();
                    Lotto l = (Lotto)cbGames.SelectedItem;
                    String tempString = "";
                    templist.AddRange(l.arvoRivi());
                    if (l.tyyppi == "Euro")
                    {
                        templist.AddRange(lotto4.arvoRivi());
                    }
                    foreach (int a in templist)
                    {
                        tempString += a.ToString() + ",";
                    }
                    tempString = tempString.Remove(tempString.Length - 1);
                    tempString += Environment.NewLine;
                    txtboxResults.Text += tempString;
                }
            }
            else
            {
                txtblockErrorMsg.Text = "Kirjoita kokonaisluku";
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtblockErrorMsg.Text = "";
            txtboxResults.Text = "";
        }
    }
}
