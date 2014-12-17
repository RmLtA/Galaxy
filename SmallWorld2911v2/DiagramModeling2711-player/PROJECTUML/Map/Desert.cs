using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    public class DesertImpl : SquareImpl, Desert
    {
        public DesertImpl()
        {
           
        }
        public void addInSquare(List<Unit> l)
        {
            for (int i = 0; i < l.Count; i++) // Loop through List with for
            {
                UnitListSquare.Add(l[i]);
            }
        }

    }

    public interface Desert : Square
    {
    
    }
}
