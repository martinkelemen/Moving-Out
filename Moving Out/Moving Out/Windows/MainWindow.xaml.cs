using Moving_Out.Logic;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Moving_Out.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MoveLogic logic;
        DispatcherTimer dt;
        DispatcherTimer dt_rm;
        DispatcherTimer dt_obj;
        DispatcherTimer dt_obj_t;
        DispatcherTimer dt_rm_obj;
        DispatcherTimer dt_moverm;
        DispatcherTimer dt_setseconds;
        ObjectiveType type;

        int rm_obj_seconds;
        int obj_seconds;

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
        private void Dt_Rm_Obj_Tick(object sender, EventArgs e)
        {
            type = logic.RoommateObjective();
            if (type != ObjectiveType.NotFound && type != ObjectiveType.None)
            {
                dt_rm.Stop();
                dt_rm_obj.Stop();
                dt_moverm.Start();
            }
            else if (type == ObjectiveType.NotFound)
            {
                Dt_Rm_Obj_Tick(sender, e);
            }
        }

        private void Move_Rm(object sender, EventArgs e)
        {
            if (!logic.RoommateAtObjective)
            {
                GameObjective tmp = new GameObjective(type, 50, (int)canvas.ActualWidth, (int)canvas.ActualHeight);
                logic.MoveRoommateToObjective(type, tmp);
            }
            else if (logic.RoommateAtObjective)
            {
                dt_moverm.Stop();
                dt_rm.Start();
                dt_rm_obj.Start();
                logic.RoommateAtObjective = false;
            }
        }

        private void Set_Seconds(object sender, EventArgs e)
        {
            if(rm_obj_seconds > 2)
            {
                rm_obj_seconds -= 2;
                dt_rm_obj.Interval = TimeSpan.FromSeconds(rm_obj_seconds);
            }
            if (obj_seconds > 3)
            {
                obj_seconds -= 3;
                dt_obj.Interval = TimeSpan.FromSeconds(obj_seconds);
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            rm_obj_seconds = 20;
            obj_seconds = 30;

            dt = new DispatcherTimer();
            dt_rm = new DispatcherTimer();
            dt_obj = new DispatcherTimer();
            dt_obj_t = new DispatcherTimer();
            dt_rm_obj = new DispatcherTimer();
            dt_moverm = new DispatcherTimer();
            dt_setseconds = new DispatcherTimer();

            dt.Tick += Dt_Tick;
            dt.Interval = TimeSpan.FromMilliseconds(10);
            dt.Start();

            dt_rm.Tick += Dt_Rm_Tick;
            dt_rm.Interval = TimeSpan.FromSeconds(5);
            dt_rm.Start();

            dt_obj.Tick += Dt_Obj_Tick;
            dt_obj.Interval = TimeSpan.FromSeconds(obj_seconds);
            dt_obj.Start();

            dt_obj_t.Tick += Dt_Obj_T_Tick;
            dt_obj_t.Interval = TimeSpan.FromSeconds(1);
            dt_obj_t.Start();

            dt_rm_obj.Tick += Dt_Rm_Obj_Tick;
            dt_rm_obj.Interval = TimeSpan.FromSeconds(rm_obj_seconds);
            dt_rm_obj.Start();

            dt_moverm.Tick += Move_Rm;
            dt_moverm.Interval = TimeSpan.FromMilliseconds(10);

            dt_setseconds.Tick += Set_Seconds;
            dt_setseconds.Interval = TimeSpan.FromSeconds(60);
            dt_setseconds.Start();
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
            else if (e.Key == Key.Escape)
            {
                //semmi
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
            else if (e.Key == Key.Q)
            {
                dt.Stop();
                dt_rm.Stop();
                dt_obj.Stop();
                dt_obj_t.Stop();
                dt_rm_obj.Stop();
                dt_setseconds.Stop();
                logic.ingamemp.Stop();
                GameOverWindow gameOverWindow = new GameOverWindow();
                gameOverWindow.CloseMainWindow += (sender, eventargs) => this.Close();
                gameOverWindow.Points = logic.Points;
                gameOverWindow.Show();
                
            }
            else if (e.Key == Key.Escape)
            {
                Ingame_Menu ingame_Menu = new Ingame_Menu();
                dt.Stop();
                dt_rm.Stop();
                dt_obj.Stop();
                dt_obj_t.Stop();
                dt_rm_obj.Stop();
                dt_setseconds.Stop();
                if ((logic.main_is_playing_audio==true && logic.task_is_playing_audio == false)||(logic.main_is_playing_audio == false && logic.task_is_playing_audio == true) )
                {
                    logic.ingamemp.Pause();
                    ingame_Menu.ContinueMusic += (sender, eventargs) => logic.ingamemp.Play();
                }
                else
                {
                    ingame_Menu.ContinueMusic += (sender, eventargs) => logic.ingamemp.Pause();
                }
                ingame_Menu.Dt_start += (sender, eventargs) =>
                {
                    dt.Start();
                    dt_rm.Start();
                    dt_obj.Start();
                    dt_obj_t.Start();
                    dt_rm_obj.Start();
                    dt_setseconds.Start();
                };
                ingame_Menu.CloseMainWindow += (sender, eventargs) => this.Close();
                ingame_Menu.ShowDialog();
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
