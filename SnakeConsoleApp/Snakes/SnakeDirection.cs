namespace SnakeConsoleApp
{
    public class SnakeDirection
    {
        private Direction direction = Direction.Up;

        public string SnakeHead => direction switch
        {
            Direction.Left => "<",
            Direction.Down => "v",
            Direction.Right => ">",
            _ => "^",
        };

        public void Change(Direction newDirection)
        {
            if (RightAngled(newDirection))
                direction = newDirection;
        }

        bool RightAngled(Direction newDirection) => direction switch
        {
            Direction.Left or Direction.Right => newDirection is Direction.Up or Direction.Down,
            Direction.Up or Direction.Down => newDirection is Direction.Left or Direction.Right,
            _ => false,
        };

        public Position NextPosition(Position currentPosition) => direction switch
        {
            Direction.Left => currentPosition.Left(),
            Direction.Down => currentPosition.Down(),
            Direction.Right => currentPosition.Right(),
            _ => currentPosition.Up(),
        };
    }
}
