using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROJECTUML;
namespace TestCombat
{
    [TestClass]
    public class TestPeople
    {
        [TestMethod]
        public void TestCreationPeopleElf()
        {
            People p;
            PeopleFactory fact = new PeopleFactoryImpl();
            p=fact.createPeople(0);
            Assert.IsInstanceOfType(p,typeof(Elf));
        }

    }
}
