using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    public class NainImpl : PeopleImpl, Nain
    {
        /**
         * \brief      Constructor of a Nain people 
         */
        public NainImpl()
        {
            ListUnit = new List<Unit>();
        }

        /**
           * \brief   return a Nain people  
           */
        public NainUnit createUnit()
        {
            return new NainUnitImpl();

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

        public void addUnitInList(Unit u)
        {
            ListUnit.Add(u);
        }
    }

    public interface Nain : People
    {
        NainUnit createUnit();
        void addUnit(int nbUnit);

        void addUnitInList(Unit u);
    }
}
