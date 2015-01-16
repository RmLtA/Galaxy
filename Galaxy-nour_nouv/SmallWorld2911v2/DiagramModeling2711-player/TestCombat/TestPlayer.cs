using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROJECTUML;
namespace TestCombat
{
    [TestClass]
    public class TestPlayer
    {
        [TestMethod]
        public void Testplayer()
        {
            Player p = new PlayerImpl("nour", PeopleType.ORC, 4);
            
            Assert.AreEqual(p.Name,"nour");
            Assert.AreEqual(p.TurnLeft,4);
        }
    }
}
