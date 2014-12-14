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
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public DesertImpl Desert
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public PlainImpl Plain
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
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
