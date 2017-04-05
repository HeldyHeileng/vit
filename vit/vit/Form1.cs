using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace vit
{
    public partial class MainForm : Form
    {
        Grid grid;
        bool gameIsOn = false;
        public MainForm()
        {
            GridSettings.width = 6;
            GridSettings.height = 6;
            GridSettings.enemyCount = 2;
            GridSettings.cellSize = 100;
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowOnly;
            InitializeComponent();
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            GridPanel.Size = new Size(GridSettings.width * GridSettings.cellSize, GridSettings.height * GridSettings.cellSize);
            this.Size = new Size(GridSettings.width * GridSettings.cellSize + 120, GridSettings.height * GridSettings.cellSize + 80);
            grid = new Grid(GridPanel.CreateGraphics());            
            grid.cc.addCell(0, 0, 0, CellType.Player);
            grid.cc.addCell(2, 2, 1, CellType.Enemy);
            grid.DrawCells();
            gameIsOn = true;
        }


        private void GridPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (!gameIsOn) return; //если не играем, то не реагируем
            int col = (int)Math.Floor(e.X * 1.0 / grid.cellSize);
            int row = (int)Math.Floor(e.Y * 1.0 / grid.cellSize);

            if (grid.cc.movePlayer(col, row))
            {
                for (int i = 0; i < grid.enemyCount; i++)
                {
                    grid.cc.generateEnemy(grid.height, grid.width);
                }
            }

            grid.DrawCells();
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Settings = new Settings();
            Settings.Show();
        }
    }
}
