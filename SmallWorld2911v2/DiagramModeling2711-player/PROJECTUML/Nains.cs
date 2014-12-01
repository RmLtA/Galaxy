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
            _ListUnit = new List<Unit>();
            _ListUnit.Add(createUnit());
        }

        /**
           * \brief   return a Nain people  
           */
        public NainUnit createUnit()
        {    
            return new NainUnitImpl();
            throw new System.NotImplementedException();
        }
    }
}
