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
        Graphics canvas;

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
            canvas = CreateGraphics();

            random = new Random(420);

            // Instantiate GameManager:
            gameManager 
                = new GameManager(random, canvas, 2048, 2048);

            gameManager.DrawMap();
        }
    }
}
