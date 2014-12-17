using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    public class GamePlayImpl : GamePlay
    {
        private MapType _typeMap;
        private List<Player> _ListPlayer;
        private Map _Map;

        public MapType TypeMap
        {
            get
            {
                return _typeMap;
            }
            set
            {
                _typeMap = value;
            }
        }

        public Map MapGame
        {
            get
            {
                return _Map;
            }
            set
            {
                _Map = value;
            }
        }

        public List<Player> ListPlayer
        {
            get
            {
                return _ListPlayer;
            }
            set
            {
                _ListPlayer = value;
            }
        }

        /**
         * \brief    Constructor of a gameplay   
         * \param    m  Map of the game
         * \param    l List of Player
         */
        public GamePlayImpl(Map m, List<Player> l,MapType typemap)
        {
            TypeMap = typemap;
            MapGame =(MapImpl) m;
            ListPlayer = l;

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
        List<Player> ListPlayer { get; set; }
        Map MapGame { get; set; }
        MapType TypeMap { get; set; }
        void gotoNextPlayer();

        void stop();

        void startCombat(Unit u, int row, int column);

        void registerGamePlay();

        void moveUnitOrder(Unit u, int column, int row);

      
    }
}
