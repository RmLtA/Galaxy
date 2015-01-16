using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROJECTUML;
namespace TestCombat
{
    [TestClass]
    public class TestStartUnit
    {
        [TestMethod]
        public void _TestStartUnit()
        {
            GamePlayBuilder builder_new = new NewGamePlayImpl();
            GamePlay newgame = builder_new.start(MapType.DEMO, "nour", PeopleType.ELF, "marc", PeopleType.ORC);
            Assert.AreEqual(newgame.ListPlayer[0].PeoplePlayer.ListUnit[0].Row, 0);
            Assert.AreEqual(newgame.ListPlayer[0].PeoplePlayer.ListUnit[0].Column, 0);
            Assert.AreEqual(newgame.ListPlayer[1].PeoplePlayer.ListUnit[0].Row, newgame.Map.SquareNumber - 1);
            Assert.AreEqual(newgame.ListPlayer[1].PeoplePlayer.ListUnit[0].Column, newgame.Map.SquareNumber - 1);
        }
    }
}
