using System;
using System.Threading;

namespace SnakeConsoleApp
{
    public class Engine
    {
        const int speed = 1;
        
        readonly Grid grid = new Grid();
        
        bool lost;

        Movement movement = Movement.Create();
        Snake snake = Snake.Create();

        public Engine()
        {
            grid.AddFood();
        }

        public void Run()
        {
            while (!lost)
            {
                if (Console.KeyAvailable)
                {
                    var input = Console.ReadKey();
                    movement = ProcessInput(input.KeyChar);
                }

                MoveSnake();

                grid.SetSnakeHead(movement.SnakeHead);
                grid.PrintGrid();

                Thread.Sleep(speed * 100);
            }

            Console.WriteLine("You lost!");
            Console.ReadKey();
        }

        Movement ProcessInput(char input) => input switch
        {
            's' => movement.Down(),
            'a' => movement.Left(),
            'd' => movement.Right(),
            'w' => movement.Up(),
            _ => movement,
        };

        void MoveSnake()
        {
            var nextPosition = movement.NextPosition(grid.CurrentPosition);

            if (grid.IsWallAt(nextPosition) || grid.IsSnakeAt(nextPosition))
            {
                lost = true;
                return;
            }

            if (grid.IsFoodAt(nextPosition))
            {
                snake = snake.Grow();
                grid.AddFood();
            }

            grid.MoveSnakeTo(snake, nextPosition);
        }
    }
}