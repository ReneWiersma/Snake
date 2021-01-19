namespace SnakeConsoleApp
{
    public class Snake
    {
        private readonly SnakeBody snakeBody;
        private readonly SnakeDirection snakeDirection = new SnakeDirection();
        private readonly Maze maze;

        public Snake(Maze maze)
        {
            this.maze = maze;

            snakeBody = new SnakeBody(maze.Center, snakeLength: 5);
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
