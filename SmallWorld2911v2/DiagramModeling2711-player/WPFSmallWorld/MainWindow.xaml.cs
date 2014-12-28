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
using PROJECTUML;

namespace WPFSmallWorld
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
 

    public partial class MainWindow : Window
    {
 
        GamePlay game;
       

        public MainWindow(GamePlay game)
        {
            this.game = game;
            InitializeComponent();

        }
        
        private void Loaded_Window(object sender, RoutedEventArgs e)
        {
            SquareFactory factory = new SquareFactoryImpl();
            Map map = game.Map;
            int size = map.SquareNumber;
            Square[,] mat = map.BoardGame;

            
            for (int c = 0; c < size; c++)
            {
                myGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(100, GridUnitType.Pixel) });
            }
            for (int l = 0; l < size; l++)
            {
               myGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(120, GridUnitType.Pixel) });
                for (int c = 0; c < size; c++)
                {
                    if (mat[l, c] is Desert)
                    {
                        myGrid.Children.Add(createPolygon(l, c, 0));
                    }
                    else
                    {
                        if (mat[l, c]is Forest)
                        {
                            myGrid.Children.Add(createPolygon(l, c, 1));

                        }
                        else if (mat[l, c] is Plain)
                        {
                            myGrid.Children.Add(createPolygon(l, c, 2));
                        }                        
                            
                    }
                }
            }

            initInformations();
            updateGraphiqueUnite(game.ListPlayer[0], 0);
            updateGraphiqueUnite(game.ListPlayer[1], 1);

        }

        //initialiser les informations des joueurs

        public void initInformations()
        {
            int n1, n2;
            n1 = game.ListPlayer[0].NbUnit;
            n2 = game.ListPlayer[1].NbUnit;
            if ((n1 != 0) && (n2 != 0))
            {
                NbUnite1.Content = game.ListPlayer[0].NbUnit.ToString();
                NbUnite2.Content = game.ListPlayer[1].NbUnit.ToString();
            }
            Name1.Content = game.ListPlayer[0].Name;
            Name2.Content = game.ListPlayer[1].Name;

            game.ListPlayer[0].Turn = true;
            game.ListPlayer[1].Turn = false;

        }


        //crér un polygone et le placer dans la grid
        public Polygon createPolygon(int l, int c, int n)
        {
            

            Polygon myPolygon = new Polygon();
            myPolygon.Stroke = System.Windows.Media.Brushes.Black;
            myPolygon.Fill = System.Windows.Media.Brushes.LightSeaGreen;
            myPolygon.StrokeThickness = 2;
            myPolygon.HorizontalAlignment = HorizontalAlignment.Left;
            myPolygon.VerticalAlignment = VerticalAlignment.Center;
            System.Windows.Point Point1 = new System.Windows.Point(50, 0);
            System.Windows.Point Point2 = new System.Windows.Point(100, 28.8675);
            System.Windows.Point Point3 = new System.Windows.Point(100, 86.6025);
            System.Windows.Point Point4 = new System.Windows.Point(50, 115.47);
            System.Windows.Point Point5 = new System.Windows.Point(0, 86.6025);
            System.Windows.Point Point6 = new System.Windows.Point(0, 28.8675);

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
                            new Uri(@"C:\Users\Romdhane\Desktop\Galaxy-v_liantsoa\SmallWorld2911v2\DiagramModeling2711-player\WPFSmallWorld\Resources\desert.png", UriKind.RelativeOrAbsolute)
                            );
                        myPolygon.Fill = imageb;
                        break;
                    }
                case 1:
                    {
                        ImageBrush imagef = new ImageBrush();
                        imagef.ImageSource =
                        new BitmapImage(
                            new Uri(@"C:\Users\Romdhane\Desktop\Galaxy-v_liantsoa\SmallWorld2911v2\DiagramModeling2711-player\WPFSmallWorld\Resources\foret.png", UriKind.RelativeOrAbsolute)
                            );
                        myPolygon.Fill = imagef;
                        break;
                    }
                case 2:
                    {
                        ImageBrush imagep = new ImageBrush();
                        imagep.ImageSource =
                        new BitmapImage(
                            new Uri(@"C:\Users\Romdhane\Desktop\Galaxy-v_liantsoa\SmallWorld2911v2\DiagramModeling2711-player\WPFSmallWorld\Resources\plaine.png", UriKind.RelativeOrAbsolute)
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
                int y = u.Row;
                int x = u.Column;
                var element = createEllipse(x, y, numJoueur);
                myGrid.Children.Add(element);
            }
        }

        private int selectionUnit(int row, int column)
        {
            for (int i = 0; i < game.whoseturn().PeoplePlayer.ListUnit.Count; i++)
            {
                if (game.Map.juxtaposedSquare(game.whoseturn().PeoplePlayer.ListUnit[i], row, column) == true)
                {
                    return i;
                }
                
            }
            System.Console.WriteLine("---NON JUXTAPOSEE-----");
            return 0;

        }

        private int indexTurnPlayer()
        {
            if (game.whoseturn() == game.ListPlayer[0])
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        private unsafe void updateUnitUI(int row, int column)
        {
            var index = selectionUnit(row,column);
            var possibleX = game.whoseturn().PeoplePlayer.ListUnit[index].getSuggestedPointsX(game.Map);
            for (int w=0; w < 4; w++)
            {
                System.Console.WriteLine(possibleX[w]);
            }

                System.Console.WriteLine("--");

            var possibleY = game.whoseturn().PeoplePlayer.ListUnit[index].getSuggestedPointsY(game.Map);
            for (int w = 0; w < 4; w++)
            {
                System.Console.WriteLine(possibleY[w]);
            }


            for (int i = 0; i < 4; i++)
            {
                if (possibleX[i] == row)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (possibleY[j] == column)
                        {
                            game.moveUnitOrder(game.whoseturn().PeoplePlayer.ListUnit[index], row, column);
                            Grid.SetColumn(myGrid.Children[(game.Map.SquareNumber * game.Map.SquareNumber) + 2 + index], column);
                            Grid.SetRow(myGrid.Children[(game.Map.SquareNumber * game.Map.SquareNumber) + 2 + index], row);
                        }
                    }
                }
            }


                System.Console.WriteLine("-----------------");


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

            

            // V2 : gestion avec Binding
            // Mise à jour du rectangle selectionné => le label sera mis à jour automatiquement par Binding
            Grid.SetColumn(selectionPolygon, column);
            Grid.SetRow(selectionPolygon, row);
            selectionPolygon.Tag = tile;
            selectionPolygon.Visibility = System.Windows.Visibility.Visible;
            updateUnitUI(row, column);
            e.Handled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // création d'un thread pour lancer le calcul du tour suivant sans que cela soit bloquant pour l'IHM
            Task.Factory.StartNew(() =>
            {

                this.Dispatcher.BeginInvoke(new Action(() =>
                {

                    // On "touche" au rectangle de selection pour provoquer un rafraichissemnt via le Binding
                    var selected = selectionPolygon.Tag;
                    selectionPolygon.Tag = null;
                    selectionPolygon.Tag = selected;
                }));

                game.gotoNextPlayer(); 
            });

        }



        //create l'ellipse
        private Ellipse createEllipse(int l, int c, int numJoueur)
        {
            Ellipse ellipse = new Ellipse();

            Grid.SetColumn(ellipse, c);
            Grid.SetRow(ellipse, l);
            ellipse.Tag = numJoueur;
            if (numJoueur == 1)
            {
                ellipse.Fill = Brushes.Red;
            }
            else
            {
                ellipse.Fill = Brushes.White;
            }
            ellipse.Height = 10;
            ellipse.Width = 10;
            return ellipse;
        }

        private void menu_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            ExitMenu menu = new ExitMenu();
            menu.Show();
        }

       
       
    }



   
}
