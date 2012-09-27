using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace ExLib.MovementBehaviour.Keyboard
{
    public class KeyboardConfiguration
    {
        public Keys Up;
        public Keys Down;
        public Keys Left;
        public Keys Right;

        public KeyboardConfiguration()
        {
            Up = Keys.W;
            Down = Keys.S;
            Left = Keys.A;
            Right = Keys.D;
        }
    }
}
