using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROJECTUML;
namespace TestCombat
{
    [TestClass]
    public class StartCombat
    {
        [TestMethod]
        public void _StartCombat()
        {

            GamePlayBuilder builder_new = new NewGamePlayImpl();
            GamePlay newgame = builder_new.start(MapType.DEMO, "nour", PeopleType.ELF, "marc", PeopleType.ORC);
            newgame.moveUnitOrder(newgame.ListPlayer[1].PeoplePlayer.ListUnit[0], 0, 1);
            newgame.moveUnitOrder(newgame.ListPlayer[0].PeoplePlayer.ListUnit[0], 0, 2);
            bool gagne=newgame.startCombat(newgame.ListPlayer[1].PeoplePlayer.ListUnit[0], 0, 2);
            Assert.AreEqual(gagne, false);
        }
    }
}
