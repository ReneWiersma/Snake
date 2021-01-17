using System.Threading.Tasks;

namespace SnakeConsoleApp
{
    public class GameTimer
    {
        const int intervalMs = 100;

        public async Task Pause() => await Task.Delay(intervalMs);
    }
}
