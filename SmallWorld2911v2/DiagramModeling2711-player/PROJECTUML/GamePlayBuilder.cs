﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    public interface GamePlayBuilder
    {
    
        GamePlay start();

        void fillInSquare();
    }
}
