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
         * \return   l List of players
         */
        public GamePlay start( MapType map,string player1, PeopleType people1, string player2, PeopleType people2)
        {
            
            //demande des informations aux joueurs via l'interface graphique
            List<Player> l = new List<Player>(2);
            Player p1 = createPlayer(player1, people1);
            Player p2 = createPlayer(player2, people2);

            Map m = createMap(map);

            //remplissage des unités dans la liste d'un peuple
            p1.addUnitPlayer(m.UnitNumber);
            p2.addUnitPlayer(m.UnitNumber);
            p1.NbUnit = m.UnitNumber;
            p2.NbUnit = m.UnitNumber;

            l.Add(p1);
            l.Add(p2);


            //placement des unites sur la Map
            m.placeUnits(p1.PeoplePlayer.ListUnit, p2.PeoplePlayer.ListUnit);

            

            //placer sur la map les unites de joueurs 
            GamePlay p = new GamePlayImpl(m, l, map);
            return p;
         
            throw new System.NotImplementedException();
        }




        /**
         * \brief    Create a Map 
         * \return   strategy choice between Demo, Small and Normal
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
         * \param   name
         * \param   map
         * \param   people
         */
        public Player createPlayer(string name, PeopleType people) 
        {

            return new PlayerImpl(name, people);

        }

        /* ça sert pour Load Game */ 
        public void fillInSquare()
        {
            throw new System.NotImplementedException();
        }
    }
}
