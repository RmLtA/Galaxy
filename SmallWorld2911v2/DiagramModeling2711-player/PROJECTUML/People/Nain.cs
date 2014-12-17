using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    public interface Nain : People
    {
        void addUnit(int nbUnit);
        NainUnit createUnit();
    }
}
