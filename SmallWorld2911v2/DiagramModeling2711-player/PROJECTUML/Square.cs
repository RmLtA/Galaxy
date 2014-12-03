using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    public abstract class SquareImpl : Square
    { // liste unité 

        public List<Unit> ListUnitImpl
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }

    public interface Square
    {
        List<Unit> ListUnitImpl { get; set; }
        void addInSquare(List<Unit> l);

        Unit returnUnitBestLife();
        Unit returnUnitBestDefense();

        
    }
}
