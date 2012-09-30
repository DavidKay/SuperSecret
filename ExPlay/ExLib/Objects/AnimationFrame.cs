using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using ExLib.Managers;

namespace ExLib.Objects
{
    public class AnimationFrame
    {
        public int Duration { get; set; }
        public GameTexture Texture { get; set; }

        public AnimationFrame(int duration, string textureName)
        {
            this.Duration = duration;
            this.Texture = GraphicsManager.GetTexture(textureName);
        }

        public AnimationFrame(int duration, Enum texture)
        {
            this.Duration = duration;
            this.Texture = GraphicsManager.GetTexture(texture.ToString());
        }
    }
}
