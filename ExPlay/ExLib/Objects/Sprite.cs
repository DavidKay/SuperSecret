using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using ExLib.Managers;
using Microsoft.Xna.Framework;

namespace ExLib.Objects
{
    public class Sprite
    {
        private GameTexture _defaultTexture;

        private bool _isAnimating;
        private int _currentFrame;
        private double _elapsedAnimationMilliseconds;

        public Color Color = Color.White;

        public GameTexture Texture
        {
            get
            {
                if (_animation == null || !_isAnimating)
                {
                    return _defaultTexture;
                }

                return _animation.Frames[_currentFrame].Texture;
            }
            set
            {
                _defaultTexture = value;
                _animation = null;
            }
        }

        private Animation _animation;

        private int _width;
        private int _height;


        public int Width { get { return _width; } set { _width = value; } }
        public int Height { get { return _height; } set { _height = value; } }

        public Sprite(GameTexture defaultTexture)
        {
            this._defaultTexture = defaultTexture;

            this._width = defaultTexture.Texture2D.Width;
            this._height = defaultTexture.Texture2D.Height;
        }

        public Sprite(GameTexture defaultTexture, int width, int height)
        {
            this._defaultTexture = defaultTexture;

            this._width = width;
            this._height = height;
        }

        public void Animate(string AnimationName)
        {
            this._animation = GraphicsManager.GetAnimation(AnimationName);
            this._isAnimating = true;
        }

        public void StopAnimate()
        {
            this._animation = null;
            this._isAnimating = false;
        }

        public void Update(GameTime gameTime)
        {
            if (_animation != null && _isAnimating)
            {
                _elapsedAnimationMilliseconds += gameTime.ElapsedGameTime.TotalMilliseconds;

                while (_elapsedAnimationMilliseconds > _animation.Frames[_currentFrame].Duration)
                {
                    _currentFrame++;

                    if (_currentFrame >= _animation.Frames.Count)
                    {
                        _currentFrame = 0;
                    }

                    _elapsedAnimationMilliseconds -= _animation.Frames[_currentFrame].Duration;


                }

            }
            
        }
    }
}
