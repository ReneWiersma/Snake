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
            var consoleDrawer = new ConsoleDrawer();

            var mazeDrawer = new MazeDrawer(consoleDrawer);
            var maze = new Maze(height: 25, width: 90, mazeDrawer);

            var snakeDirection = new SnakeDirection();
            var snakeBodyDrawer = new SnakeBodyDrawer(snakeDirection, consoleDrawer);
            var snakeBody = new SnakeBody(maze.StartPosition, snakeLength: 5, snakeBodyDrawer);
            var snake = new Snake(snakeBody, snakeDirection);
            
            var freePositions = new FreePositions(maze, snakeBody);
            var foodDrawer = new FoodDrawer(consoleDrawer);
            var food = new Food(freePositions, foodDrawer);

            SnakeDirectionCommand CreateChangeDirectionCommand(Direction direction) => new SnakeDirectionCommand(snakeDirection, direction);

            var getUser = new GetUser(CreateChangeDirectionCommand);
            var gameDelay = new GameDelay();
            var updateGameState = new UpdateGameState(maze, snake, food);
            var notifyLoss = new NotifyLoss();
            var engine = new Engine(updateGameState, gameDelay, getUser, notifyLoss);

            await engine.Execute();
        }
    }
}
