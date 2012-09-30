using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExLib.Objects;
using Microsoft.Xna.Framework;
using ExLib.Managers;
using Microsoft.Xna.Framework.Graphics;

namespace Spaceship.Elements
{
    public class Starfield : Element
    {
        private List<Point> _stars;

        public Starfield() : base(null, 0, 0)
        {
            this.IsBackgroundElement = true;

            _stars = new List<Point>();

            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                _stars.Add(new Point(rnd.Next(1, 640), rnd.Next(1, 480)));
            }
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (Point p in _stars)
            {
                GraphicsManager.DrawSprite(GraphicsManager.GetSprite(SpaceshipGame.Textures.Point), p);
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
