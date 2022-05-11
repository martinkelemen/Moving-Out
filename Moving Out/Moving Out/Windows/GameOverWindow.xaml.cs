using System;
using System.Collections.Generic;
using System.IO;
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

namespace Moving_Out.Windows
{
    /// <summary>
    /// Interaction logic for GameOverWindow.xaml
    /// </summary>
    public partial class GameOverWindow : Window
    {
        public event EventHandler CloseMainWindow;
        public int Points { get; set; }

        private string message;

        public GameOverWindow(string message)//gameover szoveg
        {
            InitializeComponent();
            this.message = message;
        }

        private void WriteToFile()
        {
            string text = player_name.Text + ";" + Points.ToString();
            File.AppendAllText("highscore.txt", text + Environment.NewLine);
        }
        private void save_exit_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu(TimeSpan.Zero);
            mainMenu.Show();
            CloseMainWindow?.Invoke(this, null);
            WriteToFile();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            label_gameover.FontSize = (int)(grid.ActualWidth / 12.8);
            label_yourname.FontSize = (int)(grid.ActualWidth / 32);
            player_name.FontSize = (int)(grid.ActualWidth / 32);
            label_objtext.FontSize = (int)(grid.ActualWidth / 32);
            label_objtext.Content = message;
        }
    }
}