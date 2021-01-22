using System;

namespace SnakeConsoleApp
{
    public class NotifyLossCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("You lost!");
            Console.ReadKey();
        }
    }
}
