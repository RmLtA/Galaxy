﻿using System;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Player window = new Player();
            window.Show();
            this.Close();
        }

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
                    try
                    {
                       GamePlay game= GamePlayImpl.Instance.LoadGame(dlg.FileName);
                       MainWindow main = new MainWindow(game);
                       App.Current.MainWindow = main;
                       Window.GetWindow(this).Close();
                       main.Show();
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show("Incorrect file. Are you sure that " + dlg.FileName + " is a SmallWorld game file?");
                        continue; // Ask a new file
                    }

                    // Stop asking file and reload the whole window
                    ok = true;

                 
                }
                // Stop asking if the user cancel the loading
                else if (res == System.Windows.Forms.DialogResult.Cancel)
                {
                    ok = true;
                }
            }

        }
    }
}

