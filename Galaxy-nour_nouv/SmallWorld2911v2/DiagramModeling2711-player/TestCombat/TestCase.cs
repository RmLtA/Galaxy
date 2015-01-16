using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROJECTUML;
namespace TestCombat
{
    [TestClass]
    public class TestCase
    {
        [TestMethod]
        public void TestCaseDesert()
        {
            SquareFactory squarefactory = new SquareFactoryImpl();
            Desert c = squarefactory.createDesert();
             Assert.IsInstanceOfType(c, typeof(Desert));
        }

        [TestMethod]
        public void TestCaseForest()
        {
            SquareFactory squarefactory = new SquareFactoryImpl();
            Forest c = squarefactory.createForest();
            Assert.IsInstanceOfType(c, typeof(Forest));
        }
        [TestMethod]
        public void TestCaseMountain()
        {
            SquareFactory squarefactory = new SquareFactoryImpl();
            Mountain c = squarefactory.createMountain();
            Assert.IsInstanceOfType(c, typeof(Mountain));
        }
        [TestMethod]
        public void TestCasePlain()
        {
            SquareFactory squarefactory = new SquareFactoryImpl();
            Plain c = squarefactory.createPlain();
            Assert.IsInstanceOfType(c, typeof(Plain));
        }

    }
    
}

