using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGE
{
    class Tile
    {
        /// <summary>
        /// 
        /// </summary>
        Bitmap bitmap;

        Color color;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="imagePath"></param>
        public Tile(string imagePath)
        {
            bitmap = new Bitmap(imagePath);
            color = Color.FromArgb(255, 123, 255, 255);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Bitmap GetBitmap()
        {
            return bitmap;
        }

        public Color GetColor()
        {
            return color;
        }
    }
}
