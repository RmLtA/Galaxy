using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    public class OrcUnitImpl : UnitImpl, OrcUnit
    {
        public OrcUnitImpl()
        {
            MovePoint = 1;
            AttackPoint = 2;
            LifePoint = 5;
            DefensePoint = 1;
            throw new System.NotImplementedException();
        }

        /**
         * \brief    calculates the percentage of chance that attacking unit wins against a defensive unit
         * \return   bool win 
         */
        public bool engageCombat(Unit u_attack, Unit u_defense)
        {
            double percent = 0;
            int LifePointTotal = 5;
            double percentLife_u_attack = 0;
            double percentLife_u_defense = 0;
            double attack = 0;
            double defense = 0;

            //re-calcul des points d'attaque
            percentLife_u_attack = (100 * u_attack.LifePoint) / LifePointTotal;
            attack = u_attack.AttackPoint * percentLife_u_attack;

            percentLife_u_defense = (100 * u_defense.LifePoint) / LifePointTotal;
            defense = u_defense.AttackPoint * percentLife_u_attack;

            //egalité en attaque et en défense
            if (attack == defense)
            {
                //deux unités égales ont 50% de chance de gagner
                percent = 50 / 100;
            }
            else
            {
                percent = (attack / defense) * 0.5;
                percent = 0.5 * percent;

            }

            if (percent > 0.5)
            {
                //l'attaquant a gagné
                return true;
            }

            //l'attaquant a perdu ou les deux adversaire sont à égalité, il n'y a pas de gagnant
            return false;
            throw new System.NotImplementedException();
        }

        /**
         * \brief    change the position of the unit
         * \param   x row
         * \param   y column
         */
        public void move(int x, int y)
        {

            if (MovePoint >= 1)
            {
                Row = x;
                Column = y;
            }
            throw new System.NotImplementedException();
        }
    }

    public interface OrcUnit : Unit
    {
        bool engageCombat(Unit u_attack, Unit u_defense);
        void move(int x, int y);
    }
}
