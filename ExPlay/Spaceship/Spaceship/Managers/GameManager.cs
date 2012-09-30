using ExLib.Other;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using ExLib.Managers;
using ExLib.Objects;
using System;
using System.Linq;
using System.Text;
using Spaceship.Elements;

namespace Spaceship.Managers
{
    public static class GameManager
    {
        public static Viewport GameViewport;

        public static void Initialize()
        {
            GameViewport = new Viewport(0, 0, 320, 240, 640, 480);

            StartNewGame();
        }

        internal static void Update(GameTime gameTime)
        {
            
        }

        public static void Draw(GameTime gameTime)
        {
            GameViewport.Draw(gameTime);
        }

        private const int TILE_WIDTH = 32;
        private const int TILE_HEIGHT = 32;

        //public static List<Actor> Players = new List<Actor>();

        static Element StarField = new Starfield();

        public static void StartNewGame()
        {
            ElementManager.Empty();

            ElementManager.GameElements.Add(StarField);
        }
    }
}
