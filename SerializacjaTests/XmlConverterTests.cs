using System;
using System.Collections.Generic;
using System.Linq;
using serializacja;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using kolekcje;
namespace SerializacjaTests
{
    [TestClass()]
    public class XmlConverterTests
    {
        [TestMethod()]
        public void SerializujObiektTest()
        {
            new XmlConverter().Serializuj(new Gra("Pokemon", "CD Projekt", 2008, 100, 10), "gra3");

            new XmlConverter().Serializuj(new Gracz("Zdzislaw", "Krecina"), "gracz1");

            new XmlConverter().Serializuj(new Zakup(new Gracz("Janek", "Kowalski"), new Gra("Pokemon", "CD Projekt", 2008, 100, 10)), "zakup1");

            Kolekcja k = new Kolekcja();
            k.WypelnijZakupy();
            new XmlConverter().Serializuj(k._gracze, "gracze1");

            new XmlConverter().Serializuj(k._zakupy, "zakupy1");

            new XmlConverter().Serializuj(k, "kolekcja1");
        }

        [TestMethod()]
        public void DeSerializujObiektTest()
        {
            //Gra g = new XmlConverter().DeSerializuj<Gra>("gra3");
            //Console.WriteLine(g.ToString());

            //Gracz gr = new XmlConverter().DeSerializuj<Gracz>("gracz1");
            //Console.WriteLine(gr.ToString());

            //Zakup zak = new XmlConverter().DeSerializuj<Zakup>("zakup1");
            //Console.WriteLine(zak.ToString());

            List<Gracz> gracze = new XmlConverter().DeSerializuj<List<Gracz>>("gracze1");
            foreach(Gracz g in gracze)
            Console.WriteLine(g.ToString());

            //Kolekcja k = new XmlConverter().DeSerializuj<Kolekcja>("kolekcja1");
            //Console.WriteLine(k.ToString());

        }

    }
}
