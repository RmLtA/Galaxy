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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PROJECTUML;

namespace WPFSmallWorld
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private aHexMap myMap;

        public MainWindow()
        {
            InitializeComponent();
            setupMap();

        }

        private void Loaded_Window(object sender, RoutedEventArgs e)
        {
            int size = 6;
            if (myMap != null)
                myMap.configureMap(size, size);
            myMap.drawHexes();
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
