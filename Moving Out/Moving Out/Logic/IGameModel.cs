using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moving_Out.Logic
{
    public interface IGameModel
    {
        event EventHandler Changed;
        event EventHandler RoommateMoveChanged;

        IGameControl Player { get; set; }
        IGameControl Roommate { get; set; }
        List<GameObjective> Objectives { get; set; }
        bool PlayerAtObjective { get; set; }
        int Points { get; set; }
        bool Left { get; set; }
        bool Right { get; set; }
        bool Up { get; set; }
        bool Down { get; set; }
    }
}
