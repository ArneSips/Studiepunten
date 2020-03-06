using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studiepunten_Domain.Business
{
    public class Studierichting
    {
        //velden
        private int _idstudierichting;
        private string _naam;
        private int _jaren;

        //Eigenschappen
        public int IDStudierichting
        {
            get { return _idstudierichting; }
        }
        public string Naam
        {
            get { return _naam; }
        }
        public int Jaren
        {
            get { return _jaren; }
        }


        //Constructors
        public Studierichting(int idstudierichting, string naam, string wachtwoord, int jaren)
        {
            _idstudierichting = idstudierichting;
            _naam = naam;
            _jaren = jaren;

        }
        public Studierichting(string naam, string wachtwoord, int jaren)
        {
            _idstudierichting = 0;
            _naam = naam;
            _jaren = jaren;
        }

        //Methods
        public override string ToString()
        {
            return _idstudierichting + " - " + _naam + _jaren;
        }
    }
}
