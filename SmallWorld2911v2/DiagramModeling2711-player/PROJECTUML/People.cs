﻿using System;
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
      
    }
}