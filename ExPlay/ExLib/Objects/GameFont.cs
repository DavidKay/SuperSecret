using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace ExLib.Objects
{
    public class GameFont
    {
        public SpriteFont SpriteFont { get; set; }
        public string Name { get; set; }

        public GameFont(SpriteFont spriteFont, string fontName)
        {
            this.SpriteFont = spriteFont;
            this.Name = fontName;
        }
    }
}
