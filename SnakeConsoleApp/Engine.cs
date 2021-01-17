using System;
using System.Threading.Tasks;

namespace SnakeConsoleApp
{
    public class Engine
    {
        readonly GameTimer timer;
        readonly Input input;
        readonly Snake snake;
        readonly Food food;

        bool lost;

        public Engine(GameTimer timer, Input input, Snake snake, Food food)
        {
            this.timer = timer;
            this.input = input;
            this.snake = snake;
            this.food = food;
        }

        public async Task Run()
        {
            while (!lost)
            {
                await timer.Pause();

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