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

namespace Moving_Out.Windows
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MediaPlayer mpMainMenu = new MediaPlayer();
        public MainMenu(TimeSpan Position)
        {
            InitializeComponent();
            mpMainMenu.Open(new Uri(System.IO.Path.Combine("Audio", "doomer.mp3"), UriKind.RelativeOrAbsolute));
            mpMainMenu.Position = Position;
            mpMainMenu.MediaEnded += new EventHandler(Media_Ended);
            mpMainMenu.Play();
            mpMainMenu.Volume = 0.1;
        }

        public MainMenu()
        {
            InitializeComponent();
            mpMainMenu.Open(new Uri(System.IO.Path.Combine("Audio", "doomer.mp3"), UriKind.RelativeOrAbsolute));
            mpMainMenu.MediaEnded += new EventHandler(Media_Ended);
            mpMainMenu.Play();
            mpMainMenu.Volume = 0.1;
        }

        private void Media_Ended(object sender, EventArgs e)
        {
            mpMainMenu.Position = TimeSpan.Zero;
            mpMainMenu.Play();
            mpMainMenu.Volume = 0.1;
        }

        private void New_Game(object sender, RoutedEventArgs e)
        {
            mpMainMenu.Stop();
            mpMainMenu.Close();
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void HighScore(object sender, RoutedEventArgs e)
        {

            HighscoreWindow highscoreWindow = new HighscoreWindow(mpMainMenu.Position);
            mpMainMenu.Stop();
            mpMainMenu.Close();
            highscoreWindow.Show();
            this.Close();
        }

        private void Quit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
