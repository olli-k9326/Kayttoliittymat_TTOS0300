using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMDemo.Model;
using System.Collections.ObjectModel;

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
    }
}
