using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studiepunten_Domain.Business
{
    class StudentStudierichting
    {
        //velden
        private int _idstudentstudierichting;
        private int _fkstudent;
        private int _fkstudierichting;
        private DateTime _startDatum;
        private DateTime _eindDatum;

        //Eigenschappen
        public int IDStudentStudierichting
        {
            get { return  _idstudentstudierichting; }
        }
        public int FKStudent
        {
            get { return _fkstudent; }
        }
        public int FKStudierichting
        {
            get { return _fkstudierichting; }
            set { _fkstudierichting = value; }
        }
        public DateTime StartDatum
        {
            get { return _startDatum; }
        }

        public DateTime EindDatum
        {
            get { return _eindDatum; }
        }


        //Constructors
        public StudentStudierichting(int idstudentstudierichting, int fkstudent, int fkstudierichting, DateTime startdatum, DateTime einddatum)
        {
            _idstudentstudierichting = idstudentstudierichting;
            _fkstudent = fkstudent;
            _fkstudierichting = fkstudierichting;
            _startDatum = startdatum;
            _eindDatum = einddatum;
        }
        public StudentStudierichting(int fkstudent, int fkstudierichting, DateTime startdatum, DateTime einddatum)
        {
            _idstudentstudierichting = 0;
            _fkstudent = fkstudent;
            _fkstudierichting = fkstudierichting;
            _startDatum = startdatum;
            _eindDatum = einddatum;
        }

        //Methods
        public override string ToString()
        {
            return _idstudentstudierichting + " - " + _fkstudent + " zit in richting: " + FKStudierichting + " begonnen op " + _startDatum + " en geëindigd op " + _eindDatum;
        }
    }
}
