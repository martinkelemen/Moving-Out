using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Moving_Out.Logic
{
    public class MoveLogic : IGameModel
    {
        //public bool Left { get; set; }
        //public bool Right { get; set; }
        //public bool Up { get; set; }
        //public bool Down { get; set; }
        //int speed = 8;

        //public void TimeStep(FrameworkElement player)
        //{
        //    if (Left==true && Canvas.GetLeft(player)>5)
        //    {
        //        Canvas.SetLeft(player, Canvas.GetLeft(player) - speed);
        //    }
        //    if (Right == true && Canvas.GetLeft(player) + (player.Width+20)< Application.Current.MainWindow.Width)
        //    {
        //        Canvas.SetLeft(player, Canvas.GetLeft(player) + speed);
        //    }
        //    if (Up==true && Canvas.GetTop(player)>5)
        //    {
        //        Canvas.SetTop(player, Canvas.GetTop(player) - speed);
        //    }
        //    if (Down == true && Canvas.GetTop(player) + (player.Width *2) < Application.Current.MainWindow.Height)
        //    {
        //        Canvas.SetTop(player, Canvas.GetTop(player) + speed);
        //    }
        //}

        public event EventHandler Changed;

        System.Windows.Size area;

        public IGameControl p { get; }

        public void SetupSizes(System.Windows.Size area)
        {
            this.area = area;
        }

        public MoveLogic()
        {
            p = new Player();
        }

        public enum Controls
        {
            Left, Right, Up, Down, LeftUp, LeftDown, RightUp, RightDown, None
        }

        public void Control(Controls control)
        {
            switch (control)
            {
                case Controls.Left:
                    p.Speed = new Vector(-8, 0);
                    p.Move();
                    break;
                case Controls.Right:
                    p.Speed = new Vector(8, 0);
                    p.Move();
                    break;
                case Controls.Up:
                    p.Speed = new Vector(0, -8);
                    p.Move();
                    break;
                case Controls.Down:
                    p.Speed = new Vector(0, 8);
                    p.Move();
                    break;
                case Controls.LeftUp:
                    p.Speed = new Vector(-8, -8);
                    p.Move();
                    break;
                case Controls.LeftDown:
                    p.Speed = new Vector(-8, 8);
                    p.Move();
                    break;
                case Controls.RightUp:
                    p.Speed = new Vector(8, -8);
                    p.Move();
                    break;
                case Controls.RightDown:
                    p.Speed = new Vector(8, 8);
                    p.Move();
                    break;
                case Controls.None:
                    p.Speed = new Vector(0, 0);
                    p.Move();
                    break;
                default:
                    break;
            }
            Changed?.Invoke(this, null);
        }

    }
}
