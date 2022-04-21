using Moving_Out.Logic;
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
using System.Windows.Threading;

namespace Moving_Out
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MoveLogic logic;
        
        private void Dt_Tick(object sender, EventArgs e)
        {
            //logic.TimeStep();
        }
        public MainWindow()
        {
            InitializeComponent();

          //  DispatcherTimer dt = new DispatcherTimer();

           // dt.Tick += Dt_Tick;
           // dt.Interval = TimeSpan.FromMilliseconds(20);
           // dt.Start();
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if(Keyboard.IsKeyDown(Key.Left))
            {
                logic.Control(MoveLogic.Controls.Left);
            }
            else if (Keyboard.IsKeyDown(Key.Right))
            {
                logic.Control(MoveLogic.Controls.Right);
            }
            else if (Keyboard.IsKeyDown(Key.Up))
            {
                logic.Control(MoveLogic.Controls.Up);
            }
            else if (Keyboard.IsKeyDown(Key.Down))
            {
                logic.Control(MoveLogic.Controls.Down);
            }
            else
            {
                logic.Control(MoveLogic.Controls.None);
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Left && Keyboard.IsKeyDown(Key.Up)) || (e.Key == Key.Up && Keyboard.IsKeyDown(Key.Left)))
            {
                logic.Control(MoveLogic.Controls.LeftUp);
            }
            else if ((e.Key == Key.Left && Keyboard.IsKeyDown(Key.Down)) || (e.Key == Key.Down && Keyboard.IsKeyDown(Key.Left)))
            {
                logic.Control(MoveLogic.Controls.LeftDown);
            }
            else if (e.Key == Key.Left)
            {
                logic.Control(MoveLogic.Controls.Left);
            }
            else if ((e.Key == Key.Right && Keyboard.IsKeyDown(Key.Up)) || (e.Key == Key.Up && Keyboard.IsKeyDown(Key.Right)))
            {
                logic.Control(MoveLogic.Controls.RightUp);
            }
            else if (e.Key == Key.Right && Keyboard.IsKeyDown(Key.Down) || (e.Key == Key.Down && Keyboard.IsKeyDown(Key.Right)))
            {
                logic.Control(MoveLogic.Controls.RightDown);
            }
            else if (e.Key == Key.Right)
            {
                logic.Control(MoveLogic.Controls.Right);
            }
            else if (e.Key == Key.Up)
            {
                logic.Control(MoveLogic.Controls.Up);
            }
            else if (e.Key == Key.Down)
            {
                logic.Control(MoveLogic.Controls.Down);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            logic = new MoveLogic();
            display.SetupModel(logic);
            display.SetupSizes(new Size(canvas.ActualWidth, canvas.ActualHeight));
            logic.SetupSizes(new Size((int)canvas.ActualWidth, (int)canvas.ActualHeight));
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            display.SetupSizes(new Size(canvas.ActualWidth, canvas.ActualHeight));
        }
    }
}
