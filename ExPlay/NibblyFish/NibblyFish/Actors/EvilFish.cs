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
      Swimming,
      Chase,
      Idle
    }

    private Vector2 destination = Vector2.Zero;
    private EvilFishBehaviour behaviour;
    private Vector2 velocity = Vector2.Zero;
    private double maxSpeed = 1;

    private List<Color> _colors = new List<Color>() { Color.Red, Color.Green, Color.Orange };

    public EvilFish()
    {
      this.Sprite = GraphicsManager.GetSprite(NibblyFishGame.Textures.EvilFish);

      this.Sprite.Color = _colors[GameManager.Random.Next(0, _colors.Count)];

      this.destination = this.GetNewDestination();
      this.behaviour = EvilFishBehaviour.Idle;
    }

    public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
    {
      switch(this.behaviour)
      {
        case EvilFishBehaviour.Chase:
          break;
        case EvilFishBehaviour.Idle:

          this.destination = this.GetNewDestination();
          this.velocity = this.destination - this.Position;

          this.velocity = this.velocity * 0.05f;
          this.behaviour = EvilFishBehaviour.Swimming;
          break;
        case EvilFishBehaviour.Swimming:
          if((this.destination - this.Position).Length() <= 20)
          {
            this.behaviour = EvilFishBehaviour.Idle;
          }
          break;
        default:
          break;
      }

      this.Position = this.Position + this.velocity;
    }

    private Vector2 GetNewDestination()
    {
      Vector2 destination = new Vector2(
                            GameManager.Random.Next(NibblyFishGame.DANGERFIELD.Left, NibblyFishGame.DANGERFIELD.Left+ NibblyFishGame.DANGERFIELD.Width),
                            GameManager.Random.Next(NibblyFishGame.DANGERFIELD.Top, NibblyFishGame.DANGERFIELD.Height));

      return destination;
    }
  }
}
