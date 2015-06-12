using System;
namespace kolekcje
{
    [Serializable()]
    public class Gra
    {
        public string _tytul;
        public string _wydawca;
        public int _rokWydania;
        public int _cena;
        public int _liczbaSztuk;

        public Gra()
        {
            _tytul = "nieznany";
            _wydawca = "nieznany";
            _rokWydania = 0;
            _cena = 0;
            _liczbaSztuk = 1;
        }

        public Gra(string tytul, string wydawca, int rokWydania, int cena, int sztuki)
        {
            _tytul = tytul;
            _wydawca = wydawca;
            _rokWydania = rokWydania;
            _cena = cena;
            _liczbaSztuk = sztuki;
        }
        public override string ToString()
        {
            return string.Format("Tytul: {0} Wydawca: {1} Rok Wydania: {2} Cena: {3}\nLiczba pozostalych sztuk: {4}\n", _tytul, _wydawca, _rokWydania, _cena, _liczbaSztuk);
        }

        public void Kup()
        {
            _liczbaSztuk--;
            if (_liczbaSztuk < 0)
            {
                throw new ZaMaloSztukException();
            }
        }
        public string PobierzTytul()
        {
            return _tytul;
        }
        public int PobierzSztuki()
        {
            return _liczbaSztuk;
        }
        public string Tytul { get { return _tytul; } set { _tytul = value; } }
        public string Wydawca { get { return _wydawca; } set { _wydawca = value; } }
        public int RokWydania { get { return _rokWydania; } set { _rokWydania = value; } }
        public int Cena { get { return _cena; } set { _cena = value; } }
        public int LiczbaSztuk { get { return _liczbaSztuk; } set { _liczbaSztuk = value; } }
    }
}
