using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studiepunten_Domain.Business
{
    class VakRepository
    {
        //Velden
        private List<Vak> _vakLijst = new List<Vak>();
        //eigenschappen
        public List<Vak> VakLijst
        {
            get { return _vakLijst; }
            set { _vakLijst = value; }
        }
        //constructor
        //methods
        public void addVakToRepository(Vak vak)
        {
            _vakLijst.Add(vak);
        }
    }
}
