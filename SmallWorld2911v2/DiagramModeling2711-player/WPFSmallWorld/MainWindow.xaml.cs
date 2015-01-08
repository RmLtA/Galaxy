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
using System.Threading.Tasks;
//using System.Windows.UIElement;
using PROJECTUML;

namespace WPFSmallWorld{

    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
 

    public partial class MainWindow : Window
    {
 
        GamePlay game;
        int rank_graphique;
        const int NONE = 777;
        int const_suggested;

        public MainWindow(GamePlay game1)
        {
            this.game = game1;
            rank_graphique = 0;
            const_suggested = 0;
            InitializeComponent();

        }
        
        private void Loaded_Window(object sender, RoutedEventArgs e)
        {
            //SquareFactory factory = new SquareFactoryImpl();
            Map map = game.Map;
            int size = map.SquareNumber;
            Square[,] mat = map.BoardGame;

            
            for (int c = 0; c < size; c++)
            {
                myGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(50, GridUnitType.Pixel) });
            }
            for (int l = 0; l < size; l++)
            {
               myGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(60, GridUnitType.Pixel) });
                for (int c = 0; c < size; c++)
                {
                    if (mat[l, c] is Desert)
                    {
                        var poly = createPolygon(l, c, 0);
                       /* if (l % 2 != 0) 
                        poly.Margin = new Thickness(-20);*/
              
                            myGrid.Children.Add(poly);
                    }
                    else
                    {
                        if (mat[l, c] is Forest)
                        {
                            var poly = createPolygon(l, c, 1);
                            /* if (l % 2 != 0)
                                 poly.Margin = new Thickness(-20);*/

                            myGrid.Children.Add(poly);


                        }
                        else
                        {
                            if (mat[l, c] is Plain)
                            {
                                var poly = createPolygon(l, c, 2);
                                /* if (l % 2 != 0)
                                     poly.Margin = new Thickness(-20);*/

                                myGrid.Children.Add(poly);

                            }
                            else if (mat[l, c] is Mountain)
                            {
                                var poly = createPolygon(l, c, 3);
                                /* if (l % 2 != 0)
                                     poly.Margin = new Thickness(-20);*/

                                myGrid.Children.Add(poly);
                            }
                        }
                            
                    }
                }
            }

            initInformations();
            //updateInfo();
            updateGraphiqueUnite(game.ListPlayer[0], 0);
            updateGraphiqueUnite(game.ListPlayer[1], 1);
           // showSuggestedSquare(game.whoseturn(), 0);

        }

        //initialiser les informations des joueurs

        public void initInformations()
        {
            if (game.ListPlayer[0].Name!=null)
            Name1.Content = game.ListPlayer[0].Name.ToString();
            if(game.ListPlayer[1].Name!=null)
            Name2.Content = game.ListPlayer[1].Name.ToString();

            switch (game.ListPlayer[0].PeopleType)
            {
                case PeopleType.ELF:
                    people1.Text = "Elf";
                    break;
                case PeopleType.ORC:
                    people1.Text = "Orc";
                    break;
                case PeopleType.NAIN:
                    people1.Text = "Nain";
                    break;
            }
            switch (game.ListPlayer[1].PeopleType)
            {
                case PeopleType.NAIN:
                    people2.Text = "Nain";
                    break;
                case PeopleType.ELF:
                    people2.Text = "Elf";
                    break;
                case PeopleType.ORC:
                    people2.Text = "Orc";
                    break;
                
            }

            foreach (Unit u in game.ListPlayer[0].PeoplePlayer.ListUnit)
            {
                InfoGrid.Children.Add(new DisplayUnit(u));
            }

            game.ListPlayer[0].Turn = true;
            game.ListPlayer[1].Turn = false;
            
        }

        public unsafe void showSuggestedSquare(PROJECTUML.Player p, int choice)
        {
            switch (choice)
            {
                case 0:
                    for (int i = 0; i < p.PeoplePlayer.ListUnit.Count; i++)
                    {
                        int[] tabX = { 0, 0, 1, -1, -1, 1 };
                        int[] tabY = { 1, -1, 0, 0, 1, 1 };
                        if ((tabX != null) && (tabY != null))
                        {
                            for (int j = 0; j < 6; j++)
                            {
                                if (game.Map.juxtaposedSquare(p.PeoplePlayer.ListUnit[i], p.PeoplePlayer.ListUnit[i].Row + tabX[j], p.PeoplePlayer.ListUnit[i].Column + tabY[j]) == true)
                                {
                                    /* System.Console.WriteLine("SUGGESTED X :" + p.PeoplePlayer.ListUnit[i].Row+tabX[j]);
                                     System.Console.WriteLine("SUGGESTED Y :" + p.PeoplePlayer.ListUnit[i].Column+tabY[j]);*/
                                    const_suggested++;
                                    myGrid.Children.Add(suggestedPolygon(tabX[j], tabY[j]));

                                }

                            }

                        }

                    }
                    break;
                case 1:
                    for (int i = 0; i < const_suggested; i++)
                    {
                        if ((i + (game.Map.SquareNumber * game.Map.SquareNumber) +
                            (game.ListPlayer[0].PeoplePlayer.ListUnit.Count + game.ListPlayer[1].PeoplePlayer.ListUnit.Count) + 1) < myGrid.Children.Count)
                        {
                            myGrid.Children.Remove(myGrid.Children[i + (game.Map.SquareNumber * game.Map.SquareNumber) +
                               (game.ListPlayer[0].PeoplePlayer.ListUnit.Count + game.ListPlayer[1].PeoplePlayer.ListUnit.Count) + 1]);
                        }
                    }
                const_suggested = 0;
                break;


            }

            

            
        }

        public void removeSuggestion()
        {
            for (int i = 0; i < const_suggested; i++)
            {
                if ((i + (game.Map.SquareNumber * game.Map.SquareNumber) +
                    (game.ListPlayer[0].PeoplePlayer.ListUnit.Count + game.ListPlayer[1].PeoplePlayer.ListUnit.Count) + 1) < myGrid.Children.Count)
                {
                    myGrid.Children.Remove(myGrid.Children[i + (game.Map.SquareNumber * game.Map.SquareNumber) +
                       (game.ListPlayer[0].PeoplePlayer.ListUnit.Count + game.ListPlayer[1].PeoplePlayer.ListUnit.Count) + 1]);
                }
            }
            //const_suggested = 0;
        }
        public void updateInfo(Unit u, int player)
        {
            refreshInfo();
            if (u != null)
            {/*
                if (player == 0)
                {
                    LifePoint11.Content = u.LifePoint.ToString();
                    Ligne11.Content = u.MovePoint.ToString();
                    Colonne11.Content = u.AttackPoint.ToString();
                }
                else
                {
                    LifePoint12.Content =u.LifePoint.ToString();
                    Ligne12.Content = u.MovePoint.ToString();
                    Colonne12.Content = u.AttackPoint.ToString();
                }*/
                
            }
        }

        public Polygon suggestedPolygon(int l, int c)
        {
            Polygon myPolygon = new Polygon();
            myPolygon.Stroke = System.Windows.Media.Brushes.Red;
            
            myPolygon.StrokeThickness = 4;
            myPolygon.HorizontalAlignment = HorizontalAlignment.Left;
            myPolygon.VerticalAlignment = VerticalAlignment.Center;
            System.Windows.Point Point1 = new System.Windows.Point(25, 0);
            System.Windows.Point Point2 = new System.Windows.Point(50, 14.43375);
            System.Windows.Point Point3 = new System.Windows.Point(50, 43.30125);
            System.Windows.Point Point4 = new System.Windows.Point(25, 57.735);
            System.Windows.Point Point5 = new System.Windows.Point(0, 43.30125);
            System.Windows.Point Point6 = new System.Windows.Point(0, 14.43375);

            PointCollection myPointCollection = new PointCollection();
            myPointCollection.Add(Point1);
            myPointCollection.Add(Point2);
            myPointCollection.Add(Point3);
            myPointCollection.Add(Point4);
            myPointCollection.Add(Point5);
            myPointCollection.Add(Point6);
            myPolygon.Points = myPointCollection;
            Grid.SetColumn(myPolygon, c);
            Grid.SetRow(myPolygon, l);

            myPolygon.MouseLeftButtonDown += new MouseButtonEventHandler(polygon_MouseLeftButtonDown);
            return myPolygon;

        }
        //créer un polygone et le placer dans la grid
        public Polygon createPolygon(int l, int c, int n)
        {


            Polygon myPolygon = new Polygon();
            myPolygon.Stroke = System.Windows.Media.Brushes.Black;
            myPolygon.Fill = System.Windows.Media.Brushes.LightSeaGreen;
            myPolygon.StrokeThickness = 2;
            myPolygon.HorizontalAlignment = HorizontalAlignment.Left;
            myPolygon.VerticalAlignment = VerticalAlignment.Center;
            System.Windows.Point Point1 = new System.Windows.Point(25, 0);
            System.Windows.Point Point2 = new System.Windows.Point(50, 14.43375);
            System.Windows.Point Point3 = new System.Windows.Point(50, 43.30125);
            System.Windows.Point Point4 = new System.Windows.Point(25, 57.735);
            System.Windows.Point Point5 = new System.Windows.Point(0, 43.30125);
            System.Windows.Point Point6 = new System.Windows.Point(0, 14.43375);

            PointCollection myPointCollection = new PointCollection();
            myPointCollection.Add(Point1);
            myPointCollection.Add(Point2);
            myPointCollection.Add(Point3);
            myPointCollection.Add(Point4);
            myPointCollection.Add(Point5);
            myPointCollection.Add(Point6);
            myPolygon.Points = myPointCollection;
            Grid.SetColumn(myPolygon, c);
            Grid.SetRow(myPolygon, l);
            switch (n)
            {
                case 0:
                    {
                        ImageBrush imageb = new ImageBrush();
                        imageb.ImageSource =
                        new BitmapImage(
                            new Uri(@"E:\4INFO\POO\GITHUB\Galaxy\SmallWorld2911v2\DiagramModeling2711-player\WPFSmallWorld\resources\desert.png", UriKind.RelativeOrAbsolute)
                            );
                        myPolygon.Fill = imageb;
                        break;
                    }
                case 1:
                    {
                        ImageBrush imagef = new ImageBrush();
                        imagef.ImageSource =
                        new BitmapImage(
                            new Uri(@"E:\4INFO\POO\GITHUB\Galaxy\SmallWorld2911v2\DiagramModeling2711-player\WPFSmallWorld\resources\foret.png", UriKind.RelativeOrAbsolute)
                            );
                        myPolygon.Fill = imagef;
                        break;
                    }
                case 2:
                    {
                        ImageBrush imagep = new ImageBrush();
                        imagep.ImageSource =
                        new BitmapImage(
                            new Uri(@"E:\4INFO\POO\GITHUB\Galaxy\SmallWorld2911v2\DiagramModeling2711-player\WPFSmallWorld\resources\plaine.png", UriKind.RelativeOrAbsolute)
                            );
                        myPolygon.Fill = imagep;
                        break;
                    }

                case 3:
                    {
                        ImageBrush imagep = new ImageBrush();
                        imagep.ImageSource =
                        new BitmapImage(
                            new Uri(@"E:\4INFO\POO\GITHUB\Galaxy\SmallWorld2911v2\DiagramModeling2711-player\WPFSmallWorld\resources\ocean.png", UriKind.RelativeOrAbsolute)
                            );
                        myPolygon.Fill = imagep;
                        break;
                    }

                default:
                    break;
            }
            myPolygon.MouseLeftButtonDown += new MouseButtonEventHandler(polygon_MouseLeftButtonDown);
            return myPolygon;
        }


        //dessiner les unites //
        private void updateGraphiqueUnite(PROJECTUML.Player p, int numJoueur)
        {
            List<Unit> listunite = p.PeoplePlayer.ListUnit;
            foreach (Unit u in listunite)
            {
                int x = u.Row;
                int y = u.Column;
                u.Rank = rank_graphique;
                rank_graphique++;
                var element = createEllipse(x,y, numJoueur);
             // if (x % 2 != 0) element.Margin = new Thickness(-30);
                myGrid.Children.Add(element);
            }

            
        }

        private int selectionUnit(int row, int column)
        {
            int i = 0;
            while (i < game.whoseturn().PeoplePlayer.ListUnit.Count)
            {
                if (game.Map.juxtaposedSquare(game.whoseturn().PeoplePlayer.ListUnit[i], row, column) == true)
                {
                    return i;
                }
                else
                {
                    i++;
                }
                
            }
            return NONE;

        }

        private int indexTurnPlayer()
        {
            if (game.whoseturn() == game.ListPlayer[0])
            {
                return 0;
            }
            else
            {
                return game.Map.UnitNumber;
            }
        }

        private bool isUnitOfPlayer(List<Unit> l)
        {
            if (l != null)
            {
                if ((l[0] is ElfUnit) && (game.whoseturn().PeopleType == PeopleType.ELF))
                {
                    return true;
                }
                if ((l[0] is NainUnit) && (game.whoseturn().PeopleType == PeopleType.NAIN))
                {
                    return true;
                }
                if ((l[0] is OrcUnit) && (game.whoseturn().PeopleType == PeopleType.ORC))
                {
                    return true;
                }
            }
            return false;
        }

        private void moveUnitUI(int row, int column, int index)
        {
            game.moveUnitOrder(game.whoseturn().PeoplePlayer.ListUnit[index], row, column);
            updateInfo(game.whoseturn().PeoplePlayer.ListUnit[index], indexTurnPlayer());
            //if (row % 2 != 0) myGrid.Children[(game.Map.SquareNumber * game.Map.SquareNumber) + 1 + index + indexTurnPlayer()].Margin = new Thickness(-30);
            Grid.SetRow(myGrid.Children[(game.Map.SquareNumber * game.Map.SquareNumber) +2 + index + indexTurnPlayer()], row);
            Grid.SetColumn(myGrid.Children[(game.Map.SquareNumber * game.Map.SquareNumber) +2 + index + indexTurnPlayer()], column);
            
        }
        private unsafe void updateUnitUI(int row, int column)
        {
           
            var index = selectionUnit(row, column);
            
            
            if (index != NONE)
            {
                if ((game.Map.returnSquare(row, column).ListUnitImpl.Count > 0) && (game.belongToPlayer(game.Map.returnSquare(row, column).ListUnitImpl[0], game.whoseturn())) == false)
                {
                    combatUI(index, row, column);
                }
                else
                {
                    moveUnitUI(row, column, index); 
                }    
           }
        }
 
        private void combatUI(int index, int row, int column)
        {
            List<Unit> l = game.Map.returnSquare(row, column).ListUnitImpl;
            bool flag = game.startCombat(game.whoseturn().PeoplePlayer.ListUnit[index], row, column);
            
            if ( flag == true)
            {
                
                //CombatInfo.Content = "COMBAT WINNED";
                //Info.Content = "LIST COUNT : " + game.Map.returnSquare(row, column).ListUnitImpl.Count;
                
                //updateInfo(unite perdant)
                for (int i = 0; i < l.Count; i++)
                {
                    if (l[i].LifePoint == 0)
                    {
                        if(indexTurnPlayer()==0)
                        myGrid.Children.Remove(myGrid.Children[(game.Map.SquareNumber * game.Map.SquareNumber) + 
                            1 + game.Map.UnitNumber+l[i].Rank]);
                        else
                            myGrid.Children.Remove(myGrid.Children[(game.Map.SquareNumber * game.Map.SquareNumber) +
                            1 + l[i].Rank]);
                    }
                }
                      

            }
            else
            {
                //le combat est perdu 
                //CombatInfo.Content = "COMBAT LOST";
                updateInfo(game.whoseturn().PeoplePlayer.ListUnit[index], indexTurnPlayer());
                if (game.whoseturn().PeoplePlayer.ListUnit[index].LifePoint == 0)
                {
                    //Info1.Content = "Remove unite player turn";
                    myGrid.Children.Remove(myGrid.Children[(game.Map.SquareNumber * game.Map.SquareNumber) + 1 + game.whoseturn().PeoplePlayer.ListUnit[index].Rank]);
                }

            }
            
        }

        private void refreshInfo()
        {
            int n1, n2;
            n1 = game.ListPlayer[0].PeoplePlayer.ListUnit.Count;
            n2 = game.ListPlayer[1].PeoplePlayer.ListUnit.Count;
            if ((n1 != 0) && (n2 != 0))
            {
                //NbUnite1.Content = game.ListPlayer[0].PeoplePlayer.ListUnit.Count.ToString();
                //NbUnite2.Content = game.ListPlayer[1].PeoplePlayer.ListUnit.Count.ToString();
            }
        }
        
        /// <summary>
        /// Délégué : réponse à l'evt click gauche sur le rectangle, affichage des informations de la tuile
        /// </summary>
        /// <param name="sender"> le rectangle (la source) </param>
        /// <param name="e"> l'evt </param>
        void polygon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var polygon = sender as Polygon;
            var tile = polygon.Tag as Square;
            

            int column = Grid.GetColumn(polygon);
            int row = Grid.GetRow(polygon);
            Name1.Content = row;
            Name2.Content = column;

            // V2 : gestion avec Binding
            // Mise à jour du rectangle selectionné => le label sera mis à jour automatiquement par Binding
            Grid.SetColumn(selectionPolygon, column);
            Grid.SetRow(selectionPolygon, row);
            selectionPolygon.Tag = tile;
            selectionPolygon.Visibility = System.Windows.Visibility.Visible;
            
            updateUnitUI(row, column);
            refreshInfo();
            //showSuggestedSquare(game.whoseturn(), 1);
            e.Handled = true;
        }
        /// <summary>
        /// Délégué : réaction général à un clic sur la fenetre 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            selectionPolygon.Tag = null;
            selectionPolygon.Visibility = System.Windows.Visibility.Collapsed;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // création d'un thread pour lancer le calcul du tour suivant sans que cela soit bloquant pour l'IHM
            Task.Factory.StartNew(() =>
            {

                this.Dispatcher.BeginInvoke(new Action(() =>
                {

                    // On "touche" au rectangle de selection pour provoquer un rafraichissemnt via le Binding
                    var selectedPol = selectionPolygon.Tag;
                    
                    selectionPolygon.Tag = null;
                    
                    selectionPolygon.Tag = selectedPol;
                    
                }));

                game.gotoNextPlayer();
                //showSuggestedSquare(game.whoseturn(),0);
            });

        }



        //create l'ellipse
        private Ellipse createEllipse(int l, int c, int numJoueur)
        {
            Ellipse ellipse = new Ellipse();
           // if (l % 2 == 0) ellipse.Margin = new Thickness(-30);
            
            Grid.SetColumn(ellipse, c);
            Grid.SetRow(ellipse, l);
            ellipse.Tag = numJoueur;
            if (numJoueur == 1)
            {
                ImageBrush imageb = new ImageBrush();
                imageb.ImageSource =
                new BitmapImage(
                    new Uri(@"E:\4INFO\POO\GITHUB\Galaxy\SmallWorld2911v2\DiagramModeling2711-player\WPFSmallWorld\resources\dwarf.png", UriKind.RelativeOrAbsolute)
                    );
                ellipse.Fill = imageb;
            }
            else
            {
                ImageBrush imageb = new ImageBrush();
                imageb.ImageSource =
                new BitmapImage(
                    new Uri(@"E:\4INFO\POO\GITHUB\Galaxy\SmallWorld2911v2\DiagramModeling2711-player\WPFSmallWorld\resources\viking.png", UriKind.RelativeOrAbsolute)
                    );
                ellipse.Fill = imageb;
            }
            ellipse.Height = 30;
            ellipse.Width = 30;
            
            return ellipse;
        }

        private void menu_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }



   
}
