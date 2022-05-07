using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Moving_Out.Logic
{
    public enum ObjectiveType
    {
        Pizza, Music, Trash, Fish, Dishes, Clean_Picture, Clean_Dinosaur, None, NotFound
    }

    public class GameObjective : GameItem
    {
        static Random r = new Random();

        public ObjectiveType ObjType { get; }
        private int displayWidth;
        private int displayHeight;

        public int Radius { get; set; }
        public System.Drawing.Point Center { get; set; }

        public bool Interactable { get; private set; }
        public int PartCounter { get; set; }
        public int Seconds { get; set; }

        private int areaMoveValue;

        public override Geometry Area
        {
            get
            {
                if (ObjType == ObjectiveType.Pizza)
                {
                    if (PartCounter == 0)
                    {
                        Interactable = false;
                        Center = new System.Drawing.Point((int)(displayWidth / 1.662338) + (int)(displayWidth / 38.4), (int)(displayHeight / 2.21087) - areaMoveValue);
                        return new EllipseGeometry(new Point(Center.X, Center.Y), Radius, Radius);
                    }
                    else if (PartCounter == 1)
                    {
                        Interactable = true;
                        Center = new System.Drawing.Point((int)(displayWidth / 2.269504) + (int)(displayWidth / 64), (int)(displayHeight / 1.13) - areaMoveValue);
                        return new EllipseGeometry(new Point(Center.X, Center.Y), Radius, Radius);
                    }
                    else
                    {
                        Center = new System.Drawing.Point((int)(displayWidth / 1.567347) + (int)(displayWidth / 64), (int)(displayHeight / 10.17) - areaMoveValue);
                        return new EllipseGeometry(new Point(Center.X, Center.Y), Radius, Radius);
                    }
                }
                else if (ObjType == ObjectiveType.Music)
                {
                    Center = new System.Drawing.Point((int)(displayWidth / 12.631579) + (int)(displayWidth / 96), (int)(displayHeight / 2.16383) + (int)(displayHeight / 50.85) - areaMoveValue);
                    return new EllipseGeometry(new Point(Center.X, Center.Y), Radius, Radius);
                }
                else if (ObjType == ObjectiveType.Trash)
                {
                    if (PartCounter == 0)
                    {
                        return new EllipseGeometry(new Point(Center.X, Center.Y - areaMoveValue), Radius, Radius);
                    }
                    else
                    {
                        Center = new System.Drawing.Point((int)(displayWidth / 1.111111) + (int)(displayWidth / 96), (int)(displayHeight / 8.475) + (int)(displayHeight / 20.34) - areaMoveValue);
                        return new EllipseGeometry(new Point(Center.X, Center.Y), Radius, Radius);
                    }
                }
                else if (ObjType == ObjectiveType.Fish)
                {
                    if (PartCounter == 0)
                    {
                        Center = new System.Drawing.Point((int)(displayWidth / 1.665221) - (int)(displayWidth / 48), (int)(displayHeight / 1.432394) - (int)(displayHeight / 11.3) - areaMoveValue);
                        return new EllipseGeometry(new Point(Center.X, Center.Y), Radius, Radius);
                    }
                    else
                    {
                        Center = new System.Drawing.Point((int)(displayWidth / 1.111111) + (int)(displayWidth / 96), (int)(displayHeight / 8.475) + (int)(displayHeight / 20.34) - areaMoveValue);
                        return new EllipseGeometry(new Point(Center.X, Center.Y), Radius, Radius);
                    }
                }
                else if (ObjType == ObjectiveType.Dishes)
                {
                    if (PartCounter == 0)
                    {
                        Center = new System.Drawing.Point((int)(displayWidth / 1.4307) + (int)(displayWidth / 96), (int)(displayHeight / 8.475) + (int)(displayHeight / 50.85) - areaMoveValue);
                        return new EllipseGeometry(new Point(Center.X, Center.Y), Radius, Radius);
                    }
                    else
                    {
                        Center = new System.Drawing.Point((int)(displayWidth / 1.389291) + (int)(displayWidth / 12.8), (int)(displayHeight / 10.17) + (int)(displayHeight / 50.85) - areaMoveValue);
                        return new EllipseGeometry(new Point(Center.X, Center.Y), Radius, Radius);
                    }
                }
                else if (ObjType == ObjectiveType.Clean_Picture)
                {

                    return new EllipseGeometry(new Point(Center.X, Center.Y - areaMoveValue), Radius, Radius);
                }
                else
                {
                    return new EllipseGeometry(new Point(Center.X, Center.Y - areaMoveValue), Radius, Radius);
                }
            }
        }

        public Geometry Objective_Alert_Area
        {
            get
            {
                areaMoveValue = (int)(displayHeight / 21.6);
                var area = Area;
                areaMoveValue = 0;
                return area;
            }
        }

        public Geometry Objective_Texture_Area
        {
            get
            {
                Radius -= (int)(displayWidth / 54.857143);
                var area = Area;
                Radius += (int)(displayWidth / 54.857143);
                return area;
            }
        }

        public Point Objective_Timer_Position()
        {
            if (ObjType == ObjectiveType.Pizza)
            {
                if (PartCounter == 0)
                {
                    Center = new System.Drawing.Point((int)(displayWidth / 1.662338) + (int)(displayWidth / 64), (int)(displayHeight / 2.21087) + (int)(displayHeight / 43.2));
                    return new Point(Center.X, Center.Y);
                }
                else if (PartCounter == 1)
                {
                    Center = new System.Drawing.Point((int)(displayWidth / 2.269504) + (int)(displayWidth / 64) - (int)(displayWidth / 96), (int)(displayHeight / 1.13) + (int)(displayHeight / 43.2));
                    return new Point(Center.X, Center.Y);
                }
                else
                {
                    Center = new System.Drawing.Point((int)(displayWidth / 1.567347) + (int)(displayWidth / 64) - (int)(displayWidth / 96), (int)(displayHeight / 10.17) + (int)(displayHeight / 43.2));
                    return new Point(Center.X, Center.Y);
                }
            }
            else if (ObjType == ObjectiveType.Music)
            {
                Center = new System.Drawing.Point((int)(displayWidth / 12.631579) + (int)(displayWidth / 96) - (int)(displayWidth / 96), (int)(displayHeight / 2.16383) + (int)(displayHeight / 50.85) + (int)(displayHeight / 43.2));
                return new Point(Center.X, Center.Y);
            }
            else if (ObjType == ObjectiveType.Trash)
            {
                if (PartCounter == 0)
                {
                    return new Point(Center.X - (int)(displayWidth / 96), Center.Y + (int)(displayHeight / 43.2));
                }
                else
                {
                    Center = new System.Drawing.Point((int)(displayWidth / 1.111111) - (int)(displayWidth / 64), (int)(displayHeight / 8.475) + (int)(displayHeight / 20.34) + (int)(displayHeight / 43.2));
                    return new Point(Center.X, Center.Y);
                }
            }
            else if (ObjType == ObjectiveType.Fish)
            {
                if (PartCounter == 0)
                {
                    Center = new System.Drawing.Point((int)(displayWidth / 1.665221) - (int)(displayWidth / 48) - (int)(displayWidth / 96), (int)(displayHeight / 1.432394) - (int)(displayHeight / 11.3) + (int)(displayHeight / 43.2));
                    return new Point(Center.X, Center.Y);
                }
                else
                {
                    Center = new System.Drawing.Point((int)(displayWidth / 1.111111), (int)(displayHeight / 8.475) + (int)(displayHeight / 20.34) + (int)(displayHeight / 43.2));
                    return new Point(Center.X, Center.Y);
                }
            }
            else if (ObjType == ObjectiveType.Dishes)
            {
                if (PartCounter == 0)
                {
                    Center = new System.Drawing.Point((int)(displayWidth / 1.4307), (int)(displayHeight / 8.475) + (int)(displayHeight / 50.85) + (int)(displayHeight / 43.2));
                    return new Point(Center.X, Center.Y);
                }
                else
                {
                    Center = new System.Drawing.Point((int)(displayWidth / 1.389291) + (int)(displayWidth / 12.8) - (int)(displayWidth / 96), (int)(displayHeight / 10.17) + (int)(displayHeight / 50.85) + (int)(displayHeight / 43.2));
                    return new Point(Center.X, Center.Y);
                }
            }
            else if (ObjType == ObjectiveType.Clean_Picture)
            {
                return new Point(Center.X - (int)(displayWidth / 96), Center.Y + (int)(displayHeight / 43.2));
            }
            else
            {
                return new Point(Center.X - (int)(displayWidth / 96), Center.Y + (int)(displayHeight / 43.2));
            }
        }

        public GameObjective(ObjectiveType objType, int radius, int displayWidth, int displayHeight, int centerX = 0, int centerY = 0)
        {
            this.ObjType = objType;
            Radius = radius;
            Center = new System.Drawing.Point(centerX, centerY);
            PartCounter = 0;
            Interactable = true;
            this.displayWidth = displayWidth;
            this.displayHeight = displayHeight;
            Seconds = 30;
            areaMoveValue = 0;

            if (objType == ObjectiveType.Clean_Picture)
            {
                int number = r.Next(0, 4);
                if (number == 0) Center = new System.Drawing.Point((int)(displayWidth / 1.14082) + (int)(displayWidth / 192), (int)(displayHeight / 2.511111) - (int)(displayHeight / 50.85));
                else if (number == 1) Center = new System.Drawing.Point((int)(displayWidth / 1.14082) - (int)(displayWidth / 19.2), (int)(displayHeight / 2.511111) - (int)(displayHeight / 50.85));
                else if (number == 2) Center = new System.Drawing.Point((int)(displayWidth / 1.4307) - (int)(displayWidth / 6.4), (int)(displayHeight / 8.475));
                else  Center = new System.Drawing.Point((int)(displayWidth / 1.315068) - (int)(displayWidth / 24), (int)(displayHeight / 1.473913));
            }
            else if (objType == ObjectiveType.Clean_Dinosaur)
            {
                Radius = (int)(displayWidth / 38.4);
                int number = r.Next(0, 3);
                if (number == 0) Center = new System.Drawing.Point((int)(displayWidth / 5.565217) + (int)(displayWidth / 27.428571), (int)(displayHeight / 1.849091) + (int)(displayHeight / 33.9));
                else if (number == 1) Center = new System.Drawing.Point((int)(displayWidth / 6.736842) + (int)(displayWidth / 27.428571), (int)(displayHeight / 1.27125) + (int)(displayHeight / 33.9));
                else Center = new System.Drawing.Point((int)(displayWidth / 3.84) + (int)(displayWidth / 27.428571), (int)(displayHeight / 1.255556) + (int)(displayHeight / 33.9));
            }
        }

        static public IList<string> ObjectiveText(ObjectiveType type)
        {
            List<string> texts = new List<string>();

            switch (type)
            {
                case ObjectiveType.Pizza:
                    texts.Add("Your roommate ordered a pizza, get ready!");
                    texts.Add("The pizza deliver guy has arrived!");
                    texts.Add("Take the pizza to the fridge!");
                    texts.Add("The pizza is spoiled..");
                    break;
                case ObjectiveType.Music:
                    texts.Add("Your roommate turned on the radio, turn it off before your neighbour comes over!");
                    texts.Add("The old Kurvinnyo has arrived..");
                    break;
                case ObjectiveType.Trash:
                    texts.Add("Your roommate threw trash on the ground, pick it up before mosquitoes take over the house!");
                    texts.Add("Drop out the trash!");
                    texts.Add("The mosquito boss is here..");
                    break;
                case ObjectiveType.Fish:
                    texts.Add("A dead fish came up from the drain, pick it up before you die from the smell!");
                    texts.Add("Drop out the fish!");
                    texts.Add("Your nose died..");
                    break;
                case ObjectiveType.Dishes:
                    texts.Add("Your roommate left some unwashed dishes on the table, pick them up before they absorb the fat forever!");
                    texts.Add("Wash the dishes!");
                    texts.Add("R.I.P. dishes..");
                    break;
                case ObjectiveType.Clean_Picture:
                    texts.Add("Wipe off the dust from the paint, before it loses its value!");
                    texts.Add("You became poor..");
                    break;
                case ObjectiveType.Clean_Dinosaur:
                    texts.Add("Wipe of the dust from the dinosaur, before it loses its value!");
                    texts.Add("You became poor..");
                    break;
            }

            return texts;
        }
    }
}