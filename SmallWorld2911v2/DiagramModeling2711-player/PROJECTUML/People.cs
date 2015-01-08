using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    public enum PeopleType { ELF, NAIN, ORC }; 
    public abstract class PeopleImpl : People
    {
          
        public List<Unit> ListUnit
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

        public void addUnitInList(Unit u) 
        {
            throw new NotImplementedException();
        }

        public void deleteInList(Unit u)
        {
            if (u != null)
            {
                for (int i = 0; i < ListUnit.Count; i++)
                {
                    if (u.isequals(u,ListUnit[i]))
                    {
                        ListUnit.RemoveAt(i);
                    }
                }

                    
            }
        }



        public PeopleImpl()
        {
            // TODO: Complete member initialization
        }
    }

    public interface People
    {

        PROJECTUML.Unit createUnit();

        void addUnit(int nbUnit);
        List<Unit> ListUnit { get; set; }

        void addUnitInList(Unit u);
        void deleteInList(Unit u);
      
    }
}
