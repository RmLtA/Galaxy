using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROJECTUML;
namespace TestCombat
{
    [TestClass]
    public class TestUnitPoint
    {
        [TestMethod]
        public void _TestUnitPoint()
        {
            GamePlayBuilder builder_new = new NewGamePlayImpl();
            GamePlay newgame = builder_new.start(MapType.DEMO, "nour", PeopleType.ELF, "marc", PeopleType.ORC);
            Assert.AreEqual(newgame.ListPlayer[0].PeoplePlayer.ListUnit[0].MovePoint, 1);
            Assert.AreEqual(newgame.ListPlayer[0].PeoplePlayer.ListUnit[0].LifePoint, 5);
            Assert.AreEqual(newgame.ListPlayer[0].PeoplePlayer.ListUnit[0].AttackPoint, 2);
        }
    }
}
