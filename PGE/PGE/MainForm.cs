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
        /// Player character (PC) Sprite.
        /// </summary>
        Sprite playerCharacter;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Instantiate back/front buffers:
            frontCanvas = CreateGraphics();

            // Instantiate PC sprite:
            playerCharacter = 
                new Sprite(
                    frontCanvas, 
                    "Resources/Spritesheets/pc.bmp"
                );
        }

        private void tmrGameLoop_Tick(object sender, EventArgs e)
        {
            // Draw PC sprite:
            playerCharacter.Draw();
        }
    }
}
