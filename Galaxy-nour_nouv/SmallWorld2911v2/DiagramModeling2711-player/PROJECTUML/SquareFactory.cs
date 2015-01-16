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
        public MountainImpl _Mountain = new MountainImpl();

        /**
         *\brief    return a mountain case
         *\return mountain case
       */
        public Mountain createMountain()
        {
            return _Mountain;
        }

        /**
        *\brief    return a plain case
        *\return  plain case
      */
        public Plain createPlain()
        {
            return _Plain;
        }

        /**
            *\brief    return a desert case
            *\return  desert case
        */
        public Desert createDesert()
        {
            return _Desert;
        }

        /**
      *\brief    return a forest case
      *\return  forest case
    */
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

        Mountain createMountain();
    }
}
