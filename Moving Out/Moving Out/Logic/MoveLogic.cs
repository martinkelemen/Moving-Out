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
        public bool Left { get; set; }
        public bool Right { get; set; }
        public bool Up { get; set; }
        public bool Down { get; set; }

        private double speed;

        public event EventHandler Changed;
        System.Windows.Size area;

        public IGameControl Player { get; set; }
        public Wall Wall { get; set; }

        public void SetupSizes(System.Windows.Size area)
        {
            this.area = area;
        }

        public void SetupItems()
        {
            Wall = new Wall((int)area.Width, (int)area.Height);
            Player = new Player((int)(area.Width / 2.206897), (int)(area.Height / 1.168966), (int)(area.Width / 128));
            speed = 4;
        }

        //public void ChangeSize(Size newArea)
        //{
        //    Player.Center = new System.Drawing.Point((int)(newArea.Width / (area.Width / Player.Center.X)), (int)(newArea.Height / (area.Height/Player.Center.Y)));
        //    Player.Radius = (int)(newArea.Width / (area.Width / Player.Radius));
        //    speed = (int)(newArea.Width / (area.Width / speed));
        //    area = newArea;
        //}

        public MoveLogic()
        {
            
        }

        public void TimeStep()
        {
            if (TestMove(new Player(Player.Center.X, Player.Center.Y, 15)))
            {
                if (Left == true)
                {
                    Player.Speed = new Vector(speed * -1, 0);
                    Player.Move();
                }
                if (Right == true)
                {
                    Player.Speed = new Vector(speed, 0);
                    Player.Move();
                }
                if (Up == true)
                {
                    Player.Speed = new Vector(0, speed * -1);
                    Player.Move();
                }
                if (Down == true)
                {
                    Player.Speed = new Vector(0, speed);
                    Player.Move();
                }
            }

            Changed?.Invoke(this, null);
        }

        //public enum Controls
        //{
        //    Left, Right, Up, Down, LeftUp, LeftDown, RightUp, RightDown, None
        //}


        //public void Control(Controls control)
        //{   
        //    if(TestMove(new Player(Player.Center.X, Player.Center.Y, 15), control))
        //    {
        //        switch (control)
        //        {
        //            case Controls.Left:
        //                Player.Speed = new Vector(-8, 0);
        //                Player.Move();
        //                break;
        //            case Controls.Right:
        //                Player.Speed = new Vector(8, 0);
        //                Player.Move();
        //                break;
        //            case Controls.Up:
        //                Player.Speed = new Vector(0, -8);
        //                Player.Move();
        //                break;
        //            case Controls.Down:
        //                Player.Speed = new Vector(0, 8);
        //                Player.Move();
        //                break;
        //            case Controls.LeftUp:
        //                Player.Speed = new Vector(-8, -8);
        //                Player.Move();
        //                break;
        //            case Controls.LeftDown:
        //                Player.Speed = new Vector(-8, 8);
        //                Player.Move();
        //                break;
        //            case Controls.RightUp:
        //                Player.Speed = new Vector(8, -8);
        //                Player.Move();
        //                break;
        //            case Controls.RightDown:
        //                Player.Speed = new Vector(8, 8);
        //                Player.Move();
        //                break;
        //            case Controls.None:
        //                Player.Speed = new Vector(0, 0);
        //                Player.Move();
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    Changed?.Invoke(this, null);
        //}

        private bool TestMove(IGameControl testPlayer)
        {
            if (Left == true)
            {
                testPlayer.Speed = new Vector(speed * -1, 0);
                testPlayer.Move();
            }
            if (Right == true)
            {
                testPlayer.Speed = new Vector(speed, 0);
                testPlayer.Move();
            }
            if (Up == true)
            {
                testPlayer.Speed = new Vector(0, speed * -1);
                testPlayer.Move();
            }
            if (Down == true)
            {
                testPlayer.Speed = new Vector(0, speed);
                testPlayer.Move();
            }

            if ((testPlayer as GameItem).IsCollision(Wall))
            {
                return false;
            }
            else return true;
        }

    }
}
