using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExLib.Managers;
using Microsoft.Xna.Framework;
using ExLib.Objects;

namespace Frogger.Actors
{
    public class Frog : Actor
    {
        public enum MovementState
        {
            North,
            East,
            South,
            West,
            None
        }

        public MovementState CurrentMovementState = MovementState.None;

        private double TotalMovementAmount = 0;

        private double MovementSpeed = 75;

        protected override void PerformMovement(GameTime gameTime)
        {
            if (CurrentMovementState == MovementState.None)
            {
                if (movementState.Direction.North)
                {
                    Move(MovementState.North);   
                }
                if (movementState.Direction.East)
                {
                    Move(MovementState.East);
                }
                if (movementState.Direction.South)
                {
                    Move(MovementState.South);
                }
                if (movementState.Direction.West)
                {
                    Move(MovementState.West);
                }
            }
            
        }

        private void Move(MovementState movementState)
        {
            CurrentMovementState = movementState;
            this.Sprite.Animate("JumpingFrog");
        }

        public override void Update(GameTime gameTime)
        {
            if (CurrentMovementState != MovementState.None)
            {
                bool stopped = false;

                double movementAmount = (MovementSpeed * gameTime.ElapsedGameTime.TotalSeconds);

                TotalMovementAmount += movementAmount;


                if (TotalMovementAmount >= 32)
                {
                    movementAmount = movementAmount - (TotalMovementAmount - 32);
                    TotalMovementAmount = 0;
                    stopped = true;
                }

                if (CurrentMovementState == MovementState.North)
                {
                    _y -= movementAmount;
                }
                else if (CurrentMovementState == MovementState.East)
                {
                    _x += movementAmount;
                }
                if (CurrentMovementState == MovementState.South)
                {
                    _y += movementAmount;
                }
                if (CurrentMovementState == MovementState.West)
                {
                    _x -= movementAmount;
                }

                if (stopped)
                {
                    CurrentMovementState = MovementState.None;
                    this.Sprite.StopAnimate();
                }

            }

            if (ElementManager.GetIntersections(this, new List<Type>() { typeof(Car) }).Any())
            {
                // death routine
                this.X = 320;
                this.Y = 448;
            }

            base.Update(gameTime);
        }
    }
}
