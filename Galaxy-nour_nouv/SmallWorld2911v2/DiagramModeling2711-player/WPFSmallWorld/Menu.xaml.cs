using System;
using System.Collections.Generic;
using System.Linq;
﻿using System;
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
    /// Logique d'interaction pour Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }
        /**
        * \brief    open the windows to select players and close the current windows
        */
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Player window = new Player();
            window.Show();
            this.Close();
        }
        /**
       * \brief    load a saved game
       */
        private void Load(object sender, RoutedEventArgs e)
        {

            // Configure a file dialog to select the file to load
            System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
            dlg.DefaultExt = ".sw";
            dlg.Filter = "SmallWorld save file (.sw)|*.sw";

            bool ok = false;
            while (!ok)
            {
                System.Windows.Forms.DialogResult res = dlg.ShowDialog();
                if (res == System.Windows.Forms.DialogResult.OK)
                {
                    BinaryFormatter bformat = new BinaryFormatter();
                    FileStream stream = null;
                    try
                    {
                        stream = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);

                        GamePlay game = (GamePlayImpl)bformat.Deserialize(stream);

                        MainWindow main = new MainWindow(game);
                        App.Current.MainWindow = main;
                        Window.GetWindow(this).Close();
                        main.Show();
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show(ee.Message);
                       
                    }
                    finally { stream.Close(); }
                    
                    ok = true;
                }
                else if (res == System.Windows.Forms.DialogResult.Cancel)
                {
                    ok = true;
                }
            }
        }
        /**
      * \brief   Quit the menu
      */
        private void menu_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


       
    }
}
