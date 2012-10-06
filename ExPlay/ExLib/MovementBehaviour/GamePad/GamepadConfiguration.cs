using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace ExLib.MovementBehaviour.GamePad
{
    public class GamepadConfiguration
    {
        public int GamepadIndex { get; set; }

        public GamepadConfiguration(int gamepadIndex)
        {
            this.GamepadIndex = gamepadIndex;
        }
    }
}
