using System;
using kolekcje;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass()]
    public class RandTests
    {
        [TestMethod()]
        public void RandomStringTest()
        {
            Console.WriteLine(Rand.RandomString(8));
            Assert.IsTrue(Rand.RandomString(8).Length == 8);
        }

        [TestMethod()]
        public void RandomRokTest()
        {

            Console.WriteLine(Rand.RandomRok());
            Assert.IsTrue(Rand.RandomRok() > 1990 && Rand.RandomRok() < 2016);
        }

        [TestMethod()]
        public void RandomCenaTest()
        {

            Console.WriteLine(Rand.RandomCena());

            Assert.IsTrue(Rand.RandomCena() > 30 && Rand.RandomCena() < 200);
        }

        [TestMethod()]
        public void RandomSztukiTest()
        {

            Console.WriteLine(Rand.RandomSztuki());

            Assert.IsTrue(Rand.RandomSztuki() > 3 && Rand.RandomSztuki() < 20);
        }

    }
}
