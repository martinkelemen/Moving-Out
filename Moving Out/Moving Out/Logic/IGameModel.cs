﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moving_Out.Logic
{
    public interface IGameModel
    {
        event EventHandler Changed;

        IGameControl p { get; }
    }
}
