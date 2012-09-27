using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExLib;
using Frogger.Managers;

namespace Frogger
{
    public class FroggerGame : ExGame
    {
        public enum Textures
        {
            GreenFrog,
            GrassTile,
            RoadTile,
            WaterTile,
            Car
        }

        public override List<string> TextureList
        {
            get
            {
                List<string> toReturn = new List<string>();
                Enum.GetValues(typeof(Textures)).Cast<Textures>().ToList().ForEach(c => toReturn.Add(c.ToString()));
                return toReturn;
            }
        }

        protected override void Initialize()
        {
            base.Initialize();

            GameManager.Initialize();
        }

        protected override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            GameManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void PerformDraw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            GameManager.Draw(gameTime);
        }
    }
}
