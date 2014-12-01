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
            throw new System.NotImplementedException();
        }
    }

    public interface Desert : Square
    {
    }
}
