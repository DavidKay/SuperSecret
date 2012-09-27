using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExLib.Interfaces;
using ExLib;
using Microsoft.Xna.Framework;
using ExLib.Managers;
using Frogger.Managers;
using Frogger.Level;
using Frogger.Actors;
using ExLib.MovementBehaviour.Keyboard;
using ExLib.Bases;
using ExLib.Objects;
using ExLib.Other;

namespace Frogger.GameWindows
{
    public class MainScreen : GameWindowBase, IGameWindow
    {
        public void Initialise(Microsoft.Xna.Framework.Content.ContentManager contentManager)
        {
            GameManager.StartNewGame();

        }

        public void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {

        }

        public void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            
        }
    }
}
