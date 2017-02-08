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

namespace L10T1
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            txbShoppingList.Text = "";
            if(chk1.IsChecked == true)
            {
                txbShoppingList.Text += chk1.Content + "\n";
            }
            if (chk2.IsChecked == true)
            {
                txbShoppingList.Text += chk2.Content + "\n";
            }
            if (chk3.IsChecked == true)
            {
                txbShoppingList.Text += chk3.Content + "\n";
            }
            if (chk4.IsChecked == true)
            {
                txbShoppingList.Text += chk4.Content + "\n";
            }
            if (chk5.IsChecked == true)
            {
                txbShoppingList.Text += chk5.Content + "\n";
            }
            if (chk6.IsChecked == true)
            {
                txbShoppingList.Text += chk6.Content + "\n";
            }
        }
    }
    
    

    /*
        // loop trough all stackpanel controls including checkboxes
        foreach(object control in stackPanel.Children)
        {
            // tarkistetaan onko kontrolli luokasta Checkbox
            if (control is Checkbox)
            {
                Checkbox checkBox = (CheckBox)Control;
                if((bool)checBox.isChecked) items += CheckBox.Content + " ";
            }
        }
            // display
        buyTextBox.Text = items;
        */

}
