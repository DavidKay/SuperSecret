using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ExLib.MovementBehaviour
{
    public class MovementState
    {
        public enum MovementDirection
        {
            N = 0,
            NE = 1,
            E = 2,
            SE = 3,
            S = 4,
            SW = 5,
            W = 6,
            NW = 7

        }

        public DirectionState Direction
        {
            get;
            set;
        }

        private float previousAngle = 0f;

        public float Angle
        {
            get
            {
                float angle;

                if (Direction.NorthEast)
                {
                    angle = MathHelper.ToRadians(45);
                }
                else if (Direction.SouthEast)
                {
                    angle = MathHelper.ToRadians(135);
                }
                else if (Direction.SouthWest)
                {
                    angle = MathHelper.ToRadians(225);
                }
                else if (Direction.NorthWest)
                {
                    angle = MathHelper.ToRadians(315);
                }
                else if (Direction.North)
                {
                    angle = MathHelper.ToRadians(0);
                }
                else if (Direction.East)
                {
                    angle = MathHelper.ToRadians(90);
                }
                else if (Direction.South)
                {
                    angle = MathHelper.ToRadians(180);
                }
                else if (Direction.West)
                {
                    angle = MathHelper.ToRadians(270);
                }
                else
                {
                    return previousAngle;
                }

                previousAngle = angle;

                return angle;
            }
        }

        internal void Update(List<MovementBehaviour.Movements.MovementsEnum> currentMovements)
        {
            Direction.Reset();

            foreach (ExLib.MovementBehaviour.Movements.MovementsEnum movement in currentMovements)
            {
                if (movement == MovementBehaviour.Movements.MovementsEnum.Up)
                {
                    Direction.North = true;
                }
                if (movement == MovementBehaviour.Movements.MovementsEnum.Right)
                {
                    Direction.East = true;
                }
                if (movement == MovementBehaviour.Movements.MovementsEnum.Down)
                {
                    Direction.South = true;
                }
                if (movement == MovementBehaviour.Movements.MovementsEnum.Left)
                {
                    Direction.West = true;
                }
            }
        }

        internal MovementState Clone()
        {
            MovementState m = new MovementState();

            m.Direction = this.Direction.Clone();

            return m;
        }

        public MovementState()
        {
            this.Direction = new DirectionState();
        }
    }
}
