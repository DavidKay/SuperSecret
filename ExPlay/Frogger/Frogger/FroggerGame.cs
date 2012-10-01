using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExLib;
using Frogger.Managers;
using ExLib.Objects;
using Frogger.GameScreens;
using Microsoft.Xna.Framework.Graphics;

namespace Frogger
{
    public class FroggerGame : ExGame
    {
        public enum Textures
        {
            GreenFrog,
            GreenFrogJump,
            GreenFrogJump2,
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

        public override List<GameFont> GameFonts
        {
            get
            {
                List<GameFont> gameFonts = new List<GameFont>();

                gameFonts.Add(new GameFont(Content.Load<SpriteFont>("LoadingFont"), "LoadingFont"));

                return gameFonts;
            }
        }

        public override List<Animation> AnimationList
        {
            get 
            {
                List<Animation> animations = new List<Animation>();

                List<AnimationFrame> jumpingFrogFrames = new List<AnimationFrame>();

                jumpingFrogFrames.Add(new AnimationFrame(50, Textures.GreenFrogJump));
                jumpingFrogFrames.Add(new AnimationFrame(50, Textures.GreenFrogJump2));

                Animation JumpingFrog = new Animation("JumpingFrog", jumpingFrogFrames);

                animations.Add(JumpingFrog);

                return animations;
            }
        }

        protected override void Initialize()
        {
            base.Initialize();

            GameManager.Initialize(new SplashScreen());
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

        public override ExLib.Bases.GameScreen GameScreen
        {
            get { return GameManager.CurrentGameScreen; }
        }
    }
}
