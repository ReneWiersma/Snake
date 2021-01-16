using System;
using System.Threading;

namespace SnakeConsoleApp
{
    public class Engine
    {
        readonly Grid grid = new Grid();
        readonly int speed = 1;

        int snakeLength = 5;
        bool lost;
        Movement movement = Movement.Default;

        public void Run()
        {
            grid.UpdatePos(movement.SnakeHead);
            grid.AddFood();

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

                grid.UpdatePos(movement.SnakeHead);
                grid.PrintGrid();

                Thread.Sleep(speed * 100);
            }

            Console.WriteLine("\nYou lost!");
            Console.ReadKey();
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

        void EatFood()
        {
            snakeLength += 1;
            grid.AddFood();
        }

        void MoveSnake()
        {
            var (x, y) = movement.NextPosition(grid.CurrentCell.X, grid.CurrentCell.Y);

            if (grid.IsWallAt(x, y) || grid.IsSnakeAt(x, y))
            {
                lost = true;
                return;
            }

            if (grid.IsFoodAt(x, y))
                EatFood();

            grid.MoveSnakeTo(x, y, snakeLength);
        }
    }
}