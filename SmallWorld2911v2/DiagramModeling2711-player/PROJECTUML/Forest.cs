using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    public class ForestImpl : SquareImpl, Forest
    {
        public ForestImpl()
        {
            throw new System.NotImplementedException();
        }

        /*Non testé*/
        public void addInSquare(List<Unit> l)
        {
            for (int i = 0; i < l.Count; i++)
            {
                ListUnitImpl.Add(l[i]);
            }
        }

        /*Non testé*/
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

    public interface Forest : Square
    {
        void addInSquare(List<Unit> l);
        Unit returnUnitBestLife();
        Unit returnUnitBestDefense();
    }
}
