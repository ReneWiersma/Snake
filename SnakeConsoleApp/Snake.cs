namespace SnakeConsoleApp
{
    public class Snake
    {
        private readonly SnakeBody snakeBody;
        private readonly SnakeDirection snakeDirection;
        private readonly Maze maze;

        public Snake(Maze maze, SnakeBody snakeBody, SnakeDirection snakeDirection)
        {
            this.maze = maze;
            this.snakeBody = snakeBody;
            this.snakeDirection = snakeDirection;
        }

        public void Grow() => snakeBody.Grow(NextPosition);

        public bool IsAt(Position position) => snakeBody.IsAt(position);

        public bool Eats(Food food) => food.IsAt(NextPosition);

        public bool Collides => maze.IsWallAt(NextPosition) || snakeBody.IsAt(NextPosition);

        public void ChangeDirection(Direction newDirection) => snakeDirection.Change(newDirection);

        Position NextPosition => snakeDirection.NextPosition(snakeBody.CurrentPosition);

        public void Move() => snakeBody.MoveTo(snakeDirection.SnakeHead, NextPosition);
    }
}
