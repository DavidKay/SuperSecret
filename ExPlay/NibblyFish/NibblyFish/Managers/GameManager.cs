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
using NibblyFish.PlayerData;

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
          if (_currentGameState == CurrentGameState.Loading)
              return _loadingScreen;
          else if (_currentGameState == CurrentGameState.TitleScreen)
              return _titleScreen;
          else
              return _inGameScreen;
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

    public static void ShowTitleScreen()
    {
      _titleScreen = new TitleScreen();
      _currentGameState = CurrentGameState.TitleScreen;

      _titleScreen.Initialise();
    }

    public static void StartNewGame()
    {
        _inGameScreen = new IngameScreen();
        _currentGameState = CurrentGameState.Ingame;

        _inGameScreen.Initialise();
    }

    private static List<EvilFish> _evilFish;

    private static int _numEvilFish = 10;
    private static int _numFood = 20;
    private static int _numPlayers = 2;

    private static Rectangle _aquariumBounds = new Rectangle(0, 0, GraphicsManager.RESOLUTION_X, GraphicsManager.RESOLUTION_Y);

    public static Random Random = new Random();



    internal static void SetupAquarium(AquariumScreen aquariumScreen)
    {
      _evilFish = new List<EvilFish>();

      for(int i = 0; i < _numEvilFish; i++)
      {
        EvilFish evilFish = new EvilFish();

        // randomise its location
        evilFish.Position = new Vector2(Random.Next(_aquariumBounds.Left, _aquariumBounds.Right),
                                        Random.Next(_aquariumBounds.Top, _aquariumBounds.Bottom));

        aquariumScreen.Elements.Add(evilFish);
      }


      for(int i = 0; i < _numFood; i++)
      {
        Food food = new Food();

        // randomise its location
        food.Position = new Vector2(Random.Next(_aquariumBounds.Left, _aquariumBounds.Right),
                                    Random.Next(_aquariumBounds.Top, _aquariumBounds.Bottom));

        aquariumScreen.Elements.Add(food);
      }

      _aquariumScreen = aquariumScreen;

      // Temporary
      //SetupPlayers();
    }

    public static List<Player> gamePlayers = new List<Player>();

    internal static void SetupPlayers()
    {
        if (_numPlayers >= 1)
        {
            Player player1 = new Player(0);
            PlayerFish playerFish = new PlayerFish(player1)
            {
                // Keyboard input 1
                MovementBehaviour = new KeyboardMovementBehaviour(0),
                RespawnPoint = new Point(30, (int)((GraphicsManager.ScreenHeight * 0.5) - (GraphicsManager.GetSprite(NibblyFishGame.Textures.DiddyFish).Height * 0.5)))
            };

            playerFish.Position.X = playerFish.RespawnPoint.X;
            playerFish.Position.Y = playerFish.RespawnPoint.Y;

            _aquariumScreen.Elements.Add(playerFish);

            playerFish.Initialize();
        }

        if (_numPlayers >= 2)
        {
            Player player2 = new Player(1);

            PlayerFish playerFish = new PlayerFish(player2)
            {
                // Keyboard input 1
                MovementBehaviour = new KeyboardMovementBehaviour(1),
                RespawnPoint = new Point(GraphicsManager.ScreenWidth - 30, (int)((GraphicsManager.ScreenHeight * 0.5) - (GraphicsManager.GetSprite(NibblyFishGame.Textures.DiddyFish).Height * 0.5)))
            };

            playerFish.Position.X = playerFish.RespawnPoint.X;
            playerFish.Position.Y = playerFish.RespawnPoint.Y;

            _aquariumScreen.Elements.Add(playerFish);

            playerFish.Initialize();
        }
    }
  }
}
