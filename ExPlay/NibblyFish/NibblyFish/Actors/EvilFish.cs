using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExLib.Objects;
using ExLib.Managers;
using NibblyFish.Managers;
using Microsoft.Xna.Framework;

namespace NibblyFish.Actors
{
    public class EvilFish : Actor
    {
        private List<Color> _colors = new List<Color>() { Color.Red, Color.Green, Color.Orange };

        public EvilFish()
        {
            this.Sprite = GraphicsManager.GetSprite(NibblyFishGame.Textures.GreenFrog);

            this.Sprite.Color = _colors[GameManager.Rnd.Next(0, _colors.Count)];
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            // random direction
            int moveX = GameManager.Rnd.Next(-1, 2);
            int moveY = GameManager.Rnd.Next(-1, 2);

            this.X += moveX;
            this.Y += moveY;
        }
    }
}
