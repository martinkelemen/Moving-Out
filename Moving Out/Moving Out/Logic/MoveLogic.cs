using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Moving_Out.Logic
{
    public class MoveLogic
    {
        public bool Left { get; set; }
        public bool Right { get; set; }
        public bool Up { get; set; }
        public bool Down { get; set; }
        int speed = 8;

        public void TimeStep(FrameworkElement player)
        {
            if (Left==true && Canvas.GetLeft(player)>5)
            {
                Canvas.SetLeft(player, Canvas.GetLeft(player) - speed);
            }
            if (Right == true && Canvas.GetLeft(player) + (player.Width+20)< Application.Current.MainWindow.Width)
            {
                Canvas.SetLeft(player, Canvas.GetLeft(player) + speed);
            }
            if (Up==true && Canvas.GetTop(player)>5)
            {
                Canvas.SetTop(player, Canvas.GetTop(player) - speed);
            }
            if (Down == true && Canvas.GetTop(player) + (player.Width *2) < Application.Current.MainWindow.Height)
            {
                Canvas.SetTop(player, Canvas.GetTop(player) + speed);
            }
        }



    }
}
