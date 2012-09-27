using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace ExLib.Interfaces
{
    public interface IGameWindow
    {
        void Initialise(ContentManager contentManager);
        void Draw(GameTime gameTime);
        void Update(GameTime gameTime);
    }
}
