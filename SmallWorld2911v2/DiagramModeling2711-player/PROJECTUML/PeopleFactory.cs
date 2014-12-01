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
        public People createPeople(int people)
        {
            switch (people)
            {
                case 0:
                    return new ElfImpl();
                case 1:
                    return new OrcImpl();
                case 2:
                    return new NainImpl();
            }
            throw new System.NotImplementedException();
        }
    }

    public interface PeopleFactory
    {
        People createPeople(int people);
    }
}
