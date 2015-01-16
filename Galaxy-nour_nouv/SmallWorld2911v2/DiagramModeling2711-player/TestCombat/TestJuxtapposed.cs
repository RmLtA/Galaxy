using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROJECTUML;
namespace TestCombat
{
    [TestClass]
    public class TestJuxtapposed
    {
        [TestMethod]
        public void _TestJuxtapposed()
        {
            GamePlayBuilder builder_new = new NewGamePlayImpl();
            GamePlay newgame = builder_new.start(MapType.DEMO, "nour", PeopleType.ELF, "marc", PeopleType.ORC);
            bool flag = newgame.Map.juxtaposedSquare(newgame.ListPlayer[0].PeoplePlayer.ListUnit[0], 0,1);
            Assert.AreEqual(flag, true);
        }
    }
}
