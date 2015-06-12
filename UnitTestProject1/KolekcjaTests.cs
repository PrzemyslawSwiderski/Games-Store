using System;
using System.Collections.Generic;
using System.Diagnostics;
using kolekcje;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass()]
    public class KolekcjaTests
    {

        [TestMethod()]
        public void GraczeToStringTest()
        {

                Kolekcja k = new Kolekcja();
                k.DodajGracza(new Gracz());
                k.DodajGracza(new Gracz("Piotr", "Jozwiak"));
                k.DodajGracza(new Gracz("Stefan", "Rahim"));
                k.DodajGracza(new Gracz("Julita", "Korwin"));
                Console.WriteLine(k.GraczeToString());
                Assert.IsTrue(true, "Nie wystapil wyjatek.");

        }      

        [TestMethod()]
        public void GryToStringTest()
        {

                Kolekcja k = new Kolekcja();
                k.DodajGre(new Gra());
                k.DodajGre(new Gra("Wiedzmin", "CD Projekt", 2008, 100, 10));
                k.DodajGre(new Gra("Wiedzmin2", "CD Projekt2", 2001, 102, 3));
                k.DodajGre(new Gra("Pokemon red", "KOnami", 2041, 200, 1));
                Console.WriteLine(k.GryToString());
                Assert.IsTrue(true, "Nie wystapil wyjatek.");

        }

        [TestMethod()]
        public void ZakupyToStringTest()
        {

            Kolekcja k = new Kolekcja();

            k.DodajGracza(new Gracz());
            k.DodajGracza(new Gracz("Piotr", "Jozwiak"));
            k.DodajGracza(new Gracz("Stefan", "Rahim"));
            k.DodajGracza(new Gracz("Julita", "Korwin"));

            k.DodajGre(new Gra());
            k.DodajGre(new Gra("Wiedzmin", "CD Projekt", 2008, 100, 12));
            k.DodajGre(new Gra("Wiedzmin2", "CD Projekt2", 2001, 102, 6));
            k.DodajGre(new Gra("Pokemon red", "KOnami", 2041, 200, 9));

            try
            {
                k.DodajZakup(new Zakup(k.PobierzGracza(2), k.PobierzGre("Wiedzmin5")));
                Assert.Fail(" Nie wystapil oczekiwany wyjatek.");
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Klucz nie istnieje.");
                Assert.IsTrue(true, "Wystapil oczekiwany wyjatek.");
            }
            k.DodajZakup(new Zakup(k.PobierzGracza(2), k.PobierzGre("Wiedzmin2")));
            k.DodajZakup(new Zakup(k.PobierzGracza(2), k.PobierzGre("Wiedzmin")));
            k.DodajZakup(new Zakup(k.PobierzGracza(3), k.PobierzGre("Wiedzmin")));
            Console.WriteLine(k.ZakupyToString());

            Assert.IsTrue(k.OstatnioDodanyZakup == 2);
        }

        [TestMethod()]
        public void PobierzGraczaTest()
        {
            try
            {
                Kolekcja k = new Kolekcja();
                k.DodajGracza(new Gracz("Andrzej", "Andrzej"));
                k.PobierzGracza(5);
                Assert.Fail(" Nie wystapil oczekiwany wyjatek.");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Zly index.");
                Assert.IsTrue(true, "Wystapil oczekiwany wyjatek.");
            }

        }

        [TestMethod()]
        public void PobierzGreTest()
        {
            //          k.DodajGre(new Gra("jakas","jakis",202,20,12));
            try
            {
                var k = new Kolekcja();
                k.PobierzGre("jakas");
                Assert.Fail(" Nie wystapil oczekiwany wyjatek.");
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Klucz nie istnieje.");
                Assert.IsTrue(true, "Wystapil oczekiwany wyjatek.");
            }

        }

        [TestMethod()]
        public void PobierzZakupTest()
        {
            try
            {
                var k = new Kolekcja();
                k.PobierzZakup(5);
                Assert.Fail(" Nie wystapil oczekiwany wyjatek.");
            }
            catch (Exception)
            {
                Console.WriteLine("Zly index.");
                Assert.IsTrue(true, "Wystapil oczekiwany wyjatek.");
            }
        }

        [TestMethod()]
        public void WypelnijTest()
        {
            Stopwatch sw = new Stopwatch();
            var k = new Kolekcja();
            sw.Start();
            k.WypelnijGry();
            sw.Stop();
            //Console.WriteLine(k.GraczeToString().Split('\n').Length);
            Console.WriteLine("Czas wypelniania w sekundach: " + sw.Elapsed.TotalSeconds);

            Assert.IsTrue(true, "Nie wystapil wyjatek.");
        }

        [TestMethod()]
        public void WypelnijTest1()
        {
            Stopwatch sw = new Stopwatch();
            var k = new Kolekcja();
            sw.Start();
            k.WypelnijGry(10000);
            sw.Stop();
            //Console.WriteLine(k.GraczeToString().Split('\n').Length);
            Console.WriteLine("Czas wypelniania w sekundach: " + sw.Elapsed.TotalSeconds);

            Assert.IsTrue(true, "Nie wystapil wyjatek.");
        }

        [TestMethod()]
        public void WypelnijTest2()
        {

                Stopwatch sw = new Stopwatch();
                var k = new Kolekcja();
                sw.Start();
                k.WypelnijGry(100000);
                sw.Stop();
                //Console.WriteLine(k.GraczeToString().Split('\n').Length);
                Console.WriteLine("Czas wypelniania w sekundach: " + sw.Elapsed.TotalSeconds);

                Assert.IsTrue(true, "Nie wystapil wyjatek.");

        }

        [TestMethod()]
        public void WypelnijTestGraczy()
        {       
            Stopwatch sw = new Stopwatch();
            var k = new Kolekcja();
            sw.Start();
            k.WypelnijGraczy(200000);
            sw.Stop();
            //Console.WriteLine(k.GraczeToString().Split('\n').Length);
            Console.WriteLine("Czas wypelniania w sekundach: " + sw.Elapsed.TotalSeconds);

            Assert.IsTrue(true, "Nie wystapil wyjatek.");
        }

        [TestMethod()]
        public void WypelnijTestZakupy()
        {
            Stopwatch sw = new Stopwatch();
            var k = new Kolekcja();
            sw.Start();
            k.WypelnijZakupy(15000);
            sw.Stop();
            //Console.WriteLine(k.GraczeToString().Split('\n').Length);
            Console.WriteLine("Czas wypelniania w sekundach: " + sw.Elapsed.TotalSeconds);
            Assert.IsTrue(k.OstatnioDodanyZakup == 14999);
        }

        [TestMethod()]
        public void DodajZakupTest()
        {

            var k = new Kolekcja();
            var gra = new Gra("Fallout", "Bethesda", 1999, 200, 20);
            k.DodajZakup(new Zakup(new Gracz("Stefan", "Mucha"), gra));
            Assert.IsTrue(k.PobierzZakup(0).PobierzGre() == gra);
        }

        [TestMethod()]
        public void DodajGraczaTest()
        {

            var k = new Kolekcja();
            var gracz = new Gracz("Adam", "Świderski");
            k.DodajGracza(gracz);
            Assert.IsTrue(k.PobierzGracza(0) == gracz);
        }

        [TestMethod()]
        public void DodajGreTest()
        {

            var k = new Kolekcja();
            var gra = new Gra("Fallout", "Bethesda", 1999, 200, 20);
            k.DodajGre(gra);
            Assert.IsTrue(k.PobierzGre("Fallout") == gra);
        }
       
        [TestMethod()]
        public void UsunZakupTest()
        {
                var k = new Kolekcja();
                var gra = new Gra("Fallout", "Bethesda", 1999, 200, 20);
                k.DodajZakup(new Zakup(new Gracz("Stefan", "Mucha"), gra));
                k.UsunZakup(k.OstatnioDodanyZakup);

                Assert.IsTrue(true, "Nie wystapil wyjatek.");

        }

        [TestMethod()]
        public void UsunGraczaTest()
        {            
            var k = new Kolekcja();
            var gracz = new Gracz("Adam", "Świderski");
            k.DodajGracza(gracz);
            k.UsunGracza(0);
            Assert.IsTrue(true, "Nie wystapil wyjatek.");           
        }

        [TestMethod()]
        public void UsunGreTest()
        {
            var k = new Kolekcja();
            var gra = new Gra("Fallout", "Bethesda", 1999, 200, 20);
            k.DodajGre(gra);
            k.UsunGre("Fallout");
            Assert.IsTrue(true, "Nie wystapil wyjatek.");
        }

    }
}
