using System;
using System.Collections.Generic;
using System.Collections.ObjectModel; // for ObservableCollection
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
using JAMK.ICT;

namespace BindingDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        JAMK.ICT.HockeyLeague liiga;
        ObservableCollection<JAMK.ICT.HockeyTeam> joukkueet;
        int counter = 0;
        public MainWindow()
        {
            InitializeComponent();
            IniMyStuff();
        }
        private void IniMyStuff()
        {
            // tänne kootusti omien kontrollien alustukset
            List<string> muuvit = new List<string>();
            muuvit.Add("Halloween");
            muuvit.Add("Jaws");
            muuvit.Add("Star Wars");
            muuvit.Add("Pahat pojat");
            cmbMovies.ItemsSource = muuvit;

            // Haetaan SM-liiga joukkueet
            liiga = new JAMK.ICT.HockeyLeague();
            joukkueet = liiga.GetTeams();
            cmbTeams.ItemsSource = joukkueet;
        }

        private void btnBind_Click(object sender, RoutedEventArgs e)
        {
            // Määritellään Stackpanelin DataContext
            // Demo1: Datacontekstini on olio
            HockeyTeam tiimi = new HockeyTeam("KeuPa", "Keuruu");
            //spRight.DataContext = tiimi;
            // demo2: kytketään olio-kokoelman 1.olioon
            ChangeTeam();
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            if(counter < joukkueet.Count - 1)
            {
                counter++;
                ChangeTeam();
            }

        }

        private void btnBackward_Click(object sender, RoutedEventArgs e)
        {
            if (counter > 0)
            {
                counter--;
                ChangeTeam();
            }
        }
        private void ChangeTeam()
        {
            spRight.DataContext = joukkueet[counter];
        }

    }
}
