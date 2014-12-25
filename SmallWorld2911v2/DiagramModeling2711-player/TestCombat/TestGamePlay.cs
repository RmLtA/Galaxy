using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROJECTUML;
using System.Collections.Generic;

namespace TestCombat
{
    [TestClass]
    public class TestGamePlay
    {
        [TestMethod]
        public void TestCreatGamePlay()
        {


            
            GamePlayBuilder builder_new = new NewGamePlayImpl();
            GamePlay newgame = builder_new.start( MapType.DEMO,"nour", PeopleType.ELF, "marc",PeopleType.ORC);
            Assert.AreEqual(newgame.Map.UnitNumber, 6);

            /*Vérification des points des unités*/
            Assert.AreEqual(newgame.ListPlayer[0].PeoplePlayer.ListUnit[0].MovePoint, 1);
            Assert.AreEqual(newgame.ListPlayer[0].PeoplePlayer.ListUnit[0].LifePoint, 5);
            Assert.AreEqual(newgame.ListPlayer[0].PeoplePlayer.ListUnit[0].AttackPoint, 2);
            Assert.AreEqual(newgame.ListPlayer[0].PeoplePlayer.ListUnit[0].DefensePoint, 1);

            /*Vérifiaction des coordonnées*/
            Assert.AreEqual(newgame.ListPlayer[0].PeoplePlayer.ListUnit[0].Row, 0);
            Assert.AreEqual(newgame.ListPlayer[0].PeoplePlayer.ListUnit[0].Column, 0);
            Assert.AreEqual(newgame.ListPlayer[1].PeoplePlayer.ListUnit[0].Row, newgame.Map.SquareNumber - 1);
            Assert.AreEqual(newgame.ListPlayer[1].PeoplePlayer.ListUnit[0].Column, newgame.Map.SquareNumber-1);

            /*Test de moveUnitOrder et moveUnit*/
            newgame.moveUnitOrder(newgame.ListPlayer[0].PeoplePlayer.ListUnit[0], 0, 1);
            Assert.AreEqual(newgame.ListPlayer[0].PeoplePlayer.ListUnit[0].Row, 0);
            Assert.AreEqual(newgame.ListPlayer[0].PeoplePlayer.ListUnit[0].Column, 1);

            /*Test pour la suggestion des cases*/


                /*Test de juxtaposedSquare*/
            newgame.moveUnitOrder(newgame.ListPlayer[1].PeoplePlayer.ListUnit[0], 0, 2);
            Assert.AreEqual(newgame.ListPlayer[1].PeoplePlayer.ListUnit[0].Row, 0);
            Assert.AreEqual(newgame.ListPlayer[1].PeoplePlayer.ListUnit[0].Column, 2);

            bool flag = newgame.Map.juxtaposedSquare(newgame.ListPlayer[0].PeoplePlayer.ListUnit[0], 0, 2);
            Assert.AreEqual(flag, true);

            ElfUnit u = new ElfUnitImpl();
            u.Row = 0;
            u.Column = 0;
            bool test1 = newgame.Map.juxtaposedSquare(u, 0, 1);
            Assert.AreEqual(test1, true);

            ElfUnit u1 = new ElfUnitImpl();
            u1.Row = 1;
            u1.Column = 0;
            /*bool test2 = newgame.Map.juxtaposedSquare(u1, 0, 0);
            Assert.AreEqual(test2, true);
            bool test3 = newgame.Map.juxtaposedSquare(u1, 1, 0);
            Assert.AreEqual(test3, true);*/
            bool test4 = newgame.Map.juxtaposedSquare(u1, 0, 2);
            Assert.AreEqual(test4, false);
            //bool test5 = newgame.Map.juxtaposedSquare(u1, 1, 2);
            //Assert.AreEqual(test5, true);


            /*Test de startCombat*/
            int move1 = newgame.ListPlayer[0].PeoplePlayer.ListUnit[0].MovePoint;
            int attack1 = newgame.ListPlayer[0].PeoplePlayer.ListUnit[0].AttackPoint;
            int life1 = newgame.ListPlayer[0].PeoplePlayer.ListUnit[0].LifePoint;

            int move2 = newgame.ListPlayer[1].PeoplePlayer.ListUnit[0].MovePoint;
            int attack2 = newgame.ListPlayer[1].PeoplePlayer.ListUnit[0].AttackPoint;
            newgame.ListPlayer[0].PeoplePlayer.ListUnit[0].MovePoint = newgame.ListPlayer[0].PeoplePlayer.ListUnit[0].MovePoint + 3;
            newgame.ListPlayer[1].PeoplePlayer.ListUnit[0].LifePoint = newgame.ListPlayer[1].PeoplePlayer.ListUnit[0].LifePoint - 3;



            /*bool flag1 = newgame.ListPlayer[1].PeoplePlayer.ListUnit[0].
                engageCombat(newgame.ListPlayer[0].PeoplePlayer.ListUnit[0], newgame.ListPlayer[1].PeoplePlayer.ListUnit[0]);
            Assert.AreEqual(flag1, false);
            bool flag3 = newgame.ListPlayer[1].PeoplePlayer.ListUnit[0].
                engageCombat(newgame.ListPlayer[1].PeoplePlayer.ListUnit[0], newgame.ListPlayer[0].PeoplePlayer.ListUnit[0]);
            Assert.AreEqual(flag3, true);

            bool flag1 = newgame.startCombat(newgame.ListPlayer[0].PeoplePlayer.ListUnit[0], 0, 2);
            Assert.AreEqual(flag1, true); 
             */
              
             
              
              

            



            /******************************************************************************

            //Test returnUnitBestLife
           newgame._Map.returnSquare(0,0).returnUnitBestLife();
           newgame._Map.returnSquare(0, 0).returnUnitBestDefense();
           newgame._Map.unitBestDefense(0,0);


            //Test chooseNbCombat(0,0)
           int result = newgame._Map.chooseNbCombat(0, 0);

            //Test engageCombat(attacke,defense)
           newgame._Map.returnSquare(0, 0).ListUnitImpl[0].engageCombat(newgame._Map.returnSquare(0, 0).ListUnitImpl[0], 
               newgame._Map.returnSquare(0, 0).ListUnitImpl[1]);

            //Test startCombat
           newgame.startCombat(newgame._Map.returnSquare(0, 0).ListUnitImpl[0], 0, 0);

            **********************************************************************************************************/






















            /*************************************************************
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
            */

            
        }

    }
}
