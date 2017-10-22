using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGE
{
    class MapGenerator
    {
        public static int[,] NextMap(int mapWidth, int mapHeight)
        {
            int[,] map = new int[mapHeight, mapWidth];

            // Fill map w/ random tiles:
            for (int row = 0; row < mapHeight; row++)
            {
                for (int column = 0; column < mapWidth; column++)
                {
                    map[row, column] = 12;
                }
            }

            return map;
        }
    }
}
