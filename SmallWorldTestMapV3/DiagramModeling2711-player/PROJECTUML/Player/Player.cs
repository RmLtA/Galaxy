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
        private People _peopleImpl;

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
        public PlayerImpl(string name, PeopleType people)
        {
            

            Name= name;
            Turn = false;

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
        bool Turn { get; set; }
        string Name { get; set; }
        People _PeopleImpl { get; set; }

        void addUnitPlayer(int nbUnit);

        
    }
}
