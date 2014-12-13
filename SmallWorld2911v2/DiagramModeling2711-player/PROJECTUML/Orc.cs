using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    public class OrcImpl : PeopleImpl, Orc
    {
        /**
         * \brief      Constructor of a Orc people 
         */
         public OrcImpl()
        {
            ListUnit = new List<Unit>();
        }

         /**
           * \brief   return a Orc people  
           */
        public OrcUnit createUnit()
        {
            return new OrcUnitImpl();
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

    public interface Orc : People
    {
        OrcUnit createUnit();
        void addUnit(int nbUnit);
    }
}
