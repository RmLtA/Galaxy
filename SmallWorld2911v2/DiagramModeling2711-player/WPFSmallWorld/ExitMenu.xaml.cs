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
using PROJECTUML;
namespace WPFSmallWorld
{
    /// <summary>
    /// Logique d'interaction pour LoadMenu.xaml
    /// </summary>
    public partial class ExitMenu : Window
    {
        public ExitMenu()
        {
            InitializeComponent();
        }
        private void clickResume(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void saveGame(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.SaveFileDialog dlg = new System.Windows.Forms.SaveFileDialog();

            dlg.FileName = GamePlayImpl.Instance.ListPlayer[0].Name + "_VS_"
                            + GamePlayImpl.Instance.ListPlayer[1].Name + "_"
                            + DateTime.Now.ToString("yyyy-MM-dd");
            dlg.DefaultExt = ".sw";
            dlg.Filter = "SmallWorld save file (.sw)|*.sw";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                GamePlayImpl.Instance.registerGamePlay(dlg.FileName);
                MessageBox.Show("Game saved!");
            }
        }

        /// <summary>
        /// Delete the current window and returns to the start page
        /// </summary>
        private void backToMenu(object sender, RoutedEventArgs e)
        {
            Menu page = new Menu();
            App.Current.MainWindow = page;
            Window.GetWindow(this).Close();
            page.Show();
        }

        private void clickExit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
