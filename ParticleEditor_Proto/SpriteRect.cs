using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ParticleEditor_Proto
{
    public partial class SpriteRect
    {
        public int Count = 0;
        public Rectangle[] Rect;

        public SpriteRect(int total)
        {
            Clear();
            Rect = new Rectangle[total];
        }

        public void Clear()
        {
            Count = 0;
        }

        public void Add(int index)
        {
            if (index == Count) Rect[++Count] = Rect[index];
        }

        public void Remove(int index)
        {
            for (int i = index + 1; i < Count; i++) Rect[i - 1] = Rect[i];
            Count--;
        }
    }
}
