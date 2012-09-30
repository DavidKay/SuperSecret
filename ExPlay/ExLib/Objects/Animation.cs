using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExLib.Objects
{
    public class Animation
    {
        // animation contains a list of frames
        public List<AnimationFrame> Frames;

        public string Name { get; set; }

        public Animation(string name, List<AnimationFrame> animationFrames)
        {
            this.Name = name;
            this.Frames = animationFrames;
        }
    }
}
