namespace SnakeConsoleApp
{
    public record Position(int X, int Y)
    {
        public Position Left(int steps = 1) => new Position(X - steps, Y);
        public Position Right(int steps = 1) => new Position(X + steps, Y);
        public Position Up(int steps = 1) => new Position(X, Y - steps);
        public Position Down(int steps = 1) => new Position(X, Y + steps);
    }
}
