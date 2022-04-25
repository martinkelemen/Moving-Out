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
        private MediaPlayer ingamemp;

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

        public bool RoommateAtObjective { get; set; }
        private bool ObjectivesFull { get; set; }

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
            speed = 3;
        }

        public MoveLogic()
        {
            RoommateAtObjective = false;
            ObjectivesFull = false;
            ingamemp = new MediaPlayer();
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

        public void DecreaseSeconds()
        {
            for (int i = 0; i < Objectives.Count(); i++)
            {
                Objectives[i].Seconds--;

                if (Objectives[i].Seconds == 0 && !Objectives[i].Interactable)
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
                if (obj.ObjType == ObjectiveType.Music)
                {
                    ingamemp.Pause();
                    ObjectivesFull = false;
                }
                else if (obj.ObjType == ObjectiveType.Pizza || obj.ObjType == ObjectiveType.Dishes || obj.ObjType == ObjectiveType.Trash)
                {
                    ObjectivesFull = false;
                }

                Objectives.Remove(obj);
            }
        }

        public void RandomObjective()
        {
            int number = r.Next(0, 3);

            if (!(Objectives.Where(t => t.ObjType == ObjectiveType.Fish).Any() && Objectives.Where(t => t.ObjType == ObjectiveType.Clean_Picture).Any()
                && Objectives.Where(t => t.ObjType == ObjectiveType.Clean_Dinosaur).Any()))
            {
                if (number == 0 && !Objectives.Where(t => t.ObjType == ObjectiveType.Fish).Any()) Objectives.Add(new GameObjective(ObjectiveType.Fish, 50, (int)area.Width, (int)area.Height));
                else if (number == 1 && !Objectives.Where(t => t.ObjType == ObjectiveType.Clean_Picture).Any()) Objectives.Add(new GameObjective(ObjectiveType.Clean_Picture, 50, (int)area.Width, (int)area.Height));
                else if (number == 2 && !Objectives.Where(t => t.ObjType == ObjectiveType.Clean_Dinosaur).Any()) Objectives.Add(new GameObjective(ObjectiveType.Clean_Dinosaur, 50, (int)area.Width, (int)area.Height));
                else RandomObjective();
            }
        }

        public ObjectiveType RoommateObjective()
        {
            int number = r.Next(0, 4);
            //int number = 1;

            if (!(Objectives.Where(t => t.ObjType == ObjectiveType.Pizza).Any() && Objectives.Where(t => t.ObjType == ObjectiveType.Music).Any() &&
                Objectives.Where(t => t.ObjType == ObjectiveType.Trash).Any() && Objectives.Where(t => t.ObjType == ObjectiveType.Dishes).Any()))
            {
                if (number == 0 && !Objectives.Where(t => t.ObjType == ObjectiveType.Pizza).Any())
                {
                    return ObjectiveType.Pizza;
                }
                else if (number == 1 && !Objectives.Where(t => t.ObjType == ObjectiveType.Music).Any())
                {
                    return ObjectiveType.Music;
                }
                else if (number == 2 && !Objectives.Where(t => t.ObjType == ObjectiveType.Trash).Any())
                {
                    return ObjectiveType.Trash;
                }
                else if (number == 3 && !Objectives.Where(t => t.ObjType == ObjectiveType.Dishes).Any())
                {
                    return ObjectiveType.Dishes;
                }
                else
                {
                    return ObjectiveType.NotFound;
                }
            }
            else
            {
                ObjectivesFull = true;
                return ObjectiveType.None;
            }
        }

        public void MoveRoommateToObjective(ObjectiveType type, GameObjective tmp)
        {
            if (type == ObjectiveType.Trash)
            {
                if (!(Roommate as GameItem).IsCollision(Wall))
                {
                    Objectives.Add(new GameObjective(type, 50, (int)area.Width, (int)area.Height, Roommate.Center.X, Roommate.Center.Y));
                    Roommate.Speed = new Vector(0, 0);
                    RoommateAtObjective = true;
                }
            }
            else
            {
                if (!(Roommate as GameItem).IsCollision(tmp))
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
                else
                {
                    Objectives.Add(new GameObjective(type, 50, (int)area.Width, (int)area.Height));
                    if (type == ObjectiveType.Music)
                    {
                        ingamemp.Open(new Uri(System.IO.Path.Combine("Audio", "polizei.mp3"), UriKind.RelativeOrAbsolute));
                        ingamemp.Volume = 0.3;
                        ingamemp.Play();
                    }
                    Roommate.Speed = new Vector(0, 0);
                    RoommateAtObjective = true;
                }
            }
        }

        public void ChangeRoommateDirection()
        {
            int newDirection_number = r.Next(0, 201);

            if (newDirection_number <= 25)
            {
                Roommate.Speed = new Vector(speed * -1 / 2, 0);
            }
            else if (newDirection_number <= 50)
            {
                Roommate.Speed = new Vector(speed / 2, 0);
            }
            else if (newDirection_number <= 75)
            {
                Roommate.Speed = new Vector(speed * -1 / 2, speed / 2);
            }
            else if (newDirection_number <= 100)
            {
                Roommate.Speed = new Vector(speed / 2, speed / 2);
            }
            else if (newDirection_number <= 125)
            {
                Roommate.Speed = new Vector(speed * -1 / 2, speed * -1 / 2);
            }
            else if (newDirection_number <= 150)
            {
                Roommate.Speed = new Vector(speed * -1 / 2, speed / 2);
            }
            else if (newDirection_number <= 175)
            {
                Roommate.Speed = new Vector(0, speed * -1 / 2);
            }
            else
            {
                Roommate.Speed = new Vector(0, speed / 2);
            }
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

            if (Roommate.Center.X < (int)(area.Width / 12.631579) || Roommate.Center.X > (int)(area.Width / 1.078652)
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
