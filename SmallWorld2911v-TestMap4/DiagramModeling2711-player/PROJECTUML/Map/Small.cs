using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    public class SmallImpl : StrategyImpl, Small
    {
        public SmallImpl()
        {
           
        }
    
        public Map execute()
        {
            return new MapImpl(MapType.SMALL);
            throw new System.NotImplementedException();
        }
    }

    public interface Small : Strategy
    {
        Map execute();
    }
}
