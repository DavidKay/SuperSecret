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
    public Sprite Sprite
    {
      get;
      set;
    }

    public int X
    {
      get
      {
        return (int)Math.Round(Position.X, 0, MidpointRounding.ToEven);
      }
    }
    public int Y
    {
      get
      {
        return (int)Math.Round(Position.Y, 0, MidpointRounding.ToEven);
      }
    }

    public bool IsBackgroundElement
    {
      get;
      set;
    }

    public int ZIndex
    {
      get;
      set;
    }

    public Vector2 Position = new Vector2();

    public virtual void Draw(GameTime gameTime)
    {
      GraphicsManager.DrawSprite(Sprite, new Point(X, Y));
    }

    public Element(Sprite sprite, int x, int y)
      : base()
    {
      this.Sprite = sprite;
      this.Position = new Vector2( x,y);

      this.ZIndex = 0;
    }

    public Element()
      : base()
    {
      this.ZIndex = 0;
    }

    public virtual void Update(GameTime gameTime)
    {
      if(Sprite != null)
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
