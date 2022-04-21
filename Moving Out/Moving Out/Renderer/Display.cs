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

        public void SetupSizes(Size area)
        {
            this.area = area;
            this.InvalidateVisual();
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

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            if(area.Width > 0 && area.Height > 0)
            {
                drawingContext.DrawRectangle(HouseBrush, null, new Rect(0, 0, area.Width, area.Height));
                drawingContext.DrawGeometry(Brushes.Black, null, new Wall((int)area.Width, (int)area.Height).Area);
            }
        }
    }
}
