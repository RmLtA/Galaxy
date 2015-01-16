using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROJECTUML;
namespace TestCombat
{
    [TestClass]
    public class TestMapSmall
    {
        [TestMethod]
        public void _TestMapSmall()
        {
            Strategy srategyDemo = new SmallImpl();
            Map m = srategyDemo.execute();
            Assert.AreEqual(m.SquareNumber, 10);
            Assert.AreEqual(m.UnitNumber, 6);


        }
    }
}
