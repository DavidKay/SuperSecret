using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace ExLib.Objects
{
    public class GameTexture
    {
        public Texture2D Texture2D {get; set;}
        public string TextureName { get; set; }

        public GameTexture(Texture2D texture, string name)
        {
            this.Texture2D = texture;
            this.TextureName = name;
        }
    }
}
