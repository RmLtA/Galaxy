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
         * \param typeMap the type of the map
         */
        public GamePlayImpl(Map m, List<Player> l, MapType typeMap)
        {
            Map = (MapImpl)m;
            ListPlayer = l;
            _TypeMap = typeMap;

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
        /**
         * \brief  return the player who has the turn
         * \return player
         */
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
                            if (Map.returnSquare(row, column).ListUnitImpl.Count > 1)
                            {
                                int index = 0;
                                
                                if (Map.returnSquare(row, column).returnUnitBestDefense() == null)
                                {
                                    int nbCombat = Map.chooseNbCombat(row, column);
                                    bool result = false;
                                    int cpt = 0;
                                    while ((nbCombat>0)&&(cpt < Map.returnSquare(row, column).ListUnitImpl.Count) && (index < Map.returnSquare(row, column).ListUnitImpl.Count))
                                    {
                                        
                                        result = isCombatWinned(u, Map.returnSquare(row, column).ListUnitImpl[index]);
                                        index++;
                                        nbCombat--;
                                        cpt++;

                                    }
                                    return result;
                                }
                            }
                            else
                            {
                                return isCombatWinned(u, Map.returnSquare(row, column).ListUnitImpl[0]);
                            }
                       
                    }else {
                        return false; 
                    }
                }
            }
            return false;
        }

        /**
         * \brief    Check if the combat is winned
         * \param    defense the attacked unit
         * \param    attack the attacker unit
         * \return   true if attack won
         */
        public bool isCombatWinned(Unit attack, Unit defense)
        {
            if (attack.engageCombat(attack, defense) == true)
            {
 
                if (defense.LifePoint > 0)
                {
                    defense.LifePoint--;  
                }
                return true;
            }
            else
            {
                if (attack.LifePoint > 0)
                {
                    attack.LifePoint--;
                }
                return false;
            }
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
                    if ((s is Plain) || (s is Mountain))
                    {
                        u.MovePoint = u.MovePoint - 1;
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
                    if ((s is Forest) || (s is Mountain))
                    {
                        u.MovePoint = u.MovePoint - 1;
                    }
                }

                if (u is NainUnit)
                {
                    if (s is Desert)
                    {
                        u.MovePoint = u.MovePoint - 1;
                    }
                    if (s is Forest)
                    {
                        u.MovePoint = u.MovePoint - 1;
                    }
                    if (s is Plain)
                    {
                        u.MovePoint = u.MovePoint / 2;
                    }
                }
                previous_row = u.Row;
                previous_column = u.Column;
                Map.BoardGame[previous_row, previous_column].removeFromSquare(u);
                u.move(row, column);
                Map.BoardGame[row, column].addUnitInSquare(u);
            }
        }
        /**
                 * \brief    return a table of rows for suggested cases 
                 * \param    u unit to move
                 * \return   table of rows
                 */
        public unsafe  int[] squareSuggestedX(Unit u)
        {
            int* tabX = Map.wrapper.moveAroundX();
            int[] tabXnew = new int[6];
            for (int i = 0; i < 6; i++)
            {
                tabXnew[i] = u.Row + tabX[i];
            }
                return tabXnew;
             
        }
        /**
                * \brief    return a table of columns for suggested cases 
                * \param    u unit to move
                * \return   table of columns
                */
        public unsafe int[] squareSuggestedY(Unit u)
        {
            int* tabY = Map.wrapper.moveAroundY();
            int[] tabYnew = new int[6];
            for (int i = 0; i < 6; i++)
            {
                tabYnew[i] = u.Column + tabY[i];
            }
            return tabYnew;

        }
        /**
                * \brief    check if all the units of the player are dead 
                * \param    p player te check
                * \return   true if all the units of the player are dead
                */
        public bool allIsDead(Player p)
        {
            foreach (Unit u in p.PeoplePlayer.ListUnit)
            {
                if (u.LifePoint != 0) return false;
            }
            return true;
        }
        /**
                 * \brief    check if all the units of the player can't move
                 * \param    p player te check
                 * \return   true if all the units of the player can't move
                 */
        public bool allCantMove(Player p)
        {
            foreach (Unit u in p.PeoplePlayer.ListUnit)
            {
                if (u.MovePoint != 0) return false;
            }
            return true;
        }

        public bool belongToPlayer(Unit u, Player p)
        {
            for (int i = 0; i < p.PeoplePlayer.ListUnit.Count; i++)
            {
                if ((u.Row == p.PeoplePlayer.ListUnit[i].Row) && (u.Column == p.PeoplePlayer.ListUnit[i].Column))
                {
                    return true;
                }
            }
            return false;
        }




    }

    public interface GamePlay
    {
        MapImpl Map { get; set; }

        List<Player> ListPlayer { get; set; }
        MapType TypeMap { get; set; }
       
        void gotoNextPlayer();

        bool startCombat(Unit u, int row, int column);

        void moveUnitOrder(Unit u, int row, int column);
        Player whoseturn();
        bool allCantMove(Player p);
        unsafe int[] squareSuggestedX(Unit u);
        unsafe int[] squareSuggestedY(Unit u);
        bool allIsDead(Player p);
        bool belongToPlayer(Unit u, Player p);
    }
}
