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
                            if (Map.returnSquare(row, column).ListUnitImpl.Count > 1)
                            {
                                int index = 0;
                                Unit u_defense = Map.returnSquare(row, column).returnUnitBestDefense();
                                if (u_defense == null)
                                {
                                    int nbCombat = Map.chooseNbCombat(row, column);
                                    bool result = false;
                                    
                                    while ((nbCombat > 0) && (index < Map.returnSquare(row, column).ListUnitImpl.Count))
                                    {
                                        isCombatWinned(u, Map.returnSquare(row, column).ListUnitImpl[index]);
                                        index++;
                                        nbCombat--;

                                    }
                                    result = true;
                                    return result;
                                }
                                else
                                {
                                    return isCombatWinned(u, u_defense); 
                                }
                            }
                            else
                            {
                                return isCombatWinned(u, Map.returnSquare(row, column).ListUnitImpl[0]); 
                            }
                       
                    }
                    else {
                        System.Console.WriteLine("Pas de combat");
                        return false; }
                }
            }
            return false;
        }

        public bool isCombatWinned(Unit attack, Unit defense)
        {
            if (attack.engageCombat(attack, defense) == true)
            {
 
                if (defense.LifePoint == 0)
                {
                    System.Console.WriteLine("COMBAT GAGNE DELETE DEFENSE");
                    delete(defense);
                }
                else
                {
                    defense.LifePoint--;
                    System.Console.WriteLine("COMBAT GAGNE LIFEDEFENSE DIMINUE");
                }
                return true;
            }
            else
            {
                if (attack.LifePoint == 0)
                {
                    System.Console.WriteLine("COMBAT GAGNE DELETE ATTACK");
                    delete(attack);
                }
                else
                {
                    attack.LifePoint--;
                    System.Console.WriteLine("COMBAT PERDU LIFEATTACK DIMINUE");
                }
                return false;
            }

            
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
                    if (s is Forest)
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

                //On enlève l'unité de sa case d'avant
                previous_row = u.Row;
                previous_column = u.Column;
                Map.BoardGame[previous_row, previous_column].removeFromSquare(u);
                //System.Console.WriteLine("NB UNIT SQUARE DEPART APRES :" + Map.BoardGame[previous_row, previous_column].ListUnitImpl.Count);
                //on rajoute l'unité dans le nouveau square
                u.move(row, column);
                Map.BoardGame[row, column].addUnitInSquare(u);
                //System.Console.WriteLine("NB UNIT SQUARE ARRIVEE APRES :" + Map.BoardGame[row, column].ListUnitImpl.Count);
                
            }


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

        public bool allIsDead(Player p)
        {
            foreach (Unit u in p.PeoplePlayer.ListUnit)
            {
                if (u.LifePoint != 0) return false;
            }
            return true;
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

        bool belongToPlayer(Unit u, Player p);
        unsafe int[] squareSuggestedX(Unit u);
        unsafe int[] squareSuggestedY(Unit u);
        bool allIsDead(Player p);

         GamePlay Instance { get; set; }

    }
}
