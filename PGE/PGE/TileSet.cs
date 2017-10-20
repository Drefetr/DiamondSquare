using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGE
{
    class TileSet
    {
        /// <summary>
        /// 
        /// </summary>
        Dictionary<string, Tile> tiles;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="path">TileSet folder path.</param>
        public TileSet(string tilesetPath)
        {
            // Load all tiles in `tilesetPath`:
            string[] files = Directory.GetFiles(tilesetPath);
            tiles = new Dictionary<string, Tile>();

            // Iterate over each file in `tilesetPath` --
            foreach(string file in files)
            {
                Tile tile = new Tile(file);
                String key = Path.GetFileNameWithoutExtension(file);
                tiles.Add(key, tile);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Bitmap GetTileBitmap(string index)
        {
            Tile tile = tiles[index];
            Bitmap tileBitmap = tile.GetBitmap();
            return tileBitmap;
        }
    }
}
