using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    public class SquareFactoryImpl : SquareFactory
    {
        public ForestImpl Forest
        {
            get
            {
                return Forest;
            }
            set
            {
                Forest = value;
            }
        }

        public DesertImpl Desert
        {
            get
            {
                return Desert;
            }
            set
            {
                Desert = value;
            }
        }

        public PlainImpl Plain
        {
            get
            {
                return Plain;
            }
            set
            {
                Plain = value;
            }
        }

        public Plain createPlain()
        {
            return Plain;
        }


        public Desert createDesert()
        {
            return Desert;
        }

        public Forest createForest()
        {
            return Forest;
        }
    }

    public interface SquareFactory
    {
        Plain createPlain();

        Desert createDesert();

        Forest createForest();
    }
}
