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

        public People _PeopleImpl
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
        public bool Turn
        {
            get { return _Turn; }
            set { _Turn = false; }// mis par défaut pour compiler}
        }
        public int Map
        {
            get { return _Map; }
            set { _Map = 0; }// mis par défaut pour compiler}

        }
        public int People
        {
            get { return _People; }
            set { _People = 0;  }//mis par défaut pour compiler
        }    
        public string Name
        {
            get { return _Name; }
            set { _Name = "Ordi"; } //mis par défaut pour compiler }
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
            Turn = false;
            Map = map;
            People = people;

            PeopleFactory fact = new PeopleFactoryImpl();
            _PeopleImpl = fact.createPeople(people);
            
        }

        public void addUnitPlayer(int nbUnit)
        {
            _PeopleImpl.addUnit(nbUnit);
        }
        public PlayerImpl()
        {
        }
       
    }

     
    public interface Player
    {
        int People { get; set; }
        int Map { get; set; }
        bool Turn { get; set; }
        string Name { get; set; }
        People _PeopleImpl { get; set; }

        void addUnitPlayer(int nbUnit);

        
    }
}
