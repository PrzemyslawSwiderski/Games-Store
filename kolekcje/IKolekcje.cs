using System;
using System.Collections.Specialized;

namespace kolekcje
{
    public interface IKolekcje
    {
        int OstatnioDodanyZakup { get; set; }
        int OstatnioUsunietyZakup { get; set; }

        void DodajGracza(Gracz gracz);

        void DodajGre(Gra gra);

        void DodajZakup(Zakup zakup);

        void UsunGracza(int ktory);

        void UsunGre(String tytul);

        void UsunZakup(int ktory);

        Gracz PobierzGracza(int ktory);

        Gra PobierzGre(string tytul);

        Zakup PobierzZakup(int ktory);

        string GraczeToString();

        string GryToString();

        string ZakupyToString();

        void WypelnijZakupy();

        void WypelnijZakupy(int ile);

        void WypelnijGraczy();

        void WypelnijGraczy(int ile);

        void WypelnijGry();

        void WypelnijGry(int ile);

        void OstatniZakup(object sender, NotifyCollectionChangedEventArgs e);
    }
}
