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
        /// 
        /// </summary>
        Graphics backCanvas;

        /// <summary>
        /// 
        /// </summary>
        Bitmap backImage;

        /// <summary>
        /// Front-buffer.
        /// </summary>
        Graphics frontCanvas;

        /// <summary>
        /// GameManager.
        /// </summary>
        GameManager gameManager;

        /// <summary>
        /// Seeded random generation.
        /// </summary>
        Random random;

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Instantiate back/front buffers:
            frontCanvas = CreateGraphics();
            backImage = new Bitmap(Width, Height);
            backCanvas = Graphics.FromImage(backImage);

            random = new Random(420);

            // Instantiate GameManager:
            gameManager 
                = new GameManager(random, backCanvas, Width, Height);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrGameLoop_Tick(object sender, EventArgs e)
        {
            gameManager.Draw();

            // Blit buffer(s):
            frontCanvas.DrawImage(backImage, 0, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    // North / Up:
                    gameManager.MoveViewport(EDirection.NORTH);
                    break;

                case Keys.Left:
                    // West / Left:
                    gameManager.MoveViewport(EDirection.WEST);
                    break;

                case Keys.Down:
                    // South / Down:
                    gameManager.MoveViewport(EDirection.SOUTH);
                    break;

                case Keys.Right:
                    // East / Right:
                    gameManager.MoveViewport(EDirection.EAST);
                    break;
            }
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X <= 32)
            {
                gameManager.MoveViewport(EDirection.WEST);
            }

            if (e.X >= Width - 32)
            {
                gameManager.MoveViewport(EDirection.EAST);
            }

            if (e.Y <= 32)
                gameManager.MoveViewport(EDirection.NORTH);

            if (e.Y >= Height - 32)
                gameManager.MoveViewport(EDirection.SOUTH);
        }

        private void MainForm_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                gameManager.IncrementTileSize();
            }
            else
            {
                gameManager.DecrementTileSize();
            }
        }
    }
}
