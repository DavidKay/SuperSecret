using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExLib.Objects;
using ExLib.Managers;

namespace NibblyFish.Elements
{
    public class Background : Element
    {
        public Background()
            : base(GraphicsManager.GetSprite(NibblyFishGame.Textures.background1, GraphicsManager.RESOLUTION_X, GraphicsManager.RESOLUTION_Y), 0, 0)
        {
            
        }
    }
}
