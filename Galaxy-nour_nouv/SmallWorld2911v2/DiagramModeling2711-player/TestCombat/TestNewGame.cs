using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROJECTUML;
namespace TestCombat
{
    [TestClass]
    public class TestNewGame
    {
        [TestMethod]
        public void _TestNewGame()
        {
            GamePlayBuilder builder_new = new NewGamePlayImpl();
            GamePlay newgame = builder_new.start(MapType.DEMO, "nour", PeopleType.ELF, "marc", PeopleType.ORC);
            Assert.AreEqual(newgame.Map.UnitNumber, 4);
            Assert.AreEqual(newgame.ListPlayer[0].Name,"nour");
        }
    
        
    }
}
