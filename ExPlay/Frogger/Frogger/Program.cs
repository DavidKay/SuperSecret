using System;

namespace Frogger
{
#if WINDOWS || XBOX
    static class Program
    {
        public static FroggerGame FroggerGame;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (FroggerGame = new FroggerGame())
            {
                FroggerGame.Run();
            }
        }
    }
#endif
}

