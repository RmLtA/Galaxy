using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    public abstract class SquareImpl : Square
    { // liste unité 

        public List<Unit> UnitImpl
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void addInSquare(List<Unit> l)
        {
            for (int i = 0; i < l.Count; i++) // Loop through List with for
            {
                UnitImpl.Add(l[i]);
            }
        }
    }

    public interface Square
    {
        void addInSquare(List<Unit> l2);
    }
}
