using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    public class DemoImpl : StrategyImpl, Demo
    {
        public DemoImpl()
        {
           
        }
    
        public Map execute()
        {
            return new MapImpl(MapType.DEMO);
            throw new System.NotImplementedException();
        }
    }

    public interface Demo : Strategy
    {
        Map execute();
    }
}
