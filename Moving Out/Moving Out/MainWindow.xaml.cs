using Moving_Out.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        object lockObject;
        bool programPaused;

        private void Dt_Tick(object sender, EventArgs e)
        {
            logic.TimeStep();
        }

        private void Dt_Rm_Tick(object sender, EventArgs e)
        {
            logic.ChangeRoommateDirection();
        }

        private void Dt_Obj_Tick(object sender, EventArgs e)
        {
            logic.RandomObjective();
        }

        private void Dt_Obj_T_Tick(object sender, EventArgs e)
        {
            logic.DecreaseSeconds();
        }

        public MainWindow()
        {
            InitializeComponent();

            lockObject = new object();
            programPaused = false;

            DispatcherTimer dt = new DispatcherTimer();

            dt.Tick += Dt_Tick;
            dt.Interval = TimeSpan.FromMilliseconds(10);
            dt.Start();

            DispatcherTimer dt_rm = new DispatcherTimer();

            dt_rm.Tick += Dt_Rm_Tick;
            dt_rm.Interval = TimeSpan.FromSeconds(5);
            dt_rm.Start();

            DispatcherTimer dt_obj = new DispatcherTimer();

            dt_obj.Tick += Dt_Obj_Tick;
            dt_obj.Interval = TimeSpan.FromSeconds(10);
            dt_obj.Start();

            DispatcherTimer dt_obj_t = new DispatcherTimer();

            dt_obj_t = new DispatcherTimer();
            dt_obj_t.Tick += Dt_Obj_T_Tick;
            dt_obj_t.Interval = TimeSpan.FromSeconds(1);
            dt_obj_t.Start();

            new Task(() =>
            {
                while (true)
                {
                    if (logic != null && logic.Objectives != null)
                    {
                        Thread.Sleep(10000);
                        lock(lockObject)
                        {
                            while(programPaused)
                            {
                                Monitor.Wait(lockObject);
                            }
                        }
                        dt_rm.Stop();
                        logic.RoommateObjective();
                        dt_rm.Start();
                    }
                }
            }).Start();
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                logic.Left = false;
            }
            else if (e.Key == Key.Right)
            {
                logic.Right = false;
            }
            else if (e.Key == Key.Up)
            {
                logic.Up = false;
            }
            else if (e.Key == Key.Down)
            {
                logic.Down = false;
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                logic.Left = true;
            }
            else if (e.Key == Key.Right)
            {
                logic.Right = true;
            }
            else if (e.Key == Key.Up)
            {
                logic.Up = true;
            }
            else if (e.Key == Key.Down)
            {
                logic.Down = true;
            }
            else if (e.Key == Key.E)
            {
                logic.Interact();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            logic = new MoveLogic();
            display.SetupModel(logic);
            display.SetupSizes(new Size(canvas.ActualWidth, canvas.ActualHeight));
            logic.SetupSizes(new Size((int)canvas.ActualWidth, (int)canvas.ActualHeight));
            logic.SetupItems();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            display.SetupSizes(new Size(canvas.ActualWidth, canvas.ActualHeight));
            //if (logic != null)
            //{
            //    logic.ChangeSize(new Size(canvas.ActualWidth, canvas.ActualHeight));
            //}
        }
    }
}
