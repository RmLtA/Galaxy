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


       /**
      * \brief   Constructeur window GameOver :
      */
        public GameOver(GamePlay g)
        {
            _game = g;

            
            InitializeComponent();
            if (g != null)
            {
                if (_game.allIsDead(_game.ListPlayer[0]) || _game.allCantMove(_game.ListPlayer[0]))
                {
                    text1.Content = "Loser";
                    text2.Content = "Winner";
                }
                else
                {
                    if (_game.allIsDead(_game.ListPlayer[1]) || _game.allCantMove(_game.ListPlayer[1]))
                    {
                        text2.Content = "Loser";
                        text1.Content = "Winner";

                    }
                    else
                    {
                        if (_game.ListPlayer[0].TurnLeft == 0)
                        {
                            text2.Content = "Loser";
                            text1.Content = "Winner";

                        }
                        else
                        {
                            text2.Content = "Winner";
                            text1.Content = "Loser";

                        }
                        
                    }
                    
                }

            }
        }
            /**
      * \brief   exit : close the window of gameover
      */
        private void menu_exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
            /**
      * \brief   returns to the Menu page and close thiw windows
      */
        private void menu_game(object sender, RoutedEventArgs e)
        {
            Menu m = new Menu();
            m.Show();
            this.Close();
        }

        
    }
}
