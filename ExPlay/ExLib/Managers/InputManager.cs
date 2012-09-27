using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace ExLib.Managers
{
    public static class InputManager
    {
        private static KeyboardState previousKeyboardState;
        private static KeyboardState currentKeyboardState;

        public static void Update()
        {
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            CheckKeyboardInterrupts();
        }


        private static void CheckKeyboardInterrupts()
        {
            if (IsKeyPressed(Keys.Escape))
            {
                ExGame.GameRef.Exit();
            }
        }

        public static bool IsKeyPressed(Keys key)
        {
            if (currentKeyboardState.IsKeyDown(key) && !previousKeyboardState.IsKeyDown(key))
                return true;
            else
                return false;
        }

        public static bool IsKeyDown(Keys key)
        {
            return currentKeyboardState.IsKeyDown(key);
        }

        internal static void Initialise()
        {
            
        }
    }
}
