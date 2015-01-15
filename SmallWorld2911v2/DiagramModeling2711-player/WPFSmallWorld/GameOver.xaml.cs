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
    /// Logique d'interaction pour GameOver.xaml
    /// </summary>
    public partial class GameOver : Window
    {
        private GamePlay _game;
        public GameOver(GamePlay g)
        {
            _game = g;

            
            InitializeComponent();
            if (g != null)
            {
                if (_game.allIsDead(_game.ListPlayer[0]))
                {
                    text1.Text = "Winner";
                    text2.Text = "Loser";
                }
                else
                {
                    if (_game.allIsDead(_game.ListPlayer[1]))
                    {
                        text2.Text = "Winner";
                        text1.Text = "Loser";

                    }
                    else
                    {

                        text2.Text = "Loser";
                        text1.Text = "Loser";
                    }
                    
                }

            }

        }
    }
}
