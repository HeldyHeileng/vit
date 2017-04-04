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

        public MainForm()
        {
            InitializeComponent();
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            grid = new Grid(10, 8, 50, GridPanel.CreateGraphics());
            grid.Draw();
            grid.cells.Add(new Cell(1, 1, 3, CellType.Player));
            grid.cells.Add(new Cell(2, 5, 5, CellType.Enemy));
            grid.DrawCells();
        }
    }
}
