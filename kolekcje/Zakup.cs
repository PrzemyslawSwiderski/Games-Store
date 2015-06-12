using System;

namespace kolekcje
{
    [Serializable()]
    public class Zakup
    {
        public Gracz _gracz;
        public Gra _gra;
        public DateTime _czasZakupu;

        public Zakup()
        {
            _czasZakupu = DateTime.Now;
        }
        

        public Zakup(Gracz gracz, Gra gra)
        {
            gra.Kup();
            _gracz = gracz;
            _gra = gra;
            _czasZakupu = DateTime.Now;
        }
        public override string ToString()
        {
            return "Gracz: " + _gracz + "Kupil -> " + _gra + "Czas zakupu: " + _czasZakupu + "\n";
        }

        public Gra PobierzGre()
        {
            return _gra;
        }

        public string Gracz { get { return _gracz._nazwisko; } set { _gracz._nazwisko = value; } }
        public string Gra { get { return _gra._tytul; } set { _gra._tytul = value; } }
        public DateTime CzasZakupu { get { return _czasZakupu; } set { _czasZakupu = value; } }
    }
}
