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

using Wrapper;

namespace WpfApplication1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        unsafe public MainWindow()
        {
            //InitializeComponent();
            WrapperAlgo wrapper = new WrapperAlgo();
            int** t = wrapper.tabMap();
            wrapper.affiche();
            System.Console.ReadLine();


            //     GamePlay engine;
            //     Map map;
            ////  
            ////Rectangle selectedVisual;


            ///// <summary>
            ///// Construction de la fenetre (référencé dans le App.xaml)
            ///// </summary>
            //public MainWithEvents()
            //{
            //    InitializeComponent();
            //    engine = new Game.Gameplay.NewGamePlayImpl();
            //}


            ///// <summary>
            ///// Réaction à l'evt "la fenetre est construite" (référencé dans le MainWithEvents.xaml)
            ///// </summary>
            ///// <param name="sender">la fenetre </param>
            ///// <param name="e"> l'evt : la fentere est construite</param>
            //private void Window_Loaded(object sender, RoutedEventArgs e)
            //{
            //    // on initialise la Grid (mapGrid défini dans le xaml) à partir de la map du modèle (engine)
            //    map = engine._Map;
            //}
        }
    }
}
