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
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using PROJECTUML;

namespace WPFSmallWorld
{
    /// <summary>
    /// Logique d'interaction pour ExitMenu.xaml
    /// </summary>
    public partial class ExitMenu : Window
    {
        GamePlay game;
        public ExitMenu()
        {
            InitializeComponent();
        }

     /**
    * \brief Constructeur with param a gameplay  
    */
        public ExitMenu(GamePlay game)
        {
            InitializeComponent();
            this.game = game;
        }
      /**
    * \brief    Resume :return to the main windows
    */
        private void clickResume(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

     /**
    * \brief   save the current gameplay
    */
        private void saveGame(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.SaveFileDialog dlg = new System.Windows.Forms.SaveFileDialog();

            dlg.FileName = game.ListPlayer[0].Name + "_VS_"
                            + game.ListPlayer[1].Name + "_"
                            + DateTime.Now.ToString("yyyy-MM-dd");
            dlg.DefaultExt = ".sw";
            dlg.Filter = "SmallWorld save file (.sw)|*.sw";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                try
                {
                    FileStream stream = new FileStream(dlg.FileName, FileMode.Create, FileAccess.Write);
                    BinaryFormatter bformat = new BinaryFormatter();

                    bformat.Serialize(stream, game);
                    stream.Flush();
                    stream.Close();
                }
                catch (Exception ee) { Console.WriteLine("erreur saving"); }
            }
            MessageBox.Show("Game saved!");
        }



        /**
     * \brief   returns to the Menu page and close thiw windows
     */
        private void backToMenu(object sender, RoutedEventArgs e)
        {
            Menu page = new Menu();
            App.Current.MainWindow = page;
            Window.GetWindow(this).Close();
            page.Show();
            this.Close();
        }
            /**
      * \brief   exit :close the windows
      */
        private void clickExit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
