using System;

namespace SnakeConsoleApp
{
    public class Grid
    {
        const int width = 90;
        const int height = 25;

        readonly Cell[,] grid = new Cell[width, height];
        readonly Random random = new();

        public Grid()
        {
            InitGrid();
        }

        public Position RandomPosition =>
            new Position(random.Next(width - 2) + 1, random.Next(height - 2) + 1);

        public Position Center => new Position(width / 2, height / 2);

        private void InitGrid()
        {
            for (int col = 0; col < height; col++)
            {
                for (int row = 0; row < width; row++)
                {
                    var cell = new Cell();

                    if (IsEdge(col, row))
                        cell.Symbol = "*";
                    else
                        cell.Symbol = " ";

                    grid[row, col] = cell;
                }
            }
        }

        private static bool IsEdge(int col, int row) => 
            row is 0 or width - 1 || col is 0 or height - 1;


        public void Draw()
        {
            Console.SetCursorPosition(0, 0);

            var toPrint = "";

            for (int col = 0; col < height; col++)
            {
                for (int row = 0; row < width; row++)
                {
                    toPrint += grid[row, col].Symbol;
                }

                toPrint += "\n";
            }

            Console.WriteLine(toPrint);
        }

        public bool IsWallAt(Position pos) => grid[pos.X, pos.Y].Symbol == "*";
    }
}
