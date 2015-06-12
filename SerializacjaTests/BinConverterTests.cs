using serializacja;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using kolekcje;
using System;
using System.Collections.Generic;
namespace SerializacjaTests
{
    [TestClass()]
    public class BinConverterTests
    {
        [TestMethod()]
        public void SerializujTest()
        {
            new BinConverter().Serializuj(new Gra("Pokemon3", "CD Projekt", 2008, 100, 10), "gra3");

            new BinConverter().Serializuj(new Gracz("Janek", "Krecina"), "gracz1");

            new BinConverter().Serializuj(new Zakup(new Gracz("Janek", "Kowalski"), new Gra("Pokemon", "CD Projekt", 2008, 100, 10)), "zakup1");

            Kolekcja k = new Kolekcja();
            k.WypelnijZakupy();
            new BinConverter().Serializuj(k._gracze, "gracze1");

            new BinConverter().Serializuj(k._zakupy, "zakupy1");

            new BinConverter().Serializuj(k, "kolekcja1");
        }

        [TestMethod()]
        public void DeSerializujTest()
        {
            Gra g = new BinConverter().DeSerializuj<Gra>("gra3");
            Console.WriteLine(g.ToString());

            Gracz gr = new BinConverter().DeSerializuj<Gracz>("gracz1");
            Console.WriteLine(gr.ToString());

            Zakup zak = new BinConverter().DeSerializuj<Zakup>("zakup1");
            Console.WriteLine(zak.ToString());

            Kolekcja k = new BinConverter().DeSerializuj<Kolekcja>("kolekcja1");
            Console.WriteLine(k.ToString());

            var gracze = new BinConverter().DeSerializuj<List<Gracz>>("gracze1");

            Console.WriteLine("Lista graczy:");
            foreach (var gracz in gracze)
            {
                Console.WriteLine(gracz.ToString());
            }
            
        }
    }
}
