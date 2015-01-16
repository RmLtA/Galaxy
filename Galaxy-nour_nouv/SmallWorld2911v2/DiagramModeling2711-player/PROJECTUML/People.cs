using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    public enum PeopleType { ELF, NAIN, ORC }; 
    public abstract class PeopleImpl : People
    {
          
        public List<Unit> ListUnit
        {
            get;
            set;
        }

        /**
        * \brief     return a unit for each type of people   
       
        */
        public PROJECTUML.Unit createUnit()
        {
            throw new NotImplementedException() ;
        }
        /**
          * \brief   add units to the people
          * \param nbUNit umber of units
          */
       
        public void addUnit(int nbUnit)
        {
            for (int i = 0; i < nbUnit; i++)
            {
                ListUnit.Add(createUnit());
            } 
        }

        /**
         * \brief   add a unit int the list of the unit of the people
         * \param u unit to add
         */
        public void addUnitInList(Unit u) 
        {
            ListUnit.Add(u);
        }

        /**
         * \brief   delete a unit from the list of the unit of the people
         * \param u unit to delete
         */
        public void deleteInList(Unit u)
        {
            if (u != null)
            {
                ListUnit.Remove(u);      
            }
        }
     
    }

    public interface People
    {

        PROJECTUML.Unit createUnit();

        void addUnit(int nbUnit);
        List<Unit> ListUnit { get; set; }

        void addUnitInList(Unit u);
        void deleteInList(Unit u);
      
    }
}
