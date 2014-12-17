using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using WrapperN;

namespace PROJECTUML
{
    public enum MapType { SMALL,NORMAL,DEMO};
    public class MapImpl : Map
    {
        private int _TurnNumber;
        private int _UnitNumber;
        private int _SquareNumber;
        private Square[,] _MatSquare;

        public Square[,] MatSquare
        {
            get { return _MatSquare; }
            set { _MatSquare = value; }
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
        public unsafe  MapImpl(MapType map)
        {
            WrapperAlgo wrapper = new WrapperAlgo();
          
            /* version Demo*/
            if (map == MapType.DEMO)
            {
                TurnNumber = 5;
                UnitNumber = 4;
                SquareNumber = 5;

                //cette matrice est à créé dans la librairie C++

                //création de la liste des cases
            }

            /* version Petite*/
            if (map == MapType.SMALL)
            {
                TurnNumber = 20;
                UnitNumber = 6;
                SquareNumber = 10;

                //création de la liste des cases
            }

            /* version Normal*/
            if (map == MapType.NORMAL)
            {
                TurnNumber = 30;
                UnitNumber = 8;
                SquareNumber = 15;

                //création de la liste des cases
            }
            MatSquare = new Square[SquareNumber, SquareNumber];
            int* tab = wrapper.tabMap(SquareNumber);
            int[,] tab2 = new int[SquareNumber, SquareNumber];
            //transformer en [,]
            for (int ligne = 0; ligne < SquareNumber; ligne++)
            {
                for (int colonne = 0; colonne < SquareNumber; colonne++)
                {
                    tab2[ligne,colonne] = tab[ligne * SquareNumber + colonne];
                }
            }
            //remplissage de la map à partir de tab2
            SquareFactory factoryCase = new SquareFactoryImpl();
            factoryCase.createDesert();
            for (int i = 0; i < SquareNumber; i++)
            {
                for (int j = 0; j < SquareNumber; j++)
                {
                    //générer aussi les autres types de cases --> même nombre
                    if (tab2[i,j] == 0) MatSquare[i, j] = factoryCase.createDesert();
                    else
                    {
                        if (tab2[i,j] == 1)
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
            MatSquare[4,4].addInSquare(l2);
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
        Square[,] MatSquare
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
