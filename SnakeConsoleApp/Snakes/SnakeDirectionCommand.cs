namespace SnakeConsoleApp
{
    public class SnakeDirectionCommand : ICommand
    {
        private readonly SnakeDirection snakeDirection;
        private readonly Direction direction;

        public SnakeDirectionCommand(SnakeDirection snakeDirection, Direction direction)
        {
            this.snakeDirection = snakeDirection;
            this.direction = direction;
        }

        public void Execute() => snakeDirection.Change(direction);
    }
}
