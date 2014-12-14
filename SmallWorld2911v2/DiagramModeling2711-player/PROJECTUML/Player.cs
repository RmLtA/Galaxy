using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    public class PlayerImpl : Player
    {
        private bool _Turn;
        private int _Map;
        private string _Name;
        private int _People;
        public bool Turn
        {
            get { return _Turn; }
            set { _Turn = value; }
        }
        public int Map
        {
            get { return _Map; }
            set { _Map = value; }

        }
        public int People
        {
            get { return _People; }
            set { _People = value;  }
        }    
        public string Name
        {
            get { return _Name; }
            set { _Name = value; } 
        }

        public People PeopleImpl
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
        public PlayerImpl(string name, int map, int people)
        {
            

            Name= name;
            _Turn = false;
            _Map = map;
            _People = people;

            PeopleFactory fact = new PeopleFactoryImpl();
            PeopleImpl = fact.createPeople(people);
            
        }

        /**
         * \brief      Add the correct number of the units tothe people of the player  
         * \param    nbUnit   number of the units
         */
        public void addUnitPlayer(int nbUnit)
        {
            PeopleImpl.addUnit(nbUnit);
        }


    }

     
    public interface Player
    {
        int People { get; set; }
        int Map { get; set; }
        bool Turn { get; set; }

        People PeopleImpl { get; set; }
        string Name { get; set; }
        void addUnitPlayer(int nbUnit);

     
    }
}
