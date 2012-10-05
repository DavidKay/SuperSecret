using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExLib.Bases;
using Microsoft.Xna.Framework;
using NibblyFish.GameScreens;

namespace NibblyFish.Managers
{
    class GameManager
    {
        private static GameScreen _loadingScreen;
        private static GameScreen _inGameScreen;
        private static GameScreen _titleScreen;

        private static CurrentGameState _currentGameState;

        public enum CurrentGameState
        {
            Loading,
            Ingame,
            TitleScreen
        }

        public static GameScreen CurrentGameScreen
        {
            get
            {
                if (_currentGameState == CurrentGameState.Loading)
                    return _loadingScreen;
                else
                    return _titleScreen;
            }
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

        public static void StartNewGame()
        {
            _titleScreen = new TitleScreen();
            _currentGameState = CurrentGameState.TitleScreen;

            _titleScreen.Initialise();
        }
    }
}
