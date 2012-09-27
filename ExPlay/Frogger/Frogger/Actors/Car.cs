using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExLib.Managers;
using ExLib;
using ExLib.Objects;

namespace Frogger.Actors
{
    class Car : Actor
    {
        private double MovementSpeed = 200;

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            this._x -= (MovementSpeed * gameTime.ElapsedGameTime.TotalSeconds);

            if (this.X + this.Sprite.Width < 0)
            {
                this.X = ExGame.SCREEN_WIDTH;
            }
        }

    }
}
