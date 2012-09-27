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

        public static List<Sprite> Sprites;

        public static RenderTarget2D RenderTarget;

        private static List<string> _textures;

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

        internal static void Initialise(List<string> textures)
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

            _textures = textures;

            LoadTextures();
        }

        private static void LoadTextures()
        {
            Sprites = new List<Sprite>();

            _textures.ForEach(c => Sprites.Add(new Sprite(c)));
        }

        public static void DrawSprite(Sprite sprite, Point location)
        {
            SpriteBatch.Draw(
                sprite.Texture,
                new Vector2(location.X, location.Y),
                Color.White);
        }

        public static Sprite GetSprite(string texturesEnum)
        {
            return Sprites.Single(c => c.Name == texturesEnum);
        }

        public static Sprite GetSprite(Enum texturesEnum)
        {
            return Sprites.Single(c => c.Name == texturesEnum.ToString());
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
    }
}
