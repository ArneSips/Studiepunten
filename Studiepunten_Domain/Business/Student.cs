using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studiepunten_Domain.Business
{
    class Student
    {
        //velden
        private int _idgebruiker;
        private string _naam;
        private string _wachtwoord;
        private double _punten;

        //Eigenschappen
        public int IDGebruiker
        {
            get { return _idgebruiker; }
        }
        public string Naam
        {
            get { return _naam; }
        }
        public string Wachtwoord
        {
            get { return _wachtwoord; }
            set { _wachtwoord = value; }
        }
        public double Punten
        {
            get { return _punten; }
        }


        //Constructors
        public Student(int idgebruiker, string naam, string wachtwoord, double punten)
        {
            _idgebruiker = idgebruiker;
            _naam = naam;
            _wachtwoord = wachtwoord;
            _punten = punten;
        }
        public Student(string naam, string wachtwoord, double punten)
        {
            _idgebruiker = 0;
            _naam = naam;
            _wachtwoord = wachtwoord;
            _punten = punten;
        }

        //Methods
        public override string ToString()
        {
            return _idgebruiker + " - " + _naam + _punten;
        }
    }
}
