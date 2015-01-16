using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PROJECTUML
{
    public class NewGamePlayImpl : GamePlayBuilderImpl, NewGamePlay
    {
        public NewGamePlayImpl()
        {
        }

        /**
         * \brief    Start the game with initialization of the list of players and the map choosed 
         * \param map the tpe of the map
         * \param player1,player2 the names of the players
         * \param people1,people2 the types of the people of the players
         * \return   a gamePlay
         */
        public GamePlay start( MapType map,string player1, PeopleType people1, string player2, PeopleType people2)
        {
            Map m = createMap(map);
            List<Player> l = new List<Player>(2);
            Player p1 = createPlayer(player1, people1,m.TurnNumber);
            Player p2 = createPlayer(player2, people2,m.TurnNumber);

            p1.addUnitPlayer(m.UnitNumber);
            p2.addUnitPlayer(m.UnitNumber);
            p1.NbUnit = m.UnitNumber;
            p2.NbUnit = m.UnitNumber;

            l.Add(p1);
            l.Add(p2);
            m.placeUnits(p1.PeoplePlayer.ListUnit, p2.PeoplePlayer.ListUnit);
            GamePlay p = new GamePlayImpl(m, l, map);
            return p;
        }

        /**
         * \brief    Create a Map 
         * \param   strategy choice between Demo, Small and Normal
         *\ return a map with strategy choosed
         */
        public Map createMap(MapType strategy)
        {

            if (strategy == MapType.DEMO)
            {
                Strategy dm = new DemoImpl();
                return dm.execute();
            }
            if (strategy == MapType.SMALL)
            {
                Strategy sm = new SmallImpl();
                return sm.execute();
            }
            if (strategy == MapType.NORMAL)
            {
                Strategy nm = new NormalImpl();
                return nm.execute();
            }

            throw new System.NotImplementedException();
        }


        /**
         * \brief    Create a Player 
         * \param   name the name of the player
         * \param   turnLeft the number of turn left
         * \param   people the type of the people of the player
         * \return player 
         */
        public Player createPlayer(string name, PeopleType people, int turnLeft) 
        {

            return new PlayerImpl(name, people, turnLeft);

        }

    }
}
