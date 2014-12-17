using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    public class SquareFactoryImpl : SquareFactory
    {
        public ForestImpl _Forest = new ForestImpl();
        public DesertImpl _Desert = new DesertImpl();

        public PlainImpl _Plain = new PlainImpl();
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
