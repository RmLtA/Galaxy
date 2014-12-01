using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECTUML
{
    public abstract class UnitImpl : Unit
    {
        private int MovePoint;
        private int LifePoint;
        private int DefensePoint;
        private int AttackPoint;
        private int Column;
        private int Row;

        public bool engageCombat(Unit u, Unit ue)
        {
            throw new System.NotImplementedException();
        }

        public void move(int x, int y)
        {
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
    }
}
