using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DataBindingT3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Tyontekija> tyontekijat;
        public MainWindow()
        {
            InitializeComponent();
            IniMyStuff();
        }
        private void IniMyStuff()
        {
            // tänne kootusti omien kontrollien alustukset

        }

        private void btnHaeTyontekijat_Click(object sender, RoutedEventArgs e)
        {
            haeTyontekijat();
        }

        private void btnTyhjenna_Click(object sender, RoutedEventArgs e)
        {

        }

        private void haeTyontekijat()
        {
            tyontekijat = new ObservableCollection<Tyontekija>();
            tyontekijat.Add(new Vakituinen("140211-312I", "Åsa", "Pelkonen",      1, "Chief Executive", 6430.30f));
            tyontekijat.Add(new Vakituinen("130981-303A", "Mikko", "Himanen",     2, "Claims examiner", 3023.01f));
            tyontekijat.Add(new Vakituinen("120383-8190", "Frans", "Takko",       3, "Forging machine setter", 3098.37f));
            tyontekijat.Add(new Vakituinen("021267-380H", "Tuija", "Poutiainen",  4, "Agricultural and food scientist", 3899.88f));
            LstTyontekijat.ItemsSource = tyontekijat;
        }

        private void LstTyontekijat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            spMiddle.DataContext = LstTyontekijat.SelectedItem;
        }

        /*
private void btnBind_Click(object sender, RoutedEventArgs e)
{
// Määritellään Stackpanelin DataContext
// Demo1: Datacontekstini on olio
HockeyTeam tiimi = new HockeyTeam("KeuPa", "Keuruu");
//spRight.DataContext = tiimi;
// demo2: kytketään olio-kokoelman 1.olioon
chooseTeam(counter);
}

private void btnForward_Click(object sender, RoutedEventArgs e)
{
if (counter < joukkueet.Count - 1)
{
counter++;
chooseTeam(counter);
}

}

private void btnBackward_Click(object sender, RoutedEventArgs e)
{
if (counter > 0)
{
counter--;
chooseTeam(counter);
}
}
private void chooseTeam(int place)
{
spRight.DataContext = joukkueet[place];
}

private void btnAddTeam_Click(object sender, RoutedEventArgs e)
{
HockeyTeam newTeam = new HockeyTeam(txtNewTeamName.Text, txtNewTeamCity.Text);
AddTeamToLeague(newTeam);
txtNewTeamName.Text = "";
txtNewTeamCity.Text = "";
}

private void AddTeamToLeague(HockeyTeam team)
{
joukkueet.Add(team);
}
*/
    }
}
