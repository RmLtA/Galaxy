using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization;

using WrapperCPP;

namespace PROJECTUML
{
    /// <summary>
    /// Enumeration of possible Unit Type, including None
    /// </summary>
    public enum UnitType { None, Elf, Orc, Nain }

    /// <summary>
    /// Move type possible in suggestions
    /// </summary>
    public enum MoveType { Impossible = 0, Possible, Suggested }
    [Serializable()]
    public abstract class UnitImpl : Unit
    {
        private int _MovePoint = 1;
        private int _LifePoint = 5;
        private int _DefensePoint = 1;
        private int _AttackPoint = 2;
        private int _Column;
        private int _Row;


        
        public int MovePoint
        {
            get { return _MovePoint; }
            set { _MovePoint = value; }
        }

        public int LifePoint
        {
            get { return _LifePoint; }
            set { _LifePoint = value; }
        }

        public int DefensePoint
        {
            get { return _DefensePoint; }
            set { _DefensePoint = value; }
        }

        public int AttackPoint
        {
            get { return _AttackPoint; }
            set { _AttackPoint = value; }
        }

        public int Column
        {
            get { return _Column; }
            set { _Column = value; }
        }

        public int Row
        {
            get { return _Row; }
            set { _Row = value; }
        }

        /**
         * \brief   return true or false switch  the calculated percent 
         * \param u_attack attacker unit
         * \param u_defense attacked unit
         * \return true : if won ; false:if lost
         */
        
        public bool engageCombat(Unit u_attack, Unit u_defense)
        {
            double percent = 0;
            int LifePointTotal = 5;
            double percentLife_u_attack = 0;
            double percentLife_u_defense = 0;
            double attack = 0;
            double defense = 0;

            //calcul les points d'attaque
            percentLife_u_attack = u_attack.LifePoint / LifePointTotal;
            attack = u_attack.AttackPoint * percentLife_u_attack;

            percentLife_u_defense = u_defense.LifePoint / LifePointTotal;
            defense = u_defense.DefensePoint * percentLife_u_defense;

            if (u_attack.LifePoint == u_defense.LifePoint)
            {
                percent = 0.5;
            }
            else
            {
                percent = (attack / defense) * 0.5;
                percent =  0.5 * percent;
            }

            if (percent >= 0.5)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /**
                 * \brief   move  a unit in the row x and colum
                 * \param x the row
                 * \param y the column
                 */

        public void move(int x, int y)
        {
            Row = x;
            Column = y;
        }
        /**
         * \brief   check if the unit is dead 
         * \return true: if the unit is dead
         */

        public bool isDead()
        {
            if (LifePoint == 0) return true;
              else
            return false;
        }
    }

    public interface Unit
    {

        bool engageCombat(Unit u_attack, Unit u_defense);

        void move(int x, int y);
        bool isDead();
        

        int DefensePoint { get; set; }
        int LifePoint { get; set; }
        int MovePoint { get; set; }

        int AttackPoint { get; set; }

        int Column { get; set; }

        int Row { get; set; }

    }
}
