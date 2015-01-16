using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROJECTUML;
namespace TestCombat
{
    [TestClass]
    public class TestGame
    {
        [TestMethod]
        public void TestNextPlayer()
        {
            GamePlayBuilder builder_new = new NewGamePlayImpl();
            GamePlay newgame = builder_new.start(MapType.DEMO, "nour", PeopleType.ELF, "marc", PeopleType.ORC);
            Assert.AreEqual(newgame.ListPlayer[0].Turn, false);
            newgame.gotoNextPlayer();
            Assert.AreEqual(newgame.ListPlayer[0].Turn, true);
        }

       
    }
}
