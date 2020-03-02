using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studiepunten_Domain.Business
{
    class Studiejaar
    {
        //velden
        private int _idstudiejaar;
        private string _naam;
        private int _fkStudierichting;

        //Eigenschappen
        public int IDStudiejaar
        {
            get { return _idstudiejaar; }
        }
        public string Naam
        {
            get { return _naam; }
        }
        public int FKStudierichting
        {
            get { return _fkStudierichting; }
        }
      


        //Constructors
        public Studiejaar(int idstudiejaar, string naam, int fkstudierichting)
        {
            _idstudiejaar = idstudiejaar;
            _naam = naam;
            _fkStudierichting = fkstudierichting;

        }
        public Studiejaar(string naam, int fkstudierichting)
        {
            _idstudiejaar = 0;
            _naam = naam;
            _fkStudierichting = fkstudierichting;
        }

        //Methods
        public override string ToString()
        {
            return _idstudiejaar + " - " + _naam + _fkStudierichting;
        }
    }
}
