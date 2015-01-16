using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    public interface LoadGamePlay : GamePlayBuilder
    {
        GamePlay start(MapType map, string player1, PeopleType people1, string player2, PeopleType people2);

    }
}
