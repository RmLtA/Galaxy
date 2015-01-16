using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    public class MountainImpl : SquareImpl, Mountain
    {
        public MountainImpl()
        {

        }
    }

    public interface Mountain : Square
    {
    }
}
