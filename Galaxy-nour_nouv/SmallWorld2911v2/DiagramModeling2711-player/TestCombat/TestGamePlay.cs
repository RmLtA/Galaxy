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
            Assert.AreEqual(newgame.Map.UnitNumber, 4);

            ///*Vérification des points des unités*/
            //Assert.AreEqual(newgame.ListPlayer[0].PeoplePlayer.ListUnit[0].MovePoint, 1);
            //Assert.AreEqual(newgame.ListPlayer[0].PeoplePlayer.ListUnit[0].LifePoint, 5);
            //Assert.AreEqual(newgame.ListPlayer[0].PeoplePlayer.ListUnit[0].AttackPoint, 2);
            //Assert.AreEqual(newgame.ListPlayer[0].PeoplePlayer.ListUnit[0].DefensePoint, 1);

            ///*Vérifiaction des coordonnées*/
            //Assert.AreEqual(newgame.ListPlayer[0].PeoplePlayer.ListUnit[0].Row, 0);
            //Assert.AreEqual(newgame.ListPlayer[0].PeoplePlayer.ListUnit[0].Column, 0);
            //Assert.AreEqual(newgame.ListPlayer[1].PeoplePlayer.ListUnit[0].Row, newgame.Map.SquareNumber - 1);
            //Assert.AreEqual(newgame.ListPlayer[1].PeoplePlayer.ListUnit[0].Column, newgame.Map.SquareNumber-1);

            /*Test de moveUnitOrder et moveUnit*/
            //newgame.moveUnitOrder(newgame.ListPlayer[0].PeoplePlayer.ListUnit[0], 0, 1);
            //Assert.AreEqual(newgame.ListPlayer[0].PeoplePlayer.ListUnit[0].Row, 0);
            //Assert.AreEqual(newgame.ListPlayer[0].PeoplePlayer.ListUnit[0].Column, 1);

            /*Test pour la suggestion des cases*/


                /*Test de juxtaposedSquare*/
            //newgame.moveUnitOrder(newgame.ListPlayer[1].PeoplePlayer.ListUnit[0], 0, 2);
            //Assert.AreEqual(newgame.ListPlayer[1].PeoplePlayer.ListUnit[0].Row, 0);
            //Assert.AreEqual(newgame.ListPlayer[1].PeoplePlayer.ListUnit[0].Column, 2);

            //bool flag = newgame.Map.juxtaposedSquare(newgame.ListPlayer[0].PeoplePlayer.ListUnit[0], 0, 2);
            //Assert.AreEqual(flag, true);

            //ElfUnit u = new ElfUnitImpl();
            //u.Row = 0;
            ////u.Column = 0;
            ////bool test1 = newgame.Map.juxtaposedSquare(u, 0, 1);
            ////Assert.AreEqual(test1, true);

            ////ElfUnit u1 = new ElfUnitImpl();
            ////u1.Row = 1;
            ////u1.Column = 0;
            ///*bool test2 = newgame.Map.juxtaposedSquare(u1, 0, 0);
            //Assert.AreEqual(test2, true);
            //bool test3 = newgame.Map.juxtaposedSquare(u1, 1, 0);
            //c*/
            ////bool test4 = newgame.Map.juxtaposedSquare(u1, 0, 2);
            ////Assert.AreEqual(test4, false);
            ////bool test5 = newgame.Map.juxtaposedSquare(u1, 1, 2);
            ////Assert.AreEqual(test5, true);


            ///*Test de startCombat*/
            //int move1 = newgame.ListPlayer[0].PeoplePlayer.ListUnit[0].MovePoint;
            //int attack1 = newgame.ListPlayer[0].PeoplePlayer.ListUnit[0].AttackPoint;
            //int life1 = newgame.ListPlayer[0].PeoplePlayer.ListUnit[0].LifePoint;

            //int move2 = newgame.ListPlayer[1].PeoplePlayer.ListUnit[0].MovePoint;
            //int attack2 = newgame.ListPlayer[1].PeoplePlayer.ListUnit[0].AttackPoint;
            //newgame.ListPlayer[0].PeoplePlayer.ListUnit[0].MovePoint = newgame.ListPlayer[0].PeoplePlayer.ListUnit[0].MovePoint + 3;
            //newgame.ListPlayer[1].PeoplePlayer.ListUnit[0].LifePoint = newgame.ListPlayer[1].PeoplePlayer.ListUnit[0].LifePoint - 3;


            ///*Test de returnUnitBestLife()*/
            //Square testSquare = new DesertImpl();
            //ElfUnit uelf1 = new ElfUnitImpl();
            //uelf1.LifePoint = 3;
            //ElfUnit uelf2 = new ElfUnitImpl();
            //uelf2.LifePoint = 7;
            //ElfUnit uelf3 = new ElfUnitImpl();
            //uelf3.LifePoint = 2;
            //testSquare.ListUnitImpl.Add(uelf1);
            // testSquare.ListUnitImpl.Add(uelf2);
            // testSquare.ListUnitImpl.Add(uelf3);

            //int  bestLife = testSquare.returnUnitBestLife().LifePoint;
            //Assert.AreEqual(bestLife, 7);
            // Assert.AreEqual(uelf2.LifePoint, 7);
            // Assert.AreEqual(uelf1.LifePoint, 3);
            // Assert.AreEqual(uelf3.LifePoint, 2);

            ///*Test de engageCombat(attack, defense)*/
            // ElfUnit attack = new ElfUnitImpl();
            // attack.AttackPoint = 1;
            // OrcUnit defense = new OrcUnitImpl();
            // defense.AttackPoint = 9;

            // bool testCombat = attack.engageCombat(defense, attack);
            // Assert.AreEqual(testCombat, true);

            ///*Test startCombat(u,row,column)*/
            // newgame.startCombat(newgame.ListPlayer[0].PeoplePlayer.ListUnit[0], 0, 1);





















            
        }

    }
}
