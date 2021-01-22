namespace SnakeConsoleApp
{
    public class Snake
    {
        private readonly SnakeBody snakeBody;
        private readonly SnakeDirection snakeDirection;

        public Snake(SnakeBody snakeBody, SnakeDirection snakeDirection)
        {
            this.snakeBody = snakeBody;
            this.snakeDirection = snakeDirection;
        }

        public void Grow() => snakeBody.Grow(NextPosition);

        public bool Eats(Food food) => food.IsAt(NextPosition);

        public bool Collides(Maze maze) => maze.IsWallAt(NextPosition) || snakeBody.IsAt(NextPosition);

        public void Move() => snakeBody.MoveTo(NextPosition);
        
        Position NextPosition => snakeDirection.NextPosition(snakeBody.CurrentPosition);
    }
}
