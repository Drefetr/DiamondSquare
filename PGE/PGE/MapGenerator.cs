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
        private const int shoreAltitude = 0;
        private const int swampAltitude = 10;
        private const int palmtreeAltitude = 15;
        private const int grassAltitude = 20;
        private const int treeAltitude = 30;
        private const int mountainAltitude = 50;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="heightMap"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="stepSize"></param>
        /// <returns></returns>
        private static int AverageDiamond(int[,] heightMap, int x, int y, int stepSize)
        {
            int halfStep = stepSize / 2;
            int N = cyclic(heightMap, x, y - halfStep);
            int E = cyclic(heightMap, x + halfStep, y);
            int S = cyclic(heightMap, x, y + halfStep);
            int W = cyclic(heightMap, x - halfStep, y);
            int average = (N + E + S + W) / 4;
            return average;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="stepSize"></param>
        /// <returns></returns>
        private static int AverageSquare(int[,] heightMap, int x, int y, int stepSize)
        {
            int halfStep = stepSize / 2;
            int NW = cyclic(heightMap, x - halfStep, y - halfStep);
            int SE = cyclic(heightMap, x + halfStep, y + halfStep);
            int SW = cyclic(heightMap, x - halfStep, y + halfStep);
            int NE = cyclic(heightMap, x + halfStep, y - halfStep);
            int average = (NE + SE + SW + NW) / 4;
            return average;
        }

        private static int cyclic(int[,] heightMap, int x, int y)
        {
            if (y > 1024)
            {
                y -= 1024;
            }

            if (y < 0)
            {
                y += 1024;
            }

            if (x > 1024)
            {
                x -= 1024;
            }

            if (x < 0)
            {
                x += 1024;
            }

            int value = heightMap[y, x];
            return value;
        }

        private static void cyclic(int[,] heightMap, int x, int y, int v)
        {
            if (y > 1024)
            {
                y -= 1024;
            }

            if (y < 0)
            {
                y += 1024;
            }

            if (x > 1024)
            {
                x -= 1024;
            }

            if (x < 0)
            {
                x += 1024;
            }

            heightMap[y, x] = v;
        }

        private static int[,] DiamondSquare(Random r, int[,] heightMap, int stepSize, double scale, int mapWidth, int mapHeight)
        {
            int halfStep = stepSize / 2;
            int maxXTile = mapWidth;
            int maxYTile = mapHeight;

            for (int x = halfStep; x < (maxXTile + halfStep); x += stepSize)
            {
                for (int y = halfStep; y < (maxYTile + halfStep); y += stepSize)
                {
                    int square = AverageSquare(heightMap, x, y, stepSize);
                    square += Convert.ToInt32(r.Next(0, 100) * scale);
                    cyclic(heightMap, y, x, square);
                }
            }

            for (int x = 0; x < maxXTile; x += stepSize)
            {
                for (int y = 0; y < maxYTile; y += stepSize)
                {
                    int diamondOne = AverageDiamond(heightMap, x + halfStep, y, stepSize);
                    diamondOne += Convert.ToInt32(r.Next(0, 100) * scale);
                    cyclic(heightMap, x + halfStep, y, diamondOne);

                    int diamondTwo = AverageDiamond(heightMap, x, y + halfStep, stepSize);
                    diamondTwo += Convert.ToInt32(r.Next(0, 100) * scale);
                    cyclic(heightMap, x, y + halfStep, diamondTwo);
                }
            }

            return heightMap;
        }

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

            for (int k = 0; k < 8; k++)
            {
                // Must be a power of 2:
                int stepSize = 32;

                // Noise-coefficient: 
                double scale = 0.337;

                while (stepSize > 1)
                {
                    DiamondSquare(r, heightMap, stepSize, scale, mapWidth, mapHeight);
                    stepSize /= 2;
                    scale /= 4.0;
                }

                // Fill Map:
                for (int j = 0; j < mapHeight; j++)
                {
                    for (int i = 0; i < mapWidth; i++)
                    {
                        int tileAltitude = heightMap[j, i];
                        int tileType = 1; // Sea

                        if (tileAltitude >= shoreAltitude)
                            tileType = 2; // Shore.

                        if (tileAltitude >= swampAltitude)
                            tileType = 10; // Swamp.

                        if (tileAltitude >= palmtreeAltitude)
                            tileType = 11;

                        if (tileAltitude >= grassAltitude)
                            tileType = 20; // Grass.

                        if (tileAltitude >= treeAltitude)
                            tileType = 30;

                        if (tileAltitude >= mountainAltitude)
                            tileType = 40;

                        map[j, i] = tileType;
                    }
                }
            }

            return map;
        }
    }
}
