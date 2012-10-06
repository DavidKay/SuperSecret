using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using ExLib;
using ExLib.Objects;

using Microsoft.Xna.Framework.Graphics;
using NibblyFish.Managers;
using NibblyFish.GameScreens;

namespace NibblyFish
{
  public class NibblyFishGame : ExGame
  {
    public static Rectangle PLAYFIELD = new Rectangle(0, 0, 1024, 768);

    public static int PLAYFIELDSIDESAFEZONEWIDTH = 128;

    /// <summary>
    /// Represents the area in which the killer piranas' roam.
    /// </summary>
    public static Rectangle DANGERFIELD = new Rectangle(
      PLAYFIELDSIDESAFEZONEWIDTH,
      0,
      PLAYFIELD.Width - PLAYFIELDSIDESAFEZONEWIDTH,
      PLAYFIELD.Height);

    public enum Textures
    {
      EvilFish,
      background1,
      DiddyFish,
      Food
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

        //List<AnimationFrame> jumpingFrogFrames = new List<AnimationFrame>();

        //jumpingFrogFrames.Add(new AnimationFrame(50, Textures.GreenFrogJump));
        //jumpingFrogFrames.Add(new AnimationFrame(50, Textures.GreenFrogJump2));

        //Animation JumpingFrog = new Animation("JumpingFrog", jumpingFrogFrames);

        //animations.Add(JumpingFrog);

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
      get
      {
        return GameManager.CurrentGameScreen;
      }
    }
  }
}
