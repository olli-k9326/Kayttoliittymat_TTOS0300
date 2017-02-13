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

namespace L10T3_lottery
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        int rowAmount;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnDraw_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LotteryRows rows = new LotteryRows();

                if (int.TryParse(txtDrawsNumber.Text, out rowAmount))
                {
                    rows.AddRandomRows(rowAmount, cmbGameType.Text);
                    txbRandomNumbersResult.Text = rows.ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txbRandomNumbersResult.Text = "";
        }
    }
}
