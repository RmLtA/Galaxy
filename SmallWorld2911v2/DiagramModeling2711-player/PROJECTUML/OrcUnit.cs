using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    public class OrcUnitImpl : UnitImpl, OrcUnit
    {
        public OrcUnitImpl()
        {
            AttackPoint = 2;
            LifePoint = 5;
            DefensePoint = 1;
            throw new System.NotImplementedException();
        }
    }

    public interface OrcUnit : Unit
    {
    }
}
