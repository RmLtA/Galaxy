using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace PROJECTUML
{
    public class MapImpl : Map
    {
        private int _TurnNumber;
        private int _UnitNumber;
        private int _SquareNumber;
        private Square[,] _BoardGame;
        public int TurnNumber
        {
            get { return _TurnNumber; }
            set { _TurnNumber = value; }
        }
        public int UnitNumber
        {
            get { return _UnitNumber; }
            set { _UnitNumber = value; }
        }
        public int SquareNumber
        {
            get { return _SquareNumber; }
            set { _SquareNumber = value; }
        }

        public Square[,] BoardGame
        {
            get { return _BoardGame; }
            set { _BoardGame = value; }
        }
        public MapImpl(int map)
        {
            /* version Demo*/
            if (map == 0)
            {
                TurnNumber = 5;
                UnitNumber = 4;
                SquareNumber = 5;

                //cette matrice est à créé dans la librairie C++
                BoardGame=new SquareImpl[SquareNumber,SquareNumber];

                SquareFactory factory = new SquareFactoryImpl();
                factory.createDesert();
                for (int i = 0; i < SquareNumber; i++)
                {
                    for (int j = 0; j < SquareNumber; j++)
                    {
                        //générer aussi les autres types de cases --> même nombre 
                        BoardGame[i, j] = factory.createDesert();
                    
                    }
                }

            }

            /* version Petite*/
            if (map == 1)
            {
                TurnNumber = 20;
                UnitNumber = 6;
                SquareNumber = 10;

                //création de la liste des cases
            }

            /* version Normal*/
            if (map == 2)
            {
                TurnNumber = 30;
                UnitNumber = 8;
                SquareNumber = 15;

                //création de la liste des cases
            }

        }

        /**
         * \brief    place the ilst of units on the board game 
         */
        public void placeUnits(List<Unit> l1, List<Unit> l2)
        {
            //position : mettre les peuples bien loin les uns des autres
            BoardGame[0,0].addInSquare(l1);
            BoardGame[5,5].addInSquare(l2);
        }

        public SquareFactoryImpl SquareFactory
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
         * \brief    return the number of Combats in function of the square attacked 
         * \return   int number of combat 
         */
        public int chooseNbCombat(int row, int column)
        {
            Square s = BoardGame[row, column];
            Unit u = s.returnUnitBestLife();

            Random random = new Random();
            int result = random.Next(3, u.LifePoint+2);

            return result;
            throw new System.NotImplementedException();
        }

        /**
         * \brief    return true if the square of the unit u is juxtaposed to the square[row,column]
         * \return   bool juxtaposed 
         */
        public bool juxtaposedSquare(Unit u, int row, int column)
        {
            // les cases sont juxtaposées si elles sont sur la même ligne mais à i et i+1eme colonne
            if (u.Row == row)
            {
                if ((column == u.Column+1) || (column == u.Column-1))
                {
                    return true;
                }
            }
            return false;
            throw new System.NotImplementedException();
        }

        /**
         * \brief    return the unit which have the best DefensePoint in a square of the BoardGame[row,column]
         * \return   Unit 
         */
        public Unit unitBestDefense(int row, int column)
        {
            Square s = BoardGame[row, column];
            return s.returnUnitBestDefense();

            throw new System.NotImplementedException();
        }

        /**
         * \brief    return the square[row,column]
         * \return   Square
         */
        public Square returnSquare(int row, int column)
        {
            return BoardGame[row, column];
        }

        public void upDateMap(Unit u, int row, int column)
        {
            // appel de la fonction move(x,y) de Unit
            throw new System.NotImplementedException();
        }
    }

    public interface Map
    {

        int TurnNumber
        {
            get;
            set;
        }
        int UnitNumber
        {
            get;
            set;
        }
        int SquareNumber
        {
            get;
            set;
        }
        int chooseNbCombat(int row, int column);

        bool juxtaposedSquare(Unit u, int row, int column);

        Unit unitBestDefense(int row, int column);

        void upDateMap(Unit u, int row, int column);
        void placeUnits(List<Unit> l1, List<Unit> l2);

        Square returnSquare(int row, int column);

    }
}
