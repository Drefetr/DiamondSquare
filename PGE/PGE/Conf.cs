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
    enum EDirection
    {
        NORTH,
        WEST,
        SOUTH,
        EAST
    }

    /// <summary>
    /// 
    /// </summary>
    class Conf
    {
        /// <summary>
        /// 
        /// </summary>
        private static readonly int _altitudeMin;

        /// <summary>
        /// 
        /// </summary>
        private static readonly int _altitudeMax;

        /// <summary>
        /// 
        /// </summary>
        private static readonly int _dimensions;

        /// <summary>
        /// Map size (tiles) -- {(n^2)+1}.
        /// </summary>
        private static readonly int _mapSize;

        /// <summary>
        /// Initial tile size (pixels).
        /// </summary>
        private static readonly int _tileSize;

        /// <summary>
        /// Maximum tile size (pixels).
        /// </summary>
        private static readonly int _tileSizeMax;

        /// <summary>
        /// Minimum tile size (pixels).
        /// </summary>
        private static readonly int _tileSizeMin;

        /// <summary>
        /// 
        /// </summary>
        private static readonly int _stepSize;

        /// <summary>
        /// 
        /// </summary>
        private static readonly int _velocity;

        public static int AltitudeMax
        {
            get
            {
                return _altitudeMax;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static int AltitudeMin
        {
            get
            {
                return _altitudeMin;
            }
        }

        public static int Dimensions
        {
            get
            {
                return _dimensions;
            }
        }

        /// <summary>
        /// Accessor to `_mapSize`.
        /// </summary>
        public static int MapSize
        {
            get
            {
                return _mapSize;
            }
        }

        /// <summary>
        /// Accessor to `_stepSize`.
        /// </summary>
        public static int StepSize
        {
            get
            {
                return _stepSize;
            }
        }

        /// <summary>
        /// Accessor to `_tileSize`.
        /// </summary>
        public static int TileSize
        {
            get
            {
                return _tileSize;
            }
        }

        /// <summary>
        /// Accessor to `_tileSizeMax`.
        /// </summary>
        public static int TileSizeMax
        {
            get
            {
                return _tileSizeMax;
            }
        }

        /// <summary>
        /// Accessor to `_tileSizeMin`.
        /// </summary>
        public static int TileSizeMin
        {
            get
            {
                return _tileSizeMin;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static int Velocity
        {
            get
            {
                return _velocity;
            }
        }

        static Conf()
        {
            _altitudeMin = 16;
            _altitudeMax = 224;
            _dimensions = 2;
            _mapSize = 1025;
            _stepSize = 16;
            _tileSize = 1;
            _tileSizeMin = 1;
            _tileSizeMax = 32;
            _velocity = 8;
        }
    }
}
