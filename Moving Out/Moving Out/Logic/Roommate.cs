using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Moving_Out.Logic
{
    public class Roommate : GameItem, IGameControl
    {
        public int Radius { get; set; }
        public Vector Speed { get; set; }
        public System.Drawing.Point Center { get; set; }

        public string Direction { get; set; }

        public Roommate(int centerX, int centerY, int radius)
        {
            Radius = radius;
            Center = new System.Drawing.Point(centerX, centerY);
            Speed = new Vector(0, 0);
            Direction = "down";
        }

        public override Geometry Area
        {
            get
            {
                return new EllipseGeometry(new Point(Center.X, Center.Y), Radius, Radius);
            }
        }

        public void Move()
        {
            Center = new System.Drawing.Point(Center.X + (int)Speed.X, Center.Y + (int)Speed.Y);
        }
    }
}
