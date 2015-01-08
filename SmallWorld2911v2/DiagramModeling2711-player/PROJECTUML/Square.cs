using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    public abstract class SquareImpl : Square
    {
        private List<Unit> _ListUnitImpl = new List<Unit>();
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

        public void addUnitInSquare(Unit u)
        {
            if(u!=null)
            ListUnitImpl.Add(u);
        }
        public void removeFromSquare(Unit u)
        {
            if (u != null)
            {
                for (int i = 0; i < ListUnitImpl.Count; i++)
                {
                    if (u.isequals(u,ListUnitImpl[i]))
                    {
                        ListUnitImpl.RemoveAt(i);
                    }
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
                max = max_int(ListUnitImpl[i].LifePoint, ListUnitImpl[i - 1].LifePoint);
            }
            if (max < ListUnitImpl.Count)
            {
                if (ListUnitImpl[max] != null)
                {
                    return ListUnitImpl[max];
                }

            }
            return null;
            

            
        }

        public int max_int(int a, int b)
        {
            if (a < b)
            {
                return a;
            }
            else { return b; }
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
                if (ListUnitImpl[i].DefensePoint == ListUnitImpl[i - 1].DefensePoint)
                {
                    return null;
                }
            }

           for (int i = 1; i < ListUnitImpl.Count; i++)
           {
                    max = max_int(ListUnitImpl[i].DefensePoint, ListUnitImpl[i - 1].DefensePoint);
                }
            if (max < ListUnitImpl.Count)
            {
                if (ListUnitImpl[max] != null)
                {
                    return ListUnitImpl[max];
                }

            }
            return null;
        }
    }

    public interface Square
    {
        List<Unit> ListUnitImpl { get; set; }
        void addInSquare(List<Unit> l);

        Unit returnUnitBestLife();
        Unit returnUnitBestDefense();
        void removeFromSquare(Unit u);

        void addUnitInSquare(Unit u);
        
    }
}
