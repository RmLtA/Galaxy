using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    public interface GamePlayBuilder
    {

        GamePlay start(string player1, PeopleType people1, PeopleType people2, string player2, MapType map);

        void fillInSquare();
    }
}
