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
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "standing.png"), UriKind.RelativeOrAbsolute)));
            }
        }

        public Brush Roommate_Brush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "Ghost_Front.png"), UriKind.RelativeOrAbsolute)));
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            if(area.Width > 0 && area.Height > 0 && model != null)
            {
                drawingContext.DrawRectangle(HouseBrush, null, new Rect(0, 0, area.Width, area.Height));
                drawingContext.DrawGeometry(Brushes.Transparent, null, new Wall((int)area.Width, (int)area.Height).Area);
                drawingContext.DrawGeometry(Charachter_Standing_Brush, null, (model.Player as GameItem).Area);
                drawingContext.DrawGeometry(Roommate_Brush, null, (model.Roommate as GameItem).Area);

                for (int i = 0; i < model.Objectives.Count(); i++)
                {
                    drawingContext.DrawGeometry(Brushes.Transparent, new Pen(Brushes.Red, 1), model.Objectives[i].Area);
                }
            }
        }
    }
}
