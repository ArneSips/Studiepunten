using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studiepunten_Domain.Business
{
    public class VakStudiejaar
    {
        
        //velden
        private int _idvak;
        private int _idstudiejaar;

        //Eigenschappen
        public int IDVak
        {
            get { return _idvak; }
        }
        public int IDStudiejaar
        {
            get { return _idstudiejaar; }
        }

        //Constructors
        public VakStudiejaar(int idvak, int idstudiejaar)
        {
            _idvak = idvak;
            _idstudiejaar = idstudiejaar;
        }
    }
}
