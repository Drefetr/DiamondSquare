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
        /// <param name="heightMap"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="stepSize"></param>
        /// <returns></returns>
        private static int AverageDiamond(int[,] heightMap, int x, int y, int stepSize)
        {
            int halfStep = stepSize / 2;
            int N = heightMap[x, y - halfStep];
            int E = heightMap[x + halfStep, y];
            int S = heightMap[x, y + halfStep];
            int W = heightMap[x - halfStep, y];
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
            int NW = heightMap[x - halfStep, y - halfStep];
            int SE = heightMap[x + halfStep, y + halfStep];
            int SW = heightMap[x - halfStep, y + halfStep];
            int NE = heightMap[x + halfStep, y - halfStep];
            int average = (NE + SE + SW + NW) / 4;
            return average;
        }

        private static int[,] DiamondSquare(Random r, int[,] heightMap, int stepSize, double scale, int mapWidth, int mapHeight)
        {
            int halfStep = stepSize / 2;
            int maxXTile = mapWidth - 16;
            int maxYTile = mapHeight - 12;

            for (int x = 16 + halfStep; x < (maxXTile + halfStep); x += stepSize)
            {
                for (int y = 12 + halfStep; y < (maxYTile + halfStep); y += stepSize)
                {
                    int square = AverageSquare(heightMap, x, y, stepSize);
                    square += Convert.ToInt32(r.Next(0, 100) * scale);
                    heightMap[x, y] = square;
                }
            }

            for (int x = 16; x < maxXTile; x += stepSize)
            {
                for (int y = 12; y < maxYTile; y += stepSize)
                {
                    int diamondOne = AverageDiamond(heightMap, x + halfStep, y, stepSize);
                    diamondOne += Convert.ToInt32(r.Next(0, 100) * scale);
                    heightMap[x + halfStep, y] = diamondOne;

                    int diamondTwo = AverageDiamond(heightMap, x, y + halfStep, stepSize);
                    diamondTwo += Convert.ToInt32(r.Next(0, 100) * scale);
                    heightMap[x, y + halfStep] = diamondTwo;
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

            for (int k = 0; k < 1; k++)
            {
                // Must be a power of 2:
                int stepSize = 16;

                // Noise-coefficient: 
                double scale = 0.42;

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
                        int tileType = 0;

                        if (tileAltitude >= 10)
                            tileType = 1; // Sea.

                        if (tileAltitude >= 15)
                            tileType = 2; // Shore.

                        if (tileAltitude >= 20)
                            tileType = 10; // Swamp.

                        if (tileAltitude >= 25)
                            tileType = 20; // Grass.

                        if (tileAltitude >= 30)
                            tileType = 30;

                        if (tileAltitude >= 40)
                            tileType = 40;

                        map[j, i] = tileType;
                    }
                }
            }

            return map;
        }
    }
}
