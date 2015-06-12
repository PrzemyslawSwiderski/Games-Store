using System;
using System.Collections.Generic;
using System.Linq;
using serializacja;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using kolekcje;
namespace SerializacjaTests
{
    [TestClass()]
    public class TxtConverterTests
    {
        [TestMethod()]
        public void SerializujTest()
        {
            new TxtConverter().Serializuj(new Gra("Fallout", "CD Projekt", 2008, 100, 10), "gra3");

            new TxtConverter().Serializuj(new Gracz("Dariusz", "Krecina"), "gracz1");

            new TxtConverter().Serializuj(new Zakup(new Gracz("Janusz", "Kowalski"), new Gra("Pokemon", "CD Projekt", 2008, 100, 10)), "zakup1");

        }
        [TestMethod()]
        public void SerializujListeTest()
        {
            Kolekcja k = new Kolekcja();
            k.WypelnijZakupy();

            new TxtConverter().Serializuj(k._gracze, "gracze");

            new TxtConverter().Serializuj(k._grylist, "gry");

            new TxtConverter().Serializuj(k._zakupy.ToList(), "zakupy");
        }
        [TestMethod()]
        public void DeSerializujTest()
        {
            Gra g = new TxtConverter().DeSerializuj<Gra>("gra3");
            Console.WriteLine(g.ToString());

            Gracz gr = new TxtConverter().DeSerializuj<Gracz>("gracz1");
            Console.WriteLine(gr.ToString());

            Zakup z = new TxtConverter().DeSerializuj<Zakup>("zakup1");
            Console.WriteLine(z.ToString());
        }
        [TestMethod()]
        public void DeSerializujListeTest()
        {
            var gracze = new TxtConverter().DeSerializuj<List<Gracz>>("gracze");

            Console.WriteLine("Lista graczy:");
            foreach (var gracz in gracze)
            {
                Console.WriteLine(gracz.ToString());
            }

            var zakupy = new TxtConverter().DeSerializuj<List<Zakup>>("zakupy");

            Console.WriteLine("Lista zakupow:");
            foreach (var zak in zakupy)
            {
                Console.WriteLine(zak.ToString());
            }
        }
        [TestMethod()]
        public void SerializujKolekcjeTest()
        {
            Kolekcja k = new Kolekcja();
            k.WypelnijZakupy();

            new TxtConverter().Serializuj(k, "kolekcja");
        }
        [TestMethod()]
        public void DeSerializujKolekcjeTest()
        {
            Kolekcja kol = new TxtConverter().DeSerializuj<Kolekcja>("kolekcja");
            Console.WriteLine(kol.ToString());
        }
    }
}
