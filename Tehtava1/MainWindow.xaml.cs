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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }


        public float calculateWindowArea(float height, float width, float frameWidth)
        {
            return (height - 2 * frameWidth) * (width - 2 * frameWidth);
        }
        public float calculateFrameArea(float height, float width, float frameWidth)
        {
            return 2 * frameWidth * width + 2 * frameWidth * (height - 2 * frameWidth);
        }
        public float calculateradius(float height, float width)
        {
            return 2 * height + 2 * width;
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            //button tapahtumakäsittelijä
            //Tarkistetaan try catchillä että syöte on sopivaa 
            try
            {
                float height = float.Parse(textBoxWindowHeight.Text, System.Globalization.CultureInfo.InvariantCulture);
                float width = float.Parse(textBoxWindowWidth.Text, System.Globalization.CultureInfo.InvariantCulture);
                float frameWidth = float.Parse(textBoxFrameWidth.Text, System.Globalization.CultureInfo.InvariantCulture);
                txtWindowArea.Text = calculateWindowArea(height, width, frameWidth).ToString();
                txtFrameArea.Text = calculateFrameArea(height, width, frameWidth).ToString();
                txtFrameRadiai.Text = "sisäpiiri : " + calculateradius(height - 2 * frameWidth, width - 2 * frameWidth).ToString() + " | ulkopiiri : " + calculateradius(height, width).ToString();
            }
            catch
            {
                lblErrorMessage.Content = "Ole hyvä ja kirjoita numerot esimerkin mukaan eli näin 1.2";
            }

        }
    }
}
