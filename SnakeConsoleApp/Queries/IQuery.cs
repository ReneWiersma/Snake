namespace SnakeConsoleApp
{
    public interface IQuery<TOut>
    {
        TOut Execute();
    }
}
