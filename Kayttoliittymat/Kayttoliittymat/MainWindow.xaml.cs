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

namespace Kayttoliittymat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int car;
        private int truck;
        public MainWindow()
        {
            InitializeComponent();
            car = 0;
            truck = 0;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            car++;
            textBlock.Text = car.ToString();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            truck++;
            textBlock2.Text = truck.ToString();
        }
    }
}
