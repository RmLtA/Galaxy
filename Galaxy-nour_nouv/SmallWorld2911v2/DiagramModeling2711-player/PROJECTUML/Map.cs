﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using WrapperCPP;

namespace PROJECTUML
{
    public enum MapType { SMALL = 0, NORMAL = 1, DEMO = 2 };
    public class MapImpl : Map
    {
        private int _TurnNumber=0;
        private int _UnitNumber=0;
        private int _SquareNumber=0;
        private Square[,] _BoardGame;
        private Wrapper _wrapper;


        public Wrapper wrapper
        {
            get
            {
                return _wrapper;
            }
            set { _wrapper = value; }
        }
        
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


        /**
         * \brief    Constructor of the Map
         * \param   map type of the map
         */
        public unsafe MapImpl(MapType map)
        {
            wrapper = new Wrapper();
            
            switch (map)
            {
                /* version Demo*/
                case MapType.DEMO:
                    TurnNumber = 5;
                    UnitNumber = 4;
                    SquareNumber = 5;
                    break;


                /* version Petite*/
                case MapType.SMALL:
                    TurnNumber = 20;
                    UnitNumber = 6;
                    SquareNumber = 10;
                    break;

                /* version Normal*/
                case MapType.NORMAL:
                    TurnNumber = 30;
                    UnitNumber = 8;
                    SquareNumber = 15;
                    break;
            }


            BoardGame = new SquareImpl[SquareNumber, SquareNumber];
            int* tab = wrapper.fillMap(SquareNumber);

            int[,] tab2 = new int[SquareNumber, SquareNumber];

            for (int ligne = 0; ligne < SquareNumber; ligne++)
            {
                for (int colonne = 0; colonne < SquareNumber; colonne++)
                {
                    tab2[ligne, colonne] = tab[ligne * SquareNumber + colonne];
                }
            }

            SquareFactory factory = new SquareFactoryImpl();
            for (int i = 0; i < SquareNumber; i++)
            {
                for (int j = 0; j < SquareNumber; j++)
                {
                    int square = tab2[i,j];
                    switch (square)
                    {
                        case 0:
                            BoardGame[i, j] = factory.createDesert();
                            break;

                        case 1:
                            BoardGame[i, j] = factory.createPlain();
                            break;

                        case 2:
                            BoardGame[i, j] = factory.createForest();
                            break;

                        case 3:
                            BoardGame[i, j] = factory.createMountain();
                            break;

                    }
                }
            }


        }

        /**
         * \brief    place the list of units on the board game 
         * \param   l1 the people's units of the player 1
         * \param   l2 the people's units of the player 2
         */
        public void placeUnits(List<Unit> l1, List<Unit> l2)
        {
            BoardGame[0,0].addInSquare(l1);
            BoardGame[SquareNumber-1,SquareNumber-1].addInSquare(l2);

            for (int i = 0; i < l1.Count; i++)
            {
                l1[i].Column = 0;
                l1[i].Row = 0;
            }

            for (int i = 0; i < l2.Count; i++)
            {
                l2[i].Column = SquareNumber - 1;
                l2[i].Row = SquareNumber - 1;
            }
        }


        /**
         * \brief    return the number of Combats in function of the square attacked 
         * \return   int number of combat 
         */
        public int chooseNbCombat(int row, int column)
        {
            Square s = BoardGame[row, column];
            int result = 0;
           
            Random random = new Random();
            if (s.ListUnitImpl != null) { 
                
                    result= 3+random.Next(s.returnUnitBestLife().LifePoint-3);
                    return result+2;  
            }
            else
            {
                return 1;
            }
        }

        /**
        * \brief    return true if the square of the unit u is juxtaposed to the square[row,column]
        * \return   bool juxtaposed 
        */
        public bool juxtaposedSquareCombat(Unit u, int row, int column)
        {
            if ((row < SquareNumber) && (column < SquareNumber) && (row >= 0) && (column >= 0))
            {
                Square s = returnSquare(row, column);
                if (s != null)
                {
                    if (((u.Row == row) && (u.Column == column + 1)) || ((u.Row == row) && (u.Column == column - 1)))
                    {
                        return true;
                    }
                    return false;

                }
            }
            return false;
        }
        
        /**
         * \brief    return true if the square of the unit u is juxtaposed to the square[row,column]
         * \return   bool juxtaposed 
         */
        public bool juxtaposedSquare(Unit u, int row, int column)
        {
            if ((row < SquareNumber) && (column < SquareNumber) && (row >=0) && (column>=0))
            {
                Square s = returnSquare(row, column);
                if (s != null)
                {
                    if (((u.Row == row) && (u.Column == column - 1)) || ((u.Row == row) && (u.Column == column + 1)))
                    {
                        return true;
                    }
                    if (u.Row % 2 != 0)
                    {

                        if (((u.Column == column) && (u.Row == row - 1)) || ((u.Column == column -1) && (u.Row  == row +1)))
                        {
                            return true;
                        }
                        if (((u.Column == column - 1) && (u.Row == row - 1)) || ((u.Column == column) && (u.Row == row + 1)))
                        {
                            return true;
                        }

                    }
                    if (u.Row % 2 == 0)
                    {
                        if (((u.Column == column) && (u.Row == row - 1)) || ((u.Column == column+1) && (u.Row  == row+1)))
                        {
                            return true;
                        }
                        if (((u.Column  == column +1) && (u.Row == row - 1)) || ((u.Column == column) && (u.Row == row + 1)))
                        {
                            return true;
                        }

                    }
                }
            }
            return false;
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
            if ((row < SquareNumber) && (column < SquareNumber) && (row >= 0) && (column >= 0))
                return BoardGame[row, column];
            else return null;
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

        Square[,] BoardGame
        {
            get;
            set;
        }
        Wrapper wrapper { get; set; }


        int chooseNbCombat(int row, int column);

        bool juxtaposedSquare(Unit u, int row, int column);
        bool juxtaposedSquareCombat(Unit u, int row, int column);

        Unit unitBestDefense(int row, int column);
        void placeUnits(List<Unit> l1, List<Unit> l2);

        Square returnSquare(int row, int column);

        

    }
}