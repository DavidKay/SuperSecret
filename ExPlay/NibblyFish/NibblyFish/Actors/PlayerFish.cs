using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExLib.Objects;
using ExLib.Managers;
using Microsoft.Xna.Framework;
using NibblyFish.Managers;

namespace NibblyFish.Actors
{
    public class PlayerFish : Actor
    {
        private int _changeColorCooldown = 0;

        private const int COLOR_COOLDOWN_DURATION = 5000;

        private int _size = 0;

        private bool _evilTransformation = false;

        public PlayerFish()
        {
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
            //CurrentMovementState = movementState;

            //this.Sprite.Animate("JumpingFrog");

            double movementAmount = (MovementSpeed * gameTime.ElapsedGameTime.TotalSeconds);

            if (movementState == MovementState.North)
                {
                    _y -= movementAmount;
                }
            else if (movementState == MovementState.East)
                {
                    _x += movementAmount;
                }
            if (movementState == MovementState.South)
                {
                    _y += movementAmount;
                }
            if (movementState == MovementState.West)
                {
                    _x -= movementAmount;
                }
        }

        public override void Update(GameTime gameTime)
        {
            _changeColorCooldown -= gameTime.ElapsedGameTime.Milliseconds;

            if (movementState.Direction.North)
            {
                Move(MovementState.North, gameTime);
            }
            if (movementState.Direction.East)
            {
                Move(MovementState.East, gameTime);
            }
            if (movementState.Direction.South)
            {
                Move(MovementState.South, gameTime);
            }
            if (movementState.Direction.West)
            {
                Move(MovementState.West, gameTime);
            }

            if (currentMovements != null && _changeColorCooldown <= 0)
            {
                if (currentMovements.Contains(ExLib.MovementBehaviour.Movements.MovementsEnum.ChangeColourRed))
                {
                    this.Sprite.Color = Color.Red;
                    _changeColorCooldown = COLOR_COOLDOWN_DURATION;
                }
                if (currentMovements.Contains(ExLib.MovementBehaviour.Movements.MovementsEnum.ChangeColourOrange))
                {
                    this.Sprite.Color = Color.Orange;
                    _changeColorCooldown = COLOR_COOLDOWN_DURATION;
                }
                if (currentMovements.Contains(ExLib.MovementBehaviour.Movements.MovementsEnum.ChangeColourGreen))
                {
                    this.Sprite.Color = Color.Green;
                    _changeColorCooldown = COLOR_COOLDOWN_DURATION;
                }
                if (currentMovements.Contains(ExLib.MovementBehaviour.Movements.MovementsEnum.ChangeColourBlue))
                {
                    this.Sprite.Color = Color.Blue;
                    _changeColorCooldown = COLOR_COOLDOWN_DURATION;
                }
            }
            

            var intersections = ElementManager.GetIntersections(this, new List<Type>() { typeof(EvilFish), typeof(Food) });

            if (intersections.Any())
            {
                {
                    foreach (EvilFish intersection in intersections.Where(c => c is EvilFish))
                    {
                        if (_evilTransformation)
                        {
                            intersection.Kill();
                        }
                        else if (intersection.Sprite.Color != this.Sprite.Color)
                        {
                            // death routine
                            this.X = 0;
                            this.Y = 300;
                        }
                    }
                }

                foreach (Food intersection in intersections.Where(c => c is Food))
                {
                    // remove the food!
                    intersection.Kill();
                    _size++;

                    if (_size < 5)
                    {
                        this.Sprite.Width++;
                        this.Sprite.Height++;
                    }
                    else if (!_evilTransformation)
                    {
                        this.Sprite.Texture = GraphicsManager.GetTexture(NibblyFishGame.Textures.EvilFish.ToString());
                        _evilTransformation = true;
                        this.Sprite.Height += 10;
                        this.Sprite.Width += 10 ;
                        MovementSpeed = 100;
                    }

                    
                }
            }

            base.Update(gameTime);
        }
    }
}
