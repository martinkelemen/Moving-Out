﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Moving_Out.Logic
{
    public class Player : GameItem, IGameControl
    {
        private int radius;

        public System.Drawing.Point Center { get; set; }
        public Vector Speed { get; set; }

        public override Geometry Area
        {
            get
            {
                return new EllipseGeometry(new Point(Center.X, Center.Y), radius, radius);
            }
        }

        public Player(int centerX, int centerY, int radius)
        {
            this.radius = radius;
            Center = new System.Drawing.Point(centerX, centerY);
            Speed = new Vector(0, 0);
        }

        public void Move()
        {
            Center = new System.Drawing.Point(Center.X + (int)Speed.X, Center.Y + (int)Speed.Y);
        }
    }
}
