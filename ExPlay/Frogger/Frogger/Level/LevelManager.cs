using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExLib.Managers;
using Frogger.Elements;

namespace Frogger.Level
{
    public static class LevelManager
    {
        public static Level CurrentLevel
        {
            get;
            private set;
        }

        public static Level SetLevel(int level)
        {
            CurrentLevel = new Level(level);
            return CurrentLevel;
        }

        internal static void Initialise()
        {
            
        }


        private static string[,] _levelData = new string[,] 
        { 
            { "G", "G", "G", "G", "G", "G", "G", "R", "G", "G", "G", "G", "G", "G", "G" }, // 0
            { "G", "W", "G", "G", "G", "G", "G", "R", "G", "G", "G", "G", "G", "G", "G" }, // 1
            { "G", "W", "G", "G", "G", "G", "G", "R", "R", "G", "G", "G", "G", "G", "G" }, // 2
            { "G", "W", "W", "G", "G", "G", "G", "R", "R", "G", "G", "G", "G", "G", "G" }, // 3
            { "G", "W", "W", "G", "G", "G", "G", "R", "R", "R", "G", "G", "G", "G", "G" }, // 4
            { "G", "W", "W", "W", "G", "G", "G", "R", "R", "R", "G", "G", "G", "G", "G" }, // 5
            { "G", "W", "W", "W", "G", "G", "G", "R", "R", "R", "R", "G", "G", "G", "G" }, // 6
            { "G", "W", "W", "W", "W", "G", "G", "R", "R", "R", "R", "G", "G", "G", "G" }, // 7
            { "G", "W", "W", "W", "W", "G", "G", "R", "R", "R", "R", "R", "G", "G", "G" }, // 8
            { "G", "W", "W", "W", "W", "W", "G", "R", "R", "R", "R", "R", "G", "G", "G" }  // 9

        };

        private const int LEVEL_WIDTH = 20;
        private const int LEVEL_HEIGHT = 15;

        public static FloorTile[,] GetFloorTilesForLevel(int level)
        {
            FloorTile[,] floorTiles = new FloorTile[LEVEL_WIDTH, LEVEL_HEIGHT];

            for (int row = 0; row < LEVEL_HEIGHT; row++)
            {
                for (int col = 0; col < LEVEL_WIDTH; col++)
                {
                    Frogger.Elements.FloorTile.FloorTileType floorTileType = 0;

                    if (_levelData[level, row] == "G")
                        floorTileType = Frogger.Elements.FloorTile.FloorTileType.Grass;
                    if (_levelData[level, row] == "W")
                        floorTileType = Frogger.Elements.FloorTile.FloorTileType.Water;
                    if (_levelData[level, row] == "R")
                        floorTileType = Frogger.Elements.FloorTile.FloorTileType.Road;

                    floorTiles[col, row] = new FloorTile(floorTileType) { X = col * 32, Y = row * 32 };
                }
            }

            return floorTiles;
        }
    }
}
