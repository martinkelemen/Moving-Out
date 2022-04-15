using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Moving_Out.Logic
{
    public abstract class GameItem
    {
        public abstract Geometry Area { get; }

        public bool IsCollision(GameItem other)
        {
            return Geometry.Combine(Area, other.Area,
            GeometryCombineMode.Intersect, null).GetArea() > 0;
            }
    }
}
