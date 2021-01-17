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
            var input = new Input();
            var timer = new GameTimer();
            var maze = new Maze();
            var food = new Food(maze);
            var snake = new Snake(maze);
            var engine = new Engine(timer, input, snake, food);

            await engine.Run();
        }
    }
}