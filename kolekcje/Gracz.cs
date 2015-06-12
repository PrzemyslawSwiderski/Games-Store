using System;

namespace kolekcje
{
    [Serializable()]
    public class Gracz
    {
        public static UInt32 Liczba;
        public string _imie;
        public string _nazwisko;

        public Gracz()
        {
            _imie = "nieznany";
            _nazwisko = "nieznany";
            Liczba++;
        }
        public Gracz(string imie, string nazwisko)
        {
            _imie = imie;
            _nazwisko = nazwisko;
            Liczba++;
        }
        public override string ToString()
        {
            return _imie + " " + _nazwisko + "\n";
        }
        public string Imie { get { return _imie; } set { _imie = value; } }
        public string Nazwisko { get { return _nazwisko; } set { _nazwisko = value; } }
    }
}
