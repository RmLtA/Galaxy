using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROJECTUML;
namespace TestCombat
{
    [TestClass]
    public class TestPeopleNain
    {
        [TestMethod]
        public void TestNAin()
        {
            PeopleFactory factoryPeople = new PeopleFactoryImpl();
            People p = factoryPeople.createPeople(PeopleType.NAIN);
            Assert.IsInstanceOfType(p, typeof(Nain));
        }
    }
}
