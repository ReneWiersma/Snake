using System;
using System.Threading;

namespace SnakeConsoleApp
{
    public class Engine
    {
        const int speed = 1;

        readonly Grid grid = new Grid();
        
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
                        snake = snake.Grow();
                        food = new Food(grid.RandomPosition);
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