using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using ExLib.Objects;
using ExLib.Interfaces;
using ExLib.Bases;

namespace ExLib.Managers
{
    public static class ElementManager
    {
        internal static void Initialise()
        {
            
        }

        
        public static void Draw(GameTime gameTime)
        {
            // May need to re-add this or write something similar
            // in order to display background non-interactive elements eg. starfield

            //GameElements.Where(c => c.IsBackgroundElement).ToList().ForEach(c => c.Draw(gameTime));
        }

        internal static void Update(GameTime gameTime)
        {
            GetScreenElements().Where(c => c is IUpdatable).ToList().ForEach(c => ((IUpdatable)c).Update(gameTime));
        }

        private static List<Element> GetScreenElements()
        {
            // Recursively get all elements from nested game screens

            List<Element> CombinedElements = new List<Element>();

            RecurseChildren(ExGame.GameRef.GameScreen, ref CombinedElements);

            return CombinedElements;
        }

        private static void RecurseChildren(GameScreen gameScreen, ref List<Element> combinedElements)
        {
            foreach (Element element in gameScreen.Elements)
            {
                combinedElements.Add(element);
            }

            foreach (GameScreen childScreen in gameScreen.Children)
            {
                RecurseChildren(childScreen, ref combinedElements);
            }
        }

        public static List<Element> GetIntersections(Rectangle rect)
        {
            List<Element> IntersectionList = new List<Element>();

            foreach (Element e in GetScreenElements())
            {
                if (CheckIntersect(e, rect))
                    IntersectionList.Add(e);
            }

            return IntersectionList;
        }

        public static List<Element> GetIntersections(Element a)
        {
            List<Element> IntersectionList = new List<Element>();

            foreach (Element e in GetScreenElements().Where(c => !c.Equals(a)))
            {
                if (CheckIntersect(a, e))
                    IntersectionList.Add(e);
            }

            return IntersectionList;
        }

        public static List<Element> GetIntersections(Element a, List<Element> elements)
        {
            List<Element> IntersectionList = new List<Element>();

            foreach (Element e in elements)
            {
                if (CheckIntersect(a, e))
                    IntersectionList.Add(e);
            }

            return IntersectionList;
        }

        public static List<Element> GetIntersections(Element a, List<Type> types)
        {
            List<Element> IntersectionList = new List<Element>();

            foreach (Element e in GetScreenElements().Where(c => types.Contains(c.GetType())))
            {
                if (CheckIntersect(a, e))
                    IntersectionList.Add(e);
            }

            return IntersectionList;
        }

        public static bool CheckIntersect(Element a, Rectangle rect)
        {
            if (a.IsBackgroundElement) 
                return false;

            var ax = a.X;
            var ay = a.Y;
            var aw = a.Sprite.Width;
            var ah = a.Sprite.Height;

            var bx = rect.X;
            var by = rect.Y;
            var bw = rect.Width;
            var bh = rect.Height;

            if (
                (ax >= bx && ax <= bx + bw) // top left dot lies within b horizontally
                &&
                (ay >= by && ay <= by + bh) // top left dot lies within b vertically
            )
            {
                return true;
            }

            if (
                (ax + aw >= bx && ax + aw <= bx + bw) // top right dot lies within b horizontally
                &&
                (ay >= by && ay <= by + bh) // top right dot lies within b vertically
            )
            {
                return true;
            }
            
            if (
                (ax + aw >= bx && ax + aw <= bx + bw) // bottom right dot lies within b horizontally
                &&
                (ay + ah >= by && ay + ah <= by + bh) // bottom right dot lies within b vertically
            )
            {
                return true;
            }

            if (
                (ax >= bx && ax <= bx + bw) // bottom left dot lies within b horizontally
                &&
                (ay + ah >= by && ay + ah <= by + bh) // bottom left dot lies within b vertically
            )
            {
                return true;
            }

            // repeat tests in reverse in case a encompasses b

            if (
                (bx >= ax && bx <= ax + aw) // top left dot lies within a horizontally
                &&
                (by >= ay && by <= ay + ah) // top left dot lies within a vertically
            )
            {
                return true;
            }

            if (
                (bx + bw >= ax && bx + bw <= ax + aw) // bottom right dot lies within b horizontally
                &&
                (by + bh >= ay && by + bh <= ay + ah) // bottom right dot lies within b vertically
            )
            {
                return true;
            }

            if (
                (bx + bw >= ax && bx + bw <= ax + aw) // top right dot lies within b horizontally
                &&
                (by >= ay && by <= ay + ah) // top right dot lies within b vertically
            )
            {
                return true;
            }

            if (
                (bx >= ax && bx <= ax + aw) // bottom left dot lies within b horizontally
                &&
                (by + bh >= ay && by + bh <= ay + ah) // bottom left dot lies within b vertically
            )
            {
                return true;
            }

            return false;
        }

        public static bool CheckIntersect(Element a, Element b)
        {
            return CheckIntersect(a, new Rectangle(b.X, b.Y, b.Sprite.Width, b.Sprite.Height));
        }
    }
}
