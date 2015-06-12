using System;
using System.Collections.Generic;
using System.Linq;
using serializacja;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using kolekcje;
namespace SerializacjaTests
{
    [TestClass()]
    public class JsonConverterTests
    {
        [TestMethod()]
        public void SerializujTest()
        {
            new JsonConverter().Serializuj(new Gra("Fallout", "CD Projekt", 2008, 100, 10), "gra3");

            new JsonConverter().Serializuj(new Gracz("Dariusz", "Krecina"), "gracz1");

            new JsonConverter().Serializuj(new Zakup(new Gracz("Janusz", "Kowalski"), new Gra("Pokemon", "CD Projekt", 2008, 100, 10)), "zakup1");

            Kolekcja k = new Kolekcja();
            k.WypelnijZakupy();
            new JsonConverter().Serializuj(k._gracze, "gracze1");

            new JsonConverter().Serializuj(k._zakupy, "zakupy1");

            new JsonConverter().Serializuj(k, "kolekcja1");
        }

        [TestMethod()]
        public void DeSerializujTest()
        {
            Gra g = new JsonConverter().DeSerializuj<Gra>("gra3");
            Console.WriteLine(g.ToString());

            Gracz gr = new JsonConverter().DeSerializuj<Gracz>("gracz1");
            Console.WriteLine(gr.ToString());

            Zakup zak = new JsonConverter().DeSerializuj<Zakup>("zakup1");
            Console.WriteLine(zak.ToString());

            var gracze = new JsonConverter().DeSerializuj<List<Gracz>>("gracze1");

            Console.WriteLine("Lista graczy:");
            foreach(var gracz in gracze)
            {
            Console.WriteLine(gracz.ToString());
            }

            Kolekcja k = new JsonConverter().DeSerializuj<Kolekcja>("kolekcja1");
            Console.WriteLine(k.ToString());
        }
    }
}
