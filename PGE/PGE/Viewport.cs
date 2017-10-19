using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGE
{
    class Viewport
    {
        /// <summary>
        /// Graphics context to draw to.
        /// </summary>
        Graphics canvas;

        /// <summary>
        /// 
        /// </summary>
        TileMap terrainMap;

        public Viewport(Graphics g, TileMap terrain)
        {
            canvas = g;
            terrainMap = terrain;
        }

        /// <summary>
        /// Draw to graphics context `canvas`.
        /// </summary>
        public void Draw()
        {
            SolidBrush b = new SolidBrush(Color.Green);
            canvas.FillRectangle(b, 0, 0, 256, 256);
        }
    }
}
