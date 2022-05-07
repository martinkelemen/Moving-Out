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

namespace Moving_Out
{
    /// <summary>
    /// Interaction logic for HighscoreWindow.xaml
    /// </summary>
    public partial class HighscoreWindow : Window
    {
        public MediaPlayer mp = new MediaPlayer();
        private void ReadFromFile()
        {
            string[] lines = File.ReadAllLines(System.IO.Path.Combine("Text", "highscore.txt"));
            string[][] all = new string[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] split = lines[i].Split(";");
                all[i] = new string[2];
                all[i][0] = split[0];
                all[i][1] = split[1];
            }
            Array.Sort(all, (a, b) => { return -(int.Parse(a[1]) - int.Parse(b[1])); } );
            for (int i = 0; i < lines.Length; i++)
            {
                highscorelistbox.Items.Add(all[i][0] + ": \t" + all[i][1] + " points");
            }
        }
        public HighscoreWindow(TimeSpan Position)
        {
            InitializeComponent();
            mp.Open(new Uri(System.IO.Path.Combine("Audio", "doomer.mp3"), UriKind.RelativeOrAbsolute));
            mp.Position = Position;
            mp.Volume = 0.2;
            mp.Play();
            ReadFromFile();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu(mp.Position);
            mp.Stop();
            mp.Close();
            mainMenu.Show();
            this.Close();
        }
    }
}