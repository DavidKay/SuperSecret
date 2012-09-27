using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExLib.Interfaces;

namespace ExLib.Bases
{
    public abstract class GameWindowBase
    {
        public List<IGameWindow> Children = new List<IGameWindow>();
    }
}
