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

        public MainWindow(GamePlay game1)
        {
            this.game = game1;
            rank_graphique = 0;
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
            //updateInfo();
            updateGraphiqueUnite(game.ListPlayer[0], 0);
            updateGraphiqueUnite(game.ListPlayer[1], 1);

        }

        //initialiser les informations des joueurs

        public void initInformations()
        {
            if (game.ListPlayer[0].Name!=null)
            Name1.Content = game.ListPlayer[0].Name.ToString();
            if(game.ListPlayer[1].Name!=null)
            Name2.Content = game.ListPlayer[1].Name.ToString();

            int n1, n2;
            n1 = game.ListPlayer[0].NbUnit;
            n2 = game.ListPlayer[1].NbUnit;
            if ((n1 != 0) && (n2 != 0))
            {
                NbUnite1.Content = game.ListPlayer[0].NbUnit.ToString();
                NbUnite2.Content = game.ListPlayer[1].NbUnit.ToString();
            }

            game.ListPlayer[0].Turn = true;
            game.ListPlayer[1].Turn = false;

        }

        public void updateInfo(Unit u)
        {
            int n1, n2;
            n1 = game.ListPlayer[0].NbUnit;
            n2 = game.ListPlayer[1].NbUnit;
            if ((n1 != 0) && (n2 != 0))
            {
                NbUnite1.Content = game.ListPlayer[0].NbUnit.ToString();
                NbUnite2.Content = game.ListPlayer[1].NbUnit.ToString();
            }
            if (u != null)
            {
                if (indexTurnPlayer() == 0)
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
                }
                
            }
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
                u.Rank = rank_graphique;
                rank_graphique++;
                var element = createEllipse(x, y, numJoueur);
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
                return 1;
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
            int turn = 0;
            game.moveUnitOrder(game.whoseturn().PeoplePlayer.ListUnit[index], row, column);
            switch (indexTurnPlayer())
            {
                case 0:
                    turn = 0;
                    break;
                case 1:
                    turn = game.Map.UnitNumber;
                    break;
            }
            updateInfo(game.whoseturn().PeoplePlayer.ListUnit[index]);
            Grid.SetRow(myGrid.Children[(game.Map.SquareNumber * game.Map.SquareNumber) + 1 + index + turn], row);
            Grid.SetColumn(myGrid.Children[(game.Map.SquareNumber * game.Map.SquareNumber) + 1 + index + turn], column);
        }
        private unsafe void updateUnitUI(int row, int column)
        {
            //var index = 0;//selectionUnit(row, column);

            
            //si les cases sont juxtaposées et que la case d'arrivée est vide
            //if (index != NONE)
            //{
                
                
                System.Console.WriteLine("NB UNIT : " + game.Map.BoardGame[row, column].ListUnitImpl.Count);
                /*switch (c)
                {
                    case 0:
                        moveUnitUI(row, column, index);
                        System.Console.WriteLine("NOMBRE UNITE SQUARE   APRES  --> " + game.Map.returnSquare(row, column).ListUnitImpl.Count);
                        break;
                    case 1:
                        System.Console.WriteLine("NOMBRE UNITE SQUARE   AVANT COMBAT  --> " + game.Map.returnSquare(row, column).ListUnitImpl.Count);
                        break;

                }*/
                

                    
                    /*
                    if (game.Map.returnSquare(row, column).ListUnitImpl.Count > 0)
                    /*et que c'est lunité de l'autre joueur*/
                    /*{
                        System.Console.WriteLine("COMBAT");
                        combatUI(index, row, column);
                    }*/
                

            //}
        }

        
        private void combatUI(int index, int row, int column)
        {
            List<Unit> l = game.Map.returnSquare(row, column).ListUnitImpl;
            bool flag = game.startCombat(game.whoseturn().PeoplePlayer.ListUnit[index], row, column);
            if ( flag == true)
            {
                System.Console.WriteLine("COMBAT GAGNE");
                updateInfo(game.whoseturn().PeoplePlayer.ListUnit[index]);
                //s'il n'y a plus d'unité dans la case ennemi car l'ennemi n'a plus de vie
                if (game.Map.returnSquare(row, column).ListUnitImpl.Count == 0)
                {
                    //supprimer l'unité
                    for (int i = 0; i < l.Count; i++)
                    {
                        myGrid.Children.Remove(myGrid.Children[(game.Map.SquareNumber * game.Map.SquareNumber) + 2 + l[i].Rank]);
                    }
                    moveUnitUI(row, column, index);
                }

            }
            else
            {
                //le combat est perdu 
                System.Console.WriteLine("COMBAT PERDU");
                updateInfo(game.whoseturn().PeoplePlayer.ListUnit[index]);
                if (game.whoseturn().PeoplePlayer.ListUnit[index].LifePoint == 0)
                {
                    myGrid.Children.Remove(myGrid.Children[(game.Map.SquareNumber * game.Map.SquareNumber) + 2 + game.whoseturn().PeoplePlayer.ListUnit[index].Rank]);
                }

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


            // V2 : gestion avec Binding
            // Mise à jour du rectangle selectionné => le label sera mis à jour automatiquement par Binding
            Grid.SetColumn(selectionPolygon, column);
            Grid.SetRow(selectionPolygon, row);
            selectionPolygon.Tag = tile;
            selectionPolygon.Visibility = System.Windows.Visibility.Visible;
            System.Console.WriteLine("ROW : " + row);
            System.Console.WriteLine("COLUMN : " + column);
            System.Console.WriteLine("NB UNIT : " + game.Map.BoardGame[row, column].ListUnitImpl.Count);
            updateUnitUI(row, column);
            /*if (game.Map.returnSquare(row, column).ListUnitImpl.Count != 0)
            {
                
                PROJECTUML.Unit u = game.Map.returnSquare(row, column).ListUnitImpl[0];
                updateInfo(u);
            }*/
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
            ellipse.Height = 50;
            ellipse.Width = 50;
            return ellipse;
        }

        private void menu_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }



   
}
