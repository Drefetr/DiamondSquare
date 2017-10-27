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
        /// Construcotr.
        /// </summary>
        /// <param name="r">Seeded random generator.</param>
        /// <param name="g">Graphics context to draw to.</param>
        /// <param name="width">Viewport width (pixels).</param>
        /// <param name="height">Viewport height (pixels).</param>
        public GameManager(Random r, Graphics g, int width, int height)
        {
            canvas = g;
            random = r;

            // Instantiate terrain TileSet:
            TileSet terrainTileSet = new TileSet("Resources/Tiles");

            // Fetch next procedural map:
            int[,] map = MapGenerator.NextMap(r, Conf.MapSize);

            // Instantiate terrain TileMap:
            terrainMap 
                = new TileMap(terrainTileSet, map, Conf.MapSize);

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
            switch (direction)
            {
                case EDirection.NORTH:
                    // North:
                    viewport.Top -= Conf.Velocity;
                    break;

                case EDirection.WEST:
                    // West:
                    viewport.Left -= Conf.Velocity;
                    break;

                case EDirection.SOUTH:
                    // South:
                    viewport.Top += Conf.Velocity;
                    break;

                case EDirection.EAST:
                    // East:
                    viewport.Left += Conf.Velocity;
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void IncrementTileSize()
        {
            if (viewport.TileSize < 64)
            {
                viewport.TileSize++;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void DecrementTileSize()
        {
            if (viewport.TileSize > 1)
            {
                viewport.TileSize--;
            }
        }
    }
}
