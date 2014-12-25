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
        private int _MovePoint = 300;
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

        public bool engageCombat(Unit u, Unit ue)
        {
            throw new System.NotImplementedException();
        }

        public unsafe int* getSuggestedPointsX(Map map)
        {


            if (map != null)
            {
                int* tab = map.wrapper.moveAroundX(Row);
                return tab;
            }
            return null;   
        }

        public unsafe int* getSuggestedPointsY(Map map)
        {


            if (map != null)
            {
                int* tab = map.wrapper.moveAroundY(Column);
                return tab;
            }
            return null;
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
        unsafe int* getSuggestedPointsX(Map map);
        unsafe int* getSuggestedPointsY(Map map);
        void move(int x, int y);

        int DefensePoint { get; set; }
        int LifePoint { get; set; }
        int MovePoint { get; set; }

        int AttackPoint { get; set; }

        int Column { get; set; }

        int Row { get; set; }

    }
}
