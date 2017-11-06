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
        /// Calculate value of diamond centroid formed by `x`, `y` and 
        /// `stepSize`.
        /// </summary>
        /// <param name="heightMap">Height map to work upon.</param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="stepSize"></param>
        /// <returns></returns>
        private static int AverageDiamond(int[,] heightMap, int x, int y, int stepSize)
        {
            int halfStep = stepSize / 2;
            int N = fetch(heightMap, x, y - halfStep);
            int E = fetch(heightMap, x + halfStep, y);
            int S = fetch(heightMap, x, y + halfStep);
            int W = fetch(heightMap, x - halfStep, y);
            int average = (N + E + S + W) / 4;
            return average;
        }

        /// <summary>
        /// Calculate value of square centroid formed by `x`, `y` and `stepSize`.
        /// </summary>
        /// <param name="x">Left-edge position on x-axis.</param>
        /// <param name="y">Top-edge position on y-axis.</param>
        /// <param name="stepSize">Step size (Tiles).</param>
        /// <returns></returns>
        private static int AverageSquare(int[,] heightMap, int x, int y, int stepSize)
        {
            int halfStep = stepSize / 2;
            int NW = fetch(heightMap, x - halfStep, y - halfStep);
            int SE = fetch(heightMap, x + halfStep, y + halfStep);
            int SW = fetch(heightMap, x - halfStep, y + halfStep);
            int NE = fetch(heightMap, x + halfStep, y - halfStep);
            int average = (NE + SE + SW + NW) / 4;
            return average;
        }

        /// <summary>
        /// Fetch value of `heightMap` cell at position defined by (`x`, `y`).
        /// </summary>
        /// <param name="heightMap">Height map to work upon.</param>
        /// <param name="x">Position on x-axis.</param>
        /// <param name="y">Position on y-axis.</param>
        /// <returns></returns>
        private static int fetch(int[,] heightMap, int x, int y)
        {
            if (y >= Conf.MapSize)
            {
                y -= Conf.MapSize;
            }

            if (y < 0)
            {
                y += Conf.MapSize;
            }

            if (x >= Conf.MapSize)
            {
                x -= Conf.MapSize;
            }

            if (x < 0)
            {
                x += Conf.MapSize;
            }

            int value = heightMap[y, x];
            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="heightMap"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="v"></param>
        private static void fetch(int[,] heightMap, int x, int y, int v)
        {
            if (y >= Conf.MapSize)
            {
                y -= Conf.MapSize;
            }

            if (y < 0)
            {
                y += Conf.MapSize;
            }

            if (x >= Conf.MapSize)
            {
                x -= Conf.MapSize;
            }

            if (x < 0)
            {
                x += Conf.MapSize;
            }

            heightMap[y, x] = v;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <param name="heightMap"></param>
        /// <param name="stepSize"></param>
        /// <param name="scale"></param>
        /// <param name="mapWidth"></param>
        /// <param name="mapHeight"></param>
        /// <returns></returns>
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
                    square += Convert.ToInt32(r.Next(0, 2) * scale);
                    fetch(heightMap, x, y, square);
                }
            }

            for (int x = 0; x < maxXTile; x += stepSize)
            {
                for (int y = 0; y < maxYTile; y += stepSize)
                {
                    int diamondOne = AverageDiamond(heightMap, x + halfStep, y, stepSize);
                    diamondOne += Convert.ToInt32(r.Next(0, 2) * scale);
                    fetch(heightMap, x + halfStep, y, diamondOne);

                    int diamondTwo = AverageDiamond(heightMap, x, y + halfStep, stepSize);
                    diamondTwo += Convert.ToInt32(r.Next(0, 2) * scale);
                    fetch(heightMap, x, y + halfStep, diamondTwo);
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
        public static int[,] NextMap(Random r, int mapSize)
        {
            int mapWidth = mapSize;
            int mapHeight = mapSize;
            int[,] heightMap = new int[mapHeight, mapWidth];
            int[,] map = new int[mapHeight, mapWidth];

            for (int row = 0; row < mapHeight; row++)
            {
                for (int column = 0; column < mapWidth; column++)
                {
                    heightMap[row, column] 
                        = r.Next(Conf.AltitudeMin, Conf.AltitudeMax + 1);
                }
            }

                // Must be a power of 2:
                int stepSize = Conf.StepSize;

                // Noise-coefficient: 
                double scale = 1.777;

                while (stepSize > 1)
                {
                    DiamondSquare(r, heightMap, stepSize, scale, mapWidth, mapHeight);
                    stepSize /= 2;
                    scale /= 4.0;
                }

                DiamondSquare(r, heightMap, 1, scale, mapWidth, mapHeight);


            // Min/max:
            double min = Conf.AltitudeMin;
            double max = Conf.AltitudeMax;

            for (int row = 0; row < mapHeight; row++)
            {
                for (int column = 0; column < mapWidth; column++)
                {
                    int tileAltitude = heightMap[row, column];

                    if (tileAltitude > max)
                        max = tileAltitude;

                    if (tileAltitude < min)
                        min = tileAltitude;
                }
            }

            // Fill Map:
            for (int row = 0; row < mapHeight; row++)
            {
                for (int column = 0; column < mapWidth; column++)
                {
                    int tileAltitude = heightMap[row, column];
                    double altNormal = (tileAltitude - min) / (max - min);
                    altNormal *= Conf.AltitudeMax;
                    map[row, column] = tileAltitude;
                }
            }

            return map;
        }
    }
}
