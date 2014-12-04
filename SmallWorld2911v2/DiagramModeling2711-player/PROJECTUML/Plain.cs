using System;
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

        public void addInSquare(List<Unit> l)
        {
            for (int i = 0; i < l.Count; i++) // Loop through List with for
            {
                UnitImpl.Add(l[i]);
            }
        }
    }

    public interface Plain : Square
    {
    }
}
