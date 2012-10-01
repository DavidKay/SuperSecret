using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExLib.Interfaces;
using ExLib.MovementBehaviour;
using Microsoft.Xna.Framework;

namespace ExLib.Objects
{
    public abstract class Actor : Element, IUpdatable
    {
        public IMovementBehaviour MovementBehaviour;

        protected MovementState movementState;
        protected List<Movements.MovementsEnum> currentMovements;

        public void Initialize()
        {
            movementState = new MovementState();
        }

        protected void CaptureMovement()
        {
            currentMovements = MovementBehaviour.GetMovements();

            movementState.Update(currentMovements);
        }

        public new virtual void Update(GameTime gameTime)
        {
            CaptureMovement();
            PerformMovement(gameTime);

            base.Update(gameTime);
        }

        protected virtual void PerformMovement(GameTime gameTime)
        {
            return;
        }
    }
}
