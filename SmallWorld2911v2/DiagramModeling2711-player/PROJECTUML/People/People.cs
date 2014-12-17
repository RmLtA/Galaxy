using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    public enum PeopleType { ELF,NAIN,ORC };
    public abstract class PeopleImpl : People
    {
        List<Unit> _ListUnit;
        public List<Unit> ListUnit
        {
            get
            {
                return _ListUnit;
            }
            set
            {
                _ListUnit = value;
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
