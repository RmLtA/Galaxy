﻿using System;
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

        /*Non testé*/
        public void addInSquare(List<Unit> l)
        {
            for (int i = 0; i < l.Count; i++) 
            {
                ListUnitImpl.Add(l[i]);
            }
        }

        /**
         * \brief    return the unit which have the best LifePoint in a square (which ave a list of units)
         * \return   Unit 
         */
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

    public interface Plain : Square
    {
        void addInSquare(List<Unit> l);
        Unit returnUnitBestLife();
        Unit returnUnitBestDefense();
    }
}
