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

namespace L10T4_Kiuas
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string valueString = "0";
        public MainWindow()
        {
            InitializeComponent();

        }

        private void btnNumber_Click(object sender, RoutedEventArgs e)
        {
            string buttonString = (((Button)sender).Content).ToString();
            valueString += buttonString;
            txtValue.Text = valueString;
        }

        private void btnErase_Click(object sender, RoutedEventArgs e)
        {
            if (valueString.Length >= 1)
            {
                valueString = valueString.Substring(0, valueString.Length - 1);
                txtValue.Text = valueString;
            }
        }

        private void brnOK_Click(object sender, RoutedEventArgs e)
        {
            double valueDouble;
            
            if (double.TryParse(valueString, out valueDouble))
            {

                if((bool)rdbTemperature.IsChecked)
                {
                    txbTemperature.Text = valueDouble.ToString();
                }
                if ((bool)rdbHumidity.IsChecked)
                {
                    txbHumidity.Text = valueDouble.ToString();
                }
            }
        }

        private void txtValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            valueString = txtValue.Text;
        }
    }
    public class Kiuas
    {

        // kosteus voi olla välillä 0-100
        float humidity;
        public float Humidity
        {
            get { return humidity; }

            set
            {
                humidity = value;
                if (humidity < 0)
                    humidity = 0;
                if (humidity > 100)
                    humidity = 100;
            }
        }
        private float temperature;

        public float Temperature
        {
            get { return temperature; }
            set
            {
                temperature = value;
                if (temperature < 0)
                    temperature = 0;
                if (temperature > 100)
                    temperature = 100;
            }
        }



    }
}
