using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Moving_Out.Logic
{
    public interface IGameControl
    {
        void Move();

        int Radius { get; set; }
        Vector Speed { get; set; }
        System.Drawing.Point Center { get; set; }
    }
}
