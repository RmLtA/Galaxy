using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    public class PlainImpl : SquareImpl, Plain
    {
        public PlainImpl()
        {
            throw new System.NotImplementedException();
        }

        public void addInSquare(List<Unit> l){
            //ajout un par un sur la liste de case 
            ListUnitImpl.Add(l[0]);
        }

        /*Non testé*/
        public Unit returnUnitBestLife()
        {
            int max=0;
            for (int i = 1; i < ListUnitImpl.Count; i++)
            {
                if (ListUnitImpl[i-1].LifePoint < ListUnitImpl[i].LifePoint)
                {
                    max= i;
                }
                else
                {
                    max=i-1;
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

    public interface Plain : Square
    {
    }
}
