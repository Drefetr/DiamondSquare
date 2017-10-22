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

        private static int[,] DiamondSquare(int[,] heightMap, int stepSize, double scale)
        {


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

            // Fill map w/ random tiles:
            for (int row = 0; row < mapHeight; row++)
            {
                for (int column = 0; column < mapWidth; column++)
                {
                    map[row, column] = r.Next(10, 13);
                }
            }

            int scale = 4;
            int stepSize = 4;
            int halfStep = stepSize / 2;
            int maxXTile = mapWidth - 16;
            int maxYTile = mapHeight - 12;

            for (int x = 16 + halfStep; x < (maxXTile + halfStep); x += stepSize)
            {
                for (int y = 12 + halfStep; y < (maxYTile + halfStep); y += stepSize)
                {
                    int square = AverageSquare(heightMap, x, y, stepSize);
                    square += r.Next(-1, 2) * scale;
                    heightMap[x, y] = square;
                }
            }

            for (int x = 16; x < maxXTile; x += stepSize)
            {
                for (int y = 12; y < maxYTile; y += stepSize)
                {
                    int diamondOne = AverageDiamond(heightMap, x + halfStep, y, stepSize);
                    diamondOne += r.Next(-1, 2) * scale;
                    heightMap[x + halfStep, y] = diamondOne;

                    int diamondTwo = AverageDiamond(heightMap, x, y + halfStep, stepSize);
                    diamondTwo += r.Next(-1, 2) * scale;
                    heightMap[x, y + halfStep] = diamondTwo;
                }
            }

            return heightMap;
        }
    }
}
