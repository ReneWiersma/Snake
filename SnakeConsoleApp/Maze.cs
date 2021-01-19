using System;

namespace SnakeConsoleApp
{
    public class Maze
    {
        readonly Random random = new();

        private readonly int height;
        private readonly int width;

        public Maze(int height, int width)
        {
            this.height = height;
            this.width = width;
            
            Draw();
        }

        public Position RandomPosition =>
            new Position(random.Next(width - 2) + 1, random.Next(height - 2) + 1);

        public Position Center => new Position(width / 2, height / 2);

        private bool IsEdge(int row, int col) => 
            row == 0 || row == width - 1 || col == 0 || col == height - 1;

        void Draw()
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
