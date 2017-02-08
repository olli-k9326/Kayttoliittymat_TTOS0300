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

namespace L9T2_euro_markka_laskuri
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double converted;
        double eurToMk = 5.94573;
        bool start;
        public MainWindow()
        {
            InitializeComponent();
            start = true;

        }

        private void textBoxEUR_Mk_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            if (double.TryParse(Input.Text, out converted))
            {
                textBlockERROR.Text = " ";
                converted *= eurToMk;
                textBlockEUR_Mk_Result.Text = converted.ToString("0.00");
            }
            else if(start && Input.Text == "")
            {
                textBlockERROR.Text = "";
                textBlockEUR_Mk_Result.Text = "";

            }
            else if(start)
            {
                textBlockERROR.Text = "Incorrect input. Use ',' as separator";
            }
        }

        private void textBoxMk_EUR_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            if (double.TryParse(textBoxMk_EUR.Text, out converted))
            {
                textBlockERROR.Text = " ";
                converted /= eurToMk;
                textBlockMk_EUR_Result.Text = converted.ToString("0.00");
            }
            else if(start && Input.Text == "")
            {
                textBlockERROR.Text = "";
                textBlockMk_EUR_Result.Text = "";

            }
            else if(start)
            {
                textBlockERROR.Text = "Incorrect input. Use ',' as separator";
            }
        }
    }
}
