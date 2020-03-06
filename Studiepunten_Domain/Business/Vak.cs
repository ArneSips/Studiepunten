using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studiepunten_Domain.Business
{
    public class Vak
    {
        //velden
        private int _idvak;
        private string _naam;
        private int _lesuren;
        private double _punten;

        //Eigenschappen
        public int IDVak
        {
            get { return _idvak; }
        }
        public string Naam
        {
            get { return _naam; }
        }
        public int Lesuren
        {
            get { return _lesuren; }
            set { _lesuren = value; }
        }
        public double Punten
        {
            get { return _punten; }
        }


        //Constructors
        public Vak(int idvak, string naam, int lesuren, double punten)
        {
            _idvak = idvak;
            _naam = naam;
            _lesuren = lesuren;
            _punten = punten;
        }
        public Vak(string naam, int lesuren, double punten)
        {
            _idvak = 0;
            _naam = naam;
            _lesuren = lesuren;
            _punten = punten;
        }

        //Methods
        public override string ToString()
        {
            return _idvak + " - " + _naam + _lesuren + _punten;
        }
    }
}
