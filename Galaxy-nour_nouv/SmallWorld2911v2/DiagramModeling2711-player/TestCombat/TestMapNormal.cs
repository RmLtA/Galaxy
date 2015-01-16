using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROJECTUML;
namespace TestCombat
{
    [TestClass]
    public class TestMapNormal
    {
        [TestMethod]
        public void _TestMapNormal()
        {
            Strategy srategyDemo = new NormalImpl();
            Map m = srategyDemo.execute();
            Assert.AreEqual(m.SquareNumber, 15);
            Assert.AreEqual(m.UnitNumber, 8);

        }
    }
}
