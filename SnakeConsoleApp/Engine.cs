﻿using System;
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

            while (!lost)
            {
                if (Console.KeyAvailable)
                {
                    var input = Console.ReadKey();
                    var direction = ProcessInput(input.KeyChar);
                    snake.ChangeDirection(direction);
                }

                CheckCollisions();

                snake.Draw();
                food.Draw();

                Console.SetCursorPosition(0, 25);

                Thread.Sleep(speed * 100);
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

        void CheckCollisions()
        {
            var nextPosition = snake.NextPosition();

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