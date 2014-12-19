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
        private Hex hex;
        GamePlay game;
        public MainWindow(GamePlay game)
        {
            this.game=game;  
            InitializeComponent();
            
        }
        //creat map+placer joueurs
        private  void Loaded_Window(object sender, RoutedEventArgs e)
        {
            SquareFactory factory = new SquareFactoryImpl();
            Map map = game.MapGame;
            int size = map.SquareNumber;
            Square[,] mat = map.MatSquare;
            
            for (int c = 0; c < size; c++)
            {
                myGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(100, GridUnitType.Pixel) });
            }
            for (int l = 0; l < size; l++)
            {
                myGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(120, GridUnitType.Pixel) });
                for (int c = 0; c < size; c++)
                { 
                    // dans chaque case de la grille on ajoute une tuile (logique) matérialisée par un rectangle (physique)
                    // le rectangle possède une référence sur sa tuile
                    if (mat[l, c].Equals(factory.createDesert()))
                    {
                        myGrid.Children.Add(createPolygon(l, c,0));
                    }
                    else
                    {
                        if (mat[l, c].Equals(factory.createForest()))
                            myGrid.Children.Add(createPolygon(l, c,1));
                        else
                            myGrid.Children.Add(createPolygon(l, c,2));
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
            
        }
        //crér un polygone et le placer dans la grid
             public Polygon createPolygon(int l,int c,int n)
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
                            new Uri(@"..\..\Texture\desert.png", UriKind.RelativeOrAbsolute)
                            );
                        myPolygon.Fill = imageb;
                        return myPolygon;
                    }
                case 1:
                    {
                        ImageBrush imagef = new ImageBrush();
                        imagef.ImageSource =
                        new BitmapImage(
                            new Uri(@"..\..\Texture\forest.png", UriKind.RelativeOrAbsolute)
                            );
                        myPolygon.Fill = imagef;
                        break;
                    }
                case 2:
                    {
                        ImageBrush imagep = new ImageBrush();
                        imagep.ImageSource =
                        new BitmapImage(
                            new Uri(@"..\..\Texture\plaine.png", UriKind.RelativeOrAbsolute)
                            );
                        myPolygon.Fill = imagep;
                        break;
                    }
                default:
                    break;
            }
            return myPolygon;
        }
        //dessiner les unites //
             private void updateGraphiqueUnite(Player p, int numJoueur)
             {
                 List<Unit> listunite = p.PeoplePlayer.ListUnit;
                 foreach (Unit u in listunite)
                 {
                     int y = u.Row;
                     int x = u.Column;
                     var element = createEllipse(x, y, numJoueur);
                     myGrid.Children.Add(element);// c'est cette fonction qui permet l'affichage de l'ellipse
                 }
             }
   //dessiner les unités 
             private void creationGraphiqueUnite(List<Unit> li, int column, int row, int numJoueur)
             {
                 foreach (Unit u in li)
                 {
                     // ajout des attributs (column et Row) référencant la position dans la grille à unitEllipse et le tag i+j permettant d'identifier l'ellipse à une unite.
                     var element = createEllipse(column, row, numJoueur);
                     myGrid.Children.Add(element);// c'est cette fonction qui permet l'affichage de l'ellipse
                     u.Column = column;
                     u.Row = row;
                 }
             }

        //creat l'ellipse
             private Ellipse createEllipse(int c, int l, int numJoueur)
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

       
    }
}
