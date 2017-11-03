using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGE
{
    /// <summary>
    /// Manages GameState and changes thereto; commands Level & Viewport.
    /// </summary>
    class GameManager
    {
        /// <summary>
        /// Graphics context to draw to.
        /// </summary>
        private Graphics canvas;

        /// <summary>
        /// Seeded random generator.
        /// </summary>
        private Random random;

        /// <summary>
        /// Terrain TileMap.
        /// </summary>
        private TileMap terrainMap;

        /// <summary>
        /// Viewport.
        /// </summary>
        private Viewport viewport;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="r">Seeded random generator.</param>
        /// <param name="g">Graphics context to draw to.</param>
        /// <param name="width">Viewport width (pixels).</param>
        /// <param name="height">Viewport height (pixels).</param>
        public GameManager(Random r, Graphics g, int width, int height)
        {
            canvas = g;
            random = r;

            // Fetch next procedural map:
            int[,] mapCells = MapGenerator.NextMap(r, Conf.MapSize);

            // Instantiate terrain TileMap:
            terrainMap 
                = new TileMap(mapCells, Conf.MapSize);

            // Instantiate Viewport:
            viewport = new Viewport(g, terrainMap, width, height);
        }

        /// <summary>
        /// Draw to graphics context `canvas` via `viewport`.
        /// </summary>
        public void Draw()
        {
            viewport.Draw();
        }

        /// <summary>
        /// Move viewport in `direction`.
        /// </summary>
        /// <param name="direction">Direction to move viewport.</param>
        public void MoveViewport(EDirection direction)
        {
            switch (direction)
            {
                case EDirection.NORTH:
                    // North / Upwards:
                    viewport.Top -= Conf.Velocity;
                    break;

                case EDirection.WEST:
                    // West / Leftwards:
                    viewport.Left -= Conf.Velocity;
                    break;

                case EDirection.SOUTH:
                    // South / Downwards:
                    viewport.Top += Conf.Velocity;
                    break;

                case EDirection.EAST:
                    // East / Rightwards:
                    viewport.Left += Conf.Velocity;
                    break;
            }
        }
    }
}
