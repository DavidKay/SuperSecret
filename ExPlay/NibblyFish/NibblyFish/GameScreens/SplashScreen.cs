using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExLib.Bases;
using NibblyFish.Managers;
using ExLib.Managers;
using Microsoft.Xna.Framework.Graphics;

namespace NibblyFish.GameScreens
{
    public class SplashScreen : GameScreen
    {

        int elapsedMilliseconds = 0;

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            elapsedMilliseconds += gameTime.ElapsedGameTime.Milliseconds;

            if (elapsedMilliseconds > 500)
            {
                GameManager.ShowTitleScreen();
            }
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            SpriteFont loadingFont = GraphicsManager.GetFont("LoadingFont");

            string message = "...NibblyPig Software Productions Presents...";

            var textSize = loadingFont.MeasureString(message);

            int displayX = (int)((GraphicsManager.RESOLUTION_X * 0.5) - (textSize.X * 0.5));
            int displayY = (int)((GraphicsManager.RESOLUTION_Y * 0.5) - (textSize.Y * 0.5));

            GraphicsManager.DrawText(loadingFont, message, displayX, displayY);

            //string startingIn = "Starting in " + (3000 - elapsedMilliseconds) + "ms!";

            //var textSize2 = loadingFont.MeasureString(startingIn);

            //int displayX2 = (int)((GraphicsManager.RESOLUTION_X * 0.5) - (textSize2.X * 0.5));
            //int displayY2 = (int)((GraphicsManager.RESOLUTION_Y * 0.5) - (textSize2.Y * 0.5)) + 20;

            //GraphicsManager.DrawText(loadingFont, startingIn, displayX2, displayY2);
        }

        public override void Initialise()
        {
            
        }
    }
}
