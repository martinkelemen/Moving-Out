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
            Player = new Player(870, 870, 15);
        }

        public MoveLogic()
        {
            
        }

        public enum Controls
        {
            Left, Right, Up, Down, LeftUp, LeftDown, RightUp, RightDown, None
        }

        public void Control(Controls control)
        {   
            if(TestMove(new Player(Player.Center.X, Player.Center.Y, 15), control))
            {
                switch (control)
                {
                    case Controls.Left:
                        Player.Speed = new Vector(-8, 0);
                        Player.Move();
                        break;
                    case Controls.Right:
                        Player.Speed = new Vector(8, 0);
                        Player.Move();
                        break;
                    case Controls.Up:
                        Player.Speed = new Vector(0, -8);
                        Player.Move();
                        break;
                    case Controls.Down:
                        Player.Speed = new Vector(0, 8);
                        Player.Move();
                        break;
                    case Controls.LeftUp:
                        Player.Speed = new Vector(-8, -8);
                        Player.Move();
                        break;
                    case Controls.LeftDown:
                        Player.Speed = new Vector(-8, 8);
                        Player.Move();
                        break;
                    case Controls.RightUp:
                        Player.Speed = new Vector(8, -8);
                        Player.Move();
                        break;
                    case Controls.RightDown:
                        Player.Speed = new Vector(8, 8);
                        Player.Move();
                        break;
                    case Controls.None:
                        Player.Speed = new Vector(0, 0);
                        Player.Move();
                        break;
                    default:
                        break;
                }
            }
            Changed?.Invoke(this, null);
        }

        private bool TestMove(IGameControl testPlayer, Controls control)
        {
            switch (control)
            {
                case Controls.Left:
                    testPlayer.Speed = new Vector(-8, 0);
                    testPlayer.Move();
                    break;
                case Controls.Right:
                    testPlayer.Speed = new Vector(8, 0);
                    testPlayer.Move();
                    break;
                case Controls.Up:
                    testPlayer.Speed = new Vector(0, -8);
                    testPlayer.Move();
                    break;
                case Controls.Down:
                    testPlayer.Speed = new Vector(0, 8);
                    testPlayer.Move();
                    break;
                case Controls.LeftUp:
                    testPlayer.Speed = new Vector(-8, -8);
                    testPlayer.Move();
                    break;
                case Controls.LeftDown:
                    testPlayer.Speed = new Vector(-8, 8);
                    testPlayer.Move();
                    break;
                case Controls.RightUp:
                    testPlayer.Speed = new Vector(8, -8);
                    testPlayer.Move();
                    break;
                case Controls.RightDown:
                    testPlayer.Speed = new Vector(8, 8);
                    testPlayer.Move();
                    break;
                case Controls.None:
                    testPlayer.Speed = new Vector(0, 0);
                    testPlayer.Move();
                    break;
                default:
                    break;
            }

            if ((testPlayer as GameItem).IsCollision(Wall))
            {
                return false;
            }
            else return true;
        }

    }
}
