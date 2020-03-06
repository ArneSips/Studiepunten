using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studiepunten_Domain.Business
{
    class StudentRepository
    {
        //Velden
        private List<Student> _studentLijst = new List<Student>();
        //eigenschappen
        public List<Student> StudentLijst
        {
            get { return _studentLijst; }
            set { _studentLijst = value; }
        }
        //constructor
        //methods
        public void addStudentToRepository(Student student)
        {
            _studentLijst.Add(student);
        }

        public Student getStudentLogIn(string naam, string wachtwoord)
        {
            foreach(Student student in _studentLijst)
            {
                if (student.Naam == naam && student.Wachtwoord == wachtwoord)
                { return student; }
            }
            return null;
        }
    }
}
