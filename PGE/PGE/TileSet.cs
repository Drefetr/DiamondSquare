using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGE
{
    class TileSet
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="path">TileSet folder path.</param>
        public TileSet(string path)
        {
        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tileIndex"></param>
        /// <returns></returns>
        public Bitmap GetTileBitmap(int index)
        {
            Bitmap tileBitmap = new Bitmap("Resources/Tiles/1.bmp");
            return tileBitmap;
        }
    }
}
