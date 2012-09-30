using System;

namespace Spaceship
{
#if WINDOWS || XBOX
    static class Program
    {
        public static SpaceshipGame Game;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Game = new SpaceshipGame())
            {
                Game.Run();
            }
        }
    }
#endif
}

