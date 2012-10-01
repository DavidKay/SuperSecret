using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExLib.Interfaces;
using Microsoft.Xna.Framework;
using ExLib.Objects;
using ExLib.Managers;
using Frogger.Actors;
using ExLib.MovementBehaviour.Keyboard;
using ExLib;
using ExLib.Other;
using ExLib.Bases;
using Frogger.GameScreens;

namespace Frogger.Managers
{
    public static class GameManager
    {
        private static GameScreen _loadingScreen;
        private static GameScreen _inGameScreen;

        private static CurrentGameState _currentGameState;

        public static GameScreen CurrentGameScreen
        {
            get
            {
                if (_currentGameState == CurrentGameState.Loading)
                    return _loadingScreen;
                else
                    return _inGameScreen;
            }
        }

        public enum CurrentGameState
        {
            Loading,
            Ingame
        }

        public static void Initialize(GameScreen initialGameScreen)
        {
            _currentGameState = CurrentGameState.Loading;

            _loadingScreen = new SplashScreen();
            _loadingScreen.Initialise();
        }

        internal static void Update(GameTime gameTime)
        {
            CurrentGameScreen.Update(gameTime);   
        }

        public static void Draw(GameTime gameTime)
        {
            CurrentGameScreen.Draw(gameTime);
        }

        private const int TILE_WIDTH = 32;
        private const int TILE_HEIGHT = 32;

        public static List<Actor> Players = new List<Actor>();


        public static void StartNewGame()
        {
            _inGameScreen = new IngameScreen();

            _inGameScreen.Initialise();

            LevelManager.Initialise();

            LevelManager.SetLevel(4);

            var allElements = LevelManager.CurrentLevel.GetAllElements();

            allElements.ForEach(c => _inGameScreen.Elements.Add(c));

            // Add player frogs
            Actor player = new Frog()
            {
                Sprite = GraphicsManager.GetSprite(FroggerGame.Textures.GreenFrog),
                X = 320,
                Y = 448,
                MovementBehaviour = new KeyboardMovementBehaviour(0)
            };

            Players.Add(player);

            Actor car = new Car()
            {
                Sprite = GraphicsManager.GetSprite(FroggerGame.Textures.Car),
                X = GraphicsManager.RESOLUTION_X,
                Y = 230
            };

            _inGameScreen.Elements.Add(player); 
            _inGameScreen.Elements.Add(car);

            car.Initialize();
            player.Initialize();

            _currentGameState = CurrentGameState.Ingame;
        }
    }
}
