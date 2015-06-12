using System;
using kolekcje;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass()]
    public class ZakupTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            try
            {
                var zakup = new Zakup(new Gracz("Zdzislaw", "Kowalski"), new Gra("FIFA 08", "EA", 2008, 100, 10));
                Console.WriteLine(zakup);
            }
            catch (Exception)
            {
                Assert.Fail("Wystapil nieoczekiwany wyjatek");
            }
        }
    }
}
