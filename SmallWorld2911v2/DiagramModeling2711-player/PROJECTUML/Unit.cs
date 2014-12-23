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
        private Point _currentPosition;


        public Point CurrentPosition
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

        public bool engageCombat(Unit u, Unit ue)
        {
            throw new System.NotImplementedException();
        }

        public unsafe List<Tuple<Point, MoveType>> getSuggestedPoints()
        {
            // Get tiles suggestion
            Map map = GamePlay.Instance.Map;
            UnitType unitEnum = (UnitType)Enum.Parse(typeof(UnitType), this.GetType().Name, true);

            var raw_points = map.wrapper.suggestion(map.NativeUnits, CurrentPosition.x, CurrentPosition.y,
                                                                    this.MovePoint, (int)unitEnum);

            // Construct a list of Point
            var points = new List<Tuple<Point, MoveType>>();
            foreach (Tuple<int, int, int> pt in raw_points)
            {
                MoveType mt = (MoveType)pt.Item3;
                points.Add(new Tuple<Point, MoveType>(new Point(pt.Item1, pt.Item2), mt));
            }

            return points;
        }

        public void upDateUnit()
        {
            throw new System.NotImplementedException();
        }


    }

    public interface Unit
    {
        /*void move(int row, int column);*/

        bool engageCombat(Unit u_attack, Unit u_defense);

        int DefensePoint { get; set; }
        int LifePoint { get; set; }
        int MovePoint { get; set; }

        int AttackPoint { get; set; }

        int Column { get; set; }

        int Row { get; set; }
    }
}
