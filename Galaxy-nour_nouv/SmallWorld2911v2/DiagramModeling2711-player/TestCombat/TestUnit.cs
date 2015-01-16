using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROJECTUML;
namespace TestCombat
{
    [TestClass]
    public class TestUnit
    {
        [TestMethod]
        public void TestUnitElf()
        {
            Unit elf = new ElfUnitImpl();
            Assert.IsInstanceOfType(elf, typeof(ElfUnitImpl));
        }

        [TestMethod]
        public void TestUnitOrc()
        {
            Unit elf = new OrcUnitImpl();
            Assert.IsInstanceOfType(elf, typeof(OrcUnitImpl));
        }

        [TestMethod]
        public void TestUnitNain()
        {
            Unit elf = new NainUnitImpl();
            Assert.IsInstanceOfType(elf, typeof(NainUnitImpl));
        }
      


    }
}