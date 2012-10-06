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
    private enum EvilFishBehaviour
    {
      Chase,
      Idle
    }

    private Vector2 destination;
    private EvilFishBehaviour behaviour;

    private List<Color> _colors = new List<Color>() { Color.Red, Color.Green, Color.Orange };

    public EvilFish()
    {
      this.Sprite = GraphicsManager.GetSprite(NibblyFishGame.Textures.EvilFish);

      this.Sprite.Color = _colors[GameManager.Random.Next(0, _colors.Count)];

      this.behaviour = EvilFishBehaviour.Idle;
    }

    public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
    {
      switch(this.behaviour)
      {
        case EvilFishBehaviour.Chase:
          break;
        case EvilFishBehaviour.Idle:

          this.GetNewDestination();
          // random direction
          int moveX = GameManager.Random.Next(-1, 2);
          int moveY = GameManager.Random.Next(-1, 2);

          this.X += moveX;
          this.Y += moveY;
          break;
        default:
          break;
      }
    }

    private void GetNewDestination()
    {

    }
  }
}
