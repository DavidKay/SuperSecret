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

        public bool IsBackgroundElement { get; set; }

        public int ZIndex {get; set;}

        protected double _x;
        protected double _y;

        public virtual void Draw(GameTime gameTime)
        {
            GraphicsManager.DrawSprite(Sprite, new Point(X, Y));
        }

        public Element(Sprite sprite, int x, int y) : base()
        {
            this.Sprite = sprite;
            this.X = x;
            this.Y = y;

            this.ZIndex = 0;
        }

        public Element() : base()
        {
            this.ZIndex = 0;
        }

        public virtual void Update(GameTime gameTime)
        {
            if (Sprite != null)
            {
                this.Sprite.Update(gameTime);
            }
        }

        public bool IsKilled = false;

        public void Kill()
        {
            IsKilled = true;
        }
    }
}
