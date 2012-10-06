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
        public Keys ChangeColourRed;
        public Keys ChangeColourOrange;
        public Keys ChangeColourBlue;
        public Keys ChangeColourGreen;

        public KeyboardConfiguration()
        {
            Up = Keys.W;
            Down = Keys.S;
            Left = Keys.A;
            Right = Keys.D;
            ChangeColourRed = Keys.D1;
            ChangeColourOrange = Keys.D2;
            ChangeColourBlue = Keys.D3;
            ChangeColourGreen = Keys.D4;
        }
    }
}
