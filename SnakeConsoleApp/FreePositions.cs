namespace SnakeConsoleApp
{
    public class FreePositions
    {
        private readonly Maze maze;
        private readonly Snake snake;

        public FreePositions(Maze maze, Snake snake)
        {
            this.maze = maze;
            this.snake = snake;
        }

        public Position GetRandom()
        {
            var newPosition = maze.RandomPosition;
            
            if (snake.IsAt(newPosition))
                return GetRandom();

            return newPosition;
        }
    }
}
