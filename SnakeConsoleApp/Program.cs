using System.Threading.Tasks;

namespace SnakeConsoleApp
{
    /// <summary>
    /// Original code based on code review request by user Terradice on StackExchange:
    /// https://codereview.stackexchange.com/questions/210835/console-snake-game-in-c
    /// </summary>
    public class Program
    {
        static async Task Main(string[] args)
        {
            var userIO = new UserIO();
            var gameTimer = new GameTimer();
            var maze = new Maze(height: 25, width: 90);
            var snakeBody = new SnakeBody(maze.Center, snakeLength: 5);
            var snakeDirection = new SnakeDirection();
            var snake = new Snake(snakeBody, snakeDirection);
            var freePositions = new FreePositions(maze, snakeBody);
            var food = new Food(freePositions);
            var gameState = new GameState(maze, snake, food);
            var engine = new Engine(gameState, gameTimer, userIO);

            await engine.Run();
        }
    }
}
