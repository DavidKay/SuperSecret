using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using ExLib.Objects;

namespace ExLib.Managers
{
    public static class ActorManager
    {
        public static List<Actor> Actors { get; private set; }

        internal static void Initialise()
        {
            Actors = new List<Actor>();
        }

        public static void AddActor(Actor actor)
        {
            if (!Actors.Contains(actor))
            {
                Actors.Add(actor);
                ElementManager.GameElements.Add(actor);
            }
        }

        public static void RemoveActor(Actor actor)
        {
            if (Actors.Contains(actor))
            {
                Actors.Remove(actor);
                ElementManager.GameElements.Remove(actor);
            }
        }

        public static void Update(GameTime gameTime)
        {
            Actors.ForEach(c => c.Update(gameTime));
        }
    }
}
