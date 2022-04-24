using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Moving_Out
{
    /// <summary>
    /// Interaction logic for Ingame_Menu.xaml
    /// </summary>
    public partial class Ingame_Menu : Window
    {
        public Ingame_Menu()
        {
            InitializeComponent();
        }

        public event EventHandler Dt_start;
        public event EventHandler CloseMainWindow;

        private void Continue(object sender, RoutedEventArgs e)
        {
            Dt_start?.Invoke(this, null);
            this.Close();
        }

        private void Save(object sender, RoutedEventArgs e)
        {

        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            CloseMainWindow?.Invoke(this, null);
            this.Close();
        }
    }
}
