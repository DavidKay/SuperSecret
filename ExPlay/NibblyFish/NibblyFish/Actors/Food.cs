using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExLib.Objects;
using ExLib.Managers;
using Microsoft.Xna.Framework;

namespace NibblyFish.Actors
{
    public class Food : Actor
    {
        public Food()
        {
            this.Sprite = GraphicsManager.GetSprite(NibblyFishGame.Textures.Food);
            this.Sprite.Color = Color.LimeGreen;
        }

        public override void Update(GameTime gameTime)
        {
            
        }

    }
}
