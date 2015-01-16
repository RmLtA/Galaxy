using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROJECTUML;
namespace TestCombat
{
    [TestClass]
    public class TestPeopleELF
    {
        [TestMethod]
        public void TestElf()
        {
            PeopleFactory factoryPeople = new PeopleFactoryImpl();
            People p=factoryPeople.createPeople(PeopleType.ELF);
            Assert.IsInstanceOfType(p,typeof(Elf));
        }

        [TestMethod]
        public void TestUnitPeople()
        {
            PeopleFactory factoryPeople = new PeopleFactoryImpl();
            People p = factoryPeople.createPeople(PeopleType.ELF);
            //Unit u = p.createUnit();
            //Assert.IsInstanceOfType(u, typeof(ElfUnit));
            //p.addUnit(5);
            //Assert.AreEqual(p.ListUnit.Capacity, 2);
        }
       



    }
}
