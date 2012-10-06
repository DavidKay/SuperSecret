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

            if (currentMovements != null )
            {
                if (currentMovements.Contains(ExLib.MovementBehaviour.Movements.MovementsEnum.ChangeColourRed))
                {
                    this.Sprite.Color = Color.Red;
                }
                if (currentMovements.Contains(ExLib.MovementBehaviour.Movements.MovementsEnum.ChangeColourOrange))
                {
                    this.Sprite.Color = Color.Orange;
                }
                if (currentMovements.Contains(ExLib.MovementBehaviour.Movements.MovementsEnum.ChangeColourGreen))
                {
                    this.Sprite.Color = Color.Green;
                }
                if (currentMovements.Contains(ExLib.MovementBehaviour.Movements.MovementsEnum.ChangeColourBlue))
                {
                    this.Sprite.Color = Color.Blue;
                }
            }
            

            var intersections = ElementManager.GetIntersections(this, new List<Type>() { typeof(EvilFish), typeof(Food) });

            if (intersections.Any())
            {
                foreach (EvilFish intersection in intersections.Where(c => c is EvilFish))
                {
                    if (intersection.Sprite.Color != this.Sprite.Color)
                    {
                        // death routine
                        this.X = 0;
                        this.Y = 300;
                    }
                }

                foreach (Food intersection in intersections.Where(c => c is Food))
                {
                    // remove the food!
                    intersection.Kill();
                    
                }
            }

            base.Update(gameTime);
        }
    }
}
