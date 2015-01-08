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
        public MountainImpl _Mountain;

        public Mountain createMountain()
        {
            _Mountain = new MountainImpl();
            return _Mountain;
        }
        public Plain createPlain()
        {
            _Plain = new PlainImpl();
            return _Plain;
        }


        public Desert createDesert()
        {
            _Desert = new DesertImpl();
            return _Desert;
        }

        public Forest createForest()
        {
            _Forest = new ForestImpl();
            return _Forest;
        }


    }

    public interface SquareFactory
    {
        Plain createPlain();

        Desert createDesert();

        Forest createForest();

        Mountain createMountain();
    }
}
