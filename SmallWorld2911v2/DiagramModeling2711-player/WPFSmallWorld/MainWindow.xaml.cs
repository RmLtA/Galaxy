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
        const int NONE = 777;
        Dictionary<Point, Polygon> _squareOfUnits;
        bool flag = false;
        Polygon selection;
        Dictionary<Border, Unit> UnitsSelected;
        List<Polygon> suggestions_square;

        public MainWindow(GamePlay game1)
        {
            this.game = game1;
            
            _squareOfUnits = new Dictionary<Point, Polygon>();

            UnitsSelected = new Dictionary<Border, Unit>();

            //On crée le collecteur des rectangles de suggestion de destination
            suggestions_square = new List<Polygon>();

            //On crée le rectangle de sélection, auquel on associe un brush rouge d'épaisseur 1
            selection = new Polygon();
            selection.Stroke = Brushes.Red;
            selection.StrokeThickness = 2;

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
            selection.Points = myPointCollection;
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
                       if (l % 2 != 0)
                           poly.Margin = new Thickness(poly.Margin.Left - 25, poly.Margin.Top - (30 * l), poly.Margin.Right, poly.Margin.Bottom); 
                       else
                           poly.Margin = new Thickness(poly.Margin.Left, poly.Margin.Top - (30 * l), poly.Margin.Right, poly.Margin.Bottom);

                            myGrid.Children.Add(poly);
                    }
                    else
                    {
                        if (mat[l, c] is Forest)
                        {
                            var poly = createPolygon(l, c, 1);
                            if (l % 2 != 0)
                                poly.Margin = new Thickness(poly.Margin.Left - 25, poly.Margin.Top - (30 * l), poly.Margin.Right, poly.Margin.Bottom);
                            else
                                poly.Margin = new Thickness(poly.Margin.Left, poly.Margin.Top - (30 * l), poly.Margin.Right, poly.Margin.Bottom);

                            myGrid.Children.Add(poly);


                        }
                        else
                        {
                            if (mat[l, c] is Plain)
                            {
                                var poly = createPolygon(l, c, 2);
                                if (l % 2 != 0)
                                    poly.Margin = new Thickness(poly.Margin.Left - 25, poly.Margin.Top - (30 * l), poly.Margin.Right, poly.Margin.Bottom);
                                else
                                    poly.Margin = new Thickness(poly.Margin.Left, poly.Margin.Top - (30 * l), poly.Margin.Right, poly.Margin.Bottom);

                                myGrid.Children.Add(poly);

                            }
                            else if (mat[l, c] is Mountain)
                            {
                                var poly = createPolygon(l, c, 3);
                                if (l % 2 != 0)
                                    poly.Margin = new Thickness(poly.Margin.Left - 25, poly.Margin.Top - (30 * l), poly.Margin.Right, poly.Margin.Bottom);
                                else
                                    poly.Margin = new Thickness(poly.Margin.Left, poly.Margin.Top - (30 * l), poly.Margin.Right, poly.Margin.Bottom);

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
           
            //showSuggestedSquare(game.whoseturn());

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

            Turn_left1.Content = game.ListPlayer[0].TurnLeft.ToString();
            Turn_left2.Content = game.ListPlayer[1].TurnLeft.ToString();

            displayUnitOnMap(game.ListPlayer[0], 0);
            displayUnitOnMap(game.ListPlayer[1], 1);

            game.ListPlayer[0].Turn = true;
            game.ListPlayer[1].Turn = false;
            Message.Text = "It's the turn of the player 1" ;
            
        }

        private void displayUnitOnMap(PROJECTUML.Player p, int choice)
        {
            int c = 0; int l = 0;
            foreach (Unit u in p.PeoplePlayer.ListUnit)
            {
                var element = new DisplayUnit(u);
                switch (choice)
                {
                    case 0:
                         UnitGrid1.Children.Add(element);
                        break;
                    case 1:
                        UnitGrid2.Children.Add(element);
                        break;
                }
                Grid.SetColumn(element, c % 2);
                Grid.SetRow(element, l % 4);
                l++;
                if (l == 4)
                {
                    c++;
                }
                
                
            }
            
        }

        public void deleteSuggestedSquare()
        {
            foreach (Polygon rect in suggestions_square)
            {
                myGrid.Children.Remove(rect);
            }
        }

        public unsafe void showSuggestedSquare(PROJECTUML.Player p)
        {
            /*if (suggestions_square.Count != 0)
            {
                deleteSuggestedSquare();
            }*/
            for (int i = 0; i < p.PeoplePlayer.ListUnit.Count; i++)
            {
                int[] tabX = { 0, 0, 1, -1, -1, 1 };
                int[] tabY = { 1, -1, 0, 0, 1, 1 };
                if ((tabX != null) && (tabY != null))
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (game.Map.juxtaposedSquare(p.PeoplePlayer.ListUnit[i], p.PeoplePlayer.ListUnit[i].Row + tabX[j], p.PeoplePlayer.ListUnit[i].Column + tabY[j]) == true)
                        {
                            var rect = new Polygon();
                            rect.StrokeThickness = 4;
                            rect.Stroke = Brushes.Green;
                            rect.HorizontalAlignment = HorizontalAlignment.Left;
                            rect.VerticalAlignment = VerticalAlignment.Center;

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
                            rect.Points = myPointCollection;

                            int row = p.PeoplePlayer.ListUnit[i].Row + tabX[j];
                            Grid.SetRow(rect, p.PeoplePlayer.ListUnit[i].Row + tabX[j]);
                            Grid.SetColumn(rect, p.PeoplePlayer.ListUnit[i].Column + tabY[j]);

                            if (row % 2 != 0)
                                rect.Margin = new Thickness(rect.Margin.Left - 25, rect.Margin.Top - (30 * row), rect.Margin.Right, rect.Margin.Bottom);
                            else
                                rect.Margin = new Thickness(rect.Margin.Left, rect.Margin.Top - (30 * row), rect.Margin.Right, rect.Margin.Bottom);
                            
                            
                            myGrid.Children.Add(rect);
                            suggestions_square.Add(rect);

                        }

                    }

                }
            }
        }



        //créer un polygone et le placer dans la grid
        public Polygon createPolygon(int l, int c, int n)
        {


            Polygon myPolygon = new Polygon();
            myPolygon.Stroke = System.Windows.Media.Brushes.Black;
            myPolygon.Fill = System.Windows.Media.Brushes.LightSeaGreen;
            myPolygon.StrokeThickness = 0.5;
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


        private void update()
        {
            
            
           foreach (Polygon rect in _squareOfUnits.Values)
            {

                myGrid.Children.Remove(rect);
            }

            _squareOfUnits.Clear();
            UnitGrid1.Children.Clear();
            UnitGrid2.Children.Clear();

            updateGraphiqueUnite(game.ListPlayer[0], 0);
            updateGraphiqueUnite(game.ListPlayer[1], 1);
            displayUnitOnMap(game.ListPlayer[0], 0);
            displayUnitOnMap(game.ListPlayer[1], 1);
        }
        private void updateGraphiqueUnite(PROJECTUML.Player p, int numJoueur)
        {
            
            Dictionary<Point, List<Unit>> unites = new Dictionary<Point, List<Unit>>();
            
            List<Unit> toRemove = new List<Unit>();

            //Pour chaque unité
            foreach (Unit u in p.PeoplePlayer.ListUnit)
            {
                
                if (u.LifePoint >0)
                {
                    
                    Point point = new Point(u.Row, u.Column);

                    
                    if (!unites.ContainsKey(point))
                    {
                        
                        unites.Add(point, new List<Unit>());
                    }
                    //Dans tous les cas on ajoute l'unités dans la liste d'unités associée au point considéré 
                    unites[point].Add(u);
                }
                //Sinon
                else
                {
                    //On l'ajoute à un dictionnaire temporaire chargé de supprimer les unités
                    toRemove.Add(u);
                }
            }


            //Pour chaque point dans le dictionnaire unites
            foreach (Point point in unites.Keys)
            {
                var rectangle = new Polygon();
                rectangle.HorizontalAlignment = HorizontalAlignment.Left;
                rectangle.VerticalAlignment = VerticalAlignment.Center;
                
                //à agrandir
                System.Windows.Point Point1 = new System.Windows.Point(8.3333*2, 0);
                System.Windows.Point Point2 = new System.Windows.Point(16.67*2, 4.91125*2);
                System.Windows.Point Point3 = new System.Windows.Point(16.67*2, 14.43375*2);
                System.Windows.Point Point4 = new System.Windows.Point(8.333*2, 19.245*2);
                System.Windows.Point Point5 = new System.Windows.Point(0, 14.43375*2);
                System.Windows.Point Point6 = new System.Windows.Point(0, 4.91125*2);

                PointCollection myPointCollection = new PointCollection();
                myPointCollection.Add(Point1);
                myPointCollection.Add(Point2);
                myPointCollection.Add(Point3);
                myPointCollection.Add(Point4);
                myPointCollection.Add(Point5);
                myPointCollection.Add(Point6);
                rectangle.Points = myPointCollection;
                
                if (numJoueur == 1)
                {
                    ImageBrush imageb = new ImageBrush();
                    imageb.ImageSource =
                    new BitmapImage(
                        new Uri(@"E:\4INFO\POO\GITHUB\Galaxy\SmallWorld2911v2\DiagramModeling2711-player\WPFSmallWorld\resources\dwarf.png", UriKind.RelativeOrAbsolute)
                        );
                    
                    rectangle.Fill = imageb;
                }
                else
                {
                    ImageBrush imageb = new ImageBrush();
                    imageb.ImageSource =
                    new BitmapImage(
                        new Uri(@"E:\4INFO\POO\GITHUB\Galaxy\SmallWorld2911v2\DiagramModeling2711-player\WPFSmallWorld\resources\viking.png", UriKind.RelativeOrAbsolute)
                        );
                    
                    rectangle.Fill = imageb;
                }
                Grid.SetRow(rectangle, unites[point][0].Row);
                Grid.SetColumn(rectangle, unites[point][0].Column);

                if (unites[point][0].Row % 2 != 0)
                    rectangle.Margin = new Thickness(rectangle.Margin.Left - 25, rectangle.Margin.Top - (30 * unites[point][0].Row), rectangle.Margin.Right, rectangle.Margin.Bottom);
                else
                    rectangle.Margin = new Thickness(rectangle.Margin.Left, rectangle.Margin.Top - (30 * unites[point][0].Row), rectangle.Margin.Right, rectangle.Margin.Bottom);
                //On ajoute l'unité à la carte

                
                myGrid.Children.Add(rectangle);
                
                //On ajoute au dictionnaire paramètre de la classe courante le couple point-rectangle
                if(!_squareOfUnits.ContainsKey(new Point(unites[point][0].Row, unites[point][0].Column)))
                _squareOfUnits.Add(new Point(unites[point][0].Row, unites[point][0].Column), rectangle);
            }

            
        }
        private int selectionUnit(int row, int column)
        {
            int i = 0;
            while (i < game.whoseturn().PeoplePlayer.ListUnit.Count)
            {
                if ((game.Map.BoardGame[row, column] is Mountain) && game.whoseturn().PeopleType == PeopleType.NAIN)
                {
                    if (game.whoseturn().PeoplePlayer.ListUnit[i].MovePoint >= 1)
                        return i;
                }
                else
                {
                    if (game.Map.juxtaposedSquare(game.whoseturn().PeoplePlayer.ListUnit[i], row, column) == true)
                    {
                        if(game.whoseturn().PeoplePlayer.ListUnit[i].MovePoint>=1)
                            return i;
                    }
                    else
                    {
                        i++;
                    }

                }
                
                
            }
            return NONE;

        }



        private void moveUnitUI(int row, int column, int index)
        {
            if (game.whoseturn().PeoplePlayer.ListUnit[index].MovePoint >= 1)
            {
                game.moveUnitOrder(game.whoseturn().PeoplePlayer.ListUnit[index], row, column);
                
             }
            
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
            if (flag == true)
            {
                Message.Text = "Combat Winned  ";
            }
            else
            {
                Message.Text = "Combat Losed  ";
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
            flag = true;

            int column = Grid.GetColumn(polygon);
            int row = Grid.GetRow(polygon);


            // V2 : gestion avec Binding
            // Mise à jour du rectangle selectionné => le label sera mis à jour automatiquement par Binding
            Grid.SetColumn(selectionPolygon, column);
            Grid.SetRow(selectionPolygon, row);
            selectionPolygon.Tag = tile;
            selectionPolygon.Visibility = System.Windows.Visibility.Visible;

            
            updateUnitUI(row, column);
            update();
            
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
            
            if (flag == true)
                game.whoseturn().TurnLeft--;
            //deleteSuggestedSquare();
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
                
                
            });
            flag = false;
            //showSuggestedSquare(game.whoseturn());
            if (game.ListPlayer[0].TurnLeft == 0 && game.ListPlayer[1].TurnLeft == 0)
            {
                GameOver g = new GameOver(game);
            }
            if (game.allIsDead(game.whoseturn()))
            {
                GameOver g = new GameOver(game);
            }
            Turn_left1.Content = game.ListPlayer[0].TurnLeft.ToString();
            Turn_left2.Content = game.ListPlayer[1].TurnLeft.ToString();
            
            if(game.whoseturn() == game.ListPlayer[0])
                Message.Text = "It's the turn of  player 2";
            else
                Message.Text = "It's the turn of  player 1";
        }





        private void menu_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }




    }



   
}
