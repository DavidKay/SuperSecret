using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Microsoft.Xna.Framework;
using ExLib.Objects;

namespace ExLib.Managers
{
    public static class GraphicsManager
    {
        public static GraphicsDeviceManager GraphicsDeviceManager;

        public static string GraphicsFolder;

        public static SpriteBatch SpriteBatch;

        public static List<ExLib.Objects.GameTexture> Textures;

        public static RenderTarget2D RenderTarget;

        private static List<string> _textureNames;

        private static List<GameFont> _gameFonts;

        private static List<Animation> _animationList;

        public const int RESOLUTION_X = 640;
        public const int RESOLUTION_Y = 480;

        public static int ScreenWidth
        {
            get
            {
                return ExGame.ClientWindow.ClientBounds.Width;
            }
        }
        
        public static int ScreenHeight
        {
            get
            {
                return ExGame.ClientWindow.ClientBounds.Height;
            }
        }

        internal static void Initialise(List<string> textureNames, List<GameFont> gameFonts, Func<List<Animation>> animations)
        {
            RenderTarget = new RenderTarget2D(
                GraphicsDeviceManager.GraphicsDevice,
                640,
                480,
                false,
                GraphicsDeviceManager.GraphicsDevice.PresentationParameters.BackBufferFormat,
                DepthFormat.Depth24);

            string assemblyPath = System.Reflection.Assembly.GetAssembly(typeof(ExGame)).Location;
            string directory = Path.GetDirectoryName(assemblyPath);

            GraphicsFolder = directory + @"\Graphics";

            _gameFonts = gameFonts;

            _textureNames = textureNames;

            LoadTextures();

            _animationList = animations();
        }

        private static void LoadTextures()
        {
            Textures = new List<Objects.GameTexture>();

            _textureNames.ForEach(textureName =>
                {
                    string filePath = GraphicsManager.GraphicsFolder + @"\" + textureName + ".png";

                    using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                    {
                        var texture = Texture2D.FromStream(GraphicsManager.GraphicsDeviceManager.GraphicsDevice, fileStream);

                        GameTexture gameTexture = new GameTexture(texture, textureName);

                        Textures.Add(gameTexture);
                    }
                });
        }

        public static void DrawSprite(Sprite sprite, Point location)
        {
            SpriteBatch.Draw(
                sprite.Texture.Texture2D,
                new Rectangle(location.X, location.Y, sprite.Width, sprite.Height),
                sprite.Color);

        }

        public static SpriteFont GetFont(string fontName)
        {
            return _gameFonts.Single(c => c.Name == fontName).SpriteFont;
        }

        public static void DrawText(string fontName, string text, int x, int y)
        {
            DrawText(_gameFonts.Single(c => c.Name == fontName).SpriteFont, text, x, y);
        }

        public static void DrawText(SpriteFont spriteFont, string text, int x, int y)
        {
            SpriteBatch.DrawString(spriteFont, text, new Vector2(x, y), Color.White);
        }

        public static GameTexture GetTexture(string name)
        {
            return Textures.SingleOrDefault(c => c.TextureName == name);
        }

        internal static void BeginDraw(GameTime gameTime)
        {
            GraphicsDeviceManager.GraphicsDevice.SetRenderTarget(RenderTarget);

            GraphicsDeviceManager.GraphicsDevice.Clear(Color.Black);

            SpriteBatch.Begin(); 
        }

        internal static void EndDraw(GameTime gameTime)
        {
            SpriteBatch.End();

            GraphicsDeviceManager.GraphicsDevice.SetRenderTarget(null);

            GraphicsDeviceManager.GraphicsDevice.Clear(Color.Black);

            SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend,
                        SamplerState.LinearClamp, DepthStencilState.Default,
                        RasterizerState.CullNone);

            SpriteBatch.Draw(RenderTarget, new Rectangle(0, 0, ScreenWidth, ScreenHeight), Color.White);

            SpriteBatch.End();

        }

        internal static Animation GetAnimation(string AnimationName)
        {
            return _animationList.Single(c => c.Name == AnimationName);
        }

        public static Sprite GetSprite(string textureName)
        {
            return new Sprite(GetTexture(textureName));
        }

        public static Sprite GetSprite(string textureName, int width, int height)
        {
            return new Sprite(GetTexture(textureName), width, height);
        }

        public static Sprite GetSprite(Enum textureName)
        {
            return GetSprite(textureName.ToString());
        }

        public static Sprite GetSprite(Enum textureName, int width, int height)
        {
            return GetSprite(textureName.ToString(), width, height);
        }
    }
}
