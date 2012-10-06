using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExLib.Objects;
using Microsoft.Xna.Framework;
using ExLib.Managers;

namespace ExLib.Other
{
    public class Viewport
    {
        public int X { get; set; }
        public int Y { get; set; }

        private int _centerX;
        private int _centerY;
        public int CenterX { 
            get
            {
                if (TrackTarget == null)
                    return _centerX;

                return TrackTarget.X + ((int)(TrackTarget.Sprite.Width * 0.5));
            }
            set
            {
                if (TrackTarget == null)
                {
                    _centerX = value;
                }
                else
                {
                    throw new Exception("Cannot set viewport target when viewport is set to track an element. Set Target to null before manually adjusting target");
                }
            }
        }
        public int CenterY
        {
            get
            {
                if (TrackTarget == null)
                    return _centerY;

                return TrackTarget.Y + ((int)(TrackTarget.Sprite.Height * 0.5));
            }
            set
            {
                if (TrackTarget == null)
                {
                    _centerY = value;
                }
                else
                {
                    throw new Exception("Cannot set viewport target when viewport is set to track an element. Set Target to null before manually adjusting target");
                }

            }
        }

        public int Width { get; set; }
        public int Height { get; set; }

        public Element TrackTarget { get; set; }

        public Viewport(int x, int y, int centerX, int centerY, int width, int height)
        {
            this.X = x;
            this.Y = y;
            this.CenterX = centerX;
            this.CenterY = centerY;
            this.Width = width;
            this.Height = height;
        }

        public Viewport(int x, int y, Element target, int width, int height)
        {
            this.X = x;
            this.Y = y;
            this.TrackTarget = target;
            this.Width = width;
            this.Height = height;
        }


        public void Draw(GameTime gameTime)
        {
            Rectangle bounds = new Rectangle(
                CenterX - ((int)(Width * 0.5)),
                CenterY - ((int)(Height * 0.5)),
                Width,
                Height);

            var ElementsOnScreen = ElementManager.GetIntersections(bounds);

            // Get all zindexes
            List<int> zindexes = ElementsOnScreen.Select(c => c.ZIndex).Distinct().ToList();

            foreach (int index in zindexes)
            {
                foreach (Element element in ElementsOnScreen.Where(c => c.ZIndex == index))
                {
                    GraphicsManager.DrawSprite(element.Sprite, new Point(element.X + X + (((int)(Width * 0.5)) - CenterX), element.Y + Y + (((int)(Height * 0.5)) - CenterY)));
                }
            }
        }
    }
}
