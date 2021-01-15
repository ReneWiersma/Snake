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

        public Movement Up()
        {
            if (direction != Direction.Down)
                return new Movement(Direction.Up);

            return this;
        }

        public Movement Down()
        {
            if (direction != Direction.Up)
                return new Movement(Direction.Down);

            return this;
        }

        public Movement Left()
        {
            if (direction != Direction.Right)
                return new Movement(Direction.Left);

            return this;
        }

        public Movement Right()
        {
            if (direction != Direction.Left)
                return new Movement(Direction.Right);

            return this;
        }

        public (int y, int x) NextPosition(int y, int x) => direction switch
        {
            Direction.Left => (y, x - 1),
            Direction.Down => (y + 1, x),
            Direction.Right => (y, x + 1),
            _ => (y - 1, x),
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