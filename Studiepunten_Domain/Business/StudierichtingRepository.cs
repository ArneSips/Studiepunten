using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studiepunten_Domain.Business
{
    class StudierichtingRepository
    {
        //Velden
        private List<Studierichting> _studierichtingLijst = new List<Studierichting>();
        //eigenschappen
        public List<Studierichting> StudierichtingLijst
        {
            get { return _studierichtingLijst; }
            set { _studierichtingLijst = value; }
        }
        //constructor
        //methods
        public void addStudierichtingToRepository(Studierichting studierichting)
        {
            _studierichtingLijst.Add(studierichting);
        }
    }
}
