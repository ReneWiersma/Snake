using System;
using System.Threading;

namespace SnakeConsoleApp
{
    public class Engine
    {
        const int speed = 1;

        readonly Grid grid;
        readonly Snake snake;
        readonly Food food;

        bool lost;

        public Engine(Grid grid, Snake snake, Food food)
        {
            this.grid = grid;
            this.snake = snake;
            this.food = food;
        }

        public void Run()
        {
            Console.CursorVisible = false;
            
            grid.Draw();
            food.Draw();

            while (!lost)
            {
                Thread.Sleep(speed * 100);

                if (Console.KeyAvailable)
                {
                    var input = Console.ReadKey();
                    var direction = ProcessInput(input.KeyChar);
                    snake.ChangeDirection(direction);
                }

                if (snake.Collides(grid))
                {
                    lost = true;
                }
                else
                {
                    if (snake.Eats(food))
                    {
                        snake.Grow();
                        food.Update(grid.RandomPosition);
                        food.Draw();
                    }

                    snake.Clear();
                    snake.Move();
                    snake.Draw();
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