using System;
using System.Threading;

namespace SnakeConsoleApp
{
    public class Engine
    {
        const int speed = 1;

        readonly Grid grid = new Grid();
        
        Movement movement = Movement.Create();
        Snake snake;
        Food food;

        bool lost;

        public Engine()
        {
            food = new Food(grid.RandomPosition);
            snake = new Snake(grid.Center, length: 5);
        }

        public void Run()
        {
            Console.CursorVisible = false;
            
            grid.Draw();

            while (!lost)
            {
                if (Console.KeyAvailable)
                {
                    var input = Console.ReadKey();
                    movement = ProcessInput(input.KeyChar);
                }

                CheckCollisions();

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
                return;
            }

            snake.Clear();
            snake.MoveTo(nextPosition);
        }
    }
}