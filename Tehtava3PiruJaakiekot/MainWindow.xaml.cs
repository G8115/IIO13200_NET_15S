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
        private blPiruJaakiekot businessTyhmyys;
        private bool newPlayer;
        public MainWindow()
        {
            InitializeComponent();

            businessTyhmyys = new blPiruJaakiekot();

            newPlayer = true;
            List<String> tempTeamNames = new List<string>();
            tempTeamNames = businessTyhmyys.getTeams();
            foreach(var a in tempTeamNames)
                cbTeams.Items.Add(a);
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            setMessage("Syötä uuden pelaajan tiedot ja paina tallenna napiketta");
            newPlayer = true;
            txtBoxFirstName.Text = "";
            txtBoxLastName.Text = "";
            txtBoxPrice.Text = "";
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            int temp = getPrice();
            if (temp != -1)
            {
                if (newPlayer)
                {
                    if (businessTyhmyys.addPlayer(txtBoxFirstName.Text, txtBoxLastName.Text, cbTeams.SelectedItem.ToString(), temp))
                    {
                        setMessage("Uusi pelaaja lisätty onnistuneesti");
                    }
                    else
                    {
                        setMessage("Nimi on jo olemassa");
                    }
                }
                else
                {
                    if (businessTyhmyys.savePlayer((Jaakiekkoilija)lbTeamPlayers.SelectedItem, txtBoxFirstName.Text, txtBoxLastName.Text, cbTeams.SelectedItem.ToString(), temp))
                    {
                        setMessage("Tiedot tallennettu");
                    }
                    else
                    {
                        setMessage("Nimi on jo olemassa");
                    }
                }
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            setMessage("pelaaja poistettu onnistuneesti");
            businessTyhmyys.removePlayer(txtBoxFirstName.Text);
        }

        private void btnLoadPlayers_Click(object sender, RoutedEventArgs e)
        {
            setMessage("tiedot ladattu");
            lbTeamPlayers.Items.Clear();
            List<Jaakiekkoilija> tempJaakiekkoList= new List<Jaakiekkoilija>();
            tempJaakiekkoList = businessTyhmyys.getPlayers(cbTeams.SelectedItem.ToString());
            foreach (var t in tempJaakiekkoList)
                lbTeamPlayers.Items.Add(t);
        }

        private void btnEnd_Click(object sender, RoutedEventArgs e)
        {
            setMessage("hei hei");
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
            setMessage("");
            newPlayer = false;
            Jaakiekkoilija tempKiekkoilija = (Jaakiekkoilija)((ListBox)sender).SelectedItem;
            if (lbTeamPlayers.SelectedIndex >= 0)
            {
                txtBoxFirstName.Text = tempKiekkoilija.FirstName;
                txtBoxLastName.Text = tempKiekkoilija.LastName;
                txtBoxPrice.Text = tempKiekkoilija.Price.ToString();
            }
        }
    }
}
