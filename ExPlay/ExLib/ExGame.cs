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
using ExLib.Managers;
using ExLib.Interfaces;
using ExLib.Objects;
using ExLib.Bases;

namespace ExLib
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public abstract class ExGame : Microsoft.Xna.Framework.Game
    {
        public static ExGame GameRef { get; private set; }

        public static GameWindow ClientWindow;

        public ExGame()
        {
            GameRef = this;

            ClientWindow = Window;
            
            GraphicsManager.GraphicsDeviceManager = new GraphicsDeviceManager(this);

            GraphicsManager.GraphicsDeviceManager.PreferredBackBufferWidth = GraphicsManager.RESOLUTION_X;
            GraphicsManager.GraphicsDeviceManager.PreferredBackBufferHeight = GraphicsManager.RESOLUTION_Y;
            
            ClientWindow.AllowUserResizing = true;

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            GraphicsManager.SpriteBatch = new SpriteBatch(GraphicsDevice);

            GraphicsManager.Initialise(TextureList, GameFonts, () => AnimationList);
            ElementManager.Initialise();
            InputManager.Initialise();

            base.Initialize();
        }

        public abstract List<GameFont> GameFonts { get; }

        public abstract List<string> TextureList { get; }

        public abstract List<Animation> AnimationList { get; } 

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            InputManager.Update();
            ElementManager.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected sealed override void Draw(GameTime gameTime)
        {
            GraphicsManager.BeginDraw(gameTime);

            // Draw decorative items
            ElementManager.Draw(gameTime);

            PerformDraw(gameTime);

            GraphicsManager.EndDraw(gameTime);

            base.Draw(gameTime);
        }

        protected abstract void PerformDraw(GameTime gameTime);

        public abstract GameScreen GameScreen { get; }
    }
}
