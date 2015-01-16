using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROJECTUML;
namespace TestCombat
{
    [TestClass]
    public class TestMapDemo
    {
        [TestMethod]
        public void _TestMapDemo()
        {
              Strategy srategyDemo = new DemoImpl();
              Map m= srategyDemo.execute();
              Assert.AreEqual(m.SquareNumber,5);
              Assert.AreEqual(m.UnitNumber,4);

            
        }
        [TestMethod]
        public void _TestNbcombat()
        {
            Strategy srategyDemo = new DemoImpl();
            Map m = srategyDemo.execute();
            int x=m.chooseNbCombat(0,0);
            Assert.AreEqual(x, 0);


        }

    }
}
