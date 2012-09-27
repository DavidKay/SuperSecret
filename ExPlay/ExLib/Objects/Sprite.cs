using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using ExLib.Managers;

namespace ExLib.Objects
{
    public class Sprite
    {
        public Texture2D Texture
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public int Width { get { return Texture.Width; } }
        public int Height { get { return Texture.Height; } }

        public Sprite(Texture2D texture, string name)
        {
            this.Texture = texture;
            this.Name = name;
            
        }

        public Sprite(string textureName)
        {
            this.Name = textureName;

            string filePath = GraphicsManager.GraphicsFolder + @"\" + textureName + ".png";

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                this.Texture = Texture2D.FromStream(GraphicsManager.GraphicsDeviceManager.GraphicsDevice, fileStream);
            }
        }
    }
}
