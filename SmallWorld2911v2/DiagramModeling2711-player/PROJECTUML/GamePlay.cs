using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    public class GamePlayImpl : GamePlay
    {
        public MapImpl _Map
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public List<Player> _ListPlayer
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        /**
         * \brief    Constructor of a gameplay   
         * \param    m  Map of the game
         * \param    l List of Player
         */
        public GamePlayImpl(Map m, List<Player> l)
        {
            _Map =(MapImpl) m;
            _ListPlayer = l;

        }

        public void stop()
        {
            throw new System.NotImplementedException();
        }

        public void gotoNextPlayer()
        {
            throw new System.NotImplementedException();
        }

        public void registerGamePlay()
        {
            throw new System.NotImplementedException();
        }

        public void startCombat(Unit u, int row, int column)
        {
            throw new System.NotImplementedException();
        }

        public void moveUnitOrder(Unit u, int column, int row)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface GamePlay
    {
    
        /*void createGamePlay();*/
       
        void gotoNextPlayer();

        void stop();

        void startCombat(Unit u, int row, int column);

        void registerGamePlay();

        void moveUnitOrder(Unit u, int column, int row);

      
    }
}
