using System.Threading.Tasks;

namespace SnakeConsoleApp
{
    public class GameDelay : IAsyncCommand
    {
        const int intervalMs = 100;

        public async Task Execute() => await Task.Delay(intervalMs);
    }
}
