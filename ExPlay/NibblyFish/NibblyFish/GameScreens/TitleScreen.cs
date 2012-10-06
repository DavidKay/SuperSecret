using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExLib.Bases;
using ExLib.Objects;
using ExLib.Managers;
using NibblyFish.Elements;
using ExLib.Other;
using NibblyFish.Managers;
using Microsoft.Xna.Framework.Graphics;

namespace NibblyFish.GameScreens
{
    class TitleScreen : GameScreen
    {
        ExLib.Other.Viewport GameViewport;

        GameScreen _aquariumScreen;

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (InputManager.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Space))
            {
                GameManager.StartNewGame();
            }

        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            GameViewport.Draw(gameTime);

            SpriteFont loadingFont = GraphicsManager.GetFont("LoadingFont");

            string message = "Title Screen Here";

            var textSize = loadingFont.MeasureString(message);

            int displayX = (int)((GraphicsManager.RESOLUTION_X * 0.5) - (textSize.X * 0.5));
            int displayY = (int)((GraphicsManager.RESOLUTION_Y * 0.5) - (textSize.Y * 0.5)) - 20;

            GraphicsManager.DrawText(loadingFont, message, displayX, displayY);
        }

        public override void Initialise()
        {
            //this.Elements.Add(new Background(NibblyFishGame.Textures.background1.ToString()));

            _aquariumScreen = new AquariumScreen();

            this.Children.Add(_aquariumScreen);

            _aquariumScreen.Initialise();

            GameViewport = new ExLib.Other.Viewport(0, 0, (int)(GraphicsManager.RESOLUTION_X * 0.5), (int)(GraphicsManager.RESOLUTION_Y * 0.5), GraphicsManager.RESOLUTION_X, GraphicsManager.RESOLUTION_Y);
        }
    }
}
