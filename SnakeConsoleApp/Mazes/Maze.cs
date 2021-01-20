using System;
using System.Collections.Generic;

namespace SnakeConsoleApp
{
    public class Maze
    {
        private readonly Random random = new();

        private readonly int height;
        private readonly int width;

        public Maze(int height, int width, MazeDrawer drawer)
        {
            this.height = height;
            this.width = width;

            drawer.Draw(CreateWalls());
        }

        private IList<Position> CreateWalls()
        {
            var walls = new List<Position>();
            
            for (int col = 0; col < width; col++)
            {
                for (int row = 0; row < height; row++)
                {
                    if (IsEdge(col, row))
                        walls.Add(new Position(col, row));
                }
            }

            return walls;
        }

        public Position RandomFreePosition =>
            new Position(random.Next(width - 2) + 1, random.Next(height - 2) + 1);

        public Position StartPosition => new Position(width / 2, height / 2);

        private bool IsEdge(int col, int row) =>
            row == 0 || row == height - 1 || col == 0 || col == width - 1;

        public bool IsWallAt(Position pos) => IsEdge(pos.X, pos.Y);
    }
}
