using System;

namespace NibblyFish
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (NibblyFishGame game = new NibblyFishGame())
            {
                game.Run();
            }
        }
    }
#endif
}

