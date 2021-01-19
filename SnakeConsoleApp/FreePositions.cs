namespace SnakeConsoleApp
{
    public class FreePositions
    {
        private readonly Maze maze;
        private readonly SnakeBody snakeBody;

        public FreePositions(Maze maze, SnakeBody snakeBody)
        {
            this.maze = maze;
            this.snakeBody = snakeBody;
        }

        public Position GetRandom()
        {
            var newPosition = maze.RandomFreePosition;
            
            if (snakeBody.IsAt(newPosition))
                return GetRandom();

            return newPosition;
        }
    }
}
