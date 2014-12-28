using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    public class PeopleFactoryImpl : PeopleFactory
    {
       
        /**
         * \brief   return a People
         * \param people People choosed
         * \return Elf, Orc or Nain people
         */
        public People createPeople(PeopleType people)
        {
            switch (people)
            {
                case PeopleType.ELF:
                    return new ElfImpl();
                case PeopleType.ORC:
                    return new OrcImpl();
                case PeopleType.NAIN:
                    return new NainImpl();
            }
            throw new System.NotImplementedException();
        }
    }

    public interface PeopleFactory
    {

        People createPeople(PeopleType people);
    }
}
