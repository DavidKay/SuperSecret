using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NibblyFish.PlayerData
{
    public class Player
    {
        string Name { get; set; }

        public int PlayerIndex { get; set; }

        public int Score { get; set; }

        public Player(int playerIndex)
        {
            this.PlayerIndex = playerIndex;

            Score = 0;
        }
    }
}
