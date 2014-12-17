using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROJECTUML;

namespace TestCombat
{
    [TestClass]
    public class TestGamePlay
    {
        [TestMethod]
        public void TestCreatGamePlay()
        {
            //variable pour le choix du GamePlay: 0 pour NewGamePlay, 1 pour LoadGamePlay
       


            // demande entre LoadGameplay et NewGamePlay
         
                    //NewGamePlay
                    GamePlayBuilder builder_new = new NewGamePlayImpl();
                    GamePlay game_new=builder_new.start("nour",PeopleType.ELF,PeopleType.ORC,"marc",MapType.DEMO);
                    Assert.AreEqual(game_new.MapGame.UnitNumber, 4);  
            
            
        }

    }
}
