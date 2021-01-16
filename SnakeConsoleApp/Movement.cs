namespace SnakeConsoleApp
{
    public class Movement
    {
        private readonly Direction direction;
        
        private enum Direction
        {
            Up, Left, Down, Right
        }

        public static Movement Default => new Movement(Direction.Up);

        Movement(Direction direction)
        {
            this.direction = direction;
        }

        public Movement Up() => ChangeMovement(Direction.Up);

        public Movement Down() => ChangeMovement(Direction.Down);

        public Movement Left() => ChangeMovement(Direction.Left);

        public Movement Right() => ChangeMovement(Direction.Right);

        Movement ChangeMovement(Direction newDirection)
        {
            if (RightAngled(newDirection))
                return new Movement(newDirection);

            return this;
        }

        bool RightAngled(Direction newDirection) => direction switch
        {
            Direction.Left or Direction.Right => newDirection is Direction.Up or Direction.Down,
            Direction.Up or Direction.Down => newDirection is Direction.Left or Direction.Right,
            _ => false,
        };

        public (int x, int y) NextPosition(int x, int y) => direction switch
        {
            Direction.Left => (x - 1, y),
            Direction.Down => (x, y + 1),
            Direction.Right => (x + 1, y),
            _ => (x, y - 1),
        };

        public string SnakeHead => direction switch
        {
            Direction.Left => "<",
            Direction.Down => "v",
            Direction.Right => ">",
            _ => "^",
        };
    }
}