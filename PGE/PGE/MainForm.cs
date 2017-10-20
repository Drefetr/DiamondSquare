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

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Instantiate back/front buffers:
            frontCanvas = CreateGraphics();

            // Instantiate GameManager:
            gameManager = new GameManager(frontCanvas, Width, Height);
        }

        private void tmrGameLoop_Tick(object sender, EventArgs e)
        {
            gameManager.Update();
            gameManager.Draw();
        }
    }
}
