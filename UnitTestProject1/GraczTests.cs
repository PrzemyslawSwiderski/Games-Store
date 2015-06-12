using System;
using kolekcje;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass()]
    public class GraczTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            try
            {
                var gracz = new Gracz("Zdzislawa", "Kowalska");
                Console.WriteLine(gracz);
            }
            catch (Exception)
            {
                Assert.Fail("Wystapil nieoczekiwany wyjatek");
            }
        }
    }
}
