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
using WrapperCPP;
namespace WPFSmallWorld
{
    /// <summary>
    /// Logique d'interaction pour Select_players.xaml
    /// </summary>
    public partial class Player : Window
    {
        
        string player1, player2;
        PeopleType people1, people2;
        string peopleType1, peopleType2;
        MapType map;
        public Player()
        {
            InitializeComponent();
        }

        private PeopleType initPeople(string content)
        {
            PeopleType type = 0;
            switch (content)
            {
                case "ELF":
                    type = PeopleType.ELF;
                    break;
                case "ORC":
                    type = PeopleType.ORC;
                    break;
                case "NAIN":
                    type = PeopleType.NAIN;
                    break;
                default:
                    throw new ArgumentException("This people is unknown");
            }
            return type;
        }
        private void initPeoplePlayer1(object sender, RoutedEventArgs e)
        {
            RadioButton sender1 = (sender as RadioButton);
            peopleType1 = sender1.Content.ToString();


            ELF.ClearValue(TextBox.BorderBrushProperty);
            NAIN.ClearValue(TextBox.BorderBrushProperty);
            ORC.ClearValue(TextBox.BorderBrushProperty);
        }
        private void initPeoplePlayer2(object sender, RoutedEventArgs e)
        {
            RadioButton sender1 = (sender as RadioButton);
            peopleType2 = sender1.Content.ToString();


            ELF2.ClearValue(TextBox.BorderBrushProperty);
            NAIN2.ClearValue(TextBox.BorderBrushProperty);
            ORC2.ClearValue(TextBox.BorderBrushProperty);
        }

        private void selectMapStrategy(object sender, RoutedEventArgs e)
        {
            RadioButton sender1 = (sender as RadioButton);
            string stringmap = sender1.Content.ToString();
            switch (stringmap)
            {
                case "SMALL":
                    map = MapType.SMALL;
                    break;
                case "DEMO":
                    map = MapType.DEMO;
                    break;
                case "NORMAL":
                    map = MapType.NORMAL;
                    break;
            }

            SMALL.ClearValue(TextBox.BorderBrushProperty);
            DEMO.ClearValue(TextBox.BorderBrushProperty);
            NORMAL.ClearValue(TextBox.BorderBrushProperty);
        }
        private void copyInfo2(object sender, RoutedEventArgs e)
        {
            player2 = Textplayer2.Text;

            Textplayer2.ClearValue(TextBox.BorderBrushProperty);

            if (player2 == null || player2 == "" || player2 == Textplayer1.Text)
            {
                Textplayer2.BorderBrush = Brushes.Red;
                Ok2.IsChecked = false;
            }
            if (peopleType2 == null)
            {
                ELF2.BorderBrush = Brushes.Red;
                ORC2.BorderBrush = Brushes.Red;
                NAIN2.BorderBrush = Brushes.Red;
                Ok2.IsChecked = false;
            }
        }

        private void copyInfo1(object sender, RoutedEventArgs e)
        {
            player1 = Textplayer1.Text;

            Textplayer1.ClearValue(TextBox.BorderBrushProperty);

            if (player1 == null || player1 == "" || player1 == Textplayer2.Text)
            {
                Textplayer1.BorderBrush = Brushes.Red;
                Ok1.IsChecked = false;
            }
            if (peopleType1 == null)
            {
                ELF.BorderBrush = Brushes.Red;
                ORC.BorderBrush = Brushes.Red;
                NAIN.BorderBrush = Brushes.Red;
                Ok1.IsChecked = false;
            }
        }


        private void startGame(object sender, RoutedEventArgs e)
        {
            GamePlay game;
            GamePlayBuilder builder = new NewGamePlayImpl();
            game = builder.start(map,player1, people1,player2, people2);
            MainWindow window = new MainWindow(game);
            window.Show();
            this.Close();

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }



    }
}
