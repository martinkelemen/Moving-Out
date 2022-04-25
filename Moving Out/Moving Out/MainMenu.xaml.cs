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

namespace Moving_Out
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        private MediaPlayer mpMainMenu = new MediaPlayer();
        private bool sound_playing;
        public MainMenu()
        {
            InitializeComponent();
            SoundButton.ImageSource = new BitmapImage(new Uri(System.IO.Path.Combine("Images", "volume.png"), UriKind.RelativeOrAbsolute));
            mpMainMenu.Open(new Uri(System.IO.Path.Combine("Audio", "doomer.mp3"), UriKind.RelativeOrAbsolute));
            mpMainMenu.MediaEnded += new EventHandler(Media_Ended);
            mpMainMenu.Play();
            mpMainMenu.Volume = 0.2;
            sound_playing = true;
        }

        private void Media_Ended(object sender, EventArgs e)
        {
            mpMainMenu.Position = TimeSpan.Zero;
            mpMainMenu.Play();
            mpMainMenu.Volume = 0.2;
        }

        private void New_Game(object sender, RoutedEventArgs e)
        {
            mpMainMenu.Stop();
            //mpMainMenu.Close();
            sound_playing = false;
            //mpMainMenu.Open(new Uri(System.IO.Path.Combine("Audio", "polizei.mp3"), UriKind.RelativeOrAbsolute));
            //mpMainMenu.Play();
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void HighScore(object sender, RoutedEventArgs e)
        {

        }

        private void Quit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
        private void Mute(object sender, RoutedEventArgs e)
        {
            if (sound_playing)
            {
                mpMainMenu.Volume = 0;
                SoundButton.ImageSource = new BitmapImage(new Uri(System.IO.Path.Combine("Images", "mute.png"), UriKind.RelativeOrAbsolute));
                sound_playing = false;
            }
            else if (sound_playing==false)
            {
                mpMainMenu.Volume = 0.2;
                SoundButton.ImageSource = new BitmapImage(new Uri(System.IO.Path.Combine("Images", "volume.png"), UriKind.RelativeOrAbsolute));
                sound_playing = true;
            }
        }
    }
}
