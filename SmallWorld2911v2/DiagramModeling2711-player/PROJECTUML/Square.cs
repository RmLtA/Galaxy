using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    public abstract class SquareImpl : Square
    {
        private List<Unit> _ListUnitImpl = new List<Unit>(100);
        public List<Unit> ListUnitImpl
        {
            get
            {
                return _ListUnitImpl;
            }
            set
            {
                _ListUnitImpl = value;
            }
        }

        /**
         * \brief    add the units in the list of unit of a square
         */
        public void addInSquare(List<Unit> l)
        {
            if (l!=null)
            {
                for (int i = 0; i < l.Count; i++)
                {
                    ListUnitImpl.Add(l[i]);
                }
            }
        }

        /**
         * \brief    return the unit which have the best LifePoint in a square (which ave a list of units)
         * \return   Unit 
         */
        public Unit returnUnitBestLife()
        {
            int max = 0;
            for (int i = 1; i < ListUnitImpl.Count; i++)
            {
                if (ListUnitImpl[i - 1].LifePoint < ListUnitImpl[i].LifePoint)
                {
                    max = i;
                }
                else
                {
                    max = i - 1;
                }
            }
            return ListUnitImpl[max];
        }

        /**
         * \brief    return the unit which have the best DefensePoint in a square (which ave a list of units)
         * \return   Unit 
         */
        public Unit returnUnitBestDefense()
        {
            int max = 0;
            for (int i = 1; i < ListUnitImpl.Count; i++)
            {
                if (ListUnitImpl[i - 1].DefensePoint < ListUnitImpl[i].DefensePoint)
                {
                    max = i;
                }
                else
                {
                    max = i - 1;
                }
            }
            return ListUnitImpl[max];
        }
    }

    public interface Square
    {
        List<Unit> ListUnitImpl { get; set; }
        void addInSquare(List<Unit> l);

        Unit returnUnitBestLife();
        Unit returnUnitBestDefense();

        
    }
}
