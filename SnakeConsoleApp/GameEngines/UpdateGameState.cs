namespace SnakeConsoleApp
{
    public class UpdateGameState : IQuery<bool> 
    {
        private readonly Maze maze;
        private readonly Snake snake;
        private readonly Food food;

        public UpdateGameState(Maze maze, Snake snake, Food food)
        {
            this.maze = maze;
            this.snake = snake;
            this.food = food;
        }

        public bool Execute()
        {
            if (snake.Collides(maze))
                return false;

            if (snake.Eats(food))
            {
                snake.Grow();
                food.Regenerate();
            }

            snake.Move();

            return true;
        }
    }
}
