using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using ExLib;
using ExLib.Objects;
using Spaceship.Managers;

namespace Spaceship
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class SpaceshipGame : ExGame
    {
        public enum Textures
        {
            Point
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

        public override List<Animation> AnimationList
        {
            get
            {
                List<Animation> animations = new List<Animation>();

                return animations;
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
