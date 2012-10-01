using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExLib.Bases;
using ExLib.Other;
using ExLib.Managers;
using Frogger.Managers;
using ExLib.Objects;
using Frogger.Actors;
using ExLib.MovementBehaviour.Keyboard;

namespace Frogger.GameScreens
{
    public class IngameScreen : GameScreen
    {
        public static Viewport GameViewport;

        public override void Initialise()
        {
            GameViewport = new Viewport(0, 0, (int)(GraphicsManager.RESOLUTION_X * 0.5), (int)(GraphicsManager.RESOLUTION_Y * 0.5), GraphicsManager.RESOLUTION_X, GraphicsManager.RESOLUTION_Y);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            GameViewport.Draw(gameTime);
        }

    }
}
