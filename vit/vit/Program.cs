using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace vit
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }

    public enum CellType {
        Empty,
        Player,
        Enemy
    }

    public class CellTypeProps {
        public Pen pen { get; set; }    
    }

    public class Cell
    {
        public int row { get; set; }
        public int col { get; set; }
        public int weight { get; set; }
        public CellType type { get; set; }

        public Cell(int row, int col, int weight) {
            this.row = row;
            this.col = col;
            this.weight = weight;
            this.type = CellType.Empty;
        }

        public Cell(int row, int col, int weight, CellType type) : this(row, col, weight){
            this.type = type;
        }
    }

    static class Stats {
        public static int EnemySumWeight { get; set; }
        public static int EnemyCount { get; set; }

        static Stats() {
            EnemySumWeight = 1;
            EnemyCount = 1;
        }
    }

    public class Grid
    {
        public int height { get; set; }
        public int width { get; set; }
        public int cellSize { get; set; }
        public Graphics graph { get; set; }
        public List<Cell> cells { get; set; }
        Dictionary<CellType, Brush> cellTypePens { get; set; }

        Pen pen = Pens.BurlyWood;
        StringFormat sf = new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center };
        public Grid(int height, int width, int cellSize, Graphics graph) {
            this.height = height;
            this.width = width;
            this.cellSize = cellSize;
            this.graph = graph;
            cells = new List<Cell>();
            cellTypePens = new Dictionary<CellType, Brush>();
            cellTypePens.Add(CellType.Enemy, Brushes.PaleVioletRed);
            cellTypePens.Add(CellType.Player, Brushes.LawnGreen);
        }

        public void Draw()
        {
            // горизонтальные линии
            for (int i = 1; i < height; i++)
            {
                graph.DrawLine(pen, 0, i * cellSize, width * cellSize, i * cellSize);
            }

            // вертикальные линии
            for (int i = 1; i < height; i++)
            {
                graph.DrawLine(pen, i * cellSize, 0, i * cellSize, height * cellSize);
            }
        }
        public Rectangle getRectangle(int col, int row) {
            return new Rectangle(col * cellSize, row * cellSize, cellSize, cellSize);
        }

        public void DrawCells() {
            foreach (Cell cell in cells) {
                var rect = getRectangle(cell.col, cell.row);
                graph.FillEllipse(cellTypePens[cell.type], rect);
                graph.DrawString(cell.weight.ToString(), new Font(FontFamily.GenericSansSerif, 20), Brushes.Black, rect, sf);                
            }
        }
    }
}
