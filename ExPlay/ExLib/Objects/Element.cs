using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using ExLib.Managers;

namespace ExLib.Objects
{
    public abstract class Element
    {
        public Sprite Sprite { get; set; }

        public int X { get { return (int)Math.Round(_x, 0, MidpointRounding.ToEven); } set { _x = value; } }
        public int Y { get { return (int)Math.Round(_y,0, MidpointRounding.ToEven); } set { _y = value; } }

        protected double _x;
        protected double _y;

        public virtual void Draw(GameTime gameTime)
        {
            GraphicsManager.DrawSprite(Sprite, new Point(X, Y));
        }

        public Element(Sprite sprite, int x, int y)
        {
            this.Sprite = sprite;
            this.X = x;
            this.Y = y;
        }

        public Element()
        {

        }
    }
}
