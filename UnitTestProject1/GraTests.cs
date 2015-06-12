using System;
using kolekcje;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass()]
    public class GraTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            try
            {
                var gra = new Gra("FIFA 14", "EA", 2014, 150, 12);
                Console.WriteLine(gra);
            }
            catch (Exception)
            {
                Assert.Fail("Wystapil nieoczekiwany wyjatek");
            }
        }
    }
}
