using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExLib.Bases;
using ExLib.Objects;
using ExLib.Managers;
using NibblyFish.Elements;
using ExLib.Other;

namespace NibblyFish.GameScreens
{
    class TitleScreen : GameScreen
    {
        Viewport GameViewport;

        GameScreen _aquariumScreen;

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            GameViewport.Draw(gameTime);
        }

        public override void Initialise()
        {
            //this.Elements.Add(new Background(NibblyFishGame.Textures.background1.ToString()));

            _aquariumScreen = new AquariumScreen();

            this.Children.Add(_aquariumScreen);

            _aquariumScreen.Initialise();

            GameViewport = new Viewport(0, 0, (int)(GraphicsManager.RESOLUTION_X * 0.5), (int)(GraphicsManager.RESOLUTION_Y * 0.5), GraphicsManager.RESOLUTION_X, GraphicsManager.RESOLUTION_Y);
        }
    }
}
