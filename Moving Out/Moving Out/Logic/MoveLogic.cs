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
    public class StatusChangedEventArgs : EventArgs
    {
        public string Message { get; set; }

        public StatusChangedEventArgs(string message)
        {
            Message = message;
        }
    }

    public class MoveLogic : IGameModel
    {
        static Random r = new Random();

        public MediaPlayer ingamemp;
        public bool task_is_playing_audio;
        public bool main_is_playing_audio;
        TimeSpan mainpositon;
        TimeSpan taskposition;

        public bool Left { get; set; }
        public bool Right { get; set; }
        public bool Up { get; set; }
        public bool Down { get; set; }

        private double speed;

        public event EventHandler Changed;
        public event EventHandler RoommateMoveChanged;
        public event EventHandler PizzaGuyMoveChanged;
        public event EventHandler PizzaArrived;
        public event EventHandler NeighbourArrived;
        public event EventHandler GameEnded;

        System.Windows.Size area;

        public IGameControl Player { get; set; }
        public IGameControl Roommate { get; set; }
        public IGameControl PizzaGuy { get; set; }
        public IGameControl Neighbour { get; set; }
        public Wall Wall { get; set; }
        public List<GameObjective> Objectives { get; set; }

        public bool RoommateAtObjective { get; set; }
        public bool PlayerAtObjective { get; set; }
        public bool PizzaGuyAtObjective { get; set; }
        public bool PizzaGuyAtStreet { get; set; }
        public bool NeighbourAtDoor { get; set; }
        private bool ObjectivesFull { get; set; }
        public int Points { get; set; }

        private void Media_Ended(object sender, EventArgs e)
        {
            ingamemp.Position = TimeSpan.Zero;
            ingamemp.Play();
            ingamemp.Volume = 0.2;
        }

        public void SetupSizes(System.Windows.Size area)
        {
            this.area = area;
        }

        public void SetupItems()
        {
            Wall = new Wall((int)area.Width, (int)area.Height);
            Player = new Player((int)(area.Width / 2.206897), (int)(area.Height / 1.168966), (int)(area.Width / 128));
            Roommate = new Roommate((int)(area.Width / 4.8), (int)(area.Height / 2.5425), (int)(area.Width / 128));
            PizzaGuy = new Player((int)(area.Width / 2.206897), (int)(area.Height / 0.981818), (int)(area.Width / 128)); //ajto 870, 1010     kinn 870, 1100
            Neighbour = new Player((int)(area.Width / 2.133333), (int)(area.Height / 0.981818), (int)(area.Width / 128)); //ajto 900, 1010    kinn 900, 1100
            Objectives = new List<GameObjective>();
            speed = (int)(area.Width / 640);
        }

        public MoveLogic()
        {
            RoommateAtObjective = false;
            PizzaGuyAtObjective = false;
            PizzaGuyAtStreet = true;
            NeighbourAtDoor = false;
            ObjectivesFull = false;
            ingamemp = new MediaPlayer();
            ingamemp.Open(new Uri(System.IO.Path.Combine("Audio", "doomermenu.mp3"), UriKind.RelativeOrAbsolute));
            ingamemp.MediaEnded += new EventHandler(Media_Ended);
            ingamemp.Play();
            main_is_playing_audio = true;
            Points = 0;
        }

        public void Interact()
        {
            for (int i = 0; i < Objectives.Count(); i++)
            {
                if ((Player as GameItem).IsCollision(Objectives[i]) && Objectives[i].Interactable)
                {
                    if (Objectives[i].ObjType == ObjectiveType.Pizza && Objectives[i].PartCounter == 1)
                    {
                        PizzaGuyMoveChanged?.Invoke(this, new StatusChangedEventArgs("down"));
                        PizzaArrived?.Invoke(this, null);
                    }
                    IncreasePartCounter(Objectives[i]);
                    Points += 10;
                }
            }
        }

        public void DecreaseSeconds()
        {
            for (int i = 0; i < Objectives.Count(); i++)
            {
                Objectives[i].Seconds--;

                if(!Objectives[i].Interactable && Objectives[i].Seconds == 3)
                {
                    PizzaGuyMoveChanged?.Invoke(this, new StatusChangedEventArgs("up"));
                    PizzaArrived?.Invoke(this, null);
                }

                else if (!Objectives[i].Interactable && Objectives[i].Seconds == 0)
                {
                    IncreasePartCounter(Objectives[i]);
                    Objectives[i].Seconds = 30;
                }
                else if (Objectives[i].Seconds == 0)
                {
                    //todo game over
                    if (Objectives[i].ObjType == ObjectiveType.Music)
                    {
                        NeighbourArrived?.Invoke(this, null);
                    }
                    else
                    {
                        var objTexts = GameObjective.ObjectiveText(Objectives[i].ObjType);
                        GameEnded?.Invoke(this, new StatusChangedEventArgs(objTexts.Last()));
                    }
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
                    taskposition = ingamemp.Position;
                    ingamemp.Stop();
                    ingamemp.Close();
                    ingamemp.Open(new Uri(System.IO.Path.Combine("Audio", "doomermenu.mp3"), UriKind.RelativeOrAbsolute));
                    ingamemp.Position = mainpositon;
                    ingamemp.Play();
                    ObjectivesFull = false;
                    task_is_playing_audio = false;
                    main_is_playing_audio = true;
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
                if (number == 0 && !Objectives.Where(t => t.ObjType == ObjectiveType.Fish).Any()) Objectives.Add(new GameObjective(ObjectiveType.Fish, (int)(area.Width / 38.4), (int)area.Width, (int)area.Height));
                else if (number == 1 && !Objectives.Where(t => t.ObjType == ObjectiveType.Clean_Picture).Any()) Objectives.Add(new GameObjective(ObjectiveType.Clean_Picture, (int)(area.Width / 38.4), (int)area.Width, (int)area.Height));
                else if (number == 2 && !Objectives.Where(t => t.ObjType == ObjectiveType.Clean_Dinosaur).Any()) Objectives.Add(new GameObjective(ObjectiveType.Clean_Dinosaur, (int)(area.Width / 38.4), (int)area.Width, (int)area.Height));
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
                    Objectives.Add(new GameObjective(type, (int)(area.Width / 38.4), (int)area.Width, (int)area.Height, Roommate.Center.X, Roommate.Center.Y));
                    Roommate.Speed = new Vector(0, 0);
                    RoommateAtObjective = true;
                }
            }
            else
            {
                if (!(Roommate as GameItem).IsCollision(tmp))
                {
                    if (Roommate.Center.X > tmp.Center.X && Roommate.Center.Y > tmp.Center.Y)
                    {
                        Roommate.Speed = new Vector(speed * -1 / 2, speed * -1 / 2);
                        Roommate.Direction = "up";
                    }
                    else if (Roommate.Center.X < tmp.Center.X && Roommate.Center.Y > tmp.Center.Y)
                    {
                        Roommate.Speed = new Vector(speed / 2, speed * -1 / 2);
                        Roommate.Direction = "up";
                    }
                    else if (Roommate.Center.X < tmp.Center.X && Roommate.Center.Y < tmp.Center.Y)
                    {
                        Roommate.Speed = new Vector(speed / 2, speed / 2);
                        Roommate.Direction = "down";
                    }
                    else if (Roommate.Center.X > tmp.Center.X && Roommate.Center.Y < tmp.Center.Y)
                    {
                        Roommate.Speed = new Vector(speed * -1 / 2, speed / 2);
                        Roommate.Direction = "down";
                    }
                    else if (Roommate.Center.X == tmp.Center.X && Roommate.Center.Y < tmp.Center.Y)
                    {
                        Roommate.Speed = new Vector(0, speed / 2);
                        Roommate.Direction = "down";
                    }
                    else if (Roommate.Center.X == tmp.Center.X && Roommate.Center.Y > tmp.Center.Y)
                    {
                        Roommate.Speed = new Vector(0, speed * -1 / 2);
                        Roommate.Direction = "up";
                    }
                    else if (Roommate.Center.X > tmp.Center.X && Roommate.Center.Y == tmp.Center.Y)
                    {
                        Roommate.Speed = new Vector(speed * -1 / 2, 0);
                        Roommate.Direction = "left";
                    }
                    else if (Roommate.Center.X < tmp.Center.X && Roommate.Center.Y == tmp.Center.Y)
                    {
                        Roommate.Speed = new Vector(speed / 2, 0);
                        Roommate.Direction = "right";
                    }
                    RoommateMoveChanged?.Invoke(this, new StatusChangedEventArgs(Roommate.Direction));
                }
                else
                {
                    Objectives.Add(new GameObjective(type, (int)(area.Width / 38.4), (int)area.Width, (int)area.Height));
                    if (type == ObjectiveType.Music)
                    {
                        mainpositon = ingamemp.Position;
                        ingamemp.Stop();
                        ingamemp.Close();
                        ingamemp.Open(new Uri(System.IO.Path.Combine("Audio", "polizei.mp3"), UriKind.RelativeOrAbsolute));
                        ingamemp.Position = taskposition;
                        ingamemp.Volume = 0.3;
                        ingamemp.Play();
                        task_is_playing_audio = true;
                        main_is_playing_audio = false;
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
                Roommate.Direction = "left";
            }
            else if (newDirection_number <= 50)
            {
                Roommate.Speed = new Vector(speed / 2, 0);
                Roommate.Direction = "right";
            }
            else if (newDirection_number <= 75)
            {
                Roommate.Speed = new Vector(speed * -1 / 2, speed / 2);
                Roommate.Direction = "down";
            }
            else if (newDirection_number <= 100)
            {
                Roommate.Speed = new Vector(speed / 2, speed / 2);
                Roommate.Direction = "down";
            }
            else if (newDirection_number <= 125)
            {
                Roommate.Speed = new Vector(speed * -1 / 2, speed * -1 / 2);
                Roommate.Direction = "up";
            }
            else if (newDirection_number <= 150)
            {
                Roommate.Speed = new Vector(speed / 2, speed * -1 / 2);
                Roommate.Direction = "up";
            }
            else if (newDirection_number <= 175)
            {
                Roommate.Speed = new Vector(0, speed * -1 / 2);
                Roommate.Direction = "up";
            }
            else
            {
                Roommate.Speed = new Vector(0, speed / 2);
                Roommate.Direction = "down";
            }
            RoommateMoveChanged?.Invoke(this, new StatusChangedEventArgs(Roommate.Direction));
        }

        public void MovePizzaGuy()
        {
            if (PizzaGuyAtStreet)
            {
                if (PizzaGuy.Center.Y > (int)(area.Height / 1.069307))
                {
                    PizzaGuy.Speed = new Vector(0, speed * -1 / 2);
                }
                else
                {
                    PizzaGuy.Speed = new Vector(0, 0);
                    PizzaGuyAtObjective = true;
                    PizzaGuyAtStreet = false;
                }
            }
            else
            {
                if (PizzaGuy.Center.Y < (int)(area.Height / 0.981818))
                {
                    PizzaGuy.Speed = new Vector(0, speed / 2);
                }
                else
                {
                    PizzaGuy.Speed = new Vector(0, 0);
                    PizzaGuyAtObjective = true;
                    PizzaGuyAtStreet = true;
                }
            }
        }

        public void MoveNeighbour()
        {
            if (Neighbour.Center.Y > (int)(area.Height / 1.069307))
            {
                Neighbour.Speed = new Vector(0, speed * -1 / 3);
            }
            else
            {
                Neighbour.Speed = new Vector(0, 0);
                NeighbourAtDoor = true;
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

                if (Roommate.Direction == "up") Roommate.Direction = "down";
                else if (Roommate.Direction == "down") Roommate.Direction = "up";
                else if (Roommate.Direction == "left") Roommate.Direction = "right";
                else Roommate.Direction = "left";

                RoommateMoveChanged?.Invoke(this, new StatusChangedEventArgs(Roommate.Direction));
            }

            Roommate.Move();
            PizzaGuy.Move();
            Neighbour.Move();

            int count = 0;
            for (int i = 0; i < Objectives.Count(); i++)
            {
                if ((Player as GameItem).IsCollision(Objectives[i]) && Objectives[i].Interactable)
                {
                    PlayerAtObjective = true;
                    count++;
                }
            }
            if (count == 0) PlayerAtObjective = false;

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
