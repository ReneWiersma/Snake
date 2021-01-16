using System;
using System.Threading;

namespace SnakeConsoleApp
{
    public class Engine
    {
        const int gridW = 90;
        const int gridH = 25;
        readonly Cell[,] grid = new Cell[gridW, gridH];
        readonly int speed = 1;

        Cell currentCell;
        int snakeLength = 5;
        bool lost;
        Movement movement = Movement.Default;

        public void Run()
        {
            PopulateGrid();

            currentCell = grid[gridW / 2, gridH / 2];

            UpdatePos();
            AddFood();

            PlayGame();
        }

        void PlayGame()
        {
            while (!lost)
            {
                if (Console.KeyAvailable)
                {
                    var input = Console.ReadKey();
                    ProcessInput(input.KeyChar);
                }

                MoveSnake();
                UpdatePos();
                PrintGrid();

                Thread.Sleep(speed * 100);
            }

            Console.WriteLine("\nYou lost!");
            Console.ReadKey();
        }

        void Lose()
        {
            lost = true;
        }

        void ProcessInput(char inp)
        {
            switch (inp)
            {
                case 'w':
                    movement = movement.Up();
                    break;
                case 's':
                    movement = movement.Down();
                    break;
                case 'a':
                    movement = movement.Left();
                    break;
                case 'd':
                    movement = movement.Right();
                    break;
            }
        }

        void AddFood()
        {
            var random = new Random();

            var cell = grid[random.Next(grid.GetLength(0) - 2) + 1, random.Next(grid.GetLength(1) - 2) + 1];

            cell.Val = "%";
        }

        void EatFood()
        {
            snakeLength += 1;
            AddFood();
        }

        void MoveSnake()
        {
            var (x, y) = movement.NextPosition(currentCell.X, currentCell.Y);
            var nextCell = grid[x, y];

            if (nextCell.Val == "*" || nextCell.Visited)
            {
                Lose();
                return;
            }

            if (nextCell.Val == "%")
                EatFood();

            currentCell.Val = "#";
            currentCell.Visited = true;
            currentCell.Decay = snakeLength;

            currentCell = nextCell;
        }

        void UpdatePos()
        {
            currentCell.Val = movement.SnakeHead;
            currentCell.Visited = false;
        }

        void PopulateGrid()
        {
            for (int col = 0; col < gridH; col++)
            {
                for (int row = 0; row < gridW; row++)
                {
                    var cell = new Cell
                    {
                        X = row,
                        Y = col,
                        Visited = false
                    };

                    if (cell.X == 0 || cell.X > gridW - 2 || cell.Y == 0 || cell.Y > gridH - 2)
                        cell.Set("*");
                    else
                        cell.Clear();

                    grid[row, col] = cell;
                }
            }
        }

        void PrintGrid()
        {
            Console.SetCursorPosition(0, 0);

            var toPrint = "";

            for (int col = 0; col < gridH; col++)
            {
                for (int row = 0; row < gridW; row++)
                {
                    grid[row, col].DecaySnake();
                    toPrint += grid[row, col].Val;
                }

                toPrint += "\n";
            }

            Console.WriteLine(toPrint);
        }
    }
}