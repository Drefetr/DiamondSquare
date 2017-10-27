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
        public TileMap(TileSet ts, int[,] tiles, int mapSize)
        {
            _height = mapSize;
            _width = mapSize;
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

            if (tileType < 0)
                tileType = 0;

            if (tileType >= 80) // Sand:
            {
                red = 244;
                green = 232;
                blue = 178;
            }

            if (tileType >= 120) // Grass:
            {
                if (tileType <= 140)
                {
                    red = 49;
                    green = 163;
                    blue = 84;
                }
                else if (tileType <= 160)
                {
                    red = 102;
                    green = 194;
                    blue = 164;
                }
                else if (tileType <= 180)
                {
                    red = 178;
                    blue = 226;
                    green = 226;
                }
            }

            if (tileType >= 200) // Mountains
            {
                red = -128 + tileType;
                green = -128 + tileType;
                blue = -128 + tileType;
            }

            if (tileType >= 240) // Snow
            {
                red = 222;
                green = 222;
                blue = 222;
            }

            if (tileType < 80)
            {
                red = 0;
                blue = tileType * 2;
                green = 0;
                // Water.
            }

            if (red < 0)
                red = 0;

            if (blue < 0)
                blue = 0;

            if (green < 0)
                green = 0;

            Color cellColor = Color.FromArgb(255, red, green, blue);

            //Color cellColor = Color.FromArgb(255, tileType, tileType, tileType);

            return cellColor;
        }
    }
}
