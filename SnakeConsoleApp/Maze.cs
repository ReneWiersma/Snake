using System;

namespace SnakeConsoleApp
{
    public class Maze
    {
        const int width = 90;
        const int height = 25;

        readonly Random random = new();

        public Maze()
        {
            Draw();
        }

        public Position RandomPosition =>
            new Position(random.Next(width - 2) + 1, random.Next(height - 2) + 1);

        public Position Center => new Position(width / 2, height / 2);

        private static bool IsEdge(int row, int col) => 
            row is 0 or width - 1 || col is 0 or height - 1;

        public void Draw()
        {
            Console.SetCursorPosition(0, 0);

            var toPrint = "";

            for (int col = 0; col < height; col++)
            {
                for (int row = 0; row < width; row++)
                {
                    if (IsEdge(row, col))
                        toPrint += "*";
                    else
                        toPrint += " ";
                }

                toPrint += "\n";
            }

            Console.WriteLine(toPrint);
        }

        public bool IsWallAt(Position pos) => IsEdge(pos.X, pos.Y);
    }
}
