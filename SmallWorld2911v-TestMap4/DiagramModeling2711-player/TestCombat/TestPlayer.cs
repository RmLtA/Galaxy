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
            Player p = new PlayerImpl("nour", PeopleType.ELF);
            p.addUnitPlayer(5);
            Map m=new MapImpl(MapType.DEMO);
            m.addPlayers(p.PeoplePlayer.ListUnit, p.PeoplePlayer.ListUnit);

           
        }
    }
}
