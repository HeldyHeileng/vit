using System;
using System.Collections.Generic;
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
            Application.Run(new Form1());
        }
    }

    public enum CellType {
        Empty,
        Player,
        Enemy
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
}
