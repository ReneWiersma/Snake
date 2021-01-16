using System;

namespace SnakeConsoleApp
{
    public class Position
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

        public Position Left() => new Position(X-1, Y);
        public Position Right() => new Position(X + 1, Y);
        public Position Up() => new Position(X, Y - 1);
        public Position Down() => new Position(X, Y + 1);

    }
}
