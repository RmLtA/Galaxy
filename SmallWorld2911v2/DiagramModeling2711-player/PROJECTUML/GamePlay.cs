using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;
using System.Drawing;
using System.IO;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace PROJECTUML
{
    public class GamePlayImpl : GamePlay, ISerializable
    {
        // Singleton attribute - Private instance
        private static GamePlay instance;

        private Map _Map;
        private List<Player> _ListPlayer;
        private MapType _TypeMap;
        //private GamePlay _instance;

        public static GamePlay Instance
        {
            get
            {
                if (instance == null)
                    instance = new GamePlayImpl();

                return instance;
            }
            set
            {
                instance = value;
            }
        }

        public Map Map
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

            GamePlayImpl.instance = this;

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
        // Load a saved Game

         public void LoadGame(string saveFile)
        {
            Stream stream = File.Open(saveFile, FileMode.Open);
            BinaryFormatter bformat = new BinaryFormatter();


            // Try to deserialize the file. In case of exception, check if
            // the exception is due to a bad format file or it's unknown.
            try
            {
                bformat.Deserialize(stream);
            }
            catch (Exception e)
            {
                if (e is SerializationException || e is System.Reflection.TargetInvocationException)
                    throw new Exception();
                else
                    throw;

            }
            stream.Close();
        }
    

        /**
        * \brief   save the current gamePlay
        */
        public void registerGamePlay(string destination)
        {
            try
            {
                Stream stream = File.Open(destination, FileMode.Create);
                BinaryFormatter bformat = new BinaryFormatter();

                bformat.Serialize(stream, GamePlayImpl.instance);
                stream.Close();
            }
            catch (Exception e) { Console.WriteLine("erreur"); }
        }


        /// <summary>
        /// Serialization of a game instance 
        /// </summary>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("GamePlayers", this.ListPlayer);
            info.AddValue("GameMap", this.Map);
        }
          // Deserialization constructor.
        public GamePlayImpl(SerializationInfo info, StreamingContext ctxt)
        {
            this.ListPlayer = (List <Player>) info.GetValue("GamePlayers", typeof(List <Player>));
            this.Map = (Map) info.GetValue("GameMap", typeof(Map));
            
            // Overwrite the current game with the new one created
            GamePlayImpl.instance = this;
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
            return false;
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

                
            }


        }
    }

    public interface GamePlay
    {
        Map Map { get; set; }

        List<Player> ListPlayer { get; set; }
        MapType TypeMap { get; set; }
       
        void gotoNextPlayer();

        void stop();

        bool startCombat(Unit u, int row, int column);

        void registerGamePlay(string destination);
        void LoadGame(string saveFile);

        void moveUnitOrder(Unit u, int row, int column);
        Player whoseturn();


    }
}
