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
        private int _MovePoint;
        private int _LifePoint;
        private int _DefensePoint;
        private int _AttackPoint;
        private int _Column;
        private int _Row;
        private int _Rank;

        public int Rank
        {
            get;
            set;
        }

        
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

        public bool isequals(Unit u1, Unit u2)
        {
            return ((u1.AttackPoint == u2.AttackPoint) && (u1.Column == u2.Column) && (u1.Row == u2.Row) && (u1.Rank == u2.Rank) && (u1.MovePoint == u2.MovePoint) && (u1.LifePoint == u2.LifePoint));
        }
        public bool engageCombat(Unit u_attack, Unit u_defense)
        {
            double percent = 0;
            int LifePointTotal = 5;
            double percentLife_u_attack = 0;
            double percentLife_u_defense = 0;
            double attack = 0;
            double defense = 0;

            //re-calcul des points d'attaque
            percentLife_u_attack = u_attack.LifePoint / LifePointTotal;
            attack = u_attack.AttackPoint * percentLife_u_attack;

            percentLife_u_defense = u_defense.LifePoint / LifePointTotal;
            defense = u_defense.AttackPoint * percentLife_u_attack;

            //egalité en attaque et en défense
            if (u_attack.LifePoint == u_defense.LifePoint)
            {
                //deux unités égales ont 50% de chance de gagner
                percent = 0.5;
                //System.Console.WriteLine("PERCENT COMBAT EGALITE " + percent);
            }
            else
            {
                percent = (attack / defense) * 0.5;
                percent =  0.5 * percent;
                //System.Console.WriteLine("PERCENT COMBAT " + percent);

            }

            if (percent >= 0.5)
            {
                System.Console.WriteLine("COMBAT GAGNE ");
                //l'attaquant a gagné
                return true;
            }
            else
            {
                System.Console.WriteLine("COMBAT PERDU ");
                //l'attaquant a perdu ou les deux adversaire sont à égalité, il n'y a pas de gagnant
                return false;
            }

            
            
        }


        public void upDateUnit()
        {
            throw new System.NotImplementedException();
        }

        public void move(int x, int y)
        {
            Row = x;
            Column = y;
        }




    }

    public interface Unit
    {
        /*void move(int row, int column);*/

        bool engageCombat(Unit u_attack, Unit u_defense);

        void move(int x, int y);
        bool isequals(Unit u1, Unit u2);

        int DefensePoint { get; set; }
        int LifePoint { get; set; }
        int MovePoint { get; set; }

        int AttackPoint { get; set; }
        int Rank { get; set; }

        int Column { get; set; }

        int Row { get; set; }

    }
}
