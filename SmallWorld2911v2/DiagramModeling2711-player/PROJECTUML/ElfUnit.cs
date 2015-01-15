using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    public class ElfUnitImpl : UnitImpl, ElfUnit
    {
        public ElfUnitImpl()
        {
            MovePoint = 20;
            AttackPoint = 2;
            LifePoint = 5;
            DefensePoint = 1;
            
        }

 




    }

    

    public interface ElfUnit : Unit
    {
        

    }
}
