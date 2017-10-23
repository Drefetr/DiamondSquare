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
        /// Default constructor.
        /// </summary>
        public GameManager(Random r, Graphics g, int width, int height)
        {
            canvas = g;
            random = r;

            // Instantiate terrain TileSet:
            TileSet terrainTileSet = new TileSet("Resources/Tiles");

            // Fetch next procedural map:
            int mapHeight = 1025;
            int mapWidth = 1025;

            int[,] map = MapGenerator.NextMap(r, mapWidth, mapHeight);

            // Instantiate terrain TileMap:
            terrainMap 
                = new TileMap(terrainTileSet, map, mapWidth, mapHeight);

            // Instantiate Viewport:
            viewport = new Viewport(g, terrainMap, width, height);
        }

        /// <summary>
        /// Draw to graphics context `canvas`.
        /// </summary>
        public void Draw()
        {
            viewport.Draw();
        }

        /// <summary>
        /// 
        /// </summary>
        public void MoveViewport(EDirection direction)
        {
            int velocity = 8;

            switch (direction)
            {
                case EDirection.NORTH:
                    // North:
                    viewport.Top -= velocity;
                    break;

                case EDirection.WEST:
                    // West:
                    viewport.Left -= velocity;
                    break;

                case EDirection.SOUTH:
                    // South:
                    viewport.Top += velocity;
                    break;

                case EDirection.EAST:
                    // East:
                    viewport.Left += velocity;
                    break;
            }
        }

        /// <summary>
        /// Update state.
        /// </summary>
        public void Update()
        {

        }
    }
}
