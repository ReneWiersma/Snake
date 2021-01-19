namespace SnakeConsoleApp
{
    public class GameState
    {
        private readonly Maze maze;
        private readonly Snake snake;
        private readonly Food food;

        public GameState(Maze maze, Snake snake, Food food)
        {
            this.maze = maze;
            this.snake = snake;
            this.food = food;

            Continue = true;
        }

        public bool Continue { get; private set; }

        public void ChangeSnakeDirection(Direction direction) => snake.ChangeDirection(direction);

        public void Update()
        {
            if (snake.Collides(maze))
            {
                Continue = false;
            }
            else
            {
                if (snake.Eats(food))
                {
                    snake.Grow();
                    food.Regenerate();
                }

                snake.Move();
            }
        }
    }
}
