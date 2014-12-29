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
        private GamePlay _instance;

        public  GamePlay Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GamePlayImpl();

                return _instance;
            }

            set
            {
                _instance = value;
            }
        }

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

        private GamePlayImpl() { }

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
        }

        public Player whoseturn()
        {
            for (int i = 0; i < ListPlayer.Count; i++)
            {
                if (ListPlayer[i].Turn == true)
                {
                    return ListPlayer[i];
                }
            }
            return null;
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
            if (u != null)
            { 
                if (u.MovePoint < 1)
                {
                    return false;
                }
                else
                {
                    if (Map.returnSquare(row, column) != null)
                    {
                        if (Map.juxtaposedSquare(u, row, column))
                        {
                            if (Map.returnSquare(row, column).ListUnitImpl.Count == 1)
                            {
                                return isCombatWinned(u, Map.returnSquare(row, column).ListUnitImpl[0]);
                            }
                            else
                            {
                                int index = 0;
                                int nbCombat = Map.chooseNbCombat(row, column);
                                bool result = false;
                                //index --> pour vérifier qu'on ne sort pas du tableau
                                while ((nbCombat > 0) && (index < Map.returnSquare(row, column).ListUnitImpl.Count))
                                {
                                    isCombatWinned(u, Map.returnSquare(row, column).ListUnitImpl[index]);
                                    index++;
                                    nbCombat--;
                                    
                                }
                                result = true;
                                return result;
                            }
                        }
                    }
                    else { return false; }
                }
            }
            return false;
        }

        public bool isCombatWinned(Unit attack, Unit defense)
        {
            if (attack.engageCombat(attack, defense) == true)
            {
 
                if (defense.LifePoint > 0)
                {
                    defense.LifePoint--;
                    if (whoseturn() == ListPlayer[0])
                    {
                        // retour à la case de départ
                        moveUnitOrder(defense, Map.SquareNumber - 1, Map.SquareNumber - 1);
                    }
                    else
                    {
                        moveUnitOrder(defense, 0, 0);
                    }
                }
                else
                {
                    delete(defense);
                }
                return true;
            }

            if (attack.LifePoint > 0)
            {
                attack.LifePoint--;
                if (whoseturn() == ListPlayer[0])
                {
                    moveUnitOrder(attack, 0, 0);
                }
                else
                {
                    moveUnitOrder(attack, Map.SquareNumber-1, Map.SquareNumber-1);
                }
            }
            else
            {
                delete(attack);
            }
            return false;
        }

        public void delete(Unit u)
        {
            if (whoseturn() == ListPlayer[0])
            {
                ListPlayer[0].PeoplePlayer.deleteInList(u);
            }
            else
            {
                ListPlayer[1].PeoplePlayer.deleteInList(u);
            }
            Map.returnSquare(u.Row, u.Column).removeFromSquare(u);
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
            int previous_row;
            int previous_column;
            Unit unit_move = u;
            if (unit_move.MovePoint >= 1)
            {
                s = Map.returnSquare(row, column);
                if (unit_move is ElfUnit)
                {
                    if (s is Forest)
                    {
                        unit_move.MovePoint = u.MovePoint / 2;
                    }
                    if (s is Desert)
                    {
                        unit_move.MovePoint = u.MovePoint * 2;
                    }
                    if (s is Plain)
                    {
                        unit_move.MovePoint = u.MovePoint - 1;
                    }
                }

                if (unit_move is OrcUnit)
                {
                    if (s is Desert)
                    {
                        unit_move.MovePoint = u.MovePoint - 1;
                    }
                    if (s is Plain)
                    {
                        unit_move.MovePoint = u.MovePoint / 2;
                    }
                    if (s is Forest)
                    {
                        unit_move.MovePoint = u.MovePoint * 2;
                    }
                }

                if (unit_move is NainUnit)
                {
                    if (s is Desert)
                    {
                        unit_move.MovePoint = u.MovePoint - 1;
                    }
                    if (s is Forest)
                    {
                        unit_move.MovePoint = u.MovePoint / 2;
                    }
                    if (s is Plain)
                    {
                        unit_move.MovePoint = u.MovePoint * 2;
                    }
                }

                previous_row = u.Row;
                previous_column = u.Column;
                Map.BoardGame[previous_row, previous_column].removeFromSquare(u);

                unit_move.Row = row;
                unit_move.Column = column;
                Map.BoardGame[row, column].addUnitInSquare(unit_move);

                u.move(row, column);
            }


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
        Player whoseturn();

        void delete(Unit u);

         GamePlay Instance { get; set; }

    }
}
