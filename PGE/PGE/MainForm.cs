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
        /// Graphics context to draw to.
        /// </summary>
        Graphics canvas;

        /// <summary>
        /// GameManager.
        /// </summary>
        GameManager gameManager;

        /// <summary>
        /// Seeded random generator.
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

            // Instantiate seeded generator:
            random = new Random(420);

            // Instantiate GameManager:
            gameManager 
                = new GameManager(random, canvas);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            // Draw map --
            gameManager.DrawMap();
        }
    }
}
