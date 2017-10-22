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

            random = new Random(420);

            // Instantiate GameManager:
            gameManager 
                = new GameManager(random, frontCanvas, Width, Height);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrGameLoop_Tick(object sender, EventArgs e)
        {
            gameManager.Update();
            gameManager.Draw();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            gameManager.MoveViewport();
        }
    }
}
