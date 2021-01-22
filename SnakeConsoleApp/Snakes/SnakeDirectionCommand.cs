namespace SnakeConsoleApp
{
    public class SnakeDirectionCommand : ICommand
    {
        private readonly Snake snake;
        private readonly Direction direction;

        public SnakeDirectionCommand(Snake snake, Direction direction)
        {
            this.snake = snake;
            this.direction = direction;
        }

        public void Execute()
        {
            snake.ChangeDirection(direction);
        }
    }
}
