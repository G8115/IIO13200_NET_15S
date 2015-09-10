using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Tehtava3PiruJaakiekot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Team> tiimit;
        private Jaakiekkoilija tempKiekkoilija;
        private bool uusiPelaaja;
        public MainWindow()
        {
            InitializeComponent();

            tempKiekkoilija = new Jaakiekkoilija("", "", "", 1);

            tiimit = new List<Team>();
            tiimit.Add(new Team("a"));
            tiimit.Add(new Team("aa"));
            tiimit.Add(new Team("aaa"));
            tiimit.Add(new Team("aaaa"));
            tiimit.ElementAt(0).Players.Add(new Jaakiekkoilija("1", "1", tiimit.ElementAt(0).Name, 1));
            tiimit.ElementAt(0).Players.Add(new Jaakiekkoilija("2", "2", tiimit.ElementAt(0).Name, 1));
            tiimit.ElementAt(0).Players.Add(new Jaakiekkoilija("3", "3", tiimit.ElementAt(0).Name, 1));
            tiimit.ElementAt(0).Players.Add(new Jaakiekkoilija("4", "4", tiimit.ElementAt(0).Name, 1));
            tiimit.ElementAt(1).Players.Add(new Jaakiekkoilija("5", "5", tiimit.ElementAt(1).Name, 1));
            tiimit.ElementAt(1).Players.Add(new Jaakiekkoilija("6", "6", tiimit.ElementAt(1).Name, 1));
            tiimit.ElementAt(1).Players.Add(new Jaakiekkoilija("7", "7", tiimit.ElementAt(1).Name, 1));
            tiimit.ElementAt(1).Players.Add(new Jaakiekkoilija("8", "8", tiimit.ElementAt(1).Name, 1));
            tiimit.ElementAt(2).Players.Add(new Jaakiekkoilija("9", "9", tiimit.ElementAt(2).Name, 1));
            tiimit.ElementAt(2).Players.Add(new Jaakiekkoilija("10", "10", tiimit.ElementAt(2).Name, 1));
            tiimit.ElementAt(2).Players.Add(new Jaakiekkoilija("11", "11", tiimit.ElementAt(2).Name, 1));
            tiimit.ElementAt(2).Players.Add(new Jaakiekkoilija("12", "12", tiimit.ElementAt(2).Name, 1));
            tiimit.ElementAt(3).Players.Add(new Jaakiekkoilija("13", "13", tiimit.ElementAt(3).Name, 1));
            tiimit.ElementAt(3).Players.Add(new Jaakiekkoilija("14", "14", tiimit.ElementAt(3).Name, 1));
            tiimit.ElementAt(3).Players.Add(new Jaakiekkoilija("15", "15", tiimit.ElementAt(3).Name, 1));
            tiimit.ElementAt(3).Players.Add(new Jaakiekkoilija("16", "16", tiimit.ElementAt(3).Name, 1));

            foreach(var a in tiimit)
                cbTeams.Items.Add(a);
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            uusiPelaaja = true;
            tempKiekkoilija = new Jaakiekkoilija("", "", "", 1);
            txtBoxFirstName.Text = "";
            txtBoxLastName.Text = "";
            txtBoxPrice.Text = "";
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
 
            int temp = getPrice();
            if (temp != -1)
            {
                if (!uusiPelaaja)
                    foreach (var t in tiimit)
                        t.removePlayer(tempKiekkoilija.FirstName);

                if (checkName(txtBoxFirstName.Text, txtBoxLastName.Text))
                {
                    tempKiekkoilija.FirstName = txtBoxFirstName.Text;
                    tempKiekkoilija.LastName = txtBoxLastName.Text;
                    tempKiekkoilija.Price = temp;
                    tempKiekkoilija.team = cbTeams.SelectedItem.ToString();

                    tiimit.Find(r => r.Name == cbTeams.SelectedItem.ToString()).Players.Add(tempKiekkoilija);
                }
                else
                {
                    setMessage("Nimi on jo olemassa");
                }
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            ((Team)cbTeams.SelectedItem).removePlayer(tempKiekkoilija.FirstName);
        }

        private void btnLoadPlayers_Click(object sender, RoutedEventArgs e)
        {
            lbTeamPlayers.SelectedIndex=-1;
            lbTeamPlayers.Items.Clear();
            Team temp = (Team)cbTeams.SelectedItem;
            foreach (var o in temp.Players)
                lbTeamPlayers.Items.Add(o);
        }

        private void btnEnd_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private int getPrice()
        {
            int tempNumber=-1;
            if (int.TryParse(txtBoxPrice.Text, out tempNumber))
            {
                
            }
            else
            {
                setMessage( "Syötä Siirtohinnaksi kokonaisluku");
            }
            return tempNumber;

        }

        private void setMessage(String s)
        {
            txtErrors.Text = s;
        }

        private void lbTeamPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
                uusiPelaaja = false;
                tempKiekkoilija =(Jaakiekkoilija) ((ListBox)sender).SelectedItem;
            if (lbTeamPlayers.SelectedIndex>=0)
            {
                txtBoxFirstName.Text = tempKiekkoilija.FirstName;
                txtBoxLastName.Text = tempKiekkoilija.LastName;
                txtBoxPrice.Text = tempKiekkoilija.Price.ToString();
            }
        }
        private bool checkName(String firstName,String lastName)
        {
            foreach (var m in tiimit)
            {
                foreach (var n in m.Players)
                {
                    if (n.FirstName.Equals(txtBoxFirstName.Text, StringComparison.Ordinal) 
                        || n.LastName.Equals(txtBoxLastName.Text, StringComparison.Ordinal))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
