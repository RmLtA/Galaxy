using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    public class NainUnitImpl : UnitImpl, NainUnit
    {
        public NainUnitImpl()
        {

        }
    }

    public interface NainUnit : Unit, IUnit
    {
        
    }
}
