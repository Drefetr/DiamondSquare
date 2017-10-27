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
        private static readonly int _mapSize;

        /// <summary>
        /// 
        /// </summary>
        private static readonly int _tileSize;

        /// <summary>
        /// 
        /// </summary>
        private static readonly int _stepSize;

        /// <summary>
        /// 
        /// </summary>
        private static readonly int _velocity;

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
        /// 
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

        public static int Velocity
        {
            get
            {
                return _velocity;
            }
        }

        static Conf()
        {
            _mapSize = 4097;
            _stepSize = 64;
            _tileSize = 1;
            _velocity = 8;
        }
    }
}
