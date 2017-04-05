using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
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

    public enum CellType
    {
        Empty,
        Player,
        Enemy
    }

    public class CellTypeProps
    {
        public Pen pen { get; set; }
    }

    public class Cell
    {
        public int row { get; set; }
        public int col { get; set; }
        public int weight { get; set; }
        public CellType type { get; set; }

        public Cell(int col, int row, int weight)
        {
            this.row = row;
            this.col = col;
            this.weight = weight;
            this.type = CellType.Empty;
        }

        public Cell(int col, int row, int weight, CellType type) : this(col, row, weight)
        {
            this.type = type;
        }
    }

    public static class GridSettings {
        public static int height { get; set; }
        public static int width { get; set; }
        public static int enemyCount { get; set; }
        public static int cellSize { get; set; }
    }

    public class Grid
    {
        public int height { get; set; }
        public int width { get; set; }
        public int enemyCount { get; set; }
        public int cellSize { get; set; }
        public Graphics graph { get; set; }
        Dictionary<CellType, Brush> cellTypePens { get; set; }
        public CellCollection cc { get; set; }

        Pen pen = Pens.BurlyWood;
        StringFormat sf = new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center };
        public Grid(Graphics graph)
        {
            this.height = GridSettings.height;
            this.width = GridSettings.width;
            this.enemyCount = GridSettings.enemyCount;
            this.cellSize = GridSettings.cellSize;
            this.graph = graph;
            cc = new CellCollection();
            cellTypePens = new Dictionary<CellType, Brush>();
            cellTypePens.Add(CellType.Enemy, Brushes.PaleVioletRed);
            cellTypePens.Add(CellType.Player, Brushes.LawnGreen);
        }
        
        public Rectangle getRectangle(int col, int row)
        {
            return new Rectangle(col * cellSize, row * cellSize, cellSize, cellSize);
        }
        public Rectangle getSmallRectangle(int col, int row)
        {
            return new Rectangle(col * cellSize + cellSize/ 2, row * cellSize + cellSize / 2, cellSize - cellSize/2, cellSize - cellSize / 2);
        }
        public Rectangle getMiddleRectangle(int col, int row)
        {
            return new Rectangle(col * cellSize + cellSize / 2 - cellSize / 40, row * cellSize + cellSize / 2 - cellSize / 40, cellSize - cellSize / 2 + cellSize/ 20, cellSize - cellSize / 2 + cellSize / 20);
        }

        public void DrawCells()
        {
            graph.Clear(Color.SteelBlue);
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
            foreach (Cell cell in cc.cells)
            {
                var rect = getRectangle(cell.col, cell.row);
                var middleRect = getMiddleRectangle(cell.col, cell.row);
                var smallRect = getSmallRectangle(cell.col, cell.row);
                //graph.FillEllipse(cellTypePens[cell.type], rect);
                var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                if (cell.type == CellType.Player)
                {
                    graph.DrawImage(Image.FromFile(path + @"\img\knight.png"), rect);
                }
                if (cell.type == CellType.Enemy && cell.weight < 7)
                {
                    graph.DrawImage(Image.FromFile(path + @"\img\smallDragon.png"), rect);
                }
                if (cell.type == CellType.Enemy && cell.weight >= 7)
                {
                    graph.DrawImage(Image.FromFile(path + @"\img\bigDragon.png"), rect);
                }
                //graph.FillEllipse(cellTypePens[cell.type], smallRect);
                graph.DrawString(cell.weight.ToString(), new Font(FontFamily.GenericSansSerif, cellSize / 4, FontStyle.Bold), Brushes.White, middleRect, sf);
                graph.DrawString(cell.weight.ToString(), new Font(FontFamily.GenericSansSerif, cellSize/4), Brushes.Black, smallRect, sf);
            }
        }

    }

    public class CellCollection
    {

        public List<Cell> cells { get; set; }
        
        Random rnd = new Random();
        public CellCollection()
        {
            cells = new List<Cell>();
        }

        public bool addCell(int col, int row, int weight, CellType type)
        {
            if (cells.Any(x => x.col == col && x.row == row))
            {
                return false;
            }
            else
            {
                   cells.Add(new Cell(col, row, weight, type));
                return true;
            }
        }

        public bool generateEnemy(int height, int width)
        {
            int weight = 0, col = 0, row = 0;
            if (cells.Count() == height * width)
            {
                return false;
            }

            double maxWeight = cells.First(x => x.type == CellType.Player).weight + 2;
                weight = rnd.Next((int)maxWeight);            
            var cellAdded = false;
            while (!cellAdded) {
                col = rnd.Next(width);
                row = rnd.Next(height);
                cellAdded = addCell(col, row, weight, CellType.Enemy);                
            }
            Debug.WriteLine("generate enemy " + col + ' ' + row);
            return true;
        }

        public bool movePlayer(int col, int row) {

            var player = cells.First(x => x.type == CellType.Player);

            if (col != player.col && row != player.row) {
                return false; // ходим не по прямой
            }

            if (col == player.col && row == player.row) {
                return false; //никуда не пошли
            }

            int delta = Math.Abs(col - player.col) + Math.Abs(row - player.row); //на сколько клеток движемся
            
            if (!cells.Any(x => x.col == col && x.row == row)) //на клетке никого нет 
            {
                if (delta == 1) //ходим на соседнюю
                {
                    player.col = col;
                    player.row = row;
                    return true;
                }
                else return false; // не можем ходить на пустую клетку если она не соседняя
            }

            //на клетке кто-то есть
            var cellEnemy = cells.First(x => x.col == col && x.row == row);

            if (cellEnemy.weight > player.weight)
            { // не можем дойти
                return false;
            }

            if (delta > 1) // нужно проверить есть ли кто-то между игроком и целевой клеткой 
            {
                var enemies = cells.Where(x => x.col >= Math.Min(col, player.col)
                                            && x.col <= Math.Max(col, player.col)
                                            && x.row >= Math.Min(row, player.row)
                                            && x.row <= Math.Max(row, player.row)
                                            && x.type == CellType.Enemy
                                            && !(x.col == col && x.row == row)).ToList();

                if (enemies.Any(x => x.weight >= player.weight)) { //не можем дойти
                    return false; 
                }

                // все ок, удаляем попутчиков
                foreach (var enemy in enemies) {
                    cells.Remove(enemy);
                }
            }

            if (cellEnemy.weight == player.weight)
            { //если нужно, увеличиваем силу игрока
                player.weight++;
            }

            cells.Remove(cellEnemy); //убиваем противника

            player.col = col; //перемещаемся
            player.row = row;

            return true;
        }
    }
}
