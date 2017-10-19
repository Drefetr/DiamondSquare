using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGE
{
    class GameManager
    {
        /// <summary>
        /// Graphics context to draw to.
        /// </summary>
        private Graphics canvas;

        /// <summary>
        /// Terrain TileMap.
        /// </summary>
        private TileMap terrainMap;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public GameManager(Graphics g)
        {
            // Instantiate terrain TileSet:
            TileSet terrainTileSet = new TileSet("Resources/Tiles");

            // Instantiate terrain TileMap:
            terrainMap = new TileMap(terrainTileSet, 128, 128);
        }

        /// <summary>
        /// Draw to graphics context `canvas`.
        /// </summary>
        public void draw()
        {
            terrainMap.Draw(canvas);
        }

        /// <summary>
        /// Update state.
        /// </summary>
        public void update()
        {

        }
    }
}
