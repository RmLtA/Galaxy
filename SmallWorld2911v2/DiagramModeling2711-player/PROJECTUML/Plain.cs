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

        public void addInSquare(List<Unit> l){
            //ajout un par un sur la liste de case 
            UnitImpl.Add(l[0]);
        }
    }

    public interface Plain : Square
    {
    }
}
