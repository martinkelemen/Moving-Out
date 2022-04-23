using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Moving_Out.Logic
{
    public class GameObjective : GameItem
    {
        public enum ObjectiveType
        {
            Pizza, Music, Trash, Fish, Dishes, Clean_Picture, Clean_Dinosaur
        }

        private ObjectiveType objType;

        public int Radius { get; set; }
        public System.Drawing.Point Center { get; set; }

        public override Geometry Area
        {
            get
            {
                return new EllipseGeometry(new Point(Center.X, Center.Y), Radius, Radius);
            }
        }

        public GameObjective(ObjectiveType objType, int centerX, int centerY, int radius)
        {
            this.objType = objType;
            Radius = radius;
            Center = new System.Drawing.Point(centerX, centerY);
        }

        public IList<string> ObjectiveText()
        {
            List<string> texts = new List<string>();

            switch (objType)
            {
                case ObjectiveType.Pizza:
                    texts.Add("Your roommate ordered a pizza, get ready!");
                    texts.Add("The pizza deliver guy has arrived!");
                    texts.Add("Take the pizza to the fridge!");
                    texts.Add("The pizza cooled down..");
                    break;
                case ObjectiveType.Music:
                    texts.Add("Your roommate turned on the radio, turn it off before your neighbour comes over!");
                    texts.Add("The old kurvinnyo has arrived..");
                    break;
                case ObjectiveType.Trash:
                    texts.Add("Your roommate threw trash on the ground, pick it up before mosquitoes take over the house!");
                    texts.Add("Drop the trash out!");
                    texts.Add("The mosquito boss is here..");
                    break;
                case ObjectiveType.Fish:
                    texts.Add("A dead fish came up from the drain, pick it up before you die from the smell!");
                    texts.Add("Drop the fish out quick!");
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