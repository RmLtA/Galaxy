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
            percentLife_u_attack =  u_attack.LifePoint/ LifePointTotal;
            attack = u_attack.AttackPoint * percentLife_u_attack;

            percentLife_u_defense =  u_defense.LifePoint/ LifePointTotal;
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
        }

    }

    public interface ElfUnit : Unit
    {
        bool engageCombat(Unit u_attack, Unit u_defense);
    }
}
