using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PGE
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Front-buffer.
        /// </summary>
        Graphics frontCanvas;

        /// <summary>
        /// Terrain TileMap.
        /// </summary>
        TileMap terrainMap;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Instantiate back/front buffers:
            frontCanvas = CreateGraphics();

            // Instantiate terrain TileSet:
            TileSet terrainTileSet = new TileSet("Resources/Tiles");

            // Instantiate terrain TileMap:
            terrainMap = new TileMap(terrainTileSet, 128, 128);
        }

        private void tmrGameLoop_Tick(object sender, EventArgs e)
        {
            terrainMap.Draw(frontCanvas);
        }
    }
}
