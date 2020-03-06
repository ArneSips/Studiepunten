using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studiepunten_Domain.Business
{
    class VakStudentRepository
    {
        //Velden
        private List<VakStudent> _vakStudentLijst = new List<VakStudent>();
        //eigenschappen
        public List<VakStudent> VakStudentLijst
        {
            get { return _vakStudentLijst; }
            set { _vakStudentLijst = value; }
        }
        //constructor
        //methods
        public void addVakStudentToRepository(VakStudent vakstudent)
        {
            _vakStudentLijst.Add(vakstudent);
        }
    }
}
