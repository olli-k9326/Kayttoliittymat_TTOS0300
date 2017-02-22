using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMDemo.Model;
using System.Collections.ObjectModel;
using MySql.Data.MySqlClient;

namespace MVVMDemo.ViewModel
{
    public class StudentViewModel
    {
        public ObservableCollection<Student> Students
        {
            get;
            set;
        }
        public void LoadStudents()
        {
            ObservableCollection<Student> students = new ObservableCollection<Student>();
            // lisätään esimerkin vuoksi muutama opiskelija, oikeasta sovelluksessa haettaisiin esim. tietokannasta.
            students.Add(new Student { FirstName = "Kalle", LastName = "Jalkanen", Asioid="O3894" });
            students.Add(new Student { FirstName = "Teppo", LastName = "Testaaja", Asioid = "K4354" });
            students.Add(new Student { FirstName = "Tomi", LastName = "Tötterström", Asioid = "L8433" });
            Students = students;
        }
        //metodi StudentViewModeliin jolla haetaan oppilastiedot mysql-palvemilta
        public void LoadStudentsFromMysql()
        {
            try
            {
                ObservableCollection<Student> students = new ObservableCollection<Student>();
                //luodaan yhteys labranetin mysql-palvelimelle
                string connStr = GetMysqlConnectionString();
                string sql = "SELECT firstname, lastname, asioid FROM student";
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MVVMDemo.Model.Student s = new Model.Student();
                            s.FirstName = reader.GetString(0);
                            s.LastName = reader.GetString(1);
                            s.Asioid = reader.GetString(2);
                            students.Add(s);
                        }
                        Students = students;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        private string GetMysqlConnectionString()
        {
            string pw = "";  //"h8sS7j6Ydtv5unJ97tH0lUECOXeMTW1s"
            /// haetaan salasana App.Config- kongfiguraatiotiedostosta
            pw = MVVMDemo.Properties.Settings.Default.passu;
            return string.Format("Data source=mysql.labranet.jamk.fi;Initial Catalog=K9326_3;user=K9326;password={0}", pw);
        }
    }
}
