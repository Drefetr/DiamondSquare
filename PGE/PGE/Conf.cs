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
        private static readonly int _tileSize;

        /// <summary>
        /// 
        /// </summary>
        private static readonly int _mapSize;

        /// <summary>
        /// 
        /// </summary>
        private static readonly int _velocity;

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
        /// Accessor to `_mapSize`.
        /// </summary>
        public static int MapSize
        {
            get
            {
                return _mapSize;
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
            _tileSize = 1;
            _velocity = 8;
        }
    }
}
