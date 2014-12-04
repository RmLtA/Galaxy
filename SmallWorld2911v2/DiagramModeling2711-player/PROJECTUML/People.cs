using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    public abstract class PeopleImpl : People
    {
        public List<Unit> ListUnit
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public PROJECTUML.Unit createUnit()
        {
            throw new NotImplementedException();
        }

        public void addUnit(int nbUnit)
        {
            throw new NotImplementedException();
        }
    }

    public interface People
    {
        List<Unit> ListUnit { get; set; }
        PROJECTUML.Unit createUnit();

        void addUnit(int nbUnit);



       
    }
}
