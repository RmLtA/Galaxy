using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    public class SquareFactoryImpl : SquareFactory
    {
        public ForestImpl _Forest;
        public DesertImpl _Desert;

        public PlainImpl _Plain;
        public Plain createPlain()
        {
            return _Plain;
        }


        public Desert createDesert()
        {
            return _Desert;
        }

        public Forest createForest()
        {
            return _Forest;
        }
    }

    public interface SquareFactory
    {
        Plain createPlain();

        Desert createDesert();

        Forest createForest();
    }
}
