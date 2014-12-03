using System;
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
            set { _MovePoint = 0; }// mis par défaut pour compiler}
        }

        public int LifePoint
        {
            get { return _LifePoint; }
            set { _LifePoint = 0; }// mis par défaut pour compiler}
        }

        public int DefensePoint
        {
            get { return _DefensePoint; }
            set { _DefensePoint = 0; }// mis par défaut pour compiler}
        }

        public int AttackPoint
        {
            get { return _AttackPoint; }
            set { _AttackPoint = 0; }// mis par défaut pour compiler}
        }

        public int Column
        {
            get { return _Column; }
            set { _Column = 0; }// mis par défaut pour compiler}
        }

        public int Row
        {
            get { return _Row; }
            set { _Row = 0; }// mis par défaut pour compiler}
        }

        public bool engageCombat(Unit u, Unit ue)
        {
            throw new System.NotImplementedException();
        }

        public void move(int x, int y)
        {
            //vérifier d'abord les points nécessaires pour un déplacement

            //vérifier le type de la case --> changement du point de déplacement
            throw new System.NotImplementedException();
        }

        public void upDateUnit()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface Unit
    {//vérifie si les cases sont juxtapossé et le nombre de point de déplacemnt !=0
                                    // vérifie si la case c a bien une unité deffensive , si oui , elle appelle une fois engageCombat
                                       //sinon elle récupére le nombre de combat et repéte enagercombat tant que une des unités n'a plus de vie 

                                    // puis voir le diagramme de sequence d'un tour
        void move(int row, int column);// renouvellel la liste des unit"x d'une case .

        Boolean engageCombat(Unit u, Unit ue);

        int DefensePoint { get; set; }
        int LifePoint { get; set; }
        int MovePoint { get; set; }

        int AttackPoint { get; set; }

        int Column { get; set; }

        int Row { get; set; }
    }
}
