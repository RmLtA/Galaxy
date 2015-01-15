using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    public class PlayerImpl : Player
    {
        private bool _Turn;
        private string _Name;
        private int _NbUnit;
        private People _PeoplePlayer;
        private PeopleType _PeopleType;
        private int _TurnLeft;

        public int TurnLeft
        {
            get;
            set;
        }
        public PeopleType PeopleType
        {
            get;
            set;
        }

        public People PeoplePlayer
        {
            get
            {
                return _PeoplePlayer;
            }
            set
            {
                _PeoplePlayer = value;
            }
        }

        public int NbUnit
        {
            get { return _NbUnit; }
            set { _NbUnit = value; }
        }
        public bool Turn
        {
            get { return _Turn; }
            set { _Turn = value; }
        }

 
        public string Name
        {
            get { return _Name; }
            set { _Name = value; } 
        }



        /**
         * \brief      Default constructor  
         */ 
        public PlayerImpl()
        {
        }

        /**
         * \brief      Constructor of a player   
         * \param    name   name of the player
         * \param    map    choice of the map
         * \param   people  choice of the people
         */
        public PlayerImpl(string name, PeopleType people, int turnLeft)
        {


            Name = name;
            Turn = false;
            TurnLeft = turnLeft;
            PeopleType = people;
            PeopleFactory fact = new PeopleFactoryImpl();
            PeoplePlayer = fact.createPeople(people);

        }

        /**
         * \brief      Add the correct number of the units tothe people of the player  
         * \param    nbUnit   number of the units
         */
        public void addUnitPlayer(int nbUnit)
        {
            PeoplePlayer.addUnit(nbUnit);
        }




    }

     
    public interface Player
    {
        int NbUnit
        {
            get;
            set;
        }
        People PeoplePlayer
        {
            get;
            set;
        }

        PeopleType PeopleType
        {
            get;
            set;
        }
        bool Turn { get; set; }

        string Name { get; set; }
        int TurnLeft { get; set; }
        void addUnitPlayer(int nbUnit);

     
    }
}
