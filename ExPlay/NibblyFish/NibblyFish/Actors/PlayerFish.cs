using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExLib.Objects;
using ExLib.Managers;
using Microsoft.Xna.Framework;
using NibblyFish.Managers;
using NibblyFish.PlayerData;

namespace NibblyFish.Actors
{
  public class PlayerFish : Actor
  {
    private int _changeColorCooldown = 0;

    private const int COLOR_COOLDOWN_DURATION = 5000;

    private int _size = 0;

    private bool _evilTransformation = false;

    public Player Player;

    public Point RespawnPoint;

    public PlayerFish(Player player)
    {
      this.Player = player;

      this.Sprite = GraphicsManager.GetSprite(NibblyFishGame.Textures.DiddyFish);

      this.Sprite.Color = Color.Orange;
    }


    public enum MovementState
    {
      North,
      East,
      South,
      West,
      None
    }

    public MovementState CurrentMovementState = MovementState.None;

    private double MovementSpeed = 75;

    private void Move(MovementState movementState, GameTime gameTime)
    {
      float movementAmount = (float)(MovementSpeed * gameTime.ElapsedGameTime.TotalSeconds);

      if(movementState == MovementState.North)
      {
        this.Position.Y -= movementAmount;
      }
      else if(movementState == MovementState.East)
      {
        this.Position.X += movementAmount;
      }
      if(movementState == MovementState.South)
      {
        this.Position.Y += movementAmount;
      }
      if(movementState == MovementState.West)
      {
        this.Position.X -= movementAmount;
      }
    }

    public override void Update(GameTime gameTime)
    {
      _changeColorCooldown -= gameTime.ElapsedGameTime.Milliseconds;

      if(movementState.Direction.North)
      {
        Move(MovementState.North, gameTime);
      }
      if(movementState.Direction.East)
      {
        Move(MovementState.East, gameTime);
      }
      if(movementState.Direction.South)
      {
        Move(MovementState.South, gameTime);
      }
      if(movementState.Direction.West)
      {
        Move(MovementState.West, gameTime);
      }

      if(currentMovements != null && _changeColorCooldown <= 0)
      {
        if(currentMovements.Contains(ExLib.MovementBehaviour.Movements.MovementsEnum.ChangeColourRed))
        {
          this.Sprite.Color = Color.Red;
          _changeColorCooldown = COLOR_COOLDOWN_DURATION;
        }
        if(currentMovements.Contains(ExLib.MovementBehaviour.Movements.MovementsEnum.ChangeColourOrange))
        {
          this.Sprite.Color = Color.Orange;
          _changeColorCooldown = COLOR_COOLDOWN_DURATION;
        }
        if(currentMovements.Contains(ExLib.MovementBehaviour.Movements.MovementsEnum.ChangeColourGreen))
        {
          this.Sprite.Color = Color.Green;
          _changeColorCooldown = COLOR_COOLDOWN_DURATION;
        }
        if(currentMovements.Contains(ExLib.MovementBehaviour.Movements.MovementsEnum.ChangeColourBlue))
        {
          this.Sprite.Color = Color.Blue;
          _changeColorCooldown = COLOR_COOLDOWN_DURATION;
        }
      }


      var intersections = ElementManager.GetIntersections(this, new List<Type>() { typeof(EvilFish), typeof(Food) });

      if(intersections.Any())
      {
        {
          foreach(EvilFish intersection in intersections.Where(c => c is EvilFish))
          {
            if(_evilTransformation)
            {
              intersection.Kill();
            }
            else if(intersection.Sprite.Color != this.Sprite.Color)
            {
              // death routine
              this.Position = new Vector2(this.RespawnPoint.X, this.RespawnPoint.Y);
              this._size = 0;
            }
          }
        }

        foreach(Food intersection in intersections.Where(c => c is Food))
        {
          // remove the food!
          intersection.Kill();
          _size++;

          if(_size < 5)
          {
            this.Sprite.Width++;
            this.Sprite.Height++;
          }
          else if(!_evilTransformation)
          {
            this.Sprite.Texture = GraphicsManager.GetTexture(NibblyFishGame.Textures.EvilFish.ToString());
            _evilTransformation = true;
            this.Sprite.Height += 10;
            this.Sprite.Width += 10;
            MovementSpeed = 100;
          }


        }
      }

      base.Update(gameTime);
    }
  }
}
