using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace kolekcje
{
    [Serializable()]
    public class Kolekcja : IKolekcje
    {
        public List<Gracz> _gracze;
        public ObservableCollection<Zakup> _zakupy;
        public Dictionary<string, Gra> _gry;
        public List<Gra> _grylist;

        public Kolekcja()
        {
            _gracze = new List<Gracz>();
            _gry = new Dictionary<string, Gra>(StringComparer.OrdinalIgnoreCase);
            _grylist = new List<Gra>();
            _zakupy = new ObservableCollection<Zakup>();
        }

        public Kolekcja(List<Gracz> gracze,List<Gra> gry,List<Zakup> zakupy)
        {
            _gracze = gracze;
            _grylist = gry;
            _gry = new Dictionary<string, Gra>(StringComparer.OrdinalIgnoreCase);
            foreach (var g in gry)
            {
                _gry.Add(g.PobierzTytul(), g);
            }
            _zakupy = new ObservableCollection<Zakup>();
            foreach (var zakup in zakupy)
            {
                _zakupy.Add(zakup);
            }
        }
        public int OstatnioDodanyZakup { get; set; }

        public int OstatnioUsunietyZakup { get; set; }

        public void DodajGracza(Gracz gracz)
        {
            _gracze.Add(gracz);
        }
        public void DodajGre(Gra gra)
        {
            try
            {
                _gry.Add(gra.PobierzTytul(), gra);
                _grylist.Add(gra);
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public void DodajZakup(Zakup zakup)
        {
            try
            {
                _zakupy.Add(zakup);
                _zakupy.CollectionChanged += OstatniZakup;
                if (zakup.PobierzGre().PobierzSztuki() <= 0)
                    UsunGre(zakup.PobierzGre().PobierzTytul());
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public void UsunGracza(int ktory)
        {
            try
            {
                _gracze.RemoveAt(ktory);
            }
            catch (ArgumentOutOfRangeException)
            { }
        }

        public void UsunGre(String tytul)
        {
            _gry.Remove(tytul);
        }


        public void UsunZakup(int ktory)
        {
            _zakupy.RemoveAt(ktory);
            _zakupy.CollectionChanged += OstatniZakup;
        }

        public Gracz PobierzGracza(int ktory)
        {
            return _gracze[ktory];
        }
        public Gra PobierzGre(string tytul)
        {
            return _gry[tytul];
        }

        public Zakup PobierzZakup(int ktory)
        {
            return _zakupy[ktory];
        }


        public string GraczeToString()
        {
            var str = "";
            var i = 1;
            foreach (var gracz in _gracze)
            {
                str = str + "Gracz numer " + i++ + " : " + gracz + "\n";
            }
            return str;
        }
        public string GryToString()
        {
            var str = "";
            foreach (var gra in _grylist)
            {
                str = str + "Klucz: " + gra._tytul + "\n" + gra + "\n";
            }
            return str;
        }
        public string ZakupyToString()
        {
            var str = "";
            var i = 1;
            foreach (var zakup in _zakupy)
            {
                str = str + "Zakup numer " + i++ + ".\n" + zakup + "\n";
            }
            return str;
        }

        public void WypelnijZakupy()
        {
            DodajGracza(new Gracz("Piotr", "Jozwiak"));
            DodajGracza(new Gracz("Stefan", "Rahim"));
            DodajGracza(new Gracz("Julita", "Korwin"));
            DodajGracza(new Gracz("Maciej", "Stepien"));
            DodajGracza(new Gracz("Jan", "Nowicki"));
            DodajGre(new Gra("Wiedzmin", "CD Projekt", 2008, 100, 12));
            DodajGre(new Gra("Wiedzmin2", "CD Projekt2", 2001, 102, 6));
            DodajGre(new Gra("Pokemon red", "KOnami", 2041, 200, 9));
            DodajZakup(new Zakup(PobierzGracza(2), PobierzGre("Wiedzmin2")));
            DodajZakup(new Zakup(PobierzGracza(2), PobierzGre("Wiedzmin")));
            DodajZakup(new Zakup(PobierzGracza(3), PobierzGre("Wiedzmin")));
            DodajZakup(new Zakup(PobierzGracza(1), PobierzGre("Pokemon red")));
        }

        public void WypelnijZakupy(int ile)
        {
            for (var i = 0; i < ile; i++)
            {
                try
                {
                    Gracz gracz;
                    DodajGracza(gracz = new Gracz(Rand.RandomString(8), Rand.RandomString(8)));
                    Gra gra;
                    DodajGre(gra = new Gra(Rand.RandomString(9), Rand.RandomString(9), Rand.RandomRok(), Rand.RandomCena(), Rand.RandomSztuki()));
                    DodajZakup(new Zakup(gracz, gra));
                }
                catch (ArgumentException)
                {

                }

            }
        }

        public void WypelnijGraczy()
        {
            DodajGracza(new Gracz("Adam", "Wojtkowiak"));
            DodajGracza(new Gracz("Grzegorz", "Rasiak"));
            DodajGracza(new Gracz("Robert", "Lewandowski"));
            DodajGracza(new Gracz("Fryderyk", "Szopen"));
            DodajGracza(new Gracz("Stefan", "Kowalski"));
            DodajGracza(new Gracz("Marta", "Kalisz"));
            DodajGracza(new Gracz("Tytus", "Nowak"));
        }

        public void WypelnijGraczy(int ile)
        {
            for (var i = 0; i < ile; i++)
            {
                DodajGracza(new Gracz(Rand.RandomString(8), Rand.RandomString(8)));
            }
        }

        public void WypelnijGry()
        {
            DodajGre(new Gra("Heroes 3", "The 3DO Company", 1999, 50, 12));
            DodajGre(new Gra("FIFA 15", "EA Sports", 2014, 150, 3));
            DodajGre(new Gra("Freeleancer", "Microsoft", 2003, 70, 7));
            DodajGre(new Gra("Eve online", "CCP Games", 2003, 200, 20));
            DodajGre(new Gra("Pillars of Eternity", "Obsidian Entertainment", 2015, 80, 8));
            DodajGre(new Gra("Pokemon Red", "Nintendo", 1996, 110, 11));
            DodajGre(new Gra("Fallout 2", "Bethesda", 1998, 50, 5));
        }

        public void WypelnijGry(int ile)
        {
            for (var i = 0; i < ile; i++)
            {
                DodajGre(new Gra(Rand.RandomString(9), Rand.RandomString(9), Rand.RandomRok(), Rand.RandomCena(), Rand.RandomSztuki()));
            }
        }

        public void OstatniZakup(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
                OstatnioDodanyZakup = e.NewStartingIndex;
            if (e.Action == NotifyCollectionChangedAction.Remove)
                OstatnioUsunietyZakup = e.OldStartingIndex;
        }

        public override string ToString()
        {
            return "\nGracze:\n " + GraczeToString() + "\nZakupy:\n" + ZakupyToString() + "\nGry:\n" + GryToString();
        }

    }
}
