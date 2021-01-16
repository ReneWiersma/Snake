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

        public Engine()
        {
            grid.UpdatePos(movement.SnakeHead);
            grid.AddFood();
        }

        public void Run()
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

            Console.WriteLine("You lost!");
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
            var nextPosition = movement.NextPosition(grid.CurrentPosition);

            if (grid.IsWallAt(nextPosition) || grid.IsSnakeAt(nextPosition))
            {
                lost = true;
                return;
            }

            if (grid.IsFoodAt(nextPosition))
                EatFood();

            grid.MoveSnakeTo(nextPosition, snakeLength);
        }
    }
}