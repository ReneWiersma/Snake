namespace SnakeConsoleApp
{
    public record Position(int X, int Y)
    {
        public Position Left() => new Position(X - 1, Y);
        public Position Right() => new Position(X + 1, Y);
        public Position Up() => new Position(X, Y - 1);
        public Position Down() => new Position(X, Y + 1);
    }
}
