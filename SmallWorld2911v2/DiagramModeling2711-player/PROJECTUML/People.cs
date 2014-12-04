using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    public abstract class PeopleImpl : People
    {
        protected List<Unit> _ListUnit
        {
            get;
            set;
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

        PROJECTUML.Unit createUnit();

        void addUnit(int nbUnit);
        List<Unit> _ListUnit { get; set; }
      
    }
}
