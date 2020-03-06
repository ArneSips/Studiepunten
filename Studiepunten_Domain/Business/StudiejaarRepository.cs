using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studiepunten_Domain.Business
{
    class StudiejaarRepository
    {
        //Velden
        private List<Studiejaar> _studiejaarLijst = new List<Studiejaar>();
        //eigenschappen
        public List<Studiejaar> StudiejaarLijst
        {
            get { return _studiejaarLijst; }
            set { _studiejaarLijst = value; }
        }
        //constructor
        //methods
        public void addStudiejaarToRepository(Studiejaar studiejaar)
        {
            _studiejaarLijst.Add(studiejaar);
        }
    }
}
