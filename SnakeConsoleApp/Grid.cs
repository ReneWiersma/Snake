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

            CurrentPosition = new Position(width / 2, height / 2);
        }

        public Position CurrentPosition { get; private set; }

        public Position RandomPosition =>
            new Position(random.Next(width - 2) + 1, random.Next(height - 2) + 1);

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

        public void SnakeHead(string symbol)
        {
            grid[CurrentPosition.X, CurrentPosition.Y].Symbol = symbol;
        }

        public void Draw()
        {
            Console.SetCursorPosition(0, 0);

            var toPrint = "";

            for (int col = 0; col < height; col++)
            {
                for (int row = 0; row < width; row++)
                {
                    grid[row, col].DecaySnake();
                    toPrint += grid[row, col].Symbol;
                }

                toPrint += "\n";
            }

            Console.WriteLine(toPrint);
        }

        public bool IsWallAt(Position pos) => grid[pos.X, pos.Y].Symbol == "*";

        public bool IsSnakeAt(Position pos) => grid[pos.X, pos.Y].IsSnake;

        public bool IsFoodAt(Position pos) => grid[pos.X, pos.Y].Symbol == "%";

        public void MoveSnakeTo(Snake snake, Position position)
        {
            grid[CurrentPosition.X, CurrentPosition.Y].Symbol = "#";
            grid[CurrentPosition.X, CurrentPosition.Y].IsSnake = true;
            grid[CurrentPosition.X, CurrentPosition.Y].Decay = snake.Length;

            CurrentPosition = position;
        }
    }
}
