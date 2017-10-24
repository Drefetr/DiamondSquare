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

    class Conf
    {
        private static readonly int _tileHeight;

        private static readonly int _tileWidth;

        public static int TileHeight
        {
            get
            {
                return _tileHeight;
            }
        }

        public static int TileWidth
        {
            get 
            {
                return _tileWidth;
            }
        }

        static Conf()
        {
            _tileHeight = 16;
            _tileWidth = 16;
        }
    }
}
