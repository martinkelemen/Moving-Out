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
        int charachterBrushCounter;
        Brush last;
        Brush last_standing;

        public void SetupSizes(Size area)
        {
            this.area = area;
            this.InvalidateVisual();
        }

        public void SetupModel(IGameModel model)
        {
            this.model = model;
            this.model.Changed += (sender, eventargs) => this.InvalidateVisual();
        }

        public Display()
        {
            last = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "standing.png"), UriKind.RelativeOrAbsolute)));
            last_standing = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "standing.png"), UriKind.RelativeOrAbsolute)));
            charachterBrushCounter = 0;
        }

        public Brush HouseBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "thumbnail.png"), UriKind.RelativeOrAbsolute)));
            }
        }

        public Brush Charachter_Standing_Brush
        {
            get
            {
                if (model.Down == true)
                {
                    charachterBrushCounter++;
                    if (charachterBrushCounter % 20 == 0)
                    {
                        charachterBrushCounter = 0;
                        last = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "standing.png"), UriKind.RelativeOrAbsolute)));
                        last_standing = last;
                    }
                    else if (charachterBrushCounter % 20 == 10)
                    {
                        last = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "running_front.png"), UriKind.RelativeOrAbsolute)));
                    }
                }
                else if (model.Up == true)
                {
                    charachterBrushCounter++;
                    if (charachterBrushCounter % 20 == 0)
                    {
                        charachterBrushCounter = 0;
                        last = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "standing_back.png"), UriKind.RelativeOrAbsolute)));
                        last_standing = last;
                    }
                    else if (charachterBrushCounter % 20 == 10)
                    {
                        last = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "running_back.png"), UriKind.RelativeOrAbsolute)));
                    }
                }
                else if (model.Left == true)
                {
                    charachterBrushCounter++;
                    if (charachterBrushCounter % 20 == 0)
                    {
                        charachterBrushCounter = 0;
                        last = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "standing_left.png"), UriKind.RelativeOrAbsolute)));
                        last_standing = last;
                    }
                    else if (charachterBrushCounter % 20 == 10)
                    {
                        last = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "running_left.png"), UriKind.RelativeOrAbsolute)));
                    }
                }
                else if (model.Right == true)
                {
                    charachterBrushCounter++;
                    if (charachterBrushCounter % 20 == 0)
                    {
                        charachterBrushCounter = 0;
                        last = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "standing_right.png"), UriKind.RelativeOrAbsolute)));
                        last_standing = last;
                    }
                    else if (charachterBrushCounter % 20 == 10)
                    {
                        last = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "running_right.png"), UriKind.RelativeOrAbsolute)));
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
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "Ghost_Front.png"), UriKind.RelativeOrAbsolute)));
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

            if(area.Width > 0 && area.Height > 0 && model != null)
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

                    //Geometry textGeometry = text.BuildGeometry(new Point(10, 20+moveTextPosition));
                    //drawingContext.DrawGeometry(Brushes.Black, new Pen(Brushes.White, 0.25), textGeometry);

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

                drawingContext.DrawGeometry(Charachter_Standing_Brush, null, (model.Player as GameItem).Area);
                drawingContext.DrawGeometry(Roommate_Brush, null, (model.Roommate as GameItem).Area);

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
