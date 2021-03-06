﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    public class ElfImpl : PeopleImpl, Elf
    {
        /**
         * \brief      Constructor of a Elf people 
         */
         public ElfImpl()
        {
            ListUnit = new List<Unit>();
        }

         /**
          * \brief   return a Elf people  
          */
        public ElfUnit createUnit()
        {
            return new ElfUnitImpl();
            throw new System.NotImplementedException();
        }

        public void addUnit(int nbUnit)
        {
            for (int i = 0; i < nbUnit; i++)
            {
                ListUnit.Add(createUnit());
            }
        }
    }

    public interface Elf : People
    {
        ElfUnit createUnit();

        void addUnit(int nbUnit);
    }
}
