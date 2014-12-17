﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    public class NormalImpl : StrategyImpl, Normal
    {
        public NormalImpl()
        {
           
        }
    
        public Map execute()
        {
            return new MapImpl(MapType.NORMAL);
            throw new System.NotImplementedException();
        }
    }

    public interface Normal : Strategy
    {
        Map execute();
    }
}