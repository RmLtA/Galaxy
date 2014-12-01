using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    public class NormalImpl : StrategyImpl, Normal
    {
        public NormalImpl()
        {
            throw new System.NotImplementedException();
        }
    
        public Map execute()
        {
            return new MapImpl(2);
            throw new System.NotImplementedException();
        }
    }

    public interface Normal : Strategy
    {
        Map execute();
    }
}
