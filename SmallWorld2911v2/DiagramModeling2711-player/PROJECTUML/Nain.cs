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
            throw new System.NotImplementedException();
        }

        public void addUnit(int nbUnit)
        {
            for (int i = 0; i < nbUnit; i++)
            {
                ListUnit.Add(createUnit());
            }
        }
    }

    public interface Nain : People
    {
        NainUnit createUnit();
        void addUnit(int nbUnit);
    }
}
