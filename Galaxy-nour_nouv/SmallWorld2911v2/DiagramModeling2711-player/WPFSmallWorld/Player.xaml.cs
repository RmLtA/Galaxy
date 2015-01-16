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
        GamePlay game;
        string player1, player2;
        PeopleType people1, people2;
        string peopleType1, peopleType2;
        MapType map;
        public Player()
        {
            InitializeComponent();
        }
        /**
  * \brief    initialise the type of people of the player 1 with Elf
  */
        private void unitelf1(object sender, RoutedEventArgs e)
        {
            enableditems2(ELF2);
            people1 = PeopleType.ELF;
         
        }
            /**
      * \brief    initialise the type of people of the player 1 with Nain
      */
        private void unitnain1(object sender, RoutedEventArgs e)
        {
            enableditems2(NAIN2); 
            people1 = PeopleType.NAIN;

        }
        /**
      * \initialise the type of people of the player1 with Orc
      */
        private void unitorc1(object sender, RoutedEventArgs e)
        {
            enableditems2(ORC2);
            people1 = PeopleType.ORC;

        }
        /**
  * \brief    initialise the type of people of the player2 with ELF
  */
        private void unitelf2(object sender, RoutedEventArgs e)
        {
            enableditems1(ELF);
            people2 = PeopleType.ELF;

        }
        /**
  * \brief   initialise the type of people of the player2 with Nain
  */
        private void unitnain2(object sender, RoutedEventArgs e)
        {
            enableditems1(NAIN);
            people2 = PeopleType.NAIN;

        }
        /**
  * \brief   initialise the type of people of the player2 with Orc
  */
        private void unitorc2(object sender, RoutedEventArgs e)
        {
            enableditems1(ORC);
            people2 = PeopleType.ORC;

        }
        /**
      * \brief    enabled people of player1
      */
        private void enableditems1(RadioButton b) {

            NAIN.IsEnabled = true;
            ELF.IsEnabled = true;
            ORC.IsEnabled = true;
            b.IsEnabled = false;
        
        }
        /**
      * \brief    enabled people of player2
      */
        private void enableditems2(RadioButton b)
        {

            NAIN2.IsEnabled = true;
            ELF2.IsEnabled = true;
            ORC2.IsEnabled = true;
            b.IsEnabled = false;

        }

        /**
      * \brief   initialise the map type with the type choosen 
      */
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
        /**
      * \brief    initialise the name and the people of player2
      */
        private void copyInfo2()
        {
            player2 = Textplayer2.Text;

            Textplayer2.ClearValue(TextBox.BorderBrushProperty);

            if (player2 == null || player2 == "" || player2 == Textplayer1.Text)
            {
                Textplayer2.BorderBrush = Brushes.Red;
            }
            if (peopleType2 == null)
            {
                ELF2.BorderBrush = Brushes.Red;
                ORC2.BorderBrush = Brushes.Red;
                NAIN2.BorderBrush = Brushes.Red;
            }
        }
            /**
      * \brief    initialise the name and the people of player1
      */
        private void copyInfo1()
        {
            player1 = Textplayer1.Text;

            Textplayer1.ClearValue(TextBox.BorderBrushProperty);

            if (player1 == null || player1 == "" || player1 == Textplayer2.Text)
            {
                Textplayer1.BorderBrush = Brushes.Red;
            }
            if (peopleType1 == null)
            {
                ELF.BorderBrush = Brushes.Red;
                ORC.BorderBrush = Brushes.Red;
                NAIN.BorderBrush = Brushes.Red;
            }
        }

            /**
      * \brief    create a gameplay with the selected informations, and open the windows of the game named "MainWindow"
      */
        private void startGame(object sender, RoutedEventArgs e)
        {
                copyInfo1();
                copyInfo2();

                GamePlayBuilder builder = new NewGamePlayImpl();
                game = builder.start(map, player1, people1, player2, people2);
                MainWindow window = new MainWindow(game);
                window.Show();
                this.Close();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }



    }
}
