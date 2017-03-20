using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading; // SÄIETTÄ VARTEN
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
using JAMK.IT;
namespace WPFVRTrains
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Train> trains = new List<Train>();
        string selectedStation = "";
        public MainWindow()
        {
            InitializeComponent();
            InitializeMyStuff();
        }
        
        #region METHODS
        void InitializeMyStuff()
        {
            //omat asetukset kootaan tänne
            // täytetään combobos asemilla
            GetStations();
        }
        private void GetStations()
        {
            List<Station> stations = new List<Station>();
            stations.Add(new Station("JY", "Jyväskylä"));
            stations.Add(new Station("HKI", "Helsinki"));
            stations.Add(new Station("TPE", "Tampere"));
            // TODO kotitehätävät hakekaa asemapaikat APIn jsonista
            // Kiinnitettään stations kokoelma comboboxiin
            cbStations.DisplayMemberPath = "Name";
            cbStations.SelectedValuePath = "Code";
            cbStations.DataContext = stations;
        }
        private void GetTrainsAt()
        {
            try
            {
                // Haetaan asemalta lähtevät junat
                string st = cbStations.SelectedValue.ToString();
                trains = JAMK.IT.TrainsVM.GetTrainsAt(st);
                dgTrains.DataContext = trains;
                tbMessage.Text = string.Format("Löytyi {0} junaa", trains.Count);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void GetTrainsAtAsync()
        {
            // huom. eri säikeessä ajettava metodi EI VOI käsitellä käyttöliittymää (GUI:ta)
            // mutta muuttujia voi
            trains = JAMK.IT.TrainsVM.GetTrainsAt(selectedStation);
            UpdateUI();

        }
        private void UpdateUI()
        {
            Action action = () =>
            {
                dgTrains.DataContext = trains;
                tbMessage.Text = string.Format("Löytyi {0} junaa", trains.Count);
            };
            Dispatcher.BeginInvoke(action);
        }
        #endregion

        private void btnGetTrains_Click(object sender, RoutedEventArgs e)
        {
            if(cbStations.SelectedValue != null)
            {
                // versio 1: Alkuperäinen
                //tbMessage.Text = "Haetaan junat...";
                //GetTrainsAt();
                // Versio 2: asynkroninen omassa säikeessä
                selectedStation = cbStations.SelectedValue.ToString();
                new Thread(GetTrainsAtAsync).Start();
                tbMessage.Text = "haetaan junia, odota hetki...";

            }
        }
    }
}
