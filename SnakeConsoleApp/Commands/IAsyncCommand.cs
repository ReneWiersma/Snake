using System.Threading.Tasks;

namespace SnakeConsoleApp
{
    public interface IAsyncCommand
    {
        Task Execute();
    }
}
