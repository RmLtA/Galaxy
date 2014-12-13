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
                if (_Map.juxtaposedSquare(u, row, column))
                {
                    //choisir le nombre de combats
                    if (_Map.returnSquare(row, column).ListUnitImpl.Count == 1)
                    {
                        return u.engageCombat(u, _Map.returnSquare(row, column).ListUnitImpl[0]);
                    }
                    else
                    {
                        int index = 0;
                        int nbCombat = _Map.chooseNbCombat(row, column);
                        bool result = false;
                        while (nbCombat > 0)
                        {
                            u.engageCombat(u, _Map.returnSquare(row, column).ListUnitImpl[index]);
                            index++;
                            nbCombat--;
                        }
                        return result; 
                    }
                }
            }
            
            
            throw new System.NotImplementedException();
        }

        public void moveUnitOrder(Unit u, int column, int row)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface GamePlay
    {
        MapImpl _Map { get; set; }

        List<Player> _ListPlayer { get; set; }
       
        void gotoNextPlayer();

        void stop();

        bool startCombat(Unit u, int row, int column);

        void registerGamePlay();

        void moveUnitOrder(Unit u, int column, int row);

      
    }
}
