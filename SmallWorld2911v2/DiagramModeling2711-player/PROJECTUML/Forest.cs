using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    public class ForestImpl : SquareImpl, Forest
    {
        public ForestImpl()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface Forest : Square
    {
    }
}
