using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExLib.Interfaces;
using Frogger.GameWindows;
using Microsoft.Xna.Framework;
using ExLib.Objects;
using Frogger.Level;
using ExLib.Managers;
using Frogger.Actors;
using ExLib.MovementBehaviour.Keyboard;
using ExLib;
using ExLib.Other;

namespace Frogger.Managers
{
    public static class GameManager
    {
        public static IGameWindow GameWindow;

        public static Viewport GameViewport;

        public static void Initialize()
        {
            GameWindow = new MainScreen();

            GameViewport = new Viewport(0, 0,(int) (GraphicsManager.RESOLUTION_X * 0.5), (int) (GraphicsManager.RESOLUTION_Y * 0.5), GraphicsManager.RESOLUTION_X, GraphicsManager.RESOLUTION_Y);

            GameWindow.Initialise(Program.FroggerGame.Content);
        }

        internal static void Update(GameTime gameTime)
        {
            GameWindow.Update(gameTime);
        }

        public static void Draw(GameTime gameTime)
        {
            GameViewport.Draw(gameTime);
        }

        private const int TILE_WIDTH = 32;
        private const int TILE_HEIGHT = 32;

        public static List<Actor> Players = new List<Actor>();

        public static void StartNewGame()
        {
            LevelManager.Initialise();

            ElementManager.Empty();

            LevelManager.SetLevel(4);

            var allElements = LevelManager.CurrentLevel.GetAllElements();

            allElements.ForEach(c => ElementManager.GameElements.Add(c));

            // Add player frogs
            Actor player = new Frog()
            {
                Sprite = GraphicsManager.GetSprite(FroggerGame.Textures.GreenFrog),
                X = 320,
                Y = 448,
                MovementBehaviour = new KeyboardMovementBehaviour(0)
            };

            Players.Add(player);
            ActorManager.AddActor(player);

            Actor car = new Car()
            {
                Sprite = GraphicsManager.GetSprite(FroggerGame.Textures.Car),
                X = GraphicsManager.RESOLUTION_X,
                Y = 230
            };

            ActorManager.AddActor(car);

            //GameViewport.TrackTarget = player;
            

            car.Initialize();
            player.Initialize();
        }
    }
}
