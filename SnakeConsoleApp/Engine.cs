using System;
using System.Threading;

namespace SnakeConsoleApp
{
    public class Engine
    {
        const int speed = 1;

        readonly Snake snake;
        readonly Food food;

        bool lost;

        public Engine(Snake snake, Food food)
        {
            this.snake = snake;
            this.food = food;
        }

        public void Run()
        {
            Console.CursorVisible = false;
            
            while (!lost)
            {
                Thread.Sleep(speed * 100);

                if (Console.KeyAvailable)
                {
                    var input = Console.ReadKey();
                    var direction = ProcessInput(input.KeyChar);
                    snake.ChangeDirection(direction);
                }

                if (snake.Collides)
                {
                    lost = true;
                }
                else
                {
                    if (snake.Eats(food))
                    {
                        snake.Grow();
                        food.New();
                    }

                    snake.Move();
                }
                
                Console.SetCursorPosition(0, 25);
            }

            Console.WriteLine("You lost!");
            Console.ReadKey();
        }

        Direction ProcessInput(char input) => input switch
        {
            's' => Direction.Down,
            'a' => Direction.Left,
            'd' => Direction.Right,
            'w' => Direction.Up,
            _ => Direction.Up,
        };
    }
}