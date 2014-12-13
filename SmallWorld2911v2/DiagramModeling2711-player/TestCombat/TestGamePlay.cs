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
            GamePlay newgame = builder_new.start();

            //récupération de la liste des joueurs
            List<Player> l = new List<Player>();
            l = newgame._ListPlayer;

            int people1 = l[0].People;
            int people2 = l[1].People;

            
            //récupération des peuples
            //récupération de la liste d'unités pour pouvoir être manipulée pour les tests pour le combat
            List<Unit> l_unit1 = new List<Unit>();
            l_unit1 = l[0]._PeopleImpl.ListUnit;
            List<Unit> l_unit2 = new List<Unit>();
            l_unit2 = l[1]._PeopleImpl.ListUnit;
            
            //Test de placeUnits
            newgame._Map.placeUnits(l_unit1, l_unit2);

            /*
            //changement des points de vie des unités
            int nbUnit = newgame._Map.UnitNumber;
            for (int i = 0; i < nbUnit; i++)
            {
                l_unit1[i].LifePoint = l_unit1[i].LifePoint + 1;
            }
            for (int i = 0; i < nbUnit; i++)
            {
                l_unit2[i].LifePoint = l_unit1[i].LifePoint + 1;
            }
            */

            //Test juxtaposedSquare
            newgame._Map.juxtaposedSquare(l_unit1[1], 0, 0);

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
