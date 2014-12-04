using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    public class ElfUnitImpl : UnitImpl, ElfUnit
    {
        public ElfUnitImpl()
        {
            MovePoint = 1;
            AttackPoint = 2;
            LifePoint = 5;
            DefensePoint = 1;
            
        }

        /*Non testé*/
        public bool engageCombat(Unit u_attack, Unit u_defense)
        {
            double purcent = 0;
            //egalité en attaque et en défense
            if (u_attack.AttackPoint == u_defense.AttackPoint)
            {
                //50% de chance de perdre une vie --> le calcul des points de vie entre en compte ???
                purcent = 50 / 100;
            }
            else
            {
                purcent = (u_attack.AttackPoint / u_defense.DefensePoint) * 0.5;
                purcent = 0.5 * purcent;
            
            }

            if (purcent > 0.5)
            {
                return true;
            }
            return false;
            throw new System.NotImplementedException();
        }
    }

    public interface ElfUnit : Unit
    {
        bool engageCombat(Unit u_attack, Unit u_defense);
    }
}
