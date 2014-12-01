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
    }

    public interface Square
    {
        void addInSquare(List<Unit> l2);
    }
}
