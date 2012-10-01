using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExLib.Objects;
using ExLib.Interfaces;


namespace ExLib.Bases
{
    public abstract class GameScreen : IDrawable, IUpdatable
    {
        public List<Element> Elements;

        public List<GameScreen> Children;

        public bool Enabled { get; set; }

        public GameScreen()
        {
            Elements = new List<Element>();
            Children = new List<GameScreen>();

            Enabled = true;
        }

        public abstract void Update(Microsoft.Xna.Framework.GameTime gameTime);
        public abstract void Draw(Microsoft.Xna.Framework.GameTime gameTime);

        public abstract void Initialise();
    }
}
