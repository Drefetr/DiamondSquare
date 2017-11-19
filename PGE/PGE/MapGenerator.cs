using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGE
{
    /// <summary>
    /// Encapsulates map generation via the DiamondSquare algorithm.
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
        public static CyclicArray<int> NextMap(Random r, int mapSize)
        {
            int mapWidth = mapSize;
            int mapHeight = mapSize;
            //int[,] heightMap = new int[mapHeight, mapWidth];
            CyclicArray<int> heightMap = new CyclicArray<int>();
            CyclicArray<int> map = new CyclicArray<int>();

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
                DiamondSquare.Generate(r, heightMap, stepSize, scale, mapWidth, mapHeight);
                stepSize /= 2;
                scale /= 4.0;
            }

            DiamondSquare.Generate(r, heightMap, 1, scale, mapWidth, mapHeight);

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
