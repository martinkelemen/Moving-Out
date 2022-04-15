using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Moving_Out.Logic
{
    public class Wall : GameItem
    {
        private int displayWidth;
        private int displayHeight;

        public Wall(int displayWidth, int displayHeight)
        {
            this.displayWidth = displayWidth;
            this.displayHeight = displayHeight;
        }

        public override Geometry Area
        {
            get
            {
                GeometryGroup gg = new GeometryGroup();
                //főfal
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth/12.631578), (int)(displayHeight / 8.843478), displayWidth-(int)(displayWidth / 12.631578)*2, 5)));
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 12.631578), (int)(displayHeight / 8.843478), 5, displayHeight-(int)(displayHeight / 4.730232))));
                gg.Children.Add(new RectangleGeometry(new Rect(displayWidth-(int)(displayWidth / 12.631578), (int)(displayHeight / 8.843478), 5, displayHeight - (int)(displayHeight / 4.730232))));
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth/12.631578), displayHeight- (int)(displayHeight / 9.685714), displayWidth - (int)(displayWidth / 12.631578) * 2, 5)));
                //nappali és dínó
                gg.Children.Add(new RectangleGeometry(new Rect(806, (int)(displayHeight / 8.843478), 40, 168)));
                gg.Children.Add(new RectangleGeometry(new Rect(806, 345, 40, 328)));
                gg.Children.Add(new RectangleGeometry(new Rect(806, 712, 40, 200)));
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 12.631578), 510, 654, 40)));
                gg.Children.Add(new RectangleGeometry(new Rect(575, (int)(displayHeight / 8.843478), 40, 108)));
                gg.Children.Add(new RectangleGeometry(new Rect(615, 183, 191, 40)));
                //előszoba és fürdő
                gg.Children.Add(new RectangleGeometry(new Rect(921, 850, 40, 55)));
                gg.Children.Add(new RectangleGeometry(new Rect(921, 508, 40, 305)));
                gg.Children.Add(new RectangleGeometry(new Rect(961, 508, 499, 40)));
                gg.Children.Add(new RectangleGeometry(new Rect(961, 692, 77, 122)));
                gg.Children.Add(new RectangleGeometry(new Rect(1112, 774, 119, 40)));
                gg.Children.Add(new RectangleGeometry(new Rect(1229, 876, 40, 40)));
                gg.Children.Add(new RectangleGeometry(new Rect(1229, 650, 40, 202)));
                gg.Children.Add(new RectangleGeometry(new Rect(1269, 650, 500, 40)));
                gg.Children.Add(new RectangleGeometry(new Rect(1460, 480, 40, 170)));
                //hálószoba/konyha
                gg.Children.Add(new RectangleGeometry(new Rect(1460, 347, 40, 100)));
                gg.Children.Add(new RectangleGeometry(new Rect(1500, 347, 268, 58)));
                return gg;
            }
        }
    }
}
