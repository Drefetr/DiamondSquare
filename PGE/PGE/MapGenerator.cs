using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGE
{
    /// <summary>
    /// 
    /// </summary>
    class MapGenerator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <param name="mapWidth"></param>
        /// <param name="mapHeight"></param>
        /// <returns></returns>
        public static int[,] NextMap(Random r, int mapWidth, int mapHeight)
        {
            int[,] heightMap = new int[mapHeight, mapWidth];
            int[,] map = new int[mapHeight, mapWidth];

            // Fill map w/ random tiles:
            for (int row = 0; row < mapHeight; row++)
            {
                for (int column = 0; column < mapWidth; column++)
                {
                    map[row, column] = r.Next(10, 13);
                }
            }

            return map;
        }
    }
}
