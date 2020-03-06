using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studiepunten_Domain.Business
{
    public class VakStudent
    {

        //velden
        private int _idvak;
        private int _idgebruiker;

        //Eigenschappen
        public int IDVak
        {
            get { return _idvak; }
        }
        public int IDGebruiker
        {
            get { return _idgebruiker; }
        }

        //Constructors
        public VakStudent(int idvak, int idgebruiker)
        {
            _idvak = idvak;
            _idgebruiker = idvak;
        }
    }
}
