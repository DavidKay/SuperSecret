using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExLib.Interfaces
{
    public interface IMovementBehaviour
    {
        List<ExLib.MovementBehaviour.Movements.MovementsEnum> GetMovements();
    }
}
