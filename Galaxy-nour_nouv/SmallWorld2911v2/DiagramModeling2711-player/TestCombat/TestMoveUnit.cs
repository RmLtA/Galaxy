using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROJECTUML;
namespace TestCombat
{
    [TestClass]
    public class TestMoveUnit
    {
        [TestMethod]
        public void _TestMoveUnit()
        {

            GamePlayBuilder builder_new = new NewGamePlayImpl();
            GamePlay newgame = builder_new.start(MapType.DEMO, "nour", PeopleType.ELF, "marc", PeopleType.ORC);
           

            
            newgame.moveUnitOrder(newgame.ListPlayer[0].PeoplePlayer.ListUnit[0], 0, 1);
            Assert.AreEqual(newgame.ListPlayer[0].PeoplePlayer.ListUnit[0].Row, 0);
            Assert.AreEqual(newgame.ListPlayer[0].PeoplePlayer.ListUnit[0].Column, 1);
        }
    }
}
