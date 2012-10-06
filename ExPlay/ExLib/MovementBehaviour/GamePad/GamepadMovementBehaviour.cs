using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExLib.Interfaces;
using ExLib.Managers;
using Microsoft.Xna.Framework.Input;

namespace ExLib.MovementBehaviour.GamePad
{
    class GamepadMovementBehaviour : IMovementBehaviour
    {
        private List<Movements.MovementsEnum> movementList = new List<Movements.MovementsEnum>();

        private GamepadConfiguration gamePadConfiguration;

        public GamepadMovementBehaviour(int playerIndex)
        {
            gamePadConfiguration = new GamepadConfiguration(playerIndex);
        }

        public List<Movements.MovementsEnum> GetMovements()
        {
            movementList.Clear();

            if (InputManager.IsKeyDown(gamePadConfiguration.GamepadIndex, Buttons.DPadUp))
                movementList.Add(Movements.MovementsEnum.Up);

            if (InputManager.IsKeyDown(gamePadConfiguration.GamepadIndex, Buttons.DPadDown))
                movementList.Add(Movements.MovementsEnum.Down);

            if (InputManager.IsKeyDown(gamePadConfiguration.GamepadIndex, Buttons.DPadLeft))
                movementList.Add(Movements.MovementsEnum.Left);

            if (InputManager.IsKeyDown(gamePadConfiguration.GamepadIndex, Buttons.DPadRight))
                movementList.Add(Movements.MovementsEnum.Right);

            return movementList;
        }
    }
}
