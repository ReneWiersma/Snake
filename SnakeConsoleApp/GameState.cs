namespace SnakeConsoleApp
{
    public class GameState
    {
        private readonly Snake snake;
        private readonly Food food;

        public GameState(Snake snake, Food food)
        {
            this.snake = snake;
            this.food = food;

            Continue = true;
        }

        public bool Continue { get; private set; }

        public void ChangeSnakeDirection(Direction direction) => snake.ChangeDirection(direction);

        public void Update()
        {
            if (snake.Collides)
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
