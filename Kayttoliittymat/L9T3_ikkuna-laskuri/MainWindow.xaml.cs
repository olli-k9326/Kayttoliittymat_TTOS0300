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

namespace L9T3_ikkuna_laskuri
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double ikkunaL, ikkunaK, karmipuuW, ikkunaPA, lasiPA, KarmiP;
        bool ikkunaL_OK = false;
        bool ikkunaK_OK = false;
        bool karmipuuW_OK = false;
        bool start = false;
        public MainWindow()
        {
            InitializeComponent();
            start = true;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ikkunaL_OK = double.TryParse(inputIkkunaL.Text, out ikkunaL);  // onko kunnon syötteet
                ikkunaK_OK = double.TryParse(inputIkkunaK.Text, out ikkunaK);
                karmipuuW_OK = double.TryParse(inputKarmiW.Text, out karmipuuW);

                if (ikkunaL_OK && ikkunaK_OK && karmipuuW_OK)
                {
                    if ((ikkunaL - 2 * karmipuuW < 0) || (ikkunaK - 2 * karmipuuW < 0)) // tarkistetaan onko karmit sopivan kokoiset
                    {
                        textBlock_error.Text = " Liian leveät karmit suhteessa leveyteen tai korkeuteen.";
                        return;
                    }
                    textBlock_error.Text = "";
                    CalculateIkkunaAla();

                    Output(ikkunaPA.ToString("0.00 cm^2"), lasiPA.ToString("0.00 cm^2"), KarmiP.ToString("0.00 cm"));
                }
                else
                {
                    textBlock_error.Text = "Jossakin kentässä on väärä syöte. Käytä pilkkua erottimena.";
                    Output("", "", "");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void CalculateIkkunaAla()               // Pinta-alojen laskenta
        {
            try
            {
                ikkunaPA = ikkunaL * ikkunaK / 100;

                KarmiP = 2 * (ikkunaL + ikkunaK) / 10;

                if ((ikkunaL - 2 * karmipuuW >= 0) && (ikkunaK - 2 * karmipuuW >= 0))
                {
                    lasiPA = (ikkunaL - 2 * karmipuuW) * (ikkunaK - 2 * karmipuuW) / 100;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Output(string x, string y, string z)           // Pinta-alojen tulostus
        {
            try
            {
                outputIkkunaAla.Text = x;
                outputLasiAla.Text = y;
                outputKarmiP.Text = z;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
        
}
