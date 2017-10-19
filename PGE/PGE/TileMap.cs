using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGE
{
    /// <summary>
    /// 
    /// </summary>
    class TileMap
    {
        /// <summary>
        /// Height (tiles).
        /// </summary>
        private int _height;

        /// <summary>
        /// Source TileSet.
        /// </summary>
        private TileSet tileSet;

        /// <summary>
        /// Width (tiles).
        /// </summary>
        private int _width;

        /// <summary>
        /// Accessor to `_height`.
        /// </summary>
        public int Height
        {
            get
            {
                return _height;
            }
        }

        /// <summary>
        /// Accessor to `_width`.
        /// </summary>
        public int Width
        {
            get
            {
                return _width;
            }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="ts">Source TileSet</param>
        public TileMap(TileSet ts, int mapWidth, int mapHeight)
        {
            _height = mapHeight;
            tileSet = ts;
            _width = mapWidth;
        }

        public void Draw()
        {
        }
    }
}
