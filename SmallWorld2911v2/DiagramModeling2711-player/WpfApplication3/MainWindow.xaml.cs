using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PROJECTUML;

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private aHexMap myMap;
        GamePlay game;
        public MainWindow(GamePlay game)
        {
            this.game=game;  
            InitializeComponent();
            setupMap();
        }

        private  void Loaded_Window(object sender, RoutedEventArgs e)
        {
            Map map = game.MapGame;
            int size = map.SquareNumber;
            if (myMap != null)
                myMap.configureMap(size, size);
                myMap.drawHexes();
                refreshMap();
        }

        public void refreshMap()
        {
            int n1, n2;
            n1 = game.ListPlayer[0].NbUnit;
            n2 = game.ListPlayer[1].NbUnit;
            if ((n1 != 0) && (n2 != 0))
            {
                NbUnite1.Content = game.ListPlayer[0].NbUnit.ToString();
                NbUnite2.Content = game.ListPlayer[1].NbUnit.ToString();
            }
            
        }
        private void menu_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void setupMap()
        {
            myMap = new aHexMap(mapText, mapScroller);
            mapCanvas.Children.Add(myMap);
        }
    }
}
