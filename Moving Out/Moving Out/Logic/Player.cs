using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Moving_Out.Logic
{
    public class Player : IGameControl
    {
        public System.Drawing.Point Center { get; set; }
        public Vector Speed { get; set; }

        public Player()
        {
            Center = new System.Drawing.Point(500, 500);
            Speed = new Vector(0, 0);
        }

        public void Move()
        {
            Center = new System.Drawing.Point(Center.X + (int)Speed.X, Center.Y + (int)Speed.Y);
        }
    }
}
