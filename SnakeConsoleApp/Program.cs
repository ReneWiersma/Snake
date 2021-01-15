using System;
using System.Threading;

namespace ConsoleApp1
{
    /// <summary>
    /// Original code based on code review request by user Terradice on StackExchange:
    /// https://codereview.stackexchange.com/questions/210835/console-snake-game-in-c
    /// </summary>

    class Program
    {
        static readonly int gridW = 90;
        static readonly int gridH = 25;
        static readonly Cell[,] grid = new Cell[gridH, gridW];
        static Cell currentCell;
        static int direction; //0=Up 1=Right 2=Down 3=Left
        static readonly int speed = 1;
        static int snakeLength = 5;
        static bool lost;

        static void Main(string[] args)
        {
            PopulateGrid();

            currentCell = grid[(int)Math.Ceiling((double)gridH / 2), (int)Math.Ceiling((double)gridW / 2)];
            
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
                    DoInput(input.KeyChar);
                }
                else
                {
                    Move();
                    PrintGrid();
                }
            }

            Console.WriteLine("\nYou lost!");
            Console.ReadKey();
        }

        static void CheckCell(Cell cell)
        {
            if (cell.Val == "%")
            {
                EatFood();
            }
            if (cell.Visited)
            {
                Lose();
            }
        }

        static void Lose()
        {
            lost = true;
        }

        static void DoInput(char inp)
        {
            switch (inp)
            {
                case 'w':
                    GoUp();
                    break;
                case 's':
                    GoDown();
                    break;
                case 'a':
                    GoRight();
                    break;
                case 'd':
                    GoLeft();
                    break;
            }
        }

        static void AddFood()
        {
            var random = new Random();
            
            var cell = grid[random.Next(grid.GetLength(0)), random.Next(grid.GetLength(1))];
            
            if (cell.Val == " ")
                cell.Val = "%";
        }

        static void EatFood()
        {
            snakeLength += 1;
            AddFood();
        }

        static void GoUp()
        {
            if (direction == 2)
                return;
            direction = 0;
        }

        static void GoRight()
        {
            if (direction == 3)
                return;
            direction = 1;
        }

        static void GoDown()
        {
            if (direction == 0)
                return;
            direction = 2;
        }

        static void GoLeft()
        {
            if (direction == 1)
                return;
            direction = 3;
        }

        static void Move()
        {
            if (direction == 0)
            {
                //up
                if (grid[currentCell.Y - 1, currentCell.X].Val == "*")
                {
                    Lose();
                    return;
                }
                VisitCell(grid[currentCell.Y - 1, currentCell.X]);
            }
            else if (direction == 1)
            {
                //right
                if (grid[currentCell.Y, currentCell.X - 1].Val == "*")
                {
                    Lose();
                    return;
                }
                VisitCell(grid[currentCell.Y, currentCell.X - 1]);
            }
            else if (direction == 2)
            {
                //down
                if (grid[currentCell.Y + 1, currentCell.X].Val == "*")
                {
                    Lose();
                    return;
                }
                VisitCell(grid[currentCell.Y + 1, currentCell.X]);
            }
            else if (direction == 3)
            {
                //left
                if (grid[currentCell.Y, currentCell.X + 1].Val == "*")
                {
                    Lose();
                    return;
                }
                VisitCell(grid[currentCell.Y, currentCell.X + 1]);
            }
            Thread.Sleep(speed * 100);
        }

        static void VisitCell(Cell cell)
        {
            currentCell.Val = "#";
            currentCell.Visited = true;
            currentCell.Decay = snakeLength;
            CheckCell(cell);
            currentCell = cell;
            UpdatePos();
        }

        static void UpdatePos()
        {
            currentCell.Set("@");
            if (direction == 0)
            {
                currentCell.Val = "^";
            }
            else if (direction == 1)
            {
                currentCell.Val = "<";
            }
            else if (direction == 2)
            {
                currentCell.Val = "v";
            }
            else if (direction == 3)
            {
                currentCell.Val = ">";
            }

            currentCell.Visited = false;
            return;
        }

        static void PopulateGrid()
        {
            for (int col = 0; col < gridH; col++)
            {
                for (int row = 0; row < gridW; row++)
                {
                    Cell cell = new Cell
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

            string toPrint = "";
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
        public class Cell
        {
            public string Val
            {
                get;
                set;
            }
            public int X
            {
                get;
                set;
            }
            public int Y
            {
                get;
                set;
            }
            public bool Visited
            {
                get;
                set;
            }
            public int Decay
            {
                get;
                set;
            }

            public void DecaySnake()
            {
                Decay -= 1;
                if (Decay == 0)
                {
                    Visited = false;
                    Val = " ";
                }
            }

            public void Clear()
            {
                Val = " ";
            }

            public void Set(string newVal)
            {
                Val = newVal;
            }
        }
    }
}