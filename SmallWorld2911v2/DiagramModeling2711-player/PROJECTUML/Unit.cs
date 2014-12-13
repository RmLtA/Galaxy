﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    public abstract class UnitImpl : Unit
    {
        private int _MovePoint;
        private int _LifePoint;
        private int _DefensePoint;
        private int _AttackPoint;
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

        public void move(int x, int y)
        {
            //vérifier d'abord les points nécessaires pour un déplacement

            //vérifier le type de la case --> changement du point de déplacement

            // une case rapporte un point par défaut

            //selon le type de l'unité le coût du déplacement change
            throw new System.NotImplementedException();
        }

        public void upDateUnit()
        {
            throw new System.NotImplementedException();
        }


    }

    public interface Unit
    {
        void move(int row, int column);// renouvelle la liste des unit d'une case .

        bool engageCombat(Unit u_attack, Unit u_defense);

        int DefensePoint { get; set; }
        int LifePoint { get; set; }
        int MovePoint { get; set; }

        int AttackPoint { get; set; }

        int Column { get; set; }

        int Row { get; set; }
    }
}
