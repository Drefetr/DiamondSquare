using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGE
{
    class Sprite
    {
        /// <summary>
        /// Graphics context to draw to.
        /// </summary>
        Graphics canvas;

        /// <summary>
        /// Spritesheet Bitmap.
        /// </summary>
        Bitmap spritesheet;

        /// <summary>
        /// Constructor.
        /// </summary>
        public Sprite(Graphics g, string spritesheetPath)
        {
            canvas = g;
            spritesheet = new Bitmap(spritesheetPath);
        }

        /// <summary>
        /// Draw to screen.
        /// </summary>
        public void Draw()
        {
            canvas.DrawImage(spritesheet, 0, 0);
        }
    }
}
