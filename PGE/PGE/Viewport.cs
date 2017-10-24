using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGE
{
    /// <summary>
    /// Manages display of visible area.
    /// </summary>
    class Viewport
    {
        /// <summary>
        /// Height of Viewport (pixels).
        /// </summary>
        int _height;

        /// <summary>
        /// 
        /// </summary>
        private int _tileSize;

        /// <summary>
        /// Width of Viewport (pixels).
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

        public int TileSize
        {
            get
            {
                return _tileSize;
            }

            set
            {
                _tileSize = value;
            }
        }

        /// <summary>
        /// Height of Viewport (pixels).
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
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

        /// <summary>
        /// Width of Viewport (pixels).
        /// </summary>
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
        /// <param name="width">Width (pixels).</param>
        /// <param name="height">Height (pixels).</param>
        public Viewport(Graphics g, TileMap terrain, int width, int height)
        {
            _height = height;
            _tileSize = Conf.TileWidth;
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
            // Calculate columns/rows:
            int columns = Width / TileSize;
            int rows = Height / TileSize;

            int leftColumn = location.X / 32;
            int topRow = location.Y / 32;
            int bottomRow = topRow + rows;
            int rightColumn = leftColumn + columns;

            for (int row = topRow; row <= bottomRow; row++)
            {
                // Iterate over each column in player-visible area:
                for (int column = leftColumn; column <= rightColumn; column++)
                {
                    // Calculate offset(s) for smooth-scrolling:
                    int xOffset = Left % TileSize;
                    int yOffset = Top % TileSize;

                    // Calculate canvas position to draw to:
                    int x = ((column - leftColumn) * TileSize) - xOffset;
                    int y = ((row - topRow) * TileSize) - yOffset;

                    // Fetch & Draw Tile's image at Point(`x`, `y`):
                    Bitmap cellImage = terrainMap.GetCellBitmap(column, row);
                    Color cellColor = terrainMap.GetCellColor(column, row);
                    SolidBrush cellBrush = new SolidBrush(cellColor);
                    //canvas.DrawImage(cellImage, x, y);

                    canvas.FillRectangle(
                        cellBrush, 
                        x, 
                        y, 
                        TileSize, 
                        TileSize);
                }
            }
        }
    }
}
