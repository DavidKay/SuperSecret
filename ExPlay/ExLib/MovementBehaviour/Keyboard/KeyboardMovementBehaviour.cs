using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExLib.Interfaces;
using Microsoft.Xna.Framework.Input;
using ExLib.Managers;

namespace ExLib.MovementBehaviour.Keyboard
{
    public class KeyboardMovementBehaviour : IMovementBehaviour
    {
        private KeyboardConfiguration Player1DefaultConfiguration = new KeyboardConfiguration();
        private KeyboardConfiguration Player2DefaultConfiguration = new KeyboardConfiguration() { Up = Keys.Up, Right = Keys.Right, Left = Keys.Left, Down = Keys.Down };

        public KeyboardConfiguration CurrentKeyConfiguration;

        public KeyboardMovementBehaviour(int playerIndex)
        {
            switch (playerIndex)
            {
                case 0:
                    CurrentKeyConfiguration = Player1DefaultConfiguration;
                    break;
                case 1:
                    CurrentKeyConfiguration = Player2DefaultConfiguration;
                    break;
            }
        }

        private List<Movements.MovementsEnum> movementList = new List<Movements.MovementsEnum>();

        public List<Movements.MovementsEnum> GetMovements()
        {
            movementList.Clear();

            if (InputManager.IsKeyDown(CurrentKeyConfiguration.Up))
                movementList.Add(Movements.MovementsEnum.Up);

            if (InputManager.IsKeyDown(CurrentKeyConfiguration.Down))
                movementList.Add(Movements.MovementsEnum.Down);

            if (InputManager.IsKeyDown(CurrentKeyConfiguration.Left))
                movementList.Add(Movements.MovementsEnum.Left);

            if (InputManager.IsKeyDown(CurrentKeyConfiguration.Right))
                movementList.Add(Movements.MovementsEnum.Right);

            return movementList;
        }
    }
}
