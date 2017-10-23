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
        /// 
        /// </summary>
        int _height;

        /// <summary>
        /// 
        /// </summary>
        int _width;

        /// <summary>
        /// Graphics context to draw to.
        /// </summary>
        Graphics canvas;

        /// <summary>
        /// Location.
        /// </summary>
        Point location;

        /// <summary>
        /// Terrain TileMap.
        /// </summary>
        TileMap terrainMap;

        public int Height
        {
            get
            {
                return _height;
            }
        }

        public int Left
        {
            get
            {
                return location.X;
            }

            set
            {
                location.X = value;
            }            
        }

        public int Top
        {
            get
            {
                return location.Y;
            }

            set
            {
                location.Y = value;
            }
        }

        public int Width
        {
            get
            {
                return _width;
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="g">Graphics context to draw to.</param>
        /// <param name="terrain">Terrain TileMap.</param>
        public Viewport(Graphics g, TileMap terrain, int width, int height)
        {
            _height = height;
            _width = width;
            canvas = g;
            location = new Point(0, 0);
            terrainMap = terrain;
        }

        /// <summary>
        /// Draw to graphics context `canvas`.
        /// </summary>
        public void Draw()
        {
            int columns = Width / 32;
            int rows = Height / 32;

            int leftColumn = location.X / 32;
            int topRow = location.Y / 32;
            int bottomRow = topRow + rows;
            int rightColumn = leftColumn + columns;

            for (int row = topRow; row < bottomRow; row++)
            {
                // Iterate over each column in player-visible area:
                for (int column = leftColumn; column < rightColumn; column++)
                {
                    // Calculate offset(s) for smooth-scrolling:
                    int xOffset = 0;
                    int yOffset = 0;

                    // Calculate canvas position to draw to:
                    int x = ((column - leftColumn) * 32) - xOffset;
                    int y = ((row - topRow) * 32) - yOffset;

                    // Fetch & Draw Tile's image at Point(`x`, `y`):
                    Bitmap cellImage = terrainMap.GetCellBitmap(column, row);
                    canvas.DrawImage(cellImage, x, y);
                }
            }
        }
    }
}
