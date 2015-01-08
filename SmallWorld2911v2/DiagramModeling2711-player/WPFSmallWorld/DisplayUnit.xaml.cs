using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PROJECTUML;

namespace WPFSmallWorld
{
    /// <summary>
    /// Logique d'interaction pour DisplayUnit.xaml
    /// </summary>
    public partial class DisplayUnit : UserControl
    {
        private Unit _unit;

        public Unit Unit
        {
            get { return this._unit; }
        }
        public DisplayUnit(Unit unit)
        {
            InitializeComponent();

            this._unit = unit;

           
            // Set Health data
            CurrentHealth.Text = unit.LifePoint.ToString();
            MaxHealth.Text = "5";

            // Set Move data
            CurrentMove.Text = unit.MovePoint.ToString();
            MaxMove.Text = "5";
        }
    }
}
