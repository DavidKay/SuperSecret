using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExLib.Bases;
using Microsoft.Xna.Framework;
using NibblyFish.GameScreens;
using NibblyFish.Actors;
using ExLib.Managers;
using ExLib.MovementBehaviour.Keyboard;

namespace NibblyFish.Managers
{
  class GameManager
  {
    private static GameScreen _loadingScreen;
    private static GameScreen _inGameScreen;
    private static GameScreen _titleScreen;

    private static GameScreen _aquariumScreen; // sub gamescreen of either titleScreen or inGameScreen

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
        if(_currentGameState == CurrentGameState.Loading)
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

    private static List<EvilFish> _evilFish;

    private static int _numEvilFish = 10;
    private static int _numFood = 20;

    private static Rectangle _aquariumBounds = new Rectangle(0, 0, GraphicsManager.RESOLUTION_X, GraphicsManager.RESOLUTION_Y);

    public static Random Random = new Random();



    internal static void SetupAquarium(AquariumScreen aquariumScreen)
    {
      _evilFish = new List<EvilFish>();

      for(int i = 0; i < _numEvilFish; i++)
      {
        EvilFish evilFish = new EvilFish();

        // randomise its location
        evilFish.X = Random.Next(_aquariumBounds.Left, _aquariumBounds.Right);
        evilFish.Y = Random.Next(_aquariumBounds.Top, _aquariumBounds.Bottom);

        aquariumScreen.Elements.Add(evilFish);
      }


      for(int i = 0; i < _numFood; i++)
      {
        Food food = new Food();

        // randomise its location
        food.X = Random.Next(_aquariumBounds.Left, _aquariumBounds.Right);
        food.Y = Random.Next(_aquariumBounds.Top, _aquariumBounds.Bottom);

        aquariumScreen.Elements.Add(food);
      }

      _aquariumScreen = aquariumScreen;

      // Temporary
      SetupPlayers();
    }

    internal static void SetupPlayers()
    {

      PlayerFish playerFish = new PlayerFish()
          {
            MovementBehaviour = new KeyboardMovementBehaviour(0)
          };

      playerFish.X = 30;
      playerFish.Y = 300;

      _aquariumScreen.Elements.Add(playerFish);

      playerFish.Initialize();

      PlayerFish playerFish2 = new PlayerFish()
      {
        MovementBehaviour = new KeyboardMovementBehaviour(1)
      };

      playerFish2.X = 30;
      playerFish2.Y = 300;

      _aquariumScreen.Elements.Add(playerFish2);

      playerFish2.Initialize();
    }
  }
}
