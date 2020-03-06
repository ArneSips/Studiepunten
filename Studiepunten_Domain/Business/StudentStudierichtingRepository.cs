using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studiepunten_Domain.Business
{
    class StudentStudierichtingRepository
    {
        //Velden
        private List<StudentStudierichting> _studentStudierichtingLijst = new List<StudentStudierichting>();
        //eigenschappen
        public List<StudentStudierichting> StudentStudierichtingLijst
        {
            get { return _studentStudierichtingLijst; }
            set { _studentStudierichtingLijst = value; }
        }
        //constructor
        //methods
        public void addStudentStudierichtingToRepository(StudentStudierichting studentStudierichting)
        {
            _studentStudierichtingLijst.Add(studentStudierichting);
        }
    }
}
