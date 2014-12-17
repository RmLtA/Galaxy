using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    public abstract class SquareImpl : Square
    { // liste unité 
        List<Unit> _UnitListSquare;
        public List<Unit> UnitListSquare
        {
            get
            {
                return _UnitListSquare;   
            }
            set
            {
                _UnitListSquare = value;
            }
        }

        public void addInSquare(List<Unit> l)
        {
            for (int i = 0; i < l.Count; i++) // Loop through List with for
            {
                UnitListSquare.Add(l[i]);
            }
        }
    }

    public interface Square
    {
        void addInSquare(List<Unit> l2);
    }
}
