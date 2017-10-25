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
        /// 
        /// </summary>
        private int[,] map;

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
        public TileMap(TileSet ts, int[,] tiles, int mapWidth, int mapHeight)
        {
            _height = mapHeight;
            _width = mapWidth;
            map = tiles;
            tileSet = ts;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        public Bitmap GetCellBitmap(int column, int row)
        {
            if (column > Width)
            {
                column -= Width;
            }

            if (column < 0)
            {
                column += Width;
            }

            if (row > Height)
            {
                row -= Height;
            }

            if (row < 0)
            {
                row += Height;
            }

            int tileType = map[row, column];
            Bitmap cellImage = tileSet.GetTileBitmap("" + tileType);
            return cellImage;
        }

        public Color GetCellColor(int column, int row)
        {
            if (column > Width)
            {
                column -= Width;
            }

            if (column < 0)
            {
                column += Width;
            }

            if (row > Height)
            {
                row -= Height;
            }

            if (row < 0)
            {
                row += Height;
            }

            int tileType = map[row, column];
            int red = 0;
            int green = 0;
            int blue = 0;

            if (tileType >= 10) // Grass:
            {
                green = tileType * 10;
            }

            if (tileType >= 18) // Mountains
            {
                red = (tileType * 6);
                green = (tileType * 6);
                blue = (tileType * 6);
            }

            if (tileType >= 24) // Snow
            {
                red = 222;
                green = 222;
                blue = 222;
            }

            if (tileType < 10)
            {
                blue = tileType * 24;
                // Water.
            }

            Color cellColor = Color.FromArgb(255, red, green, blue);
            return cellColor;
        }
    }
}
