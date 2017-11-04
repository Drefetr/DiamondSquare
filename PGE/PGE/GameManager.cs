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
        /// Terrain Map.
        /// </summary>
        private Map terrainMap;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="r">Seeded random generator.</param>
        /// <param name="g">Graphics context to draw to.</param>
        /// <param name="width">Viewport width (pixels).</param>
        /// <param name="height">Viewport height (pixels).</param>
        public GameManager(Random r, Graphics g)
        {
            canvas = g;
            random = r;

            // Fetch next procedural map:
            int[,] mapCells = MapGenerator.NextMap(r, Conf.MapSize);

            // Instantiate map:
            terrainMap = new Map(canvas, mapCells, Conf.MapSize);
        }

        /// <summary>
        /// Draw `terrainMap` to graphics context `canvas`.
        /// </summary>
        public void DrawMap()
        {
            terrainMap.Draw();
        }
    }
}
