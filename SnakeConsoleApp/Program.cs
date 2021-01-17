﻿namespace SnakeConsoleApp
{
    /// <summary>
    /// Original code based on code review request by user Terradice on StackExchange:
    /// https://codereview.stackexchange.com/questions/210835/console-snake-game-in-c
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            var input = new Input();
            var grid = new Grid();
            var food = new Food(grid);
            var snake = new Snake(grid);
            var engine = new Engine(input, snake, food);

            engine.Run();
        }
    }
}