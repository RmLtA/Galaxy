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
        public GamePlay start()
        {
            
            //demande des informations aux joueurs via l'interface graphique
            List<Player> l = new List<Player>();
            Player p1 = createPlayer("nour", 0, 0);
            Player p2 = createPlayer("marc", 0, 1);
          


            //à récupérer parmi les infos demander
             //ajout vérifiaction de choix entr les 2 map différents
             Map m = createMap(l[0].Map);

            //emplissag des unités dans la liste d'un peuple
             p1.addUnitPlayer(m.UnitNumber);
             p2.addUnitPlayer(m.UnitNumber);
             l.Add(p1);
             l.Add(p2);

            //placement des unites sur la Map
             m.placeUnits(p1._PeopleImpl._ListUnit, p2._PeopleImpl._ListUnit);

            //placer sur la map les unites de joueurs 
            GamePlay p = new GamePlayImpl(m, l);
            return p;
         
            throw new System.NotImplementedException();
        }




        /**
         * \brief    Create a Map 
         * \return   strategy choice between Demo, Small and Normal
         */
        public Map createMap(int strategy)
        {

            if (strategy == 0)
            {
                Strategy dm = new DemoImpl();
                return dm.execute();
            }
            if (strategy == 1)
            {
                Strategy sm = new SmallImpl();
                return sm.execute();
            }
            if (strategy == 2)
            {
                Strategy nm = new NormalImpl();
                return nm.execute();
            }

            throw new System.NotImplementedException();
        }

        public Player createPlayer(string name, int map, int people) 
        {

            return new PlayerImpl(name, map, people);

        }

        
        public void fillInSquare()
        {
            throw new System.NotImplementedException();
        }
    }
}
