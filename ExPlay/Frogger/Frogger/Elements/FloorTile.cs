using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExLib.Managers;
using ExLib.Objects;

namespace Frogger.Elements
{
    public class FloorTile : Element
    {
        public FloorTileType TileType { get; private set; }

        public enum FloorTileType
        {
            Grass,
            Road,
            Water
        }


        public FloorTile(FloorTileType tileType)
        {
            this.TileType = tileType;
            this.Sprite = GraphicsManager.GetSprite(tileType.ToString() + "Tile");
        }
    }
}
