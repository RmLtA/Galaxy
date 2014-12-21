using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    public class GamePlayImpl : GamePlay
    {
        private MapImpl _Map;
        private List<Player> _ListPlayer;
        private MapType _TypeMap;

        public MapImpl Map
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

        public MapType TypeMap
        {
            get
            {
                return _TypeMap;
            }
            set
            {
                _TypeMap = value;
            }
        }

        /**
         * \brief    Constructor of a gameplay   
         * \param    m  Map of the game
         * \param    l List of Player
         */
        public GamePlayImpl(Map m, List<Player> l, MapType typeMap)
        {
            Map =(MapImpl) m;
            ListPlayer = l;
            _TypeMap = typeMap;

        }

        public void stop()
        {
            throw new System.NotImplementedException();
        }

        /**
         * \brief    decides the next turn   
         */
        public void gotoNextPlayer()
        {
            if (ListPlayer[0].Turn == false)
            {
                ListPlayer[0].Turn = true;
                ListPlayer[1].Turn = false;
            }
            else
            {
                ListPlayer[1].Turn = true;
                ListPlayer[0].Turn = false;
            }
            throw new System.NotImplementedException();
        }

        public void registerGamePlay()
        {
            throw new System.NotImplementedException();
        }

        /**
         * \brief    return true if the attacking unit winned against unit(s) in the square[row,column]
         * \return   bool winned 
         */
        public bool startCombat(Unit u, int row, int column)
        {
            //vérification du nombre de point de déplacement
            if (u.MovePoint < 1)
            {
                return false;
            }
            else
            {
                //vérification si les cases sont juxtaposées.
                if (Map.juxtaposedSquare(u, row, column))
                {
                    //choisir le nombre de combats
                    if (Map.returnSquare(row, column).ListUnitImpl.Count == 1)
                    {
                        return u.engageCombat(u, Map.returnSquare(row, column).ListUnitImpl[0]);
                    }
                    else
                    {
                        int index = 0;
                        int nbCombat = Map.chooseNbCombat(row, column);
                        bool result = false;
                        while (nbCombat > 0)
                        {
                            u.engageCombat(u, Map.returnSquare(row, column).ListUnitImpl[index]);
                            index++;
                            nbCombat--;
                        }
                        return result; 
                    }
                }
            }
            
            
            throw new System.NotImplementedException();
        }


        /**
         * \brief    change the position of the unit and calculate the bonus and the malus
         * \param   u unit
         * \param   row
         * \param column
         */
        public void moveUnitOrder(Unit u, int row, int column)
        {
            Square s;
            if (u.MovePoint >= 1)
            {
                s = Map.returnSquare(row, column);
                if (u is ElfUnit)
                {
                    if (s is Forest)
                    {
                        u.MovePoint = u.MovePoint / 2;
                    }
                    if (s is Desert)
                    {
                        u.MovePoint = u.MovePoint * 2;
                    }
                    if (s is Plain)
                    {
                        u.MovePoint = u.MovePoint - 1 ;
                    }
                }

                if (u is OrcUnit)
                {
                    if (s is Desert)
                    {
                        u.MovePoint = u.MovePoint - 1;
                    }
                    if (s is Plain)
                    {
                        u.MovePoint = u.MovePoint / 2;
                    }
                }

                if (u is NainUnit)
                {
                    if (s is Desert)
                    {
                        u.MovePoint = u.MovePoint - 1;
                    }
                    if (s is Plain)
                    {
                        u.MovePoint = u.MovePoint / 2;
                    }
                }

                u.move(row, column);
            }

            throw new System.NotImplementedException();
        }
    }

    public interface GamePlay
    {
        MapImpl Map { get; set; }

        List<Player> ListPlayer { get; set; }
        MapType TypeMap { get; set; }
       
        void gotoNextPlayer();

        void stop();

        bool startCombat(Unit u, int row, int column);

        void registerGamePlay();

        void moveUnitOrder(Unit u, int row, int column);

      
    }
}
