using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROJECTUML;
namespace TestCombat
{
    [TestClass]
    public class TestPlayer
    {
        [TestMethod]
        public void TestCreatPlayer()
        {
            Player p;
            p = new PlayerImpl("nour", 0, 0);  
        }
    }
}
