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
         * \param l list to add to the list of units of the square
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
        *\brief    add a unit in the list of units of the square
        *\param  u unit to add
         */
        public void addUnitInSquare(Unit u)
        {
            if(u!=null)
            ListUnitImpl.Add(u);
        }
        /**
       *\brief    remove a unit from the list of units of the square
       *\param  u unit to remove
        */
        public void removeFromSquare(Unit u)
        {
            if (u != null)
            {
                ListUnitImpl.Remove(u);
            }
        }

        /**
         * \brief    return the unit which have the best LifePoint in a square (which ave a list of units)
         * \return   Unit 
         */
        public Unit returnUnitBestLife()
        {
            if (ListUnitImpl != null)
            {
                int max = ListUnitImpl[0].LifePoint;
                int index = 0;
                for (int i = 1; i < ListUnitImpl.Count; i++)
                {
                    if (ListUnitImpl[i].LifePoint > max)
                        max = ListUnitImpl[i].LifePoint;
                        index = i;

                }
                return ListUnitImpl[index];
            }

            return null;

        }

        /**
         * \brief    return the unit which have the best DefensePoint in a square (which ave a list of units)
         * \return   Unit 
         */
        public Unit returnUnitBestDefense()
        {
            if (ListUnitImpl != null)
            {
                foreach(Unit u in ListUnitImpl){
                    if (u.DefensePoint != 1)
                    {
                        int max = ListUnitImpl[0].DefensePoint;
                        int index = 0;
                        for (int i = 1; i < ListUnitImpl.Count; i++)
                        {
                            if (ListUnitImpl[i].LifePoint > max)
                                max = ListUnitImpl[i].DefensePoint;
                            index = i;
                        }
                        return ListUnitImpl[index];
                    }
                    else
                    {
                        return null;
                    }

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
