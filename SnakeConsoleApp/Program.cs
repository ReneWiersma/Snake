﻿using System;
using System.Threading;

namespace SnakeConsoleApp
{
    /// <summary>
    /// Original code based on code review request by user Terradice on StackExchange:
    /// https://codereview.stackexchange.com/questions/210835/console-snake-game-in-c
    /// </summary>
    partial class Program
    {
        static readonly int gridW = 90;
        static readonly int gridH = 25;
        static readonly Cell[,] grid = new Cell[gridH, gridW];
        static readonly int speed = 1;

        static Cell currentCell;
        static int snakeLength = 5;
        static bool lost;
        static Movement movement = Movement.Default;

        static void Main(string[] args)
        {
            PopulateGrid();

            currentCell = grid[gridH / 2, gridW / 2];

            UpdatePos();
            AddFood();

            PlayGame();
        }

        static void PlayGame()
        {
            while (!lost)
            {
                if (Console.KeyAvailable)
                {
                    var input = Console.ReadKey();
                    ProcessInput(input.KeyChar);
                }

                MoveSnake();
                UpdatePos();
                PrintGrid();
                
                Thread.Sleep(speed * 100);
            }

            Console.WriteLine("\nYou lost!");
            Console.ReadKey();
        }

        static void Lose()
        {
            lost = true;
        }

        static void ProcessInput(char inp)
        {
            switch (inp)
            {
                case 'w':
                    movement = movement.Up();
                    break;
                case 's':
                    movement = movement.Down();
                    break;
                case 'a':
                    movement = movement.Left();
                    break;
                case 'd':
                    movement = movement.Right();
                    break;
            }
        }

        static void AddFood()
        {
            var random = new Random();

            var cell = grid[random.Next(grid.GetLength(0) - 2) + 1, random.Next(grid.GetLength(1) - 2) + 1];

            cell.Val = "%";
        }

        static void EatFood()
        {
            snakeLength += 1;
            AddFood();
        }

        static void MoveSnake()
        {
            var (y, x) = movement.NextPosition(currentCell.Y, currentCell.X);
            var nextCell = grid[y, x];

            if (nextCell.Val == "*" || nextCell.Visited)
            {
                Lose();
                return;
            }

            if (nextCell.Val == "%")
                EatFood();

            currentCell.Val = "#";
            currentCell.Visited = true;
            currentCell.Decay = snakeLength;

            currentCell = nextCell;
        }

        static void UpdatePos()
        {
            currentCell.Val = movement.SnakeHead;
            currentCell.Visited = false;
        }

        static void PopulateGrid()
        {
            for (int col = 0; col < gridH; col++)
            {
                for (int row = 0; row < gridW; row++)
                {
                    var cell = new Cell
                    {
                        X = row,
                        Y = col,
                        Visited = false
                    };
                    if (cell.X == 0 || cell.X > gridW - 2 || cell.Y == 0 || cell.Y > gridH - 2)
                        cell.Set("*");
                    else
                        cell.Clear();
                    grid[col, row] = cell;
                }
            }
        }

        static void PrintGrid()
        {
            Console.SetCursorPosition(0, 0);

            var toPrint = "";

            for (int col = 0; col < gridH; col++)
            {
                for (int row = 0; row < gridW; row++)
                {
                    grid[col, row].DecaySnake();
                    toPrint += grid[col, row].Val;
                }

                toPrint += "\n";
            }

            Console.WriteLine(toPrint);
        }
    }
}