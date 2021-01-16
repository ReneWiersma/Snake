using System;
using System.Threading;

namespace SnakeConsoleApp
{
    public class Engine
    {
        const int speed = 1;

        readonly Grid grid = new Grid();
        
        Movement movement = Movement.Create();
        Snake snake = new Snake(new Position(45, 12), 5);
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

                CheckCollisions();

                grid.Draw();
                snake.Draw(movement.SnakeHead);
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

        void CheckCollisions()
        {
            var nextPosition = movement.NextPosition(snake.CurrentPosition);

            if (grid.IsWallAt(nextPosition) || snake.IsAt(nextPosition))
            {
                lost = true;
                return;
            }

            if (food.IsAt(nextPosition))
            {
                snake = snake.Grow(nextPosition);
                food = new Food(grid.RandomPosition);
            }

            snake.MoveTo(nextPosition);

            //grid.MoveSnakeTo(snake, nextPosition);
        }
    }
}