﻿using System;
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

        /**
         * \brief    return a map with the strategy demo  
         */
        public Map execute()
        {
            return new MapImpl(MapType.DEMO);
        }
    }

    public interface Demo : Strategy
    {
        Map execute();
    }
}