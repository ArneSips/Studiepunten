using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studiepunten_Domain.Business
{
    class VakStudiejaarRepository
    {
        //Velden
        private List<VakStudiejaar> _vakStudiejaarLijst = new List<VakStudiejaar>();
        //eigenschappen
        public List<VakStudiejaar> VakStudiejaarLijst
        {
            get { return _vakStudiejaarLijst; }
            set { _vakStudiejaarLijst = value; }
        }
        //constructor
        //methods
        public void addVakStudiejaarToRepository(VakStudiejaar vakstudiejaar)
        {
            _vakStudiejaarLijst.Add(vakstudiejaar);
        }
    }
}
