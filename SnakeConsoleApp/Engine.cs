using System;
using System.Threading;

namespace SnakeConsoleApp
{
    public class Engine
    {
        const int speed = 1;

        readonly Grid grid = new Grid();
        
        Movement movement = Movement.Create();
        Snake snake = Snake.Create();
        Food food;

        bool lost;

        public Engine()
        {
            food = new Food(grid.RandomPosition);
        }

        public void Run()
        {
            Console.CursorVisible = false;

            while (!lost)
            {
                if (Console.KeyAvailable)
                {
                    var input = Console.ReadKey();
                    movement = ProcessInput(input.KeyChar);
                }

                MoveSnake();

                grid.SnakeHead(movement.SnakeHead);
                grid.Draw();
                food.Draw();

                Console.SetCursorPosition(0, 25);

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

            if (food.IsAt(nextPosition))
            {
                snake = snake.Grow();
                food = new Food(grid.RandomPosition);
            }

            grid.MoveSnakeTo(snake, nextPosition);
        }
    }
}