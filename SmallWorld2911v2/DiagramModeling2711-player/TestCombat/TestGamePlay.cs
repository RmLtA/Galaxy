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
            int choix_game = 0;

            Player p1;
            //choix Map demo :0 et choix du people Elf 0
            p1 = new PlayerImpl("nour", 0, 0);

            Player p2;
            //choix Map demo :0 et choix du people Orc 1
            p2 = new PlayerImpl("marc", 0, 1); 


            // demande entre LoadGameplay et NewGamePlay
            switch (choix_game)
            {
                case 0:
                    //NewGamePlay
                    GamePlayBuilder builder_new = new NewGamePlayImpl();
                    GamePlay game_new=builder_new.start(p1, p2);
                    break;
                case 1:
                    //LoadGamePlay
                    GamePlayBuilder builder_load = new LoadGamePlayImpl();
                    GamePlay game_load=builder_load.start(p1, p2);
                    break;

            }
            
            
        }

    }
}
