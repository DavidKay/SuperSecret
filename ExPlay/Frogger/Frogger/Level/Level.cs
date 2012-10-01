using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Frogger.Elements;
using ExLib.Managers;
using ExLib.Objects;
using Frogger.Managers;

namespace Frogger
{
    public class Level
    {
        public FloorTile[,] Tiles = new FloorTile[15, 20];
        
        public int LevelNumber { get; private set; }

        public Level(int level)
        {
            this.LevelNumber = level;
            this.Tiles = LevelManager.GetFloorTilesForLevel(level);
        }

        public List<Element> GetAllElements()
        {
            List<Element> ElementList = new List<Element>();

            for (int y = 0; y < Tiles.GetLength(1); y++)
            {
                for (int x = 0; x < Tiles.GetLength(0); x++)
                {
                    ElementList.Add(Tiles[x, y]);
                }
            }

            return ElementList;
        }
    }
}
