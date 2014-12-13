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
using System.Windows.Navigation;



namespace WpfApplication2
{
   

    /// <summary>
    /// Logique d'interaction pour Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {   private aHexMap myMap;
        
        
        public Window2()
        {
            InitializeComponent();
            setupMap();
        }

        private void menu_new_Click(object sender, RoutedEventArgs e)
        {
            setupMap();
        }
        private void drawHexes_Click(object sender, RoutedEventArgs e)
        {
            if (myMap != null)
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
