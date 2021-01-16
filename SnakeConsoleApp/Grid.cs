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

            CurrentPosition = new Position(width / 2, height / 2);
        }

        public Position CurrentPosition { get; private set; }

        private void InitGrid()
        {
            for (int col = 0; col < height; col++)
            {
                for (int row = 0; row < width; row++)
                {
                    var cell = new Cell();

                    if (row == 0 || row > width - 2 || col == 0 || col > height - 2)
                        cell.Set("*");
                    else
                        cell.Clear();

                    grid[row, col] = cell;
                }
            }
        }

        public void SetSnakeHead(string symbol)
        {
            grid[CurrentPosition.X, CurrentPosition.Y].Val = symbol;
            grid[CurrentPosition.X, CurrentPosition.Y].IsSnakeTail = false;
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

        public bool IsWallAt(Position pos) => grid[pos.X, pos.Y].Val == "*";

        public bool IsSnakeAt(Position pos) => grid[pos.X, pos.Y].IsSnakeTail;

        public bool IsFoodAt(Position pos) => grid[pos.X, pos.Y].Val == "%";

        public void MoveSnakeTo(Position position, int snakeLength)
        {
            grid[CurrentPosition.X, CurrentPosition.Y].Val = "#";
            grid[CurrentPosition.X, CurrentPosition.Y].IsSnakeTail = true;
            grid[CurrentPosition.X, CurrentPosition.Y].Decay = snakeLength;

            CurrentPosition = position;
        }
    }
}
