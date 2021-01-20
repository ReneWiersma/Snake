using System.Threading.Tasks;

namespace SnakeConsoleApp
{
    public class GameTimer
    {
        const int intervalMs = 100;

        public async Task Delay() => await Task.Delay(intervalMs);
    }
}
