using System;

namespace SnakeConsoleApp
{
    public class Grid
    {
        const int width = 90;
        const int height = 25;
        readonly Cell[,] grid = new Cell[width, height];

        public Grid()
        {
            InitGrid();

            CurrentCell = grid[width / 2, height / 2];
        }

        public Cell CurrentCell { get; private set; }

        private void InitGrid()
        {
            for (int col = 0; col < height; col++)
            {
                for (int row = 0; row < width; row++)
                {
                    var cell = new Cell
                    {
                        X = row,
                        Y = col,
                        IsSnakeTail = false
                    };

                    if (cell.X == 0 || cell.X > width - 2 || cell.Y == 0 || cell.Y > height - 2)
                        cell.Set("*");
                    else
                        cell.Clear();

                    grid[row, col] = cell;
                }
            }
        }

        public void UpdatePos(string symbol)
        {
            CurrentCell.Val = symbol;
            CurrentCell.IsSnakeTail = false;
        }

        public void PrintGrid()
        {
            Console.SetCursorPosition(0, 0);

            var toPrint = "";

            for (int col = 0; col < height; col++)
            {
                for (int row = 0; row < width; row++)
                {
                    grid[row, col].DecaySnake();
                    toPrint += grid[row, col].Val;
                }

                toPrint += "\n";
            }

            Console.WriteLine(toPrint);
        }

        public void AddFood()
        {
            var random = new Random();

            var cell = grid[random.Next(grid.GetLength(0) - 2) + 1, random.Next(grid.GetLength(1) - 2) + 1];

            cell.Val = "%";
        }

        public bool IsWallAt(int x, int y) => grid[x, y].Val == "*";

        public bool IsSnakeAt(int x, int y) => grid[x, y].IsSnakeTail;

        public bool IsFoodAt(int x, int y) => grid[x, y].Val == "%";

        public void MoveSnakeTo(int x, int y, int snakeLength)
        {
            CurrentCell.Val = "#";
            CurrentCell.IsSnakeTail = true;
            CurrentCell.Decay = snakeLength;

            CurrentCell = grid[x, y];
        }
    }
}
