using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExLib.MovementBehaviour
{
    public class DirectionState
    {
        public void Reset()
        {
            North = false;
            East = false;
            South = false;
            West = false;
        }

        public bool North
        {
            get;
            set;
        }

        public bool NorthEast
        {
            get { return North && East; }
            set { North = East = value; }
        }

        public bool East
        {
            get;
            set;
        }

        public bool SouthEast
        {
            get { return South && East; }
            set { South = East = value; }
        }

        public bool South
        {
            get;
            set;
        }

        public bool SouthWest
        {
            get { return South && West; }
            set { South = West = value; }
        }

        public bool West
        {
            get;
            set;
        }

        public bool NorthWest
        {
            get { return North && West; }
            set { North = West = value; }
        }

        internal DirectionState Clone()
        {
            DirectionState newDirectionState = new DirectionState();

            newDirectionState.North = North;
            newDirectionState.North = East;
            newDirectionState.North = South;
            newDirectionState.North = West;

            return newDirectionState;
        }
    }
}
