using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROJECTUML;
namespace TestCombat
{
    [TestClass]
    public class TestPeopleORC
    {
        [TestMethod]
        public void TestOrc()
        {
            PeopleFactory factoryPeople = new PeopleFactoryImpl();
            People p = factoryPeople.createPeople(PeopleType.ORC);
            Assert.IsInstanceOfType(p, typeof(Orc));
        }
    }
}
