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
        private static List<GamePadState> currentGamePadStates = new List<GamePadState>();

        public static void Update()
        {
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();
            
            currentGamePadStates.Clear();

            if (GamePad.GetState(PlayerIndex.One).IsConnected)
            {
                currentGamePadStates.Add(GamePad.GetState(PlayerIndex.One));
            }
            if (GamePad.GetState(PlayerIndex.Two).IsConnected)
            {
                currentGamePadStates.Add(GamePad.GetState(PlayerIndex.Two));
            }
            if (GamePad.GetState(PlayerIndex.Three).IsConnected)
            {
                currentGamePadStates.Add(GamePad.GetState(PlayerIndex.Three));
            }
            if (GamePad.GetState(PlayerIndex.Four).IsConnected)
            {
                currentGamePadStates.Add(GamePad.GetState(PlayerIndex.Four));
            }

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

        public static bool IsKeyDown(int gamePadIndex, Buttons button)
        {
            return currentGamePadStates[gamePadIndex].IsButtonDown(button);
        }

        internal static void Initialise()
        {
            
        }
    }
}
