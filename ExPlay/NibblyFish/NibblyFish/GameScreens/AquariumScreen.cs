using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExLib.Bases;
using NibblyFish.Elements;
using NibblyFish.Managers;

namespace NibblyFish.GameScreens
{
    class AquariumScreen : GameScreen
    {
        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            
        }

        public override void Initialise()
        {
            this.Elements.Add(new Background(NibblyFishGame.Textures.background1.ToString()));

            GameManager.SetupAquarium(this);
        }
    }
}
