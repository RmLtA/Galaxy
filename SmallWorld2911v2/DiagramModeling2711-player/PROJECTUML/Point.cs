using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    class PointImpl : Point
    {
        public int x
        {
            get;
            set;
        }

        public int y
        {
            get;
            set;
        }

        public PointImpl(int ab, int od)
        {
            x = ab;
            y = od;
        }
    }

    public interface Point
    {
        int x { get; set; }
        int y { get; set; }
    }
}
