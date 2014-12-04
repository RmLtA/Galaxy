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
        private Square[,] MatSquare;
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
        public unsafe  MapImpl(int map,int ** tab)
        {
            /* version Demo*/
            if (map == 0)
            {
                TurnNumber = 5;
                UnitNumber = 4;
                SquareNumber = 5;

                //cette matrice est à créé dans la librairie C++

                //création de la liste des cases
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
            MatSquare = new SquareImpl[SquareNumber, SquareNumber];

            SquareFactory factoryCase = new SquareFactoryImpl();
            factoryCase.createDesert();
            for (int i = 0; i < SquareNumber; i++)
            {
                for (int j = 0; j < SquareNumber; j++)
                {
                    //générer aussi les autres types de cases --> même nombre
                    if (tab[i, j] == 0) MatSquare[i, j] = factoryCase.createDesert();
                    else
                    {
                        if (tab[i, j] == 1)
                            MatSquare[i, j] = factoryCase.createPlain();
                        else
                            MatSquare[i, j] = factoryCase.createForest();
                    }
                }
            }


        }

        public void addPlayers(List<Unit> l1, List<Unit> l2)
        {
            MatSquare[0,0].addInSquare(l1);
            MatSquare[0, 0].addInSquare(l2);
        }

      
        public int chooseNbCombat(int row, int column)
        {
            throw new System.NotImplementedException();
        }

        public bool juxtaposedSquare(Unit u, int row, int column)
        {
            throw new System.NotImplementedException();
        }

        public Unit unitBestDefense(int row, int column)
        {
            throw new System.NotImplementedException();
        }

        public void upDateMap(Unit u, int row, int column)
        {
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

        void addPlayers(List<Unit> l1, List<Unit> l2);


    }
}
