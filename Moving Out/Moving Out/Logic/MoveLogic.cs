using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Moving_Out.Logic
{
    public class MoveLogic : IGameModel
    {
        static Random r = new Random();
        private MediaPlayer ingamemp = new MediaPlayer();
        
        public bool Left { get; set; }
        public bool Right { get; set; }
        public bool Up { get; set; }
        public bool Down { get; set; }

        private double speed;

        public event EventHandler Changed;
        System.Windows.Size area;

        public IGameControl Player { get; set; }
        public IGameControl Roommate { get; set; }
        public Wall Wall { get; set; }
        public List<GameObjective> Objectives { get; set; }

        public void SetupSizes(System.Windows.Size area)
        {
            this.area = area;
        }

        public void SetupItems()
        {
            Wall = new Wall((int)area.Width, (int)area.Height);
            Player = new Player((int)(area.Width / 2.206897), (int)(area.Height / 1.168966), (int)(area.Width / 128));
            Roommate = new Roommate((int)(area.Width / 4.8), (int)(area.Height / 2.5425), (int)(area.Width / 128));
            Objectives = new List<GameObjective>();
            speed = 8;
        }

        public MoveLogic()
        {
            
        }

        public void Interact()
        {
            for (int i = 0; i < Objectives.Count(); i++)
            {
                if ((Player as GameItem).IsCollision(Objectives[i]) && Objectives[i].Interactable)
                {
                    IncreasePartCounter(Objectives[i]);
                }
            }
        }

        public void CheckMusic()
        {
            for (int i = 0; i < Objectives.Count(); i++)
            {
                if (ingamemp.Source == null && Objectives[i].ObjType == ObjectiveType.Music)
                {
                    ingamemp.Open(new Uri(System.IO.Path.Combine("Audio", "polizei.mp3"), UriKind.RelativeOrAbsolute));
                    ingamemp.Play();
                    ingamemp.Volume = 0.3;
                }
            }
        }

        public void DecreaseSeconds()
        {
            for (int i = 0; i < Objectives.Count(); i++)
            {
                Objectives[i].Seconds--;

                if(Objectives[i].Seconds == 0 && !Objectives[i].Interactable)
                {
                    IncreasePartCounter(Objectives[i]);
                    Objectives[i].Seconds = 30;
                }
                else
                {
                    //todo game over
                }
            }
        }

        private void IncreasePartCounter(GameObjective obj)
        {
            obj.PartCounter++;
            if ((obj.PartCounter + 1) == GameObjective.ObjectiveText(obj.ObjType).Count())
            {
                Objectives.Remove(obj);
            }
            if ((obj.PartCounter + 1) == GameObjective.ObjectiveText(obj.ObjType).Count() && obj.ObjType == ObjectiveType.Music)
            {
                Objectives.Remove(obj);
                ingamemp.Pause();
            }
        }

        public void RandomObjective()
        {
            int number = r.Next(0, 3);

            if(!(Objectives.Where(t => t.ObjType == ObjectiveType.Fish).Any() && Objectives.Where(t => t.ObjType == ObjectiveType.Clean_Picture).Any() 
                && Objectives.Where(t => t.ObjType == ObjectiveType.Clean_Dinosaur).Any()))
            {
                if (number == 0 && !Objectives.Where(t => t.ObjType == ObjectiveType.Fish).Any()) Objectives.Add(new GameObjective(ObjectiveType.Fish, 50, (int)area.Width, (int)area.Height));
                else if (number == 1 && !Objectives.Where(t => t.ObjType == ObjectiveType.Clean_Picture).Any()) Objectives.Add(new GameObjective(ObjectiveType.Clean_Picture, 50, (int)area.Width, (int)area.Height));
                else if (number == 2 && !Objectives.Where(t => t.ObjType == ObjectiveType.Clean_Dinosaur).Any()) Objectives.Add(new GameObjective(ObjectiveType.Clean_Dinosaur, 50, (int)area.Width, (int)area.Height));
                else RandomObjective();
            }
        }

        public void RoommateObjective()
        {
            //int number = r.Next(0, 4);
            int number = 1;

            if(!(Objectives.Where(t => t.ObjType == ObjectiveType.Pizza).Any() && Objectives.Where(t => t.ObjType == ObjectiveType.Music).Any() &&
                Objectives.Where(t => t.ObjType == ObjectiveType.Trash).Any() && Objectives.Where(t => t.ObjType == ObjectiveType.Dishes).Any()))
            {
                if (number == 0 && !Objectives.Where(t => t.ObjType == ObjectiveType.Pizza).Any())
                {
                    MoveRoommateToObjective(ObjectiveType.Pizza);
                    Objectives.Add(new GameObjective(ObjectiveType.Pizza, 50, (int)area.Width, (int)area.Height));
                }
                else if (number == 1 && !Objectives.Where(t => t.ObjType == ObjectiveType.Music).Any())
                {
                    MoveRoommateToObjective(ObjectiveType.Music);
                    Objectives.Add(new GameObjective(ObjectiveType.Music, 50, (int)area.Width, (int)area.Height));
                }
                else if (number == 2 && !Objectives.Where(t => t.ObjType == ObjectiveType.Trash).Any())
                {
                    MoveRoommateToObjective(ObjectiveType.Trash);
                    Objectives.Add(new GameObjective(ObjectiveType.Trash, 50, (int)area.Width, (int)area.Height, Roommate.Center.X, Roommate.Center.Y));
                }
                else if (number == 3 && !Objectives.Where(t => t.ObjType == ObjectiveType.Dishes).Any())
                {
                    MoveRoommateToObjective(ObjectiveType.Dishes);
                    Objectives.Add(new GameObjective(ObjectiveType.Dishes, 50, (int)area.Width, (int)area.Height));
                }
                else
                {
                    RoommateObjective();
                }
            }
        }

        private void MoveRoommateToObjective(ObjectiveType type)
        {
            GameObjective tmp;
            if (type == ObjectiveType.Trash)
            {
                while ((Roommate as GameItem).IsCollision(Wall))
                {
                    ChangeRoommateDirection();
                    Thread.Sleep(5000);
                }
            }
            else
            {
                tmp = new GameObjective(type, 30, (int)area.Width, (int)area.Height);

                while (!(Roommate as GameItem).IsCollision(tmp))
                {
                    if (Roommate.Center.X > tmp.Center.X && Roommate.Center.Y > tmp.Center.Y) Roommate.Speed = new Vector(speed * -1 / 2, speed * -1 / 2);
                    else if (Roommate.Center.X < tmp.Center.X && Roommate.Center.Y > tmp.Center.Y) Roommate.Speed = new Vector(speed / 2, speed * -1 / 2);
                    else if (Roommate.Center.X < tmp.Center.X && Roommate.Center.Y < tmp.Center.Y) Roommate.Speed = new Vector(speed / 2, speed / 2);
                    else if (Roommate.Center.X > tmp.Center.X && Roommate.Center.Y < tmp.Center.Y) Roommate.Speed = new Vector(speed * -1 / 2, speed / 2);
                    else if (Roommate.Center.X == tmp.Center.X && Roommate.Center.Y < tmp.Center.Y) Roommate.Speed = new Vector(0, speed / 2);
                    else if (Roommate.Center.X == tmp.Center.X && Roommate.Center.Y > tmp.Center.Y) Roommate.Speed = new Vector(0, speed * -1 / 2);
                    else if (Roommate.Center.X > tmp.Center.X && Roommate.Center.Y == tmp.Center.Y) Roommate.Speed = new Vector(speed * -1 / 2, 0);
                    else if (Roommate.Center.X < tmp.Center.X && Roommate.Center.Y == tmp.Center.Y) Roommate.Speed = new Vector(speed / 2, 0);
                }
            }
            Roommate.Speed = new Vector(0, 0);
        }

        public void ChangeRoommateDirection()
        {
            int newDirection_number = r.Next(0, 201);

            if (newDirection_number <= 25)
            {
                Roommate.Speed = new Vector(speed * -1/2, 0);
            }
            else if (newDirection_number <= 50)
            {
                Roommate.Speed = new Vector(speed/2, 0);
            }
            else if (newDirection_number <= 75)
            {
                Roommate.Speed = new Vector(speed *-1/2, speed/2);
            }
            else if (newDirection_number <= 100)
            {
                Roommate.Speed = new Vector(speed/2, speed/2);
            }
            else if (newDirection_number <= 125)
            {
                Roommate.Speed = new Vector(speed*-1/2, speed*-1/2);
            }
            else if (newDirection_number <= 150)
            {
                Roommate.Speed = new Vector(speed*-1/2, speed/2);
            }
            else if (newDirection_number <= 175)
            {
                Roommate.Speed = new Vector(0, speed*-1/2);
            }
            else
            {
                Roommate.Speed = new Vector(0, speed/2);
            }
            //newObjective(ObjectiveType.None);
        }

        public void TimeStep()
        {
            if (TestMove(new Player(Player.Center.X, Player.Center.Y, Player.Radius)))
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

            if(Roommate.Center.X < (int)(area.Width / 12.631579) || Roommate.Center.X > (int)(area.Width / 1.078652) 
                || Roommate.Center.Y < (int)(area.Height / 8.843478) || Roommate.Center.Y > (int)(area.Height / 1.13))
            {
                Roommate.Speed = new Vector(Roommate.Speed.X * -1, Roommate.Speed.Y * -1);
            }

            Roommate.Move();

            Changed?.Invoke(this, null);
        }

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
