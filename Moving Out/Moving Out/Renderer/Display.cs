using Moving_Out.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Moving_Out.Renderer
{
    public class Display : FrameworkElement
    {
        Size area;
        IGameModel model;

        Brush last;
        Brush last_standing;
        int characterBrushCounter;
        string roommateBrushDirection;
        string pizzaGuyBrushDirection;

        public void SetupSizes(Size area)
        {
            this.area = area;
            this.InvalidateVisual();
        }

        public void SetupModel(IGameModel model)
        {
            this.model = model;
            this.model.Changed += (sender, eventargs) => this.InvalidateVisual();
            this.model.RoommateMoveChanged += ChangeRoommateBrush;
            this.model.PizzaGuyMoveChanged += ChangePizzaGuyBrush;
        }

        private void ChangeRoommateBrush(object sender, EventArgs e)
        {
            if ((e as StatusChangedEventArgs).Message == "up") roommateBrushDirection = "up";
            else if ((e as StatusChangedEventArgs).Message == "down") roommateBrushDirection = "down";
            else if ((e as StatusChangedEventArgs).Message == "left") roommateBrushDirection = "left";
            else roommateBrushDirection = "right";
        }

        private void ChangePizzaGuyBrush(object sender, EventArgs e)
        {
            if ((e as StatusChangedEventArgs).Message == "up") pizzaGuyBrushDirection = "up";
            else if ((e as StatusChangedEventArgs).Message == "down") pizzaGuyBrushDirection = "down";
        }

        public Display()
        {
            last = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "standing.png"), UriKind.RelativeOrAbsolute)));
            last_standing = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "standing.png"), UriKind.RelativeOrAbsolute)));
            characterBrushCounter = 0;
            roommateBrushDirection = "down";
            pizzaGuyBrushDirection = "up";
        }

        public Brush HouseBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "thumbnail.png"), UriKind.RelativeOrAbsolute)));
            }
        }

        public Brush Character_Brush
        {
            get
            {
                if (model.Down == true)
                {
                    characterBrushCounter++;
                    if (characterBrushCounter % 40 == 0)
                    {
                        characterBrushCounter = 0;
                        last = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "standing.png"), UriKind.RelativeOrAbsolute)));
                        last_standing = last;
                    }
                    else if (characterBrushCounter % 40 == 10)
                    {
                        last = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "running_front.png"), UriKind.RelativeOrAbsolute)));
                    }
                    else if (characterBrushCounter % 40 == 20)
                    {
                        last = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "standing.png"), UriKind.RelativeOrAbsolute)));
                        last_standing = last;
                    }
                    else if (characterBrushCounter % 40 == 30)
                    {
                        last = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "running_front_v2.png"), UriKind.RelativeOrAbsolute)));
                    }
                }
                else if (model.Up == true)
                {
                    characterBrushCounter++;
                    if (characterBrushCounter % 40 == 0)
                    {
                        characterBrushCounter = 0;
                        last = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "standing_back.png"), UriKind.RelativeOrAbsolute)));
                        last_standing = last;
                    }
                    else if (characterBrushCounter % 40 == 10)
                    {
                        last = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "running_back.png"), UriKind.RelativeOrAbsolute)));
                    }
                    else if (characterBrushCounter % 40 == 20)
                    {
                        last = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "standing_back.png"), UriKind.RelativeOrAbsolute)));
                        last_standing = last;
                    }
                    else if (characterBrushCounter % 40 == 30)
                    {
                        last = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "running_back_v2.png"), UriKind.RelativeOrAbsolute)));
                    }
                }
                else if (model.Left == true)
                {
                    characterBrushCounter++;
                    if (characterBrushCounter % 40 == 0)
                    {
                        characterBrushCounter = 0;
                        last = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "standing_left.png"), UriKind.RelativeOrAbsolute)));
                        last_standing = last;
                    }
                    else if (characterBrushCounter % 40 == 10)
                    {
                        last = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "running_left.png"), UriKind.RelativeOrAbsolute)));
                    }
                    else if (characterBrushCounter % 40 == 20)
                    {
                        last = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "standing_left.png"), UriKind.RelativeOrAbsolute)));
                        last_standing = last;
                    }
                    else if (characterBrushCounter % 40 == 30)
                    {
                        last = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "running_left_v2.png"), UriKind.RelativeOrAbsolute)));
                    }
                }
                else if (model.Right == true)
                {
                    characterBrushCounter++;
                    if (characterBrushCounter % 40 == 0)
                    {
                        characterBrushCounter = 0;
                        last = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "standing_right.png"), UriKind.RelativeOrAbsolute)));
                        last_standing = last;
                    }
                    else if (characterBrushCounter % 40 == 10)
                    {
                        last = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "running_right.png"), UriKind.RelativeOrAbsolute)));
                    }
                    else if (characterBrushCounter % 40 == 20)
                    {
                        last = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "standing_right.png"), UriKind.RelativeOrAbsolute)));
                        last_standing = last;
                    }
                    else if (characterBrushCounter % 40 == 30)
                    {
                        last = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "running_right_v2.png"), UriKind.RelativeOrAbsolute)));
                    }
                }
                else
                {
                    last = last_standing;
                }

                return last;
            }
        }

        public Brush Roommate_Brush
        {
            get
            {
                if (roommateBrushDirection == "up")
                {
                    return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "Ghost_back.png"), UriKind.RelativeOrAbsolute)));
                }
                else if (roommateBrushDirection == "down")
                {
                    return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "Ghost_Front.png"), UriKind.RelativeOrAbsolute)));
                }
                else if (roommateBrushDirection == "left")
                {
                    return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "Ghost_left.png"), UriKind.RelativeOrAbsolute)));
                }
                else
                {
                    return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "Ghost_right.png"), UriKind.RelativeOrAbsolute)));
                }
            }
        }

        public Brush PizzaGuy_Brush
        {
            get
            {
                if (pizzaGuyBrushDirection == "up")
                {
                    return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "pizza_standing_back.png"), UriKind.RelativeOrAbsolute)));
                }
                else
                {
                    return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "pizza_standing_front.png"), UriKind.RelativeOrAbsolute)));
                }
            }
        }

        public Brush Neighbour_Brush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "oldkurvinnyo_running_back.png"), UriKind.RelativeOrAbsolute)));
            }
        }

        public Brush Objective_Alert_Brush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "exclamation_mark.png"), UriKind.RelativeOrAbsolute)));
            }
        }

        public Brush Fish_Objective_Brush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "fish.png"), UriKind.RelativeOrAbsolute)));
            }
        }

        public Brush Dishes_Objective_Brush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "plates.png"), UriKind.RelativeOrAbsolute)));
            }
        }

        public Brush Trash_Objective_Brush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "trash_bag.png"), UriKind.RelativeOrAbsolute)));
            }
        }

        public Brush E_Button_Brush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "E_button.png"), UriKind.RelativeOrAbsolute)));
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            if (area.Width > 0 && area.Height > 0 && model != null)
            {
                drawingContext.DrawRectangle(HouseBrush, null, new Rect(0, 0, area.Width, area.Height));
                drawingContext.DrawGeometry(Brushes.Transparent, null, new Wall((int)area.Width, (int)area.Height).Area);

                int moveTextPosition = 0;

                for (int i = 0; i < model.Objectives.Count(); i++)
                {
                    drawingContext.DrawGeometry(Brushes.Transparent, null, model.Objectives[i].Area);

                    List<string> texts = (List<string>)GameObjective.ObjectiveText(model.Objectives[i].ObjType);

                    FormattedText objText = new FormattedText(texts[model.Objectives[i].PartCounter], System.Globalization.CultureInfo.CurrentCulture,
                        FlowDirection.LeftToRight, new Typeface(new FontFamily("Arial"), FontStyles.Italic,
                        FontWeights.UltraBold, FontStretches.Normal), 16, Brushes.Black, 10);

                    drawingContext.DrawText(objText, new Point((int)(area.Width / 192), (int)(area.Height / 108) + moveTextPosition));

                    FormattedText timerText = new FormattedText($"{model.Objectives[i].Seconds}s", System.Globalization.CultureInfo.CurrentCulture,
                        FlowDirection.LeftToRight, new Typeface(new FontFamily("Arial"), FontStyles.Italic,
                        FontWeights.UltraBold, FontStretches.Normal), 16, Brushes.White, 10);

                    drawingContext.DrawText(timerText, model.Objectives[i].Objective_Timer_Position());

                    moveTextPosition += (int)(area.Height / 54);

                    if (model.Objectives[i].PartCounter == 0)
                    {
                        if (model.Objectives[i].ObjType == ObjectiveType.Trash)
                        {
                            drawingContext.DrawGeometry(Trash_Objective_Brush, null, model.Objectives[i].Objective_Texture_Area);
                        }
                        else if (model.Objectives[i].ObjType == ObjectiveType.Fish)
                        {
                            drawingContext.DrawGeometry(Fish_Objective_Brush, null, model.Objectives[i].Objective_Texture_Area);
                        }
                        else if (model.Objectives[i].ObjType == ObjectiveType.Dishes)
                        {
                            drawingContext.DrawGeometry(Dishes_Objective_Brush, null, model.Objectives[i].Objective_Texture_Area);
                        }
                    }
                }

                drawingContext.DrawGeometry(Character_Brush, null, (model.Player as GameItem).Area);
                drawingContext.DrawGeometry(Roommate_Brush, null, (model.Roommate as GameItem).Area);
                drawingContext.DrawGeometry(PizzaGuy_Brush, null, (model.PizzaGuy as GameItem).Area);
                drawingContext.DrawGeometry(Neighbour_Brush, null, (model.Neighbour as GameItem).Area);

                for (int i = 0; i < model.Objectives.Count(); i++)
                {
                    drawingContext.DrawGeometry(Objective_Alert_Brush, null, model.Objectives[i].Objective_Alert_Area);
                }

                if (model.PlayerAtObjective)
                {
                    drawingContext.DrawRectangle(E_Button_Brush, null, new Rect((int)(area.Width / 96), (int)(area.Height / 1.08), (int)(area.Width / 27.428571), (int)(area.Height / 15.428571)));
                }

                FormattedText pointsText = new FormattedText($"Points: {model.Points}", System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight, new Typeface(new FontFamily("Arial"), FontStyles.Italic,
                    FontWeights.UltraBold, FontStretches.Normal), 20, Brushes.White, 10);

                drawingContext.DrawText(pointsText, new Point((int)(area.Width / 1.066667), (int)(area.Height / 54)));
            }
        }
    }
}
