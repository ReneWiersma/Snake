using System;
using System.Threading;

namespace SnakeConsoleApp
{
    public class Engine
    {
        const int speed = 1;

        readonly Input input;
        readonly Snake snake;
        readonly Food food;

        bool lost;

        public Engine(Input input, Snake snake, Food food)
        {
            this.input = input;
            this.snake = snake;
            this.food = food;
        }

        public void Run()
        {
            while (!lost)
            {
                Thread.Sleep(speed * 100);

                if (input.TryGetDirection(out var direction))
                    snake.ChangeDirection(direction);

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
            }

            Console.WriteLine("You lost!");
            Console.ReadKey();
        }
    }
}